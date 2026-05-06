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
            this.txtSearchManagementNo = new DevExpress.XtraEditors.TextEdit();
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
            this.memoNote = new DevExpress.XtraEditors.MemoEdit();
            this.txtAbnormalNo = new DevExpress.XtraEditors.TextEdit();
            this.deExpectedCancelDate = new DevExpress.XtraEditors.DateEdit();
            this.lueReason = new DevExpress.XtraEditors.LookUpEdit();
            this.btnRegister = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit(); this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueManagementNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchManagementNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpJigInfo)).BeginInit(); this.grpJigInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.txtUseProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.txtJigType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrequency.Properties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.txtJigName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactory.Properties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpReason)).BeginInit(); this.grpReason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoNote.Properties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.txtAbnormalNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpectedCancelDate.Properties.CalendarTimeProperties)).BeginInit(); ((System.ComponentModel.ISupportInitialize)(this.deExpectedCancelDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueReason.Properties)).BeginInit(); this.SuspendLayout();
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold); this.lblTitle.Appearance.Options.UseFont = true; this.lblTitle.Location = new System.Drawing.Point(12, 12); this.lblTitle.Text = "Đăng ký hủy Jig";
            this.grpSearch.Controls.Add(this.btnSearch); this.grpSearch.Controls.Add(this.lueManagementNo); this.grpSearch.Controls.Add(this.txtSearchManagementNo); this.grpSearch.Controls.Add(this.lblManagementNo); this.grpSearch.Location = new System.Drawing.Point(12, 66); this.grpSearch.Size = new System.Drawing.Size(1360, 98); this.grpSearch.Text = "Search";
            this.lblManagementNo.Location = new System.Drawing.Point(24, 50); this.lblManagementNo.Text = "Số quản lý";
            this.txtSearchManagementNo.Location = new System.Drawing.Point(110, 46); this.txtSearchManagementNo.Size = new System.Drawing.Size(200, 22);
            this.lueManagementNo.Location = new System.Drawing.Point(320, 46); this.lueManagementNo.Size = new System.Drawing.Size(470, 22);
            this.btnSearch.Location = new System.Drawing.Point(1250, 40); this.btnSearch.Size = new System.Drawing.Size(90, 32); this.btnSearch.Text = "Search"; this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.grpJigInfo.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtDepartment, this.txtFactory, this.txtJigName, this.txtFrequency, this.txtJigType, this.txtSize, this.txtUseProduct, this.txtLocation });
            this.grpJigInfo.Location = new System.Drawing.Point(12, 170); this.grpJigInfo.Size = new System.Drawing.Size(1360, 230); this.grpJigInfo.Text = "Thông tin Jig";
            int leftX = 210; int rightX = 930; int row1 = 45; int rowH = 40;
            this.grpJigInfo.Controls.Add(new DevExpress.XtraEditors.LabelControl() { Location = new System.Drawing.Point(24, row1), Text = "Bộ phận" }); this.txtDepartment.Location = new System.Drawing.Point(leftX, row1 - 4); this.txtDepartment.Size = new System.Drawing.Size(450, 22);
            this.grpJigInfo.Controls.Add(new DevExpress.XtraEditors.LabelControl() { Location = new System.Drawing.Point(24, row1 + rowH), Text = "Tên Jig" }); this.txtJigName.Location = new System.Drawing.Point(leftX, row1 + rowH - 4); this.txtJigName.Size = new System.Drawing.Size(450, 22);
            this.grpJigInfo.Controls.Add(new DevExpress.XtraEditors.LabelControl() { Location = new System.Drawing.Point(24, row1 + rowH * 2), Text = "Loại Jig" }); this.txtJigType.Location = new System.Drawing.Point(leftX, row1 + rowH * 2 - 4); this.txtJigType.Size = new System.Drawing.Size(450, 22);
            this.grpJigInfo.Controls.Add(new DevExpress.XtraEditors.LabelControl() { Location = new System.Drawing.Point(24, row1 + rowH * 3), Text = "Sản phẩm sử dụng" }); this.txtUseProduct.Location = new System.Drawing.Point(leftX, row1 + rowH * 3 - 4); this.txtUseProduct.Size = new System.Drawing.Size(450, 22);
            this.grpJigInfo.Controls.Add(new DevExpress.XtraEditors.LabelControl() { Location = new System.Drawing.Point(24, row1 + rowH * 4), Text = "Vị trí" }); this.txtLocation.Location = new System.Drawing.Point(leftX, row1 + rowH * 4 - 4); this.txtLocation.Size = new System.Drawing.Size(450, 22);
            this.grpJigInfo.Controls.Add(new DevExpress.XtraEditors.LabelControl() { Location = new System.Drawing.Point(760, row1), Text = "Nhà máy" }); this.txtFactory.Location = new System.Drawing.Point(rightX, row1 - 4); this.txtFactory.Size = new System.Drawing.Size(410, 22);
            this.grpJigInfo.Controls.Add(new DevExpress.XtraEditors.LabelControl() { Location = new System.Drawing.Point(700, row1 + rowH), Text = "Tần suất kiểm tra" }); this.txtFrequency.Location = new System.Drawing.Point(rightX, row1 + rowH - 4); this.txtFrequency.Size = new System.Drawing.Size(410, 22);
            this.grpJigInfo.Controls.Add(new DevExpress.XtraEditors.LabelControl() { Location = new System.Drawing.Point(760, row1 + rowH * 2), Text = "Size" }); this.txtSize.Location = new System.Drawing.Point(rightX, row1 + rowH * 2 - 4); this.txtSize.Size = new System.Drawing.Size(410, 22);
            this.grpReason.Controls.AddRange(new System.Windows.Forms.Control[] { this.lueReason, this.deExpectedCancelDate, this.txtAbnormalNo, this.memoNote });
            this.grpReason.Location = new System.Drawing.Point(12, 406); this.grpReason.Size = new System.Drawing.Size(1360, 230); this.grpReason.Text = "Nguyên nhân hủy";
            this.grpReason.Controls.Add(new DevExpress.XtraEditors.LabelControl() { Location = new System.Drawing.Point(24, 50), Text = "Lí do hủy" }); this.lueReason.Location = new System.Drawing.Point(210, 46); this.lueReason.Size = new System.Drawing.Size(410, 22);
            this.grpReason.Controls.Add(new DevExpress.XtraEditors.LabelControl() { Location = new System.Drawing.Point(660, 50), Text = "Ngày hủy dự kiến" }); this.deExpectedCancelDate.Location = new System.Drawing.Point(900, 46); this.deExpectedCancelDate.Size = new System.Drawing.Size(430, 22);
            this.grpReason.Controls.Add(new DevExpress.XtraEditors.LabelControl() { Location = new System.Drawing.Point(24, 110), Text = "Số bất thường" }); this.txtAbnormalNo.Location = new System.Drawing.Point(210, 106); this.txtAbnormalNo.Size = new System.Drawing.Size(410, 22);
            this.grpReason.Controls.Add(new DevExpress.XtraEditors.LabelControl() { Location = new System.Drawing.Point(790, 110), Text = "Ghi chú" }); this.memoNote.Location = new System.Drawing.Point(900, 106); this.memoNote.Size = new System.Drawing.Size(430, 100);
            this.btnRegister.Location = new System.Drawing.Point(36, 658); this.btnRegister.Size = new System.Drawing.Size(160, 48); this.btnRegister.Text = "Register"; this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            this.btnClose.Location = new System.Drawing.Point(210, 658); this.btnClose.Size = new System.Drawing.Size(160, 48); this.btnClose.Text = "Close"; this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.ClientSize = new System.Drawing.Size(1384, 731); this.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblTitle, this.grpSearch, this.grpJigInfo, this.grpReason, this.btnRegister, this.btnClose }); this.Name = "FRM_JIG_CANCEL_REGISTER"; this.Text = "Đăng ký hủy Jig"; this.Load += new System.EventHandler(this.FRM_JIG_CANCEL_REGISTER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit(); this.grpSearch.ResumeLayout(false); this.grpSearch.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.lueManagementNo.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtSearchManagementNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpJigInfo)).EndInit(); this.grpJigInfo.ResumeLayout(false); this.grpJigInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtUseProduct.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtJigType.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtFrequency.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtJigName.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtFactory.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpReason)).EndInit(); this.grpReason.ResumeLayout(false); this.grpReason.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.memoNote.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtAbnormalNo.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.deExpectedCancelDate.Properties.CalendarTimeProperties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.deExpectedCancelDate.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.lueReason.Properties)).EndInit(); this.ResumeLayout(false); this.PerformLayout();
        }

        private DevExpress.XtraEditors.LabelControl lblTitle; private DevExpress.XtraEditors.GroupControl grpSearch; private DevExpress.XtraEditors.SimpleButton btnSearch; private DevExpress.XtraEditors.LookUpEdit lueManagementNo; private DevExpress.XtraEditors.TextEdit txtSearchManagementNo; private DevExpress.XtraEditors.LabelControl lblManagementNo; private DevExpress.XtraEditors.GroupControl grpJigInfo; private DevExpress.XtraEditors.TextEdit txtLocation; private DevExpress.XtraEditors.TextEdit txtUseProduct; private DevExpress.XtraEditors.TextEdit txtSize; private DevExpress.XtraEditors.TextEdit txtJigType; private DevExpress.XtraEditors.TextEdit txtFrequency; private DevExpress.XtraEditors.TextEdit txtJigName; private DevExpress.XtraEditors.TextEdit txtFactory; private DevExpress.XtraEditors.TextEdit txtDepartment; private DevExpress.XtraEditors.GroupControl grpReason; private DevExpress.XtraEditors.MemoEdit memoNote; private DevExpress.XtraEditors.TextEdit txtAbnormalNo; private DevExpress.XtraEditors.DateEdit deExpectedCancelDate; private DevExpress.XtraEditors.LookUpEdit lueReason; private DevExpress.XtraEditors.SimpleButton btnRegister; private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
