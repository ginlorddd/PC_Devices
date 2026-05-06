namespace JigFlow.Forms
{
    partial class FRM_JIG_CANCEL_WAITING_APPROVE_LIST
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
            this.gcWaiting = new DevExpress.XtraGrid.GridControl();
            this.gvWaiting = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblRecord = new DevExpress.XtraEditors.LabelControl();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWaiting)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1800, 56);
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 8);
            this.lblTitle.Text = "Danh sách Jig đăng ký hủy chờ duyệt";
            this.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnRefresh.Location = new System.Drawing.Point(1680, 12);
            this.btnRefresh.Size = new System.Drawing.Size(100, 32);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.gcWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWaiting.Location = new System.Drawing.Point(0, 56);
            this.gcWaiting.MainView = this.gvWaiting;
            this.gcWaiting.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvWaiting });
            this.gvWaiting.GridControl = this.gcWaiting;
            this.panelBottom.Controls.Add(this.btnDelete);
            this.panelBottom.Controls.Add(this.btnApprove);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Controls.Add(this.lblRecord);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Size = new System.Drawing.Size(1800, 86);
            this.btnDelete.Location = new System.Drawing.Point(20, 12); this.btnDelete.Size = new System.Drawing.Size(96, 30); this.btnDelete.Text = "Delete"; this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnApprove.Location = new System.Drawing.Point(124, 12); this.btnApprove.Size = new System.Drawing.Size(96, 30); this.btnApprove.Text = "Approved"; this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            this.btnExport.Location = new System.Drawing.Point(20, 48); this.btnExport.Size = new System.Drawing.Size(96, 30); this.btnExport.Text = "Export"; this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            this.btnClose.Location = new System.Drawing.Point(124, 48); this.btnClose.Size = new System.Drawing.Size(96, 30); this.btnClose.Text = "Close"; this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.lblRecord.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.lblRecord.Location = new System.Drawing.Point(1650, 54);
            this.lblRecord.Text = "Record: 0";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 900);
            this.Controls.Add(this.gcWaiting);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_JIG_CANCEL_WAITING_APPROVE_LIST";
            this.Text = "Jig hủy chờ duyệt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_JIG_CANCEL_WAITING_APPROVE_LIST_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWaiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWaiting)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl gcWaiting;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWaiting;
        private System.Windows.Forms.Panel panelBottom;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblRecord;
    }
}
