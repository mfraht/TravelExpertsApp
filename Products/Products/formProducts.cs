using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductMaintenance.TravelExpertsModel;

namespace ProductMaintenance
{
    public partial class formProducts : Form
    {
        public formProducts()
        {
            InitializeComponent();
        }

        private TravelExpertsContext context = new TravelExpertsContext();
        private Products selectedProduct = null;

        private void frmProductMaintenance_Load(object sender, EventArgs e)
        {
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            dgvProducts.Columns.Clear();
            var products = context.Products
                .OrderBy(p => p.ProductId)
                .Select(p => new { p.ProductId, p.ProdName })
                .ToList();

            dgvProducts.DataSource = products;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue;
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // format the odd numbered rows
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.DeepSkyBlue;

            // format the first column
            dgvProducts.Columns[0].HeaderText = "Product Id";
            dgvProducts.Columns[0].Width = 100;

            // format the second column
            dgvProducts.Columns[1].Width = 150;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int prodId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells[0].Value);
            selectedProduct = context.Products.Find(prodId);
        }
        //Agents can edit products
        private void ModifyProduct()
        {
            var addModifyProductForm = new frmAddModifyProduct()
            {
                AddProduct = false,
                Product = selectedProduct
            };
            DialogResult result = addModifyProductForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    selectedProduct = addModifyProductForm.Product;
                    context.SaveChanges();
                    DisplayProducts();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }
        //Agents can delete products
        private void DeleteProduct()
        {
            DialogResult result =
                MessageBox.Show($"Delete {selectedProduct.ProductId}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    RemoveProdSup();

                    context.Products.Remove(selectedProduct);
                    context.SaveChanges(true);
                    DisplayProducts();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }
        //Agents can remove product_suppliers
        private void RemoveProdSup()
        {
            var qs = (from prodSup in context.ProductsSuppliers
                      join products in context.Products
                      on prodSup.ProductId equals products.ProductId
                      join suppliers in context.Suppliers
                      on prodSup.SupplierId equals suppliers.SupplierId
                      where products.ProductId == selectedProduct.ProductId
                      select new
                      {
                          ProductSupplierId = prodSup.ProductSupplierId,
                          ProductID = products.ProductId,
                          SupplierId = suppliers.SupplierId
                      }).Single();
            ProductsSuppliers ProdSup = new ProductsSuppliers();
            ProdSup.ProductSupplierId = qs.ProductSupplierId;
            ProdSup.SupplierId = qs.SupplierId;
            ProdSup.ProductId = qs.ProductID;
            context.ProductsSuppliers.Remove(ProdSup);
            context.SaveChanges();
        }
        //Agents can add products
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addModifyProductForm = new frmAddModifyProduct()
            {
                AddProduct = true
            };
            DialogResult result = addModifyProductForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    selectedProduct = addModifyProductForm.Product;
                    context.Products.Add(selectedProduct);
                    context.SaveChanges();
                    UpdateProdSupp(selectedProduct.ProductId, addModifyProductForm.supplierId);
                    DisplayProducts();
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        //Agents can add/edit product_suppliers
        public void UpdateProdSupp(int productId, int supplierId)
        {
            ProductsSuppliers prodSup = new ProductsSuppliers();

            prodSup.ProductId = productId;
            prodSup.SupplierId = supplierId;
            context.ProductsSuppliers.Add(prodSup);
            context.SaveChanges();
            context.UpdateRange(prodSup);
            this.Close();
        }

        private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();

            var state = context.Entry(selectedProduct).State;
            if (state == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted that product.",
                    "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated that product.\n" +
                    "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }
            this.DisplayProducts();
        }

        private void HandleDatabaseError(DbUpdateException ex)
        {
            string errorMessage = "";
            var sqlException = (SqlException)ex.InnerException;
            foreach (SqlError error in sqlException.Errors)
            {
                errorMessage += "ERROR CODE:  " + error.Number + " " +
                                error.Message + "\n";
            }
            MessageBox.Show(errorMessage);
        }

        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ModifyBtn_Click(object sender, EventArgs e)
        {
            if (selectedProduct != null)
                ModifyProduct();
        }
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (selectedProduct != null)
                DeleteProduct();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
