using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductMaintenance.TravelExpertsModels;

/// <summary>
/// To Create a Windows Form Application "PackageMaintenance" that let the user maintain packages.
/// Author:      Sunday Emmanuel 

/// </summary>

namespace PackageMaintenance
{
    public partial class frmPackages : Form
    {
        public int packageId;
        public int packagesuppId;

        public frmPackages()
        {
            InitializeComponent();
        }

        private TravelExpertsContext context = new TravelExpertsContext();
        private Packages selectedPackage;

        private void frmPackageMaintenance_Load(object sender, EventArgs e)
        {
            DisplayPackages();
        }
        //The linking between tables should be done by selecting from controls, not entering foreign keys.
        private void DisplayPackages ()
        {
            dgvPackages.Columns.Clear(); // clears old content
            var packages = context.Packages
                .OrderBy(p => p.PackageId)
                .Select(p => new { p.PackageId, p.PkgName, p.PkgStartDate, 
                    p.PkgEndDate, p.PkgDesc, p.PkgBasePrice, p.PkgAgencyCommission })
                .ToList();

            dgvPackages.DataSource = packages;


            // format the column header
            dgvPackages.EnableHeadersVisualStyles = false;
            dgvPackages.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvPackages.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            dgvPackages.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // format the odd numbered rows
            dgvPackages.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;

            // format the first column
            dgvPackages.Columns[0].HeaderText = "PKg ID";
            dgvPackages.Columns[0].Width = 50;

            // format the second column
            dgvPackages.Columns[1].HeaderText = "PKg Name";
            dgvPackages.Columns[1].Width = 150;

            // format the third column
            dgvPackages.Columns[2].HeaderText = "PKg Start Date";
            dgvPackages.Columns[2].Width = 100;

            // format the fourth column
            dgvPackages.Columns[3].HeaderText = "PKg End Date";
            dgvPackages.Columns[3].Width = 100;

            // format the fifth column
            dgvPackages.Columns[4].HeaderText = "PKg Description";
            dgvPackages.Columns[4].Width = 250;

            // format the sixth column
            dgvPackages.Columns[5].HeaderText = "PKg Base Price";
            dgvPackages.Columns[5].DefaultCellStyle.Format = "c2";
            dgvPackages.Columns[5].Width = 100;

            // format the seventh column
            dgvPackages.Columns[6].HeaderText = "Agency Commission";
            dgvPackages.Columns[6].DefaultCellStyle.Format = "c2";
            dgvPackages.Columns[6].Width = 100;

           
        }

        private void dgvPackages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                int packageId = Convert.ToInt32(dgvPackages.Rows[e.RowIndex].Cells[0].Value);
                selectedPackage = context.Packages.Find(packageId);
        }

        // Modifying the packages
        private void ModifyPackage()
        {
            var addModifyPackageForm = new frmAddModifyPackage() { 
                AddPackage = false, 
                Package = selectedPackage
            };
            DialogResult result = addModifyPackageForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    selectedPackage = addModifyPackageForm.Package;
                    //Checking if Agency Commission is greater than Base Price
                    if (selectedPackage.PkgAgencyCommission > selectedPackage.PkgBasePrice)
                    {
                        MessageBox.Show("Agency Commission couldn't be greater than Base Price");
                        addModifyPackageForm.ShowDialog();
                    }
                    //Checking if Package End Date must be later than Package Start Date or not
                    if (selectedPackage.PkgStartDate > selectedPackage.PkgEndDate)
                    {
                        MessageBox.Show("Start Date couldn't be later than End Date");
                        addModifyPackageForm.ShowDialog();
                    }
                    context.SaveChanges();
                    DisplayPackages();
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


        // Removing packages from the table
        private void RemovePackage()
        {
            DialogResult result =
                MessageBox.Show($"Remove {selectedPackage.PkgName}?",
                "Confirm Remove", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    RemovePackageProdSup();

                    context.Packages.Remove(selectedPackage);
                    context.SaveChanges(true);
                    MessageBox.Show($"{selectedPackage.PkgName} is Deleted");
                    DisplayPackages();
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

        //Agents can delete product_suppliers
        private void RemovePackageProdSup()
        {
            var qs = (from PackProdSup in context.PackagesProductsSuppliers
                      join Package in context.Packages
                      on PackProdSup.PackageId equals Package.PackageId
                      where Package.PackageId == selectedPackage.PackageId
                      select new
                      {
                          PackageId = Package.PackageId,
                          ProductSupplierId = PackProdSup.ProductSupplierId,
                          //ProductName = Product.ProdName
                      }).Single();
            PackagesProductsSuppliers PackageProdSup = new PackagesProductsSuppliers();
            PackageProdSup.ProductSupplierId = qs.ProductSupplierId;
            PackageProdSup.PackageId = qs.PackageId;
            context.PackagesProductsSuppliers.Remove(PackageProdSup);
            context.SaveChanges();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addModifyPackageForm = new frmAddModifyPackage() { 
                AddPackage = true 
            };
            DialogResult result = addModifyPackageForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    selectedPackage = addModifyPackageForm.Package;
                    //Checking if Agency Commission is greater than Base Price
                    if (selectedPackage.PkgAgencyCommission > selectedPackage.PkgBasePrice)
                    {
                        MessageBox.Show("Agency Commission couldn't be greater than Base Price");
                        addModifyPackageForm.ShowDialog();
                    }
                    //Checking if Package End Date must be later than Package Start Date or not
                    if (selectedPackage.PkgStartDate > selectedPackage.PkgEndDate)
                    {
                        MessageBox.Show("Start Date couldn't be later than End Date");
                        addModifyPackageForm.ShowDialog();
                    }
                    context.Packages.Add(selectedPackage);
                    context.SaveChanges();
                    UpdatePackage(selectedPackage.PackageId, addModifyPackageForm.productSupplierId);
                    DisplayPackages();
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

            var state = context.Entry(selectedPackage).State;
            if (state == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted that package.",
                    "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated that package.\n" +
                    "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }
            this.DisplayPackages();
        }
        //Agents can edit package_product_suppliers
        public void UpdatePackage(int packageId, int productSupplierId)
        {
            PackagesProductsSuppliers packProdSup = new PackagesProductsSuppliers();

            packProdSup.ProductSupplierId = productSupplierId;
            packProdSup.PackageId = packageId;
            context.PackagesProductsSuppliers.Add(packProdSup);
            context.SaveChanges();
            context.UpdateRange(packProdSup);
            this.Close();
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
            if (selectedPackage != null)
                ModifyPackage();
        }
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (selectedPackage != null)
                RemovePackage();
        }

    }
}
