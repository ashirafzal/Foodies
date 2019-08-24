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
            label1.BackColor = Color.RoyalBlue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Black;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.RoyalBlue;
            label1.ForeColor = Color.White;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.BackColor = Color.RoyalBlue;
            label2.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.White;
            label2.ForeColor = Color.Black;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.RoyalBlue;
            label3.ForeColor = Color.White;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.White;
            label3.ForeColor = Color.Black;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.RoyalBlue;
            label4.ForeColor = Color.White;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.White;
            label4.ForeColor = Color.Black;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = Color.RoyalBlue;
            label5.ForeColor = Color.White;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.White;
            label5.ForeColor = Color.Black;
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            dgv_1();
            // TODO: This line of code loads data into the 'categoryYDataSet2.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.categoryYDataSet2.Category);
            Category.Visible = false;
        }

        public void dgv_1()
        {
            dgv1.RowTemplate.Height = 200;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(0, 10, 0, 10);
            this.dgv1.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //This Part of Code is for the styling of the Visaul Style
            //dgv1.EnableHeadersVisualStyles = false;

            // This Part of Code is for the styling of the Grid Border
            this.dgv1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Bold);

            //this Line of Code made the dgv1 Text Middle Center
            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //this line of code is applying padding to a specific Column of dgv1 which is Product Column
            //dgv2.Columns[4].DefaultCellStyle.Padding = new Padding(3, 3, 3, 3);

        }

        private void label4_Click(object sender, EventArgs e)
        {
            //Categories Panel
            Category.Visible = true;
        }
    }
}
