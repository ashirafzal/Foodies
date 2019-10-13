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
    public partial class CancelInvioce : Form
    {
        public CancelInvioce()
        {
            InitializeComponent();
        }

        private void DeleteInvioce_Load(object sender, EventArgs e)
        {
            dgv_1();
            LoadGridView();
        }

        public void LoadGridView()
        {
            SqlConnection con = new SqlConnection(Helper.con);
            con.Open();
            string query = "select * from Bill";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv1.DataSource = dt;
            con.Close();

            dgv1.Columns[0].HeaderText = "INVOICE ID";
            dgv1.Columns[1].HeaderText = "CUST ID";
            dgv1.Columns[2].HeaderText = "ORDER ID";
            dgv1.Columns[3].HeaderText = "CUST NAME";
            dgv1.Columns[4].HeaderText = "PRODUCT NAME";
            dgv1.Columns[5].HeaderText = "PRODUCT QTY";
            dgv1.Columns[6].HeaderText = "PRODUCT RATE";
            dgv1.Columns[7].HeaderText = "PRODUCT AMOUNT";
            dgv1.Columns[8].HeaderText = "GST AMOUNT";
            dgv1.Columns[9].HeaderText = "ORDER TIME";
            dgv1.Columns[10].HeaderText = "ORDER DATE";
            dgv1.Columns[11].HeaderText = "TOTAL QTY";
            dgv1.Columns[11].Visible = false;
            dgv1.Columns[12].HeaderText = "ACTUAL AMOUNT";
            dgv1.Columns[12].Visible = false;
            dgv1.Columns[13].HeaderText = "TOTAL AMOUNT";
            dgv1.Columns[13].Visible = false;
            dgv1.Columns[14].HeaderText = "TOTAL GST AMOUNT";
            dgv1.Columns[14].Visible = false;
            dgv1.Columns[15].HeaderText = "DISCOUNT";
            dgv1.Columns[15].Visible = false;
        }

        public void dgv_1()
        {
            dgv1.RowTemplate.Height = 42;

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
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void DeleteInvoice_Click(object sender, EventArgs e)
        {
            string Invoiceid, CustID, OrderID, CustName, ProductName,
                ProductQuantity, ProductRate, ProductAmount, ProductAmountWithGST,
                OrderTime, OrderDate, TotalQty, ActualAmount, TotalAmount, TotalAmountWithGST,
                DiscounInPercent;

            try
            {
                int txt_invoiceid = Convert.ToInt32(InvoiceNumber.Text);

                SqlConnection con = new SqlConnection(Helper.con);
                con.Open();
                string query = "select * from Bill where InvioceID  = '" + txt_invoiceid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv1.DataSource = dt;


                SqlTransaction tran = con.BeginTransaction();

                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    Invoiceid = Convert.ToString(dgv1.Rows[i].Cells[0].Value);
                    CustID = Convert.ToString(dgv1.Rows[i].Cells[1].Value);
                    OrderID = Convert.ToString(dgv1.Rows[i].Cells[2].Value);
                    CustName = Convert.ToString(dgv1.Rows[i].Cells[3].Value);
                    ProductName = Convert.ToString(dgv1.Rows[i].Cells[4].Value);
                    ProductQuantity = Convert.ToString(dgv1.Rows[i].Cells[5].Value);
                    ProductRate = Convert.ToString(dgv1.Rows[i].Cells[6].Value);
                    ProductAmount = Convert.ToString(dgv1.Rows[i].Cells[7].Value);
                    ProductAmountWithGST = Convert.ToString(dgv1.Rows[i].Cells[8].Value);
                    OrderTime = Convert.ToString(dgv1.Rows[i].Cells[9].Value);
                    OrderDate = Convert.ToString(dgv1.Rows[i].Cells[10].Value);
                    TotalQty = Convert.ToString(dgv1.Rows[i].Cells[11].Value);
                    ActualAmount = Convert.ToString(dgv1.Rows[i].Cells[12].Value);
                    TotalAmount = Convert.ToString(dgv1.Rows[i].Cells[13].Value);
                    TotalAmountWithGST = Convert.ToString(dgv1.Rows[i].Cells[14].Value);
                    DiscounInPercent = Convert.ToString(dgv1.Rows[i].Cells[15].Value);

                    SqlCommand cmd1 = new SqlCommand
                    ("insert into DeletedBill values ('" + Invoiceid + "' , '" + CustID + "' , '" + OrderID + "' , '" + CustName + "' , '" + ProductName + "' , '" + ProductQuantity + "' , '" + ProductRate + "' , '" + ProductAmount + "' , '" + ProductAmountWithGST + "' , '" + OrderTime + "' , '" + OrderDate + "' , '" + TotalQty + "' , '" + ActualAmount + "' , '" + TotalAmount + "' , '" + TotalAmountWithGST + "' , '" + DiscounInPercent + "') ", con, tran);
                    cmd1.ExecuteNonQuery();
                }

                SqlCommand cmd2 = new SqlCommand("Delete from Bill where InvioceID  = '" + txt_invoiceid + "' ", con, tran);
                cmd2.ExecuteNonQuery();

                tran.Commit();
                con.Close();

                InvoiceNumber.Text = "";
                InvoiceNumber.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("InvoiceID cannot be blank");
            }

            LoadGridView();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv1.Rows[e.RowIndex];

                InvoiceNumber.Text = row.Cells[0].Value.ToString();
            }
        }
    }
}