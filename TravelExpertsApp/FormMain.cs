using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
