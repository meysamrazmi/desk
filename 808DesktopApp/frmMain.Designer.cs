namespace _808DesktopApp
{
    partial class frmMain
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
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tblFile = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAuthor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.Label();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.txtTitle = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.tabMyProduct = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tblProduct = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tblProductKit = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tblCollege = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btnSuggestion = new System.Windows.Forms.Button();
            this.lblMail = new System.Windows.Forms.Label();
            this.btnLastContent = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnBookmark = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.tmrCheckOnline = new System.Windows.Forms.Timer(this.components);
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.tabMyProduct.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 2;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.mainPanel.Controls.Add(this.panel2, 0, 0);
            this.mainPanel.Controls.Add(this.tabMyProduct, 0, 1);
            this.mainPanel.Controls.Add(this.panel1, 0, 2);
            this.mainPanel.Controls.Add(this.tblFile, 2, 2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 3;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainPanel.Size = new System.Drawing.Size(934, 661);
            this.mainPanel.TabIndex = 0;
            // 
            // tblFile
            // 
            this.tblFile.ColumnCount = 6;
            this.tblFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFile.Location = new System.Drawing.Point(3, 386);
            this.tblFile.Name = "tblFile";
            this.tblFile.RowCount = 5;
            this.tblFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblFile.Size = new System.Drawing.Size(742, 272);
            this.tblFile.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAuthor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.picProduct);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(751, 386);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 272);
            this.panel1.TabIndex = 26;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Location = new System.Drawing.Point(46, 216);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAuthor.Size = new System.Drawing.Size(66, 20);
            this.txtAuthor.TabIndex = 24;
            this.txtAuthor.Text = "...";
            this.txtAuthor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "ناشر:";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(46, 242);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrice.Size = new System.Drawing.Size(66, 20);
            this.txtPrice.TabIndex = 21;
            this.txtPrice.Text = "...";
            this.txtPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // picProduct
            // 
            this.picProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProduct.Location = new System.Drawing.Point(26, 19);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(130, 130);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProduct.TabIndex = 22;
            this.picProduct.TabStop = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(26, 162);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTitle.Size = new System.Drawing.Size(130, 45);
            this.txtTitle.TabIndex = 19;
            this.txtTitle.Text = "...";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(118, 242);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 18;
            this.lblPrice.Text = "قیمت :";
            // 
            // tabMyProduct
            // 
            this.mainPanel.SetColumnSpan(this.tabMyProduct, 2);
            this.tabMyProduct.Controls.Add(this.tabPage1);
            this.tabMyProduct.Controls.Add(this.tabPage2);
            this.tabMyProduct.Controls.Add(this.tabPage3);
            this.tabMyProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMyProduct.Location = new System.Drawing.Point(3, 102);
            this.tabMyProduct.Name = "tabMyProduct";
            this.tabMyProduct.RightToLeftLayout = true;
            this.tabMyProduct.SelectedIndex = 0;
            this.tabMyProduct.Size = new System.Drawing.Size(928, 278);
            this.tabMyProduct.TabIndex = 27;
            this.tabMyProduct.SelectedIndexChanged += new System.EventHandler(this.tabMyProduct_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tblProduct);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(920, 252);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tblProduct
            // 
            this.tblProduct.ColumnCount = 4;
            this.tblProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblProduct.Location = new System.Drawing.Point(3, 3);
            this.tblProduct.Name = "tblProduct";
            this.tblProduct.RowCount = 3;
            this.tblProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblProduct.Size = new System.Drawing.Size(914, 246);
            this.tblProduct.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tblProductKit);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(302, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tblProductKit
            // 
            this.tblProductKit.ColumnCount = 4;
            this.tblProductKit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblProductKit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblProductKit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblProductKit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblProductKit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblProductKit.Location = new System.Drawing.Point(3, 3);
            this.tblProductKit.Name = "tblProductKit";
            this.tblProductKit.RowCount = 3;
            this.tblProductKit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblProductKit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblProductKit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblProductKit.Size = new System.Drawing.Size(296, 268);
            this.tblProductKit.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tblCollege);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(302, 274);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tblCollege
            // 
            this.tblCollege.ColumnCount = 4;
            this.tblCollege.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCollege.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCollege.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCollege.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCollege.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCollege.Location = new System.Drawing.Point(3, 3);
            this.tblCollege.Name = "tblCollege";
            this.tblCollege.RowCount = 3;
            this.tblCollege.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblCollege.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCollege.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblCollege.Size = new System.Drawing.Size(296, 268);
            this.tblCollege.TabIndex = 1;
            // 
            // panel2
            // 
            this.mainPanel.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.lbl2);
            this.panel2.Controls.Add(this.btnSuggestion);
            this.panel2.Controls.Add(this.lblMail);
            this.panel2.Controls.Add(this.btnLastContent);
            this.panel2.Controls.Add(this.lbl1);
            this.panel2.Controls.Add(this.btnBookmark);
            this.panel2.Controls.Add(this.lblUsername);
            this.panel2.Controls.Add(this.lblFullName);
            this.panel2.Controls.Add(this.picUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel2.Size = new System.Drawing.Size(928, 93);
            this.panel2.TabIndex = 28;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(27, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 31);
            this.btnExit.TabIndex = 35;
            this.btnExit.Text = "logout";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(627, 66);
            this.lbl2.Name = "lbl2";
            this.lbl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl2.Size = new System.Drawing.Size(33, 13);
            this.lbl2.TabIndex = 34;
            this.lbl2.Text = "ایمیل:";
            // 
            // btnSuggestion
            // 
            this.btnSuggestion.Location = new System.Drawing.Point(110, 56);
            this.btnSuggestion.Name = "btnSuggestion";
            this.btnSuggestion.Size = new System.Drawing.Size(75, 23);
            this.btnSuggestion.TabIndex = 14;
            this.btnSuggestion.Text = "suggestion";
            this.btnSuggestion.UseVisualStyleBackColor = true;
            this.btnSuggestion.Click += new System.EventHandler(this.btnSuggestion_Click);
            // 
            // lblMail
            // 
            this.lblMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMail.Location = new System.Drawing.Point(420, 66);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(201, 13);
            this.lblMail.TabIndex = 33;
            this.lblMail.Text = "lblMaildddddddddddddd";
            // 
            // btnLastContent
            // 
            this.btnLastContent.Location = new System.Drawing.Point(29, 56);
            this.btnLastContent.Name = "btnLastContent";
            this.btnLastContent.Size = new System.Drawing.Size(75, 23);
            this.btnLastContent.TabIndex = 12;
            this.btnLastContent.Text = "last content";
            this.btnLastContent.UseVisualStyleBackColor = true;
            this.btnLastContent.Click += new System.EventHandler(this.btnLastContent_Click);
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(788, 66);
            this.lbl1.Name = "lbl1";
            this.lbl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl1.Size = new System.Drawing.Size(61, 13);
            this.lbl1.TabIndex = 32;
            this.lbl1.Text = "نام کاربری:";
            // 
            // btnBookmark
            // 
            this.btnBookmark.Location = new System.Drawing.Point(202, 56);
            this.btnBookmark.Name = "btnBookmark";
            this.btnBookmark.Size = new System.Drawing.Size(82, 23);
            this.btnBookmark.TabIndex = 10;
            this.btnBookmark.Text = "my Bookmark";
            this.btnBookmark.UseVisualStyleBackColor = true;
            this.btnBookmark.Click += new System.EventHandler(this.btnBookmark_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.Location = new System.Drawing.Point(666, 66);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(116, 13);
            this.lblUsername.TabIndex = 31;
            this.lblUsername.Text = "ddddddsername";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFullName
            // 
            this.lblFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFullName.Location = new System.Drawing.Point(768, 33);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFullName.Size = new System.Drawing.Size(81, 17);
            this.lblFullName.TabIndex = 30;
            this.lblFullName.Text = "lblFullName";
            // 
            // picUser
            // 
            this.picUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picUser.Location = new System.Drawing.Point(855, 29);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(50, 50);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 29;
            this.picUser.TabStop = false;
            // 
            // tmrCheckOnline
            // 
            this.tmrCheckOnline.Enabled = true;
            this.tmrCheckOnline.Interval = 10000;
            this.tmrCheckOnline.Tick += new System.EventHandler(this.tmrCheckOnline_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 661);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.tabMyProduct.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.TableLayoutPanel tblFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtPrice;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TabControl tabMyProduct;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tblProduct;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tblProductKit;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tblCollege;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btnSuggestion;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Button btnLastContent;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnBookmark;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Timer tmrCheckOnline;
    }
}