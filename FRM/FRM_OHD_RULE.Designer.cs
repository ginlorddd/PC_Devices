namespace DM_OHD.FRM
{
    partial class FRM_OHD_RULE
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit cboOwner;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit colorBgEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit colorFgEdit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.cboOwner = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.colorBgEdit = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.colorFgEdit = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboOwner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBgEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorFgEdit)).BeginInit();
            this.SuspendLayout();
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1100, 44);
            this.panelTop.Controls.Add(this.btnSave);
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.btnDelete);
            this.btnSave.Location = new System.Drawing.Point(12, 9);
            this.btnSave.Size = new System.Drawing.Size(130, 26);
            this.btnSave.Text = "Lưu quy tắc";
            this.btnAdd.Location = new System.Drawing.Point(150, 9);
            this.btnAdd.Size = new System.Drawing.Size(110, 26);
            this.btnAdd.Text = "Thêm quy tắc";
            this.btnDelete.Location = new System.Drawing.Point(268, 9);
            this.btnDelete.Size = new System.Drawing.Size(110, 26);
            this.btnDelete.Text = "Xóa quy tắc";
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 44);
            this.grid.MainView = this.view;
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { this.cboOwner, this.colorBgEdit, this.colorFgEdit });
            this.grid.Size = new System.Drawing.Size(1100, 576);
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.view });
            this.view.GridControl = this.grid;
            this.cboOwner.AutoHeight = false;
            this.cboOwner.Name = "cboOwner";
            this.colorBgEdit.AutoHeight = false;
            this.colorBgEdit.Name = "colorBgEdit";
            this.colorBgEdit.StoreColorAsInteger = false;
            this.colorFgEdit.AutoHeight = false;
            this.colorFgEdit.Name = "colorFgEdit";
            this.colorFgEdit.StoreColorAsInteger = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 620);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_OHD_RULE";
            this.Text = "Điều chỉnh quy tắc";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboOwner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBgEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorFgEdit)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
