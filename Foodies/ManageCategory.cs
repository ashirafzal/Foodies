using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodies
{
    public partial class ManageCategory : Form
    {
        string imgLocation = "";

        public ManageCategory()
        {
            InitializeComponent();
        }

        private void ManageCategory_Load(object sender, EventArgs e)
        {
            dgv_1();
            // TODO: This line of code loads data into the 'categoryDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.categoryDataSet.Category);
        }

        public void dgv_1()
        {
            dgv1.RowTemplate.Height = 200;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(10, 8, 0, 8);
            this.dgv1.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular);

            // This Part of Code is for the styling of the Grid Border
            this.dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Byte[] img = (Byte[])dgv1.CurrentRow.Cells[2].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);

            CategoryID.Text = dgv1.CurrentRow.Cells[0].Value.ToString();
            CategoryName.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
            
        }

        private void dgv1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgv1.Rows[e.RowIndex].ErrorText = "Concisely describe the error and how to fix it";
            e.Cancel = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] images = null;
                FileStream Stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Stream);
                images = brs.ReadBytes((int)Stream.Length);

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                int a1 = Convert.ToInt16(CategoryID.Text);
                string sqlQuery = "update Category set CategoryName = @CategoryName, CategoryImage = @images where CategoryId = '" + a1 + "'  ";
                cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Add(new SqlParameter("@CategoryName", CategoryName.Text));
                cmd.Parameters.Add(new SqlParameter("@images", images));
                var N = cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                con.Close();
                CategoryID.Text = string.Empty;
                CategoryName.Text = string.Empty;
                MessageBox.Show("Category updated");
                // TODO: This line of code loads data into the 'categoryDataSet.Category' table. You can move, or remove it, as needed.
                this.categoryTableAdapter.Fill(this.categoryDataSet.Category);
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Products where ProductCategory = '" + CategoryName.Text + "'  ", con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            MessageBox.Show("There are "+ table.Rows.Count.ToString() + " products in this category. These Products will also be deleted with this category. Are you sure you want to continue this ?");

            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "delete from Category where CategoryName ='" + CategoryName.Text + "'";
            //cmd.ExecuteNonQuery();

            //SqlCommand cmd1 = con.CreateCommand();
            //cmd1.CommandType = CommandType.Text;
            //cmd1.CommandText = "delete from Products where ProductCategory ='" + CategoryName.Text + "'";
            //cmd1.ExecuteNonQuery();

            //CategoryID.Text = string.Empty;
            //CategoryName.Text = string.Empty;

            //// TODO: This line of code loads data into the 'categoryDataSet.Category' table. You can move, or remove it, as needed.
            //this.categoryTableAdapter.Fill(this.categoryDataSet.Category);

            //MessageBox.Show("Category and products under this category deleted successfully");

            con.Close();
        }
    }
}
