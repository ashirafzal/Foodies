using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Foodies
{
    public partial class Current_Invoice_Print : Form
    {
        int INVOICEID;

        public Current_Invoice_Print()
        {
            InitializeComponent();
        }

        private void Current_Invoice_Print_Load(object sender, EventArgs e)
        {
            FileandFolder();
            LoadGridView();
            PrintEditedInvoices();
        }

        public void FileandFolder()
        {
            string FolderPath = "C://FoodiesBill";
            string FilePath = "C://FoodiesBill/Bill.xml";

            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
                if (!File.Exists(FilePath))
                {
                    var myFile = File.Create(FilePath);
                    myFile.Close();
                }
                else
                {

                }
            }
            else
            {
                if (!File.Exists(FilePath))
                {
                    var myFile = File.Create(FilePath);
                    myFile.Close();
                }
                else
                {

                }
            }
        }

        public void LoadGridView()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            SqlCommand cmd10 = new SqlCommand("select top 1 InvioceID from Bill order by InvioceID DESC", con, tran);
            cmd10.ExecuteNonQuery();

            using (SqlDataReader dr = cmd10.ExecuteReader())
            {
                while (dr.Read())
                {
                    INVOICEID = Convert.ToInt32(dr["InvioceID"]);
                }
            }

            tran.Commit();
            string query = "select * from Bill where InvioceID = '" + INVOICEID + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv1.DataSource = dt;

            con.Close();
        }

        public void PrintEditedInvoices()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("InvioceID", typeof(string));
            dt.Columns.Add("CustID", typeof(string));
            dt.Columns.Add("OrderID", typeof(string));
            dt.Columns.Add("CustName", typeof(string));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("ProductQuantity", typeof(string));
            dt.Columns.Add("ProductRate", typeof(string));
            dt.Columns.Add("ProductAmount", typeof(string));
            dt.Columns.Add("ProductAmountWithGST", typeof(string));
            dt.Columns.Add("OrderTime", typeof(string));
            dt.Columns.Add("OrderDate", typeof(string));
            dt.Columns.Add("Totalqty", typeof(string));
            dt.Columns.Add("ActualAmount", typeof(string));
            dt.Columns.Add("TotalAmount", typeof(string));
            dt.Columns.Add("TotalAmountWithGST", typeof(string));
            dt.Columns.Add("DiscountInPercent", typeof(string));

            foreach (DataGridViewRow dgv in dgv1.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value, dgv.Cells[10].Value
                    , dgv.Cells[11].Value, dgv.Cells[12].Value, dgv.Cells[13].Value, dgv.Cells[14].Value, dgv.Cells[15].Value);
            }

            ds.Tables.Add(dt);
            //ds.WriteXmlSchema("C://FoodiesBill/Bill.xml");
            ds.WriteXmlSchema("C://FoodiesBill/Bill.xml");

            CrystalReport1 bp = new CrystalReport1();
            bp.SetDataSource(ds);
            crystalReportViewer1.ReportSource = bp;
            //crystalReportViewer1.PrintReport();
        }

    }
}