namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    partial class FRM_DEVICE_REGISTER_HISTORY_LIST
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_DEVICE_REGISTER_HISTORY_LIST));
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.groupFilter = new DevExpress.XtraEditors.GroupControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtFrom = new DevExpress.XtraEditors.DateEdit();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtTo = new DevExpress.XtraEditors.DateEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportRegister = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportDevice = new DevExpress.XtraEditors.SimpleButton();
            this.splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupRegister = new DevExpress.XtraEditors.GroupControl();
            this.gcRegister = new DevExpress.XtraGrid.GridControl();
            this.gvRegister = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupDevice = new DevExpress.XtraEditors.GroupControl();
            this.gcDevice = new DevExpress.XtraGrid.GridControl();
            this.gvDevice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupFilter)).BeginInit();
            this.groupFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).BeginInit();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupRegister)).BeginInit();
            this.groupRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDevice)).BeginInit();
            this.groupDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.groupFilter);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1444, 81);
            this.panelTop.TabIndex = 2;
            // 
            // groupFilter
            // 
            this.groupFilter.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupFilter.AppearanceCaption.Options.UseFont = true;
            this.groupFilter.Controls.Add(this.btnClose);
            this.groupFilter.Controls.Add(this.lblFrom);
            this.groupFilter.Controls.Add(this.dtFrom);
            this.groupFilter.Controls.Add(this.lblTo);
            this.groupFilter.Controls.Add(this.dtTo);
            this.groupFilter.Controls.Add(this.btnRefresh);
            this.groupFilter.Controls.Add(this.btnExportRegister);
            this.groupFilter.Controls.Add(this.btnExportDevice);
            this.groupFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupFilter.Location = new System.Drawing.Point(2, 2);
            this.groupFilter.Name = "groupFilter";
            this.groupFilter.Size = new System.Drawing.Size(1440, 77);
            this.groupFilter.TabIndex = 0;
            this.groupFilter.Text = "Bộ lọc";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(1085, 29);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(18, 38);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(51, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Từ ngày:";
            // 
            // dtFrom
            // 
            this.dtFrom.EditValue = new System.DateTime(2025, 12, 14, 0, 0, 0, 0);
            this.dtFrom.Location = new System.Drawing.Point(95, 34);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFrom.Size = new System.Drawing.Size(180, 22);
            this.dtFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(290, 38);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(31, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "Đến:";
            // 
            // dtTo
            // 
            this.dtTo.EditValue = new System.DateTime(2025, 12, 14, 0, 0, 0, 0);
            this.dtTo.Location = new System.Drawing.Point(350, 34);
            this.dtTo.Name = "dtTo";
            this.dtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTo.Size = new System.Drawing.Size(180, 22);
            this.dtTo.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(560, 32);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 30);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Lọc / Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportRegister
            // 
            this.btnExportRegister.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportRegister.Appearance.Options.UseFont = true;
            this.btnExportRegister.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportRegister.ImageOptions.Image")));
            this.btnExportRegister.Location = new System.Drawing.Point(720, 32);
            this.btnExportRegister.Name = "btnExportRegister";
            this.btnExportRegister.Size = new System.Drawing.Size(170, 30);
            this.btnExportRegister.TabIndex = 7;
            this.btnExportRegister.Text = "Export lịch sử đăng ký";
            this.btnExportRegister.Click += new System.EventHandler(this.btnExportRegister_Click);
            // 
            // btnExportDevice
            // 
            this.btnExportDevice.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportDevice.Appearance.Options.UseFont = true;
            this.btnExportDevice.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportDevice.ImageOptions.Image")));
            this.btnExportDevice.Location = new System.Drawing.Point(896, 32);
            this.btnExportDevice.Name = "btnExportDevice";
            this.btnExportDevice.Size = new System.Drawing.Size(170, 30);
            this.btnExportDevice.TabIndex = 8;
            this.btnExportDevice.Text = "Export lịch sử sử dụng";
            this.btnExportDevice.Click += new System.EventHandler(this.btnExportDevice_Click);
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Horizontal = false;
            this.splitMain.Location = new System.Drawing.Point(0, 81);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.groupRegister);
            this.splitMain.Panel1.Text = "Panel1";
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.groupDevice);
            this.splitMain.Panel2.Text = "Panel2";
            this.splitMain.Size = new System.Drawing.Size(1444, 651);
            this.splitMain.SplitterPosition = 319;
            this.splitMain.TabIndex = 0;
            // 
            // groupRegister
            // 
            this.groupRegister.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupRegister.AppearanceCaption.Options.UseFont = true;
            this.groupRegister.Controls.Add(this.gcRegister);
            this.groupRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupRegister.Location = new System.Drawing.Point(0, 0);
            this.groupRegister.Name = "groupRegister";
            this.groupRegister.Size = new System.Drawing.Size(1444, 319);
            this.groupRegister.TabIndex = 0;
            this.groupRegister.Text = "Lịch sử đăng ký thiết bị";
            // 
            // gcRegister
            // 
            this.gcRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRegister.Location = new System.Drawing.Point(2, 22);
            this.gcRegister.MainView = this.gvRegister;
            this.gcRegister.Name = "gcRegister";
            this.gcRegister.Size = new System.Drawing.Size(1440, 295);
            this.gcRegister.TabIndex = 0;
            this.gcRegister.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRegister});
            // 
            // gvRegister
            // 
            this.gvRegister.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvRegister.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvRegister.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvRegister.GridControl = this.gcRegister;
            this.gvRegister.Name = "gvRegister";
            this.gvRegister.OptionsBehavior.Editable = false;
            this.gvRegister.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvRegister.OptionsView.ShowAutoFilterRow = true;
            this.gvRegister.OptionsView.ShowGroupPanel = false;
            // 
            // groupDevice
            // 
            this.groupDevice.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupDevice.AppearanceCaption.Options.UseFont = true;
            this.groupDevice.Controls.Add(this.gcDevice);
            this.groupDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDevice.Location = new System.Drawing.Point(0, 0);
            this.groupDevice.Name = "groupDevice";
            this.groupDevice.Size = new System.Drawing.Size(1444, 320);
            this.groupDevice.TabIndex = 0;
            this.groupDevice.Text = "Lịch sử sử dụng thiết bị";
            // 
            // gcDevice
            // 
            this.gcDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDevice.Location = new System.Drawing.Point(2, 22);
            this.gcDevice.MainView = this.gvDevice;
            this.gcDevice.Name = "gcDevice";
            this.gcDevice.Size = new System.Drawing.Size(1440, 296);
            this.gcDevice.TabIndex = 0;
            this.gcDevice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDevice});
            // 
            // gvDevice
            // 
            this.gvDevice.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvDevice.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDevice.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvDevice.GridControl = this.gcDevice;
            this.gvDevice.Name = "gvDevice";
            this.gvDevice.OptionsBehavior.Editable = false;
            this.gvDevice.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvDevice.OptionsView.ShowAutoFilterRow = true;
            this.gvDevice.OptionsView.ShowGroupPanel = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 732);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1444, 10);
            this.panelBottom.TabIndex = 1;
            // 
            // FRM_DEVICE_REGISTER_HISTORY_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 742);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_DEVICE_REGISTER_HISTORY_LIST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử đăng ký & sử dụng thiết bị";
            this.Load += new System.EventHandler(this.FRM_DEVICE_REGISTER_HISTORY_LIST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupFilter)).EndInit();
            this.groupFilter.ResumeLayout(false);
            this.groupFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).EndInit();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupRegister)).EndInit();
            this.groupRegister.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDevice)).EndInit();
            this.groupDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.GroupControl groupFilter;

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;

        private DevExpress.XtraEditors.DateEdit dtFrom;
        private DevExpress.XtraEditors.DateEdit dtTo;

        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnExportRegister;
        private DevExpress.XtraEditors.SimpleButton btnExportDevice;

        private DevExpress.XtraEditors.SplitContainerControl splitMain;

        private DevExpress.XtraEditors.GroupControl groupRegister;
        private DevExpress.XtraGrid.GridControl gcRegister;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRegister;

        private DevExpress.XtraEditors.GroupControl groupDevice;
        private DevExpress.XtraGrid.GridControl gcDevice;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDevice;

        private DevExpress.XtraEditors.PanelControl panelBottom;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
