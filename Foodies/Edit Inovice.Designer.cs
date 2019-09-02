namespace Foodies
{
    partial class Edit_Inovice
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit_Inovice));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.InvoiceNumber = new System.Windows.Forms.TextBox();
            this.SearchInvoice = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.invioceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productAmountWithGSTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalqtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalAmountWithGSTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountInPercentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invoiceDataSet = new Foodies.InvoiceDataSet();
            this.billTableAdapter = new Foodies.InvoiceDataSetTableAdapters.BillTableAdapter();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalQty = new System.Windows.Forms.Label();
            this.ActualAmount = new System.Windows.Forms.Label();
            this.TotalAmount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.BtnDiscount = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceDataSet)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.666283F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.29459F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.1542F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1604, 841);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.91771F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.08229F));
            this.tableLayoutPanel2.Controls.Add(this.InvoiceNumber, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.SearchInvoice, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1604, 81);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // InvoiceNumber
            // 
            this.InvoiceNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceNumber.Location = new System.Drawing.Point(15, 30);
            this.InvoiceNumber.Margin = new System.Windows.Forms.Padding(15, 20, 0, 0);
            this.InvoiceNumber.Multiline = true;
            this.InvoiceNumber.Name = "InvoiceNumber";
            this.InvoiceNumber.Size = new System.Drawing.Size(1315, 41);
            this.InvoiceNumber.TabIndex = 0;
            this.InvoiceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SearchInvoice
            // 
            this.SearchInvoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchInvoice.BackColor = System.Drawing.Color.RoyalBlue;
            this.SearchInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchInvoice.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchInvoice.ForeColor = System.Drawing.Color.White;
            this.SearchInvoice.Location = new System.Drawing.Point(1346, 24);
            this.SearchInvoice.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.SearchInvoice.Name = "SearchInvoice";
            this.SearchInvoice.Size = new System.Drawing.Size(242, 53);
            this.SearchInvoice.TabIndex = 1;
            this.SearchInvoice.Text = "SEARCH INVOICE";
            this.SearchInvoice.UseVisualStyleBackColor = false;
            this.SearchInvoice.Click += new System.EventHandler(this.SearchInvoice_Click);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv1.AutoGenerateColumns = false;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invioceIDDataGridViewTextBoxColumn,
            this.custIDDataGridViewTextBoxColumn,
            this.orderIDDataGridViewTextBoxColumn,
            this.custNameDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.productQuantityDataGridViewTextBoxColumn,
            this.productRateDataGridViewTextBoxColumn,
            this.productAmountDataGridViewTextBoxColumn,
            this.productAmountWithGSTDataGridViewTextBoxColumn,
            this.orderTimeDataGridViewTextBoxColumn,
            this.orderDateDataGridViewTextBoxColumn,
            this.totalqtyDataGridViewTextBoxColumn,
            this.actualAmountDataGridViewTextBoxColumn,
            this.totalAmountDataGridViewTextBoxColumn,
            this.totalAmountWithGSTDataGridViewTextBoxColumn,
            this.discountInPercentDataGridViewTextBoxColumn});
            this.dgv1.DataSource = this.billBindingSource;
            this.dgv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv1.GridColor = System.Drawing.Color.DarkGray;
            this.dgv1.Location = new System.Drawing.Point(13, 90);
            this.dgv1.Margin = new System.Windows.Forms.Padding(0);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv1.ShowCellErrors = false;
            this.dgv1.ShowCellToolTips = false;
            this.dgv1.ShowRowErrors = false;
            this.dgv1.Size = new System.Drawing.Size(1577, 622);
            this.dgv1.TabIndex = 2;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            this.dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEnter);
            // 
            // invioceIDDataGridViewTextBoxColumn
            // 
            this.invioceIDDataGridViewTextBoxColumn.DataPropertyName = "InvioceID";
            this.invioceIDDataGridViewTextBoxColumn.HeaderText = "INVOICE ID";
            this.invioceIDDataGridViewTextBoxColumn.Name = "invioceIDDataGridViewTextBoxColumn";
            this.invioceIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // custIDDataGridViewTextBoxColumn
            // 
            this.custIDDataGridViewTextBoxColumn.DataPropertyName = "CustID";
            this.custIDDataGridViewTextBoxColumn.HeaderText = "CUST ID";
            this.custIDDataGridViewTextBoxColumn.Name = "custIDDataGridViewTextBoxColumn";
            this.custIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "ORDER ID";
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // custNameDataGridViewTextBoxColumn
            // 
            this.custNameDataGridViewTextBoxColumn.DataPropertyName = "CustName";
            this.custNameDataGridViewTextBoxColumn.HeaderText = "CUST NAME";
            this.custNameDataGridViewTextBoxColumn.Name = "custNameDataGridViewTextBoxColumn";
            this.custNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "PRODUCT NAME";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productQuantityDataGridViewTextBoxColumn
            // 
            this.productQuantityDataGridViewTextBoxColumn.DataPropertyName = "ProductQuantity";
            this.productQuantityDataGridViewTextBoxColumn.HeaderText = "PRODUCT QUANTITY";
            this.productQuantityDataGridViewTextBoxColumn.Name = "productQuantityDataGridViewTextBoxColumn";
            // 
            // productRateDataGridViewTextBoxColumn
            // 
            this.productRateDataGridViewTextBoxColumn.DataPropertyName = "ProductRate";
            this.productRateDataGridViewTextBoxColumn.HeaderText = "PRODUCT RATE";
            this.productRateDataGridViewTextBoxColumn.Name = "productRateDataGridViewTextBoxColumn";
            this.productRateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productAmountDataGridViewTextBoxColumn
            // 
            this.productAmountDataGridViewTextBoxColumn.DataPropertyName = "ProductAmount";
            this.productAmountDataGridViewTextBoxColumn.HeaderText = "PRODUCT AMOUNT";
            this.productAmountDataGridViewTextBoxColumn.Name = "productAmountDataGridViewTextBoxColumn";
            this.productAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productAmountWithGSTDataGridViewTextBoxColumn
            // 
            this.productAmountWithGSTDataGridViewTextBoxColumn.DataPropertyName = "ProductAmountWithGST";
            this.productAmountWithGSTDataGridViewTextBoxColumn.HeaderText = "GST AMOUNT";
            this.productAmountWithGSTDataGridViewTextBoxColumn.Name = "productAmountWithGSTDataGridViewTextBoxColumn";
            this.productAmountWithGSTDataGridViewTextBoxColumn.ReadOnly = true;
            this.productAmountWithGSTDataGridViewTextBoxColumn.Visible = false;
            // 
            // orderTimeDataGridViewTextBoxColumn
            // 
            this.orderTimeDataGridViewTextBoxColumn.DataPropertyName = "OrderTime";
            this.orderTimeDataGridViewTextBoxColumn.HeaderText = "ORDER TIME";
            this.orderTimeDataGridViewTextBoxColumn.Name = "orderTimeDataGridViewTextBoxColumn";
            this.orderTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderDateDataGridViewTextBoxColumn
            // 
            this.orderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate";
            this.orderDateDataGridViewTextBoxColumn.HeaderText = "ORDER DATE";
            this.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn";
            this.orderDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalqtyDataGridViewTextBoxColumn
            // 
            this.totalqtyDataGridViewTextBoxColumn.DataPropertyName = "Totalqty";
            this.totalqtyDataGridViewTextBoxColumn.HeaderText = "TOTAL QTY";
            this.totalqtyDataGridViewTextBoxColumn.Name = "totalqtyDataGridViewTextBoxColumn";
            this.totalqtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalqtyDataGridViewTextBoxColumn.Visible = false;
            // 
            // actualAmountDataGridViewTextBoxColumn
            // 
            this.actualAmountDataGridViewTextBoxColumn.DataPropertyName = "ActualAmount";
            this.actualAmountDataGridViewTextBoxColumn.HeaderText = "ACTUAL AMOUNT";
            this.actualAmountDataGridViewTextBoxColumn.Name = "actualAmountDataGridViewTextBoxColumn";
            this.actualAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.actualAmountDataGridViewTextBoxColumn.Visible = false;
            // 
            // totalAmountDataGridViewTextBoxColumn
            // 
            this.totalAmountDataGridViewTextBoxColumn.DataPropertyName = "TotalAmount";
            this.totalAmountDataGridViewTextBoxColumn.HeaderText = "TOTAL AMOUNT";
            this.totalAmountDataGridViewTextBoxColumn.Name = "totalAmountDataGridViewTextBoxColumn";
            this.totalAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalAmountDataGridViewTextBoxColumn.Visible = false;
            // 
            // totalAmountWithGSTDataGridViewTextBoxColumn
            // 
            this.totalAmountWithGSTDataGridViewTextBoxColumn.DataPropertyName = "TotalAmountWithGST";
            this.totalAmountWithGSTDataGridViewTextBoxColumn.HeaderText = "GST TOTAL AMOUNT";
            this.totalAmountWithGSTDataGridViewTextBoxColumn.Name = "totalAmountWithGSTDataGridViewTextBoxColumn";
            this.totalAmountWithGSTDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalAmountWithGSTDataGridViewTextBoxColumn.Visible = false;
            // 
            // discountInPercentDataGridViewTextBoxColumn
            // 
            this.discountInPercentDataGridViewTextBoxColumn.DataPropertyName = "DiscountInPercent";
            this.discountInPercentDataGridViewTextBoxColumn.HeaderText = "DISCOUT PERCENTAGE";
            this.discountInPercentDataGridViewTextBoxColumn.Name = "discountInPercentDataGridViewTextBoxColumn";
            this.discountInPercentDataGridViewTextBoxColumn.ReadOnly = true;
            this.discountInPercentDataGridViewTextBoxColumn.Visible = false;
            // 
            // billBindingSource
            // 
            this.billBindingSource.DataMember = "Bill";
            this.billBindingSource.DataSource = this.invoiceDataSet;
            // 
            // invoiceDataSet
            // 
            this.invoiceDataSet.DataSetName = "InvoiceDataSet";
            this.invoiceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // billTableAdapter
            // 
            this.billTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.73067F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.26933F));
            this.tableLayoutPanel3.Controls.Add(this.BtnPrint, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 721);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1604, 120);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnPrint.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrint.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.ForeColor = System.Drawing.Color.White;
            this.BtnPrint.Location = new System.Drawing.Point(1347, 18);
            this.BtnPrint.Margin = new System.Windows.Forms.Padding(0, 0, 30, 30);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(227, 53);
            this.BtnPrint.TabIndex = 4;
            this.BtnPrint.Text = "PRINT EDITED INVOICE";
            this.BtnPrint.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.TotalQty, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.ActualAmount, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.TotalAmount, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtDiscount, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.BtnDiscount, 3, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.16667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.83333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1327, 120);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "TOTAL QUANTITY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(334, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 47);
            this.label2.TabIndex = 1;
            this.label2.Text = "ACTUAL AMOUNT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(665, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(325, 47);
            this.label3.TabIndex = 2;
            this.label3.Text = "TOTAL AMOUNT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalQty
            // 
            this.TotalQty.AutoSize = true;
            this.TotalQty.Dock = System.Windows.Forms.DockStyle.Top;
            this.TotalQty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalQty.Location = new System.Drawing.Point(0, 62);
            this.TotalQty.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.TotalQty.Name = "TotalQty";
            this.TotalQty.Size = new System.Drawing.Size(331, 19);
            this.TotalQty.TabIndex = 3;
            this.TotalQty.Text = "0";
            this.TotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActualAmount
            // 
            this.ActualAmount.AutoSize = true;
            this.ActualAmount.Dock = System.Windows.Forms.DockStyle.Top;
            this.ActualAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActualAmount.Location = new System.Drawing.Point(331, 62);
            this.ActualAmount.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.ActualAmount.Name = "ActualAmount";
            this.ActualAmount.Size = new System.Drawing.Size(331, 19);
            this.ActualAmount.TabIndex = 4;
            this.ActualAmount.Text = "0";
            this.ActualAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalAmount
            // 
            this.TotalAmount.AutoSize = true;
            this.TotalAmount.Dock = System.Windows.Forms.DockStyle.Top;
            this.TotalAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalAmount.Location = new System.Drawing.Point(662, 62);
            this.TotalAmount.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.Size = new System.Drawing.Size(331, 19);
            this.TotalAmount.TabIndex = 5;
            this.TotalAmount.Text = "0";
            this.TotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.ForeColor = System.Drawing.Color.DimGray;
            this.txtDiscount.Location = new System.Drawing.Point(1003, 5);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(314, 35);
            this.txtDiscount.TabIndex = 6;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BtnDiscount
            // 
            this.BtnDiscount.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnDiscount.FlatAppearance.BorderSize = 0;
            this.BtnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDiscount.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDiscount.ForeColor = System.Drawing.Color.White;
            this.BtnDiscount.Location = new System.Drawing.Point(1003, 52);
            this.BtnDiscount.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.BtnDiscount.Name = "BtnDiscount";
            this.BtnDiscount.Size = new System.Drawing.Size(314, 45);
            this.BtnDiscount.TabIndex = 7;
            this.BtnDiscount.Text = "DISCOUNT";
            this.BtnDiscount.UseVisualStyleBackColor = false;
            // 
            // Edit_Inovice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1604, 841);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Edit_Inovice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDIT INVOICE";
            this.Load += new System.EventHandler(this.Edit_Inovice_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceDataSet)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox InvoiceNumber;
        private System.Windows.Forms.Button SearchInvoice;
        private InvoiceDataSet invoiceDataSet;
        private System.Windows.Forms.BindingSource billBindingSource;
        private InvoiceDataSetTableAdapters.BillTableAdapter billTableAdapter;
        protected System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn invioceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn custNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productAmountWithGSTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalqtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmountWithGSTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountInPercentDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TotalQty;
        private System.Windows.Forms.Label ActualAmount;
        private System.Windows.Forms.Label TotalAmount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Button BtnDiscount;
    }
}