namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    partial class FRM_DEVICE_TYPE_MST
    {
        private System.ComponentModel.IContainer components = null;

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.LabelControl lblTitle;

        private DevExpress.XtraEditors.SplitContainerControl splitMain;

        // LEFT
        private DevExpress.XtraEditors.PanelControl panelLeftTop;
        private DevExpress.XtraEditors.LabelControl lblSearch;
        private DevExpress.XtraEditors.TextEdit txtSearch;

        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;

        // RIGHT
        private DevExpress.XtraEditors.GroupControl groupEdit;
        private DevExpress.XtraEditors.PanelControl panelEdit;

        private DevExpress.XtraEditors.LabelControl lblType;
        private DevExpress.XtraEditors.TextEdit txtType;

        private DevExpress.XtraEditors.LabelControl lblTypeShort;
        private DevExpress.XtraEditors.TextEdit txtTypeShort;

        private DevExpress.XtraEditors.LabelControl lblHDSD;
        private DevExpress.XtraEditors.TextEdit txtHDSD;
        private DevExpress.XtraEditors.SimpleButton btnChooseHDSD;

        private DevExpress.XtraEditors.LabelControl lblBCDT;
        private DevExpress.XtraEditors.TextEdit txtBCDT;
        private DevExpress.XtraEditors.SimpleButton btnChooseBCDT;

        private DevExpress.XtraEditors.MemoEdit memoNote;
        private DevExpress.XtraEditors.LabelControl lblNote;

        private DevExpress.XtraEditors.PanelControl panelButtons;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_DEVICE_TYPE_MST));
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelLeftTop = new DevExpress.XtraEditors.PanelControl();
            this.lblSearch = new DevExpress.XtraEditors.LabelControl();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.groupEdit = new DevExpress.XtraEditors.GroupControl();
            this.panelEdit = new DevExpress.XtraEditors.PanelControl();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.txtType = new DevExpress.XtraEditors.TextEdit();
            this.lblTypeShort = new DevExpress.XtraEditors.LabelControl();
            this.txtTypeShort = new DevExpress.XtraEditors.TextEdit();
            this.lblHDSD = new DevExpress.XtraEditors.LabelControl();
            this.txtHDSD = new DevExpress.XtraEditors.TextEdit();
            this.btnChooseHDSD = new DevExpress.XtraEditors.SimpleButton();
            this.lblBCDT = new DevExpress.XtraEditors.LabelControl();
            this.txtBCDT = new DevExpress.XtraEditors.TextEdit();
            this.btnChooseBCDT = new DevExpress.XtraEditors.SimpleButton();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.memoNote = new DevExpress.XtraEditors.MemoEdit();
            this.panelButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnApplyFilesToDevices = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).BeginInit();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeftTop)).BeginInit();
            this.panelLeftTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupEdit)).BeginInit();
            this.groupEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelEdit)).BeginInit();
            this.panelEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeShort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHDSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBCDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelButtons)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1465, 55);
            this.panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(14, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(214, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DANH MỤC LOẠI THIẾT BỊ";
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 55);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.gcData);
            this.splitMain.Panel1.Controls.Add(this.panelLeftTop);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.groupEdit);
            this.splitMain.Size = new System.Drawing.Size(1465, 625);
            this.splitMain.SplitterPosition = 720;
            this.splitMain.TabIndex = 0;
            // 
            // gcData
            // 
            this.gcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcData.Location = new System.Drawing.Point(0, 42);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(720, 583);
            this.gcData.TabIndex = 0;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // gvData
            // 
            this.gvData.GridControl = this.gcData;
            this.gvData.Name = "gvData";
            this.gvData.OptionsBehavior.Editable = false;
            this.gvData.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvData.OptionsView.ShowAutoFilterRow = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvData_FocusedRowChanged);
            // 
            // panelLeftTop
            // 
            this.panelLeftTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelLeftTop.Controls.Add(this.lblSearch);
            this.panelLeftTop.Controls.Add(this.txtSearch);
            this.panelLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftTop.Location = new System.Drawing.Point(0, 0);
            this.panelLeftTop.Name = "panelLeftTop";
            this.panelLeftTop.Size = new System.Drawing.Size(720, 42);
            this.panelLeftTop.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(12, 13);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(20, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(45, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(660, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            // 
            // groupEdit
            // 
            this.groupEdit.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupEdit.AppearanceCaption.Options.UseFont = true;
            this.groupEdit.Controls.Add(this.panelEdit);
            this.groupEdit.Controls.Add(this.panelButtons);
            this.groupEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupEdit.Location = new System.Drawing.Point(0, 0);
            this.groupEdit.Name = "groupEdit";
            this.groupEdit.Size = new System.Drawing.Size(733, 625);
            this.groupEdit.TabIndex = 0;
            this.groupEdit.Text = "Thêm / Sửa loại thiết bị";
            // 
            // panelEdit
            // 
            this.panelEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelEdit.Controls.Add(this.lblMode);
            this.panelEdit.Controls.Add(this.lblType);
            this.panelEdit.Controls.Add(this.txtType);
            this.panelEdit.Controls.Add(this.lblTypeShort);
            this.panelEdit.Controls.Add(this.txtTypeShort);
            this.panelEdit.Controls.Add(this.lblHDSD);
            this.panelEdit.Controls.Add(this.txtHDSD);
            this.panelEdit.Controls.Add(this.btnChooseHDSD);
            this.panelEdit.Controls.Add(this.lblBCDT);
            this.panelEdit.Controls.Add(this.txtBCDT);
            this.panelEdit.Controls.Add(this.btnChooseBCDT);
            this.panelEdit.Controls.Add(this.lblNote);
            this.panelEdit.Controls.Add(this.memoNote);
            this.panelEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdit.Location = new System.Drawing.Point(2, 22);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(729, 545);
            this.panelEdit.TabIndex = 0;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(12, 337);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(94, 25);
            this.lblMode.TabIndex = 12;
            this.lblMode.Text = "lblMode";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(16, 16);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(89, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Tên loại (Type) (*)";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(135, 13);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(310, 22);
            this.txtType.TabIndex = 1;
            // 
            // lblTypeShort
            // 
            this.lblTypeShort.Location = new System.Drawing.Point(16, 58);
            this.lblTypeShort.Name = "lblTypeShort";
            this.lblTypeShort.Size = new System.Drawing.Size(119, 13);
            this.lblTypeShort.TabIndex = 2;
            this.lblTypeShort.Text = "Mã ngắn (TypeShort) (*)";
            // 
            // txtTypeShort
            // 
            this.txtTypeShort.Location = new System.Drawing.Point(135, 55);
            this.txtTypeShort.Name = "txtTypeShort";
            this.txtTypeShort.Size = new System.Drawing.Size(160, 22);
            this.txtTypeShort.TabIndex = 3;
            // 
            // lblHDSD
            // 
            this.lblHDSD.Location = new System.Drawing.Point(16, 100);
            this.lblHDSD.Name = "lblHDSD";
            this.lblHDSD.Size = new System.Drawing.Size(76, 13);
            this.lblHDSD.TabIndex = 4;
            this.lblHDSD.Text = "File HDSD (PDF)";
            // 
            // txtHDSD
            // 
            this.txtHDSD.Location = new System.Drawing.Point(135, 97);
            this.txtHDSD.Name = "txtHDSD";
            this.txtHDSD.Properties.ReadOnly = true;
            this.txtHDSD.Size = new System.Drawing.Size(240, 22);
            this.txtHDSD.TabIndex = 5;
            // 
            // btnChooseHDSD
            // 
            this.btnChooseHDSD.Location = new System.Drawing.Point(381, 96);
            this.btnChooseHDSD.Name = "btnChooseHDSD";
            this.btnChooseHDSD.Size = new System.Drawing.Size(64, 26);
            this.btnChooseHDSD.TabIndex = 6;
            this.btnChooseHDSD.Text = "Chọn";
            this.btnChooseHDSD.Click += new System.EventHandler(this.btnChooseHDSD_Click);
            // 
            // lblBCDT
            // 
            this.lblBCDT.Location = new System.Drawing.Point(16, 142);
            this.lblBCDT.Name = "lblBCDT";
            this.lblBCDT.Size = new System.Drawing.Size(75, 13);
            this.lblBCDT.TabIndex = 7;
            this.lblBCDT.Text = "File BCDT (PDF)";
            // 
            // txtBCDT
            // 
            this.txtBCDT.Location = new System.Drawing.Point(135, 139);
            this.txtBCDT.Name = "txtBCDT";
            this.txtBCDT.Properties.ReadOnly = true;
            this.txtBCDT.Size = new System.Drawing.Size(240, 22);
            this.txtBCDT.TabIndex = 8;
            // 
            // btnChooseBCDT
            // 
            this.btnChooseBCDT.Location = new System.Drawing.Point(381, 138);
            this.btnChooseBCDT.Name = "btnChooseBCDT";
            this.btnChooseBCDT.Size = new System.Drawing.Size(64, 26);
            this.btnChooseBCDT.TabIndex = 9;
            this.btnChooseBCDT.Text = "Chọn";
            this.btnChooseBCDT.Click += new System.EventHandler(this.btnChooseBCDT_Click);
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(16, 188);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(35, 13);
            this.lblNote.TabIndex = 10;
            this.lblNote.Text = "Ghi chú";
            // 
            // memoNote
            // 
            this.memoNote.Location = new System.Drawing.Point(135, 188);
            this.memoNote.Name = "memoNote";
            this.memoNote.Size = new System.Drawing.Size(310, 120);
            this.memoNote.TabIndex = 11;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnApplyFilesToDevices);
            this.panelButtons.Controls.Add(this.btnNew);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(2, 567);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(729, 56);
            this.panelButtons.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.Location = new System.Drawing.Point(14, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(92, 32);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Thêm mới";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(112, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(210, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(308, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 32);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(406, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 32);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApplyFilesToDevices
            // 
            this.btnApplyFilesToDevices.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnApplyFilesToDevices.Appearance.Options.UseFont = true;
            this.btnApplyFilesToDevices.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnApplyFilesToDevices.Location = new System.Drawing.Point(517, 12);
            this.btnApplyFilesToDevices.Name = "btnApplyFilesToDevices";
            this.btnApplyFilesToDevices.Size = new System.Drawing.Size(207, 32);
            this.btnApplyFilesToDevices.TabIndex = 5;
            this.btnApplyFilesToDevices.Text = "Update File for All Devices";
            this.btnApplyFilesToDevices.Click += new System.EventHandler(this.btnApplyFilesToDevices_Click);
            // 
            // FRM_DEVICE_TYPE_MST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 680);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_DEVICE_TYPE_MST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh mục loại thiết bị";
            this.Load += new System.EventHandler(this.FRM_DEVICE_TYPE_MST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).EndInit();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeftTop)).EndInit();
            this.panelLeftTop.ResumeLayout(false);
            this.panelLeftTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupEdit)).EndInit();
            this.groupEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelEdit)).EndInit();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeShort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHDSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBCDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelButtons)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblMode;
        private DevExpress.XtraEditors.SimpleButton btnApplyFilesToDevices;
    }
}
