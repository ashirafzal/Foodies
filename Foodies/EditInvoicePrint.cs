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
    public partial class EditInvoicePrint : Form
    {
        int INVOICEID;

        public EditInvoicePrint()
        {
            InitializeComponent();
        }

        public void LoadGridView()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            SqlCommand cmd10 = new SqlCommand("select top 1 InvioceID2 from EditedBill order by InvioceID2 DESC", con, tran);
            cmd10.ExecuteNonQuery();

            using (SqlDataReader dr = cmd10.ExecuteReader())
            {
                while (dr.Read())
                {
                    INVOICEID = Convert.ToInt32(dr["InvioceID2"]);
                }
            }

            tran.Commit();
            string query = "select * from Bill where InvioceID = '"+ INVOICEID +"' ";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv1.DataSource = dt;

            con.Close();
        }

        public void PrintEditedInvoices()
        {

        }

        private void EditInvoicePrint_Load(object sender, EventArgs e)
        {
            dgv1.Height = 0;
            LoadGridView();
        }
    }
}