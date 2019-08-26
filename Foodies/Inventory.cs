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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
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

        //public void dgv_1()
        //{
        //    dgv1.RowTemplate.Height = 180;

        //    //This Part of Code is for the styling of the Grid Padding
        //    Padding newPadding = new Padding(0, 10, 0, 10);
        //    this.dgv1.ColumnHeadersDefaultCellStyle.Padding = newPadding;

        //    //This Part of Code is for the styling of the Grid Columns
        //    dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
        //    dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    //This Part of Code is for the styling of the Visaul Style
        //    //dgv1.EnableHeadersVisualStyles = false;

        //    // This Part of Code is for the styling of the Grid Border
        //    this.dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        //    this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

        //    //This Part of Code is for the styling of the Grid Rows
        //    dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);

        //    //this Line of Code made the dgv1 Text Middle Center
        //    dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    //this line of code is applying padding to a specific Column of dgv1 which is Product Column
        //    //dgv2.Columns[4].DefaultCellStyle.Padding = new Padding(3, 3, 3, 3);

        //}

        //public void dgv_2()
        //{
        //    dgv2_Product.RowTemplate.Height = 180;

        //    //This Part of Code is for the styling of the Grid Padding
        //    Padding newPadding = new Padding(0, 10, 0, 10);
        //    this.dgv2_Product.ColumnHeadersDefaultCellStyle.Padding = newPadding;

        //    //This Part of Code is for the styling of the Grid Columns
        //    dgv2_Product.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
        //    dgv2_Product.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    //This Part of Code is for the styling of the Visaul Style
        //    //dgv1.EnableHeadersVisualStyles = false;

        //    // This Part of Code is for the styling of the Grid Border
        //    this.dgv2_Product.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        //    this.dgv2_Product.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

        //    //This Part of Code is for the styling of the Grid Rows
        //    dgv2_Product.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);

        //    //this Line of Code made the dgv1 Text Middle Center
        //    dgv2_Product.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    //this line of code is applying padding to a specific Column of dgv1 which is Product Column
        //    //dgv2.Columns[4].DefaultCellStyle.Padding = new Padding(3, 3, 3, 3);

        //}

        private void Inventory_Load(object sender, EventArgs e)
        {

        }

        private void label_Product_Click(object sender, EventArgs e)
        {
           
        }

        private void label_Category_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label_Dashboard_Click(object sender, EventArgs e)
        {
            hidePanels();
            DashboardPanel.Visible = true;
        }

        public void hidePanels()
        {
            DashboardPanel.Visible = false;
            StockPanel.Visible = false;
            ProductPanel.Visible = false;
            CategoryPanel.Visible = false;
            ReportPanel.Visible = false;
        }

        private void label_Stock_Click(object sender, EventArgs e)
        {
          
        }

        private void label_Report_Click(object sender, EventArgs e)
        {
            
        }
    }
}