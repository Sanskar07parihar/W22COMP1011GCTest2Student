using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace InventoryManagement.UI.Controls
{
    public partial class ucInventory : UserControl
    {
        public ucInventory()
        {
            InitializeComponent();
        }

        private void ucInventory_Load(object sender, EventArgs e)
        {
            btnInventoryStatus.PerformClick();
        }

        private void btnInventoryStatus_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "Inventory";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.GetAsync(string.Format("Inventory/GetInventoryStatus/")).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        List<Inventory> obj = response.Content.ReadAsAsync<List<Inventory>>().Result;

                        dtgInventory.DataSource = obj;
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

        private void btnInventoryInRecord_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "Inventory In Record";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.GetAsync(string.Format("Inventory/GetInventoryInAll/")).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        List<InventoryIn> obj = response.Content.ReadAsAsync<List<InventoryIn>>().Result;

                        dtgInventory.DataSource = obj;
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

        private void btnInventoryOutRecord_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "Inventory Out Record";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.GetAsync(string.Format("Inventory/GetInventoryOutAll/")).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        List<InventoryOut> obj = response.Content.ReadAsAsync<List<InventoryOut>>().Result;

                        dtgInventory.DataSource = obj;
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

        private void btnInventoryIn_Click(object sender, EventArgs e)
        {
            frmInOut frm = new frmInOut(InOutType.In, SelectedInventory);
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                btnInventoryStatus.PerformClick();
            }
        }

        private void btnInventoryOut_Click(object sender, EventArgs e)
        {
            if (SelectedInventory == null)
            {
                MessageBox.Show("select an item from inventory to continue");
                return;
            }

            frmInOut frm = new frmInOut(InOutType.Out, SelectedInventory);
            DialogResult result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                btnInventoryStatus.PerformClick();
            }
        }

        private Inventory SelectedInventory = null;

        private void dtgInventory_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgInventory.SelectedRows.Count > 0 && dtgInventory.CurrentRow.DataBoundItem is Inventory inv && inv != null)
            {
                SelectedInventory = inv;
            }
            else
            {
                SelectedInventory = null;
            }
        }
    }
}
