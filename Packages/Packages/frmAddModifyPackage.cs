using System;
using System.Linq;
using System.Windows.Forms;
using ProductMaintenance.TravelExpertsModels;

namespace PackageMaintenance
{
    public partial class frmAddModifyPackage : Form
    {
        public Packages Package { get; set; } // selected product on the main form
        public PackagesProductsSuppliers packProdSupp { get; set; } // selected product on the main form
        
        public bool AddPackage { get; set; } // flag that distinguishes Add from Modify
        public int productSupplierId { get; set; } // selected product on the main form
        public int packageId;
        
        ProductsSuppliers currentProdSup;
        TravelExpertsContext context;    // The DB context
        Products currentProduct;   // To hold the current customer information
        
        public frmAddModifyPackage()
        {
            InitializeComponent();
        }

        private void frmAddModifyPackage_Load(object sender, EventArgs e)
        {
            context = new TravelExpertsContext();    // Instantiate the context
            currentProduct = context.Products.First();   // Load the first Product
            Object[] cIds = context.Products.Select(c => (Object)c.ProdName).ToArray();
            productNameBox.Items.AddRange(cIds);
            if (AddPackage)
            {
                this.Text = "Add Package";
                txtPackageId.ReadOnly = true;  // allow entry of new Package code

                var lastPack = context.Packages
                   .AsEnumerable()
                   .Last();
                packageId = lastPack.PackageId + 1;
                txtPackageId.Text = packageId.ToString();

            }
            else
            {
                this.Text = "Modify Package";
                txtPackageId.ReadOnly = true;   // can't change existing Package code
                this.DisplayPackages();
            }
        }

        private void DisplayPackages()
        {
            txtPackageId.Text = Package.PackageId.ToString();
            txtPkgName.Text = Package.PkgName;
            txtPkgStartDate.Text = Package.PkgStartDate.ToString();
            txtPkgEndDate.Text = Package.PkgEndDate.ToString();
            txtPkgDescription.Text = Package.PkgDesc;
            txtPkgBasePrice.Text = Package.PkgBasePrice.ToString();
            txtAgentCommission.Text = Package.PkgAgencyCommission.ToString();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (AddPackage)
                {
                    // initialize the Package property with new Packages object
                    this.Package = new Packages();
                    
                }
                this.LoadPackageData();
                this.DialogResult = DialogResult.OK;
            }
        }

        //Package Name and Package Name and Description cannot be null
        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";
            errorMessage += Validator.IsPresent(txtPackageId.Text, txtPackageId.Tag.ToString());
            errorMessage += Validator.IsPresent(txtPkgName.Text, txtPkgName.Tag.ToString());
            errorMessage += Validator.IsPresent(txtPkgDescription.Text, txtPkgDescription.Tag.ToString());
            errorMessage += Validator.IsDecimal(txtPkgBasePrice.Text, txtPkgBasePrice.Tag.ToString());
            errorMessage += Validator.IsDate(txtPkgStartDate.Text, txtPkgStartDate.Tag.ToString());
            if (errorMessage != "")       {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        private void LoadPackageData()
        {
            Package.PkgName = txtPkgName.Text;
            Package.PkgStartDate = Convert.ToDateTime(txtPkgStartDate.Text);
            Package.PkgEndDate = Convert.ToDateTime(txtPkgEndDate.Text);
            Package.PkgDesc = txtPkgDescription.Text;
            Package.PkgBasePrice = Convert.ToDecimal(txtPkgBasePrice.Text);
            Package.PkgAgencyCommission = Convert.ToDecimal(txtAgentCommission.Text);
        }

        private void productNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Products prod = (from p in context.Products
                             where p.ProdName == productNameBox.SelectedItem.ToString()
                             select p).Single();
            currentProduct = context.Products.Find(prod.ProductId);   // Load Product ID=1
            int prodSupId = Convert.ToInt32(currentProduct.ProductId);
            currentProdSup = context.ProductsSuppliers.Find(prodSupId);
            if (currentProdSup == null) return;
            productSupplierId = currentProdSup.ProductSupplierId;

        }

        
    }
}