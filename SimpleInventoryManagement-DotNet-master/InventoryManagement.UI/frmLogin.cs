using InventoryManagement.Models;
using System;
using System.Net.Http;
using System.Reflection;
using System.Windows.Forms;

namespace InventoryManagement.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            lblVersion.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if (txtUsername.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Input username to continue");
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Input password to continue");
                txtPassword.Focus();
                return;
            }

            AuthenticateUser();
        }

        private void AuthenticateUser()
        {
            Declarations.LoggedInUser = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.GetAsync(string.Format("User/AuthenticateUser/{0}/{1}", txtUsername.Text, txtPassword.Text)).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        User user = response.Content.ReadAsAsync<User>().Result;

                        if (user != null && user.Id > 0)
                        {
                            Declarations.LoggedInUser = user;
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Bad credentials");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error authenticating user");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error authenticating user: " + ex.Message);
            }
        }
    }
}
