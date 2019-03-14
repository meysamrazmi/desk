using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Configuration;

namespace _808DesktopApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static string item = string.Empty;

        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var tempFolder = System.IO.Path.GetTempPath() + "ExtractFilePath";
            Classes.Helper.extractFilePath = tempFolder;
            loc:
            try
            {
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                goto loc;
            }

        }

    }
}
