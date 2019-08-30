﻿using System;
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
    public partial class Weekly : Form
    {
        public Weekly()
        {
            InitializeComponent();
        }

        private void Weekly_Load(object sender, EventArgs e)
        {
            LoadChart();
        }

        public void LoadChart()
        {
            var firstdayofweek = DateTime.Now.AddDays(-6);
            var currentdate = DateTime.Now.Date;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9CBGPDG\ASHIRAFZAL;Initial Catalog=foodtime;Integrated Security=True;Pooling=False");

            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;

            cmd = new SqlCommand("Select * from Bill where OrderDate between '" + firstdayofweek + "' and '" + currentdate + "' ", con);
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
