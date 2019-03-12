using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _808DesktopApp
{
    public partial class frmShowPedia : Form
    {
        public frmShowPedia(Classes.LastContent lastContent, string title)
        {
            InitializeComponent();

            var pedias = new List<Classes.Pedia>();
            if (lastContent.college != null)
                pedias.AddRange(lastContent.college);
            if (lastContent.product != null)
                pedias.AddRange(lastContent.product);
            if (lastContent.product_kit != null)
                pedias.AddRange(lastContent.product_kit);
            setPedia(pedias, title);
        }

        public frmShowPedia(Classes.Bookmark bookmark, string title)
        {
            InitializeComponent();
            var pedias = new List<Classes.Pedia>();

            if (bookmark.article != null)
                pedias.AddRange(bookmark.article);
            if (bookmark.blog != null)
                pedias.AddRange(bookmark.blog);
            if (bookmark.college != null)
                pedias.AddRange(bookmark.college);
            if (bookmark.designteam != null)
                pedias.AddRange(bookmark.designteam);
            if (bookmark.education != null)
                pedias.AddRange(bookmark.education);
            if (bookmark.film != null)
                pedias.AddRange(bookmark.film);
            if (bookmark.gallerynew != null)
                pedias.AddRange(bookmark.gallerynew);
            if (bookmark.podcast != null)
                pedias.AddRange(bookmark.podcast);
            if (bookmark.product != null)
                pedias.AddRange(bookmark.product);
            if (bookmark.product_kit != null)
                pedias.AddRange(bookmark.product_kit);
            if (bookmark.publication != null)
                pedias.AddRange(bookmark.publication);
            if (bookmark.pedia != null)
                pedias.AddRange(bookmark.pedia);

            setPedia(pedias, title);
        }

        void setPedia(List<Classes.Pedia> pedias, string title)
        {
            this.Text = title;
            foreach (var pedia in pedias)
            {
                var pic = new PictureBox();
                pic.Name = "pic" + pedia.nid;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Dock = DockStyle.Fill;
                if (Classes.ManageData.isOffLine && !string.IsNullOrEmpty(pedia.local_picture))
                    pic.Image = Image.FromFile(pedia.local_picture);
                else if (!string.IsNullOrEmpty(pedia.picture))
                    pic.ImageLocation = pedia.picture;
                else
                    pic.Image = _808DesktopApp.Properties.Resources.no_image;
                pic.Height = 200;
                pic.Tag = pedia;
                pic.Click += Pic_Click;
                pic.MouseHover += Pic_MouseHover;
                tblPanel.Controls.Add(pic);
            }
        }

        private void Pic_MouseHover(object sender, EventArgs e)
        {
            var picItem = sender as PictureBox;
            var pedia = picItem.Tag as Classes.Pedia;
            new ToolTip().Show(pedia.title, this, Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y, 1000);
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            var picItem = sender as PictureBox;
            var pedia = picItem.Tag as Classes.Pedia;
            System.Diagnostics.Process.Start(pedia.url);
        }
    }
}
