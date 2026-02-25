namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    partial class FRM_IMAGE_VIEWER_ADV
    {
        private System.ComponentModel.IContainer components = null;

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PanelControl panelToolbar;
        private DevExpress.XtraEditors.SimpleButton btnZoomIn;
        private DevExpress.XtraEditors.SimpleButton btnZoomOut;
        private DevExpress.XtraEditors.SimpleButton btnFitScreen;
        private DevExpress.XtraEditors.SimpleButton btnRotate;
        private DevExpress.XtraEditors.SimpleButton btnSaveAs;
        private DevExpress.XtraEditors.SimpleButton btnOpenFolder;
        private DevExpress.XtraEditors.LabelControl lblFileName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_IMAGE_VIEWER_ADV));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.panelToolbar = new DevExpress.XtraEditors.PanelControl();
            this.lblFileName = new DevExpress.XtraEditors.LabelControl();
            this.btnOpenFolder = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveAs = new DevExpress.XtraEditors.SimpleButton();
            this.btnRotate = new DevExpress.XtraEditors.SimpleButton();
            this.btnFitScreen = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomIn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelToolbar)).BeginInit();
            this.panelToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 60);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(900, 640);
            this.pictureEdit1.TabIndex = 0;
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this.lblFileName);
            this.panelToolbar.Controls.Add(this.btnOpenFolder);
            this.panelToolbar.Controls.Add(this.btnSaveAs);
            this.panelToolbar.Controls.Add(this.btnRotate);
            this.panelToolbar.Controls.Add(this.btnFitScreen);
            this.panelToolbar.Controls.Add(this.btnZoomOut);
            this.panelToolbar.Controls.Add(this.btnZoomIn);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(900, 60);
            this.panelToolbar.TabIndex = 1;
            // 
            // lblFileName
            // 
            this.lblFileName.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFileName.Appearance.Options.UseFont = true;
            this.lblFileName.Location = new System.Drawing.Point(15, 20);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(71, 16);
            this.lblFileName.TabIndex = 6;
            this.lblFileName.Text = "Tên file hình";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpenFolder.ImageOptions.SvgImage")));
            this.btnOpenFolder.Location = new System.Drawing.Point(780, 10);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(100, 40);
            this.btnOpenFolder.TabIndex = 5;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaveAs.ImageOptions.SvgImage")));
            this.btnSaveAs.Location = new System.Drawing.Point(670, 10);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(100, 40);
            this.btnSaveAs.TabIndex = 4;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRotate.ImageOptions.SvgImage")));
            this.btnRotate.Location = new System.Drawing.Point(560, 10);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(100, 40);
            this.btnRotate.TabIndex = 3;
            this.btnRotate.Text = "Rotate 90°";
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // btnFitScreen
            // 
            this.btnFitScreen.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFitScreen.ImageOptions.SvgImage")));
            this.btnFitScreen.Location = new System.Drawing.Point(450, 10);
            this.btnFitScreen.Name = "btnFitScreen";
            this.btnFitScreen.Size = new System.Drawing.Size(100, 40);
            this.btnFitScreen.TabIndex = 2;
            this.btnFitScreen.Text = "Fit Screen";
            this.btnFitScreen.Click += new System.EventHandler(this.btnFitScreen_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnZoomOut.ImageOptions.SvgImage")));
            this.btnZoomOut.Location = new System.Drawing.Point(340, 10);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(100, 40);
            this.btnZoomOut.TabIndex = 1;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnZoomIn.ImageOptions.SvgImage")));
            this.btnZoomIn.Location = new System.Drawing.Point(230, 10);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(100, 40);
            this.btnZoomIn.TabIndex = 0;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // FRM_IMAGE_VIEWER_ADV
            // 
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.panelToolbar);
            this.Name = "FRM_IMAGE_VIEWER_ADV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem ảnh";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelToolbar)).EndInit();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
