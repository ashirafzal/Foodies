using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodies
{
    public partial class ProductPrice : Form
    {
        public ProductPrice()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void dgv_1()
        {
            dgv1.RowTemplate.Height = 40;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(0, 10, 0, 10);
            this.dgv1.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);
            dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //This Part of Code is for the styling of the Visaul Style
            //dgv1.EnableHeadersVisualStyles = false;

            // This Part of Code is for the styling of the Grid Border
            this.dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //this line of code is applying padding to a specific Column of dgv1 which is Product Column
            //dgv2.Columns[4].DefaultCellStyle.Padding = new Padding(3, 3, 3, 3);

        }

        private void ProductPrice_Load(object sender, EventArgs e)
        {
            dgv_1();
            txtSearchPrice.Focus();
            LoadGridView1();
        }

        public void LoadGridView1()
        {
            dgv1.Refresh();
            SqlConnection con = new SqlConnection(Helper.con);
            con.Open();
            string query = "select * from Products";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv1.DataSource = dt;
            con.Close();

            dgv1.Columns[0].HeaderText = "PRODUCT ID";
            dgv1.Columns[1].HeaderText = "PRODUCT NAME";
            dgv1.Columns[2].HeaderText = "PRODUCT PRICE";
            dgv1.Columns[3].HeaderText = "PRODUCT CATEGORY";
            dgv1.Columns[4].HeaderText = "PRODUCT IMAGE";
            dgv1.Columns[3].Visible = false;
            dgv1.Columns[4].Visible = false;

            for (int i = 0; i < dgv1.Columns.Count; i++)
                if (dgv1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgv1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }
        }

        private void SearchPrice_Click(object sender, EventArgs e)
        {
            try
            {

                if(txtSearchPrice.Text == string.Empty)
                {
                    MessageBox.Show("Product name cannot be blank");
                    txtSearchPrice.Focus();
                }
                else
                {
                    SqlConnection con = new SqlConnection(Helper.con);
                    con.Open();
                    string query = "select * from Products where ProductName = '" + txtSearchPrice.Text + "' ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dgv1.DataSource = dt;
                    con.Close();

                    txtSearchPrice.Text = string.Empty;
                    txtSearchPrice.Focus();
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error searching product name");
            }
        }
    }
}
