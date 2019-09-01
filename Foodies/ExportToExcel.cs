using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodies
{
    public partial class ExportToExcel : Form
    {
        public ExportToExcel()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void BillRecord_MouseEnter(object sender, EventArgs e)
        {
            BillRecord.BackColor = Color.Black;
        }

        private void BillRecord_MouseLeave(object sender, EventArgs e)
        {
            BillRecord.BackColor = Color.Transparent;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            BillRecord.BackColor = Color.Black;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            BillRecord.BackColor = Color.Transparent;
        }

        private void label_BillRecord_MouseEnter(object sender, EventArgs e)
        {
            BillRecord.BackColor = Color.Black;
        }

        private void label_BillRecord_MouseLeave(object sender, EventArgs e)
        {
            BillRecord.BackColor = Color.Transparent;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            Category.BackColor = Color.Black;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            Category.BackColor = Color.Transparent;
        }

        private void Category_MouseEnter(object sender, EventArgs e)
        {
            Category.BackColor = Color.Black;
        }

        private void Category_MouseLeave(object sender, EventArgs e)
        {
            Category.BackColor = Color.Transparent;
        }

        private void label_Category_MouseEnter(object sender, EventArgs e)
        {
            Category.BackColor = Color.Black;
        }

        private void label_Category_MouseLeave(object sender, EventArgs e)
        {
            Category.BackColor = Color.Transparent;
        }

        private void Customer_MouseEnter(object sender, EventArgs e)
        {
            Customer.BackColor = Color.Black;
        }

        private void Customer_MouseLeave(object sender, EventArgs e)
        {
            Customer.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            Customer.BackColor = Color.Black;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            Customer.BackColor = Color.Transparent;
        }

        private void label_Customers_MouseEnter(object sender, EventArgs e)
        {
            Customer.BackColor = Color.Black;
        }

        private void label_Customers_MouseLeave(object sender, EventArgs e)
        {
            Customer.BackColor = Color.Transparent;
        }

        private void Orders_MouseEnter(object sender, EventArgs e)
        {
            Orders.BackColor = Color.Black;
        }

        private void Orders_MouseLeave(object sender, EventArgs e)
        {
            Orders.BackColor = Color.Transparent;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            Orders.BackColor = Color.Black;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            Orders.BackColor = Color.Transparent;
        }

        private void label_Orders_MouseEnter(object sender, EventArgs e)
        {
            Orders.BackColor = Color.Black;
        }

        private void label_Orders_MouseLeave(object sender, EventArgs e)
        {
            Orders.BackColor = Color.Transparent;
        }

        private void Products_MouseEnter(object sender, EventArgs e)
        {
            Products.BackColor = Color.Black;
        }

        private void Products_MouseLeave(object sender, EventArgs e)
        {
            Products.BackColor = Color.Transparent;
        }

        private void label_Products_MouseEnter(object sender, EventArgs e)
        {
            Products.BackColor = Color.Black;
        }

        private void label_Products_MouseLeave(object sender, EventArgs e)
        {
            Products.BackColor = Color.Transparent;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            Products.BackColor = Color.Black;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            Products.BackColor = Color.Transparent;
        }

        private void Sales_MouseEnter(object sender, EventArgs e)
        {
            Sales.BackColor = Color.Black;
        }

        private void Sales_MouseLeave(object sender, EventArgs e)
        {
            Sales.BackColor = Color.Transparent;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            Sales.BackColor = Color.Black;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            Sales.BackColor = Color.Transparent;
        }

        private void label_Sales_MouseEnter(object sender, EventArgs e)
        {
            Sales.BackColor = Color.Black;
        }

        private void label_Sales_MouseLeave(object sender, EventArgs e)
        {
            Sales.BackColor = Color.Transparent;
        }

        private void Stocks_MouseEnter(object sender, EventArgs e)
        {
            Stocks.BackColor = Color.Black;
        }

        private void Stocks_MouseLeave(object sender, EventArgs e)
        {
            Stocks.BackColor = Color.Transparent;
        }

        private void label_Stocks_MouseEnter(object sender, EventArgs e)
        {
            Stocks.BackColor = Color.Black;
        }

        private void label_Stocks_MouseLeave(object sender, EventArgs e)
        {
            Stocks.BackColor = Color.Transparent;
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            Stocks.BackColor = Color.Black;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            Stocks.BackColor = Color.Transparent;
        }

        private void BillRecord_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void BillRecord_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void label_BillRecord_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void Category_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void label_Category_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void label_Customers_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void Orders_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Orders_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void label_Orders_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void Products_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void label_Products_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }

        private void label_Sales_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }

        private void Sales_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }

        private void Stocks_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }

        private void label_Stocks_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }

        private void ExportToExcel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stocksDataSet.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.stocksDataSet.Stock);
            // TODO: This line of code loads data into the 'salesDataSet.Sales' table. You can move, or remove it, as needed.
            this.salesTableAdapter.Fill(this.salesDataSet.Sales);
            // TODO: This line of code loads data into the 'productsDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.productsDataSet.Products);
            // TODO: This line of code loads data into the 'orderDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.orderDataSet.Orders);
            // TODO: This line of code loads data into the 'cutomerDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.cutomerDataSet.Customer);
            // TODO: This line of code loads data into the 'categoryDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.categoryDataSet.Category);
            // TODO: This line of code loads data into the 'invoiceDataSet.Bill' table. You can move, or remove it, as needed.
            this.billTableAdapter.Fill(this.invoiceDataSet.Bill);

        }
    }
}