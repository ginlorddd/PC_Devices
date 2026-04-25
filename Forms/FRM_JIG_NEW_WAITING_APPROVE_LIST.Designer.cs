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
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblRecordCaption = new DevExpress.XtraEditors.LabelControl();
            this.txtRecord = new DevExpress.XtraEditors.TextEdit();
            this.lblModeCaption = new DevExpress.XtraEditors.LabelControl();
            this.txtMode = new DevExpress.XtraEditors.TextEdit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWaiting)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(241, 245, 252);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1380, 64);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(22, 43, 93);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(22, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(358, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh sách Jig mới chờ duyệt";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(1230, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(132, 36);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gcWaiting
            // 
            this.gcWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcWaiting.Location = new System.Drawing.Point(0, 64);
            this.gcWaiting.MainView = this.gvWaiting;
            this.gcWaiting.Name = "gcWaiting";
            this.gcWaiting.Size = new System.Drawing.Size(1380, 634);
            this.gcWaiting.TabIndex = 1;
            this.gcWaiting.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWaiting});
            // 
            // gvWaiting
            // 
            this.gvWaiting.GridControl = this.gcWaiting;
            this.gvWaiting.Name = "gvWaiting";
            this.gvWaiting.OptionsView.ShowGroupPanel = false;
            this.gvWaiting.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gvWaiting.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvWaiting.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gvWaiting.Appearance.Row.Options.UseFont = true;
            this.gvWaiting.RowHeight = 28;
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
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(245, 247, 252);
            this.panelBottom.Controls.Add(this.panelActions);
            this.panelBottom.Controls.Add(this.panelStatus);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 698);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1380, 112);
            this.panelBottom.TabIndex = 2;
            // 
            // panelActions
            // 
            this.panelActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActions.Controls.Add(this.btnUpdate);
            this.panelActions.Controls.Add(this.btnApprove);
            this.panelActions.Controls.Add(this.btnExport);
            this.panelActions.Controls.Add(this.btnDelete);
            this.panelActions.Controls.Add(this.btnClose);
            this.panelActions.Location = new System.Drawing.Point(22, 12);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(540, 88);
            this.panelActions.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Location = new System.Drawing.Point(16, 11);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(132, 28);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnApprove.Appearance.Options.UseFont = true;
            this.btnApprove.Location = new System.Drawing.Point(158, 11);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(304, 35);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Location = new System.Drawing.Point(16, 49);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(132, 28);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Location = new System.Drawing.Point(158, 49);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(149, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(313, 49);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.Controls.Add(this.lblRecordCaption);
            this.panelStatus.Controls.Add(this.txtRecord);
            this.panelStatus.Controls.Add(this.lblModeCaption);
            this.panelStatus.Controls.Add(this.txtMode);
            this.panelStatus.Location = new System.Drawing.Point(1136, 18);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(226, 74);
            this.panelStatus.TabIndex = 1;
            // 
            // lblRecordCaption
            // 
            this.lblRecordCaption.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecordCaption.Appearance.Options.UseFont = true;
            this.lblRecordCaption.Location = new System.Drawing.Point(4, 4);
            this.lblRecordCaption.Name = "lblRecordCaption";
            this.lblRecordCaption.Size = new System.Drawing.Size(52, 21);
            this.lblRecordCaption.TabIndex = 0;
            this.lblRecordCaption.Text = "Record";
            // 
            // txtRecord
            // 
            this.txtRecord.Location = new System.Drawing.Point(90, 3);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtRecord.Properties.Appearance.Options.UseFont = true;
            this.txtRecord.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtRecord.Properties.ReadOnly = true;
            this.txtRecord.Size = new System.Drawing.Size(130, 28);
            this.txtRecord.TabIndex = 1;
            // 
            // lblModeCaption
            // 
            this.lblModeCaption.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblModeCaption.Appearance.Options.UseFont = true;
            this.lblModeCaption.Location = new System.Drawing.Point(4, 42);
            this.lblModeCaption.Name = "lblModeCaption";
            this.lblModeCaption.Size = new System.Drawing.Size(41, 21);
            this.lblModeCaption.TabIndex = 2;
            this.lblModeCaption.Text = "Mode";
            // 
            // txtMode
            // 
            this.txtMode.Location = new System.Drawing.Point(90, 39);
            this.txtMode.Name = "txtMode";
            this.txtMode.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.txtMode.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtMode.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtMode.Properties.Appearance.Options.UseBackColor = true;
            this.txtMode.Properties.Appearance.Options.UseFont = true;
            this.txtMode.Properties.Appearance.Options.UseForeColor = true;
            this.txtMode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtMode.Properties.ReadOnly = true;
            this.txtMode.Size = new System.Drawing.Size(130, 28);
            this.txtMode.TabIndex = 3;
            // 
            // FRM_JIG_NEW_WAITING_APPROVE_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 810);
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
            this.panelActions.ResumeLayout(false);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMode.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl gcWaiting;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWaiting;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelActions;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Panel panelStatus;
        private DevExpress.XtraEditors.LabelControl lblRecordCaption;
        private DevExpress.XtraEditors.TextEdit txtRecord;
        private DevExpress.XtraEditors.LabelControl lblModeCaption;
        private DevExpress.XtraEditors.TextEdit txtMode;
    }
}
