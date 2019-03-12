using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _808DesktopApp
{
    public partial class frmFileDownloader : Form
    {
        string fileName = string.Empty;
        string url = string.Empty;
        public frmFileDownloader(string fileName,string url)
        {
            this.fileName = fileName;
            this.url = url;
            InitializeComponent();
        }
        private void frmFileDownloader_Load(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri(url),
                    // Param2 = Path to save
                    fileName
                );
            }
        }
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage >= 100)
            {
                Thread.Sleep(1000);
                this.Close();
            }
        }
    }
}
