using System;
using System.Windows.Forms;
using ProductMaintenance.TravelExpertsModels;

namespace TravelExpertsApp
{
    public partial class frmAddModifyPackProdSup : Form
    {
        public Products Product { get; set; }
        public bool AddProduct { get; set; }

        public frmAddModifyPackProdSup()
        {
            InitializeComponent();
        }

        private void frmAddModifyProduct_Load(object sender, EventArgs e)
        {
            //if (AddProduct)
            //{
            //    this.Text = "Add Product";
            //    txtCode.ReadOnly = false;  // allow entry of new product code
            //}
            //else
            //{
            //    this.Text = "Modify Product";
            //    txtCode.ReadOnly = true;   // can't change existing product code
            //    this.DisplayProduct();
            //}
        }

        //private void DisplayProduct()
        //{
        //    txtCode.Text = Product.ProductCode;
        //    txtName.Text = Product.Name;
        //    txtVersion.Text = Product.Version.ToString("N2");
        //    txtDate.Text = Product.ReleaseDate.ToShortDateString();
        //}

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //if (IsValidData())
            //{
            //    if (AddProduct)
            //    {
            //        // initialize the Product property with new Products object
            //        this.Product = new Products();
            //    }
            //    this.LoadProductData();
            //    this.DialogResult = DialogResult.OK;
            //}
        }

        //private bool IsValidData()
        //{
        //    bool success = true;
        //    string errorMessage = "";

        //    errorMessage += Validator.IsPresent(txtCode.Text, txtCode.Tag.ToString());
        //    errorMessage += Validator.IsPresent(txtName.Text, txtName.Tag.ToString());
        //    errorMessage += Validator.IsDecimal(txtVersion.Text, txtVersion.Tag.ToString());
        //    errorMessage += Validator.IsDate(txtDate.Text, txtDate.Tag.ToString());

        //    if (errorMessage != "")
        //    {
        //        success = false;
        //        MessageBox.Show(errorMessage, "Entry Error");
        //    }
        //    return success;
        //}

        private void LoadProductData()
        {
            //Product.ProductCode = txtCode.Text;
            //Product.Name = txtName.Text;
            //Product.Version = Convert.ToDecimal(txtVersion.Text);
            //Product.ReleaseDate = Convert.ToDateTime(txtDate.Text);
            ////Product.OnHandQuantity = Convert.ToInt32(txtOnHand.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}