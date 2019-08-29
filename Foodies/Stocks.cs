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

        int StockID;

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

        private void btnUpdate_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Stock company is required");
                }
                else
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Stock set stockname = '" + StockName.Text + "' , stockweigth = '" + StockWeight.Text + "', stockcompany = '" + StockCompany.Text + "', stockcategory = '" + StockCategory .Text + "', stockdate = '" + DateTime.Now.Date + "', stocktime = '" + DateTime.Now.ToShortTimeString() + "' where stockid = '" + StockID + "'  ";
                    cmd.ExecuteNonQuery();
                    StockCompany.Text = string.Empty;
                    StockCategory.Text = string.Empty;
                    StockName.Text = string.Empty;
                    StockWeight.Text = string.Empty;
                    // TODO: This line of code loads data into the 'stockDataSet.Stock' table. You can move, or remove it, as needed.
                    this.stockTableAdapter.Fill(this.stockDataSet.Stock);
                    MessageBox.Show("Stock updated");
                }

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv1.Rows[e.RowIndex];

                StockID = Convert.ToInt32(row.Cells[0].Value);
                StockName.Text = row.Cells[1].Value.ToString();
                StockWeight.Text = row.Cells[2].Value.ToString();
                StockCompany.Text = row.Cells[3].Value.ToString();
                StockCategory.Text = row.Cells[4].Value.ToString();
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv1.Rows[e.RowIndex];

                StockID = Convert.ToInt32(row.Cells[0].Value);
                StockName.Text = row.Cells[1].Value.ToString();
                StockWeight.Text = row.Cells[2].Value.ToString();
                StockCompany.Text = row.Cells[3].Value.ToString();
                StockCategory.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Stock where stockid ='" + StockID + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                StockCompany.Text = string.Empty;
                StockCategory.Text = string.Empty;
                StockName.Text = string.Empty;
                StockWeight.Text = string.Empty;
                // TODO: This line of code loads data into the 'stockDataSet.Stock' table. You can move, or remove it, as needed.
                this.stockTableAdapter.Fill(this.stockDataSet.Stock);
                MessageBox.Show("Stock deleted");
                
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all required fields");
            }
        }
    }
}
