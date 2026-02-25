namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    partial class FRM_PDF_VIEWER_ADV
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.SimpleButton btnZoomIn;
        private DevExpress.XtraEditors.SimpleButton btnZoomOut;
        private DevExpress.XtraEditors.SimpleButton btnRotateLeft;
        private DevExpress.XtraEditors.SimpleButton btnRotateRight;
        private DevExpress.XtraEditors.SimpleButton btnZoomTool;
        private DevExpress.XtraEditors.SimpleButton btnSelectTool;
        private DevExpress.XtraEditors.SimpleButton btnOpenFolder;
        private DevExpress.XtraEditors.LabelControl lblPage;
        private DevExpress.XtraEditors.LabelControl lblFileName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_PDF_VIEWER_ADV));
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.btnOpenFolder = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectTool = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomTool = new DevExpress.XtraEditors.SimpleButton();
            this.btnRotateRight = new DevExpress.XtraEditors.SimpleButton();
            this.btnRotateLeft = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomIn = new DevExpress.XtraEditors.SimpleButton();
            this.lblPage = new DevExpress.XtraEditors.LabelControl();
            this.lblFileName = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveAs = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 60);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.NavigationPanePageVisibility = DevExpress.XtraPdfViewer.PdfNavigationPanePageVisibility.None;
            this.pdfViewer1.Size = new System.Drawing.Size(1000, 700);
            this.pdfViewer1.TabIndex = 0;
            this.pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.PageLevel;
            this.pdfViewer1.ScrollPositionChanged += new DevExpress.XtraPdfViewer.PdfScrollPositionChangedEventHandler(this.pdfViewer1_ScrollPositionChanged);
            this.pdfViewer1.Load += new System.EventHandler(this.FRM_PDF_VIEWER_ADV_Load);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnSaveAs);
            this.panelTop.Controls.Add(this.btnOpenFolder);
            this.panelTop.Controls.Add(this.btnSelectTool);
            this.panelTop.Controls.Add(this.btnZoomTool);
            this.panelTop.Controls.Add(this.btnRotateRight);
            this.panelTop.Controls.Add(this.btnRotateLeft);
            this.panelTop.Controls.Add(this.btnZoomOut);
            this.panelTop.Controls.Add(this.btnZoomIn);
            this.panelTop.Controls.Add(this.lblPage);
            this.panelTop.Controls.Add(this.lblFileName);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 60);
            this.panelTop.TabIndex = 1;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpenFolder.ImageOptions.SvgImage")));
            this.btnOpenFolder.Location = new System.Drawing.Point(888, 9);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(100, 40);
            this.btnOpenFolder.TabIndex = 0;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnSelectTool
            // 
            this.btnSelectTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectTool.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSelectTool.ImageOptions.SvgImage")));
            this.btnSelectTool.Location = new System.Drawing.Point(607, 9);
            this.btnSelectTool.Name = "btnSelectTool";
            this.btnSelectTool.Size = new System.Drawing.Size(80, 40);
            this.btnSelectTool.TabIndex = 1;
            this.btnSelectTool.Text = "Select";
            this.btnSelectTool.Click += new System.EventHandler(this.btnSelectTool_Click);
            // 
            // btnZoomTool
            // 
            this.btnZoomTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomTool.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnZoomTool.ImageOptions.SvgImage")));
            this.btnZoomTool.Location = new System.Drawing.Point(505, 9);
            this.btnZoomTool.Name = "btnZoomTool";
            this.btnZoomTool.Size = new System.Drawing.Size(96, 40);
            this.btnZoomTool.TabIndex = 2;
            this.btnZoomTool.Text = "Zoom Tool";
            this.btnZoomTool.Click += new System.EventHandler(this.btnZoomTool_Click);
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotateRight.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRotateRight.ImageOptions.SvgImage")));
            this.btnRotateRight.Location = new System.Drawing.Point(461, 9);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(38, 40);
            this.btnRotateRight.TabIndex = 3;
            this.btnRotateRight.Text = "Rotate Right";
            this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotateLeft.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRotateLeft.ImageOptions.SvgImage")));
            this.btnRotateLeft.Location = new System.Drawing.Point(414, 9);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(41, 40);
            this.btnRotateLeft.TabIndex = 4;
            this.btnRotateLeft.Text = "Rotate Left";
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnZoomOut.ImageOptions.SvgImage")));
            this.btnZoomOut.Location = new System.Drawing.Point(368, 9);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(40, 40);
            this.btnZoomOut.TabIndex = 5;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnZoomIn.ImageOptions.SvgImage")));
            this.btnZoomIn.Location = new System.Drawing.Point(323, 9);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(39, 40);
            this.btnZoomIn.TabIndex = 6;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // lblPage
            // 
            this.lblPage.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblPage.Appearance.Options.UseFont = true;
            this.lblPage.Location = new System.Drawing.Point(10, 35);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(19, 14);
            this.lblPage.TabIndex = 7;
            this.lblPage.Text = "0/0";
            // 
            // lblFileName
            // 
            this.lblFileName.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFileName.Appearance.Options.UseFont = true;
            this.lblFileName.Location = new System.Drawing.Point(10, 10);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 16);
            this.lblFileName.TabIndex = 8;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAs.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaveAs.ImageOptions.SvgImage")));
            this.btnSaveAs.Location = new System.Drawing.Point(782, 9);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(100, 40);
            this.btnSaveAs.TabIndex = 9;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // FRM_PDF_VIEWER_ADV
            // 
            this.ClientSize = new System.Drawing.Size(1000, 760);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_PDF_VIEWER_ADV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem tài liệu PDF";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraEditors.SimpleButton btnSaveAs;
    }
}
