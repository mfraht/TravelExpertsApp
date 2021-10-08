
namespace TravelExpertsApp
{
    partial class FormProductSuppliers
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
            this.btnExit = new System.Windows.Forms.Button();
            this.GridViewProdSup = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProdSup)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.Location = new System.Drawing.Point(203, 487);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 35);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "&Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // GridViewProdSup
            // 
            this.GridViewProdSup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewProdSup.Location = new System.Drawing.Point(12, 12);
            this.GridViewProdSup.Name = "GridViewProdSup";
            this.GridViewProdSup.RowHeadersWidth = 51;
            this.GridViewProdSup.RowTemplate.Height = 29;
            this.GridViewProdSup.Size = new System.Drawing.Size(548, 456);
            this.GridViewProdSup.TabIndex = 6;
            // 
            // FormProductSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 536);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.GridViewProdSup);
            this.Name = "FormProductSuppliers";
            this.Text = "FormProductSuppliers";
            this.Load += new System.EventHandler(this.FormProductSuppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProdSup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView GridViewProdSup;
    }
}