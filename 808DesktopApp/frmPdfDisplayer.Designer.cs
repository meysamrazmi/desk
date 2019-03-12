namespace _808DesktopApp
{
    partial class frmPdfDisplayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pdfDocument1 = new O2S.Components.PDFView4NET.PDFDocument(this.components);
            this.pdfPageView1 = new O2S.Components.PDFView4NET.PDFPageView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnMines = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.txtZoom = new System.Windows.Forms.TextBox();
            this.btnPlus = new System.Windows.Forms.Button();
            this.txtAllPage = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pdfPageView1
            // 
            this.pdfPageView1.AutoScroll = true;
            this.pdfPageView1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pdfPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfPageView1.Location = new System.Drawing.Point(0, 0);
            this.pdfPageView1.Name = "pdfPageView1";
            this.pdfPageView1.PageNumber = 0;
            this.pdfPageView1.Size = new System.Drawing.Size(818, 613);
            this.pdfPageView1.TabIndex = 0;
            this.pdfPageView1.WorkMode = O2S.Components.PDFView4NET.UserInteractiveWorkMode.PanAndScan;
            this.pdfPageView1.Zoom = 100F;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAllPage);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnMines);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Controls.Add(this.txtPage);
            this.panel1.Controls.Add(this.txtZoom);
            this.panel1.Controls.Add(this.btnPlus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 585);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(818, 28);
            this.panel1.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(455, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(34, 23);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnMines
            // 
            this.btnMines.Location = new System.Drawing.Point(658, 3);
            this.btnMines.Name = "btnMines";
            this.btnMines.Size = new System.Drawing.Size(24, 23);
            this.btnMines.TabIndex = 4;
            this.btnMines.Text = "-";
            this.btnMines.UseVisualStyleBackColor = true;
            this.btnMines.Click += new System.EventHandler(this.btnMines_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(318, 2);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(32, 23);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(356, 4);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(42, 20);
            this.txtPage.TabIndex = 6;
            this.txtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPage.TextChanged += new System.EventHandler(this.txtPage_TextChanged);
            // 
            // txtZoom
            // 
            this.txtZoom.Location = new System.Drawing.Point(688, 4);
            this.txtZoom.Name = "txtZoom";
            this.txtZoom.Size = new System.Drawing.Size(50, 20);
            this.txtZoom.TabIndex = 2;
            this.txtZoom.TextChanged += new System.EventHandler(this.txtZoom_TextChanged);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(744, 3);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(24, 23);
            this.btnPlus.TabIndex = 5;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // txtAllPage
            // 
            this.txtAllPage.Location = new System.Drawing.Point(404, 4);
            this.txtAllPage.Name = "txtAllPage";
            this.txtAllPage.ReadOnly = true;
            this.txtAllPage.Size = new System.Drawing.Size(42, 20);
            this.txtAllPage.TabIndex = 9;
            this.txtAllPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmPdfDisplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 613);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pdfPageView1);
            this.Name = "frmPdfDisplayer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "frmPdfDisplayer";
            this.Load += new System.EventHandler(this.frmPdfDisplayer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private O2S.Components.PDFView4NET.PDFDocument pdfDocument1;
        private O2S.Components.PDFView4NET.PDFPageView pdfPageView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnMines;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.TextBox txtZoom;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.TextBox txtAllPage;
    }
}