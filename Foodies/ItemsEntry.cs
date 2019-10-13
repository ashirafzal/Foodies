using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Foodies
{
    public partial class ItemsEntry : Form
    {

        string imgLocation = "";

        public ItemsEntry()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //not in use
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //not in use
        }

        private void ProductPanel_Paint(object sender, PaintEventArgs e)
        {
            //just a panel 
        }

        private void browseimage_Click(object sender, EventArgs e)
        {
           //zaya   
        }

        private void CreateProduct_Click(object sender, EventArgs e)
        {
           //zaya
        }

        private void ProductEntry_Load(object sender, EventArgs e)
        {

        }

        private void browseimage_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }

        private void CreateProduct_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Helper.con);
                int b = Convert.ToInt32(txtPrice.Text);

                byte[] images = null;
                FileStream Stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Stream);
                images = brs.ReadBytes((int)Stream.Length);

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string sqlQuery = "insert into Products(ProductCategory,ProductName,ProductPrice,ProductImage) values ('" + txtCategory.Text.ToLower() + "','" + txtName.Text.ToLower() + "','" + b + "',@images)";
                cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                cmd.ExecuteNonQuery();
                con.Close();
                txtCategory.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                MessageBox.Show("Product Created Successfull");
            }
            catch (Exception)
            {
                MessageBox.Show("Fields can't be Empty");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ManageItems manageProduct = new ManageItems();
            manageProduct.Show();
        }
    }
    
}