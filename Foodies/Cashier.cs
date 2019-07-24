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
    public partial class Cashier : Form
    {
        public Cashier()
        {
            InitializeComponent();
            dgv_1();
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
            //dgv1.Columns[2].DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);

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
            // TODO: This line of code loads data into the 'categoryDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.categoryDataSet.Products);
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
            ManageProduct manageProduct = new ManageProduct();
            manageProduct.Show();
        }

        private void tableLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
