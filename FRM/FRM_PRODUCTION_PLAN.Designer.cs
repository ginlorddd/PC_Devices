namespace PC_Devices.FRM
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
            this.SuspendLayout();
            // tabControl
            this.tabControl1.Controls.Add(this.tabFY);
            this.tabControl1.Controls.Add(this.tabRatio);
            this.tabControl1.Controls.Add(this.tabOutput);
            this.tabControl1.Controls.Add(this.tabMaster);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Size = new System.Drawing.Size(1280, 720);
            // tab FY
            this.tabFY.Controls.Add(this.gridFY);
            this.tabFY.Controls.Add(this.btnSaveFY);
            this.tabFY.Text = "Bảng 2 - Kế hoạch FY";
            this.tabFY.UseVisualStyleBackColor = true;
            this.gridFY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFY.MainView = this.viewFY;
            this.gridFY.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.viewFY });
            this.btnSaveFY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveFY.Height = 36;
            this.btnSaveFY.ImageOptions.Image = global::PC_Devices.Properties.Resources.AssignTo_32x32;
            this.btnSaveFY.Text = "Lưu bảng kế hoạch FY";
            // tab Ratio
            this.tabRatio.Controls.Add(this.gridRatio);
            this.tabRatio.Controls.Add(this.btnSaveRatio);
            this.tabRatio.Text = "Bảng 3 - Tỉ lệ chạy máy";
            this.tabRatio.UseVisualStyleBackColor = true;
            this.gridRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRatio.MainView = this.viewRatio;
            this.gridRatio.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.viewRatio });
            this.btnSaveRatio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveRatio.Height = 36;
            this.btnSaveRatio.ImageOptions.Image = global::PC_Devices.Properties.Resources.AssignTo_32x32;
            this.btnSaveRatio.Text = "Lưu bảng tỉ lệ chạy máy";
            // tab Output
            this.tabOutput.Controls.Add(this.gridOutput);
            this.tabOutput.Controls.Add(this.btnSaveOutput);
            this.tabOutput.Text = "Bảng 4 - Sản lượng khuôn";
            this.tabOutput.UseVisualStyleBackColor = true;
            this.gridOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOutput.MainView = this.viewOutput;
            this.gridOutput.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.viewOutput });
            this.btnSaveOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveOutput.Height = 36;
            this.btnSaveOutput.ImageOptions.Image = global::PC_Devices.Properties.Resources.AssignTo_32x32;
            this.btnSaveOutput.Text = "Lưu bảng sản lượng khuôn";
            // tab Master
            this.tabMaster.Controls.Add(this.gridMaster);
            this.tabMaster.Controls.Add(this.btnGenerateMaster);
            this.tabMaster.Text = "Bảng 1 - Kế hoạch OHD";
            this.tabMaster.UseVisualStyleBackColor = true;
            this.gridMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMaster.MainView = this.viewMaster;
            this.gridMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.viewMaster });
            this.btnGenerateMaster.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerateMaster.Height = 36;
            this.btnGenerateMaster.ImageOptions.Image = global::PC_Devices.Properties.Resources.BO_Role_32x32;
            this.btnGenerateMaster.Text = "Tạo bảng kế hoạch OHD (master)";
            // form
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tabControl1);
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
            this.ResumeLayout(false);
        }
    }
}
