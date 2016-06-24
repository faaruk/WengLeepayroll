using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WengLeePayroll
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WengLeePayroll.appcode.VersionControl objVC = new WengLeePayroll.appcode.VersionControl();
            objVC.VersionCheck();
            Application.Run(new frmLogin());
            //Application.Run(new MainMdi());
            //Application.Run(new ManageEmployee());
        }
    }
}
