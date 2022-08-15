using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin frm = new frmLogin();

            DialogResult dl = frm.ShowDialog();

            if (dl == DialogResult.OK)
            {

                Application.Run(new frmMain());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
