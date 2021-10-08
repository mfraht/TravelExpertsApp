namespace ProductMaintenance
{
    partial class frmAddModifyProduct
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(372, 144);
            this.txtName.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(548, 47);
            this.txtName.TabIndex = 23;
            this.txtName.Tag = "Description";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(372, 33);
            this.txtId.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.txtId.MaxLength = 7;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(261, 47);
            this.txtId.TabIndex = 22;
            this.txtId.Tag = "Code";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(740, 508);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(249, 72);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "&Cancel";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(372, 508);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(249, 72);
            this.btnAccept.TabIndex = 27;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(106, 150);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 41);
            this.label2.TabIndex = 29;
            this.label2.Text = "Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 41);
            this.label1.TabIndex = 28;
            this.label1.Text = "Product Id:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmAddModifyProduct
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1175, 617);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "frmAddModifyProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.frmAddModifyProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}