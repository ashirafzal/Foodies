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
    public partial class Stocks : Form
    {
        public Stocks()
        {
            InitializeComponent();
        }

        private void Stocks_Load(object sender, EventArgs e)
        {
            dgv_1();
            // TODO: This line of code loads data into the 'stockDataSet.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.stockDataSet.Stock);
        }

        public void dgv_1()
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
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 12F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
            con.Open();

            try
            {

                if (StockName.Text == string.Empty)
                {
                    MessageBox.Show("Stock name is required");
                }
                else if (StockWeight.Text == string.Empty)
                {
                    MessageBox.Show("Stock weight is required");
                }
                else if (StockCategory.Text == string.Empty)
                {
                    MessageBox.Show("Stock category is required");
                }
                else if (StockCompany.Text == string.Empty)
                {
                    string companyname = "local company";
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Stock (stockname,stockweigth,stockcompany,stockcategory,stockdate,stocktime) values ('" + StockName.Text + "','" + StockWeight.Text + "','" + companyname.ToString() + "','" + StockCategory.Text + "','" + DateTime.Now.Date + "','" + DateTime.Now.ToShortTimeString() + "')";
                    cmd.ExecuteNonQuery();
                    StockCompany.Text = string.Empty;
                    StockCategory.Text = string.Empty;
                    StockName.Text = string.Empty;
                    StockWeight.Text = string.Empty;
                    // TODO: This line of code loads data into the 'stockDataSet.Stock' table. You can move, or remove it, as needed.
                    this.stockTableAdapter.Fill(this.stockDataSet.Stock);
                    MessageBox.Show("Stock Created Successfully");
                }
                else
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Stock (stockname,stockweigth,stockcompany,stockcategory,stockdate,stocktime) values ('" + StockName.Text + "','" + StockWeight.Text + "','" + StockCompany.Text + "','" + StockCategory.Text + "','" + DateTime.Now.Date + "','" + DateTime.Now.ToShortTimeString() + "')";
                    cmd.ExecuteNonQuery();
                    StockCompany.Text = string.Empty;
                    StockCategory.Text = string.Empty;
                    StockName.Text = string.Empty;
                    StockWeight.Text = string.Empty;
                    // TODO: This line of code loads data into the 'stockDataSet.Stock' table. You can move, or remove it, as needed.
                    this.stockTableAdapter.Fill(this.stockDataSet.Stock);
                    MessageBox.Show("Stock Created Successfully");
                }

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
            }
        }
    }
}
