﻿using System;
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
    public partial class Inventory : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
        int TotalSales; DateTime date;

        public Inventory()
        {
            InitializeComponent();
            InventoryHeaderInfo();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label_Dashboard.BackColor = Color.RoyalBlue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label_Dashboard.BackColor = Color.White;
            label_Dashboard.ForeColor = Color.Black;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label_Dashboard.BackColor = Color.RoyalBlue;
            label_Dashboard.ForeColor = Color.White;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label_Stock.BackColor = Color.RoyalBlue;
            label_Stock.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label_Stock.BackColor = Color.White;
            label_Stock.ForeColor = Color.Black;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label_Product.BackColor = Color.RoyalBlue;
            label_Product.ForeColor = Color.White;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label_Product.BackColor = Color.White;
            label_Product.ForeColor = Color.Black;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label_Category.BackColor = Color.RoyalBlue;
            label_Category.ForeColor = Color.White;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label_Category.BackColor = Color.White;
            label_Category.ForeColor = Color.Black;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label_Report.BackColor = Color.RoyalBlue;
            label_Report.ForeColor = Color.White;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label_Report.BackColor = Color.White;
            label_Report.ForeColor = Color.Black;
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        public void dgv_2()
        {
            dgv2.RowTemplate.Height = 42;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(0, 10, 0, 10);
            this.dgv2.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);
            dgv2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // This Part of Code is for the styling of the Grid Border
            this.dgv2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv2.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void dgv_3()
        {
            dgv3.RowTemplate.Height = 42;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(0, 10, 0, 10);
            this.dgv3.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv3.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);
            dgv3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // This Part of Code is for the styling of the Grid Border
            this.dgv3.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv3.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv3.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void dgv_4()
        {
            dgv4.RowTemplate.Height = 42;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(0, 10, 0, 10);
            this.dgv4.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv4.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);
            dgv4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // This Part of Code is for the styling of the Grid Border
            this.dgv4.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv4.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv4.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv4.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stockDataSet.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.stockDataSet.Stock);
            // TODO: This line of code loads data into the 'productsDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.productsDataSet.Products);
            // TODO: This line of code loads data into the 'categoryDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.categoryDataSet.Category);
            LoadChart2();
            LoadChart3();
            LoadChart4();
            LoadChart5();
            dgv_2();
            dgv_3();
            dgv_4();
            FoucsTextBoxes();
        }

        public void InventoryHeaderInfo()
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Category", con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                string query = "select * from Category";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv1.DataSource = dt;
                categorytotal.Text = dgv1.Rows.Count.ToString();
                categorytotal2.Text = dgv1.Rows.Count.ToString();
                dgv1.Refresh();
                dgv1.DataSource = null;
            }
            else
            {
                categorytotal.Text = "0";
                categorytotal2.Text = "0";
            }


            SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT * from Products", con);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            if (table2.Rows.Count > 0)
            {
                string query = "select * from Products";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv1.DataSource = dt;
                fastfoodtotal.Text = dgv1.Rows.Count.ToString();
                fastfoodtotal2.Text = dgv1.Rows.Count.ToString();
                dgv1.Refresh();
                dgv1.DataSource = null;
            }
            else
            {
                fastfoodtotal.Text = "0";
                fastfoodtotal2.Text = "0";
            }

            SqlDataAdapter adapter3 = new SqlDataAdapter("SELECT * from Bill", con);
            DataTable table3 = new DataTable();
            adapter3.Fill(table3);
            if (table3.Rows.Count > 0)
            {
                string query = "select * from Bill";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv1.DataSource = dt;

                for (int i = 0; i < dgv1.Rows.Count; ++i)
                {
                    TotalSales += Convert.ToInt32(dgv1.Rows[i].Cells[7].Value);
                }

                total_sales.Text = TotalSales.ToString();
                totalInvoices.Text = dgv1.Rows.Count.ToString();
                dgv1.Refresh();
                dgv1.DataSource = null;
            }
            else
            {
                total_sales.Text = "0";
                totalInvoices.Text = "0";
            }

            SqlDataAdapter adapter4 = new SqlDataAdapter("SELECT * from Stock", con);
            DataTable table4 = new DataTable();
            adapter4.Fill(table4);
            if (table4.Rows.Count > 0)
            {
                string query = "select * from Stock";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv1.DataSource = dt;
                StockTotal.Text = dgv1.Rows.Count.ToString();
                dgv1.Refresh();
                dgv1.DataSource = null;
            }
            else
            {
                StockTotal.Text = "0";
            }

            SqlDataAdapter adapter5 = new SqlDataAdapter("SELECT * from Sales", con);
            DataTable table5 = new DataTable();
            adapter5.Fill(table5);
            if (table5.Rows.Count > 0)
            {
                string query = "select * from Sales";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv1.DataSource = dt;
                totalSales2.Text = dgv1.Rows.Count.ToString();
                dgv1.Refresh();
                dgv1.DataSource = null;
            }
            else
            {
                totalSales2.Text = "0";
            }

            SqlDataAdapter adapter6 = new SqlDataAdapter("SELECT * from Orders", con);
            DataTable table6 = new DataTable();
            adapter6.Fill(table6);
            if (table6.Rows.Count > 0)
            {
                string query = "select * from Orders";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv1.DataSource = dt;
                totalOrders.Text = dgv1.Rows.Count.ToString();
                dgv1.Refresh();
                dgv1.DataSource = null;
            }
            else
            {
                totalOrders.Text = "0";
            }

            SqlDataAdapter adapter7 = new SqlDataAdapter("SELECT * from users", con);
            DataTable table7 = new DataTable();
            adapter7.Fill(table7);
            if (table7.Rows.Count > 0)
            {
                string query = "select * from users";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv1.DataSource = dt;
                totalAppUsers.Text = dgv1.Rows.Count.ToString();
                dgv1.Refresh();
                dgv1.DataSource = null;
            }
            else
            {
                totalAppUsers.Text = "0";
            }

            SqlDataAdapter adapter8 = new SqlDataAdapter("SELECT * from Customer", con);
            DataTable table8 = new DataTable();
            adapter8.Fill(table8);
            if (table8.Rows.Count > 0)
            {
                string query = "select * from Customer";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv1.DataSource = dt;
                totalCustomers.Text = dgv1.Rows.Count.ToString();
                dgv1.Refresh();
                dgv1.DataSource = null;
            }
            else
            {
                totalCustomers.Text = "0";
            }

            SqlDataAdapter adapter9 = new SqlDataAdapter("SELECT * from DeletedBill", con);
            DataTable table9 = new DataTable();
            adapter9.Fill(table9);
            if (table9.Rows.Count > 0)
            {
                string query = "select * from DeletedBill";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv1.DataSource = dt;
                totalDeletedInvoices.Text = dgv1.Rows.Count.ToString();
                dgv1.Refresh();
                dgv1.DataSource = null;
            }
            else
            {
                totalDeletedInvoices.Text = "0";
            }

        }

        public void FoucsTextBoxes()
        {
            txtSearchCategory.Focus();
            txtSearchProduct.Focus();
            txtSearchStock.Focus();
        }

        private void label_Product_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void label_Category_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label_Dashboard_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void label_Stock_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void label_Report_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void SearchProduct_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
                con.Open();
                string query = "select * from Products where ProductName = '" + txtSearchProduct.Text.ToLower() + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv3.DataSource = dt;
                con.Close();
                txtSearchProduct.Text = string.Empty;
                txtSearchProduct.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter product name to search");
            }
        }

        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
                con.Open();
                string query = "select * from Category where CategoryName = '" + txtSearchCategory.Text.ToLower() + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv4.DataSource = dt;
                con.Close();
                txtSearchCategory.Text = string.Empty;
                txtSearchCategory.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter category to search");
            }
        }

        private void dgv3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv3.Rows[e.RowIndex];

                txtSearchProduct.Text = row.Cells[1].Value.ToString();
            }
        }

        private void dgv4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv4.Rows[e.RowIndex];

                txtSearchCategory.Text = row.Cells[1].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv4.Refresh();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
            con.Open();
            string query = "select * from Category";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv4.DataSource = dt;
            con.Close();
            txtSearchCategory.Text = string.Empty;
            txtSearchCategory.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv3.Refresh();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
            con.Open();
            string query = "select * from Products";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv3.DataSource = dt;
            con.Close();
            txtSearchProduct.Text = string.Empty;
            txtSearchProduct.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgv2.Refresh();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
            con.Open();
            string query = "select * from Stock";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv2.DataSource = dt;
            con.Close();
            txtSearchStock.Text = string.Empty;
            txtSearchStock.Focus();
        }

        private void btnSearchStock_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
                con.Open();
                string query = "select * from Stock where stockname = '" + txtSearchStock.Text.ToLower() + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv2.DataSource = dt;
                con.Close();
                txtSearchStock.Text = string.Empty;
                txtSearchStock.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter stock name to search");
            }
        }

        private void dgv3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv3.Rows[e.RowIndex];

                txtSearchProduct.Text = row.Cells[1].Value.ToString();
            }
        }

        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv2.Rows[e.RowIndex];

                txtSearchStock.Text = row.Cells[1].Value.ToString();
            }
        }

        public void LoadChart2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");

            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;

            cmd = new SqlCommand("Select * from Bill where OrderDate = '" + DateTime.Now.Date + "' ", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            chart2.DataSource = source;
            chart2.Series[0].XValueMember = "InvioceID";
            chart2.Series[0].YValueMembers = "TotalQty";
            chart2.Series[1].XValueMember = "InvioceID";
            chart2.Series[1].YValueMembers = "TotalAmount";
            this.chart2.Titles.Add("TOTAL SALE PER CUSTOMER DATA");
            chart2.DataBind();
        }

        public void LoadChart4()
        {
            var firstdayofweek = DateTime.Now.AddDays(-6);
            var currentdate = DateTime.Now.Date;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");

            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;

            cmd = new SqlCommand("Select * from Bill where OrderDate between '" + firstdayofweek + "' and '" + currentdate + "' ", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            chart4.DataSource = source;
            chart4.Series[0].XValueMember = "InvioceID";
            chart4.Series[0].YValueMembers = "TotalQty";
            chart4.Series[1].XValueMember = "InvioceID";
            chart4.Series[1].YValueMembers = "TotalAmount";
            this.chart4.Titles.Add("TOTAL SALE PER CUSTOMER DATA");
            chart4.DataBind();
        }

        public void LoadChart3()
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var firstdayofmonth = DateTime.Now.AddDays(-29);
            var currentdate = DateTime.Now.Date;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");

            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;

            cmd = new SqlCommand("Select * from Bill where OrderDate between '" + firstdayofmonth + "' and '" + currentdate + "' ", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            chart3.DataSource = source;
            chart3.Series[0].XValueMember = "InvioceID";
            chart3.Series[0].YValueMembers = "TotalQty";
            chart3.Series[1].XValueMember = "InvioceID";
            chart3.Series[1].YValueMembers = "TotalAmount";
            this.chart3.Titles.Add("TOTAL SALE PER CUSTOMER DATA");
            chart3.DataBind();
        }

        public void LoadChart5()
        {
            var firstdayofyear = DateTime.Now.Year;
            var currentdate = DateTime.Now.Date;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");

            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;

            cmd = new SqlCommand("Select * from Bill where OrderDate between '" + firstdayofyear + "' and '" + currentdate + "' ", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            chart5.DataSource = source;
            chart5.Series[0].XValueMember = "InvioceID";
            chart5.Series[0].YValueMembers = "TotalQty";
            chart5.Series[1].XValueMember = "InvioceID";
            chart5.Series[1].YValueMembers = "TotalAmount";
            this.chart5.Titles.Add("TOTAL SALE PER CUSTOMER DATA");
            chart5.DataBind();
        }

    }
}