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
    public partial class frmPdfDisplayer : Form
    {
        string filePath = string.Empty;
        public frmPdfDisplayer(string filePath)
        {
            this.filePath = filePath;
            InitializeComponent();
        }

        private void frmPdfDisplayer_Load(object sender, EventArgs e)
        {
            pdfDocument1.FilePath = filePath;
            pdfPageView1.Document = pdfDocument1;
            pdfPageView1.Show();
            pdfPageView1.PageNumber = 0;
            txtZoom.Text = pdfPageView1.Zoom.ToString();
            txtPage.Text = (pdfPageView1.PageNumber + 1).ToString();
            txtAllPage.Text = (pdfDocument1.PageCount).ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (pdfPageView1.Zoom + 20 < 1000)
            {
                pdfPageView1.Zoom = pdfPageView1.Zoom + 20;
                txtZoom.Text = pdfPageView1.Zoom.ToString();
            }
        }

        private void btnMines_Click(object sender, EventArgs e)
        {
            if (pdfPageView1.Zoom - 20 > 10)
            {
                pdfPageView1.Zoom = pdfPageView1.Zoom - 20;
                txtZoom.Text = pdfPageView1.Zoom.ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pdfPageView1.PageNumber < pdfDocument1.PageCount - 1)
            {
                txtPage.TextChanged -= txtPage_TextChanged;
                pdfPageView1.PageNumber = pdfPageView1.PageNumber + 1;
                txtPage.Text = (pdfPageView1.PageNumber + 1).ToString();
                txtPage.TextChanged += txtPage_TextChanged;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (pdfPageView1.PageNumber > 0)
            {
                txtPage.TextChanged -= txtPage_TextChanged;
                pdfPageView1.PageNumber = pdfPageView1.PageNumber - 1;
                txtPage.Text = (pdfPageView1.PageNumber + 1).ToString();
                txtPage.TextChanged += txtPage_TextChanged;
            }
        }

        private void txtPage_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            var tryNum = int.TryParse(txtPage.Text, out num);
            if (!tryNum)
                return;
            num = int.Parse(txtPage.Text);
            if (num > 0 && num <= pdfDocument1.PageCount)
            {
                pdfPageView1.PageNumber = num - 1;
            }
        }

        private void txtZoom_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            var tryNum = int.TryParse(txtZoom.Text, out num);
            if (!tryNum)
                return;

            if (num + 20 < 1000 && num - 20 > 10)
            {
                pdfPageView1.Zoom = num;
                txtZoom.Text = num.ToString();
            }
        }
    }
}
