// Workshop3 - Threaded Project for OOSD (PROJ-009-004)
// Travel Experts: Desktop application C#.NET
// Date: October 8, 2021
// Version: 1.0
/*
This application is built using C# as a desktop application. The navigation is user-friendly. 
The application is functionality so that the user maintain the data in the tables: Packages, 
Products, Products_suppliers, Suppliers, Packages_products_suppliers 
*/
using System;
using System.Windows.Forms;

namespace TravelExpertsApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonProducts_Click(object sender, EventArgs e)
        {
            var formProducts = new ProductMaintenance.formProducts();

            formProducts.ShowDialog();
        }

        private void buttonSuppliers_Click(object sender, EventArgs e)
        {
            var frmSuppliers = new SupplierMaintenance.frmSuppliers();

            frmSuppliers.ShowDialog();
        }

        private void buttonPackages_Click(object sender, EventArgs e)
        {
            var frmPackages = new PackageMaintenance.frmPackages();
            frmPackages.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var FormPackagesProductsSuppliers = new FormPackagesProductsSuppliers();
            FormPackagesProductsSuppliers.ShowDialog();
        }

        private void buttonProdSupp_Click(object sender, EventArgs e)
        {
            var FormProductSuppliers = new FormProductSuppliers();
            FormProductSuppliers.ShowDialog();
        }
    }
}
