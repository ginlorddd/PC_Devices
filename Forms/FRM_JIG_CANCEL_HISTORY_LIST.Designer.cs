namespace JigFlow.Forms
{
    partial class FRM_JIG_CANCEL_HISTORY_LIST
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.gcHistory = new DevExpress.XtraGrid.GridControl();
            this.gvHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblRecord = new DevExpress.XtraEditors.LabelControl();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            this.panelTop.Controls.Add(this.lblTitle); this.panelTop.Controls.Add(this.btnRefresh); this.panelTop.Dock = System.Windows.Forms.DockStyle.Top; this.panelTop.Height = 56;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold); this.lblTitle.Appearance.Options.UseFont = true; this.lblTitle.Location = new System.Drawing.Point(12, 8); this.lblTitle.Text = "Danh sách Jig đã hủy";
            this.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right); this.btnRefresh.Location = new System.Drawing.Point(1680, 12); this.btnRefresh.Size = new System.Drawing.Size(100, 32); this.btnRefresh.Text = "Refresh"; this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.gcHistory.Dock = System.Windows.Forms.DockStyle.Fill; this.gcHistory.Location = new System.Drawing.Point(0, 56); this.gcHistory.MainView = this.gvHistory; this.gcHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvHistory });
            this.gvHistory.GridControl = this.gcHistory;
            this.panelBottom.Controls.Add(this.btnExport); this.panelBottom.Controls.Add(this.btnDelete); this.panelBottom.Controls.Add(this.btnClose); this.panelBottom.Controls.Add(this.lblRecord); this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom; this.panelBottom.Height = 86;
            this.btnExport.Location = new System.Drawing.Point(20, 18); this.btnExport.Size = new System.Drawing.Size(90, 35); this.btnExport.Text = "Export"; this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            this.btnDelete.Location = new System.Drawing.Point(116, 18); this.btnDelete.Size = new System.Drawing.Size(90, 35); this.btnDelete.Text = "Delete"; this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnClose.Location = new System.Drawing.Point(212, 18); this.btnClose.Size = new System.Drawing.Size(90, 35); this.btnClose.Text = "Close"; this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.lblRecord.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right); this.lblRecord.Location = new System.Drawing.Point(1650, 26); this.lblRecord.Text = "Record: 0";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; this.ClientSize = new System.Drawing.Size(1800, 900); this.Controls.Add(this.gcHistory); this.Controls.Add(this.panelBottom); this.Controls.Add(this.panelTop); this.Name = "FRM_JIG_CANCEL_HISTORY_LIST"; this.Text = "Lịch sử hủy Jig"; this.WindowState = System.Windows.Forms.FormWindowState.Maximized; this.Load += new System.EventHandler(this.FRM_JIG_CANCEL_HISTORY_LIST_Load);
            this.panelTop.ResumeLayout(false); this.panelTop.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.gcHistory)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).EndInit(); this.panelBottom.ResumeLayout(false); this.panelBottom.PerformLayout(); this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl gcHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHistory;
        private System.Windows.Forms.Panel panelBottom;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblRecord;
    }
}
