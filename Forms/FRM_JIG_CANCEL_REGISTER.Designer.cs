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
            this.lblManagementNo = new DevExpress.XtraEditors.LabelControl();
            this.txtSearchManagementNo = new DevExpress.XtraEditors.TextEdit();
            this.lueManagementNo = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.grpJigInfo = new DevExpress.XtraEditors.GroupControl();
            this.lblDepartment = new DevExpress.XtraEditors.LabelControl();
            this.lblJigName = new DevExpress.XtraEditors.LabelControl();
            this.lblJigType = new DevExpress.XtraEditors.LabelControl();
            this.lblUseProduct = new DevExpress.XtraEditors.LabelControl();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.lblFactory = new DevExpress.XtraEditors.LabelControl();
            this.lblFrequency = new DevExpress.XtraEditors.LabelControl();
            this.lblSize = new DevExpress.XtraEditors.LabelControl();
            this.txtDepartment = new DevExpress.XtraEditors.TextEdit();
            this.txtJigName = new DevExpress.XtraEditors.TextEdit();
            this.txtJigType = new DevExpress.XtraEditors.TextEdit();
            this.txtUseProduct = new DevExpress.XtraEditors.TextEdit();
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.txtFactory = new DevExpress.XtraEditors.TextEdit();
            this.txtFrequency = new DevExpress.XtraEditors.TextEdit();
            this.txtSize = new DevExpress.XtraEditors.TextEdit();
            this.grpReason = new DevExpress.XtraEditors.GroupControl();
            this.lblReason = new DevExpress.XtraEditors.LabelControl();
            this.lblExpectedDate = new DevExpress.XtraEditors.LabelControl();
            this.lblAbnormalNo = new DevExpress.XtraEditors.LabelControl();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.lueReason = new DevExpress.XtraEditors.LookUpEdit();
            this.deExpectedCancelDate = new DevExpress.XtraEditors.DateEdit();
            this.txtAbnormalNo = new DevExpress.XtraEditors.TextEdit();
            this.memoNote = new DevExpress.XtraEditors.MemoEdit();
            this.btnRegister = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchManagementNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueManagementNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpJigInfo)).BeginInit();
            this.grpJigInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJigName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJigType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUseProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpReason)).BeginInit();
            this.grpReason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpectedCancelDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpectedCancelDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbnormalNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoNote.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(282, 45);
            this.lblTitle.Text = "Đăng ký hủy Jig";
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.lblManagementNo);
            this.grpSearch.Controls.Add(this.txtSearchManagementNo);
            this.grpSearch.Controls.Add(this.lueManagementNo);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Location = new System.Drawing.Point(16, 72);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(1360, 96);
            this.grpSearch.Text = "Search";
            // 
            // lblManagementNo
            // 
            this.lblManagementNo.Location = new System.Drawing.Point(24, 50);
            this.lblManagementNo.Name = "lblManagementNo";
            this.lblManagementNo.Size = new System.Drawing.Size(62, 16);
            this.lblManagementNo.Text = "Số quản lý";
            // 
            // txtSearchManagementNo
            // 
            this.txtSearchManagementNo.Location = new System.Drawing.Point(124, 46);
            this.txtSearchManagementNo.Name = "txtSearchManagementNo";
            this.txtSearchManagementNo.Size = new System.Drawing.Size(210, 22);
            // 
            // lueManagementNo
            // 
            this.lueManagementNo.Location = new System.Drawing.Point(344, 46);
            this.lueManagementNo.Name = "lueManagementNo";
            this.lueManagementNo.Size = new System.Drawing.Size(470, 22);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1246, 42);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpJigInfo
            // 
            this.grpJigInfo.Controls.Add(this.lblDepartment);
            this.grpJigInfo.Controls.Add(this.lblJigName);
            this.grpJigInfo.Controls.Add(this.lblJigType);
            this.grpJigInfo.Controls.Add(this.lblUseProduct);
            this.grpJigInfo.Controls.Add(this.lblLocation);
            this.grpJigInfo.Controls.Add(this.lblFactory);
            this.grpJigInfo.Controls.Add(this.lblFrequency);
            this.grpJigInfo.Controls.Add(this.lblSize);
            this.grpJigInfo.Controls.Add(this.txtDepartment);
            this.grpJigInfo.Controls.Add(this.txtJigName);
            this.grpJigInfo.Controls.Add(this.txtJigType);
            this.grpJigInfo.Controls.Add(this.txtUseProduct);
            this.grpJigInfo.Controls.Add(this.txtLocation);
            this.grpJigInfo.Controls.Add(this.txtFactory);
            this.grpJigInfo.Controls.Add(this.txtFrequency);
            this.grpJigInfo.Controls.Add(this.txtSize);
            this.grpJigInfo.Location = new System.Drawing.Point(16, 176);
            this.grpJigInfo.Name = "grpJigInfo";
            this.grpJigInfo.Size = new System.Drawing.Size(1360, 230);
            this.grpJigInfo.Text = "Thông tin Jig";
            this.lblDepartment.Location = new System.Drawing.Point(24, 45); this.lblDepartment.Text = "Bộ phận";
            this.lblJigName.Location = new System.Drawing.Point(24, 84); this.lblJigName.Text = "Tên Jig";
            this.lblJigType.Location = new System.Drawing.Point(24, 123); this.lblJigType.Text = "Loại Jig";
            this.lblUseProduct.Location = new System.Drawing.Point(24, 162); this.lblUseProduct.Text = "Sản phẩm sử dụng";
            this.lblLocation.Location = new System.Drawing.Point(24, 201); this.lblLocation.Text = "Vị trí";
            this.lblFactory.Location = new System.Drawing.Point(760, 45); this.lblFactory.Text = "Nhà máy";
            this.lblFrequency.Location = new System.Drawing.Point(760, 84); this.lblFrequency.Text = "Tần suất kiểm tra";
            this.lblSize.Location = new System.Drawing.Point(760, 123); this.lblSize.Text = "Size";
            this.txtDepartment.Location = new System.Drawing.Point(210, 41); this.txtDepartment.Size = new System.Drawing.Size(450, 22);
            this.txtJigName.Location = new System.Drawing.Point(210, 80); this.txtJigName.Size = new System.Drawing.Size(450, 22);
            this.txtJigType.Location = new System.Drawing.Point(210, 119); this.txtJigType.Size = new System.Drawing.Size(450, 22);
            this.txtUseProduct.Location = new System.Drawing.Point(210, 158); this.txtUseProduct.Size = new System.Drawing.Size(450, 22);
            this.txtLocation.Location = new System.Drawing.Point(210, 197); this.txtLocation.Size = new System.Drawing.Size(450, 22);
            this.txtFactory.Location = new System.Drawing.Point(930, 41); this.txtFactory.Size = new System.Drawing.Size(406, 22);
            this.txtFrequency.Location = new System.Drawing.Point(930, 80); this.txtFrequency.Size = new System.Drawing.Size(406, 22);
            this.txtSize.Location = new System.Drawing.Point(930, 119); this.txtSize.Size = new System.Drawing.Size(406, 22);
            // 
            // grpReason
            // 
            this.grpReason.Controls.Add(this.lblReason);
            this.grpReason.Controls.Add(this.lblExpectedDate);
            this.grpReason.Controls.Add(this.lblAbnormalNo);
            this.grpReason.Controls.Add(this.lblNote);
            this.grpReason.Controls.Add(this.lueReason);
            this.grpReason.Controls.Add(this.deExpectedCancelDate);
            this.grpReason.Controls.Add(this.txtAbnormalNo);
            this.grpReason.Controls.Add(this.memoNote);
            this.grpReason.Location = new System.Drawing.Point(16, 412);
            this.grpReason.Name = "grpReason";
            this.grpReason.Size = new System.Drawing.Size(1360, 230);
            this.grpReason.Text = "Nguyên nhân hủy";
            this.lblReason.Location = new System.Drawing.Point(24, 56); this.lblReason.Text = "Lí do hủy";
            this.lblExpectedDate.Location = new System.Drawing.Point(760, 56); this.lblExpectedDate.Text = "Ngày hủy dự kiến";
            this.lblAbnormalNo.Location = new System.Drawing.Point(24, 113); this.lblAbnormalNo.Text = "Số bất thường";
            this.lblNote.Location = new System.Drawing.Point(760, 113); this.lblNote.Text = "Ghi chú";
            this.lueReason.Location = new System.Drawing.Point(210, 52); this.lueReason.Size = new System.Drawing.Size(410, 22);
            this.deExpectedCancelDate.Location = new System.Drawing.Point(930, 52); this.deExpectedCancelDate.Size = new System.Drawing.Size(406, 22);
            this.txtAbnormalNo.Location = new System.Drawing.Point(210, 109); this.txtAbnormalNo.Size = new System.Drawing.Size(410, 22);
            this.memoNote.Location = new System.Drawing.Point(930, 109); this.memoNote.Size = new System.Drawing.Size(406, 100);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(40, 658);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(160, 46);
            this.btnRegister.Text = "Register";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(216, 658);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 46);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FRM_JIG_CANCEL_REGISTER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 730);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.grpReason);
            this.Controls.Add(this.grpJigInfo);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.lblTitle);
            this.Name = "FRM_JIG_CANCEL_REGISTER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký hủy Jig";
            this.Load += new System.EventHandler(this.FRM_JIG_CANCEL_REGISTER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchManagementNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueManagementNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpJigInfo)).EndInit();
            this.grpJigInfo.ResumeLayout(false);
            this.grpJigInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJigName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJigType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUseProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpReason)).EndInit();
            this.grpReason.ResumeLayout(false);
            this.grpReason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpectedCancelDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpectedCancelDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbnormalNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoNote.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.GroupControl grpSearch;
        private DevExpress.XtraEditors.LabelControl lblManagementNo;
        private DevExpress.XtraEditors.TextEdit txtSearchManagementNo;
        private DevExpress.XtraEditors.LookUpEdit lueManagementNo;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.GroupControl grpJigInfo;
        private DevExpress.XtraEditors.LabelControl lblDepartment;
        private DevExpress.XtraEditors.LabelControl lblJigName;
        private DevExpress.XtraEditors.LabelControl lblJigType;
        private DevExpress.XtraEditors.LabelControl lblUseProduct;
        private DevExpress.XtraEditors.LabelControl lblLocation;
        private DevExpress.XtraEditors.LabelControl lblFactory;
        private DevExpress.XtraEditors.LabelControl lblFrequency;
        private DevExpress.XtraEditors.LabelControl lblSize;
        private DevExpress.XtraEditors.TextEdit txtDepartment;
        private DevExpress.XtraEditors.TextEdit txtJigName;
        private DevExpress.XtraEditors.TextEdit txtJigType;
        private DevExpress.XtraEditors.TextEdit txtUseProduct;
        private DevExpress.XtraEditors.TextEdit txtLocation;
        private DevExpress.XtraEditors.TextEdit txtFactory;
        private DevExpress.XtraEditors.TextEdit txtFrequency;
        private DevExpress.XtraEditors.TextEdit txtSize;
        private DevExpress.XtraEditors.GroupControl grpReason;
        private DevExpress.XtraEditors.LabelControl lblReason;
        private DevExpress.XtraEditors.LabelControl lblExpectedDate;
        private DevExpress.XtraEditors.LabelControl lblAbnormalNo;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraEditors.LookUpEdit lueReason;
        private DevExpress.XtraEditors.DateEdit deExpectedCancelDate;
        private DevExpress.XtraEditors.TextEdit txtAbnormalNo;
        private DevExpress.XtraEditors.MemoEdit memoNote;
        private DevExpress.XtraEditors.SimpleButton btnRegister;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
