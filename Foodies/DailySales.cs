﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Foodies
{
    public partial class DailySales : Form
    {
        public DailySales()
        {
            InitializeComponent();
        }

        private void SalesDemo_Load(object sender, EventArgs e)
        {
            LoadChart();
        }

        public void LoadChart()
        {
            SqlConnection con = new SqlConnection(Helper.con);

            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;

            cmd = new SqlCommand("Select * from Bill where OrderDate = '"+ DateTime.Now.Date + "' ", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            DataView source = new DataView(ds.Tables[0]);
            chart1.DataSource = source;
            chart1.Series[0].XValueMember = "InvioceID";
            chart1.Series[0].YValueMembers = "TotalQty";
            chart1.Series[1].XValueMember = "InvioceID";
            chart1.Series[1].YValueMembers = "TotalAmount";
            this.chart1.Titles.Add("TOTAL SALE PER CUSTOMER DATA");
            chart1.DataBind();
        }
    }
}