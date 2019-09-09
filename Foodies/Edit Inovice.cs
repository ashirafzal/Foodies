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
    public partial class Edit_Inovice : Form
    {
        int totalQuantity = 0;double actualAmount = 0;int invoiceid2 = 0;
        string discount, totalAmount, DRactualAmount;
        string CUSTID, CUSTNAME, CUSTCONTACT, ORDERID;
        decimal discountpercentageForAmount;

        public Edit_Inovice()
        {
            InitializeComponent();
            InvoiceNumber.Focus();
        }

        private void Edit_Inovice_Load(object sender, EventArgs e)
        {
            dgv_1();
            // TODO: This line of code loads data into the 'invoiceDataSet.Bill' table. You can move, or remove it, as needed.
            this.billTableAdapter.Fill(this.invoiceDataSet.Bill);

            ActualAmount.Text = "0";
            TotalQty.Text = "0";
            TotalAmount.Text = "0";
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

            // This Part of Code is for the styling of the Grid Border
            this.dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular);

            Padding newPadding2 = new Padding(10, 0, 10, 0);
            dgv1.RowsDefaultCellStyle.Padding = newPadding2;

            //this Line of Code made the dgv1 Text Middle Center
            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void SearchInvoice_Click(object sender, EventArgs e)
        {
           
        }

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int qty;
            int rate;
            int amount;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv1.Rows[e.RowIndex];

                ActualAmount.Text = "0";
                TotalQty.Text = "0";
                totalQuantity = 0; actualAmount = 0;

                this.dgv1.EditMode = DataGridViewEditMode.EditOnEnter;

                qty = Convert.ToInt32(row.Cells[5].Value);
                rate = Convert.ToInt32(row.Cells[6].Value);
                amount = qty * rate;
                row.Cells[7].Value = amount;

            }

            for (int i = 0; i < dgv1.Rows.Count; ++i)
            {
                totalQuantity += Convert.ToInt32(dgv1.Rows[i].Cells[5].Value);
                actualAmount += Convert.ToDouble(dgv1.Rows[i].Cells[7].Value);
            }

            ActualAmount.Text = actualAmount.ToString();
            TotalQty.Text = totalQuantity.ToString();
            TotalAmount.Text = actualAmount.ToString();
            txtDiscount.Text = string.Empty;
        }

        private void BtnDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                decimal discountAmountinPKR = Convert.ToInt32(txtDiscount.Text);
                decimal labelActualAmount = Convert.ToInt32(TotalAmount.Text);
                decimal ActualAmount = labelActualAmount - discountAmountinPKR;
                TotalAmount.Text = ActualAmount.ToString();
                discountpercentageForAmount = discountAmountinPKR / labelActualAmount * 100;
                txtDiscount.Text = string.Empty;
                txtDiscount.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter discount in Numbers"
                    +"\nHint 100 , 200 , 300 etc");
                txtDiscount.Text = string.Empty;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgv1.Refresh();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
            con.Open();
            string query = "select * from Bill";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv1.DataSource = dt;
            con.Close();

            totalQuantity = 0;
            actualAmount = 0;
            invoiceid2 = 0;

            ActualAmount.Text = "0";
            TotalQty.Text = "0";
            TotalAmount.Text = "0";
            txtDiscount.Text = string.Empty;
            txtDiscount.Visible = true;
            InvoiceNumber.Focus();
        }

        private void SearchInvoice_Click_1(object sender, EventArgs e)
        {
            try
            {
                ActualAmount.Text = "0";
                TotalQty.Text = "0";
                TotalAmount.Text = "0";

                int invoiceid = Convert.ToInt32(InvoiceNumber.Text);
                invoiceid2 = Convert.ToInt32(InvoiceNumber.Text);

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
                con.Open();
                string query = "select * from Bill where InvioceID  = '" + invoiceid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv1.DataSource = dt;

                SqlTransaction tran = con.BeginTransaction();

                SqlCommand cmd2 = new SqlCommand("select top 1 ActualAmount,TotalAmount,DiscountInPercent from Bill where InvioceID = '" + InvoiceNumber.Text + "' ", con, tran);
                cmd2.ExecuteNonQuery();

                InvoiceNumber.Text = "";
                InvoiceNumber.Focus();

                totalQuantity = 0;

                using (SqlDataReader dr = cmd2.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        totalAmount = dr["TotalAmount"].ToString();
                        discount = dr["DiscountInPercent"].ToString();
                        DRactualAmount = dr["ActualAmount"].ToString();
                    }
                }

                TotalAmount.Text = totalAmount;
                txtDiscount.Text = discount;
                ActualAmount.Text = DRactualAmount.ToString();

                for (int i = 0; i < dgv1.Rows.Count; ++i)
                {
                    totalQuantity += Convert.ToInt32(dgv1.Rows[i].Cells[5].Value);
                }

                TotalQty.Text = totalQuantity.ToString();

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("InvoiceID cannot be blank");
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            int invoiceid3 = invoiceid2;
            string itemname;
            string itemqty;
            string itemprice;
            double itempricewithGST;
            double GST;
            double GStunit = 0.17;
            string billtotal = TotalAmount.Text;
            string totalqty = TotalQty.Text;
            double totalGSTcalcualtion = Convert.ToDouble(TotalAmount.Text) * GStunit;
            double totalAmountwithGST = Convert.ToDouble(TotalAmount.Text) + totalGSTcalcualtion;
            double discount = Convert.ToDouble(discountpercentageForAmount);
            double singleitemcollectiveamount;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Bill where InvioceID ='" + invoiceid3 + "'";
            cmd.ExecuteNonQuery();

            string Custname = "Valuable Customer";
            string CustContact = "***********";
            string OrderType = "Food Item";
            string OrderCategory = "Food";

            SqlCommand cmd4;
            cmd4 = new SqlCommand("update Customer set CustName =  '" + Custname + "', Contact = '" + CustContact + "', OrderTime = '" + DateTime.Now.ToShortTimeString() + "', OrderDate = '" + DateTime.Now.Date + "' where CustID = '" + CUSTID + "' ", con);
            cmd4.ExecuteNonQuery();
            SqlCommand cmd5;
            cmd5 = new SqlCommand("update Orders set CustID = '" + CUSTID + "', OrderType = '" + OrderType.ToString() + "', OrderCategory = '" + OrderCategory.ToString() + "', Ordertime = '" + DateTime.Now.ToShortTimeString() + "', OrderDate = '" + DateTime.Now.Date + "' ", con);
            cmd5.ExecuteNonQuery();

            SqlCommand cmd6;
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                itemname = Convert.ToString(dgv1.Rows[i].Cells[4].Value);
                itemqty = Convert.ToString(dgv1.Rows[i].Cells[5].Value);
                itemprice = Convert.ToString(dgv1.Rows[i].Cells[6].Value);
                singleitemcollectiveamount = Convert.ToDouble(dgv1.Rows[i].Cells[7].Value);
                GST = Convert.ToDouble(dgv1.Rows[i].Cells[7].Value) * GStunit;
                itempricewithGST = Convert.ToDouble(dgv1.Rows[i].Cells[7].Value) + GST;
                cmd6 = new SqlCommand("insert into Bill values ('" + invoiceid2 + "','" + CUSTID + "','" + ORDERID + "','" + CUSTNAME + "','" + itemname.ToString() + "','" + itemqty.ToString() + "','" + itemprice.ToString() + "','" + singleitemcollectiveamount.ToString() + "','" + itempricewithGST.ToString() + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.Date + "','" + totalqty.ToString() + "','" + ActualAmount.Text.ToString() + "','" + billtotal.ToString() + "','" + totalAmountwithGST.ToString() + "','" + discount.ToString() + "')", con);
                cmd6.ExecuteNonQuery();
            }

            SqlCommand cmd7;
            cmd7 = new SqlCommand("insert into EditedBill values ('" + invoiceid2 + "')", con);
            cmd7.ExecuteNonQuery();

            con.Close();

            Edit_Invoice_Print edit_Invoice_Print = new Edit_Invoice_Print();
            edit_Invoice_Print.Show();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv1.Rows[e.RowIndex];

                InvoiceNumber.Text = row.Cells[0].Value.ToString();
                CUSTID = row.Cells[1].Value.ToString(); ;
                CUSTNAME = row.Cells[3].Value.ToString(); ;
                ORDERID = row.Cells[2].Value.ToString(); ;
            }
        }
    }
}
