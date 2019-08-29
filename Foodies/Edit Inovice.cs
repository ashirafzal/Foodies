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
    public partial class Edit_Inovice : Form
    {
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
            try
            {
                int invoiceid = Convert.ToInt32(InvoiceNumber.Text);

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
                con.Open();
                string query = "select * from Bill where InvioceID  = '" + invoiceid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv1.DataSource = dt;
                con.Close();
                InvoiceNumber.Text = "";
                dgv1.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("InvoiceID cannot be blank");
            }
        }

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int qty;
            int rate;
            int amount;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv1.Rows[e.RowIndex];

                this.dgv1.EditMode = DataGridViewEditMode.EditOnEnter;

                qty = Convert.ToInt32(row.Cells[5].Value);
                rate = Convert.ToInt32(row.Cells[6].Value);
                amount = qty * rate;
                row.Cells[7].Value = amount;
            }
        }
    }
}
