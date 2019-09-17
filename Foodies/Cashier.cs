using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
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

        //For inventory operations
        // Product name to check in a string
        string zingerburger = "zinger burger";
        // Boolean to check whether porudct is present in datagridview or not
        bool exist;

        public void inventoryFunctionality()
        {
            //Declaration for Dr read 
            int stockid, stockweigth, newstockweigth;
            string stockname, stockcompany, stockcategory, stockdate, stocktime;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            foreach (DataGridViewRow Row in dgv3.Rows)
            {
                for (int i = 0; i < 1; i++)
                {
                    if (Convert.ToString(Row.Cells[0].Value) == zingerburger)
                    {
                        string gridname = Convert.ToString(Row.Cells[0].Value);
                        int quantity = Convert.ToInt32(Row.Cells[1].Value);
                        exist = true;
                        if (exist == true)
                        {
                            //MessageBox.Show("Found");
                            SqlCommand cmd = new SqlCommand("select * from Stock where stockname = 'chicken' ", con, tran);
                            cmd.ExecuteNonQuery();

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    stockid =  Convert.ToInt32(dr["stockid"]);
                                    stockname = Convert.ToString(dr["stockname"]);
                                    stockweigth = Convert.ToInt32(dr["stockweigth"]);
                                    stockcompany = Convert.ToString(dr["stockcompany"]);
                                    stockcategory = Convert.ToString(dr["stockcategory"]);
                                    stockdate = Convert.ToString(dr["stockdate"]);
                                    stocktime = Convert.ToString(dr["stocktime"]);

                                    newstockweigth = stockweigth - 125 * quantity;

                                    SqlCommand cmd1 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" +stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd1.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd2 = new SqlCommand("select * from Stock where stockname = 'potato' ", con, tran);
                            cmd2.ExecuteNonQuery();

                            using (SqlDataReader dr2 = cmd2.ExecuteReader())
                            {
                                while (dr2.Read())
                                {
                                    stockid = Convert.ToInt32(dr2["stockid"]);
                                    stockname = Convert.ToString(dr2["stockname"]);
                                    stockweigth = Convert.ToInt32(dr2["stockweigth"]);
                                    stockcompany = Convert.ToString(dr2["stockcompany"]);
                                    stockcategory = Convert.ToString(dr2["stockcategory"]);
                                    stockdate = Convert.ToString(dr2["stockdate"]);
                                    stocktime = Convert.ToString(dr2["stocktime"]);

                                    newstockweigth = stockweigth - 250 * quantity;

                                    SqlCommand cmd3 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd3.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd4 = new SqlCommand("select * from Stock where stockname = 'chinese salt' ", con, tran);
                            cmd4.ExecuteNonQuery();

                            using (SqlDataReader dr3 = cmd4.ExecuteReader())
                            {
                                while (dr3.Read())
                                {
                                    stockid = Convert.ToInt32(dr3["stockid"]);
                                    stockname = Convert.ToString(dr3["stockname"]);
                                    stockweigth = Convert.ToInt32(dr3["stockweigth"]);
                                    stockcompany = Convert.ToString(dr3["stockcompany"]);
                                    stockcategory = Convert.ToString(dr3["stockcategory"]);
                                    stockdate = Convert.ToString(dr3["stockdate"]);
                                    stocktime = Convert.ToString(dr3["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    SqlCommand cmd5 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd5.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd6 = new SqlCommand("select * from Stock where stockname = 'white chilli' ", con, tran);
                            cmd6.ExecuteNonQuery();

                            using (SqlDataReader dr4 = cmd6.ExecuteReader())
                            {
                                while (dr4.Read())
                                {
                                    stockid = Convert.ToInt32(dr4["stockid"]);
                                    stockname = Convert.ToString(dr4["stockname"]);
                                    stockweigth = Convert.ToInt32(dr4["stockweigth"]);
                                    stockcompany = Convert.ToString(dr4["stockcompany"]);
                                    stockcategory = Convert.ToString(dr4["stockcategory"]);
                                    stockdate = Convert.ToString(dr4["stockdate"]);
                                    stocktime = Convert.ToString(dr4["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    SqlCommand cmd7 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd7.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd8= new SqlCommand("select * from Stock where stockname = 'mastard powder' ", con, tran);
                            cmd8.ExecuteNonQuery();

                            using (SqlDataReader dr5 = cmd8.ExecuteReader())
                            {
                                while (dr5.Read())
                                {
                                    stockid = Convert.ToInt32(dr5["stockid"]);
                                    stockname = Convert.ToString(dr5["stockname"]);
                                    stockweigth = Convert.ToInt32(dr5["stockweigth"]);
                                    stockcompany = Convert.ToString(dr5["stockcompany"]);
                                    stockcategory = Convert.ToString(dr5["stockcategory"]);
                                    stockdate = Convert.ToString(dr5["stockdate"]);
                                    stocktime = Convert.ToString(dr5["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    SqlCommand cmd9 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd9.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd10 = new SqlCommand("select * from Stock where stockname = 'sauce' ", con, tran);
                            cmd10.ExecuteNonQuery();

                            using (SqlDataReader dr6 = cmd10.ExecuteReader())
                            {
                                while (dr6.Read())
                                {
                                    stockid = Convert.ToInt32(dr6["stockid"]);
                                    stockname = Convert.ToString(dr6["stockname"]);
                                    stockweigth = Convert.ToInt32(dr6["stockweigth"]);
                                    stockcompany = Convert.ToString(dr6["stockcompany"]);
                                    stockcategory = Convert.ToString(dr6["stockcategory"]);
                                    stockdate = Convert.ToString(dr6["stockdate"]);
                                    stocktime = Convert.ToString(dr6["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    SqlCommand cmd11 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd11.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd12 = new SqlCommand("select * from Stock where stockname = 'meda' ", con, tran);
                            cmd12.ExecuteNonQuery();

                            using (SqlDataReader dr7 = cmd12.ExecuteReader())
                            {
                                while (dr7.Read())
                                {
                                    stockid = Convert.ToInt32(dr7["stockid"]);
                                    stockname = Convert.ToString(dr7["stockname"]);
                                    stockweigth = Convert.ToInt32(dr7["stockweigth"]);
                                    stockcompany = Convert.ToString(dr7["stockcompany"]);
                                    stockcategory = Convert.ToString(dr7["stockcategory"]);
                                    stockdate = Convert.ToString(dr7["stockdate"]);
                                    stocktime = Convert.ToString(dr7["stocktime"]);

                                    newstockweigth = stockweigth - 250 * quantity;

                                    SqlCommand cmd13 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd13.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd14 = new SqlCommand("select * from Stock where stockname = 'bread crum' ", con, tran);
                            cmd14.ExecuteNonQuery();

                            using (SqlDataReader dr8 = cmd14.ExecuteReader())
                            {
                                while (dr8.Read())
                                {
                                    stockid = Convert.ToInt32(dr8["stockid"]);
                                    stockname = Convert.ToString(dr8["stockname"]);
                                    stockweigth = Convert.ToInt32(dr8["stockweigth"]);
                                    stockcompany = Convert.ToString(dr8["stockcompany"]);
                                    stockcategory = Convert.ToString(dr8["stockcategory"]);
                                    stockdate = Convert.ToString(dr8["stockdate"]);
                                    stocktime = Convert.ToString(dr8["stocktime"]);

                                    newstockweigth = stockweigth - 250 * quantity;

                                    SqlCommand cmd15 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd15.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd16 = new SqlCommand("select * from Stock where stockname = 'baking powder' ", con, tran);
                            cmd16.ExecuteNonQuery();

                            using (SqlDataReader dr9 = cmd16.ExecuteReader())
                            {
                                while (dr9.Read())
                                {
                                    stockid = Convert.ToInt32(dr9["stockid"]);
                                    stockname = Convert.ToString(dr9["stockname"]);
                                    stockweigth = Convert.ToInt32(dr9["stockweigth"]);
                                    stockcompany = Convert.ToString(dr9["stockcompany"]);
                                    stockcategory = Convert.ToString(dr9["stockcategory"]);
                                    stockdate = Convert.ToString(dr9["stockdate"]);
                                    stocktime = Convert.ToString(dr9["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    SqlCommand cmd17 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd17.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd18 = new SqlCommand("select * from Stock where stockname = 'baking powder' ", con, tran);
                            cmd18.ExecuteNonQuery();

                            using (SqlDataReader dr10 = cmd18.ExecuteReader())
                            {
                                while (dr10.Read())
                                {
                                    stockid = Convert.ToInt32(dr10["stockid"]);
                                    stockname = Convert.ToString(dr10["stockname"]);
                                    stockweigth = Convert.ToInt32(dr10["stockweigth"]);
                                    stockcompany = Convert.ToString(dr10["stockcompany"]);
                                    stockcategory = Convert.ToString(dr10["stockcategory"]);
                                    stockdate = Convert.ToString(dr10["stockdate"]);
                                    stocktime = Convert.ToString(dr10["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    SqlCommand cmd19 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd19.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd20 = new SqlCommand("select * from Stock where stockname = 'egg' ", con, tran);
                            cmd20.ExecuteNonQuery();

                            using (SqlDataReader dr11 = cmd20.ExecuteReader())
                            {
                                while (dr11.Read())
                                {
                                    stockid = Convert.ToInt32(dr11["stockid"]);
                                    stockname = Convert.ToString(dr11["stockname"]);
                                    double stockweigth2 = Convert.ToDouble(dr11["stockweigth"]);
                                    stockcompany = Convert.ToString(dr11["stockcompany"]);
                                    stockcategory = Convert.ToString(dr11["stockcategory"]);
                                    stockdate = Convert.ToString(dr11["stockdate"]);
                                    stocktime = Convert.ToString(dr11["stocktime"]);

                                    double newstockweigth2 = stockweigth2 - 0.5 * quantity;

                                    SqlCommand cmd21 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth2 + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd21.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd22 = new SqlCommand("select * from Stock where stockname = 'corn flour' ", con, tran);
                            cmd22.ExecuteNonQuery();

                            using (SqlDataReader dr12 = cmd22.ExecuteReader())
                            {
                                while (dr12.Read())
                                {
                                    stockid = Convert.ToInt32(dr12["stockid"]);
                                    stockname = Convert.ToString(dr12["stockname"]);
                                    stockweigth = Convert.ToInt32(dr12["stockweigth"]);
                                    stockcompany = Convert.ToString(dr12["stockcompany"]);
                                    stockcategory = Convert.ToString(dr12["stockcategory"]);
                                    stockdate = Convert.ToString(dr12["stockdate"]);
                                    stocktime = Convert.ToString(dr12["stocktime"]);

                                    newstockweigth = stockweigth - 2 * quantity;

                                    SqlCommand cmd23 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd23.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd24 = new SqlCommand("select * from Stock where stockname = 'milk' ", con, tran);
                            cmd24.ExecuteNonQuery();

                            using (SqlDataReader dr13 = cmd24.ExecuteReader())
                            {
                                while (dr13.Read())
                                {
                                    stockid = Convert.ToInt32(dr13["stockid"]);
                                    stockname = Convert.ToString(dr13["stockname"]);
                                    stockweigth = Convert.ToInt32(dr13["stockweigth"]);
                                    stockcompany = Convert.ToString(dr13["stockcompany"]);
                                    stockcategory = Convert.ToString(dr13["stockcategory"]);
                                    stockdate = Convert.ToString(dr13["stockdate"]);
                                    stocktime = Convert.ToString(dr13["stocktime"]);

                                    newstockweigth = stockweigth - 8 * quantity;

                                    SqlCommand cmd25 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd25.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd26 = new SqlCommand("select * from Stock where stockname = 'bun' ", con, tran);
                            cmd26.ExecuteNonQuery();

                            using (SqlDataReader dr14 = cmd26.ExecuteReader())
                            {
                                while (dr14.Read())
                                {
                                    stockid = Convert.ToInt32(dr14["stockid"]);
                                    stockname = Convert.ToString(dr14["stockname"]);
                                    stockweigth = Convert.ToInt32(dr14["stockweigth"]);
                                    stockcompany = Convert.ToString(dr14["stockcompany"]);
                                    stockcategory = Convert.ToString(dr14["stockcategory"]);
                                    stockdate = Convert.ToString(dr14["stockdate"]);
                                    stocktime = Convert.ToString(dr14["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    SqlCommand cmd27 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd27.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd28 = new SqlCommand("select * from Stock where stockname = 'mayoneze' ", con, tran);
                            cmd28.ExecuteNonQuery();

                            using (SqlDataReader dr15 = cmd28.ExecuteReader())
                            {
                                while (dr15.Read())
                                {
                                    stockid = Convert.ToInt32(dr15["stockid"]);
                                    stockname = Convert.ToString(dr15["stockname"]);
                                    stockweigth = Convert.ToInt32(dr15["stockweigth"]);
                                    stockcompany = Convert.ToString(dr15["stockcompany"]);
                                    stockcategory = Convert.ToString(dr15["stockcategory"]);
                                    stockdate = Convert.ToString(dr15["stockdate"]);
                                    stocktime = Convert.ToString(dr15["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    SqlCommand cmd29 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd29.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd30 = new SqlCommand("select * from Stock where stockname = 'ketchup' ", con, tran);
                            cmd30.ExecuteNonQuery();

                            using (SqlDataReader dr16 = cmd30.ExecuteReader())
                            {
                                while (dr16.Read())
                                {
                                    stockid = Convert.ToInt32(dr16["stockid"]);
                                    stockname = Convert.ToString(dr16["stockname"]);
                                    stockweigth = Convert.ToInt32(dr16["stockweigth"]);
                                    stockcompany = Convert.ToString(dr16["stockcompany"]);
                                    stockcategory = Convert.ToString(dr16["stockcategory"]);
                                    stockdate = Convert.ToString(dr16["stockdate"]);
                                    stocktime = Convert.ToString(dr16["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    SqlCommand cmd31 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd31.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd32 = new SqlCommand("select * from Stock where stockname = 'salad' ", con, tran);
                            cmd32.ExecuteNonQuery();

                            using (SqlDataReader dr17 = cmd32.ExecuteReader())
                            {
                                while (dr17.Read())
                                {
                                    stockid = Convert.ToInt32(dr17["stockid"]);
                                    stockname = Convert.ToString(dr17["stockname"]);
                                    stockweigth = Convert.ToInt32(dr17["stockweigth"]);
                                    stockcompany = Convert.ToString(dr17["stockcompany"]);
                                    stockcategory = Convert.ToString(dr17["stockcategory"]);
                                    stockdate = Convert.ToString(dr17["stockdate"]);
                                    stocktime = Convert.ToString(dr17["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    SqlCommand cmd33 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd33.ExecuteNonQuery();
                                }
                            }

                            SqlCommand cmd34 = new SqlCommand("select * from Stock where stockname = 'salt' ", con, tran);
                            cmd34.ExecuteNonQuery();

                            using (SqlDataReader dr18 = cmd34.ExecuteReader())
                            {
                                while (dr18.Read())
                                {
                                    stockid = Convert.ToInt32(dr18["stockid"]);
                                    stockname = Convert.ToString(dr18["stockname"]);
                                    stockweigth = Convert.ToInt32(dr18["stockweigth"]);
                                    stockcompany = Convert.ToString(dr18["stockcompany"]);
                                    stockcategory = Convert.ToString(dr18["stockcategory"]);
                                    stockdate = Convert.ToString(dr18["stockdate"]);
                                    stocktime = Convert.ToString(dr18["stocktime"]);

                                    newstockweigth = stockweigth - 1 * quantity;

                                    SqlCommand cmd35 = new SqlCommand("update Stock set stockname = '" + stockname + "' , stockweigth = '" + newstockweigth + "', stockcompany = '" + stockcompany + "', stockcategory = '" + stockcategory + "', stockdate = '" + stockdate + "', stocktime = '" + stocktime + "' where stockid = '" + stockid + "'  ", con, tran);
                                    cmd35.ExecuteNonQuery();
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Not Found");
                        }
                    }
                    else
                    {
                        exist = false;
                    }
                }
            }
            tran.Commit();
            con.Close();
        }

        //For billing
        string drInvoiceid, CustID, OrderID, CustName, Product_Name,
               ProductQuantity, ProductRate, ProductAmount, ProductAmountWithGST,
               OrderTime, OrderDate, TotalQty, ActualAmount, TotalAmount, TotalAmountWithGST,
               DiscounInPercent;

        // For Bill variables
        string Total_Qty, Actual_Amount, Total_Amount, _TotalWithGST, _Discount;

        // Connection String //
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");

        public System.Windows.Forms.DataGridViewImageCellLayout ImageLayout { get; set; }
        public System.Drawing.Printing.PaperSize PaperSize { get; set; }

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
            this.dgv3.EditMode = DataGridViewEditMode.EditOnEnter;
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
            ManageCategory manageCategory = new ManageCategory();
            manageCategory.Show();
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
            Stocks stocks = new Stocks();
            stocks.Show();
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

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");
                con.Open();
                string query = "select * from Products where ProductCategory = '"+ maincategory +"' ";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dgv2.DataSource = dt;
                con.Close();
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
                        //totalAmount = 0; totalQuantity = 0;
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
            try
            {
                if (DiscountPKR.Text == "")
                {
                    per_discount.Text = DiscountPercent.Text;
                    decimal labelActualAmount = Convert.ToInt32(act_price.Text);
                    decimal discountvalue = Convert.ToInt32(DiscountPercent.Text);
                    decimal discoutPercentage = discountvalue / 100;
                    decimal remainAmount = discoutPercentage * labelActualAmount;
                    decimal ActualAmount = totalAmount - remainAmount;
                    total_Amount.Text = ActualAmount.ToString();
                }
                else if (DiscountPercent.Text == "")
                {
                    decimal discountAmountinPKR = Convert.ToInt32(DiscountPKR.Text);
                    decimal labelActualAmount = Convert.ToInt32(act_price.Text);
                    decimal ActualAmount = labelActualAmount - discountAmountinPKR;
                    total_Amount.Text = ActualAmount.ToString();
                    decimal percentageForAmount = discountAmountinPKR / labelActualAmount * 100;
                    per_discount.Text = percentageForAmount.ToString();
                }
                else
                {
                    MessageBox.Show("Either insert discount in rupees or in percentage");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Discount feild cannot be empty");
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
            // TODO: This line of code loads data into the 'categoryDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.categoryDataSet.Category);
        }

        private void dgv3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv3_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void DVPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {

        }

        private void DVPrintDocument_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            
        }

        private void DVPrintPreviewDialog_Load(object sender, EventArgs e)
        {
            
        }

        private void DVPrintPreviewDialog_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void dgv3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int qty;
            int rate;
            int amount;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv3.Rows[e.RowIndex];

                totalAmount = 0; totalQuantity = 0;
                totalQty.Text = "0";
                total_Amount.Text = "0";

                this.dgv3.EditMode = DataGridViewEditMode.EditOnEnter;

                qty = Convert.ToInt32(row.Cells[1].Value);
                rate = Convert.ToInt32(row.Cells[2].Value);
                amount = qty * rate;
                row.Cells[3].Value = amount;

            }

            for (int i = 0; i < dgv3.Rows.Count; ++i)
            {
                totalQuantity += Convert.ToInt32(dgv3.Rows[i].Cells[1].Value);
                totalAmount += Convert.ToInt32(dgv3.Rows[i].Cells[3].Value);
            }
            totalQty.Text = totalQuantity.ToString();
            total_Amount.Text = totalAmount.ToString();
            act_price.Text = totalAmount.ToString();
        }

        private void dgv3_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgv3_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                try
            {
                DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 500);
                DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

                if (dgv3.Rows.Count <=2)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 500);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 4)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 550);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 6)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 600);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 8)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 650);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 10)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 700);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 12)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 750);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 14)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 800);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 16)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 850);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 18)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 900);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 20)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 950);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 22)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1000);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 24)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1050);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 26)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1100);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 28)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1150);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 30)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1200);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 32)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1250);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 34)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1300);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 36)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1350);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else if (dgv3.Rows.Count <= 38)
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1400);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }
                else
                {
                    DVPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("", 400, 1450);
                    DVPrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                }

                //
                //
                //

                if (dgv3.Rows.Count == 0)
                {
                    const string message =
                        "Transaction can't be completed because there is no item selected for sale.";
                    const string caption = "Transaction Error";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Stop);
                }
                else if (dgv3.Rows.Count > 40)
                {
                    const string message =
                        "Transaction can't be completed on more than 40 items.\n" +
                        "Please select less than 40 items for transaction.";
                    const string caption = "Transaction Limit";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Exclamation);
                }
                else
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Bill", con);
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

                        SqlCommand cmd1 = new SqlCommand("insert into Customer values ('" + Custname + "','" + CustContact + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.ToShortDateString() + "')", con, tran);
                        cmd1.ExecuteNonQuery();
                        SqlCommand cmd2 = new SqlCommand("select top 1 CustID from Customer order by CustID DESC", con, tran);
                        cmd2.ExecuteNonQuery();

                        using (SqlDataReader dr = cmd2.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                CUSTID = dr["CustID"].ToString();
                                SqlCommand cmd3 = new SqlCommand("insert into Orders values ('" + CUSTID + "','" + OrderType.ToString() + "','" + OrderCategory.ToString() + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.ToShortDateString() + "')", con, tran);
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
                                    }
                                }
                            }
                            tran.Commit();
                            con.Close();
                        }
                        //Current_Invoice_Print current_Invoice = new Current_Invoice_Print();
                        //current_Invoice.Show();

                        //DVPrintPreviewDialog.Document = DVPrintDocument;
                        //DVPrintPreviewDialog.Show();

                        if ((DVPrintPreviewDialog != null))
                        {
                            DVPrintPreviewDialog = new PrintPreviewDialog();
                            ((Form)DVPrintPreviewDialog).WindowState = FormWindowState.Maximized;
                        }

                        DVPrintPreviewDialog.Document = DVPrintDocument;
                        DVPrintPreviewDialog.Show();
                        //DVPrintDocument.Print();

                        inventoryFunctionality();
                    }
                    else
                    {
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
                                    }
                                }
                            }
                            tran.Commit();
                            con.Close();
                        }
                        //Current_Invoice_Print current_Invoice = new Current_Invoice_Print();
                        //current_Invoice.Show();

                        //DVPrintPreviewDialog.Document = DVPrintDocument;
                        //DVPrintPreviewDialog.Show();

                        if ((DVPrintPreviewDialog != null))
                        {
                            DVPrintPreviewDialog = new PrintPreviewDialog();
                            ((Form)DVPrintPreviewDialog).WindowState = FormWindowState.Maximized;
                        }
                        DVPrintPreviewDialog.Document = DVPrintDocument;
                        DVPrintPreviewDialog.Show();
                        //DVPrintDocument.Print();

                        inventoryFunctionality();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Transaction Failed for Unknown Reason");
            }
           
        }

        private void DVPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            SqlCommand cmd10 = new SqlCommand("select top 1 InvioceID,Totalqty," +
                "TotalAmount,TotalAmountWithGST,ActualAmount," +
                "DiscountInPercent from Bill order by InvioceID DESC", con, tran);
            cmd10.ExecuteNonQuery();

            using (SqlDataReader dr = cmd10.ExecuteReader())
            {
                while (dr.Read())
                {
                    INVOICEID = Convert.ToInt32(dr["InvioceID"]);
                    Total_Qty = Convert.ToString(dr["Totalqty"]);
                    Total_Amount = Convert.ToString(dr["TotalAmount"]);
                    _TotalWithGST = Convert.ToString(dr["TotalAmountWithGST"]);
                    Actual_Amount = Convert.ToString(dr["ActualAmount"]);
                    _Discount = Convert.ToString(dr["DiscountInPercent"]);
                }
            }

            tran.Commit();
            con.Close();

            e.Graphics.DrawString("FOODIES FASTFOOD", new Font("Arial",15,FontStyle.Bold), Brushes.Blue, new Point(100,30));
            e.Graphics.DrawString("GST# 222-333-123456", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(130, 70));
            e.Graphics.DrawString("Invoice ID :", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10, 100));
            e.Graphics.DrawString(INVOICEID.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(90, 100));
            e.Graphics.DrawString("Transaction Date :", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10, 120));
            e.Graphics.DrawString(DateTime.Now.Date.ToShortDateString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(130, 120));
            e.Graphics.DrawString("Transaction Time :", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10, 140));
            e.Graphics.DrawString(DateTime.Now.ToShortTimeString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(130, 140));
            //
            e.Graphics.DrawString("------------------------------------------------------------------------------",
               new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10, 160));
            e.Graphics.DrawString("SALES ITEMS", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(150, 180));
            e.Graphics.DrawString("------------------------------------------------------------------------------",
            new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10, 200));
            //
            e.Graphics.DrawString("PRODUCT NAME", new Font("Arial", 9, FontStyle.Regular), Brushes.Blue, new Point(10, 240));
            e.Graphics.DrawString("QUANTITY", new Font("Arial", 9, FontStyle.Regular), Brushes.Blue, new Point(160, 240));
            e.Graphics.DrawString("RATE", new Font("Arial", 9, FontStyle.Regular), Brushes.Blue, new Point(240, 240));
            e.Graphics.DrawString("AMOUNT", new Font("Arial", 9, FontStyle.Regular), Brushes.Blue, new Point(310, 240));

            int position = 260;

            for (int i = 0;i < dgv3.Rows.Count; i ++)
            {
                position = position + 20;
                e.Graphics.DrawString(Convert.ToString(dgv3.Rows[i].Cells[0].Value), new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10,position));
                e.Graphics.DrawString(Convert.ToString(dgv3.Rows[i].Cells[1].Value)+".00", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(170, position));
                e.Graphics.DrawString(Convert.ToString(dgv3.Rows[i].Cells[2].Value)+".00", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(240, position));
                e.Graphics.DrawString(Convert.ToString(dgv3.Rows[i].Cells[3].Value)+".00", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(310, position));
            }
            //
            e.Graphics.DrawString("------------------------------------------------------------------------------",
           new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10, position + 20));
            //
            e.Graphics.DrawString("Actual Amount", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10, position + 40));
            e.Graphics.DrawString(Actual_Amount.ToString() + ".00", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(310, position + 40));
            e.Graphics.DrawString("Total Quantity", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10, position + 60));
            e.Graphics.DrawString(Total_Qty.ToString() + ".00", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(310, position + 60));
            e.Graphics.DrawString("Total Amount", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10, position + 80));
            e.Graphics.DrawString(Total_Amount.ToString() + ".00", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(310, position + 80));
            e.Graphics.DrawString("Total Amount(GST Included)", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10, position + 100));
            e.Graphics.DrawString(_TotalWithGST.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(310, position + 100));
            e.Graphics.DrawString("Discount", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10, position + 120));
            e.Graphics.DrawString(_Discount.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(310, position + 120));
            //
            e.Graphics.DrawString("------------------------------------------------------------------------------",
           new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(10, position + 140));
            //
            e.Graphics.DrawString("FOR ANY QUERIES AND COMPLAINS", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(80, position + 160));
            e.Graphics.DrawString(" SMS / WHATSAPP : 03423351437", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, new Point(90, position + 180));

        }

        private void totalInvoiceDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_Inovice edit_Inovice = new Edit_Inovice();
            edit_Inovice.Show();
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

        private void productPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductPrice productPrice = new ProductPrice();
            productPrice.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
        }

        private void btnRefresh_MouseEnter(object sender, EventArgs e)
        {
            btnRefresh.BackColor = Color.DodgerBlue;
        }

        private void btnRefresh_MouseLeave(object sender, EventArgs e)
        {
            btnRefresh.BackColor = Color.RoyalBlue;
        }

        private void dgv3_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void dailySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailySales dailySales = new DailySales();
            dailySales.Show();
        }

        private void weeklySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Weekly weekly = new Weekly();
            weekly.Show();
        }

        private void monthlySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlySales monthlySales = new MonthlySales();
            monthlySales.Show();
        }

        private void annualSaleslToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnnualSales annualSales = new AnnualSales();
            annualSales.Show();
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExcel exportToExcel = new ExportToExcel();
            exportToExcel.Show();
        }

        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the last transaction ?", "Delete Last Transaction ?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=SSPI;MultipleActiveResultSets = True");
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                SqlCommand cmd1 = new SqlCommand("select top 1 InvioceID from Bill order by InvioceID DESC", con, tran);
                cmd1.ExecuteNonQuery();

                using (SqlDataReader dr = cmd1.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        INVOICEID = Convert.ToInt32(dr["InvioceID"]);

                        SqlCommand cmd3 = new SqlCommand("select InvioceID,CustID,OrderID,CustName,ProductName,ProductQuantity" +
                                                            ",ProductRate,ProductAmount,ProductAmountWithGST,OrderTime," +
                                                            "OrderDate,Totalqty,ActualAmount,TotalAmount,TotalAmountWithGST," +
                                                            "DiscountInPercent from Bill where InvioceID = '" + INVOICEID + "' ", con, tran);
                        cmd3.ExecuteNonQuery();

                        using (SqlDataReader dr2 = cmd3.ExecuteReader())
                        {
                            while (dr2.Read())
                            {
                                drInvoiceid = Convert.ToString(dr2["InvioceID"]);
                                CustID = Convert.ToString(dr2["CustID"]);
                                OrderID = Convert.ToString(dr2["OrderID"]);
                                CustName = Convert.ToString(dr2["CustName"]);
                                Product_Name = Convert.ToString(dr2["ProductName"]);
                                ProductQuantity = Convert.ToString(dr2["ProductQuantity"]);
                                ProductRate = Convert.ToString(dr2["ProductRate"]);
                                ProductAmount = Convert.ToString(dr2["ProductAmount"]);
                                ProductAmountWithGST = Convert.ToString(dr2["ProductAmountWithGST"]);
                                OrderTime = Convert.ToString(dr2["OrderTime"]);
                                OrderDate = Convert.ToString(dr2["OrderDate"]);
                                TotalQty = Convert.ToString(dr2["Totalqty"]);
                                ActualAmount = Convert.ToString(dr2["ActualAmount"]);
                                TotalAmount = Convert.ToString(dr2["TotalAmount"]);
                                TotalAmountWithGST = Convert.ToString(dr2["TotalAmountWithGST"]);
                                DiscounInPercent = Convert.ToString(dr2["DiscountInPercent"]);

                                SqlCommand cmd4 = new SqlCommand("insert into DeletedBill values ('" + drInvoiceid + "' , '" + CustID + "' , '" + OrderID + "' , '" + CustName + "' , '" + Product_Name + "' , '" + ProductQuantity + "' , '" + ProductRate + "' , '" + ProductAmount + "' , '" + ProductAmountWithGST + "' , '" + OrderTime + "' , '" + OrderDate + "' , '" + TotalQty + "' , '" + ActualAmount + "' , '" + TotalAmount + "' , '" + TotalAmountWithGST + "' , '" + DiscounInPercent + "') ", con, tran);
                                cmd4.ExecuteNonQuery();
                            }
                        }
                        SqlCommand cmd2 = new SqlCommand("delete from Bill where InvioceID = '" + INVOICEID + "' ", con, tran);
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Transaction deleted");
                    }
                    tran.Commit();
                    con.Close();
                }
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Transaction exist");
            }
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