using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;

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
            //DataGridVeiwDesignLoad
            dgv_1();
            dgv_2();
            dgv_3();
            dgv_4();
            dgv_5();
            dgv_6();
            dgv_7();

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
            dgv1.RowsDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void dgv_2()
        {
            dgv2.RowTemplate.Height = 32;

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
            dgv2.RowsDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
        
            // This Part of Code is for the styling of the Grid Border
            this.dgv3.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv3.RowsDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv3.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void dgv_4()
        {
            dgv4.RowTemplate.Height = 32;

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
            dgv4.RowsDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv4.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void dgv_5()
        {
            dgv5.RowTemplate.Height = 32;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(0, 10, 0, 10);
            this.dgv5.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv5.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);
            dgv5.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // This Part of Code is for the styling of the Grid Border
            this.dgv5.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv5.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv5.RowsDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv5.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void dgv_6()
        {
            dgv6.RowTemplate.Height = 32;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(0, 10, 0, 10);
            this.dgv6.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv6.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);
            dgv6.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // This Part of Code is for the styling of the Grid Border
            this.dgv6.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv6.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv6.RowsDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv6.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void dgv_7()
        {
            dgv7.RowTemplate.Height = 32;

            //This Part of Code is for the styling of the Grid Padding
            Padding newPadding = new Padding(0, 10, 0, 10);
            this.dgv7.ColumnHeadersDefaultCellStyle.Padding = newPadding;

            //This Part of Code is for the styling of the Grid Columns
            dgv7.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Regular);
            dgv7.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // This Part of Code is for the styling of the Grid Border
            this.dgv7.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dgv7.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            //This Part of Code is for the styling of the Grid Rows
            dgv7.RowsDefaultCellStyle.Font = new Font("Arial", 11F, FontStyle.Regular);

            //this Line of Code made the dgv1 Text Middle Center
            dgv7.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void StockToExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable.
            DataTable dt = new DataTable();

            //Adding the Columns.
            foreach (DataGridViewColumn column in dgv1.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows.
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            //Exporting to Excel.
            string folderPath = "C:\\Foodies\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Customers");

                //Set the color of Header Row.
                //A resembles First Column while C resembles Third column.
                wb.Worksheet(1).Cells("A1:C1").Style.Fill.BackgroundColor = XLColor.DarkGreen;
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    //A resembles First Column while C resembles Third column.
                    //Header row is at Position 1 and hence First row starts from Index 2.
                    string cellRange = string.Format("A{0}:C{0}", i + 1);
                    if (i % 2 != 0)
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.GreenYellow;
                    }
                    else
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.Yellow;
                    }

                }
                //Adjust widths of Columns.
                wb.Worksheet(1).Columns().AdjustToContents();

                //Save the Excel file.
                wb.SaveAs(folderPath + "Bill Records.xlsx");
            }

        }

        private void categorytoExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable.
            DataTable dt = new DataTable();

            //Adding the Columns.
            foreach (DataGridViewColumn column in dgv2.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows.
            foreach (DataGridViewRow row in dgv2.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            //Exporting to Excel.
            string folderPath = "C:\\Foodies\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Customers");

                //Set the color of Header Row.
                //A resembles First Column while C resembles Third column.
                wb.Worksheet(1).Cells("A1:C1").Style.Fill.BackgroundColor = XLColor.DarkGreen;
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    //A resembles First Column while C resembles Third column.
                    //Header row is at Position 1 and hence First row starts from Index 2.
                    string cellRange = string.Format("A{0}:C{0}", i + 1);
                    if (i % 2 != 0)
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.GreenYellow;
                    }
                    else
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.Yellow;
                    }

                }
                //Adjust widths of Columns.
                wb.Worksheet(1).Columns().AdjustToContents();

                //Save the Excel file.
                wb.SaveAs(folderPath + "Category Records.xlsx");
            }
        }

        private void customerToExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable.
            DataTable dt = new DataTable();

            //Adding the Columns.
            foreach (DataGridViewColumn column in dgv3.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows.
            foreach (DataGridViewRow row in dgv3.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            //Exporting to Excel.
            string folderPath = "C:\\Foodies\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Customers");

                //Set the color of Header Row.
                //A resembles First Column while C resembles Third column.
                wb.Worksheet(1).Cells("A1:C1").Style.Fill.BackgroundColor = XLColor.DarkGreen;
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    //A resembles First Column while C resembles Third column.
                    //Header row is at Position 1 and hence First row starts from Index 2.
                    string cellRange = string.Format("A{0}:C{0}", i + 1);
                    if (i % 2 != 0)
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.GreenYellow;
                    }
                    else
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.Yellow;
                    }

                }
                //Adjust widths of Columns.
                wb.Worksheet(1).Columns().AdjustToContents();

                //Save the Excel file.
                wb.SaveAs(folderPath + "Customer Records.xlsx");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Creating DataTable.
            DataTable dt = new DataTable();

            //Adding the Columns.
            foreach (DataGridViewColumn column in dgv4.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows.
            foreach (DataGridViewRow row in dgv4.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            //Exporting to Excel.
            string folderPath = "C:\\Foodies\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Customers");

                //Set the color of Header Row.
                //A resembles First Column while C resembles Third column.
                wb.Worksheet(1).Cells("A1:C1").Style.Fill.BackgroundColor = XLColor.DarkGreen;
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    //A resembles First Column while C resembles Third column.
                    //Header row is at Position 1 and hence First row starts from Index 2.
                    string cellRange = string.Format("A{0}:C{0}", i + 1);
                    if (i % 2 != 0)
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.GreenYellow;
                    }
                    else
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.Yellow;
                    }

                }
                //Adjust widths of Columns.
                wb.Worksheet(1).Columns().AdjustToContents();

                //Save the Excel file.
                wb.SaveAs(folderPath + "Order Records.xlsx");
            }
        }

        private void ProductsToExcel_Click(object sender, EventArgs e)
        {
            //Creating DataTable.
            DataTable dt = new DataTable();

            //Adding the Columns.
            foreach (DataGridViewColumn column in dgv5.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows.
            foreach (DataGridViewRow row in dgv5.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            //Exporting to Excel.
            string folderPath = "C:\\Foodies\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Customers");

                //Set the color of Header Row.
                //A resembles First Column while C resembles Third column.
                wb.Worksheet(1).Cells("A1:C1").Style.Fill.BackgroundColor = XLColor.DarkGreen;
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    //A resembles First Column while C resembles Third column.
                    //Header row is at Position 1 and hence First row starts from Index 2.
                    string cellRange = string.Format("A{0}:C{0}", i + 1);
                    if (i % 2 != 0)
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.GreenYellow;
                    }
                    else
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.Yellow;
                    }

                }
                //Adjust widths of Columns.
                wb.Worksheet(1).Columns().AdjustToContents();

                //Save the Excel file.
                wb.SaveAs(folderPath + "Products Record.xlsx");
            }
        }




    }
}