using _808DesktopApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace _808DesktopApp
{
    public partial class frmMain : Form
    {
        UserLogin userLogin = null;
        int page = 0, pageCount = 4, allPageCount = 0;
        MyProduct myProducts = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            #region Login User
            var loginFrm = new frmLogin();
            if (loginFrm.ShowDialog() != DialogResult.OK)
            {
                btnExit_Click(sender, e);
                return;
            }

            userLogin = loginFrm.Tag as UserLogin;

            if (userLogin == null)
            {
                btnExit_Click(sender, e);
                return;
            }

            #endregion

            Helper.CreatePath();
            myProducts = ManageData.myProducts(userLogin);
            fillMyProducts();
            fillUserInfo();
        }

        void fillUserInfo()
        {
            lblUsername.Text = userLogin.user.name;
            lblFullName.Text = userLogin.profile.full_name;
            lblMail.Text = userLogin.user.mail;
            if (Classes.ManageData.isOffLine && userLogin.user.local_picture != null)
                picUser.Image = Image.FromFile(userLogin.user.local_picture);
            else if (!string.IsNullOrEmpty(userLogin.user.picture))
                picUser.ImageLocation = userLogin.user.picture;
            else
                picUser.Image = _808DesktopApp.Properties.Resources.no_image;
        }

        void fillMyProducts()
        {
            if (myProducts == null)
                return;
            List<Product> selectProduct = null;
            allPageCount = 0;
            TableLayoutPanel sampleProduct = null;
            switch (tabMyProduct.SelectedIndex)
            {
                case 0:
                    selectProduct = myProducts.product.Skip(page * pageCount).Take(pageCount).ToList();
                    allPageCount = myProducts.product.Count / pageCount;
                    sampleProduct = tblProduct;
                    break;
                case 1:
                    selectProduct = myProducts.product_kit.Skip(page * pageCount).Take(pageCount).ToList();
                    allPageCount = myProducts.product_kit.Count / pageCount;
                    sampleProduct = tblProductKit;
                    break;
                case 2:
                    selectProduct = myProducts.college.Skip(page * pageCount).Take(pageCount).ToList();
                    allPageCount = myProducts.college.Count / pageCount;
                    sampleProduct = tblCollege;
                    break;
            }

            sampleProduct.Controls.Clear();
            int column = 0;
            foreach (var item in selectProduct)
            {
                var pic = new PictureBox();
                pic.Name = "pic" + item.nid;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Dock = DockStyle.Fill;
                if (Classes.ManageData.isOffLine && !string.IsNullOrEmpty(item.local_picture))
                    pic.Image = Image.FromFile(item.local_picture);
                else if (!string.IsNullOrEmpty(item.picture))
                    pic.ImageLocation = item.picture;
                else
                    pic.Image = _808DesktopApp.Properties.Resources.no_image;
                pic.Tag = item;
                pic.Click += SelectItem_Click;

                var title = new Label();
                title.Name = "lbl" + item.nid;
                title.Dock = DockStyle.Fill;
                title.Tag = item;
                title.Text = item.title;
                title.Click += SelectItem_Click;
                sampleProduct.Controls.Add(pic, column, 0);
                sampleProduct.Controls.Add(title, column, 1);
                column++;
            }

            var prePage = new LinkLabel { Dock = DockStyle.Fill, Tag = page - 1, Text = "صفحه قبل" };
            prePage.Click += SelectPage_Click;
            var nextPage = new LinkLabel { Dock = DockStyle.Fill, Tag = page + 1, Text = "صفحه بعد" };
            nextPage.Click += SelectPage_Click;
            var curPage = new Label { Dock = DockStyle.Fill, Tag = page, Text = "صفحه جاری " + Convert.ToInt32(page + 1) };
            var allPage = new Label { Dock = DockStyle.Fill, Tag = page, Text = "تعداد صفحه " + Convert.ToInt32(allPageCount + 1) };

            sampleProduct.Controls.Add(prePage, 0, 2);
            sampleProduct.Controls.Add(curPage, 1, 2);
            sampleProduct.Controls.Add(allPage, 2, 2);
            sampleProduct.Controls.Add(nextPage, 3, 2);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ManageData.logout(userLogin);
            Application.Exit();
        }

        void SelectItem_Click(object sender, EventArgs e)
        {
            var item = sender as Control;
            var productInfo = item.Tag as Product;
            if (productInfo != null)
            {
                txtAuthor.Text = productInfo.author;
                txtTitle.Text = productInfo.title;
                txtPrice.Text = productInfo.price.ToString();
                if (Classes.ManageData.isOffLine && !string.IsNullOrEmpty(productInfo.local_picture))
                    picProduct.Image = Image.FromFile(productInfo.local_picture);
                else if (!string.IsNullOrEmpty(productInfo.picture))
                    picProduct.ImageLocation = productInfo.picture;
                else
                    picProduct.Image = _808DesktopApp.Properties.Resources.no_image;

                tblFile.Controls.Clear();
                foreach (var file in productInfo.files)
                {
                    var extension = System.IO.Path.GetExtension(file.name);
                    var title = file.name.Replace(extension, "");
                    var fileItem = new LinkLabel
                    {
                        Dock = DockStyle.Fill,
                        Tag = file,
                        Text = title,
                    };
                    fileItem.Click += FileItem_Click;
                    tblFile.Controls.Add(fileItem);
                }

            }
        }

        void FileItem_Click(object sender, EventArgs e)
        {
            var fileItem = sender as Control;
            var fileInfo = fileItem.Tag as Classes.File;
            if (fileInfo == null)
                return;
            var filePath = Helper.GetFileNameinDirectory(fileInfo.new_name);
            var fileType = Helper.DetectFileType(fileInfo.name);

            if (fileType == Helper.FileType.Other)
            {
                var ext = "Type Files | *" + System.IO.Path.GetExtension(fileInfo.name);

                var saveFile = new SaveFileDialog();
                saveFile.Filter = ext;
                saveFile.FileName = fileInfo.name;
                saveFile.ShowDialog();
                var frmDownload = new frmFileDownloader(saveFile.FileName, fileInfo.url);
                frmDownload.ShowDialog();
                return;
            }

            if (!System.IO.File.Exists(filePath))
            {
                var message = MessageBox.Show("فایل مورد نظر پیدا نشد.آیا فایل برروی لوح فشورده می باشد؟", "پیام سیستم", MessageBoxButtons.YesNo);
                var flag = false;
                if (message == DialogResult.Yes)
                {
                    var drives = DriveInfo.GetDrives()
                                .Where(d => d.DriveType == DriveType.CDRom && d.IsReady);
                    if (drives != null && drives.Count() > 0)
                    {
                        foreach (var drive in drives)
                        {
                            var result = Helper.FindFileInDrive(fileInfo.new_name, drive.Name);
                            if (!string.IsNullOrEmpty(result))
                            {
                                MessageBox.Show("فایل مورد نظر پیدا شد در حال انتقال فایل ها", "پیام سیستم", MessageBoxButtons.OK);
                                flag = Helper.CopyFileToSource(result);
                                if (!flag)
                                    MessageBox.Show("خطا در انتقال فایل ها", "پیام سیستم", MessageBoxButtons.OK);

                                break;
                            }
                        }
                    }
                }
                if (!flag)
                {
                    var text = string.Format("فایل مورد نظر پیدا نشد.آیا مایلید فایل با حجم {0} را دانلود نمایید؟", Helper.getFileSize(fileInfo.filesize));
                    message = MessageBox.Show(text, "پیام سیستم", MessageBoxButtons.YesNo);
                    if (message == DialogResult.Yes)
                    {
                        var frmDownload = new frmFileDownloader(filePath, fileInfo.url);
                        var result = frmDownload.ShowDialog();
                        if (result != DialogResult.OK)
                            MessageBox.Show("خطا در دانلود فایل", "پیام سیستم", MessageBoxButtons.OK);
                    }
                }
            }

            if (!System.IO.File.Exists(filePath))
            {
                MessageBox.Show("فایل مورد نظر پیدا نشد.", "پیام سیستم", MessageBoxButtons.OK);
                return;
            }

            try
            {
                var dataEnc = System.IO.File.ReadAllBytes(filePath);
                if (dataEnc.Length == 0)
                {
                    System.IO.File.Delete(filePath);
                    return;
                }


                var encData = Helper.DecryptData(dataEnc, fileInfo.password);
                var playPath = Helper.ExtractFilePath(fileInfo.name);

                System.IO.File.WriteAllBytes(playPath, encData);

                switch (fileType)
                {
                    case Helper.FileType.Video:
                        var videoPlayer = new frmVideoPlayer(playPath);
                        videoPlayer.ShowDialog();
                        videoPlayer.Close();
                        break;
                    case Helper.FileType.PDF:
                        var pdfPlayer = new frmPdfDisplayer(playPath);
                        pdfPlayer.ShowDialog();
                        pdfPlayer.Close();
                        break;
                }

                System.IO.File.Delete(playPath);
            }
            catch 
            {
                MessageBox.Show("خطا در بازکردن فایل.", "پیام سیستم", MessageBoxButtons.OK);
                System.IO.File.Delete(filePath);
            }

        }

        void SelectPage_Click(object sender, EventArgs e)
        {
            var item = sender as Control;
            if (!string.IsNullOrEmpty(item.Tag.ToString()))
            {
                var num = Convert.ToInt32(item.Tag);
                if (num >= 0 && num <= allPageCount)
                {
                    page = num;
                    fillMyProducts();
                }
            }
        }

        private void btnBookmark_Click(object sender, EventArgs e)
        {
            var result = ManageData.bookmark(userLogin);
            if (result == null)
                return;

            var show = new frmShowPedia(result, "بوکمارک ها");
            show.ShowDialog();
        }

        private void btnLastContent_Click(object sender, EventArgs e)
        {
            var result = ManageData.lastContent();
            if (result == null)
                return;

            var show = new frmShowPedia(result, "آخرین محتوا");
            show.ShowDialog();
        }

        private void btnSuggestion_Click(object sender, EventArgs e)
        {
            var result = ManageData.suggestion(userLogin);
            if (result == null)
                return;


            var show = new frmShowPedia(result, "پیشنهادات");
            show.ShowDialog();
        }

        private void tmrCheckOnline_Tick(object sender, EventArgs e)
        {
            var offline = ManageData.OffLineApp();
            if (offline)
                this.Text = "offline";
            else
                this.Text = "online";
        }

        private void tabMyProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = 0;
            fillMyProducts();
        }

    }
}
