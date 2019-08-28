using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Foodies
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
        public Login()
        {
            InitializeComponent();
            username.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (username.Text == "user" || password.Text == "pass")
                {
                    Cashier main = new Cashier();
                    this.Hide();
                    main.Show();
                }
                else if (username.Text == string.Empty || password.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Username and Password");
                }
                else
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT username,password from Users where username = '" + username.Text + "' and password = '" + password.Text + "'", con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        Cashier main = new Cashier();
                        this.Hide();
                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Please enter username & password or use the default username and password for login",
                    "User Mishandling", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
