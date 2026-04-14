namespace DM_OHD.FRM
{
    partial class FRM_OHD_RULE
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboOwner;

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
            this.cboOwner = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboOwner)).BeginInit();
            this.SuspendLayout();
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1100, 44);
            this.panelTop.Controls.Add(this.btnSave);
            this.btnSave.Location = new System.Drawing.Point(12, 9);
            this.btnSave.Size = new System.Drawing.Size(130, 26);
            this.btnSave.Text = "Lưu quy tắc";
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 44);
            this.grid.MainView = this.view;
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { this.cboOwner });
            this.grid.Size = new System.Drawing.Size(1100, 576);
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.view });
            this.view.GridControl = this.grid;
            this.cboOwner.AutoHeight = false;
            this.cboOwner.Name = "cboOwner";
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
            this.ResumeLayout(false);
        }
    }
}
