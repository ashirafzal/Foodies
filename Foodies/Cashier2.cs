using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Foodies
{
    public partial class Cashier2 : Form
    {
        /*Timer for counting minutes*/
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        /*Declaring product and cashier string,integerandimage type variable to be read by the dr and then saved in these
         declarations*/
        string Productname;
        int Productprice;
        Image ProductImage;
        string Categoryname;
        Image CategoryImage;

        /*Declaring runtime labels and pictureboxes*/
        Panel pnl2;
        Label label3;
        PictureBox picture2;
        Panel pnl;
        PictureBox picture;
        Label label;
        Label Clabel2;

        /*Declaring Global Label as object sender Event Args e*/
        Label currentlable;
        Label currentlable2;
        Label currentlable3;

        /* Declaring variable to check whether the element is present in gridview or not?*/
        string Dgvproductname;
        int DgvProductprice;
        string Dgvcategory;
        int Dgvactualprice;

        /*Declaratioin of variables for the total count for the total amount, total quantity,
         actual amount from the data gird view*/
        int quantity = 1, a, b, c;
        int totalAmount = 0; int totalQuantity = 0;

        int INVOICEID; /* For Invoice Reading through Sql reader*/
        string druser;/*Checking user status*/

        //For billing
        string drInvoiceid, CustID, OrderID, CustName, Product_Name,
               ProductQuantity, ProductRate, ProductAmount, ProductAmountWithGST,
               OrderTime, OrderDate, TotalQty, ActualAmount, TotalAmount, TotalAmountWithGST,
               DiscounInPercent;

        // For Bill variables
        string Total_Qty, Actual_Amount, Total_Amount, _TotalWithGST, _Discount;

        /*Getter and setter for the print page width and height to print*/
        public System.Drawing.Printing.PaperSize PaperSize { get; set; }

        //For inventory operations
        // Product name to check in a string
        string zingerburger = "zinger burger";
        string beefburger = "beef burger";
        string clubsandwich = "club sandwich";
        string chickensandwich = "chicken sandwich";
        string bbqsandwich = "bbq sandwich";
        // Boolean to check whether porudct is present in datagridview or not
        bool exist;

        public void Timercheckingstock()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Stock where stockweigth = '0' ", con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("A stock item is ended you need to update it.\n" +
                    "Do you want to update it now?", "Stock warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    updatestock updatestock = new updatestock();
                    updatestock.Show();
                }
                if (result == DialogResult.No)
                {
                    //Do nothing
                }
            }
        }

        public void WatchMethod()
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

                totalAmount = 0; totalQuantity = 0;
                totalQty.Text = "0";
                total_Amount.Text = "0";

                this.dgv1.EditMode = DataGridViewEditMode.EditOnEnter;

                qty = Convert.ToInt32(row.Cells[1].Value);
                rate = Convert.ToInt32(row.Cells[2].Value);
                amount = qty * rate;
                row.Cells[3].Value = amount;

            }

            for (int i = 0; i < dgv1.Rows.Count; ++i)
            {
                totalQuantity += Convert.ToInt32(dgv1.Rows[i].Cells[1].Value);
                totalAmount += Convert.ToInt32(dgv1.Rows[i].Cells[3].Value);
            }
            totalQty.Text = totalQuantity.ToString();
            total_Amount.Text = totalAmount.ToString();
            act_price.Text = totalAmount.ToString();
        }

        private void cCCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
        }

        private void cLOSEAPPLICATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sEARCHINVOICESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceDetails invoiceDetails = new InvoiceDetails();
            invoiceDetails.Show();
        }

        private void cANCELINVOICESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelInvioce cancelInvioce = new CancelInvioce();
            cancelInvioce.Show();
        }

        private void eDITINVOICEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_Inovice edit_Inovice = new Edit_Inovice();
            edit_Inovice.Show();
        }

        private void dELETEDINVOICEDATAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletedInvoice deletedInvoice = new DeletedInvoice();
            deletedInvoice.Show();
        }

        private void pRODUCTPRICESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductPrice productPrice = new ProductPrice();
            productPrice.Show();
        }

        private void cREATECATEGORIESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubProductManagement_System category = new SubProductManagement_System();
            category.Show();
        }

        private void mANAGECATEGORIESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCategory manageCategory = new ManageCategory();
            manageCategory.Show();
        }

        private void cREATEPRODUCTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemsEntry itemsEntry = new ItemsEntry();
            itemsEntry.Show();
        }

        private void mANAGEPRODUCTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageItems manageItems = new ManageItems();
            manageItems.Show();
        }

        private void dAILYSALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailySales dailySales = new DailySales();
            dailySales.Show();
        }

        private void wEEKLYSALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Weekly weekly = new Weekly();
            weekly.Show();
        }

        private void mONTHLYSALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlySales monthlySales = new MonthlySales();
            monthlySales.Show();
        }

        private void aNNUALSALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnualSales annualSales = new AnnualSales();
            annualSales.Show();
        }

        private void eXPORTTOEXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExcel exportToExcel = new ExportToExcel();
            exportToExcel.Show();
        }

        public void CheckingUserStatus()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            SqlCommand cmd20 = new SqlCommand("select top 1 usercategory from LoginDetails order by Id DESC", con, tran);
            cmd20.ExecuteNonQuery();

            using (SqlDataReader dr = cmd20.ExecuteReader())
            {
                while (dr.Read())
                {
                    druser = Convert.ToString(dr["usercategory"]);
                }
            }

            if (druser == "admin")
            {
                bBBBToolStripMenuItem.Visible = true;
                cCCCToolStripMenuItem.Visible = true;
            }
            else
            {
                bBBBToolStripMenuItem.Visible = false;
                cCCCToolStripMenuItem.Visible = false;
            }
        }

        private void Cashier2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Connection String //
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");

        private void sALESSUMMARYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesSummary sales = new SalesSummary();
            sales.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {
            Timercheckingstock();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv1.Rows.Count <= 2)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 450);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 3)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 500);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 4)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 550);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 5)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 575);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 6)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 600);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 7)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 625);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 8)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 650);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 9)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 675);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 10)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 700);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 11)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 725);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 12)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 750);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 13)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 775);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 14)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 800);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 16)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 850);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 17)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 875);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 18)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 900);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 19)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 925);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 20)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 950);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 21)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 975);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 22)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1000);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 23)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1025);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 24)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1050);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 25)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1075);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 26)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1100);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 27)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1125);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 28)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1150);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 29)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1175);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 30)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1200);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 31)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1225);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 32)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1250);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 33)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1275);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 34)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1300);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 35)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1325);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 36)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1350);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 37)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1375);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 38)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1400);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 39)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1425);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv1.Rows.Count <= 40)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1450);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, DVPrintDocument.DefaultPageSettings.PaperSize.Height);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }

                //
                //
                //

                if (dgv1.Rows.Count == 0)
                {
                    const string message =
                        "Transaction can't be completed because there is no item selected for sale.";
                    const string caption = "Transaction Error";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Stop);
                }
                else if (dgv1.Rows.Count > 40)
                {
                    const string message =
                        "Transaction can't be completed on more than 40 items.\n" +
                        "Please select less than 40 items for transaction.";
                    const string caption = "Paper size limit";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Exclamation);
                }
                else
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Bill", con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        /* Connection String me Integrated Security=True; ko Integrated Security=SSPI; se change karna hoga
                        or phir MultipleActiveResultSets = True connection string me add karna hoga takai Sql Reader ke while
                        condition me aik se sql queries ki queires ko implement kara jasakai*/

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
                                INVOICEID = INVOICEID + 1;
                            }
                        }

                        string Custname = "Valuable Customer";
                        string CustContact = "***********";

                        string CUSTID, ORDERID, CUSTNAME, ORDERTIME, ORDERDATE, CUSTCONTACT;
                        string OrderType = "Food Item";
                        string OrderCategory = "Food";

                        SqlCommand cmd1 = new SqlCommand("insert into Customer values ('" + Custname + "','" + CustContact + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.ToShortDateString() + "')", con, tran);
                        cmd1.ExecuteNonQuery();
                        SqlCommand cmd2 = new SqlCommand("select top 1 CustID from Customer order by CustID DESC", con, tran);
                        cmd2.ExecuteNonQuery();

                        using (SqlDataReader dr = cmd2.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                CUSTID = dr["CustID"].ToString();
                                SqlCommand cmd3 = new SqlCommand("insert into Orders values ('" + CUSTID + "','" + OrderType.ToString() + "','" + OrderCategory.ToString() + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.ToShortDateString() + "')", con, tran);
                                cmd3.ExecuteNonQuery();
                            }
                        }

                        SqlCommand cmd4 = new SqlCommand("select top 1 CustID,CustName,Contact from Customer order by CustID DESC", con, tran);
                        cmd4.ExecuteNonQuery();
                        SqlCommand cmd5 = new SqlCommand("select top 1 OrderID,OrderTime,OrderDate from Orders order by OrderID DESC", con, tran);
                        cmd5.ExecuteNonQuery();

                        using (SqlDataReader dr = cmd4.ExecuteReader())
                        {
                            using (SqlDataReader dr1 = cmd5.ExecuteReader())
                            {
                                string itemname;
                                string itemqty;
                                string itemprice;
                                double itempricewithGST;
                                double GST;
                                double GStunit = 0.17;
                                string billtotal = total_Amount.Text;
                                string totalqty = totalQty.Text;
                                double totalGSTcalcualtion = Convert.ToDouble(total_Amount.Text) * GStunit;
                                double totalAmountwithGST = Convert.ToDouble(total_Amount.Text) + totalGSTcalcualtion;
                                double discount = Convert.ToDouble(per_discount.Text);
                                double singleitemcollectiveamount;

                                while (dr.Read())
                                {
                                    CUSTID = dr["CustID"].ToString();
                                    CUSTNAME = dr["CustName"].ToString();
                                    CUSTCONTACT = dr["Contact"].ToString();
                                    while (dr1.Read())
                                    {
                                        ORDERID = dr1["OrderID"].ToString();
                                        ORDERTIME = dr1["OrderTime"].ToString();
                                        ORDERDATE = dr1["OrderDate"].ToString();

                                        SqlCommand cmd7 = new SqlCommand("insert into Sales values ('" + ORDERID + "','" + CUSTID + "','" + CUSTNAME + "','" + CUSTCONTACT + "','" + OrderType + "','" + OrderCategory + "','" + ORDERTIME + "','" + ORDERDATE + "')", con, tran);
                                        cmd7.ExecuteNonQuery();

                                        SqlCommand cmd6;
                                        for (int i = 0; i < dgv1.Rows.Count; i++)
                                        {
                                            itemname = Convert.ToString(dgv1.Rows[i].Cells[0].Value);
                                            itemqty = Convert.ToString(dgv1.Rows[i].Cells[1].Value);
                                            itemprice = Convert.ToString(dgv1.Rows[i].Cells[2].Value);
                                            singleitemcollectiveamount = Convert.ToDouble(dgv1.Rows[i].Cells[3].Value);
                                            GST = Convert.ToInt32(dgv1.Rows[i].Cells[3].Value) * GStunit;
                                            itempricewithGST = Convert.ToDouble(dgv1.Rows[i].Cells[2].Value) + GST;
                                            cmd6 = new SqlCommand("insert into Bill values ('" + INVOICEID + "','" + CUSTID + "','" + ORDERID + "','" + CUSTNAME + "','" + itemname.ToString() + "','" + itemqty.ToString() + "','" + itemprice.ToString() + "','" + singleitemcollectiveamount.ToString() + "','" + itempricewithGST.ToString() + "','" + ORDERTIME + "','" + ORDERDATE + "','" + totalqty.ToString() + "','" + act_price.Text.ToString() + "','" + billtotal.ToString() + "','" + totalAmountwithGST.ToString() + "','" + discount.ToString() + "')", con, tran);
                                            cmd6.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            tran.Commit();
                            con.Close();
                        }
                        //Current_Invoice_Print current_Invoice = new Current_Invoice_Print();
                        //current_Invoice.Show();

                        //DVPrintPreviewDialog.Document = DVPrintDocument;
                        //DVPrintPreviewDialog.Show();

                        if ((DVPrintPreviewDialog != null))
                        {
                            DVPrintPreviewDialog = new PrintPreviewDialog();
                            ((Form)DVPrintPreviewDialog).WindowState = FormWindowState.Maximized;
                        }

                        DVPrintPreviewDialog.Document = DVPrintDocument;
                        DVPrintPreviewDialog.Show();
                        //DVPrintDocument.Print();

                        inventoryFunctionality();
                    }
                    else
                    {
                        string Custname = "Valuable Customer";
                        string CustContact = "***********";

                        string CUSTID, ORDERID, CUSTNAME, ORDERTIME, ORDERDATE, CUSTCONTACT;
                        string OrderType = "Food Item";
                        string OrderCategory = "Food";

                        int InvocieId = 1;

                        /* Connection String me Integrated Security=True; ko Integrated Security=SSPI; se change karna hoga
                         or phir MultipleActiveResultSets = True connection string me add karna hoga takai Sql Reader ke while
                         condition me aik se sql queries ki queires ko implement kara jasakai*/

                        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
                        con.Open();
                        SqlTransaction tran = con.BeginTransaction();

                        //
                        SqlCommand cmd1 = new SqlCommand("insert into Customer values ('" + Custname + "','" + CustContact + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.Date + "')", con, tran);
                        cmd1.ExecuteNonQuery();
                        SqlCommand cmd2 = new SqlCommand("select top 1 CustID from Customer order by CustID DESC", con, tran);
                        cmd2.ExecuteNonQuery();

                        using (SqlDataReader dr = cmd2.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                CUSTID = dr["CustID"].ToString();
                                SqlCommand cmd3 = new SqlCommand("insert into Orders values ('" + CUSTID + "','" + OrderType.ToString() + "','" + OrderCategory.ToString() + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.Date + "')", con, tran);
                                cmd3.ExecuteNonQuery();
                            }
                        }

                        SqlCommand cmd4 = new SqlCommand("select top 1 CustID,CustName,Contact from Customer order by CustID DESC", con, tran);
                        cmd4.ExecuteNonQuery();
                        SqlCommand cmd5 = new SqlCommand("select top 1 OrderID,OrderTime,OrderDate from Orders order by OrderID DESC", con, tran);
                        cmd5.ExecuteNonQuery();

                        using (SqlDataReader dr = cmd4.ExecuteReader())
                        {
                            using (SqlDataReader dr1 = cmd5.ExecuteReader())
                            {
                                string itemname;
                                string itemqty;
                                string itemprice;
                                double itempricewithGST;
                                double GST;
                                double GStunit = 0.17;
                                string billtotal = total_Amount.Text;
                                string totalqty = totalQty.Text;
                                double totalGSTcalcualtion = Convert.ToDouble(total_Amount.Text) * GStunit;
                                double totalAmountwithGST = Convert.ToDouble(total_Amount.Text) + totalGSTcalcualtion;
                                double discount = Convert.ToDouble(per_discount.Text);
                                double singleitemcollectiveamount;

                                while (dr.Read())
                                {
                                    CUSTID = dr["CustID"].ToString();
                                    CUSTNAME = dr["CustName"].ToString();
                                    CUSTCONTACT = dr["Contact"].ToString();
                                    while (dr1.Read())
                                    {
                                        ORDERID = dr1["OrderID"].ToString();
                                        ORDERTIME = dr1["OrderTime"].ToString();
                                        ORDERDATE = dr1["OrderDate"].ToString();

                                        SqlCommand cmd7 = new SqlCommand("insert into Sales values ('" + ORDERID + "','" + CUSTID + "','" + CUSTNAME + "','" + CUSTCONTACT + "','" + OrderType + "','" + OrderCategory + "','" + ORDERTIME + "','" + ORDERDATE + "')", con, tran);
                                        cmd7.ExecuteNonQuery();

                                        SqlCommand cmd6;
                                        for (int i = 0; i < dgv1.Rows.Count; i++)
                                        {
                                            itemname = Convert.ToString(dgv1.Rows[i].Cells[0].Value);
                                            itemqty = Convert.ToString(dgv1.Rows[i].Cells[1].Value);
                                            itemprice = Convert.ToString(dgv1.Rows[i].Cells[2].Value);
                                            singleitemcollectiveamount = Convert.ToDouble(dgv1.Rows[i].Cells[3].Value);
                                            GST = Convert.ToInt32(dgv1.Rows[i].Cells[3].Value) * GStunit;
                                            itempricewithGST = Convert.ToDouble(dgv1.Rows[i].Cells[2].Value) + GST;
                                            cmd6 = new SqlCommand("insert into Bill values ('" + InvocieId + "','" + CUSTID + "','" + ORDERID + "','" + CUSTNAME + "','" + itemname.ToString() + "','" + itemqty.ToString() + "','" + itemprice.ToString() + "','" + singleitemcollectiveamount.ToString() + "','" + itempricewithGST.ToString() + "','" + ORDERTIME + "','" + ORDERDATE + "','" + totalqty.ToString() + "','" + act_price.Text.ToString() + "','" + billtotal.ToString() + "','" + totalAmountwithGST.ToString() + "','" + discount.ToString() + "')", con, tran);
                                            cmd6.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            tran.Commit();
                            con.Close();
                        }
                        //Current_Invoice_Print current_Invoice = new Current_Invoice_Print();
                        //current_Invoice.Show();

                        //DVPrintPreviewDialog.Document = DVPrintDocument;
                        //DVPrintPreviewDialog.Show();

                        if ((DVPrintPreviewDialog != null))
                        {
                            DVPrintPreviewDialog = new PrintPreviewDialog();
                            ((Form)DVPrintPreviewDialog).WindowState = FormWindowState.Maximized;
                        }
                        DVPrintPreviewDialog.Document = DVPrintDocument;
                        DVPrintPreviewDialog.Show();
                        //DVPrintDocument.Print();

                        inventoryFunctionality();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Transaction Failed for Unknown Reason");
            }
        }

        private void DVPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            SqlCommand cmd10 = new SqlCommand("select top 1 InvioceID,Totalqty," +
                "TotalAmount,TotalAmountWithGST,ActualAmount," +
                "DiscountInPercent from Bill order by InvioceID DESC", con, tran);
            cmd10.ExecuteNonQuery();

            using (SqlDataReader dr = cmd10.ExecuteReader())
            {
                while (dr.Read())
                {
                    INVOICEID = Convert.ToInt32(dr["InvioceID"]);
                    Total_Qty = Convert.ToString(dr["Totalqty"]);
                    Total_Amount = Convert.ToString(dr["TotalAmount"]);
                    _TotalWithGST = Convert.ToString(dr["TotalAmountWithGST"]);
                    Actual_Amount = Convert.ToString(dr["ActualAmount"]);
                    _Discount = Convert.ToString(dr["DiscountInPercent"]);
                }
            }

            tran.Commit();
            con.Close();

            e.Graphics.DrawString("FOODIES CLUB", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(110, 30));
            //e.Graphics.DrawString("GST# 222-333-123456", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(130, 70));
            e.Graphics.DrawString("Invoice ID :", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, 70));
            e.Graphics.DrawString(INVOICEID.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(90, 70));
            e.Graphics.DrawString("Transaction Date :", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, 90));
            e.Graphics.DrawString(DateTime.Now.Date.ToShortDateString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(130, 90));
            e.Graphics.DrawString("Transaction Time :", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, 110));
            e.Graphics.DrawString(DateTime.Now.ToShortTimeString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(130, 110));
            //
            e.Graphics.DrawString("------------------------------------------------------------------------------",
               new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, 130));
            e.Graphics.DrawString("SALES ITEMS", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(150, 150));
            e.Graphics.DrawString("------------------------------------------------------------------------------",
            new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, 170));
            //
            e.Graphics.DrawString("PRODUCT NAME", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(10, 190));
            e.Graphics.DrawString("QUANTITY", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(160, 190));
            e.Graphics.DrawString("RATE", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(240, 190));
            e.Graphics.DrawString("AMOUNT", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Point(310, 190));

            int position = 210;

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                position = position + 20;
                e.Graphics.DrawString(Convert.ToString(dgv1.Rows[i].Cells[0].Value), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, position));
                e.Graphics.DrawString(Convert.ToString(dgv1.Rows[i].Cells[1].Value) + ".00", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(170, position));
                e.Graphics.DrawString(Convert.ToString(dgv1.Rows[i].Cells[2].Value) + ".00", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(240, position));
                e.Graphics.DrawString(Convert.ToString(dgv1.Rows[i].Cells[3].Value) + ".00", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(310, position));
            }
            //
            e.Graphics.DrawString("------------------------------------------------------------------------------",
           new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, position + 20));
            //
            e.Graphics.DrawString("Actual Amount", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(70, position + 40));
            e.Graphics.DrawString(Actual_Amount.ToString() + ".00", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(250, position + 40));
            e.Graphics.DrawString("Total Quantity", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(70, position + 60));
            e.Graphics.DrawString(Total_Qty.ToString() + ".00", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(250, position + 60));
            e.Graphics.DrawString("Total Amount", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(70, position + 80));
            e.Graphics.DrawString(Total_Amount.ToString() + ".00", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(250, position + 80));
            //e.Graphics.DrawString("Total Amount(GST Included)", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, position + 100));
            //e.Graphics.DrawString(_TotalWithGST.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(310, position + 100));
            e.Graphics.DrawString("Discount", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(70, position + 100));
            e.Graphics.DrawString(_Discount.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(250, position + 100));
            //
            e.Graphics.DrawString("------------------------------------------------------------------------------",
           new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, position + 120));
            //
            e.Graphics.DrawString("TOKEN NO "+INVOICEID.ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, position + 135));
            //
            e.Graphics.DrawString("------------------------------------------------------------------------------",
           new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(10, position + 155));
            //
            e.Graphics.DrawString("TOKEN NO " + INVOICEID.ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(10, position + 175));

        }

        public Cashier2()
        {
            InitializeComponent();
            CheckingUserStatus();
            _timer.Interval = 1800000; // 1800000 ms = 30 minutes
            //_timer.Interval = 30000; // 30000 ms = 30 seconds
            _timer.Tick += timer1_Tick_2;
            _timer.Start();
        }

        private void Cashier2_Load(object sender, EventArgs e)
        {
            Loadproducts();
            Loadcategory();
            Dgv_1();
        }

        public void Dgv_1()
        {
            dgv1.RowTemplate.Height = 32;

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
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void Loadcategory()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True"))
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                SqlCommand cmd10 = new SqlCommand("SELECT * FROM Category", conn, tran);
                cmd10.ExecuteNonQuery();

                string CommandText = "SELECT * FROM Category";
                using (SqlCommand cmd2 = new SqlCommand(CommandText, con))
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    using (SqlDataReader dr2 = cmd10.ExecuteReader())
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            while (dr2.Read())
                            {
                                Categoryname = Convert.ToString(dr2["CategoryName"]);
                                var bytes = (byte[])dr2[2];
                                foreach (DataRow dr3 in ds.Tables[0].Rows)
                                {
                                    using (MemoryStream ms = new MemoryStream(bytes))
                                    {
                                        CategoryImage = Image.FromStream(ms);
                                    }
                                }

                                pnl2 = new Panel
                                {
                                    Size = new System.Drawing.Size(200, 180),
                                    Location = new Point(10, 10),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    BackColor = Color.White,
                                    Margin = new Padding(7, 5, 5, 5),
                                };

                                picture2 = new PictureBox
                                {
                                    Size = new System.Drawing.Size(180, 120),
                                    Location = new Point(10, 10),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    //Margin = new Padding(5, 5, 5, 5),
                                    BackColor = Color.Green,
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                    Image = CategoryImage,
                                };

                                label3 = new Label
                                {
                                    Size = new System.Drawing.Size(150, 30),
                                    Font = new Font("Arial", 13, FontStyle.Bold),
                                    Location = new Point(30, 140),
                                    //Margin = new Padding(5, 5, 5, 5),
                                    BackColor = Color.White,
                                    ForeColor = Color.Black,
                                    Text = Categoryname,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                };

                                pnl2.Controls.Add(picture2);
                                pnl2.Controls.Add(label3);
                                flowLayoutPanel2.Controls.Add(pnl2);
                                pnl2.Click += new System.EventHandler(this.pnl2Click);
                                label3.Click += new System.EventHandler(this.label3Click);

                            }
                        }
                    }
                }
            }
        }

        /*Category Label onclick Evenet handler*/
        void label3Click(object sender, EventArgs e)
        {
            currentlable = (Label)sender;
            flowLayoutPanel1.Controls.Clear();
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True"))
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                SqlCommand cmd10 = new SqlCommand("SELECT * FROM Products where ProductCategory = '" + currentlable.Text + "' ", conn, tran);
                cmd10.ExecuteNonQuery();

                string CommandText = "SELECT * FROM Products";
                using (SqlCommand cmd2 = new SqlCommand(CommandText, con))
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    using (SqlDataReader dr2 = cmd10.ExecuteReader())
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            while (dr2.Read())
                            {
                                Productname = Convert.ToString(dr2["ProductName"]);
                                Productprice = Convert.ToInt32(dr2["ProductPrice"]);
                                var bytes = (byte[])dr2[4];
                                foreach (DataRow dr3 in ds.Tables[0].Rows)
                                {
                                    using (MemoryStream ms = new MemoryStream(bytes))
                                    {
                                        ProductImage = Image.FromStream(ms);
                                    }
                                }


                                pnl = new Panel
                                {
                                    Size = new System.Drawing.Size(214, 200),
                                    Location = new Point(10, 10),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    BackColor = Color.White,
                                    Margin = new Padding(5, 5, 5, 5),
                                };

                                picture = new PictureBox
                                {
                                    Size = new System.Drawing.Size(190, 120),
                                    Location = new Point(10, 10),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    //Margin = new Padding(5, 5, 5, 5),
                                    BackColor = Color.Green,
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                    Image = ProductImage,
                                };

                                label = new Label
                                {
                                    Size = new System.Drawing.Size(150, 22),
                                    Font = new Font("Arial", 13, FontStyle.Bold),
                                    Location = new Point(30, 140),
                                    //Margin = new Padding(5, 5, 5, 5),
                                    BackColor = Color.White,
                                    ForeColor = Color.Black,
                                    Text = Productname,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                };

                                label2 = new Label
                                {
                                    Size = new System.Drawing.Size(100, 20),
                                    Font = new Font("Arial", 12, FontStyle.Bold),
                                    Location = new Point(60, 165),
                                    //Margin = new Padding(5, 5, 5, 5),
                                    BackColor = Color.White,
                                    ForeColor = Color.Black,
                                    Text = Convert.ToString(Productprice),
                                    TextAlign = ContentAlignment.MiddleCenter,
                                };

                                pnl.Controls.Add(picture);
                                pnl.Controls.Add(label);
                                pnl.Controls.Add(label2);
                                flowLayoutPanel1.Controls.Add(pnl);
                                label.Click += new System.EventHandler(this.labelClick);
                                label2.Click += new System.EventHandler(this.label2Click);

                            }
                        }
                    }
                }
            }
            //MessageBox.Show(""+currentlable.Text);
        }

        /*Category Panel onclick Evenet handler*/
        void pnl2Click(object sender, EventArgs e)
        {
            // Do nothing in this DataeventHandler
        }

        public void Loadproducts()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True"))
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                SqlCommand cmd10 = new SqlCommand("SELECT * FROM Products", conn, tran);
                cmd10.ExecuteNonQuery();

                string CommandText = "SELECT * FROM Products";
                using (SqlCommand cmd2 = new SqlCommand(CommandText, con))
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    using (SqlDataReader dr2 = cmd10.ExecuteReader())
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            while (dr2.Read())
                            {
                                Productname = Convert.ToString(dr2["ProductName"]);
                                Productprice = Convert.ToInt32(dr2["ProductPrice"]);
                                var bytes = (byte[])dr2[4];
                                foreach (DataRow dr3 in ds.Tables[0].Rows)
                                {
                                    using (MemoryStream ms = new MemoryStream(bytes))
                                    {
                                        ProductImage = Image.FromStream(ms);
                                    }
                                }

                                pnl = new Panel
                                {
                                    Size = new System.Drawing.Size(214, 200),
                                    Location = new Point(10, 10),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    BackColor = Color.White,
                                    Margin = new Padding(5, 5, 5, 5),
                                };

                                picture = new PictureBox
                                {
                                    Size = new System.Drawing.Size(190, 120),
                                    Location = new Point(10, 10),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    //Margin = new Padding(5, 5, 5, 5),
                                    BackColor = Color.Green,
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                    Image = ProductImage,
                                };

                                label = new Label
                                {
                                    Size = new System.Drawing.Size(150, 22),
                                    Font = new Font("Arial", 13, FontStyle.Bold),
                                    Location = new Point(30, 140),
                                    //Margin = new Padding(5, 5, 5, 5),
                                    BackColor = Color.White,
                                    ForeColor = Color.Black,
                                    Text = Productname,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                };

                                label2 = new Label
                                {
                                    Size = new System.Drawing.Size(100, 20),
                                    Font = new Font("Arial", 12, FontStyle.Bold),
                                    Location = new Point(60, 165),
                                    //Margin = new Padding(5, 5, 5, 5),
                                    BackColor = Color.White,
                                    ForeColor = Color.Black,
                                    Text = Convert.ToString(Productprice),
                                    TextAlign = ContentAlignment.MiddleCenter,
                                };

                                pnl.Controls.Add(picture);
                                pnl.Controls.Add(label);
                                pnl.Controls.Add(label2);
                                flowLayoutPanel1.Controls.Add(pnl);
                                label.Click += new System.EventHandler(this.labelClick);
                                label2.Click += new System.EventHandler(this.label2Click);

                            }
                        }
                    }
                }
            }
        }

        void label2Click(object sender, EventArgs e)
        {
            currentlable3 = (Label)sender;
        }

        void labelClick(object sender, EventArgs e)
        {
            try
            {
                currentlable2 = (Label)sender;

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                SqlCommand cmd10 = new SqlCommand("select * from Products where ProductName = '" + currentlable2.Text + "' ", con, tran);
                cmd10.ExecuteNonQuery();

                using (SqlDataReader dr = cmd10.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dgvproductname = Convert.ToString(dr["ProductName"]);
                        DgvProductprice = Convert.ToInt32(dr["ProductPrice"]);
                        Dgvcategory = Convert.ToString(dr["ProductCategory"]);
                        Dgvactualprice = Convert.ToInt32(dr["ProductPrice"]);
                    }
                }

                totalAmount = 0; totalQuantity = 0;

                bool Found = false;
                dgv1.AllowUserToAddRows = true;

                if (dgv1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Row in dgv1.Rows)
                    {
                        if (Convert.ToString(Row.Cells[0].Value) == Dgvproductname)
                        {
                            Found = true;
                            dgv1.AllowUserToAddRows = false;
                        }
                        dgv1.AllowUserToAddRows = false;
                    }
                    if (!Found)
                    {
                        a = Convert.ToInt32(quantity);
                        b = Convert.ToInt32(DgvProductprice);
                        c = a * b;

                        dgv1.Rows.Add(Dgvproductname, a, b, c,Dgvcategory);
                        for (int i = 0; i < dgv1.Rows.Count; ++i)
                        {
                            totalQuantity += Convert.ToInt32(dgv1.Rows[i].Cells[1].Value);
                            totalAmount += Convert.ToInt32(dgv1.Rows[i].Cells[3].Value);
                        }
                        totalQty.Text = totalQuantity.ToString();
                        total_Amount.Text = totalAmount.ToString();
                        act_price.Text = totalAmount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgv1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgv1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void aAAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.Show();
        }

        private void cLOCKOUTLOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                totalAmount = 0; totalQuantity = 0;
                totalQty.Text = totalQuantity.ToString();
                total_Amount.Text = totalAmount.ToString();

                var row = dgv1.CurrentRow;

                if (row == null || row.Index < 0)
                    return;
                var unit = 1;
                var quantity = Convert.ToInt32(row.Cells["qtty"].Value) + unit;
                //assuming you have rate column...
                var rate = Convert.ToInt32(row.Cells["rate"].Value);

                //this line increase quantity
                row.Cells["qtty"].Value = quantity;
                //this line increase amount
                row.Cells["price"].Value = Convert.ToInt32(row.Cells["price"].Value) + rate;


                for (int i = 0; i < dgv1.Rows.Count; ++i)
                {
                    totalQuantity += Convert.ToInt32(dgv1.Rows[i].Cells[1].Value);
                    totalAmount += Convert.ToInt32(dgv1.Rows[i].Cells[3].Value);
                }
                totalQty.Text = totalQuantity.ToString();
                total_Amount.Text = totalAmount.ToString();
                act_price.Text = totalAmount.ToString();

            }
            else if (e.ColumnIndex == 6)
            {
                totalAmount = 0; totalQuantity = 0;
                totalQty.Text.Trim();
                //totalQty.Text = totalQuantity.ToString();
                total_Amount.Text = totalAmount.ToString();

                var row = dgv1.CurrentRow;

                if (row == null || row.Index < 0)
                    return;
                var unit = 1;
                var quantity = Convert.ToInt32(row.Cells["qtty"].Value) - unit;
                //assuming you have rate column...
                var rate = Convert.ToInt32(row.Cells["rate"].Value);

                if (quantity < 1)
                {
                    this.dgv1.Rows.RemoveAt(e.RowIndex);

                    for (int i = 0; i < dgv1.Rows.Count; ++i)
                    {
                        totalQuantity += Convert.ToInt32(dgv1.Rows[i].Cells[1].Value);
                        totalAmount += Convert.ToInt32(dgv1.Rows[i].Cells[3].Value);
                    }
                    totalQty.Text = totalQuantity.ToString();
                    total_Amount.Text = totalAmount.ToString();
                    act_price.Text = totalAmount.ToString();
                    //
                    per_discount.Text = "0";
                    DiscountPercent.Text = "";
                    DiscountPKR.Text = "";
                }
                else
                {
                    //this line decrease quantity
                    row.Cells["qtty"].Value = quantity;
                    //this line decrease amount
                    row.Cells["price"].Value = Convert.ToInt32(row.Cells["price"].Value) - rate;

                    for (int i = 0; i < dgv1.Rows.Count; ++i)
                    {
                        //totalAmount = 0; totalQuantity = 0;
                        totalQuantity += Convert.ToInt32(dgv1.Rows[i].Cells[1].Value);
                        totalAmount += Convert.ToInt32(dgv1.Rows[i].Cells[3].Value);
                    }
                    totalQty.Text = totalQuantity.ToString();
                    total_Amount.Text = totalAmount.ToString();
                    act_price.Text = totalAmount.ToString();
                    //
                    per_discount.Text = "0";
                    DiscountPercent.Text = "";
                    DiscountPKR.Text = "";
                }


            }

            else if (dgv1.CurrentCell.ColumnIndex == 7)
            {
                this.dgv1.Rows.RemoveAt(e.RowIndex);

                totalAmount = 0; totalQuantity = 0;
                totalQty.Text = totalQuantity.ToString();
                total_Amount.Text = totalAmount.ToString();

                for (int i = 0; i < dgv1.Rows.Count; ++i)
                {
                    totalQuantity += Convert.ToInt32(dgv1.Rows[i].Cells[1].Value);
                    totalAmount += Convert.ToInt32(dgv1.Rows[i].Cells[3].Value);
                }
                totalQty.Text = totalQuantity.ToString();
                total_Amount.Text = totalAmount.ToString();
                act_price.Text = totalAmount.ToString();
                //
                per_discount.Text = "0";
                DiscountPercent.Text = "";
                DiscountPKR.Text = "";
            }
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                if (DiscountPKR.Text == "")
                {
                    per_discount.Text = DiscountPercent.Text;
                    decimal labelActualAmount = Convert.ToInt32(act_price.Text);
                    decimal discountvalue = Convert.ToInt32(DiscountPercent.Text);
                    decimal discoutPercentage = discountvalue / 100;
                    decimal remainAmount = discoutPercentage * labelActualAmount;
                    decimal ActualAmount = totalAmount - remainAmount;
                    total_Amount.Text = Convert.ToInt32(ActualAmount).ToString();
                    DiscountPKR.Text = "";
                    DiscountPercent.Text = "";
                }
                else if (DiscountPercent.Text == "")
                {
                    decimal discountAmountinPKR = Convert.ToInt32(DiscountPKR.Text);
                    decimal labelActualAmount = Convert.ToInt32(act_price.Text);
                    decimal ActualAmount = labelActualAmount - discountAmountinPKR;
                    total_Amount.Text = Convert.ToInt32(ActualAmount).ToString();
                    decimal percentageForAmount = discountAmountinPKR / labelActualAmount * 100;
                    per_discount.Text =  Convert.ToString(Convert.ToDouble(percentageForAmount));
                    DiscountPKR.Text = "";
                    DiscountPercent.Text = "";
                }
                else
                {
                    MessageBox.Show("Either insert discount in rupees or in percentage");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Discount feild cannot be empty");
            } 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to cancel the last transaction ?", "Delete Last Transaction ?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
                    con.Open();
                    SqlTransaction tran = con.BeginTransaction();

                    SqlCommand cmd1 = new SqlCommand("select top 1 InvioceID from Bill order by InvioceID DESC", con, tran);
                    cmd1.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd1.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            INVOICEID = Convert.ToInt32(dr["InvioceID"]);

                            SqlCommand cmd3 = new SqlCommand("select InvioceID,CustID,OrderID,CustName,ProductName,ProductQuantity" +
                                                                ",ProductRate,ProductAmount,ProductAmountWithGST,OrderTime," +
                                                                "OrderDate,Totalqty,ActualAmount,TotalAmount,TotalAmountWithGST," +
                                                                "DiscountInPercent from Bill where InvioceID = '" + INVOICEID + "' ", con, tran);
                            cmd3.ExecuteNonQuery();

                            using (SqlDataReader dr2 = cmd3.ExecuteReader())
                            {
                                while (dr2.Read())
                                {
                                    drInvoiceid = Convert.ToString(dr2["InvioceID"]);
                                    CustID = Convert.ToString(dr2["CustID"]);
                                    OrderID = Convert.ToString(dr2["OrderID"]);
                                    CustName = Convert.ToString(dr2["CustName"]);
                                    Product_Name = Convert.ToString(dr2["ProductName"]);
                                    ProductQuantity = Convert.ToString(dr2["ProductQuantity"]);
                                    ProductRate = Convert.ToString(dr2["ProductRate"]);
                                    ProductAmount = Convert.ToString(dr2["ProductAmount"]);
                                    ProductAmountWithGST = Convert.ToString(dr2["ProductAmountWithGST"]);
                                    OrderTime = Convert.ToString(dr2["OrderTime"]);
                                    OrderDate = Convert.ToString(dr2["OrderDate"]);
                                    TotalQty = Convert.ToString(dr2["Totalqty"]);
                                    ActualAmount = Convert.ToString(dr2["ActualAmount"]);
                                    TotalAmount = Convert.ToString(dr2["TotalAmount"]);
                                    TotalAmountWithGST = Convert.ToString(dr2["TotalAmountWithGST"]);
                                    DiscounInPercent = Convert.ToString(dr2["DiscountInPercent"]);

                                    SqlCommand cmd4 = new SqlCommand("insert into DeletedBill values ('" + drInvoiceid + "' , '" + CustID + "' , '" + OrderID + "' , '" + CustName + "' , '" + Product_Name + "' , '" + ProductQuantity + "' , '" + ProductRate + "' , '" + ProductAmount + "' , '" + ProductAmountWithGST + "' , '" + OrderTime + "' , '" + OrderDate + "' , '" + TotalQty + "' , '" + ActualAmount + "' , '" + TotalAmount + "' , '" + TotalAmountWithGST + "' , '" + DiscounInPercent + "') ", con, tran);
                                    cmd4.ExecuteNonQuery();
                                }
                            }
                            SqlCommand cmd2 = new SqlCommand("delete from Bill where InvioceID = '" + INVOICEID + "' ", con, tran);
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("Transaction deleted");
                        }
                        tran.Commit();
                        con.Close();
                    }
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Transaction exist");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error deleting last transaction");
            }
        }

        private void bBBBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stocks stocks = new Stocks();
            stocks.Show();
        }

        private void act_price_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();
            dgv1.Refresh();
            DiscountPKR.Text = "";
            DiscountPercent.Text = "";
            per_discount.Text = "0";
            act_price.Text = "0";
            totalQty.Text = "0";
            total_Amount.Text = "0";
            flowLayoutPanel1.Controls.Clear();
            Loadproducts();
            flowLayoutPanel2.Controls.Clear();
            Loadcategory();


        }

        public void inventoryFunctionality()
        {
            //Declaration for Dr read 
            int stockid, stockweigth, newstockweigth;
            string stockname, stockcompany, stockcategory, stockdate, stocktime;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            foreach (DataGridViewRow Row in dgv1.Rows)
            {
                for (int i = 0; i < 1; i++)
                {
                    if (Convert.ToString(Row.Cells[0].Value) == zingerburger)
                    {
                        string gridname = Convert.ToString(Row.Cells[0].Value);
                        int quantity = Convert.ToInt32(Row.Cells[1].Value);
                        exist = true;
                        if (exist == true)
                        {
                            //MessageBox.Show("Found");
                            SqlCommand cmd = new SqlCommand("select * from Stock where stockname = 'chicken' ", con, tran);
                            cmd.ExecuteNonQuery();

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    stockid = Convert.ToInt32(dr["stockid"]);
                                    stockname = Convert.ToString(dr["stockname"]);
                                    stockweigth = Convert.ToInt32(dr["stockweigth"]);
                                    stockcompany = Convert.ToString(dr["stockcompany"]);
                                    stockcategory = Convert.ToString(dr["stockcategory"]);
                                    stockdate = Convert.ToString(dr["stockdate"]);
                                    stocktime = Convert.ToString(dr["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 125 * quantity;

                                        if (newstockweigth > -1)
                                        {

                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                  
                                }
                            }

                            SqlCommand cmd2 = new SqlCommand("select * from Stock where stockname = 'potato' ", con, tran);
                            cmd2.ExecuteNonQuery();

                            using (SqlDataReader dr2 = cmd2.ExecuteReader())
                            {
                                while (dr2.Read())
                                {
                                    stockid = Convert.ToInt32(dr2["stockid"]);
                                    stockname = Convert.ToString(dr2["stockname"]);
                                    stockweigth = Convert.ToInt32(dr2["stockweigth"]);
                                    stockcompany = Convert.ToString(dr2["stockcompany"]);
                                    stockcategory = Convert.ToString(dr2["stockcategory"]);
                                    stockdate = Convert.ToString(dr2["stockdate"]);
                                    stocktime = Convert.ToString(dr2["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 250 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }        
                                }
                            }

                            SqlCommand cmd4 = new SqlCommand("select * from Stock where stockname = 'chinese salt' ", con, tran);
                            cmd4.ExecuteNonQuery();

                            using (SqlDataReader dr3 = cmd4.ExecuteReader())
                            {
                                while (dr3.Read())
                                {
                                    stockid = Convert.ToInt32(dr3["stockid"]);
                                    stockname = Convert.ToString(dr3["stockname"]);
                                    stockweigth = Convert.ToInt32(dr3["stockweigth"]);
                                    stockcompany = Convert.ToString(dr3["stockcompany"]);
                                    stockcategory = Convert.ToString(dr3["stockcategory"]);
                                    stockdate = Convert.ToString(dr3["stockdate"]);
                                    stocktime = Convert.ToString(dr3["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }     
                                }
                            }

                            SqlCommand cmd6 = new SqlCommand("select * from Stock where stockname = 'white chilli' ", con, tran);
                            cmd6.ExecuteNonQuery();

                            using (SqlDataReader dr4 = cmd6.ExecuteReader())
                            {
                                while (dr4.Read())
                                {
                                    stockid = Convert.ToInt32(dr4["stockid"]);
                                    stockname = Convert.ToString(dr4["stockname"]);
                                    stockweigth = Convert.ToInt32(dr4["stockweigth"]);
                                    stockcompany = Convert.ToString(dr4["stockcompany"]);
                                    stockcategory = Convert.ToString(dr4["stockcategory"]);
                                    stockdate = Convert.ToString(dr4["stockdate"]);
                                    stocktime = Convert.ToString(dr4["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }

                            SqlCommand cmd8 = new SqlCommand("select * from Stock where stockname = 'mastard powder' ", con, tran);
                            cmd8.ExecuteNonQuery();

                            using (SqlDataReader dr5 = cmd8.ExecuteReader())
                            {
                                while (dr5.Read())
                                {
                                    stockid = Convert.ToInt32(dr5["stockid"]);
                                    stockname = Convert.ToString(dr5["stockname"]);
                                    stockweigth = Convert.ToInt32(dr5["stockweigth"]);
                                    stockcompany = Convert.ToString(dr5["stockcompany"]);
                                    stockcategory = Convert.ToString(dr5["stockcategory"]);
                                    stockdate = Convert.ToString(dr5["stockdate"]);
                                    stocktime = Convert.ToString(dr5["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    } 
                                }
                            }

                            SqlCommand cmd10 = new SqlCommand("select * from Stock where stockname = 'sauce' ", con, tran);
                            cmd10.ExecuteNonQuery();

                            using (SqlDataReader dr6 = cmd10.ExecuteReader())
                            {
                                while (dr6.Read())
                                {
                                    stockid = Convert.ToInt32(dr6["stockid"]);
                                    stockname = Convert.ToString(dr6["stockname"]);
                                    stockweigth = Convert.ToInt32(dr6["stockweigth"]);
                                    stockcompany = Convert.ToString(dr6["stockcompany"]);
                                    stockcategory = Convert.ToString(dr6["stockcategory"]);
                                    stockdate = Convert.ToString(dr6["stockdate"]);
                                    stocktime = Convert.ToString(dr6["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }                                    
                                }
                            }

                            SqlCommand cmd12 = new SqlCommand("select * from Stock where stockname = 'meda' ", con, tran);
                            cmd12.ExecuteNonQuery();

                            using (SqlDataReader dr7 = cmd12.ExecuteReader())
                            {
                                while (dr7.Read())
                                {
                                    stockid = Convert.ToInt32(dr7["stockid"]);
                                    stockname = Convert.ToString(dr7["stockname"]);
                                    stockweigth = Convert.ToInt32(dr7["stockweigth"]);
                                    stockcompany = Convert.ToString(dr7["stockcompany"]);
                                    stockcategory = Convert.ToString(dr7["stockcategory"]);
                                    stockdate = Convert.ToString(dr7["stockdate"]);
                                    stocktime = Convert.ToString(dr7["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 250 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }

                            SqlCommand cmd14 = new SqlCommand("select * from Stock where stockname = 'bread crum' ", con, tran);
                            cmd14.ExecuteNonQuery();

                            using (SqlDataReader dr8 = cmd14.ExecuteReader())
                            {
                                while (dr8.Read())
                                {
                                    stockid = Convert.ToInt32(dr8["stockid"]);
                                    stockname = Convert.ToString(dr8["stockname"]);
                                    stockweigth = Convert.ToInt32(dr8["stockweigth"]);
                                    stockcompany = Convert.ToString(dr8["stockcompany"]);
                                    stockcategory = Convert.ToString(dr8["stockcategory"]);
                                    stockdate = Convert.ToString(dr8["stockdate"]);
                                    stocktime = Convert.ToString(dr8["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 250 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }                                    
                                }
                            }

                            SqlCommand cmd16 = new SqlCommand("select * from Stock where stockname = 'baking powder' ", con, tran);
                            cmd16.ExecuteNonQuery();

                            using (SqlDataReader dr9 = cmd16.ExecuteReader())
                            {
                                while (dr9.Read())
                                {
                                    stockid = Convert.ToInt32(dr9["stockid"]);
                                    stockname = Convert.ToString(dr9["stockname"]);
                                    stockweigth = Convert.ToInt32(dr9["stockweigth"]);
                                    stockcompany = Convert.ToString(dr9["stockcompany"]);
                                    stockcategory = Convert.ToString(dr9["stockcategory"]);
                                    stockdate = Convert.ToString(dr9["stockdate"]);
                                    stocktime = Convert.ToString(dr9["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }                                   
                                }
                            }

                            SqlCommand cmd18 = new SqlCommand("select * from Stock where stockname = 'baking powder' ", con, tran);
                            cmd18.ExecuteNonQuery();

                            using (SqlDataReader dr10 = cmd18.ExecuteReader())
                            {
                                while (dr10.Read())
                                {
                                    stockid = Convert.ToInt32(dr10["stockid"]);
                                    stockname = Convert.ToString(dr10["stockname"]);
                                    stockweigth = Convert.ToInt32(dr10["stockweigth"]);
                                    stockcompany = Convert.ToString(dr10["stockcompany"]);
                                    stockcategory = Convert.ToString(dr10["stockcategory"]);
                                    stockdate = Convert.ToString(dr10["stockdate"]);
                                    stocktime = Convert.ToString(dr10["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd19 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd19.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd19 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd19.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }                                    
                                }
                            }

                            SqlCommand cmd20 = new SqlCommand("select * from Stock where stockname = 'egg' ", con, tran);
                            cmd20.ExecuteNonQuery();

                            using (SqlDataReader dr11 = cmd20.ExecuteReader())
                            {
                                while (dr11.Read())
                                {
                                    stockid = Convert.ToInt32(dr11["stockid"]);
                                    stockname = Convert.ToString(dr11["stockname"]);
                                    double stockweigth2 = Convert.ToDouble(dr11["stockweigth"]);
                                    stockcompany = Convert.ToString(dr11["stockcompany"]);
                                    stockcategory = Convert.ToString(dr11["stockcategory"]);
                                    stockdate = Convert.ToString(dr11["stockdate"]);
                                    stocktime = Convert.ToString(dr11["stocktime"]);

                                    if (stockweigth2 > 0)
                                    {
                                        double newstockweigth2 = stockweigth2 - 21 * quantity;

                                        if (newstockweigth2 > -1)
                                        {
                                            SqlCommand cmd21 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth2 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd21.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd21 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd21.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }

                            SqlCommand cmd22 = new SqlCommand("select * from Stock where stockname = 'corn flour' ", con, tran);
                            cmd22.ExecuteNonQuery();

                            using (SqlDataReader dr12 = cmd22.ExecuteReader())
                            {
                                while (dr12.Read())
                                {
                                    stockid = Convert.ToInt32(dr12["stockid"]);
                                    stockname = Convert.ToString(dr12["stockname"]);
                                    stockweigth = Convert.ToInt32(dr12["stockweigth"]);
                                    stockcompany = Convert.ToString(dr12["stockcompany"]);
                                    stockcategory = Convert.ToString(dr12["stockcategory"]);
                                    stockdate = Convert.ToString(dr12["stockdate"]);
                                    stocktime = Convert.ToString(dr12["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 2 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd23 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd23.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd23 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd23.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }                                    
                                }
                            }

                            SqlCommand cmd24 = new SqlCommand("select * from Stock where stockname = 'milk' ", con, tran);
                            cmd24.ExecuteNonQuery();

                            using (SqlDataReader dr13 = cmd24.ExecuteReader())
                            {
                                while (dr13.Read())
                                {
                                    stockid = Convert.ToInt32(dr13["stockid"]);
                                    stockname = Convert.ToString(dr13["stockname"]);
                                    stockweigth = Convert.ToInt32(dr13["stockweigth"]);
                                    stockcompany = Convert.ToString(dr13["stockcompany"]);
                                    stockcategory = Convert.ToString(dr13["stockcategory"]);
                                    stockdate = Convert.ToString(dr13["stockdate"]);
                                    stocktime = Convert.ToString(dr13["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 8 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd25 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd25.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd25 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd25.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }                                    
                                }
                            }

                            SqlCommand cmd26 = new SqlCommand("select * from Stock where stockname = 'bun' ", con, tran);
                            cmd26.ExecuteNonQuery();

                            using (SqlDataReader dr14 = cmd26.ExecuteReader())
                            {
                                while (dr14.Read())
                                {
                                    stockid = Convert.ToInt32(dr14["stockid"]);
                                    stockname = Convert.ToString(dr14["stockname"]);
                                    stockweigth = Convert.ToInt32(dr14["stockweigth"]);
                                    stockcompany = Convert.ToString(dr14["stockcompany"]);
                                    stockcategory = Convert.ToString(dr14["stockcategory"]);
                                    stockdate = Convert.ToString(dr14["stockdate"]);
                                    stocktime = Convert.ToString(dr14["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd27 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd27.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd27 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd27.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }                                    
                                }
                            }

                            SqlCommand cmd28 = new SqlCommand("select * from Stock where stockname = 'mayoneze' ", con, tran);
                            cmd28.ExecuteNonQuery();

                            using (SqlDataReader dr15 = cmd28.ExecuteReader())
                            {
                                while (dr15.Read())
                                {
                                    stockid = Convert.ToInt32(dr15["stockid"]);
                                    stockname = Convert.ToString(dr15["stockname"]);
                                    stockweigth = Convert.ToInt32(dr15["stockweigth"]);
                                    stockcompany = Convert.ToString(dr15["stockcompany"]);
                                    stockcategory = Convert.ToString(dr15["stockcategory"]);
                                    stockdate = Convert.ToString(dr15["stockdate"]);
                                    stocktime = Convert.ToString(dr15["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd29 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd29.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd29 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd29.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }                                   
                                }
                            }

                            SqlCommand cmd30 = new SqlCommand("select * from Stock where stockname = 'ketchup' ", con, tran);
                            cmd30.ExecuteNonQuery();

                            using (SqlDataReader dr16 = cmd30.ExecuteReader())
                            {
                                while (dr16.Read())
                                {
                                    stockid = Convert.ToInt32(dr16["stockid"]);
                                    stockname = Convert.ToString(dr16["stockname"]);
                                    stockweigth = Convert.ToInt32(dr16["stockweigth"]);
                                    stockcompany = Convert.ToString(dr16["stockcompany"]);
                                    stockcategory = Convert.ToString(dr16["stockcategory"]);
                                    stockdate = Convert.ToString(dr16["stockdate"]);
                                    stocktime = Convert.ToString(dr16["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd31 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd31.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd31 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd31.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }                                    
                                }
                            }

                            SqlCommand cmd32 = new SqlCommand("select * from Stock where stockname = 'salad' ", con, tran);
                            cmd32.ExecuteNonQuery();

                            using (SqlDataReader dr17 = cmd32.ExecuteReader())
                            {
                                while (dr17.Read())
                                {
                                    stockid = Convert.ToInt32(dr17["stockid"]);
                                    stockname = Convert.ToString(dr17["stockname"]);
                                    stockweigth = Convert.ToInt32(dr17["stockweigth"]);
                                    stockcompany = Convert.ToString(dr17["stockcompany"]);
                                    stockcategory = Convert.ToString(dr17["stockcategory"]);
                                    stockdate = Convert.ToString(dr17["stockdate"]);
                                    stocktime = Convert.ToString(dr17["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd33 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd33.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd33 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd33.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }                                  
                                }
                            }

                            SqlCommand cmd34 = new SqlCommand("select * from Stock where stockname = 'salt' ", con, tran);
                            cmd34.ExecuteNonQuery();

                            using (SqlDataReader dr18 = cmd34.ExecuteReader())
                            {
                                while (dr18.Read())
                                {
                                    stockid = Convert.ToInt32(dr18["stockid"]);
                                    stockname = Convert.ToString(dr18["stockname"]);
                                    stockweigth = Convert.ToInt32(dr18["stockweigth"]);
                                    stockcompany = Convert.ToString(dr18["stockcompany"]);
                                    stockcategory = Convert.ToString(dr18["stockcategory"]);
                                    stockdate = Convert.ToString(dr18["stockdate"]);
                                    stocktime = Convert.ToString(dr18["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd35 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd35.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd35 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd35.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }                                   
                                }
                            }

                            SqlCommand cmd36 = new SqlCommand("select * from Stock where stockname = 'bun' ", con, tran);
                            cmd36.ExecuteNonQuery();

                            using (SqlDataReader dr19 = cmd36.ExecuteReader())
                            {
                                while (dr19.Read())
                                {
                                    stockid = Convert.ToInt32(dr19["stockid"]);
                                    stockname = Convert.ToString(dr19["stockname"]);
                                    stockweigth = Convert.ToInt32(dr19["stockweigth"]);
                                    stockcompany = Convert.ToString(dr19["stockcompany"]);
                                    stockcategory = Convert.ToString(dr19["stockcategory"]);
                                    stockdate = Convert.ToString(dr19["stockdate"]);
                                    stocktime = Convert.ToString(dr19["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }

                            SqlCommand cmd38 = new SqlCommand("select * from Stock where stockname = 'box' ", con, tran);
                            cmd38.ExecuteNonQuery();

                            using (SqlDataReader dr20 = cmd38.ExecuteReader())
                            {
                                while (dr20.Read())
                                {
                                    stockid = Convert.ToInt32(dr20["stockid"]);
                                    stockname = Convert.ToString(dr20["stockname"]);
                                    stockweigth = Convert.ToInt32(dr20["stockweigth"]);
                                    stockcompany = Convert.ToString(dr20["stockcompany"]);
                                    stockcategory = Convert.ToString(dr20["stockcategory"]);
                                    stockdate = Convert.ToString(dr20["stockdate"]);
                                    stocktime = Convert.ToString(dr20["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd39 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd39.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd39 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd39.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }
                            //
                        }

                    }
                    //else if 1
                    else if (Convert.ToString(Row.Cells[0].Value) == beefburger)
                    {
                        string gridname = Convert.ToString(Row.Cells[0].Value);
                        int quantity = Convert.ToInt32(Row.Cells[1].Value);
                        exist = true;
                        if (exist == true)
                        {
                            //MessageBox.Show("Found");
                            SqlCommand cmd = new SqlCommand("select * from Stock where stockname = 'minced meat' ", con, tran);
                            cmd.ExecuteNonQuery();

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    stockid = Convert.ToInt32(dr["stockid"]);
                                    stockname = Convert.ToString(dr["stockname"]);
                                    stockweigth = Convert.ToInt32(dr["stockweigth"]);
                                    stockcompany = Convert.ToString(dr["stockcompany"]);
                                    stockcategory = Convert.ToString(dr["stockcategory"]);
                                    stockdate = Convert.ToString(dr["stockdate"]);
                                    stocktime = Convert.ToString(dr["stocktime"]);                                                          

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 500 * quantity;

                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                   
                                }
                            }

                            SqlCommand cmd2 = new SqlCommand("select * from Stock where stockname = 'salt' ", con, tran);
                            cmd2.ExecuteNonQuery();

                            using (SqlDataReader dr2 = cmd2.ExecuteReader())
                            {
                                while (dr2.Read())
                                {
                                    stockid = Convert.ToInt32(dr2["stockid"]);
                                    stockname = Convert.ToString(dr2["stockname"]);
                                    stockweigth = Convert.ToInt32(dr2["stockweigth"]);
                                    stockcompany = Convert.ToString(dr2["stockcompany"]);
                                    stockcategory = Convert.ToString(dr2["stockcategory"]);
                                    stockdate = Convert.ToString(dr2["stockdate"]);
                                    stocktime = Convert.ToString(dr2["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                    
                                }
                            }

                            SqlCommand cmd4 = new SqlCommand("select * from Stock where stockname = 'mashed garlic' ", con, tran);
                            cmd4.ExecuteNonQuery();

                            using (SqlDataReader dr3 = cmd4.ExecuteReader())
                            {
                                while (dr3.Read())
                                {
                                    stockid = Convert.ToInt32(dr3["stockid"]);
                                    stockname = Convert.ToString(dr3["stockname"]);
                                    stockweigth = Convert.ToInt32(dr3["stockweigth"]);
                                    stockcompany = Convert.ToString(dr3["stockcompany"]);
                                    stockcategory = Convert.ToString(dr3["stockcategory"]);
                                    stockdate = Convert.ToString(dr3["stockdate"]);
                                    stocktime = Convert.ToString(dr3["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                   
                                }
                            }

                            SqlCommand cmd6 = new SqlCommand("select * from Stock where stockname = 'white chilli' ", con, tran);
                            cmd6.ExecuteNonQuery();

                            using (SqlDataReader dr4 = cmd6.ExecuteReader())
                            {
                                while (dr4.Read())
                                {
                                    stockid = Convert.ToInt32(dr4["stockid"]);
                                    stockname = Convert.ToString(dr4["stockname"]);
                                    stockweigth = Convert.ToInt32(dr4["stockweigth"]);
                                    stockcompany = Convert.ToString(dr4["stockcompany"]);
                                    stockcategory = Convert.ToString(dr4["stockcategory"]);
                                    stockdate = Convert.ToString(dr4["stockdate"]);
                                    stocktime = Convert.ToString(dr4["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                   
                                }
                            }

                            SqlCommand cmd8 = new SqlCommand("select * from Stock where stockname = 'black chilli' ", con, tran);
                            cmd8.ExecuteNonQuery();

                            using (SqlDataReader dr5 = cmd8.ExecuteReader())
                            {
                                while (dr5.Read())
                                {
                                    stockid = Convert.ToInt32(dr5["stockid"]);
                                    stockname = Convert.ToString(dr5["stockname"]);
                                    stockweigth = Convert.ToInt32(dr5["stockweigth"]);
                                    stockcompany = Convert.ToString(dr5["stockcompany"]);
                                    stockcategory = Convert.ToString(dr5["stockcategory"]);
                                    stockdate = Convert.ToString(dr5["stockdate"]);
                                    stocktime = Convert.ToString(dr5["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {

                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                        else
                                        {

                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                }
                            }

                            SqlCommand cmd10 = new SqlCommand("select * from Stock where stockname = 'tomato paste' ", con, tran);
                            cmd10.ExecuteNonQuery();

                            using (SqlDataReader dr6 = cmd10.ExecuteReader())
                            {
                                while (dr6.Read())
                                {
                                    stockid = Convert.ToInt32(dr6["stockid"]);
                                    stockname = Convert.ToString(dr6["stockname"]);
                                    stockweigth = Convert.ToInt32(dr6["stockweigth"]);
                                    stockcompany = Convert.ToString(dr6["stockcompany"]);
                                    stockcategory = Convert.ToString(dr6["stockcategory"]);
                                    stockdate = Convert.ToString(dr6["stockdate"]);
                                    stocktime = Convert.ToString(dr6["stocktime"]);

                                    newstockweigth = stockweigth - 4 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                    
                                }
                            }

                            SqlCommand cmd12 = new SqlCommand("select * from Stock where stockname = 'ketchup' ", con, tran);
                            cmd12.ExecuteNonQuery();

                            using (SqlDataReader dr7 = cmd12.ExecuteReader())
                            {
                                while (dr7.Read())
                                {
                                    stockid = Convert.ToInt32(dr7["stockid"]);
                                    stockname = Convert.ToString(dr7["stockname"]);
                                    stockweigth = Convert.ToInt32(dr7["stockweigth"]);
                                    stockcompany = Convert.ToString(dr7["stockcompany"]);
                                    stockcategory = Convert.ToString(dr7["stockcategory"]);
                                    stockdate = Convert.ToString(dr7["stockdate"]);
                                    stocktime = Convert.ToString(dr7["stocktime"]);

                                    newstockweigth = stockweigth - 4 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                   
                                }
                            }

                            SqlCommand cmd14 = new SqlCommand("select * from Stock where stockname = 'mastard paste' ", con, tran);
                            cmd14.ExecuteNonQuery();

                            using (SqlDataReader dr8 = cmd14.ExecuteReader())
                            {
                                while (dr8.Read())
                                {
                                    stockid = Convert.ToInt32(dr8["stockid"]);
                                    stockname = Convert.ToString(dr8["stockname"]);
                                    stockweigth = Convert.ToInt32(dr8["stockweigth"]);
                                    stockcompany = Convert.ToString(dr8["stockcompany"]);
                                    stockcategory = Convert.ToString(dr8["stockcategory"]);
                                    stockdate = Convert.ToString(dr8["stockdate"]);
                                    stocktime = Convert.ToString(dr8["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                    
                                }
                            }

                            SqlCommand cmd16 = new SqlCommand("select * from Stock where stockname = 'chinese salt' ", con, tran);
                            cmd16.ExecuteNonQuery();

                            using (SqlDataReader dr9 = cmd16.ExecuteReader())
                            {
                                while (dr9.Read())
                                {
                                    stockid = Convert.ToInt32(dr9["stockid"]);
                                    stockname = Convert.ToString(dr9["stockname"]);
                                    stockweigth = Convert.ToInt32(dr9["stockweigth"]);
                                    stockcompany = Convert.ToString(dr9["stockcompany"]);
                                    stockcategory = Convert.ToString(dr9["stockcategory"]);
                                    stockdate = Convert.ToString(dr9["stockdate"]);
                                    stocktime = Convert.ToString(dr9["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                  
                                }
                            }

                            SqlCommand cmd18 = new SqlCommand("select * from Stock where stockname = 'Vinegar' ", con, tran);
                            cmd18.ExecuteNonQuery();

                            using (SqlDataReader dr10 = cmd18.ExecuteReader())
                            {
                                while (dr10.Read())
                                {
                                    stockid = Convert.ToInt32(dr10["stockid"]);
                                    stockname = Convert.ToString(dr10["stockname"]);
                                    stockweigth = Convert.ToInt32(dr10["stockweigth"]);
                                    stockcompany = Convert.ToString(dr10["stockcompany"]);
                                    stockcategory = Convert.ToString(dr10["stockcategory"]);
                                    stockdate = Convert.ToString(dr10["stockdate"]);
                                    stocktime = Convert.ToString(dr10["stocktime"]);

                                    newstockweigth = stockweigth - 4 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd19 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd19.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd19 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd19.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                    
                                }
                            }

                            SqlCommand cmd20 = new SqlCommand("select * from Stock where stockname = 'soya sauce' ", con, tran);
                            cmd20.ExecuteNonQuery();

                            using (SqlDataReader dr11 = cmd20.ExecuteReader())
                            {
                                while (dr11.Read())
                                {
                                    stockid = Convert.ToInt32(dr11["stockid"]);
                                    stockname = Convert.ToString(dr11["stockname"]);
                                    double stockweigth2 = Convert.ToDouble(dr11["stockweigth"]);
                                    stockcompany = Convert.ToString(dr11["stockcompany"]);
                                    stockcategory = Convert.ToString(dr11["stockcategory"]);
                                    stockdate = Convert.ToString(dr11["stockdate"]);
                                    stocktime = Convert.ToString(dr11["stocktime"]);

                                    double newstockweigth2 = stockweigth2 - 4 * quantity;

                                    if (stockweigth2 > 0)
                                    {
                                        if (newstockweigth2 > 0)
                                        {
                                            SqlCommand cmd21 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth2 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd21.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd21 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd21.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                   
                                }
                            }

                            SqlCommand cmd22 = new SqlCommand("select * from Stock where stockname = 'butter' ", con, tran);
                            cmd22.ExecuteNonQuery();

                            using (SqlDataReader dr12 = cmd22.ExecuteReader())
                            {
                                while (dr12.Read())
                                {
                                    stockid = Convert.ToInt32(dr12["stockid"]);
                                    stockname = Convert.ToString(dr12["stockname"]);
                                    stockweigth = Convert.ToInt32(dr12["stockweigth"]);
                                    stockcompany = Convert.ToString(dr12["stockcompany"]);
                                    stockcategory = Convert.ToString(dr12["stockcategory"]);
                                    stockdate = Convert.ToString(dr12["stockdate"]);
                                    stocktime = Convert.ToString(dr12["stocktime"]);

                                    newstockweigth = stockweigth - 4 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd23 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd23.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd23 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd23.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                }
                            }

                            SqlCommand cmd24 = new SqlCommand("select * from Stock where stockname = 'egg' ", con, tran);
                            cmd24.ExecuteNonQuery();

                            using (SqlDataReader dr13 = cmd24.ExecuteReader())
                            {
                                while (dr13.Read())
                                {
                                    stockid = Convert.ToInt32(dr13["stockid"]);
                                    stockname = Convert.ToString(dr13["stockname"]);
                                    stockweigth = Convert.ToInt32(dr13["stockweigth"]);
                                    stockcompany = Convert.ToString(dr13["stockcompany"]);
                                    stockcategory = Convert.ToString(dr13["stockcategory"]);
                                    stockdate = Convert.ToString(dr13["stockdate"]);
                                    stocktime = Convert.ToString(dr13["stocktime"]);

                                    newstockweigth = stockweigth - 21 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd25 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd25.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd25 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd25.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                }
                            }

                            SqlCommand cmd26 = new SqlCommand("select * from Stock where stockname = 'bun' ", con, tran);
                            cmd26.ExecuteNonQuery();

                            using (SqlDataReader dr14 = cmd26.ExecuteReader())
                            {
                                while (dr14.Read())
                                {
                                    stockid = Convert.ToInt32(dr14["stockid"]);
                                    stockname = Convert.ToString(dr14["stockname"]);
                                    stockweigth = Convert.ToInt32(dr14["stockweigth"]);
                                    stockcompany = Convert.ToString(dr14["stockcompany"]);
                                    stockcategory = Convert.ToString(dr14["stockcategory"]);
                                    stockdate = Convert.ToString(dr14["stockdate"]);
                                    stocktime = Convert.ToString(dr14["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd27 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd27.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd27 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd27.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }

                            SqlCommand cmd28 = new SqlCommand("select * from Stock where stockname = 'milk' ", con, tran);
                            cmd28.ExecuteNonQuery();

                            using (SqlDataReader dr15 = cmd28.ExecuteReader())
                            {
                                while (dr15.Read())
                                {
                                    stockid = Convert.ToInt32(dr15["stockid"]);
                                    stockname = Convert.ToString(dr15["stockname"]);
                                    stockweigth = Convert.ToInt32(dr15["stockweigth"]);
                                    stockcompany = Convert.ToString(dr15["stockcompany"]);
                                    stockcategory = Convert.ToString(dr15["stockcategory"]);
                                    stockdate = Convert.ToString(dr15["stockdate"]);
                                    stocktime = Convert.ToString(dr15["stocktime"]);

                                    newstockweigth = stockweigth - 8 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd29 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd29.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd29 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd29.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                   
                                }
                            }

                            SqlCommand cmd30 = new SqlCommand("select * from Stock where stockname = 'bread crumb' ", con, tran);
                            cmd30.ExecuteNonQuery();

                            using (SqlDataReader dr16 = cmd30.ExecuteReader())
                            {
                                while (dr16.Read())
                                {
                                    stockid = Convert.ToInt32(dr16["stockid"]);
                                    stockname = Convert.ToString(dr16["stockname"]);
                                    stockweigth = Convert.ToInt32(dr16["stockweigth"]);
                                    stockcompany = Convert.ToString(dr16["stockcompany"]);
                                    stockcategory = Convert.ToString(dr16["stockcategory"]);
                                    stockdate = Convert.ToString(dr16["stockdate"]);
                                    stocktime = Convert.ToString(dr16["stocktime"]);

                                    newstockweigth = stockweigth - 100 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd31 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd31.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd31 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd31.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                    
                                }
                            }

                            SqlCommand cmd32 = new SqlCommand("select * from Stock where stockname = 'cooking oil' ", con, tran);
                            cmd32.ExecuteNonQuery();

                            using (SqlDataReader dr17 = cmd32.ExecuteReader())
                            {
                                while (dr17.Read())
                                {
                                    stockid = Convert.ToInt32(dr17["stockid"]);
                                    stockname = Convert.ToString(dr17["stockname"]);
                                    stockweigth = Convert.ToInt32(dr17["stockweigth"]);
                                    stockcompany = Convert.ToString(dr17["stockcompany"]);
                                    stockcategory = Convert.ToString(dr17["stockcategory"]);
                                    stockdate = Convert.ToString(dr17["stockdate"]);
                                    stocktime = Convert.ToString(dr17["stocktime"]);

                                    newstockweigth = stockweigth - 20 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd33 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd33.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd33 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd33.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                    
                                }
                            }

                            SqlCommand cmd34 = new SqlCommand("select * from Stock where stockname = 'bun' ", con, tran);
                            cmd34.ExecuteNonQuery();

                            using (SqlDataReader dr18 = cmd34.ExecuteReader())
                            {
                                while (dr18.Read())
                                {
                                    stockid = Convert.ToInt32(dr18["stockid"]);
                                    stockname = Convert.ToString(dr18["stockname"]);
                                    stockweigth = Convert.ToInt32(dr18["stockweigth"]);
                                    stockcompany = Convert.ToString(dr18["stockcompany"]);
                                    stockcategory = Convert.ToString(dr18["stockcategory"]);
                                    stockdate = Convert.ToString(dr18["stockdate"]);
                                    stocktime = Convert.ToString(dr18["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd35 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd35.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd35 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd35.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }

                            SqlCommand cmd36 = new SqlCommand("select * from Stock where stockname = 'box' ", con, tran);
                            cmd36.ExecuteNonQuery();

                            using (SqlDataReader dr19 = cmd36.ExecuteReader())
                            {
                                while (dr19.Read())
                                {
                                    stockid = Convert.ToInt32(dr19["stockid"]);
                                    stockname = Convert.ToString(dr19["stockname"]);
                                    stockweigth = Convert.ToInt32(dr19["stockweigth"]);
                                    stockcompany = Convert.ToString(dr19["stockcompany"]);
                                    stockcategory = Convert.ToString(dr19["stockcategory"]);
                                    stockdate = Convert.ToString(dr19["stockdate"]);
                                    stocktime = Convert.ToString(dr19["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }
                        }
                    }

                    //else if 2
                    else if (Convert.ToString(Row.Cells[0].Value) == clubsandwich)
                    {
                        string gridname = Convert.ToString(Row.Cells[0].Value);
                        int quantity = Convert.ToInt32(Row.Cells[1].Value);
                        exist = true;
                        if (exist == true)
                        {
                            //MessageBox.Show("Found");
                            SqlCommand cmd = new SqlCommand("select * from Stock where stockname = 'salt' ", con, tran);
                            cmd.ExecuteNonQuery();

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    stockid = Convert.ToInt32(dr["stockid"]);
                                    stockname = Convert.ToString(dr["stockname"]);
                                    stockweigth = Convert.ToInt32(dr["stockweigth"]);
                                    stockcompany = Convert.ToString(dr["stockcompany"]);
                                    stockcategory = Convert.ToString(dr["stockcategory"]);
                                    stockdate = Convert.ToString(dr["stockdate"]);
                                    stocktime = Convert.ToString(dr["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd2 = new SqlCommand("select * from Stock where stockname = 'white pepper powder' ", con, tran);
                            cmd2.ExecuteNonQuery();

                            using (SqlDataReader dr2 = cmd2.ExecuteReader())
                            {
                                while (dr2.Read())
                                {
                                    stockid = Convert.ToInt32(dr2["stockid"]);
                                    stockname = Convert.ToString(dr2["stockname"]);
                                    stockweigth = Convert.ToInt32(dr2["stockweigth"]);
                                    stockcompany = Convert.ToString(dr2["stockcompany"]);
                                    stockcategory = Convert.ToString(dr2["stockcategory"]);
                                    stockdate = Convert.ToString(dr2["stockdate"]);
                                    stocktime = Convert.ToString(dr2["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd4 = new SqlCommand("select * from Stock where stockname = 'black pepper powder' ", con, tran);
                            cmd4.ExecuteNonQuery();

                            using (SqlDataReader dr3 = cmd4.ExecuteReader())
                            {
                                while (dr3.Read())
                                {
                                    stockid = Convert.ToInt32(dr3["stockid"]);
                                    stockname = Convert.ToString(dr3["stockname"]);
                                    stockweigth = Convert.ToInt32(dr3["stockweigth"]);
                                    stockcompany = Convert.ToString(dr3["stockcompany"]);
                                    stockcategory = Convert.ToString(dr3["stockcategory"]);
                                    stockdate = Convert.ToString(dr3["stockdate"]);
                                    stocktime = Convert.ToString(dr3["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd6 = new SqlCommand("select * from Stock where stockname = 'soya sauce' ", con, tran);
                            cmd6.ExecuteNonQuery();

                            using (SqlDataReader dr4 = cmd6.ExecuteReader())
                            {
                                while (dr4.Read())
                                {
                                    stockid = Convert.ToInt32(dr4["stockid"]);
                                    stockname = Convert.ToString(dr4["stockname"]);
                                    stockweigth = Convert.ToInt32(dr4["stockweigth"]);
                                    stockcompany = Convert.ToString(dr4["stockcompany"]);
                                    stockcategory = Convert.ToString(dr4["stockcategory"]);
                                    stockdate = Convert.ToString(dr4["stockdate"]);
                                    stocktime = Convert.ToString(dr4["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd8 = new SqlCommand("select * from Stock where stockname = 'lemon juice' ", con, tran);
                            cmd8.ExecuteNonQuery();

                            using (SqlDataReader dr5 = cmd8.ExecuteReader())
                            {
                                while (dr5.Read())
                                {
                                    stockid = Convert.ToInt32(dr5["stockid"]);
                                    stockname = Convert.ToString(dr5["stockname"]);
                                    stockweigth = Convert.ToInt32(dr5["stockweigth"]);
                                    stockcompany = Convert.ToString(dr5["stockcompany"]);
                                    stockcategory = Convert.ToString(dr5["stockcategory"]);
                                    stockdate = Convert.ToString(dr5["stockdate"]);
                                    stocktime = Convert.ToString(dr5["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {

                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                        else
                                        {

                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                }
                            }

                            SqlCommand cmd10 = new SqlCommand("select * from Stock where stockname = 'mustard paste' ", con, tran);
                            cmd10.ExecuteNonQuery();

                            using (SqlDataReader dr6 = cmd10.ExecuteReader())
                            {
                                while (dr6.Read())
                                {
                                    stockid = Convert.ToInt32(dr6["stockid"]);
                                    stockname = Convert.ToString(dr6["stockname"]);
                                    stockweigth = Convert.ToInt32(dr6["stockweigth"]);
                                    stockcompany = Convert.ToString(dr6["stockcompany"]);
                                    stockcategory = Convert.ToString(dr6["stockcategory"]);
                                    stockdate = Convert.ToString(dr6["stockdate"]);
                                    stocktime = Convert.ToString(dr6["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd12 = new SqlCommand("select * from Stock where stockname = 'ginger garlic paste' ", con, tran);
                            cmd12.ExecuteNonQuery();

                            using (SqlDataReader dr7 = cmd12.ExecuteReader())
                            {
                                while (dr7.Read())
                                {
                                    stockid = Convert.ToInt32(dr7["stockid"]);
                                    stockname = Convert.ToString(dr7["stockname"]);
                                    stockweigth = Convert.ToInt32(dr7["stockweigth"]);
                                    stockcompany = Convert.ToString(dr7["stockcompany"]);
                                    stockcategory = Convert.ToString(dr7["stockcategory"]);
                                    stockdate = Convert.ToString(dr7["stockdate"]);
                                    stocktime = Convert.ToString(dr7["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd14 = new SqlCommand("select * from Stock where stockname = 'oil' ", con, tran);
                            cmd14.ExecuteNonQuery();

                            using (SqlDataReader dr8 = cmd14.ExecuteReader())
                            {
                                while (dr8.Read())
                                {
                                    stockid = Convert.ToInt32(dr8["stockid"]);
                                    stockname = Convert.ToString(dr8["stockname"]);
                                    stockweigth = Convert.ToInt32(dr8["stockweigth"]);
                                    stockcompany = Convert.ToString(dr8["stockcompany"]);
                                    stockcategory = Convert.ToString(dr8["stockcategory"]);
                                    stockdate = Convert.ToString(dr8["stockdate"]);
                                    stocktime = Convert.ToString(dr8["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd16 = new SqlCommand("select * from Stock where stockname = 'bread slices' ", con, tran);
                            cmd16.ExecuteNonQuery();

                            using (SqlDataReader dr9 = cmd16.ExecuteReader())
                            {
                                while (dr9.Read())
                                {
                                    stockid = Convert.ToInt32(dr9["stockid"]);
                                    stockname = Convert.ToString(dr9["stockname"]);
                                    stockweigth = Convert.ToInt32(dr9["stockweigth"]);
                                    stockcompany = Convert.ToString(dr9["stockcompany"]);
                                    stockcategory = Convert.ToString(dr9["stockcategory"]);
                                    stockdate = Convert.ToString(dr9["stockdate"]);
                                    stocktime = Convert.ToString(dr9["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd18 = new SqlCommand("select * from Stock where stockname = 'cheddar cheese slice' ", con, tran);
                            cmd18.ExecuteNonQuery();

                            using (SqlDataReader dr10 = cmd18.ExecuteReader())
                            {
                                while (dr10.Read())
                                {
                                    stockid = Convert.ToInt32(dr10["stockid"]);
                                    stockname = Convert.ToString(dr10["stockname"]);
                                    stockweigth = Convert.ToInt32(dr10["stockweigth"]);
                                    stockcompany = Convert.ToString(dr10["stockcompany"]);
                                    stockcategory = Convert.ToString(dr10["stockcategory"]);
                                    stockdate = Convert.ToString(dr10["stockdate"]);
                                    stocktime = Convert.ToString(dr10["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd19 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd19.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd19 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd19.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd20 = new SqlCommand("select * from Stock where stockname = 'egg' ", con, tran);
                            cmd20.ExecuteNonQuery();

                            using (SqlDataReader dr11 = cmd20.ExecuteReader())
                            {
                                while (dr11.Read())
                                {
                                    stockid = Convert.ToInt32(dr11["stockid"]);
                                    stockname = Convert.ToString(dr11["stockname"]);
                                    double stockweigth2 = Convert.ToDouble(dr11["stockweigth"]);
                                    stockcompany = Convert.ToString(dr11["stockcompany"]);
                                    stockcategory = Convert.ToString(dr11["stockcategory"]);
                                    stockdate = Convert.ToString(dr11["stockdate"]);
                                    stocktime = Convert.ToString(dr11["stocktime"]);

                                    double newstockweigth2 = stockweigth2 - 1 * quantity;

                                    if (stockweigth2 > 0)
                                    {
                                        if (newstockweigth2 > 0)
                                        {
                                            SqlCommand cmd21 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth2 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd21.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd21 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd21.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd34 = new SqlCommand("select * from Stock where stockname = 'bun' ", con, tran);
                            cmd34.ExecuteNonQuery();

                            using (SqlDataReader dr18 = cmd34.ExecuteReader())
                            {
                                while (dr18.Read())
                                {
                                    stockid = Convert.ToInt32(dr18["stockid"]);
                                    stockname = Convert.ToString(dr18["stockname"]);
                                    stockweigth = Convert.ToInt32(dr18["stockweigth"]);
                                    stockcompany = Convert.ToString(dr18["stockcompany"]);
                                    stockcategory = Convert.ToString(dr18["stockcategory"]);
                                    stockdate = Convert.ToString(dr18["stockdate"]);
                                    stocktime = Convert.ToString(dr18["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd35 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd35.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd35 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd35.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }

                            SqlCommand cmd36 = new SqlCommand("select * from Stock where stockname = 'box' ", con, tran);
                            cmd36.ExecuteNonQuery();

                            using (SqlDataReader dr19 = cmd36.ExecuteReader())
                            {
                                while (dr19.Read())
                                {
                                    stockid = Convert.ToInt32(dr19["stockid"]);
                                    stockname = Convert.ToString(dr19["stockname"]);
                                    stockweigth = Convert.ToInt32(dr19["stockweigth"]);
                                    stockcompany = Convert.ToString(dr19["stockcompany"]);
                                    stockcategory = Convert.ToString(dr19["stockcategory"]);
                                    stockdate = Convert.ToString(dr19["stockdate"]);
                                    stocktime = Convert.ToString(dr19["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }
                        }
                    }
                    //else if end

                    //else if 2
                    else if (Convert.ToString(Row.Cells[0].Value) == clubsandwich)
                    {
                        string gridname = Convert.ToString(Row.Cells[0].Value);
                        int quantity = Convert.ToInt32(Row.Cells[1].Value);
                        exist = true;
                        if (exist == true)
                        {
                            //MessageBox.Show("Found");
                            SqlCommand cmd = new SqlCommand("select * from Stock where stockname = 'salt' ", con, tran);
                            cmd.ExecuteNonQuery();

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    stockid = Convert.ToInt32(dr["stockid"]);
                                    stockname = Convert.ToString(dr["stockname"]);
                                    stockweigth = Convert.ToInt32(dr["stockweigth"]);
                                    stockcompany = Convert.ToString(dr["stockcompany"]);
                                    stockcategory = Convert.ToString(dr["stockcategory"]);
                                    stockdate = Convert.ToString(dr["stockdate"]);
                                    stocktime = Convert.ToString(dr["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd2 = new SqlCommand("select * from Stock where stockname = 'white pepper powder' ", con, tran);
                            cmd2.ExecuteNonQuery();

                            using (SqlDataReader dr2 = cmd2.ExecuteReader())
                            {
                                while (dr2.Read())
                                {
                                    stockid = Convert.ToInt32(dr2["stockid"]);
                                    stockname = Convert.ToString(dr2["stockname"]);
                                    stockweigth = Convert.ToInt32(dr2["stockweigth"]);
                                    stockcompany = Convert.ToString(dr2["stockcompany"]);
                                    stockcategory = Convert.ToString(dr2["stockcategory"]);
                                    stockdate = Convert.ToString(dr2["stockdate"]);
                                    stocktime = Convert.ToString(dr2["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd4 = new SqlCommand("select * from Stock where stockname = 'black pepper powder' ", con, tran);
                            cmd4.ExecuteNonQuery();

                            using (SqlDataReader dr3 = cmd4.ExecuteReader())
                            {
                                while (dr3.Read())
                                {
                                    stockid = Convert.ToInt32(dr3["stockid"]);
                                    stockname = Convert.ToString(dr3["stockname"]);
                                    stockweigth = Convert.ToInt32(dr3["stockweigth"]);
                                    stockcompany = Convert.ToString(dr3["stockcompany"]);
                                    stockcategory = Convert.ToString(dr3["stockcategory"]);
                                    stockdate = Convert.ToString(dr3["stockdate"]);
                                    stocktime = Convert.ToString(dr3["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd6 = new SqlCommand("select * from Stock where stockname = 'soya sauce' ", con, tran);
                            cmd6.ExecuteNonQuery();

                            using (SqlDataReader dr4 = cmd6.ExecuteReader())
                            {
                                while (dr4.Read())
                                {
                                    stockid = Convert.ToInt32(dr4["stockid"]);
                                    stockname = Convert.ToString(dr4["stockname"]);
                                    stockweigth = Convert.ToInt32(dr4["stockweigth"]);
                                    stockcompany = Convert.ToString(dr4["stockcompany"]);
                                    stockcategory = Convert.ToString(dr4["stockcategory"]);
                                    stockdate = Convert.ToString(dr4["stockdate"]);
                                    stocktime = Convert.ToString(dr4["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd8 = new SqlCommand("select * from Stock where stockname = 'lemon juice' ", con, tran);
                            cmd8.ExecuteNonQuery();

                            using (SqlDataReader dr5 = cmd8.ExecuteReader())
                            {
                                while (dr5.Read())
                                {
                                    stockid = Convert.ToInt32(dr5["stockid"]);
                                    stockname = Convert.ToString(dr5["stockname"]);
                                    stockweigth = Convert.ToInt32(dr5["stockweigth"]);
                                    stockcompany = Convert.ToString(dr5["stockcompany"]);
                                    stockcategory = Convert.ToString(dr5["stockcategory"]);
                                    stockdate = Convert.ToString(dr5["stockdate"]);
                                    stocktime = Convert.ToString(dr5["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {

                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                        else
                                        {

                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                }
                            }

                            SqlCommand cmd10 = new SqlCommand("select * from Stock where stockname = 'mustard paste' ", con, tran);
                            cmd10.ExecuteNonQuery();

                            using (SqlDataReader dr6 = cmd10.ExecuteReader())
                            {
                                while (dr6.Read())
                                {
                                    stockid = Convert.ToInt32(dr6["stockid"]);
                                    stockname = Convert.ToString(dr6["stockname"]);
                                    stockweigth = Convert.ToInt32(dr6["stockweigth"]);
                                    stockcompany = Convert.ToString(dr6["stockcompany"]);
                                    stockcategory = Convert.ToString(dr6["stockcategory"]);
                                    stockdate = Convert.ToString(dr6["stockdate"]);
                                    stocktime = Convert.ToString(dr6["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd12 = new SqlCommand("select * from Stock where stockname = 'ginger garlic paste' ", con, tran);
                            cmd12.ExecuteNonQuery();

                            using (SqlDataReader dr7 = cmd12.ExecuteReader())
                            {
                                while (dr7.Read())
                                {
                                    stockid = Convert.ToInt32(dr7["stockid"]);
                                    stockname = Convert.ToString(dr7["stockname"]);
                                    stockweigth = Convert.ToInt32(dr7["stockweigth"]);
                                    stockcompany = Convert.ToString(dr7["stockcompany"]);
                                    stockcategory = Convert.ToString(dr7["stockcategory"]);
                                    stockdate = Convert.ToString(dr7["stockdate"]);
                                    stocktime = Convert.ToString(dr7["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd14 = new SqlCommand("select * from Stock where stockname = 'oil' ", con, tran);
                            cmd14.ExecuteNonQuery();

                            using (SqlDataReader dr8 = cmd14.ExecuteReader())
                            {
                                while (dr8.Read())
                                {
                                    stockid = Convert.ToInt32(dr8["stockid"]);
                                    stockname = Convert.ToString(dr8["stockname"]);
                                    stockweigth = Convert.ToInt32(dr8["stockweigth"]);
                                    stockcompany = Convert.ToString(dr8["stockcompany"]);
                                    stockcategory = Convert.ToString(dr8["stockcategory"]);
                                    stockdate = Convert.ToString(dr8["stockdate"]);
                                    stocktime = Convert.ToString(dr8["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd16 = new SqlCommand("select * from Stock where stockname = 'bread slices' ", con, tran);
                            cmd16.ExecuteNonQuery();

                            using (SqlDataReader dr9 = cmd16.ExecuteReader())
                            {
                                while (dr9.Read())
                                {
                                    stockid = Convert.ToInt32(dr9["stockid"]);
                                    stockname = Convert.ToString(dr9["stockname"]);
                                    stockweigth = Convert.ToInt32(dr9["stockweigth"]);
                                    stockcompany = Convert.ToString(dr9["stockcompany"]);
                                    stockcategory = Convert.ToString(dr9["stockcategory"]);
                                    stockdate = Convert.ToString(dr9["stockdate"]);
                                    stocktime = Convert.ToString(dr9["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd18 = new SqlCommand("select * from Stock where stockname = 'cheddar cheese slice' ", con, tran);
                            cmd18.ExecuteNonQuery();

                            using (SqlDataReader dr10 = cmd18.ExecuteReader())
                            {
                                while (dr10.Read())
                                {
                                    stockid = Convert.ToInt32(dr10["stockid"]);
                                    stockname = Convert.ToString(dr10["stockname"]);
                                    stockweigth = Convert.ToInt32(dr10["stockweigth"]);
                                    stockcompany = Convert.ToString(dr10["stockcompany"]);
                                    stockcategory = Convert.ToString(dr10["stockcategory"]);
                                    stockdate = Convert.ToString(dr10["stockdate"]);
                                    stocktime = Convert.ToString(dr10["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd19 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd19.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd19 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd19.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd20 = new SqlCommand("select * from Stock where stockname = 'egg' ", con, tran);
                            cmd20.ExecuteNonQuery();

                            using (SqlDataReader dr11 = cmd20.ExecuteReader())
                            {
                                while (dr11.Read())
                                {
                                    stockid = Convert.ToInt32(dr11["stockid"]);
                                    stockname = Convert.ToString(dr11["stockname"]);
                                    double stockweigth2 = Convert.ToDouble(dr11["stockweigth"]);
                                    stockcompany = Convert.ToString(dr11["stockcompany"]);
                                    stockcategory = Convert.ToString(dr11["stockcategory"]);
                                    stockdate = Convert.ToString(dr11["stockdate"]);
                                    stocktime = Convert.ToString(dr11["stocktime"]);

                                    double newstockweigth2 = stockweigth2 - 1 * quantity;

                                    if (stockweigth2 > 0)
                                    {
                                        if (newstockweigth2 > 0)
                                        {
                                            SqlCommand cmd21 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth2 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd21.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd21 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd21.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd36 = new SqlCommand("select * from Stock where stockname = 'box' ", con, tran);
                            cmd36.ExecuteNonQuery();

                            using (SqlDataReader dr19 = cmd36.ExecuteReader())
                            {
                                while (dr19.Read())
                                {
                                    stockid = Convert.ToInt32(dr19["stockid"]);
                                    stockname = Convert.ToString(dr19["stockname"]);
                                    stockweigth = Convert.ToInt32(dr19["stockweigth"]);
                                    stockcompany = Convert.ToString(dr19["stockcompany"]);
                                    stockcategory = Convert.ToString(dr19["stockcategory"]);
                                    stockdate = Convert.ToString(dr19["stockdate"]);
                                    stocktime = Convert.ToString(dr19["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }
                        }
                    }
                    // else if end

                    //else if 3
                    else if (Convert.ToString(Row.Cells[0].Value) == chickensandwich)
                    {
                        string gridname = Convert.ToString(Row.Cells[0].Value);
                        int quantity = Convert.ToInt32(Row.Cells[1].Value);
                        exist = true;
                        if (exist == true)
                        {
                            //MessageBox.Show("Found");
                            SqlCommand cmd = new SqlCommand("select * from Stock where stockname = 'salt' ", con, tran);
                            cmd.ExecuteNonQuery();

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    stockid = Convert.ToInt32(dr["stockid"]);
                                    stockname = Convert.ToString(dr["stockname"]);
                                    stockweigth = Convert.ToInt32(dr["stockweigth"]);
                                    stockcompany = Convert.ToString(dr["stockcompany"]);
                                    stockcategory = Convert.ToString(dr["stockcategory"]);
                                    stockdate = Convert.ToString(dr["stockdate"]);
                                    stocktime = Convert.ToString(dr["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd2 = new SqlCommand("select * from Stock where stockname = 'chicken' ", con, tran);
                            cmd2.ExecuteNonQuery();

                            using (SqlDataReader dr2 = cmd2.ExecuteReader())
                            {
                                while (dr2.Read())
                                {
                                    stockid = Convert.ToInt32(dr2["stockid"]);
                                    stockname = Convert.ToString(dr2["stockname"]);
                                    stockweigth = Convert.ToInt32(dr2["stockweigth"]);
                                    stockcompany = Convert.ToString(dr2["stockcompany"]);
                                    stockcategory = Convert.ToString(dr2["stockcategory"]);
                                    stockdate = Convert.ToString(dr2["stockdate"]);
                                    stocktime = Convert.ToString(dr2["stocktime"]);

                                    newstockweigth = stockweigth - 80 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd4 = new SqlCommand("select * from Stock where stockname = 'white cayenne pepper' ", con, tran);
                            cmd4.ExecuteNonQuery();

                            using (SqlDataReader dr3 = cmd4.ExecuteReader())
                            {
                                while (dr3.Read())
                                {
                                    stockid = Convert.ToInt32(dr3["stockid"]);
                                    stockname = Convert.ToString(dr3["stockname"]);
                                    stockweigth = Convert.ToInt32(dr3["stockweigth"]);
                                    stockcompany = Convert.ToString(dr3["stockcompany"]);
                                    stockcategory = Convert.ToString(dr3["stockcategory"]);
                                    stockdate = Convert.ToString(dr3["stockdate"]);
                                    stocktime = Convert.ToString(dr3["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd6 = new SqlCommand("select * from Stock where stockname = 'mastard powder' ", con, tran);
                            cmd6.ExecuteNonQuery();

                            using (SqlDataReader dr4 = cmd6.ExecuteReader())
                            {
                                while (dr4.Read())
                                {
                                    stockid = Convert.ToInt32(dr4["stockid"]);
                                    stockname = Convert.ToString(dr4["stockname"]);
                                    stockweigth = Convert.ToInt32(dr4["stockweigth"]);
                                    stockcompany = Convert.ToString(dr4["stockcompany"]);
                                    stockcategory = Convert.ToString(dr4["stockcategory"]);
                                    stockdate = Convert.ToString(dr4["stockdate"]);
                                    stocktime = Convert.ToString(dr4["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd8 = new SqlCommand("select * from Stock where stockname = 'meda' ", con, tran);
                            cmd8.ExecuteNonQuery();

                            using (SqlDataReader dr5 = cmd8.ExecuteReader())
                            {
                                while (dr5.Read())
                                {
                                    stockid = Convert.ToInt32(dr5["stockid"]);
                                    stockname = Convert.ToString(dr5["stockname"]);
                                    stockweigth = Convert.ToInt32(dr5["stockweigth"]);
                                    stockcompany = Convert.ToString(dr5["stockcompany"]);
                                    stockcategory = Convert.ToString(dr5["stockcategory"]);
                                    stockdate = Convert.ToString(dr5["stockdate"]);
                                    stocktime = Convert.ToString(dr5["stocktime"]);

                                    newstockweigth = stockweigth - 4 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {

                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                        else
                                        {

                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                }
                            }

                            SqlCommand cmd10 = new SqlCommand("select * from Stock where stockname = 'butter' ", con, tran);
                            cmd10.ExecuteNonQuery();

                            using (SqlDataReader dr6 = cmd10.ExecuteReader())
                            {
                                while (dr6.Read())
                                {
                                    stockid = Convert.ToInt32(dr6["stockid"]);
                                    stockname = Convert.ToString(dr6["stockname"]);
                                    stockweigth = Convert.ToInt32(dr6["stockweigth"]);
                                    stockcompany = Convert.ToString(dr6["stockcompany"]);
                                    stockcategory = Convert.ToString(dr6["stockcategory"]);
                                    stockdate = Convert.ToString(dr6["stockdate"]);
                                    stocktime = Convert.ToString(dr6["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd12 = new SqlCommand("select * from Stock where stockname = 'milk' ", con, tran);
                            cmd12.ExecuteNonQuery();

                            using (SqlDataReader dr7 = cmd12.ExecuteReader())
                            {
                                while (dr7.Read())
                                {
                                    stockid = Convert.ToInt32(dr7["stockid"]);
                                    stockname = Convert.ToString(dr7["stockname"]);
                                    stockweigth = Convert.ToInt32(dr7["stockweigth"]);
                                    stockcompany = Convert.ToString(dr7["stockcompany"]);
                                    stockcategory = Convert.ToString(dr7["stockcategory"]);
                                    stockdate = Convert.ToString(dr7["stockdate"]);
                                    stocktime = Convert.ToString(dr7["stocktime"]);

                                    newstockweigth = stockweigth - 250 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd14 = new SqlCommand("select * from Stock where stockname = 'bread slices' ", con, tran);
                            cmd14.ExecuteNonQuery();

                            using (SqlDataReader dr8 = cmd14.ExecuteReader())
                            {
                                while (dr8.Read())
                                {
                                    stockid = Convert.ToInt32(dr8["stockid"]);
                                    stockname = Convert.ToString(dr8["stockname"]);
                                    stockweigth = Convert.ToInt32(dr8["stockweigth"]);
                                    stockcompany = Convert.ToString(dr8["stockcompany"]);
                                    stockcategory = Convert.ToString(dr8["stockcategory"]);
                                    stockdate = Convert.ToString(dr8["stockdate"]);
                                    stocktime = Convert.ToString(dr8["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd16 = new SqlCommand("select * from Stock where stockname = 'ketchup' ", con, tran);
                            cmd16.ExecuteNonQuery();

                            using (SqlDataReader dr9 = cmd16.ExecuteReader())
                            {
                                while (dr9.Read())
                                {
                                    stockid = Convert.ToInt32(dr9["stockid"]);
                                    stockname = Convert.ToString(dr9["stockname"]);
                                    stockweigth = Convert.ToInt32(dr9["stockweigth"]);
                                    stockcompany = Convert.ToString(dr9["stockcompany"]);
                                    stockcategory = Convert.ToString(dr9["stockcategory"]);
                                    stockdate = Convert.ToString(dr9["stockdate"]);
                                    stocktime = Convert.ToString(dr9["stocktime"]);

                                    newstockweigth = stockweigth - 10 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd36 = new SqlCommand("select * from Stock where stockname = 'box' ", con, tran);
                            cmd36.ExecuteNonQuery();

                            using (SqlDataReader dr19 = cmd36.ExecuteReader())
                            {
                                while (dr19.Read())
                                {
                                    stockid = Convert.ToInt32(dr19["stockid"]);
                                    stockname = Convert.ToString(dr19["stockname"]);
                                    stockweigth = Convert.ToInt32(dr19["stockweigth"]);
                                    stockcompany = Convert.ToString(dr19["stockcompany"]);
                                    stockcategory = Convert.ToString(dr19["stockcategory"]);
                                    stockdate = Convert.ToString(dr19["stockdate"]);
                                    stocktime = Convert.ToString(dr19["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }
                        }
                    }
                    //else if end

                    //else if 3
                    else if (Convert.ToString(Row.Cells[0].Value) == bbqsandwich)
                    {
                        string gridname = Convert.ToString(Row.Cells[0].Value);
                        int quantity = Convert.ToInt32(Row.Cells[1].Value);
                        exist = true;
                        if (exist == true)
                        {
                            //MessageBox.Show("Found");
                            SqlCommand cmd = new SqlCommand("select * from Stock where stockname = 'onion' ", con, tran);
                            cmd.ExecuteNonQuery();

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    stockid = Convert.ToInt32(dr["stockid"]);
                                    stockname = Convert.ToString(dr["stockname"]);
                                    stockweigth = Convert.ToInt32(dr["stockweigth"]);
                                    stockcompany = Convert.ToString(dr["stockcompany"]);
                                    stockcategory = Convert.ToString(dr["stockcategory"]);
                                    stockdate = Convert.ToString(dr["stockdate"]);
                                    stocktime = Convert.ToString(dr["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 65 * quantity;

                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd2 = new SqlCommand("select * from Stock where stockname = 'vinegar' ", con, tran);
                            cmd2.ExecuteNonQuery();

                            using (SqlDataReader dr2 = cmd2.ExecuteReader())
                            {
                                while (dr2.Read())
                                {
                                    stockid = Convert.ToInt32(dr2["stockid"]);
                                    stockname = Convert.ToString(dr2["stockname"]);
                                    stockweigth = Convert.ToInt32(dr2["stockweigth"]);
                                    stockcompany = Convert.ToString(dr2["stockcompany"]);
                                    stockcategory = Convert.ToString(dr2["stockcategory"]);
                                    stockdate = Convert.ToString(dr2["stockdate"]);
                                    stocktime = Convert.ToString(dr2["stocktime"]);

                                    newstockweigth = stockweigth - 4 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd4 = new SqlCommand("select * from Stock where stockname = 'diced celery' ", con, tran);
                            cmd4.ExecuteNonQuery();

                            using (SqlDataReader dr3 = cmd4.ExecuteReader())
                            {
                                while (dr3.Read())
                                {
                                    stockid = Convert.ToInt32(dr3["stockid"]);
                                    stockname = Convert.ToString(dr3["stockname"]);
                                    stockweigth = Convert.ToInt32(dr3["stockweigth"]);
                                    stockcompany = Convert.ToString(dr3["stockcompany"]);
                                    stockcategory = Convert.ToString(dr3["stockcategory"]);
                                    stockdate = Convert.ToString(dr3["stockdate"]);
                                    stocktime = Convert.ToString(dr3["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd6 = new SqlCommand("select * from Stock where stockname = 'chili powder' ", con, tran);
                            cmd6.ExecuteNonQuery();

                            using (SqlDataReader dr4 = cmd6.ExecuteReader())
                            {
                                while (dr4.Read())
                                {
                                    stockid = Convert.ToInt32(dr4["stockid"]);
                                    stockname = Convert.ToString(dr4["stockname"]);
                                    stockweigth = Convert.ToInt32(dr4["stockweigth"]);
                                    stockcompany = Convert.ToString(dr4["stockcompany"]);
                                    stockcategory = Convert.ToString(dr4["stockcategory"]);
                                    stockdate = Convert.ToString(dr4["stockdate"]);
                                    stocktime = Convert.ToString(dr4["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd8 = new SqlCommand("select * from Stock where stockname = 'garlic clove' ", con, tran);
                            cmd8.ExecuteNonQuery();

                            using (SqlDataReader dr5 = cmd8.ExecuteReader())
                            {
                                while (dr5.Read())
                                {
                                    stockid = Convert.ToInt32(dr5["stockid"]);
                                    stockname = Convert.ToString(dr5["stockname"]);
                                    stockweigth = Convert.ToInt32(dr5["stockweigth"]);
                                    stockcompany = Convert.ToString(dr5["stockcompany"]);
                                    stockcategory = Convert.ToString(dr5["stockcategory"]);
                                    stockdate = Convert.ToString(dr5["stockdate"]);
                                    stocktime = Convert.ToString(dr5["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {

                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                        else
                                        {

                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                }
                            }

                            SqlCommand cmd10 = new SqlCommand("select * from Stock where stockname = 'butter' ", con, tran);
                            cmd10.ExecuteNonQuery();

                            using (SqlDataReader dr6 = cmd10.ExecuteReader())
                            {
                                while (dr6.Read())
                                {
                                    stockid = Convert.ToInt32(dr6["stockid"]);
                                    stockname = Convert.ToString(dr6["stockname"]);
                                    stockweigth = Convert.ToInt32(dr6["stockweigth"]);
                                    stockcompany = Convert.ToString(dr6["stockcompany"]);
                                    stockcategory = Convert.ToString(dr6["stockcategory"]);
                                    stockdate = Convert.ToString(dr6["stockdate"]);
                                    stocktime = Convert.ToString(dr6["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd12 = new SqlCommand("select * from Stock where stockname = 'salt' ", con, tran);
                            cmd12.ExecuteNonQuery();

                            using (SqlDataReader dr7 = cmd12.ExecuteReader())
                            {
                                while (dr7.Read())
                                {
                                    stockid = Convert.ToInt32(dr7["stockid"]);
                                    stockname = Convert.ToString(dr7["stockname"]);
                                    stockweigth = Convert.ToInt32(dr7["stockweigth"]);
                                    stockcompany = Convert.ToString(dr7["stockcompany"]);
                                    stockcategory = Convert.ToString(dr7["stockcategory"]);
                                    stockdate = Convert.ToString(dr7["stockdate"]);
                                    stocktime = Convert.ToString(dr7["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd14 = new SqlCommand("select * from Stock where stockname = 'ketchup' ", con, tran);
                            cmd14.ExecuteNonQuery();

                            using (SqlDataReader dr8 = cmd14.ExecuteReader())
                            {
                                while (dr8.Read())
                                {
                                    stockid = Convert.ToInt32(dr8["stockid"]);
                                    stockname = Convert.ToString(dr8["stockname"]);
                                    stockweigth = Convert.ToInt32(dr8["stockweigth"]);
                                    stockcompany = Convert.ToString(dr8["stockcompany"]);
                                    stockcategory = Convert.ToString(dr8["stockcategory"]);
                                    stockdate = Convert.ToString(dr8["stockdate"]);
                                    stocktime = Convert.ToString(dr8["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd16 = new SqlCommand("select * from Stock where stockname = 'bread slices' ", con, tran);
                            cmd16.ExecuteNonQuery();

                            using (SqlDataReader dr9 = cmd16.ExecuteReader())
                            {
                                while (dr9.Read())
                                {
                                    stockid = Convert.ToInt32(dr9["stockid"]);
                                    stockname = Convert.ToString(dr9["stockname"]);
                                    stockweigth = Convert.ToInt32(dr9["stockweigth"]);
                                    stockcompany = Convert.ToString(dr9["stockcompany"]);
                                    stockcategory = Convert.ToString(dr9["stockcategory"]);
                                    stockdate = Convert.ToString(dr9["stockdate"]);
                                    stocktime = Convert.ToString(dr9["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd18 = new SqlCommand("select * from Stock where stockname = 'brown sugar' ", con, tran);
                            cmd18.ExecuteNonQuery();

                            using (SqlDataReader dr10 = cmd18.ExecuteReader())
                            {
                                while (dr10.Read())
                                {
                                    stockid = Convert.ToInt32(dr10["stockid"]);
                                    stockname = Convert.ToString(dr10["stockname"]);
                                    stockweigth = Convert.ToInt32(dr10["stockweigth"]);
                                    stockcompany = Convert.ToString(dr10["stockcompany"]);
                                    stockcategory = Convert.ToString(dr10["stockcategory"]);
                                    stockdate = Convert.ToString(dr10["stockdate"]);
                                    stocktime = Convert.ToString(dr10["stocktime"]);

                                    newstockweigth = stockweigth - 4 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd19 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd19.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd19 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd19.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd20 = new SqlCommand("select * from Stock where stockname = 'pepper' ", con, tran);
                            cmd20.ExecuteNonQuery();

                            using (SqlDataReader dr11 = cmd20.ExecuteReader())
                            {
                                while (dr11.Read())
                                {
                                    stockid = Convert.ToInt32(dr11["stockid"]);
                                    stockname = Convert.ToString(dr11["stockname"]);
                                    double stockweigth2 = Convert.ToDouble(dr11["stockweigth"]);
                                    stockcompany = Convert.ToString(dr11["stockcompany"]);
                                    stockcategory = Convert.ToString(dr11["stockcategory"]);
                                    stockdate = Convert.ToString(dr11["stockdate"]);
                                    stocktime = Convert.ToString(dr11["stocktime"]);

                                    double newstockweigth2 = stockweigth2 - 1 * quantity;

                                    if (stockweigth2 > 0)
                                    {
                                        if (newstockweigth2 > 0)
                                        {
                                            SqlCommand cmd21 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth2 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd21.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd21 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd21.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd23 = new SqlCommand("select * from Stock where stockname = 'chicken' ", con, tran);
                            cmd23.ExecuteNonQuery();

                            using (SqlDataReader dr12 = cmd23.ExecuteReader())
                            {
                                while (dr12.Read())
                                {
                                    stockid = Convert.ToInt32(dr12["stockid"]);
                                    stockname = Convert.ToString(dr12["stockname"]);
                                    double stockweigth2 = Convert.ToDouble(dr12["stockweigth"]);
                                    stockcompany = Convert.ToString(dr12["stockcompany"]);
                                    stockcategory = Convert.ToString(dr12["stockcategory"]);
                                    stockdate = Convert.ToString(dr12["stockdate"]);
                                    stocktime = Convert.ToString(dr12["stocktime"]);

                                    double newstockweigth2 = stockweigth2 - 70 * quantity;

                                    if (stockweigth2 > 0)
                                    {
                                        if (newstockweigth2 > 0)
                                        {
                                            SqlCommand cmd24 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth2 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd24.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd24 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd24.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd25 = new SqlCommand("select * from Stock where stockname = 'salsa' ", con, tran);
                            cmd25.ExecuteNonQuery();

                            using (SqlDataReader dr13 = cmd25.ExecuteReader())
                            {
                                while (dr13.Read())
                                {
                                    stockid = Convert.ToInt32(dr13["stockid"]);
                                    stockname = Convert.ToString(dr13["stockname"]);
                                    double stockweigth2 = Convert.ToDouble(dr13["stockweigth"]);
                                    stockcompany = Convert.ToString(dr13["stockcompany"]);
                                    stockcategory = Convert.ToString(dr13["stockcategory"]);
                                    stockdate = Convert.ToString(dr13["stockdate"]);
                                    stocktime = Convert.ToString(dr13["stocktime"]);

                                    double newstockweigth2 = stockweigth2 - 40 * quantity;

                                    if (stockweigth2 > 0)
                                    {
                                        if (newstockweigth2 > 0)
                                        {
                                            SqlCommand cmd26 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth2 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd26.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd26 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd26.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd34 = new SqlCommand("select * from Stock where stockname = 'bun' ", con, tran);
                            cmd34.ExecuteNonQuery();

                            using (SqlDataReader dr18 = cmd34.ExecuteReader())
                            {
                                while (dr18.Read())
                                {
                                    stockid = Convert.ToInt32(dr18["stockid"]);
                                    stockname = Convert.ToString(dr18["stockname"]);
                                    stockweigth = Convert.ToInt32(dr18["stockweigth"]);
                                    stockcompany = Convert.ToString(dr18["stockcompany"]);
                                    stockcategory = Convert.ToString(dr18["stockcategory"]);
                                    stockdate = Convert.ToString(dr18["stockdate"]);
                                    stocktime = Convert.ToString(dr18["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd35 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd35.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd35 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd35.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }

                            SqlCommand cmd36 = new SqlCommand("select * from Stock where stockname = 'box' ", con, tran);
                            cmd36.ExecuteNonQuery();

                            using (SqlDataReader dr19 = cmd36.ExecuteReader())
                            {
                                while (dr19.Read())
                                {
                                    stockid = Convert.ToInt32(dr19["stockid"]);
                                    stockname = Convert.ToString(dr19["stockname"]);
                                    stockweigth = Convert.ToInt32(dr19["stockweigth"]);
                                    stockcompany = Convert.ToString(dr19["stockcompany"]);
                                    stockcategory = Convert.ToString(dr19["stockcategory"]);
                                    stockdate = Convert.ToString(dr19["stockdate"]);
                                    stocktime = Convert.ToString(dr19["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }
                        }
                    }
                    // else if end

                    //else if 3
                    else if (Convert.ToString(Row.Cells[0].Value) == chickensandwich)
                    {
                        string gridname = Convert.ToString(Row.Cells[0].Value);
                        int quantity = Convert.ToInt32(Row.Cells[1].Value);
                        exist = true;
                        if (exist == true)
                        {
                            //MessageBox.Show("Found");
                            SqlCommand cmd = new SqlCommand("select * from Stock where stockname = 'salt' ", con, tran);
                            cmd.ExecuteNonQuery();

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    stockid = Convert.ToInt32(dr["stockid"]);
                                    stockname = Convert.ToString(dr["stockname"]);
                                    stockweigth = Convert.ToInt32(dr["stockweigth"]);
                                    stockcompany = Convert.ToString(dr["stockcompany"]);
                                    stockcategory = Convert.ToString(dr["stockcategory"]);
                                    stockdate = Convert.ToString(dr["stockdate"]);
                                    stocktime = Convert.ToString(dr["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd1.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd2 = new SqlCommand("select * from Stock where stockname = 'chicken' ", con, tran);
                            cmd2.ExecuteNonQuery();

                            using (SqlDataReader dr2 = cmd2.ExecuteReader())
                            {
                                while (dr2.Read())
                                {
                                    stockid = Convert.ToInt32(dr2["stockid"]);
                                    stockname = Convert.ToString(dr2["stockname"]);
                                    stockweigth = Convert.ToInt32(dr2["stockweigth"]);
                                    stockcompany = Convert.ToString(dr2["stockcompany"]);
                                    stockcategory = Convert.ToString(dr2["stockcategory"]);
                                    stockdate = Convert.ToString(dr2["stockdate"]);
                                    stocktime = Convert.ToString(dr2["stocktime"]);

                                    newstockweigth = stockweigth - 80 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd3.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd4 = new SqlCommand("select * from Stock where stockname = 'white cayenne pepper' ", con, tran);
                            cmd4.ExecuteNonQuery();

                            using (SqlDataReader dr3 = cmd4.ExecuteReader())
                            {
                                while (dr3.Read())
                                {
                                    stockid = Convert.ToInt32(dr3["stockid"]);
                                    stockname = Convert.ToString(dr3["stockname"]);
                                    stockweigth = Convert.ToInt32(dr3["stockweigth"]);
                                    stockcompany = Convert.ToString(dr3["stockcompany"]);
                                    stockcategory = Convert.ToString(dr3["stockcategory"]);
                                    stockdate = Convert.ToString(dr3["stockdate"]);
                                    stocktime = Convert.ToString(dr3["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd5.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd6 = new SqlCommand("select * from Stock where stockname = 'mastard powder' ", con, tran);
                            cmd6.ExecuteNonQuery();

                            using (SqlDataReader dr4 = cmd6.ExecuteReader())
                            {
                                while (dr4.Read())
                                {
                                    stockid = Convert.ToInt32(dr4["stockid"]);
                                    stockname = Convert.ToString(dr4["stockname"]);
                                    stockweigth = Convert.ToInt32(dr4["stockweigth"]);
                                    stockcompany = Convert.ToString(dr4["stockcompany"]);
                                    stockcategory = Convert.ToString(dr4["stockcategory"]);
                                    stockdate = Convert.ToString(dr4["stockdate"]);
                                    stocktime = Convert.ToString(dr4["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd7.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd8 = new SqlCommand("select * from Stock where stockname = 'meda' ", con, tran);
                            cmd8.ExecuteNonQuery();

                            using (SqlDataReader dr5 = cmd8.ExecuteReader())
                            {
                                while (dr5.Read())
                                {
                                    stockid = Convert.ToInt32(dr5["stockid"]);
                                    stockname = Convert.ToString(dr5["stockname"]);
                                    stockweigth = Convert.ToInt32(dr5["stockweigth"]);
                                    stockcompany = Convert.ToString(dr5["stockcompany"]);
                                    stockcategory = Convert.ToString(dr5["stockcategory"]);
                                    stockdate = Convert.ToString(dr5["stockdate"]);
                                    stocktime = Convert.ToString(dr5["stocktime"]);

                                    newstockweigth = stockweigth - 4 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {

                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                        else
                                        {

                                            SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd9.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }

                                }
                            }

                            SqlCommand cmd10 = new SqlCommand("select * from Stock where stockname = 'butter' ", con, tran);
                            cmd10.ExecuteNonQuery();

                            using (SqlDataReader dr6 = cmd10.ExecuteReader())
                            {
                                while (dr6.Read())
                                {
                                    stockid = Convert.ToInt32(dr6["stockid"]);
                                    stockname = Convert.ToString(dr6["stockname"]);
                                    stockweigth = Convert.ToInt32(dr6["stockweigth"]);
                                    stockcompany = Convert.ToString(dr6["stockcompany"]);
                                    stockcategory = Convert.ToString(dr6["stockcategory"]);
                                    stockdate = Convert.ToString(dr6["stockdate"]);
                                    stocktime = Convert.ToString(dr6["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd11.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd12 = new SqlCommand("select * from Stock where stockname = 'milk' ", con, tran);
                            cmd12.ExecuteNonQuery();

                            using (SqlDataReader dr7 = cmd12.ExecuteReader())
                            {
                                while (dr7.Read())
                                {
                                    stockid = Convert.ToInt32(dr7["stockid"]);
                                    stockname = Convert.ToString(dr7["stockname"]);
                                    stockweigth = Convert.ToInt32(dr7["stockweigth"]);
                                    stockcompany = Convert.ToString(dr7["stockcompany"]);
                                    stockcategory = Convert.ToString(dr7["stockcategory"]);
                                    stockdate = Convert.ToString(dr7["stockdate"]);
                                    stocktime = Convert.ToString(dr7["stocktime"]);

                                    newstockweigth = stockweigth - 250 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd13.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd14 = new SqlCommand("select * from Stock where stockname = 'bread slices' ", con, tran);
                            cmd14.ExecuteNonQuery();

                            using (SqlDataReader dr8 = cmd14.ExecuteReader())
                            {
                                while (dr8.Read())
                                {
                                    stockid = Convert.ToInt32(dr8["stockid"]);
                                    stockname = Convert.ToString(dr8["stockname"]);
                                    stockweigth = Convert.ToInt32(dr8["stockweigth"]);
                                    stockcompany = Convert.ToString(dr8["stockcompany"]);
                                    stockcategory = Convert.ToString(dr8["stockcategory"]);
                                    stockdate = Convert.ToString(dr8["stockdate"]);
                                    stocktime = Convert.ToString(dr8["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd15.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd16 = new SqlCommand("select * from Stock where stockname = 'ketchup' ", con, tran);
                            cmd16.ExecuteNonQuery();

                            using (SqlDataReader dr9 = cmd16.ExecuteReader())
                            {
                                while (dr9.Read())
                                {
                                    stockid = Convert.ToInt32(dr9["stockid"]);
                                    stockname = Convert.ToString(dr9["stockname"]);
                                    stockweigth = Convert.ToInt32(dr9["stockweigth"]);
                                    stockcompany = Convert.ToString(dr9["stockcompany"]);
                                    stockcategory = Convert.ToString(dr9["stockcategory"]);
                                    stockdate = Convert.ToString(dr9["stockdate"]);
                                    stocktime = Convert.ToString(dr9["stocktime"]);

                                    newstockweigth = stockweigth - 10 * quantity;

                                    if (stockweigth > 0)
                                    {
                                        if (newstockweigth > 0)
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd17.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }


                                }
                            }

                            SqlCommand cmd36 = new SqlCommand("select * from Stock where stockname = 'box' ", con, tran);
                            cmd36.ExecuteNonQuery();

                            using (SqlDataReader dr19 = cmd36.ExecuteReader())
                            {
                                while (dr19.Read())
                                {
                                    stockid = Convert.ToInt32(dr19["stockid"]);
                                    stockname = Convert.ToString(dr19["stockname"]);
                                    stockweigth = Convert.ToInt32(dr19["stockweigth"]);
                                    stockcompany = Convert.ToString(dr19["stockcompany"]);
                                    stockcategory = Convert.ToString(dr19["stockcategory"]);
                                    stockdate = Convert.ToString(dr19["stockdate"]);
                                    stocktime = Convert.ToString(dr19["stocktime"]);

                                    if (stockweigth > 0)
                                    {
                                        newstockweigth = stockweigth - 1 * quantity;

                                        if (newstockweigth > -1)
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            SqlCommand cmd37 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + 0 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                            cmd37.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        //Do nothing
                                    }
                                }
                            }
                        }
                    }
                    //else if end

                    else
                    {
                        exist = false;
                    }
                }
            }
            tran.Commit();
            con.Close();
        }


    }

}