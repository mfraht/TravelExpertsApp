using System;
using System.Linq;
using System.Windows.Forms;
using ProductMaintenance.TravelExpertsModel;

namespace ProductMaintenance
{
    public partial class frmAddModifyProduct : Form
    {
        public Products Product { get; set; }
        public bool AddProduct { get; set; }
        public int supplierId { get; set; }
        TravelExpertsContext context;    // The DB context
        Suppliers currentSupplier;   // To hold the current customer information

        public frmAddModifyProduct()
        {
            InitializeComponent();
        }

        private void frmAddModifyProduct_Load(object sender, EventArgs e)
        {
            context = new TravelExpertsContext();    // Instantiate the context
            currentSupplier = context.Suppliers.First();   // Load the first Product
            Object[] cIds = context.Suppliers.Select(c => (Object)c.SupName).ToArray();

            BoxSupplier.Items.AddRange(cIds);


            if (AddProduct)
            {
                this.Text = "Add Product";

            }
            else
            {
                this.Text = "Modify Product";
                this.DisplayProduct();
            }
        }

        private void DisplayProduct()
        {
            //txtCode.Text = Product.ProductId.ToString();
            txtName.Text = Product.ProdName;

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (AddProduct)
                {
                    // initialize the Product property with new Products object
                    this.Product = new Products();
                }
                this.LoadProductData();
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtName.Text, txtName.Tag.ToString());

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        private void LoadProductData()
        {
            //Product.ProductId = Convert.ToInt32(txtCode.Text);
            Product.ProdName = txtName.Text;

            //Product.OnHandQuantity = Convert.ToInt32(txtOnHand.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void BoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Suppliers supplier = (from p in context.Suppliers
                                  where p.SupName == BoxSupplier.SelectedItem.ToString()
                                  select p).Single();
            supplierId = supplier.SupplierId;
            currentSupplier = context.Suppliers.Find(supplier.SupplierId);   // Load Product ID=1

        }
    }
}