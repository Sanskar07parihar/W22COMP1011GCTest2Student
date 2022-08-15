using System;
using System.Collections.Generic;
using InventoryManagement.Models;
using System.Net.Http;
using System.Windows.Forms;

namespace InventoryManagement.UI
{
    public partial class frmInOut : Form
    {
        public frmInOut(InOutType outType, Inventory inventory)
        {
            InitializeComponent();

            Inventory = inventory;
            InOutType = outType;
        }

        private InOutType InOutType { get; set; }

        private Inventory Inventory { get; set; }

        private void frmInOut_Load(object sender, EventArgs e)
        {
            lblType.Text = InOutType.ToString();

            LoadItemNames();
            LoadCategory();
            LoadUnits();

            if (InOutType == InOutType.Out)
            {
                ddlItemNames.Enabled = false;
            }
            else
            {
                ddlItemNames.Enabled = true;
            }

            if (Inventory != null && Inventory.ItemName != null && Inventory.ItemName != String.Empty)
            {
                ddlItemNames.Text = Inventory.ItemName;
            }
        }

        private void LoadItemNames()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.GetAsync(string.Format("Inventory/GetInventoryInAll/")).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        List<InventoryIn> obj = response.Content.ReadAsAsync<List<InventoryIn>>().Result;

                        List<string> itemNames = new List<string>();

                        for (int i = 0; i < obj.Count; i++)
                        {
                            if (!itemNames.Contains(obj[i].ItemName))
                            {
                                itemNames.Add(obj[i].ItemName);
                            }
                        }

                        ddlItemNames.Items.AddRange(itemNames.ToArray());
                    }
                    else
                    {
                        MessageBox.Show("Error fetching Inventory");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching Inventory: " + ex.Message);
            }
        }

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

                        ddlCategory.DataSource = categories;

                        ddlCategory.DisplayMember = nameof(Category.CategoryName);
                        ddlCategory.ValueMember = nameof(Category.Id);
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

        private void LoadUnits()
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

                        ddlUnits.DataSource = unitOfMeasurements;

                        ddlUnits.DisplayMember = nameof(UnitOfMeasurement.UnitName);
                        ddlUnits.ValueMember = nameof(UnitOfMeasurement.Id);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlItemNames.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Input item name to continue");
                ddlItemNames.Focus();
                return;
            }
            if (numQty.Value == 0)
            {
                MessageBox.Show("Input valid qty to continue");
                numQty.Focus();
                return;
            }
            if (ddlCategory.SelectedValue == null || !(ddlCategory.SelectedValue is int) || ddlCategory.SelectedValue is int valCat && valCat == 0)
            {
                MessageBox.Show("Input valid category to continue");
                ddlCategory.Focus();
                return;
            }
            if (ddlUnits.SelectedValue == null || !(ddlUnits.SelectedValue is int) || ddlUnits.SelectedValue is int valUnit && valUnit == 0)
            {
                MessageBox.Show("Input valid unit to continue");
                ddlUnits.Focus();
                return;
            }

            if (InOutType == InOutType.In)
            {
                InventoryIn inventoryIn = new InventoryIn();

                inventoryIn.ItemName = ddlItemNames.Text;
                inventoryIn.Qty = (int)numQty.Value;
                inventoryIn.CategoryId = (int)ddlCategory.SelectedValue;
                inventoryIn.UnitId = (int)ddlCategory.SelectedValue;

                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Declarations.API_URL);

                        HttpResponseMessage response = client.PostAsJsonAsync("Inventory/SaveInventoryIn", inventoryIn).Result;

                        if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        {
                            MessageBox.Show("Error saving inventoryIn");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving inventoryIn: " + ex.Message);
                }
            }
            else
            {
                InventoryOut inventoryout = new InventoryOut();

                inventoryout.ItemName = ddlItemNames.Text;
                inventoryout.Qty = (int)numQty.Value;
                inventoryout.CategoryId = (int)ddlCategory.SelectedValue;
                inventoryout.UnitId = (int)ddlCategory.SelectedValue;

                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Declarations.API_URL);

                        HttpResponseMessage response = client.PostAsJsonAsync("Inventory/SaveInventoryOut", inventoryout).Result;

                        if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        {
                            MessageBox.Show("Error saving InventoryOut");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving InventoryOut: " + ex.Message);
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
