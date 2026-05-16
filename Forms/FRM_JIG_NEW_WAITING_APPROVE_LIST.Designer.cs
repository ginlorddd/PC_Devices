namespace JigFlow.Forms
{
    partial class FRM_JIG_NEW_WAITING_APPROVE_LIST
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
            this.lblRecord = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWaiting)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // panelTop
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 56;
            // lblTitle
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Text = "Danh sách Jig mới chờ duyệt";
            // btnRefresh
            this.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnRefresh.Location = new System.Drawing.Point(1110, 12);
            this.btnRefresh.Size = new System.Drawing.Size(120, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // gcWaiting
            this.gcWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWaiting.Location = new System.Drawing.Point(0, 56);
            this.gcWaiting.MainView = this.gvWaiting;
            this.gcWaiting.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvWaiting });
            // gvWaiting
            this.gvWaiting.GridControl = this.gcWaiting;
            this.gvWaiting.OptionsBehavior.Editable = false;
            this.gvWaiting.Columns.AddVisible("STT", "STT");
            this.gvWaiting.Columns.AddVisible("MANAGEMENT_NO", "Control No.");
            this.gvWaiting.Columns.AddVisible("JIG_NAME", "Tên Jig");
            this.gvWaiting.Columns.AddVisible("JIG_TYPE_CODE", "Loại Jig");
            this.gvWaiting.Columns.AddVisible("JIG_SIZE", "Size");
            this.gvWaiting.Columns.AddVisible("USE_PRODUCT", "Sản phẩm sử dụng");
            this.gvWaiting.Columns.AddVisible("LOCATION_CODE", "Vị trí");
            this.gvWaiting.Columns.AddVisible("DEPARTMENT", "Bộ phận đăng ký");
            this.gvWaiting.Columns.AddVisible("REQUEST_AT", "Ngày đăng ký");
            this.gvWaiting.Columns.AddVisible("REQUEST_BY", "Người đăng ký");
            this.gvWaiting.Columns.AddVisible("STATUS_USE", "Kết quả kiểm tra");
            this.gvWaiting.Columns.AddVisible("FIRST_CHECK_RESULT_FILE", "File kết quả");
            // panelBottom
            this.panelBottom.Controls.Add(this.lblRecord);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnUpdate);
            this.panelBottom.Controls.Add(this.btnApprove);
            this.panelBottom.Controls.Add(this.btnDelete);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 70;
            // buttons
            this.btnExport.Location = new System.Drawing.Point(16, 18); this.btnExport.Size = new System.Drawing.Size(90, 35); this.btnExport.Text = "Export"; this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            this.btnUpdate.Location = new System.Drawing.Point(112, 18); this.btnUpdate.Size = new System.Drawing.Size(90, 35); this.btnUpdate.Text = "Edit"; this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnApprove.Location = new System.Drawing.Point(208, 18); this.btnApprove.Size = new System.Drawing.Size(90, 35); this.btnApprove.Text = "Approve"; this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            this.btnDelete.Location = new System.Drawing.Point(304, 18); this.btnDelete.Size = new System.Drawing.Size(90, 35); this.btnDelete.Text = "Delete"; this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnClose.Location = new System.Drawing.Point(400, 18); this.btnClose.Size = new System.Drawing.Size(90, 35); this.btnClose.Text = "Close"; this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.lblRecord.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblRecord.Location = new System.Drawing.Point(1080, 28);
            this.lblRecord.Text = "Record: 0";
            // form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 700);
            this.Controls.Add(this.gcWaiting);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_JIG_NEW_WAITING_APPROVE_LIST";
            this.Text = "Jig mới chờ duyệt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_JIG_NEW_WAITING_APPROVE_LIST_Load);
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
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblRecord;
    }
}
