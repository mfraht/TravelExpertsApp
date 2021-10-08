using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductMaintenance.TravelExpertsModels;


namespace TravelExpertsApp
{
    public partial class FormProductSuppliers : Form
    {
#pragma warning disable CS0436 // Type conflicts with imported type
        TravelExpertsContext context = new();
#pragma warning restore CS0436 // Type conflicts with imported type


        public FormProductSuppliers()
        {
            InitializeComponent();
        }

        private void FormProductSuppliers_Load(object sender, EventArgs e)
        {
            GridViewProdSup.Columns.Clear();


            var qs = (from prodSup in context.ProductsSuppliers
                      join suppliers in context.Suppliers
                      on prodSup.SupplierId equals suppliers.SupplierId
                      join products in context.Products
                      on prodSup.ProductId equals products.ProductId
                      select new
                      {
                          ProductSupplierId = prodSup.ProductSupplierId,
                          ProductID = products.ProductId,
                          SupplierId = suppliers.SupplierId,
                      }).ToList();

            DisplayResults(qs);
        }
        private void DisplayResults(object qs)
        {
            GridViewProdSup.Columns.Clear();

            GridViewProdSup.DataSource = qs;
            
           // format the column header
           GridViewProdSup.EnableHeadersVisualStyles = false;
            GridViewProdSup.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            GridViewProdSup.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            GridViewProdSup.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // format the odd numbered rows
            GridViewProdSup.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;

            // format the first column
            GridViewProdSup.Columns[0].HeaderText = "ProductSupplierId";
            GridViewProdSup.Columns[0].Width = 100;

            // format the second column
            GridViewProdSup.Columns[1].HeaderText = "ProductId";
            GridViewProdSup.Columns[1].Width = 150;

            // format the second column
            GridViewProdSup.Columns[2].HeaderText = "SupplierId";
            GridViewProdSup.Columns[2].Width = 150;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
