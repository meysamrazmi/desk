using _808DesktopApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _808DesktopApp
{
    public partial class frmLogin : Form
    {
        BackgroundWorker bckWrkr = new BackgroundWorker();

        public frmLogin()
        {
            InitializeComponent();
            bckWrkr.WorkerReportsProgress = true;
            bckWrkr.DoWork += new DoWorkEventHandler(bckWrkr_DoWork);
            bckWrkr.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bckWrkr_RunWorkerCompleted);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            txtUsername.Text = txtUsername.Text.Trim();
            txtPassword.Text = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                MessageBox.Show("نام کاربری یا رمز عبور را وارد کنید");

            bckWrkr.RunWorkerAsync();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "amir6972";
            txtPassword.Text = "123456aA";

            //var id = Helper.getCPUSerial();
            //MessageBox.Show(id);
            //id = Helper.getMainbord();
            //MessageBox.Show(id);
            //id = Helper.getCPUName();
            //MessageBox.Show(id);
            //id = Helper.getHDDSerial();
            //MessageBox.Show(id);


            var version = checkUpdate();
            if (version != null)
            {
                runUpdater(version);
            }
        }

        private void bckWrkr_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                picWait.Invoke((MethodInvoker)delegate
                {
                    picWait.Visible = true;
                });


                var resultLogin = ManageData.login(txtUsername.Text, txtPassword.Text);
                this.Tag = resultLogin;
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bckWrkr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                picWait.Invoke((MethodInvoker)delegate
                {
                    picWait.Visible = false;
                });
            }
            catch
            {
            }
        }


        Classes.Version checkUpdate()
        {
            AllVersion allVersion = null;
            try
            {
                var isOffline = Classes.WebService.CheckForInternetConnection();
                if (!isOffline)
                    allVersion = Classes.WebService.getAllVersion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (allVersion == null)
                return null;

            var currentVersion = new System.Version(ProductVersion);
            var newVersions = allVersion.versions.Where(c => System.Version.Parse(c.vid) > currentVersion);
            if (newVersions.Count() < 1)
                return null;
            var newVersion = new Classes.Version();
            newVersion.force_update = "0";
            foreach (Classes.Version version in newVersions)
            {
                newVersion.force_update = version.force_update == "1" ? "1" : "0";
                newVersion.description += version.description + "&&";
            }
            newVersion.update_link = newVersions.LastOrDefault().update_link;
            newVersion.vid = newVersions.LastOrDefault().vid;
            newVersion.description = newVersion.description.Replace(" ", "_");
            return newVersion;// = new Classes.Version
            //{
            //    description = "تست_برای_کلاینت",
            //    force_update = "1",
            //    update_link = "https://as5.cdn.asset.aparat.com/aparat-video/39647e23a9f2298041c47e645023d7f3765579__29934.mp4",
            //    vid = "1.2.4"
            //};
        }

        void runUpdater(Classes.Version version)
        {
            string newFilename = Path.Combine(Application.StartupPath, "808DesktopApp.exe");
            var cParams = version.vid + " " + version.description + " " + version.force_update + " " + version.update_link + " " + newFilename;
            string filename = Path.Combine(Application.StartupPath, "808Updater.exe");
            var proc = System.Diagnostics.Process.Start(filename, cParams);
            proc.CloseMainWindow();
            proc.Close();
        }
    }
}
