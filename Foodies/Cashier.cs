using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Foodies
{
    public partial class Cashier : Form
    {
        int quantity = 1,a,b,c;
        string productprice;
        int actualprice;
        int totalAmount = 0; int totalQuantity = 0;
        int INVOICEID; /* For Invoice Reading through Sql reader*/

        // Connection String //
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");

        public System.Windows.Forms.DataGridViewImageCellLayout ImageLayout { get; set; }

        public Cashier()
        {
            InitializeComponent();
            dgv_1();
            dgv_2();
            dgv_3();
        }

        public void dgv_1()
        {
            dgv1.RowTemplate.Height = 200;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(10, 8, 0, 8);
            this.dgv1.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14F, FontStyle.Bold);
            dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //This Part of Code is for the styling of the Visaul Style
            //dgv1.EnableHeadersVisualStyles = false;

            // This Part of Code is for the styling of the Grid Border
            this.dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //this line of code is applying padding to a specific Column of dgv1 which is Product Column
            //dgv2.Columns[4].DefaultCellStyle.Padding = new Padding(3, 3, 3, 3);
        }

        public void dgv_2()
        {
            dgv2.RowTemplate.Height = 200;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(10, 8, 0, 8);
            this.dgv2.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14F, FontStyle.Bold);
            dgv2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //This Part of Code is for the styling of the Visaul Style
            //dgv1.EnableHeadersVisualStyles = false;

            // This Part of Code is for the styling of the Grid Border
            this.dgv2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv2.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //this line of code is applying padding to a specific Column of dgv1 which is Product Column
            //dgv2.Columns[4].DefaultCellStyle.Padding = new Padding(3, 3, 3, 3);

        }

        public void dgv_3()
        {
            dgv3.RowTemplate.Height = 32;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(0, 10, 0, 10);
            this.dgv3.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv3.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);
            dgv3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //This Part of Code is for the styling of the Visaul Style
            //dgv1.EnableHeadersVisualStyles = false;

            // This Part of Code is for the styling of the Grid Border
            this.dgv3.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv3.RowsDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv3.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //this line of code is applying padding to a specific Column of dgv1 which is Product Column
            //dgv2.Columns[4].DefaultCellStyle.Padding = new Padding(3, 3, 3, 3);

        }


        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button1_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Cashier_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'categoryDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.categoryDataSet.Category);
            // TODO: This line of code loads data into the 'itemsDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.itemsDataSet.Products);
            // TODO: This line of code loads data into the 'itemsDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.itemsDataSet.Products);
            // TODO: This line of code loads data into the 'categoryDataSet.Products' table. You can move, or remove it, as needed.
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void inventoryManagementSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.Show();
        }

        private void searchInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceDetails invoiceDetails = new InvoiceDetails();
            invoiceDetails.Show();
        }

        private void manageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageSubProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemsEntry itemsEntry = new ItemsEntry();
            itemsEntry.Show();
        }

        private void tableLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void stockManagementSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            totalAmount = 0; totalQuantity = 0;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv2.Rows[e.RowIndex];
                string productname = row.Cells[1].Value.ToString();
                productprice = row.Cells[2].Value.ToString();
                string productcategory = row.Cells[3].Value.ToString();
                actualprice = Convert.ToInt32(row.Cells[2].Value.ToString());

                try
                {
                    bool Found = false;
                    dgv3.AllowUserToAddRows = true;

                    if (dgv3.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow Row in dgv3.Rows)
                        {
                            if (Convert.ToString(Row.Cells[0].Value) == productname)
                            { 
                                Found = true;
                                dgv3.AllowUserToAddRows = false;
                            }
                                dgv3.AllowUserToAddRows = false;
                        }
                        if (!Found)
                        {
                                a = Convert.ToInt32(quantity);
                                b = Convert.ToInt32(productprice);
                                c = a * b;

                                dgv3.Rows.Add(productname, a,b, c, productcategory, 1);
                                    for (int i = 0; i < dgv3.Rows.Count; ++i)
                                    {
                                        totalQuantity += Convert.ToInt32(dgv3.Rows[i].Cells[1].Value);
                                        totalAmount += Convert.ToInt32(dgv3.Rows[i].Cells[3].Value);
                                    }
                                totalQty.Text = totalQuantity.ToString();
                                total_Amount.Text = totalAmount.ToString();
                                act_price.Text = totalAmount.ToString();
                        } 
                    }
                }
                catch (Exception)
                {

                }
                
            }


        }

        private void dgv2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv1.Rows[e.RowIndex];
                string maincategory = row.Cells[1].Value.ToString();

                if (maincategory == "pizza")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
                    con.Open();
                    string query = "select * from Products where ProductCategory = 'pizza' ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dgv2.DataSource = dt;
                    con.Close();
                }
                else if (maincategory == "burger")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
                    con.Open();
                    string query = "select * from Products where ProductCategory = 'burger' ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dgv2.DataSource = dt;
                    con.Close();
                }
                else if (maincategory == "Broast")
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
                    con.Open();
                    string query = "select * from Products where ProductCategory = 'Broast' ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dgv2.DataSource = dt;
                    con.Close();
                }
            }

            this.dgv2.Columns[0].Visible = false;
            this.dgv2.Columns[1].Visible = false;
            this.dgv2.Columns[2].Visible = false;
            this.dgv2.Columns[3].Visible = false;

            for (int i = 0; i < dgv2.Columns.Count; i++)
                if (dgv2.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgv2.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }

        }

        private void createProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubProductManagement_System category = new SubProductManagement_System();
            category.Show();
        }

        private void dgv3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                totalAmount = 0; totalQuantity = 0;
                totalQty.Text = totalQuantity.ToString();
                total_Amount.Text = totalAmount.ToString();

                var row = dgv3.CurrentRow;

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


                for (int i = 0; i < dgv3.Rows.Count; ++i)
                {
                    totalQuantity += Convert.ToInt32(dgv3.Rows[i].Cells[1].Value);
                    totalAmount += Convert.ToInt32(dgv3.Rows[i].Cells[3].Value);
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

                var row = dgv3.CurrentRow;

                if (row == null || row.Index < 0)
                    return;
                var unit = 1;
                var quantity = Convert.ToInt32(row.Cells["qtty"].Value) - unit;
                //assuming you have rate column...
                var rate = Convert.ToInt32(row.Cells["rate"].Value);

                if(quantity < 1 )
                {
                    this.dgv3.Rows.RemoveAt(e.RowIndex);

                    for (int i = 0; i < dgv3.Rows.Count; ++i)
                    {
                        totalQuantity += Convert.ToInt32(dgv3.Rows[i].Cells[1].Value);
                        totalAmount += Convert.ToInt32(dgv3.Rows[i].Cells[3].Value);
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

                    for (int i = 0; i < dgv3.Rows.Count; ++i)
                    {
                        totalAmount = 0; totalQuantity = 0;
                        totalQuantity += Convert.ToInt32(dgv3.Rows[i].Cells[1].Value);
                        totalAmount += Convert.ToInt32(dgv3.Rows[i].Cells[3].Value);
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
          
            else if (dgv3.CurrentCell.ColumnIndex == 7)
            {
                this.dgv3.Rows.RemoveAt(e.RowIndex);

                totalAmount = 0; totalQuantity = 0;
                totalQty.Text = totalQuantity.ToString();
                total_Amount.Text = totalAmount.ToString();

                for (int i = 0; i < dgv3.Rows.Count; ++i)
                {
                    totalQuantity += Convert.ToInt32(dgv3.Rows[i].Cells[1].Value);
                    totalAmount += Convert.ToInt32(dgv3.Rows[i].Cells[3].Value);
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

        private void dgv3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void total_Amount_Click(object sender, EventArgs e)
        {

        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
           if(DiscountPKR.Text != "")
            {
                
            }
            else
            {
              
            }
        }

        private void DiscountPercent_TextChanged(object sender, EventArgs e)
        {

        }

        private void DiscountPKR_TextChanged(object sender, EventArgs e)
        {

        }

        private void per_discount_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgv3.Rows.Clear();
            dgv3.Refresh();
            dgv2.DataSource = null;
            DiscountPKR.Text = "";
            DiscountPercent.Text = "";
            per_discount.Text = "0";
            act_price.Text = "0";
            totalQty.Text = "0";
            total_Amount.Text = "0";
        }

        private void dgv3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv3_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgv3_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgv3_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from users", con);
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

                                //
                                SqlCommand cmd7 = new SqlCommand("insert into Sales values ('" + ORDERID + "','" + CUSTID + "','" + CUSTNAME + "','" + CUSTCONTACT + "','" + OrderType + "','" + OrderCategory + "','" + ORDERTIME + "','" + ORDERDATE + "')", con, tran);
                                cmd7.ExecuteNonQuery();

                                SqlCommand cmd6;
                                for (int i = 0; i < dgv3.Rows.Count; i++)
                                {
                                    itemname = Convert.ToString(dgv3.Rows[i].Cells[0].Value);
                                    itemqty = Convert.ToString(dgv3.Rows[i].Cells[1].Value);
                                    itemprice = Convert.ToString(dgv3.Rows[i].Cells[2].Value);
                                    singleitemcollectiveamount = Convert.ToDouble(dgv3.Rows[i].Cells[3].Value);
                                    GST = Convert.ToInt32(dgv3.Rows[i].Cells[3].Value) * GStunit;
                                    itempricewithGST = Convert.ToDouble(dgv3.Rows[i].Cells[2].Value) + GST;
                                    cmd6 = new SqlCommand("insert into Bill values ('" + INVOICEID + "','" + CUSTID + "','" + ORDERID + "','" + CUSTNAME + "','" + itemname.ToString() + "','" + itemqty.ToString() + "','" + itemprice.ToString() + "','" + singleitemcollectiveamount.ToString() + "','" + itempricewithGST.ToString() + "','" + ORDERTIME + "','" + ORDERDATE + "','" + totalqty.ToString() + "','" + act_price.Text.ToString() + "','" + billtotal.ToString() + "','" + totalAmountwithGST.ToString() + "','" + discount.ToString() + "')", con, tran);
                                    cmd6.ExecuteNonQuery();
                                }
                                MessageBox.Show("Operation Successfull");
                            }
                        }
                    }
                    tran.Commit();
                    con.Close();
                }

            }
            else
            {
                //
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

                                //
                                SqlCommand cmd7 = new SqlCommand("insert into Sales values ('" + ORDERID + "','" + CUSTID + "','" + CUSTNAME + "','" + CUSTCONTACT + "','" + OrderType + "','" + OrderCategory + "','" + ORDERTIME + "','" + ORDERDATE + "')", con, tran);
                                cmd7.ExecuteNonQuery();

                                SqlCommand cmd6;
                                for (int i = 0; i < dgv3.Rows.Count; i++)
                                {
                                    itemname = Convert.ToString(dgv3.Rows[i].Cells[0].Value);
                                    itemqty = Convert.ToString(dgv3.Rows[i].Cells[1].Value);
                                    itemprice = Convert.ToString(dgv3.Rows[i].Cells[2].Value);
                                    singleitemcollectiveamount = Convert.ToDouble(dgv3.Rows[i].Cells[3].Value);
                                    GST = Convert.ToInt32(dgv3.Rows[i].Cells[3].Value) * GStunit;
                                    itempricewithGST = Convert.ToDouble(dgv3.Rows[i].Cells[2].Value) + GST;
                                    cmd6 = new SqlCommand("insert into Bill values ('" + InvocieId + "','" + CUSTID + "','" + ORDERID + "','" + CUSTNAME + "','" + itemname.ToString() + "','" + itemqty.ToString() + "','" + itemprice.ToString() + "','" + singleitemcollectiveamount.ToString() + "','" + itempricewithGST.ToString() + "','" + ORDERTIME + "','" + ORDERDATE + "','" + totalqty.ToString() + "','" + act_price.Text.ToString() + "','" + billtotal.ToString() + "','" + totalAmountwithGST.ToString() + "','" + discount.ToString() + "')", con, tran);
                                    cmd6.ExecuteNonQuery();
                                }
                                MessageBox.Show("Operation Successfull");
                            }
                        }
                    }
                    tran.Commit();
                    con.Close();
                }
                //
            }

            //
            try
            {
                
            }
            catch (Exception)
            {
                MessageBox.Show("Transaction Failed for Unknown Reason");
            }
           
        }

        private void totalInvoiceDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelInvioce cancelInvioce = new CancelInvioce();
            cancelInvioce.Show();
        }

        private void deletedInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletedInvoice deletedInvoice = new DeletedInvoice();
            deletedInvoice.Show();
        }

        private void Cashier_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void manageItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageItems manageItems = new ManageItems();
            manageItems.Show();
        }

        private void couponToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void dgv3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
