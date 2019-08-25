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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Product = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.Product.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Product);
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1332, 679);
            this.panel1.TabIndex = 2;
            // 
            // Product
            // 
            this.Product.BackColor = System.Drawing.Color.White;
            this.Product.Controls.Add(this.panel2);
            this.Product.Location = new System.Drawing.Point(-1, -1);
            this.Product.Margin = new System.Windows.Forms.Padding(0);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(1330, 677);
            this.Product.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1328, 39);
            this.panel2.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Teal;
            this.label15.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(10, 6, 0, 0);
            this.label15.Size = new System.Drawing.Size(128, 28);
            this.label15.TabIndex = 2;
            this.label15.Text = "PRODUCTS";
            // 
            // Extra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1409, 812);
            this.Controls.Add(this.panel1);
            this.Name = "Extra";
            this.Text = "Extra";
            this.panel1.ResumeLayout(false);
            this.Product.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Product;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label15;
    }
}