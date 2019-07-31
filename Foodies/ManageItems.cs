using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace Foodies
{
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
            // TODO: This line of code loads data into the 'itemsDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.itemsDataSet.Products);

        }

        public void dgv_CashierRegister()
        {
            dgv1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(10, 8, 0, 8);
            this.dgv1.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 15F, FontStyle.Bold);

            //This Part of Code is for the styling of the Visaul Style
            dgv1.EnableHeadersVisualStyles = false;

            // This Part of Code is for the styling of the Grid Border
            this.dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;

            //This Part of Code is for the styling of the Grid Rows
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 15F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //this line of code is applying padding to a specific Column of dgv1 which is Product Column
            //dgv1.Columns[2].DefaultCellStyle.Padding = new Padding(2, 2, 2, 2);

            this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv1.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Bold);


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
            pictureBox1.Image = Image.FromStream(ms);

            ProductID.Text = dgv1.CurrentRow.Cells[0].Value.ToString();
            ProductCategory.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
            ProductName.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
            ProductPrice.Text = dgv1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
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
                int a1 = Convert.ToInt16(ProductID.Text);
                int b = Convert.ToInt32(ProductPrice.Text);
                string sqlQuery = "update Products set ProductCategory = @ProductCategory , ProductName = @ProductName , ProductPrice =  @b , ProductImage = @images where ProductId = '" + a1 + "'  ";
                cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Add(new SqlParameter("@ProductCategory", ProductCategory.Text));
                cmd.Parameters.Add(new SqlParameter("@ProductName", ProductName.Text));
                cmd.Parameters.Add(new SqlParameter("@b", ProductPrice.Text));
                cmd.Parameters.Add(new SqlParameter("@images", images));
                var N = cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                con.Close();
                ProductID.Text = string.Empty;
                ProductName.Text = string.Empty;
                ProductCategory.Text = string.Empty;
                ProductPrice.Text = string.Empty;
                MessageBox.Show("Product updated Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
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
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
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
                MessageBox.Show("Product Deleted Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("ProductID can't be empty");
            }
        }
    }
}
