using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    partial class FRM_DEVICE_MAINT_LIST
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_DEVICE_MAINT_LIST));
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelPreview = new DevExpress.XtraEditors.GroupControl();
            this.lblAlert = new System.Windows.Forms.Label();
            this.lblTenTitle = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblMaQLTitle = new System.Windows.Forms.Label();
            this.lblMaQL = new System.Windows.Forms.Label();
            this.lblSerialTitle = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblNhaMayTitle = new System.Windows.Forms.Label();
            this.lblNhaMay = new System.Windows.Forms.Label();
            this.lblNgayBDTitle = new System.Windows.Forms.Label();
            this.lblNgayBD = new System.Windows.Forms.Label();
            this.lblKeHoachBDTitle = new System.Windows.Forms.Label();
            this.lblKeHoachBD = new System.Windows.Forms.Label();
            this.picBarCode = new DevExpress.XtraEditors.PictureEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSendMail = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.gcData1 = new DevExpress.XtraGrid.GridControl();
            this.gvData1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPreview)).BeginInit();
            this.panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarCode.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.Location = new System.Drawing.Point(12, 12);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(978, 268);
            this.gcData.TabIndex = 0;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // gvData
            // 
            this.gvData.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvData.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvData.GridControl = this.gcData;
            this.gvData.Name = "gvData";
            this.gvData.OptionsBehavior.Editable = false;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.RowAutoHeight = true;
            this.gvData.OptionsView.ShowAutoFilterRow = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            // 
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.Controls.Add(this.lblAlert);
            this.panelPreview.Controls.Add(this.lblTenTitle);
            this.panelPreview.Controls.Add(this.lblTen);
            this.panelPreview.Controls.Add(this.lblMaQLTitle);
            this.panelPreview.Controls.Add(this.lblMaQL);
            this.panelPreview.Controls.Add(this.lblSerialTitle);
            this.panelPreview.Controls.Add(this.lblSerial);
            this.panelPreview.Controls.Add(this.lblNhaMayTitle);
            this.panelPreview.Controls.Add(this.lblNhaMay);
            this.panelPreview.Controls.Add(this.lblNgayBDTitle);
            this.panelPreview.Controls.Add(this.lblNgayBD);
            this.panelPreview.Controls.Add(this.lblKeHoachBDTitle);
            this.panelPreview.Controls.Add(this.lblKeHoachBD);
            this.panelPreview.Controls.Add(this.picBarCode);
            this.panelPreview.Location = new System.Drawing.Point(996, 12);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(289, 538);
            this.panelPreview.TabIndex = 1;
            this.panelPreview.Text = "THÔNG TIN CHI TIẾT";
            // 
            // lblAlert
            // 
            this.lblAlert.AutoSize = true;
            this.lblAlert.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblAlert.Location = new System.Drawing.Point(5, 40);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(99, 23);
            this.lblAlert.TabIndex = 0;
            this.lblAlert.Text = "Cảnh báo";
            // 
            // lblTenTitle
            // 
            this.lblTenTitle.AutoSize = true;
            this.lblTenTitle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblTenTitle.Location = new System.Drawing.Point(5, 100);
            this.lblTenTitle.Name = "lblTenTitle";
            this.lblTenTitle.Size = new System.Drawing.Size(97, 18);
            this.lblTenTitle.TabIndex = 1;
            this.lblTenTitle.Text = "Tên thiết bị:";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblTen.Location = new System.Drawing.Point(111, 100);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(13, 18);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "-";
            // 
            // lblMaQLTitle
            // 
            this.lblMaQLTitle.AutoSize = true;
            this.lblMaQLTitle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaQLTitle.Location = new System.Drawing.Point(5, 130);
            this.lblMaQLTitle.Name = "lblMaQLTitle";
            this.lblMaQLTitle.Size = new System.Drawing.Size(93, 18);
            this.lblMaQLTitle.TabIndex = 3;
            this.lblMaQLTitle.Text = "Mã quản lý:";
            // 
            // lblMaQL
            // 
            this.lblMaQL.AutoSize = true;
            this.lblMaQL.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblMaQL.Location = new System.Drawing.Point(111, 130);
            this.lblMaQL.Name = "lblMaQL";
            this.lblMaQL.Size = new System.Drawing.Size(13, 18);
            this.lblMaQL.TabIndex = 4;
            this.lblMaQL.Text = "-";
            // 
            // lblSerialTitle
            // 
            this.lblSerialTitle.AutoSize = true;
            this.lblSerialTitle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblSerialTitle.Location = new System.Drawing.Point(5, 160);
            this.lblSerialTitle.Name = "lblSerialTitle";
            this.lblSerialTitle.Size = new System.Drawing.Size(58, 18);
            this.lblSerialTitle.TabIndex = 5;
            this.lblSerialTitle.Text = "Serial:";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblSerial.Location = new System.Drawing.Point(111, 160);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(13, 18);
            this.lblSerial.TabIndex = 6;
            this.lblSerial.Text = "-";
            // 
            // lblNhaMayTitle
            // 
            this.lblNhaMayTitle.AutoSize = true;
            this.lblNhaMayTitle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblNhaMayTitle.Location = new System.Drawing.Point(5, 190);
            this.lblNhaMayTitle.Name = "lblNhaMayTitle";
            this.lblNhaMayTitle.Size = new System.Drawing.Size(78, 18);
            this.lblNhaMayTitle.TabIndex = 7;
            this.lblNhaMayTitle.Text = "Nhà máy:";
            // 
            // lblNhaMay
            // 
            this.lblNhaMay.AutoSize = true;
            this.lblNhaMay.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblNhaMay.Location = new System.Drawing.Point(111, 190);
            this.lblNhaMay.Name = "lblNhaMay";
            this.lblNhaMay.Size = new System.Drawing.Size(13, 18);
            this.lblNhaMay.TabIndex = 8;
            this.lblNhaMay.Text = "-";
            // 
            // lblNgayBDTitle
            // 
            this.lblNgayBDTitle.AutoSize = true;
            this.lblNgayBDTitle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblNgayBDTitle.Location = new System.Drawing.Point(5, 220);
            this.lblNgayBDTitle.Name = "lblNgayBDTitle";
            this.lblNgayBDTitle.Size = new System.Drawing.Size(109, 18);
            this.lblNgayBDTitle.TabIndex = 9;
            this.lblNgayBDTitle.Text = "Lần BD trước:";
            // 
            // lblNgayBD
            // 
            this.lblNgayBD.AutoSize = true;
            this.lblNgayBD.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblNgayBD.Location = new System.Drawing.Point(111, 220);
            this.lblNgayBD.Name = "lblNgayBD";
            this.lblNgayBD.Size = new System.Drawing.Size(13, 18);
            this.lblNgayBD.TabIndex = 10;
            this.lblNgayBD.Text = "-";
            // 
            // lblKeHoachBDTitle
            // 
            this.lblKeHoachBDTitle.AutoSize = true;
            this.lblKeHoachBDTitle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblKeHoachBDTitle.Location = new System.Drawing.Point(5, 250);
            this.lblKeHoachBDTitle.Name = "lblKeHoachBDTitle";
            this.lblKeHoachBDTitle.Size = new System.Drawing.Size(105, 18);
            this.lblKeHoachBDTitle.TabIndex = 11;
            this.lblKeHoachBDTitle.Text = "Kế hoạch BD:";
            // 
            // lblKeHoachBD
            // 
            this.lblKeHoachBD.AutoSize = true;
            this.lblKeHoachBD.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblKeHoachBD.Location = new System.Drawing.Point(111, 250);
            this.lblKeHoachBD.Name = "lblKeHoachBD";
            this.lblKeHoachBD.Size = new System.Drawing.Size(13, 18);
            this.lblKeHoachBD.TabIndex = 12;
            this.lblKeHoachBD.Text = "-";
            // 
            // picBarCode
            // 
            this.picBarCode.Location = new System.Drawing.Point(25, 309);
            this.picBarCode.Name = "picBarCode";
            this.picBarCode.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picBarCode.Size = new System.Drawing.Size(243, 115);
            this.picBarCode.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSendMail);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(12, 556);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1273, 91);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            // 
            // btnSendMail
            // 
            this.btnSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMail.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMail.Appearance.Options.UseFont = true;
            this.btnSendMail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSendMail.ImageOptions.Image")));
            this.btnSendMail.Location = new System.Drawing.Point(1204, 37);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(63, 29);
            this.btnSendMail.TabIndex = 129;
            this.btnSendMail.Text = "Mail";
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.Location = new System.Drawing.Point(198, 56);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(78, 29);
            this.btnExport.TabIndex = 128;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(114, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 29);
            this.btnRefresh.TabIndex = 126;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.Location = new System.Drawing.Point(16, 20);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 29);
            this.btnEdit.TabIndex = 126;
            this.btnEdit.Text = "Cập nhật";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(16, 55);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 29);
            this.btnDelete.TabIndex = 126;
            this.btnDelete.Text = "Xóa";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(114, 56);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 29);
            this.btnClose.TabIndex = 125;
            this.btnClose.Text = "Thoát";
            // 
            // gcData1
            // 
            this.gcData1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData1.Location = new System.Drawing.Point(12, 286);
            this.gcData1.MainView = this.gvData1;
            this.gcData1.Name = "gcData1";
            this.gcData1.Size = new System.Drawing.Size(978, 264);
            this.gcData1.TabIndex = 128;
            this.gcData1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData1});
            // 
            // gvData1
            // 
            this.gvData1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvData1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvData1.GridControl = this.gcData1;
            this.gvData1.Name = "gvData1";
            this.gvData1.OptionsBehavior.Editable = false;
            this.gvData1.OptionsView.ColumnAutoWidth = false;
            this.gvData1.OptionsView.RowAutoHeight = true;
            this.gvData1.OptionsView.ShowAutoFilterRow = true;
            this.gvData1.OptionsView.ShowGroupPanel = false;
            // 
            // FRM_DEVICE_MAINT_LIST
            // 
            this.ClientSize = new System.Drawing.Size(1299, 659);
            this.Controls.Add(this.gcData1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.gcData);
            this.Name = "FRM_DEVICE_MAINT_LIST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách thiết bị bảo dưỡng";
            this.Load += new System.EventHandler(this.FRM_DEVICE_MAINT_LIST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPreview)).EndInit();
            this.panelPreview.ResumeLayout(false);
            this.panelPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarCode.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;

        private DevExpress.XtraEditors.GroupControl panelPreview;

        private System.Windows.Forms.Label lblAlert;

        private System.Windows.Forms.Label lblTenTitle;
        private System.Windows.Forms.Label lblTen;

        private System.Windows.Forms.Label lblMaQLTitle;
        private System.Windows.Forms.Label lblMaQL;

        private System.Windows.Forms.Label lblSerialTitle;
        private System.Windows.Forms.Label lblSerial;

        private System.Windows.Forms.Label lblNhaMayTitle;
        private System.Windows.Forms.Label lblNhaMay;

        private System.Windows.Forms.Label lblNgayBDTitle;
        private System.Windows.Forms.Label lblNgayBD;

        private System.Windows.Forms.Label lblKeHoachBDTitle;
        private System.Windows.Forms.Label lblKeHoachBD;

        private DevExpress.XtraEditors.PictureEdit picBarCode;
        private GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSendMail;
        private DevExpress.XtraGrid.GridControl gcData1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData1;
    }
}
