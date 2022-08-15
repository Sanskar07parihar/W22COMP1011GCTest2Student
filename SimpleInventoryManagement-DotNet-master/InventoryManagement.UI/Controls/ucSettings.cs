using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace InventoryManagement.UI.Controls
{
    public partial class ucSettings : UserControl
    {
        public ucSettings()
        {
            InitializeComponent();
        }

        private void ucSettings_Load(object sender, System.EventArgs e)
        {
            LoadCategory();
            LoadUnit();
        }

        #region [ category ]

        private Category SelectedCategory = null;

        private void LoadCategory()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.GetAsync(string.Format("Category/GetAll/")).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        List<Category> categories = response.Content.ReadAsAsync<List<Category>>().Result;

                        dtgCategory.DataSource = categories;
                    }
                    else
                    {
                        MessageBox.Show("Error fetching Category");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching Category: " + ex.Message);
            }
        }

        private void ClearCategorySelection()
        {
            SelectedCategory = null;
            txtCategory.Text = String.Empty;
        }

        private void btnDeleteCategory_Click(object sender, System.EventArgs e)
        {
            if (SelectedCategory == null)
            {
                MessageBox.Show("Select an existing Category to continue");
                return;
            }
            if (SelectedCategory.Id == 0)
            {
                MessageBox.Show("Select an existing Category to continue");
                return;
            }


            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.DeleteAsync(String.Format("Category/DeleteCategory/{0}", SelectedCategory.Id)).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ClearCategorySelection();
                        LoadCategory();
                    }
                    else
                    {
                        MessageBox.Show("Error deleting Category");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting Category: " + ex.Message);
            }
        }

        private void btnSaveCategory_Click(object sender, System.EventArgs e)
        {
            if (SelectedCategory == null)
            {
                MessageBox.Show("Select an existing Category or add new to continue");
                return;
            }

            SelectedCategory.CategoryName = txtCategory.Text;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.PostAsJsonAsync("Category/SaveCategory", SelectedCategory).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ClearCategorySelection();
                        LoadCategory();
                    }
                    else
                    {
                        MessageBox.Show("Error saving Category");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving Category: " + ex.Message);
            }
        }

        private void btnAddNewCategory_Click(object sender, System.EventArgs e)
        {
            ClearCategorySelection();

            SelectedCategory = new Category();
        }

        private void dtgCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgCategory.SelectedRows.Count > 0 && dtgCategory.CurrentRow.DataBoundItem is Category category && category != null)
            {
                SelectedCategory = category;
                txtCategory.Text = category.CategoryName;
            }
            else
            {
                ClearCategorySelection();
            }
        }

        #endregion

        #region [ unit ]
        
        private UnitOfMeasurement SelectedUnit = null;

        private void LoadUnit()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.GetAsync(string.Format("Unit/GetAll/")).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        List<UnitOfMeasurement> unitOfMeasurements = response.Content.ReadAsAsync<List<UnitOfMeasurement>>().Result;

                        dtgUnitOfMeasurement.DataSource = unitOfMeasurements;
                    }
                    else
                    {
                        MessageBox.Show("Error fetching Unit");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching Unit: " + ex.Message);
            }
        }

        private void ClearUnit()
        {
            SelectedUnit = null;
            txtUnitOfMeasurement.Text = String.Empty;
        }

        private void btnDeleteUnit_Click(object sender, EventArgs e)
        {
            if (SelectedUnit == null)
            {
                MessageBox.Show("Select an existing Unit to continue");
                return;
            }
            if (SelectedUnit.Id == 0)
            {
                MessageBox.Show("Select an existing Unit to continue");
                return;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.DeleteAsync(String.Format("Unit/DeleteUnit/{0}", SelectedUnit.Id)).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ClearUnit();
                        LoadUnit();
                    }
                    else
                    {
                        MessageBox.Show("Error deleting Unit");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting Unit: " + ex.Message);
            }
        }

        private void btnSaveUnit_Click(object sender, EventArgs e)
        {
            if (SelectedUnit == null)
            {
                MessageBox.Show("Select an existing Unit or add new to continue");
                return;
            }

            SelectedUnit.UnitName = txtUnitOfMeasurement.Text;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.PostAsJsonAsync("Unit/SaveUnit", SelectedUnit).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ClearUnit();
                        LoadUnit();
                    }
                    else
                    {
                        MessageBox.Show("Error saving Unit");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving Unit: " + ex.Message);
            }
        }

        private void btnAddNewUnit_Click(object sender, EventArgs e)
        {
            ClearUnit();

            SelectedUnit = new UnitOfMeasurement();
        }

        private void dtgUnitOfMeasurement_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgUnitOfMeasurement.SelectedRows.Count > 0 && dtgUnitOfMeasurement.CurrentRow.DataBoundItem is UnitOfMeasurement uom && uom != null)
            {
                SelectedUnit = uom;
                txtUnitOfMeasurement.Text = uom.UnitName;
            }
            else
            {
                ClearUnit();
            }
        }

        #endregion
    }
}
