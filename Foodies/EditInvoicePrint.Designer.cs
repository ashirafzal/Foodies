namespace Foodies
{
    partial class EditInvoicePrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditInvoicePrint));
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reportDocument1 = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.invoiceDataSet = new Foodies.InvoiceDataSet();
            this.billBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.billTableAdapter = new Foodies.InvoiceDataSetTableAdapters.BillTableAdapter();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1600, 841);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dataGridView1.DataSource = this.billBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 1);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1602, 12);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Visible = false;
            // 
            // invoiceDataSet
            // 
            this.invoiceDataSet.DataSetName = "InvoiceDataSet";
            this.invoiceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // billBindingSource
            // 
            this.billBindingSource.DataMember = "Bill";
            this.billBindingSource.DataSource = this.invoiceDataSet;
            // 
            // billTableAdapter
            // 
            this.billTableAdapter.ClearBeforeFill = true;
            // 
            // invioceIDDataGridViewTextBoxColumn
            // 
            this.invioceIDDataGridViewTextBoxColumn.DataPropertyName = "InvioceID";
            this.invioceIDDataGridViewTextBoxColumn.HeaderText = "InvioceID";
            this.invioceIDDataGridViewTextBoxColumn.Name = "invioceIDDataGridViewTextBoxColumn";
            // 
            // custIDDataGridViewTextBoxColumn
            // 
            this.custIDDataGridViewTextBoxColumn.DataPropertyName = "CustID";
            this.custIDDataGridViewTextBoxColumn.HeaderText = "CustID";
            this.custIDDataGridViewTextBoxColumn.Name = "custIDDataGridViewTextBoxColumn";
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            // 
            // custNameDataGridViewTextBoxColumn
            // 
            this.custNameDataGridViewTextBoxColumn.DataPropertyName = "CustName";
            this.custNameDataGridViewTextBoxColumn.HeaderText = "CustName";
            this.custNameDataGridViewTextBoxColumn.Name = "custNameDataGridViewTextBoxColumn";
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            // 
            // productQuantityDataGridViewTextBoxColumn
            // 
            this.productQuantityDataGridViewTextBoxColumn.DataPropertyName = "ProductQuantity";
            this.productQuantityDataGridViewTextBoxColumn.HeaderText = "ProductQuantity";
            this.productQuantityDataGridViewTextBoxColumn.Name = "productQuantityDataGridViewTextBoxColumn";
            // 
            // productRateDataGridViewTextBoxColumn
            // 
            this.productRateDataGridViewTextBoxColumn.DataPropertyName = "ProductRate";
            this.productRateDataGridViewTextBoxColumn.HeaderText = "ProductRate";
            this.productRateDataGridViewTextBoxColumn.Name = "productRateDataGridViewTextBoxColumn";
            // 
            // productAmountDataGridViewTextBoxColumn
            // 
            this.productAmountDataGridViewTextBoxColumn.DataPropertyName = "ProductAmount";
            this.productAmountDataGridViewTextBoxColumn.HeaderText = "ProductAmount";
            this.productAmountDataGridViewTextBoxColumn.Name = "productAmountDataGridViewTextBoxColumn";
            // 
            // productAmountWithGSTDataGridViewTextBoxColumn
            // 
            this.productAmountWithGSTDataGridViewTextBoxColumn.DataPropertyName = "ProductAmountWithGST";
            this.productAmountWithGSTDataGridViewTextBoxColumn.HeaderText = "ProductAmountWithGST";
            this.productAmountWithGSTDataGridViewTextBoxColumn.Name = "productAmountWithGSTDataGridViewTextBoxColumn";
            // 
            // orderTimeDataGridViewTextBoxColumn
            // 
            this.orderTimeDataGridViewTextBoxColumn.DataPropertyName = "OrderTime";
            this.orderTimeDataGridViewTextBoxColumn.HeaderText = "OrderTime";
            this.orderTimeDataGridViewTextBoxColumn.Name = "orderTimeDataGridViewTextBoxColumn";
            // 
            // orderDateDataGridViewTextBoxColumn
            // 
            this.orderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate";
            this.orderDateDataGridViewTextBoxColumn.HeaderText = "OrderDate";
            this.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn";
            // 
            // totalqtyDataGridViewTextBoxColumn
            // 
            this.totalqtyDataGridViewTextBoxColumn.DataPropertyName = "Totalqty";
            this.totalqtyDataGridViewTextBoxColumn.HeaderText = "Totalqty";
            this.totalqtyDataGridViewTextBoxColumn.Name = "totalqtyDataGridViewTextBoxColumn";
            // 
            // actualAmountDataGridViewTextBoxColumn
            // 
            this.actualAmountDataGridViewTextBoxColumn.DataPropertyName = "ActualAmount";
            this.actualAmountDataGridViewTextBoxColumn.HeaderText = "ActualAmount";
            this.actualAmountDataGridViewTextBoxColumn.Name = "actualAmountDataGridViewTextBoxColumn";
            // 
            // totalAmountDataGridViewTextBoxColumn
            // 
            this.totalAmountDataGridViewTextBoxColumn.DataPropertyName = "TotalAmount";
            this.totalAmountDataGridViewTextBoxColumn.HeaderText = "TotalAmount";
            this.totalAmountDataGridViewTextBoxColumn.Name = "totalAmountDataGridViewTextBoxColumn";
            // 
            // totalAmountWithGSTDataGridViewTextBoxColumn
            // 
            this.totalAmountWithGSTDataGridViewTextBoxColumn.DataPropertyName = "TotalAmountWithGST";
            this.totalAmountWithGSTDataGridViewTextBoxColumn.HeaderText = "TotalAmountWithGST";
            this.totalAmountWithGSTDataGridViewTextBoxColumn.Name = "totalAmountWithGSTDataGridViewTextBoxColumn";
            // 
            // discountInPercentDataGridViewTextBoxColumn
            // 
            this.discountInPercentDataGridViewTextBoxColumn.DataPropertyName = "DiscountInPercent";
            this.discountInPercentDataGridViewTextBoxColumn.HeaderText = "DiscountInPercent";
            this.discountInPercentDataGridViewTextBoxColumn.Name = "discountInPercentDataGridViewTextBoxColumn";
            // 
            // EditInvoicePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 841);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.crystalReportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditInvoicePrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRINT EDITED INVOICE";
            this.Load += new System.EventHandler(this.EditInvoicePrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private InvoiceDataSet invoiceDataSet;
        private System.Windows.Forms.BindingSource billBindingSource;
        private InvoiceDataSetTableAdapters.BillTableAdapter billTableAdapter;
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
    }
}