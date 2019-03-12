using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace _808Updater
{
    public partial class UpdatePreviewfrm : Form
    {
        string urlDownload;
        string fileName;
        public UpdatePreviewfrm(string vid,
            string description,
            string force_update,
            string update_link, string fileName)
        {
            InitializeComponent();
            lblVersion.Text = vid;
            description = description.Replace("&&", Environment.NewLine);
            description = description.Replace("_", " ");
            lblDescription.Text = description;
            urlDownload = update_link;
            this.fileName = fileName;
            MessageBox.Show("vid:" + vid + " description:" + description + " force_update:" + force_update + " update_link:" + update_link + " fileName:" + fileName);
            if (force_update == "1")
            {
                btnCancel.Enabled = btnUpdate.Enabled = false;
                updateAction();
            }
        }


        void updateAction()
        {
            lblStatus.Text = "درحال بستن نرم افزار";

            #region Stop DesktopApp
            var processes = Process.GetProcesses().Where(c => c.ProcessName == "808DesktopApp");
            foreach (Process p in processes)
            {
                p.Kill();
            }
            #endregion

            lblStatus.Text = "در حال آماده سازی";

            #region Rename DesktopApp
            if (System.IO.File.Exists(fileName))
                System.IO.File.Move(fileName, fileName.Remove(fileName.Length - 4));
            #endregion


            lblStatus.Text = "درحال بروزرسانی";
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                wc.DownloadFileAsync(
                    new System.Uri(urlDownload),
                    fileName
                );
            }
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.fileName);
            #region Delete DesktopApp
            if (System.IO.File.Exists(fileName.Remove(fileName.Length - 4)))
                System.IO.File.Delete(fileName.Remove(fileName.Length - 4));
            #endregion
            Application.Exit();
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage >= 100)
            {
                System.Threading.Thread.Sleep(1000);
                this.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateAction();
            btnCancel.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdatePreviewfrm_Load(object sender, EventArgs e)
        {
            //this.urlDownload = "https://hw15.cdn.asset.aparat.com/aparat-video/d37904785f92afb3306a14cb0f049a2713655552-240p__41876.mp4";
            //this.fileName = @"C:\Users\Amirhossein\source\repos\808DesktopApp\808Updater\bin\Debug\loghme.mp4";
        }
    }
}
