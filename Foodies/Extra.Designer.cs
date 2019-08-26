namespace Foodies
{
    partial class Extra
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
            this.Category = new System.Windows.Forms.Panel();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.SearchCategory = new System.Windows.Forms.Button();
            this.txtSearchCategory = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.Category.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Category
            // 
            this.Category.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Category.Controls.Add(this.dgv1);
            this.Category.Controls.Add(this.SearchCategory);
            this.Category.Controls.Add(this.txtSearchCategory);
            this.Category.Controls.Add(this.panel1);
            this.Category.Location = new System.Drawing.Point(9, 9);
            this.Category.Margin = new System.Windows.Forms.Padding(0);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(1334, 687);
            this.Category.TabIndex = 3;
            this.Category.Visible = false;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.GridColor = System.Drawing.Color.Black;
            this.dgv1.Location = new System.Drawing.Point(22, 107);
            this.dgv1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 20);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.Size = new System.Drawing.Size(1293, 543);
            this.dgv1.TabIndex = 5;
            // 
            // SearchCategory
            // 
            this.SearchCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchCategory.BackColor = System.Drawing.Color.RoyalBlue;
            this.SearchCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchCategory.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchCategory.ForeColor = System.Drawing.Color.White;
            this.SearchCategory.Location = new System.Drawing.Point(1064, 57);
            this.SearchCategory.Margin = new System.Windows.Forms.Padding(0);
            this.SearchCategory.Name = "SearchCategory";
            this.SearchCategory.Size = new System.Drawing.Size(254, 39);
            this.SearchCategory.TabIndex = 4;
            this.SearchCategory.Text = "SEARCH CATEGORY";
            this.SearchCategory.UseVisualStyleBackColor = false;
            // 
            // txtSearchCategory
            // 
            this.txtSearchCategory.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCategory.Location = new System.Drawing.Point(22, 54);
            this.txtSearchCategory.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.txtSearchCategory.Name = "txtSearchCategory";
            this.txtSearchCategory.Size = new System.Drawing.Size(1031, 38);
            this.txtSearchCategory.TabIndex = 3;
            this.txtSearchCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1334, 39);
            this.panel1.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Teal;
            this.label14.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(-6, 0);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.label14.Size = new System.Drawing.Size(159, 29);
            this.label14.TabIndex = 2;
            this.label14.Text = "CATEGORIES";
            // 
            // Extra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1409, 812);
            this.Controls.Add(this.Category);
            this.Name = "Extra";
            this.Text = "Extra";
            this.Category.ResumeLayout(false);
            this.Category.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Category;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button SearchCategory;
        private System.Windows.Forms.TextBox txtSearchCategory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
    }
}