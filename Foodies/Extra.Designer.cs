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
            this.SuspendLayout();
            // 
            // Category
            // 
            this.Category.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Category.Location = new System.Drawing.Point(9, 9);
            this.Category.Margin = new System.Windows.Forms.Padding(0);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(1334, 687);
            this.Category.TabIndex = 3;
            this.Category.Visible = false;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Category;
    }
}