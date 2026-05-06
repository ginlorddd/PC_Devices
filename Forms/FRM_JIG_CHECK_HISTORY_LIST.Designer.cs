namespace JigFlow.Forms
{
    partial class FRM_JIG_CHECK_HISTORY_LIST
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
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblRecord = new DevExpress.XtraEditors.LabelControl();
            this.lblRecordValue = new DevExpress.XtraEditors.LabelControl();
            this.lblMode = new DevExpress.XtraEditors.LabelControl();
            this.lblModeValue = new DevExpress.XtraEditors.LabelControl();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 56;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(16, 10);
            this.lblTitle.Text = "Lịch sử kiểm tra Jig";
            this.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnRefresh.Location = new System.Drawing.Point(1130, 12);
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.gcHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHistory.Location = new System.Drawing.Point(0, 56);
            this.gcHistory.MainView = this.gvHistory;
            this.gcHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvHistory });
            this.gvHistory.GridControl = this.gcHistory;

            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnApprove);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Controls.Add(this.lblRecord);
            this.panelBottom.Controls.Add(this.lblRecordValue);
            this.panelBottom.Controls.Add(this.lblMode);
            this.panelBottom.Controls.Add(this.lblModeValue);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 70;
            this.btnExport.Location = new System.Drawing.Point(16, 18); this.btnExport.Size = new System.Drawing.Size(90, 35); this.btnExport.Text = "Export"; this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            this.btnApprove.Location = new System.Drawing.Point(112, 18); this.btnApprove.Size = new System.Drawing.Size(90, 35); this.btnApprove.Text = "Approve"; this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            this.btnClose.Location = new System.Drawing.Point(208, 18); this.btnClose.Size = new System.Drawing.Size(90, 35); this.btnClose.Text = "Close"; this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.lblRecord.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblRecord.Location = new System.Drawing.Point(1010, 16);
            this.lblRecord.Appearance.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblRecord.Appearance.Options.UseFont = true;
            this.lblRecord.Text = "Record";
            this.lblRecordValue.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblRecordValue.Appearance.BackColor = System.Drawing.Color.White;
            this.lblRecordValue.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblRecordValue.Location = new System.Drawing.Point(1090, 14);
            this.lblRecordValue.Padding = new System.Windows.Forms.Padding(24, 2, 24, 2);
            this.lblRecordValue.Text = "0";
            this.lblMode.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblMode.Location = new System.Drawing.Point(1010, 43);
            this.lblMode.Appearance.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblMode.Appearance.Options.UseFont = true;
            this.lblMode.Text = "Mode";
            this.lblModeValue.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblModeValue.Appearance.BackColor = System.Drawing.Color.Black;
            this.lblModeValue.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblModeValue.Appearance.Options.UseBackColor = true;
            this.lblModeValue.Appearance.Options.UseForeColor = true;
            this.lblModeValue.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblModeValue.Location = new System.Drawing.Point(1090, 41);
            this.lblModeValue.Padding = new System.Windows.Forms.Padding(24, 2, 24, 2);
            this.lblModeValue.Text = "View";

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 700);
            this.Controls.Add(this.gcHistory);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_JIG_CHECK_HISTORY_LIST";
            this.Text = "Lịch sử kiểm tra Jig";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_JIG_CHECK_HISTORY_LIST_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl gcHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHistory;
        private System.Windows.Forms.Panel panelBottom;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblRecord;
        private DevExpress.XtraEditors.LabelControl lblRecordValue;
        private DevExpress.XtraEditors.LabelControl lblMode;
        private DevExpress.XtraEditors.LabelControl lblModeValue;
    }
}
