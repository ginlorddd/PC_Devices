namespace DM_OHD.FRM
{
    partial class FRM_DIE_MASTER
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.LabelControl lblDieNo;
        private DevExpress.XtraEditors.LabelControl lblDieName;
        private DevExpress.XtraEditors.LabelControl lblCavity;
        private DevExpress.XtraEditors.TextEdit txtDieNo;
        private DevExpress.XtraEditors.TextEdit txtDieName;
        private DevExpress.XtraEditors.SpinEdit spCavity;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView view;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.lblDieNo = new DevExpress.XtraEditors.LabelControl();
            this.lblDieName = new DevExpress.XtraEditors.LabelControl();
            this.lblCavity = new DevExpress.XtraEditors.LabelControl();
            this.txtDieNo = new DevExpress.XtraEditors.TextEdit();
            this.txtDieName = new DevExpress.XtraEditors.TextEdit();
            this.spCavity = new DevExpress.XtraEditors.SpinEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDieNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDieName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCavity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.SuspendLayout();
            this.panel.Controls.Add(this.lblDieNo);
            this.panel.Controls.Add(this.lblDieName);
            this.panel.Controls.Add(this.lblCavity);
            this.panel.Controls.Add(this.txtDieNo);
            this.panel.Controls.Add(this.txtDieName);
            this.panel.Controls.Add(this.spCavity);
            this.panel.Controls.Add(this.btnSave);
            this.panel.Controls.Add(this.btnDelete);
            this.panel.Controls.Add(this.btnExport);
            this.panel.Controls.Add(this.btnImport);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Size = new System.Drawing.Size(1170, 120);
            this.lblDieNo.Location = new System.Drawing.Point(15, 20);
            this.lblDieNo.Text = "Số khuôn";
            this.lblDieName.Location = new System.Drawing.Point(15, 55);
            this.lblDieName.Text = "Tên khuôn";
            this.lblCavity.Location = new System.Drawing.Point(370, 20);
            this.lblCavity.Text = "Tổng số cavity";
            this.txtDieNo.Location = new System.Drawing.Point(95, 15);
            this.txtDieNo.Size = new System.Drawing.Size(220, 22);
            this.txtDieName.Location = new System.Drawing.Point(95, 50);
            this.txtDieName.Size = new System.Drawing.Size(250, 22);
            this.spCavity.Location = new System.Drawing.Point(470, 15);
            this.spCavity.Properties.IsFloatValue = false;
            this.spCavity.Properties.MaxValue = 100;
            this.spCavity.Properties.MinValue = 1;
            this.spCavity.Size = new System.Drawing.Size(120, 22);
            this.btnSave.Location = new System.Drawing.Point(620, 15);
            this.btnSave.Size = new System.Drawing.Size(95, 30);
            this.btnSave.Text = "Thêm/Sửa";
            this.btnDelete.Location = new System.Drawing.Point(725, 15);
            this.btnDelete.Size = new System.Drawing.Size(95, 30);
            this.btnDelete.Text = "Xóa";
            this.btnExport.Location = new System.Drawing.Point(830, 15);
            this.btnExport.Size = new System.Drawing.Size(95, 30);
            this.btnExport.Text = "Export";
            this.btnImport.Location = new System.Drawing.Point(935, 15);
            this.btnImport.Size = new System.Drawing.Size(120, 30);
            this.btnImport.Text = "Import Excel";
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 120);
            this.grid.MainView = this.view;
            this.grid.Size = new System.Drawing.Size(1170, 550);
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.view });
            this.view.GridControl = this.grid;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 670);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel);
            this.Name = "FRM_DIE_MASTER";
            this.Text = "Die Master";
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDieNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDieName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCavity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
