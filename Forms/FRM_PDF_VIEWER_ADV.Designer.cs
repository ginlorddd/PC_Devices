namespace JigFlow.Forms
{
    partial class FRM_PDF_VIEWER_ADV
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.btnSaveAs = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpenFolder = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectTool = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomTool = new DevExpress.XtraEditors.SimpleButton();
            this.btnRotateRight = new DevExpress.XtraEditors.SimpleButton();
            this.btnRotateLeft = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomIn = new DevExpress.XtraEditors.SimpleButton();
            this.lblPage = new DevExpress.XtraEditors.LabelControl();
            this.lblFileName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // pdfViewer1
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 60);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.NavigationPanePageVisibility = DevExpress.XtraPdfViewer.PdfNavigationPanePageVisibility.None;
            this.pdfViewer1.Size = new System.Drawing.Size(1000, 700);
            this.pdfViewer1.TabIndex = 0;
            this.pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.PageLevel;
            this.pdfViewer1.ScrollPositionChanged += new DevExpress.XtraPdfViewer.PdfScrollPositionChangedEventHandler(this.pdfViewer1_ScrollPositionChanged);
            // panelTop
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
            // buttons
            this.btnZoomIn.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnZoomIn.Location = new System.Drawing.Point(323, 9); this.btnZoomIn.Size = new System.Drawing.Size(39, 40); this.btnZoomIn.Text = "+"; this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            this.btnZoomOut.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnZoomOut.Location = new System.Drawing.Point(368, 9); this.btnZoomOut.Size = new System.Drawing.Size(40, 40); this.btnZoomOut.Text = "-"; this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            this.btnRotateLeft.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnRotateLeft.Location = new System.Drawing.Point(414, 9); this.btnRotateLeft.Size = new System.Drawing.Size(41, 40); this.btnRotateLeft.Text = "↺"; this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            this.btnRotateRight.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnRotateRight.Location = new System.Drawing.Point(461, 9); this.btnRotateRight.Size = new System.Drawing.Size(38, 40); this.btnRotateRight.Text = "↻"; this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            this.btnZoomTool.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnZoomTool.Location = new System.Drawing.Point(505, 9); this.btnZoomTool.Size = new System.Drawing.Size(96, 40); this.btnZoomTool.Text = "Zoom Tool"; this.btnZoomTool.Click += new System.EventHandler(this.btnZoomTool_Click);
            this.btnSelectTool.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnSelectTool.Location = new System.Drawing.Point(607, 9); this.btnSelectTool.Size = new System.Drawing.Size(80, 40); this.btnSelectTool.Text = "Select"; this.btnSelectTool.Click += new System.EventHandler(this.btnSelectTool_Click);
            this.btnSaveAs.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnSaveAs.Location = new System.Drawing.Point(782, 9); this.btnSaveAs.Size = new System.Drawing.Size(100, 40); this.btnSaveAs.Text = "Save As"; this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            this.btnOpenFolder.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnOpenFolder.Location = new System.Drawing.Point(888, 9); this.btnOpenFolder.Size = new System.Drawing.Size(100, 40); this.btnOpenFolder.Text = "Open Folder"; this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // labels
            this.lblFileName.Location = new System.Drawing.Point(10, 10);
            this.lblFileName.Size = new System.Drawing.Size(0, 13);
            this.lblPage.Location = new System.Drawing.Point(10, 35);
            this.lblPage.Text = "0/0";

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 760);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_PDF_VIEWER_ADV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem tài liệu PDF";
            this.Load += new System.EventHandler(this.FRM_PDF_VIEWER_ADV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.SimpleButton btnZoomIn;
        private DevExpress.XtraEditors.SimpleButton btnZoomOut;
        private DevExpress.XtraEditors.SimpleButton btnRotateLeft;
        private DevExpress.XtraEditors.SimpleButton btnRotateRight;
        private DevExpress.XtraEditors.SimpleButton btnZoomTool;
        private DevExpress.XtraEditors.SimpleButton btnSelectTool;
        private DevExpress.XtraEditors.SimpleButton btnOpenFolder;
        private DevExpress.XtraEditors.SimpleButton btnSaveAs;
        private DevExpress.XtraEditors.LabelControl lblPage;
        private DevExpress.XtraEditors.LabelControl lblFileName;
    }
}
