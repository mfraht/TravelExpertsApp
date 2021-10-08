
namespace TravelExpertsApp
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSuppliers = new System.Windows.Forms.Button();
            this.buttonProducts = new System.Windows.Forms.Button();
            this.buttonPackages = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonProdSupp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(97, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(719, 81);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSuppliers
            // 
            this.buttonSuppliers.BackColor = System.Drawing.Color.LightSalmon;
            this.buttonSuppliers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSuppliers.Location = new System.Drawing.Point(342, 178);
            this.buttonSuppliers.Name = "buttonSuppliers";
            this.buttonSuppliers.Size = new System.Drawing.Size(179, 144);
            this.buttonSuppliers.TabIndex = 9;
            this.buttonSuppliers.Text = "Suppliers";
            this.buttonSuppliers.UseVisualStyleBackColor = false;
            this.buttonSuppliers.Click += new System.EventHandler(this.buttonSuppliers_Click);
            // 
            // buttonProducts
            // 
            this.buttonProducts.BackColor = System.Drawing.Color.MistyRose;
            this.buttonProducts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonProducts.Location = new System.Drawing.Point(36, 178);
            this.buttonProducts.Name = "buttonProducts";
            this.buttonProducts.Size = new System.Drawing.Size(183, 144);
            this.buttonProducts.TabIndex = 8;
            this.buttonProducts.Text = "Products";
            this.buttonProducts.UseVisualStyleBackColor = false;
            this.buttonProducts.Click += new System.EventHandler(this.buttonProducts_Click);
            // 
            // buttonPackages
            // 
            this.buttonPackages.BackColor = System.Drawing.Color.Moccasin;
            this.buttonPackages.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPackages.Location = new System.Drawing.Point(663, 178);
            this.buttonPackages.Name = "buttonPackages";
            this.buttonPackages.Size = new System.Drawing.Size(179, 144);
            this.buttonPackages.TabIndex = 10;
            this.buttonPackages.Text = "Packages";
            this.buttonPackages.UseVisualStyleBackColor = false;
            this.buttonPackages.Click += new System.EventHandler(this.buttonPackages_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.Location = new System.Drawing.Point(312, 363);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(227, 48);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Moccasin;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(632, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 46);
            this.button1.TabIndex = 12;
            this.button1.Text = "Packages Products Suppliers";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonProdSupp
            // 
            this.buttonProdSupp.BackColor = System.Drawing.Color.MistyRose;
            this.buttonProdSupp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonProdSupp.Location = new System.Drawing.Point(14, 365);
            this.buttonProdSupp.Name = "buttonProdSupp";
            this.buttonProdSupp.Size = new System.Drawing.Size(242, 46);
            this.buttonProdSupp.TabIndex = 13;
            this.buttonProdSupp.Text = "Products Suppliers";
            this.buttonProdSupp.UseVisualStyleBackColor = false;
            this.buttonProdSupp.Click += new System.EventHandler(this.buttonProdSupp_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.buttonProdSupp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonPackages);
            this.Controls.Add(this.buttonSuppliers);
            this.Controls.Add(this.buttonProducts);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Travel Experts";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSuppliers;
        private System.Windows.Forms.Button buttonProducts;
        private System.Windows.Forms.Button buttonPackages;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonProdSupp;
    }
}