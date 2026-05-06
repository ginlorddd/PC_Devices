namespace JigFlow.Forms
{
    partial class FRM_JIG_CANCEL_REGISTER
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.grpSearch = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lueManagementNo = new DevExpress.XtraEditors.LookUpEdit();
            this.lblManagementNo = new DevExpress.XtraEditors.LabelControl();
            this.grpJigInfo = new DevExpress.XtraEditors.GroupControl();
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.txtUseProduct = new DevExpress.XtraEditors.TextEdit();
            this.txtSize = new DevExpress.XtraEditors.TextEdit();
            this.txtJigType = new DevExpress.XtraEditors.TextEdit();
            this.txtFrequency = new DevExpress.XtraEditors.TextEdit();
            this.txtJigName = new DevExpress.XtraEditors.TextEdit();
            this.txtFactory = new DevExpress.XtraEditors.TextEdit();
            this.txtDepartment = new DevExpress.XtraEditors.TextEdit();
            this.grpReason = new DevExpress.XtraEditors.GroupControl();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.txtAbnormalNo = new DevExpress.XtraEditors.TextEdit();
            this.dtCancelPlan = new DevExpress.XtraEditors.DateEdit();
            this.cboCancelReason = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnRegister = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit(); this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueManagementNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpJigInfo)).BeginInit(); this.grpJigInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.txtUseProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.txtJigType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrequency.Properties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.txtJigName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactory.Properties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpReason)).BeginInit(); this.grpReason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.txtAbnormalNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCancelPlan.Properties.CalendarTimeProperties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.dtCancelPlan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCancelReason.Properties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.panelButtons)).BeginInit(); this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold); this.lblTitle.Appearance.Options.UseFont = true; this.lblTitle.Location = new System.Drawing.Point(12, 12); this.lblTitle.Text = "Đăng ký hủy Jig";
            this.grpSearch.Controls.Add(this.btnSearch); this.grpSearch.Controls.Add(this.lueManagementNo); this.grpSearch.Controls.Add(this.lblManagementNo); this.grpSearch.Location = new System.Drawing.Point(12, 62); this.grpSearch.Size = new System.Drawing.Size(1210, 90); this.grpSearch.Text = "Search";
            this.lblManagementNo.Location = new System.Drawing.Point(20, 45); this.lblManagementNo.Text = "Số quản lý";
            this.lueManagementNo.Location = new System.Drawing.Point(110, 42); this.lueManagementNo.Size = new System.Drawing.Size(870, 22);
            this.btnSearch.Location = new System.Drawing.Point(1020, 39); this.btnSearch.Size = new System.Drawing.Size(150, 28); this.btnSearch.Text = "Search"; this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.grpJigInfo.Location = new System.Drawing.Point(12, 160); this.grpJigInfo.Size = new System.Drawing.Size(1210, 230); this.grpJigInfo.Text = "Thông tin Jig";
            DevReadOnly(this.txtDepartment, 20, 45, 400); DevReadOnly(this.txtFactory, 700, 45, 250); DevReadOnly(this.txtJigName, 20, 85, 400); DevReadOnly(this.txtFrequency, 700, 85, 470);
            DevReadOnly(this.txtJigType, 20, 125, 400); DevReadOnly(this.txtSize, 700, 125, 470); DevReadOnly(this.txtUseProduct, 20, 165, 400); DevReadOnly(this.txtLocation, 20, 200, 400);
            this.grpJigInfo.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtDepartment, this.txtFactory, this.txtJigName, this.txtFrequency, this.txtJigType, this.txtSize, this.txtUseProduct, this.txtLocation });
            this.grpReason.Location = new System.Drawing.Point(12, 400); this.grpReason.Size = new System.Drawing.Size(1210, 180); this.grpReason.Text = "Nguyên nhân hủy";
            this.cboCancelReason.Location = new System.Drawing.Point(20, 45); this.cboCancelReason.Size = new System.Drawing.Size(400, 22);
            this.dtCancelPlan.Location = new System.Drawing.Point(700, 45); this.dtCancelPlan.Size = new System.Drawing.Size(470, 22);
            this.txtAbnormalNo.Location = new System.Drawing.Point(20, 85); this.txtAbnormalNo.Size = new System.Drawing.Size(400, 22);
            this.txtNote.Location = new System.Drawing.Point(700, 85); this.txtNote.Size = new System.Drawing.Size(470, 80);
            this.grpReason.Controls.AddRange(new System.Windows.Forms.Control[] { this.cboCancelReason, this.dtCancelPlan, this.txtAbnormalNo, this.txtNote });
            this.panelButtons.Location = new System.Drawing.Point(12, 590); this.panelButtons.Size = new System.Drawing.Size(1210, 70); this.panelButtons.Controls.Add(this.btnClose); this.panelButtons.Controls.Add(this.btnRegister);
            this.btnRegister.Location = new System.Drawing.Point(20, 18); this.btnRegister.Size = new System.Drawing.Size(120, 34); this.btnRegister.Text = "Register"; this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            this.btnClose.Location = new System.Drawing.Point(155, 18); this.btnClose.Size = new System.Drawing.Size(120, 34); this.btnClose.Text = "Close"; this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; this.ClientSize = new System.Drawing.Size(1234, 676);
            this.Controls.Add(this.panelButtons); this.Controls.Add(this.grpReason); this.Controls.Add(this.grpJigInfo); this.Controls.Add(this.grpSearch); this.Controls.Add(this.lblTitle);
            this.Name = "FRM_JIG_CANCEL_REGISTER"; this.Text = "Đăng ký hủy Jig"; this.Load += new System.EventHandler(this.FRM_JIG_CANCEL_REGISTER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit(); this.grpSearch.ResumeLayout(false); this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueManagementNo.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.grpJigInfo)).EndInit(); this.grpJigInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpReason)).EndInit(); this.grpReason.ResumeLayout(false); ((System.ComponentModel.ISupportInitialize)(this.panelButtons)).EndInit(); this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false); this.PerformLayout();
        }

        private void DevReadOnly(DevExpress.XtraEditors.TextEdit txt, int x, int y, int w) { txt.Location = new System.Drawing.Point(x, y); txt.Size = new System.Drawing.Size(w, 22); txt.Properties.ReadOnly = true; }

        private DevExpress.XtraEditors.LabelControl lblTitle; private DevExpress.XtraEditors.GroupControl grpSearch; private DevExpress.XtraEditors.SimpleButton btnSearch; private DevExpress.XtraEditors.LookUpEdit lueManagementNo; private DevExpress.XtraEditors.LabelControl lblManagementNo;
        private DevExpress.XtraEditors.GroupControl grpJigInfo; private DevExpress.XtraEditors.TextEdit txtDepartment; private DevExpress.XtraEditors.TextEdit txtFactory; private DevExpress.XtraEditors.TextEdit txtJigName; private DevExpress.XtraEditors.TextEdit txtFrequency; private DevExpress.XtraEditors.TextEdit txtJigType; private DevExpress.XtraEditors.TextEdit txtSize; private DevExpress.XtraEditors.TextEdit txtUseProduct; private DevExpress.XtraEditors.TextEdit txtLocation;
        private DevExpress.XtraEditors.GroupControl grpReason; private DevExpress.XtraEditors.ComboBoxEdit cboCancelReason; private DevExpress.XtraEditors.DateEdit dtCancelPlan; private DevExpress.XtraEditors.TextEdit txtAbnormalNo; private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.PanelControl panelButtons; private DevExpress.XtraEditors.SimpleButton btnRegister; private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
