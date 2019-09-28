using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Globalization;
using System.Net.Sockets;
using System.IO;
using System.Net.Cache;
using System.Text.RegularExpressions;

namespace Foodies
{
    public partial class Login : Form
    {
        string User_name = "ashirxyz",category = "admin";
        string druser, drcategory;
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
            con.Open();
            try
            {
                if (username.Text == "ashirxyz" || password.Text == "foodies-ashir")
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into LoginDetails (Loginuser,usercategory,time,date) values ('" + User_name + "','" + category + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.ToShortDateString() + "')";
                    cmd.ExecuteNonQuery();
                    //Cashier main = new Cashier();
                    Cashier2 main = new Cashier2();
                    this.Hide();
                    main.Show();
                }
                else if (username.Text == string.Empty || password.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Username and Password");
                }
                else
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT username,password from users where username = '" + username.Text.ToLower() + "' and password = '" + password.Text.ToLower() + "' ", con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        //Transaction start
                        SqlTransaction tran = con.BeginTransaction();

                        SqlCommand cmd10 = new SqlCommand("select * from users where username = '" + username.Text.ToLower() + "' and password = '" + password.Text.ToLower() + "' ", con, tran);
                        cmd10.ExecuteNonQuery();

                        using (SqlDataReader dr = cmd10.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                druser = Convert.ToString(dr["username"]);
                                drcategory = Convert.ToString(dr["category"]);
                            }
                        }
                        tran.Commit();
                        // Transaction closed
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into LoginDetails (Loginuser,usercategory,time,date) values ('" + druser + "','" + drcategory + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.ToShortDateString() + "')";
                        cmd.ExecuteNonQuery();

                        //Cashier main = new Cashier();
                        Cashier2 main = new Cashier2();
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
                MessageBox.Show(this, "Please enter correct username & password or use the default username and password for login",
                    "User Mishandling", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void password_Enter(object sender, EventArgs e)
        {
           
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
