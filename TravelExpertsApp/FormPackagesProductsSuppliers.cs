using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using ProductMaintenance.TravelExpertsModels;
using ProductMaintenance;


namespace TravelExpertsApp
{
    public partial class FormPackagesProductsSuppliers : Form
    {
        public FormPackagesProductsSuppliers()
        {
            InitializeComponent();
        }
        public int packageId;
        public int packagesuppId;
        //public PackagesProductsSuppliers packProdSupp { get; set; } // selected product on the main form
        TravelExpertsContext context = new TravelExpertsContext();
        private PackagesProductsSuppliers selectedpackProdSupp;
        private Packages selectedpack;


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridView1.Columns.Clear();
         

            var qs = (from PackProdSup in context.PackagesProductsSuppliers
                      join Package in context.Packages
                      on PackProdSup.PackageId equals Package.PackageId
                      join ProductsSupplier in context.ProductsSuppliers
                      on PackProdSup.ProductSupplierId equals ProductsSupplier.ProductSupplierId
                      join Product in context.Products
                      on ProductsSupplier.ProductId equals Product.ProductId
                      select new
                      {
                          PackageId = Package.PackageId,
                          ProductSupplierId = ProductsSupplier.ProductSupplierId,
                          ProductName = Product.ProdName
                      }).ToList();

            DisplayResults(qs);


        }
        private void DisplayResults(object qs)
        {
            dataGridView1.Columns.Clear();
          
            dataGridView1.DataSource = qs;

            // format the column header
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // format the odd numbered rows
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;

            // format the first column
            dataGridView1.Columns[0].HeaderText = "PackageId";
            dataGridView1.Columns[0].Width = 100;

            // format the second column
            dataGridView1.Columns[1].Width = 150;

            // format the second column
            dataGridView1.Columns[2].HeaderText = "Product Name";
            dataGridView1.Columns[2].Width = 150;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            packageId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            packagesuppId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            selectedpack = context.Packages.Find(packageId);
        }
    }
}
