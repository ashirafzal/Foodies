namespace Foodies
{
    partial class SalesSummary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesSummary));
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.annualsales = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lastmonthsales = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lastweeksales = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.todaysales = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product_name,
            this.product_price,
            this.qty});
            this.dgv1.Location = new System.Drawing.Point(0, -1);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.Size = new System.Drawing.Size(980, 19);
            this.dgv1.TabIndex = 0;
            this.dgv1.Visible = false;
            // 
            // product_name
            // 
            this.product_name.HeaderText = "PRODUCT NAME";
            this.product_name.Name = "product_name";
            this.product_name.ReadOnly = true;
            // 
            // product_price
            // 
            this.product_price.HeaderText = "PRODUCT PRICE";
            this.product_price.Name = "product_price";
            this.product_price.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.HeaderText = "PRODUCT QTY";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(341, 469);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(917, 317);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // dgv2
            // 
            this.dgv2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(983, -1);
            this.dgv2.Margin = new System.Windows.Forms.Padding(0);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(618, 19);
            this.dgv2.TabIndex = 2;
            this.dgv2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(607, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "ANNUAL SALES SUMMARY";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(620, 421);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(351, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "ANNUAL SALES BY PRODUCT";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.annualsales, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lastmonthsales, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lastweeksales, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.todaysales, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(341, 128);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(917, 260);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // annualsales
            // 
            this.annualsales.AutoSize = true;
            this.annualsales.BackColor = System.Drawing.Color.White;
            this.annualsales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annualsales.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.annualsales.Location = new System.Drawing.Point(458, 195);
            this.annualsales.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.annualsales.Name = "annualsales";
            this.annualsales.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.annualsales.Size = new System.Drawing.Size(459, 60);
            this.annualsales.TabIndex = 11;
            this.annualsales.Text = "0";
            this.annualsales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.CadetBlue;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(0, 195);
            this.label14.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label14.Size = new System.Drawing.Size(458, 60);
            this.label14.TabIndex = 10;
            this.label14.Text = "Annual sales";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lastmonthsales
            // 
            this.lastmonthsales.AutoSize = true;
            this.lastmonthsales.BackColor = System.Drawing.Color.White;
            this.lastmonthsales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lastmonthsales.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastmonthsales.Location = new System.Drawing.Point(458, 130);
            this.lastmonthsales.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lastmonthsales.Name = "lastmonthsales";
            this.lastmonthsales.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lastmonthsales.Size = new System.Drawing.Size(459, 60);
            this.lastmonthsales.TabIndex = 7;
            this.lastmonthsales.Text = "0";
            this.lastmonthsales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.CadetBlue;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 130);
            this.label10.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(458, 60);
            this.label10.TabIndex = 6;
            this.label10.Text = "Last month sales";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lastweeksales
            // 
            this.lastweeksales.AutoSize = true;
            this.lastweeksales.BackColor = System.Drawing.Color.White;
            this.lastweeksales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lastweeksales.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastweeksales.Location = new System.Drawing.Point(458, 65);
            this.lastweeksales.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lastweeksales.Name = "lastweeksales";
            this.lastweeksales.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lastweeksales.Size = new System.Drawing.Size(459, 60);
            this.lastweeksales.TabIndex = 3;
            this.lastweeksales.Text = "0";
            this.lastweeksales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.CadetBlue;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label6.Size = new System.Drawing.Size(458, 60);
            this.label6.TabIndex = 2;
            this.label6.Text = "Last week sales";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.CadetBlue;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(458, 60);
            this.label4.TabIndex = 0;
            this.label4.Text = "Today sales";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // todaysales
            // 
            this.todaysales.AutoSize = true;
            this.todaysales.BackColor = System.Drawing.Color.White;
            this.todaysales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.todaysales.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todaysales.Location = new System.Drawing.Point(458, 0);
            this.todaysales.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.todaysales.Name = "todaysales";
            this.todaysales.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.todaysales.Size = new System.Drawing.Size(459, 60);
            this.todaysales.TabIndex = 1;
            this.todaysales.Text = "0";
            this.todaysales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SalesSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1600, 841);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dgv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SalesSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALES SUMMARY";
            this.Load += new System.EventHandler(this.SalesSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label annualsales;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lastmonthsales;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lastweeksales;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label todaysales;
    }
}