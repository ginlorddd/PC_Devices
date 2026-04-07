namespace DM_OHD.FRM
{
    partial class FRM_PRODUCTION_PLAN
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFY;
        private System.Windows.Forms.TabPage tabRatio;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.TabPage tabMaster;
        private DevExpress.XtraGrid.GridControl gridFY;
        private DevExpress.XtraGrid.Views.Grid.GridView viewFY;
        private DevExpress.XtraGrid.GridControl gridRatio;
        private DevExpress.XtraGrid.Views.Grid.GridView viewRatio;
        private DevExpress.XtraGrid.GridControl gridOutput;
        private DevExpress.XtraGrid.Views.Grid.GridView viewOutput;
        private DevExpress.XtraGrid.GridControl gridMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView viewMaster;
        private DevExpress.XtraEditors.SimpleButton btnSaveFY;
        private DevExpress.XtraEditors.SimpleButton btnSaveRatio;
        private DevExpress.XtraEditors.SimpleButton btnSaveOutput;
        private DevExpress.XtraEditors.SimpleButton btnGenerateMaster;
        private DevExpress.XtraEditors.SimpleButton btnExportFY;
        private DevExpress.XtraEditors.SimpleButton btnImportFY;
        private DevExpress.XtraEditors.SimpleButton btnExportRatio;
        private DevExpress.XtraEditors.SimpleButton btnImportRatio;
        private DevExpress.XtraEditors.SimpleButton btnExportOutput;
        private DevExpress.XtraEditors.SimpleButton btnImportOutput;
        private DevExpress.XtraEditors.SimpleButton btnExportMaster;
        private DevExpress.XtraEditors.PanelControl panelFilter;
        private DevExpress.XtraEditors.LabelControl lblFrom;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraEditors.DateEdit deFrom;
        private DevExpress.XtraEditors.DateEdit deTo;
        private DevExpress.XtraEditors.SimpleButton btnApplyFilter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFY = new System.Windows.Forms.TabPage();
            this.tabRatio = new System.Windows.Forms.TabPage();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.tabMaster = new System.Windows.Forms.TabPage();
            this.gridFY = new DevExpress.XtraGrid.GridControl();
            this.viewFY = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridRatio = new DevExpress.XtraGrid.GridControl();
            this.viewRatio = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridOutput = new DevExpress.XtraGrid.GridControl();
            this.viewOutput = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridMaster = new DevExpress.XtraGrid.GridControl();
            this.viewMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSaveFY = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveRatio = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveOutput = new DevExpress.XtraEditors.SimpleButton();
            this.btnGenerateMaster = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportFY = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportFY = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportRatio = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportRatio = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportOutput = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportOutput = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportMaster = new DevExpress.XtraEditors.SimpleButton();
            this.panelFilter = new DevExpress.XtraEditors.PanelControl();
            this.lblFrom = new DevExpress.XtraEditors.LabelControl();
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.deFrom = new DevExpress.XtraEditors.DateEdit();
            this.deTo = new DevExpress.XtraEditors.DateEdit();
            this.btnApplyFilter = new DevExpress.XtraEditors.SimpleButton();
            this.tabControl1.SuspendLayout();
            this.tabFY.SuspendLayout();
            this.tabRatio.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.tabMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewFY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFilter)).BeginInit();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).BeginInit();
            this.SuspendLayout();
            // tabControl
            this.tabControl1.Controls.Add(this.tabFY);
            this.tabControl1.Controls.Add(this.tabRatio);
            this.tabControl1.Controls.Add(this.tabOutput);
            this.tabControl1.Controls.Add(this.tabMaster);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 42);
            this.tabControl1.Size = new System.Drawing.Size(1280, 678);
            // tab FY
            this.tabFY.Controls.Add(this.gridFY);
            this.tabFY.Controls.Add(this.btnExportFY);
            this.tabFY.Controls.Add(this.btnImportFY);
            this.tabFY.Controls.Add(this.btnSaveFY);
            this.tabFY.Text = "Bảng 2 - Kế hoạch FY";
            this.tabFY.UseVisualStyleBackColor = true;
            this.gridFY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFY.MainView = this.viewFY;
            this.gridFY.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.viewFY });
            this.btnSaveFY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveFY.Height = 36;
            this.btnSaveFY.Text = "Lưu bảng kế hoạch FY";
            this.btnImportFY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnImportFY.Height = 30;
            this.btnImportFY.Text = "Import Excel";
            this.btnExportFY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExportFY.Height = 30;
            this.btnExportFY.Text = "Export";
            // tab Ratio
            this.tabRatio.Controls.Add(this.gridRatio);
            this.tabRatio.Controls.Add(this.btnExportRatio);
            this.tabRatio.Controls.Add(this.btnImportRatio);
            this.tabRatio.Controls.Add(this.btnSaveRatio);
            this.tabRatio.Text = "Bảng 3 - Tỉ lệ chạy máy";
            this.tabRatio.UseVisualStyleBackColor = true;
            this.gridRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRatio.MainView = this.viewRatio;
            this.gridRatio.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.viewRatio });
            this.btnSaveRatio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveRatio.Height = 36;
            this.btnSaveRatio.Text = "Lưu bảng tỉ lệ chạy máy";
            this.btnImportRatio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnImportRatio.Height = 30;
            this.btnImportRatio.Text = "Import Excel";
            this.btnExportRatio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExportRatio.Height = 30;
            this.btnExportRatio.Text = "Export";
            // tab Output
            this.tabOutput.Controls.Add(this.gridOutput);
            this.tabOutput.Controls.Add(this.btnExportOutput);
            this.tabOutput.Controls.Add(this.btnImportOutput);
            this.tabOutput.Controls.Add(this.btnSaveOutput);
            this.tabOutput.Text = "Bảng 4 - Sản lượng khuôn";
            this.tabOutput.UseVisualStyleBackColor = true;
            this.gridOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOutput.MainView = this.viewOutput;
            this.gridOutput.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.viewOutput });
            this.btnSaveOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveOutput.Height = 36;
            this.btnSaveOutput.Text = "Lưu bảng sản lượng khuôn";
            this.btnImportOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnImportOutput.Height = 30;
            this.btnImportOutput.Text = "Import Excel";
            this.btnExportOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExportOutput.Height = 30;
            this.btnExportOutput.Text = "Export";
            // tab Master
            this.tabMaster.Controls.Add(this.gridMaster);
            this.tabMaster.Controls.Add(this.btnExportMaster);
            this.tabMaster.Controls.Add(this.btnGenerateMaster);
            this.tabMaster.Text = "Bảng 1 - Kế hoạch OHD";
            this.tabMaster.UseVisualStyleBackColor = true;
            this.gridMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaster.MainView = this.viewMaster;
            this.gridMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.viewMaster });
            this.btnGenerateMaster.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerateMaster.Height = 36;
            this.btnGenerateMaster.Text = "Tạo bảng kế hoạch OHD (master)";
            this.btnExportMaster.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExportMaster.Height = 30;
            this.btnExportMaster.Text = "Export";
            // panelFilter
            this.panelFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFilter.Controls.Add(this.btnApplyFilter);
            this.panelFilter.Controls.Add(this.deTo);
            this.panelFilter.Controls.Add(this.deFrom);
            this.panelFilter.Controls.Add(this.lblTo);
            this.panelFilter.Controls.Add(this.lblFrom);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1280, 42);

            this.lblFrom.Location = new System.Drawing.Point(10, 13);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(17, 13);
            this.lblFrom.Text = "Từ";

            this.deFrom.EditValue = null;
            this.deFrom.Location = new System.Drawing.Point(34, 10);
            this.deFrom.Name = "deFrom";
            this.deFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFrom.Size = new System.Drawing.Size(100, 20);

            this.lblTo.Location = new System.Drawing.Point(142, 13);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 13);
            this.lblTo.Text = "Đến";

            this.deTo.EditValue = null;
            this.deTo.Location = new System.Drawing.Point(170, 10);
            this.deTo.Name = "deTo";
            this.deTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTo.Size = new System.Drawing.Size(100, 20);

            this.btnApplyFilter.Location = new System.Drawing.Point(280, 9);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(52, 23);
            this.btnApplyFilter.Text = "Lọc";

            // form
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelFilter);
            this.Text = "Kế hoạch sản xuất";
            this.tabControl1.ResumeLayout(false);
            this.tabFY.ResumeLayout(false);
            this.tabRatio.ResumeLayout(false);
            this.tabOutput.ResumeLayout(false);
            this.tabMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewFY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelFilter)).EndInit();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
