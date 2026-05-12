namespace JigFlow.Forms
{
    partial class FRM_JIG_FUNCTION_LIST
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
            this.gcJig = new DevExpress.XtraGrid.GridControl();
            this.gvJig = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblRecord = new DevExpress.XtraEditors.LabelControl();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcJig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJig)).BeginInit();
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
            this.lblTitle.Text = "Danh sách Jig chức năng";
            // btnRefresh
            this.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnRefresh.Location = new System.Drawing.Point(1110, 12);
            this.btnRefresh.Size = new System.Drawing.Size(120, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // gcJig
            this.gcJig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcJig.Location = new System.Drawing.Point(0, 56);
            this.gcJig.MainView = this.gvJig;
            this.gcJig.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvJig });
            // gvJig
            this.gvJig.GridControl = this.gcJig;
            this.gvJig.OptionsBehavior.Editable = false;
            this.gvJig.Columns.AddVisible("STT", "STT");
            this.gvJig.Columns.AddVisible("CONTROL_NO", "Control No.");
            this.gvJig.Columns.AddVisible("JIG_NAME", "Tên Jig");
            this.gvJig.Columns.AddVisible("JIG_TYPE", "Loại Jig");
            this.gvJig.Columns.AddVisible("JIG_SIZE", "Size");
            this.gvJig.Columns.AddVisible("USE_PRODUCT", "Sản phẩm sử dụng");
            this.gvJig.Columns.AddVisible("LOCATION_CODE", "Vị trí");
            this.gvJig.Columns.AddVisible("STATUS_USE", "Trạng thái sử dụng");
            this.gvJig.Columns.AddVisible("USE_SECTION", "Bộ phận sử dụng");
            this.gvJig.Columns.AddVisible("LAST_CHECK_DATE", "Ngày kiểm tra định kỳ gần nhất");
            this.gvJig.Columns.AddVisible("NEXT_CHECK_PLAN_DATE", "Kế hoạch kiểm tra định kỳ tiếp theo");
            this.gvJig.Columns.AddVisible("CHECK_RESULT", "Kết quả kiểm tra định kỳ");
            this.gvJig.Columns.AddVisible("CHECK_FREQUENCY", "Tần suất kiểm tra định kỳ");
            // panelBottom
            this.panelBottom.Controls.Add(this.lblRecord);
            this.panelBottom.Controls.Add(this.btnImport);
            this.panelBottom.Controls.Add(this.btnExport);
            this.panelBottom.Controls.Add(this.btnUpdate);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 70;
            // buttons bottom
            this.btnImport.Location = new System.Drawing.Point(16, 18); this.btnImport.Size = new System.Drawing.Size(90, 35); this.btnImport.Text = "Import"; this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            this.btnExport.Location = new System.Drawing.Point(112, 18); this.btnExport.Size = new System.Drawing.Size(90, 35); this.btnExport.Text = "Export"; this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            this.btnUpdate.Location = new System.Drawing.Point(208, 18); this.btnUpdate.Size = new System.Drawing.Size(90, 35); this.btnUpdate.Text = "Edit"; this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnClose.Location = new System.Drawing.Point(304, 18); this.btnClose.Size = new System.Drawing.Size(90, 35); this.btnClose.Text = "Close"; this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.lblRecord.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblRecord.Location = new System.Drawing.Point(1080, 28);
            this.lblRecord.Text = "Record: 0";
            // form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 700);
            this.Controls.Add(this.gcJig);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_JIG_FUNCTION_LIST";
            this.Text = "Jig chức năng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_JIG_FUNCTION_LIST_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcJig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJig)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl gcJig;
        private DevExpress.XtraGrid.Views.Grid.GridView gvJig;
        private System.Windows.Forms.Panel panelBottom;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblRecord;
    }
}
