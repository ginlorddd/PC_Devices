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
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWaiting)).BeginInit();
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
            // grid
            this.gcWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWaiting.Location = new System.Drawing.Point(0, 56);
            this.gcWaiting.MainView = this.gvWaiting;
            this.gcWaiting.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvWaiting });

            this.gvWaiting.GridControl = this.gcWaiting;
            this.gvWaiting.Columns.AddVisible("STT", "STT");
            this.gvWaiting.Columns.AddVisible("MANAGEMENT_NO", "Số quản lý");
            this.gvWaiting.Columns.AddVisible("JIG_NAME", "Tên Jig");
            this.gvWaiting.Columns.AddVisible("JIG_TYPE_CODE", "Loại Jig");
            this.gvWaiting.Columns.AddVisible("JIG_SIZE", "Size");
            this.gvWaiting.Columns.AddVisible("USE_PRODUCT", "Sản phẩm sử dụng");
            this.gvWaiting.Columns.AddVisible("DEPARTMENT", "Bộ phận");
            this.gvWaiting.Columns.AddVisible("FACTORY", "Nhà máy");
            this.gvWaiting.Columns.AddVisible("CHECK_FREQUENCY", "Tần suất kiểm tra");
            this.gvWaiting.Columns.AddVisible("STATUS_USE", "Trạng thái sử dụng");
            this.gvWaiting.Columns.AddVisible("REQUEST_STATUS", "Trạng thái yêu cầu");
            this.gvWaiting.Columns.AddVisible("REQUEST_BY", "Người yêu cầu");
            this.gvWaiting.Columns.AddVisible("REQUEST_AT", "Thời gian yêu cầu");

            // form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 700);
            this.Controls.Add(this.gcWaiting);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_JIG_NEW_WAITING_APPROVE_LIST";
            this.Text = "Jig mới chờ duyệt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_JIG_NEW_WAITING_APPROVE_LIST_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWaiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWaiting)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl gcWaiting;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWaiting;
    }
}
