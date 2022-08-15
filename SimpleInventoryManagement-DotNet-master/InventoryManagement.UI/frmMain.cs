using InventoryManagement.UI.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagement.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            btnMenuHome.PerformClick();

            this.Text = " Welcome to dashboard '" + Declarations.LoggedInUser.FirstName + " " + Declarations.LoggedInUser.LastName + "'";
        }

        private void btnMenu_Click(object sender, System.EventArgs e)
        {
            if (sender is Button btn && btn != null)
            {
                ResetAllMenus();

                btn.BackColor = Color.YellowGreen;
                btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);

                UserControl control;
                MenuOption menToOpen = (MenuOption)Convert.ToInt32(btn.Tag);

                switch (menToOpen)
                {
                    case MenuOption.Home:
                        pnlDisplayControl.Controls.Clear();
                        control = new ucHome();
                        control.Height = pnlDisplayControl.Height;
                        control.Width = pnlDisplayControl.Width;
                        pnlDisplayControl.Controls.Add(control);
                        break;
                    case MenuOption.Inventory:
                        pnlDisplayControl.Controls.Clear();
                        control = new ucInventory();
                        control.Height = pnlDisplayControl.Height;
                        control.Width = pnlDisplayControl.Width;
                        pnlDisplayControl.Controls.Add(control);
                        break;
                    case MenuOption.Users:
                        pnlDisplayControl.Controls.Clear();
                        control = new ucUsers();
                        control.Height = pnlDisplayControl.Height;
                        control.Width = pnlDisplayControl.Width;
                        pnlDisplayControl.Controls.Add(control);
                        break;
                    case MenuOption.Settings:
                        pnlDisplayControl.Controls.Clear();
                        control = new ucSettings();
                        control.Height = pnlDisplayControl.Height;
                        control.Width = pnlDisplayControl.Width;
                        pnlDisplayControl.Controls.Add(control);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ResetAllMenus()
        {
            foreach (var item in flowPanelMenu.Controls)
            {
                if (item is Button btn && btn != null)
                {
                    btn.BackColor = Color.AliceBlue;
                    btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Regular);
                }
            }
        }


    }
}
