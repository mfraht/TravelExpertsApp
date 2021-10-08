using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProductMaintenance.Models;

namespace ProductMaintenance
{
    public partial class FrmAddModifySupplier : Form
    {
        public Suppliers Supplier { get; set; }
        public bool AddSupplier { get; set; }

        public FrmAddModifySupplier()
        {
            InitializeComponent();
        }

        private void FrmAddModifySupplier_Load(object sender, EventArgs e)
        {
            if (AddSupplier)
            {
                this.Text = "Add Supplier";
                txtSupplierId.ReadOnly = true;  // allow entry of new supplier code
            }
            else
            {
                this.Text = "Modify Supplier";
                txtSupplierId.ReadOnly = true;   // can't change existing supplier code
                this.DisplaySupplier();
            }
        }

        private void DisplaySupplier()
        {
            txtSupplierId.Text = Supplier.SupplierId.ToString();
            txtSupplierName.Text = Supplier.SupName;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (AddSupplier)
                {
                    // initialize the Supplier property with new Suppliers object
                    this.Supplier = new Suppliers();
                }
                this.LoadSupplierData();
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            //errorMessage += Validator.IsInt32(txtSupplierId.Text, txtSupplierId.Tag.ToString());
            //errorMessage += Validator.IsPresent(txtSupplierName.Text, txtSupplierName.Tag.ToString());
          

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        private void LoadSupplierData()
        {
            //Supplier.SupplierId = Convert.ToInt32(txtSupplierId.Text);
            Supplier.SupName = txtSupplierName.Text;
            
        }
    }
}
