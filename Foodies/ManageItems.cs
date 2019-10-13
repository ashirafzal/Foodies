using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace Foodies
{
    [System.Runtime.InteropServices.ComVisible(true)]
    [System.Serializable]

    public partial class ManageItems : Form
    {
        string imgLocation = "";

        public ManageItems()
        {
            InitializeComponent();
            dgv_CashierRegister();
            dgv1.RowTemplate.Height = 200;
            dgv1.AllowUserToAddRows = false;
        }

        private void ManageProduct_Load(object sender, EventArgs e)
        {
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

            for (int i = 0; i < dgv1.Columns.Count; i++)
                if (dgv1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgv1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }
        }

        public void dgv_CashierRegister()
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Byte[] img = (Byte[])dgv1.CurrentRow.Cells[4].Value;
            MemoryStream ms = new MemoryStream(img);
            //pictureBox1.Image = Image.FromStream(ms);

            ProductID.Text = dgv1.CurrentRow.Cells[0].Value.ToString();
            ProductName.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
            ProductPrice.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
            ProductCategory.Text = dgv1.CurrentRow.Cells[3].Value.ToString();  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int a1 = Convert.ToInt16(ProductID.Text);
                int b = Convert.ToInt32(ProductPrice.Text);

                byte[] images = null;
                FileStream Stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Stream);
                images = brs.ReadBytes((int)Stream.Length);

                SqlConnection con = new SqlConnection(Helper.con);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string sqlQuery = "update Products set ProductName = @ProductName , ProductPrice =  @b ,ProductCategory = @ProductCategory, ProductImage = @images where ProductId = '" + a1 + "'  ";
                cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Add(new SqlParameter("@ProductCategory", ProductCategory.Text.ToLower()));
                cmd.Parameters.Add(new SqlParameter("@ProductName", ProductName.Text.ToLower()));
                cmd.Parameters.Add(new SqlParameter("@b", b));
                cmd.Parameters.Add(new SqlParameter("@images", images));
                var N = cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                con.Close();
                ProductID.Text = string.Empty;
                ProductName.Text = string.Empty;
                ProductCategory.Text = string.Empty;
                ProductPrice.Text = string.Empty;
                MessageBox.Show("Product updated");
                LoadGridView1();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter numeric value in required fields");
            }
            catch (Exception)
            {
                if (ProductID.Text == string.Empty)
                {
                    MessageBox.Show("Please fill required field");
                }
                else if (ProductCategory.Text == string.Empty)
                {
                    MessageBox.Show("Please fill required field");
                }
                else if (ProductName.Text == string.Empty)
                {
                    MessageBox.Show("Please fill required field");
                }
                else if (ProductPrice.Text == string.Empty)
                {
                    MessageBox.Show("Please fill required field");
                }
                else if (ProductID.Text == string.Empty || ProductCategory.Text == string.Empty
                    || ProductName.Text == string.Empty || ProductPrice.Text == string.Empty )
                {
                    MessageBox.Show("Please fill all required fields");
                }
                else
                {
                    MessageBox.Show("Please select a image to update product");
                }     
            }

        }

        private void dgv1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgv1.Rows[e.RowIndex].ErrorText = "Concisely describe the error and how to fix it";
            e.Cancel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Helper.con);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                int a1 = Convert.ToInt16(ProductID.Text);
                cmd.CommandText = "delete from Products where ProductId ='" + a1 + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                ProductID.Text = string.Empty;
                ProductCategory.Text = string.Empty;
                ProductName.Text = string.Empty;
                ProductPrice.Text = string.Empty;
                MessageBox.Show("Product Deleted");
                LoadGridView1();
            }
            catch (Exception)
            {
                MessageBox.Show("ProductID can't be empty");
            }
        }
    }
}
