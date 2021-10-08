using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductMaintenance.Models;

namespace SupplierMaintenance
{
    public partial class frmSuppliers : Form
    {
        public frmSuppliers()
        {
            InitializeComponent();
        }

        private TravelExpertsContext context = new TravelExpertsContext();
        private ProductMaintenance.Models.Suppliers selectedSupplier = null;

        private void frmSupplierMaintenance_Load(object sender, EventArgs e)
        {
            DisplaySuppliers();
        }

        private void DisplaySuppliers ()
        {
            dgvSuppliers.Columns.Clear();
            var Suppliers = context.Suppliers
                .OrderBy(p => p.SupplierId)
                .Select(p => new { p.SupplierId, p.SupName})
                .ToList();

            dgvSuppliers.DataSource = Suppliers;

            // format the column header
            dgvSuppliers.EnableHeadersVisualStyles = false;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvSuppliers.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // format the odd numbered rows
            dgvSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;

            // format the first column
            dgvSuppliers.Columns[0].HeaderText = "Supplier Id";
            dgvSuppliers.Columns[0].Width = 100;

            // format the second column
            dgvSuppliers.Columns[1].Width = 200;

        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                int supplierId = Convert.ToInt32(dgvSuppliers.Rows[e.RowIndex].Cells[0].Value);
                selectedSupplier = context.Suppliers.Find(supplierId);
           
        }

        private void ModifySupplier()
        {
            var addModifySupplierForm = new ProductMaintenance.FrmAddModifySupplier() { 
                AddSupplier = false, 
                Supplier = selectedSupplier
            };
            DialogResult result = addModifySupplierForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    selectedSupplier = addModifySupplierForm.Supplier;
                    context.SaveChanges();
                    DisplaySuppliers();
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

        private void DeleteSupplier()
        {
            DialogResult result =
                MessageBox.Show($"Delete {selectedSupplier.SupplierId}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    context.Suppliers.Remove(selectedSupplier);
                    context.SaveChanges(true);
                    DisplaySuppliers();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addModifySupplierForm = new ProductMaintenance.FrmAddModifySupplier() { 
                AddSupplier = true 
            };
            DialogResult result = addModifySupplierForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    selectedSupplier = addModifySupplierForm.Supplier;
                    context.Suppliers.Add(selectedSupplier);
                    context.SaveChanges();
                    DisplaySuppliers();
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

        private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();

            var state = context.Entry(selectedSupplier).State;
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
            this.DisplaySuppliers();
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
            if (selectedSupplier != null)
                ModifySupplier();
        }
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (selectedSupplier != null)
                DeleteSupplier();
        }

    }
}
