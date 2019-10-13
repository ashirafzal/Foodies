using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Foodies
{
    public partial class SubProductManagement_System : Form
    {
        string imgLocation = "";

        public SubProductManagement_System()
        {
            InitializeComponent();
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void browseimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }

        private void CreateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Helper.con);

                byte[] images = null;
                FileStream Stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Stream);
                images = brs.ReadBytes((int)Stream.Length);

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string sqlQuery = "insert into Category(CategoryName,CategoryImage) values ('" + txtCategory.Text.ToLower()  + "',@images)";
                cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Category Created Successfull");
            }
            catch (Exception)
            {
                MessageBox.Show("Fields can't be Empty");
            }
        }

        private void ProductPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SubProductManagement_System_Load(object sender, EventArgs e)
        {

        }
    }
}
