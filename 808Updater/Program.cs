using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _808Updater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            args = new string[5];
            args[0] = args[1] = args[2] = args[3] = args[4] = "tset";
            if (args.Length < 1)
            {
                return;
            }
            string vid = args[0];
            string description = args[1];
            string force_update = args[2];
            string update_link = args[3];
            string fileName = args[4];

            Application.Run(new UpdatePreviewfrm(vid,
            description,
            force_update,
            update_link,
            fileName));
        }
    }
}