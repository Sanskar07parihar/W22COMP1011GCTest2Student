using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagement.UI.Controls
{
    public partial class ucUsers : UserControl
    {
        public ucUsers()
        {
            InitializeComponent();
        }

        private void ucUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private User SelectedUser = null;

        private void LoadUsers()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.GetAsync(string.Format("User/GetAll/")).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        List<User> users = response.Content.ReadAsAsync<List<User>>().Result;

                        dtgUsers.DataSource = users;
                    }
                    else
                    {
                        MessageBox.Show("Error fetching users");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching users: " + ex.Message);
            }
        }

        private void dtgUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgUsers.SelectedRows.Count > 0 && dtgUsers.CurrentRow.DataBoundItem is User user && user != null)
            {
                SelectedUser = user;

                txtFirstName.Text = user.FirstName;
                txtLastname.Text = user.LastName;
                txtPassword.Text = user.Password;
                txtUserName.Text = user.UserName;
            }
            else
            {
                ClearUserSelection();
            }
        }

        private void ClearUserSelection()
        {
            SelectedUser = null;

            txtFirstName.Text = String.Empty;
            txtLastname.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtUserName.Text = String.Empty;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearUserSelection();

            SelectedUser = new User();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Select an existing user or add new to continue");
                return;
            }

            SelectedUser.UserName = txtUserName.Text;
            SelectedUser.Password = txtPassword.Text;
            SelectedUser.FirstName = txtFirstName.Text;
            SelectedUser.LastName = txtLastname.Text;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.PostAsJsonAsync("User/SaveUser", SelectedUser).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ClearUserSelection();
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("Error saving user");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Select an existing user to continue");
                return;
            }
            if (SelectedUser.Id == 0)
            {
                MessageBox.Show("Select an existing user to continue");
                return;
            }


            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Declarations.API_URL);

                    HttpResponseMessage response = client.DeleteAsync(String.Format("User/DeleteUser/{0}", SelectedUser.Id)).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ClearUserSelection();
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("Error deleting user");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dtgUsers.RowCount == 0)
            {
                MessageBox.Show("No user to export");
                return;
            }

            if (dtgUsers.DataSource is List<User> lst && lst != null)
            {
                StringBuilder userString = new StringBuilder();

                string header = string.Format("{0},{1},{2},{3}"
                                            , nameof(User.UserName)
                                            , nameof(User.Password)
                                            , nameof(User.FirstName)
                                            , nameof(User.LastName));

                userString.AppendLine(header);

                for (int i = 0; i < lst.Count; i++)
                {
                    string s = string.Format("{0},{1},{2},{3}"
                                            , lst[i].UserName
                                            , lst[i].Password
                                            , lst[i].FirstName
                                            , lst[i].LastName);

                    userString.AppendLine(s);
                }

                WriteToFile(userString.ToString());
                MessageBox.Show("File exported successfully.");
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string data = ReadFromFile();
            data = data.Trim();

            if (data == String.Empty)
            {
                MessageBox.Show("No data to read");
                return;
            }

            string[] datas = data.Split(new char[] { '\n' }, StringSplitOptions.None);
            List<User> lst = new List<User>();

            for (int i = 1; i < datas.Length; i++)
            {
                string[] allrowData = datas[i].Split(new char[] { ',' }, StringSplitOptions.None);
                User user = new User();

                if (allrowData.Length == 4)
                {
                    user.UserName = allrowData[0];
                    user.Password = allrowData[1];
                    user.FirstName = allrowData[2];
                    user.LastName = allrowData[3];
                }

                lst.Add(user);
            }

            if (lst.Count > 0)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Declarations.API_URL);

                        HttpResponseMessage response = client.PostAsJsonAsync("User/DeleteSaveAllUser", lst).Result;

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            ClearUserSelection();
                            LoadUsers();

                            MessageBox.Show("Import complete");
                        }
                        else
                        {
                            MessageBox.Show("Error storing import user to database");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error storing import user to database: " + ex.Message);
                }
            }
        }

        string FileName = "User_ExportImport" + ".csv";
        private void WriteToFile(string dataToWrite)
        {
            if (dataToWrite == null) return;

            try
            {
                string path = System.Windows.Forms.Application.StartupPath.ToString();// + @"\" + fileName;

                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                path += @"\" + FileName;

                if (File.Exists(path)) File.Delete(path);

                using (var file = new StreamWriter(path, true))
                {
                    file.WriteLine(dataToWrite);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        private string ReadFromFile()
        {
            string data = string.Empty;
            try
            {
                string path = System.Windows.Forms.Application.StartupPath.ToString();// + @"\" + fileName;

                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                path += @"\" + FileName;

                if (!File.Exists(path)) return data;

                using (var file = new StreamReader(path, true))
                {
                    data = file.ReadToEnd();
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }

            return data;
        }
    }
}
