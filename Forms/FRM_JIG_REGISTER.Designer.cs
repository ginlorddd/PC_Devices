namespace JigFlow.Forms
{
    partial class FRM_JIG_REGISTER
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
            this.groupInfo = new DevExpress.XtraEditors.GroupControl();
            this.lblDepartment = new DevExpress.XtraEditors.LabelControl();
            this.lblFactory = new DevExpress.XtraEditors.LabelControl();
            this.lblManagementNo = new DevExpress.XtraEditors.LabelControl();
            this.lblNameJig = new DevExpress.XtraEditors.LabelControl();
            this.lblFrequency = new DevExpress.XtraEditors.LabelControl();
            this.lblJigType = new DevExpress.XtraEditors.LabelControl();
            this.lblSize = new DevExpress.XtraEditors.LabelControl();
            this.lblUseProduct = new DevExpress.XtraEditors.LabelControl();
            this.lblReportForm = new DevExpress.XtraEditors.LabelControl();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.lblDrawing = new DevExpress.XtraEditors.LabelControl();
            this.lblLastCheckDate = new DevExpress.XtraEditors.LabelControl();
            this.lblFirstCheck = new DevExpress.XtraEditors.LabelControl();
            this.cboDepartment = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboFactory = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtManagementNo = new DevExpress.XtraEditors.TextEdit();
            this.btnEditManagementNo = new DevExpress.XtraEditors.SimpleButton();
            this.txtNameJig = new DevExpress.XtraEditors.TextEdit();
            this.cboFrequency = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboJigType = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSize = new DevExpress.XtraEditors.TextEdit();
            this.txtUseProduct = new DevExpress.XtraEditors.TextEdit();
            this.cboReportForm = new DevExpress.XtraEditors.LookUpEdit();
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.cboDrawing = new DevExpress.XtraEditors.LookUpEdit();
            this.deLastCheckDate = new DevExpress.XtraEditors.DateEdit();
            this.txtFirstCheckFile = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowseResult = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefreshData = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).BeginInit();
            this.groupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFactory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManagementNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameJig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFrequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboJigType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUseProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReportForm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDrawing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLastCheckDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLastCheckDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstCheckFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(15, 35, 95);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(28, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(252, 45);
            this.lblTitle.Text = "Đăng ký Jig mới";
            // 
            // groupInfo
            // 
            this.groupInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupInfo.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupInfo.AppearanceCaption.Options.UseFont = true;
            this.groupInfo.Controls.Add(this.lblDepartment);
            this.groupInfo.Controls.Add(this.lblFactory);
            this.groupInfo.Controls.Add(this.lblManagementNo);
            this.groupInfo.Controls.Add(this.lblNameJig);
            this.groupInfo.Controls.Add(this.lblFrequency);
            this.groupInfo.Controls.Add(this.lblJigType);
            this.groupInfo.Controls.Add(this.lblSize);
            this.groupInfo.Controls.Add(this.lblUseProduct);
            this.groupInfo.Controls.Add(this.lblReportForm);
            this.groupInfo.Controls.Add(this.lblLocation);
            this.groupInfo.Controls.Add(this.lblDrawing);
            this.groupInfo.Controls.Add(this.lblLastCheckDate);
            this.groupInfo.Controls.Add(this.lblFirstCheck);
            this.groupInfo.Controls.Add(this.cboDepartment);
            this.groupInfo.Controls.Add(this.cboFactory);
            this.groupInfo.Controls.Add(this.txtManagementNo);
            this.groupInfo.Controls.Add(this.btnEditManagementNo);
            this.groupInfo.Controls.Add(this.txtNameJig);
            this.groupInfo.Controls.Add(this.cboFrequency);
            this.groupInfo.Controls.Add(this.cboJigType);
            this.groupInfo.Controls.Add(this.txtSize);
            this.groupInfo.Controls.Add(this.txtUseProduct);
            this.groupInfo.Controls.Add(this.cboReportForm);
            this.groupInfo.Controls.Add(this.txtLocation);
            this.groupInfo.Controls.Add(this.cboDrawing);
            this.groupInfo.Controls.Add(this.deLastCheckDate);
            this.groupInfo.Controls.Add(this.txtFirstCheckFile);
            this.groupInfo.Controls.Add(this.btnBrowseResult);
            this.groupInfo.Location = new System.Drawing.Point(24, 64);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(1260, 430);
            this.groupInfo.TabIndex = 0;
            this.groupInfo.Text = "Thông tin Jig";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDepartment.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblDepartment.Appearance.Options.UseFont = true;
            this.lblDepartment.Appearance.Options.UseForeColor = true;
            this.lblDepartment.Location = new System.Drawing.Point(24, 42);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 20);
            this.lblDepartment.Text = "Bộ phận";
            // 
            // lblFactory
            // 
            this.lblFactory.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFactory.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblFactory.Appearance.Options.UseFont = true;
            this.lblFactory.Appearance.Options.UseForeColor = true;
            this.lblFactory.Location = new System.Drawing.Point(690, 42);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(61, 20);
            this.lblFactory.Text = "Nhà máy";
            // 
            // lblManagementNo
            // 
            this.lblManagementNo.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblManagementNo.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblManagementNo.Appearance.Options.UseFont = true;
            this.lblManagementNo.Appearance.Options.UseForeColor = true;
            this.lblManagementNo.Location = new System.Drawing.Point(1050, 42);
            this.lblManagementNo.Name = "lblManagementNo";
            this.lblManagementNo.Size = new System.Drawing.Size(79, 20);
            this.lblManagementNo.Text = "Số quản lý";
            // 
            // lblNameJig
            // 
            this.lblNameJig.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNameJig.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblNameJig.Appearance.Options.UseFont = true;
            this.lblNameJig.Appearance.Options.UseForeColor = true;
            this.lblNameJig.Location = new System.Drawing.Point(24, 98);
            this.lblNameJig.Name = "lblNameJig";
            this.lblNameJig.Size = new System.Drawing.Size(52, 20);
            this.lblNameJig.Text = "Tên Jig";
            // 
            // lblFrequency
            // 
            this.lblFrequency.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFrequency.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblFrequency.Appearance.Options.UseFont = true;
            this.lblFrequency.Appearance.Options.UseForeColor = true;
            this.lblFrequency.Location = new System.Drawing.Point(690, 98);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(122, 20);
            this.lblFrequency.Text = "Tần suất kiểm tra";
            // 
            // lblJigType
            // 
            this.lblJigType.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblJigType.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblJigType.Appearance.Options.UseFont = true;
            this.lblJigType.Appearance.Options.UseForeColor = true;
            this.lblJigType.Location = new System.Drawing.Point(24, 154);
            this.lblJigType.Name = "lblJigType";
            this.lblJigType.Size = new System.Drawing.Size(56, 20);
            this.lblJigType.Text = "Loại Jig";
            // 
            // lblSize
            // 
            this.lblSize.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSize.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblSize.Appearance.Options.UseFont = true;
            this.lblSize.Appearance.Options.UseForeColor = true;
            this.lblSize.Location = new System.Drawing.Point(690, 154);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(29, 20);
            this.lblSize.Text = "Size";
            // 
            // lblUseProduct
            // 
            this.lblUseProduct.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUseProduct.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblUseProduct.Appearance.Options.UseFont = true;
            this.lblUseProduct.Appearance.Options.UseForeColor = true;
            this.lblUseProduct.Location = new System.Drawing.Point(24, 210);
            this.lblUseProduct.Name = "lblUseProduct";
            this.lblUseProduct.Size = new System.Drawing.Size(118, 20);
            this.lblUseProduct.Text = "Sản phẩm sử dụng";
            // 
            // lblReportForm
            // 
            this.lblReportForm.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblReportForm.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblReportForm.Appearance.Options.UseFont = true;
            this.lblReportForm.Appearance.Options.UseForeColor = true;
            this.lblReportForm.Location = new System.Drawing.Point(690, 210);
            this.lblReportForm.Name = "lblReportForm";
            this.lblReportForm.Size = new System.Drawing.Size(115, 20);
            this.lblReportForm.Text = "Báo cáo kiểm tra";
            // 
            // lblLocation
            // 
            this.lblLocation.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLocation.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblLocation.Appearance.Options.UseFont = true;
            this.lblLocation.Appearance.Options.UseForeColor = true;
            this.lblLocation.Location = new System.Drawing.Point(24, 266);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(38, 20);
            this.lblLocation.Text = "Vị trí";
            // 
            // lblDrawing
            // 
            this.lblDrawing.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDrawing.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblDrawing.Appearance.Options.UseFont = true;
            this.lblDrawing.Appearance.Options.UseForeColor = true;
            this.lblDrawing.Location = new System.Drawing.Point(690, 266);
            this.lblDrawing.Name = "lblDrawing";
            this.lblDrawing.Size = new System.Drawing.Size(47, 20);
            this.lblDrawing.Text = "Bản vẽ";
            // 
            // lblLastCheckDate
            // 
            this.lblLastCheckDate.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLastCheckDate.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblLastCheckDate.Appearance.Options.UseFont = true;
            this.lblLastCheckDate.Appearance.Options.UseForeColor = true;
            this.lblLastCheckDate.Location = new System.Drawing.Point(690, 322);
            this.lblLastCheckDate.Name = "lblLastCheckDate";
            this.lblLastCheckDate.Size = new System.Drawing.Size(167, 20);
            this.lblLastCheckDate.Text = "Ngày kiểm tra định kỳ gần nhất";
            // 
            // lblFirstCheck
            // 
            this.lblFirstCheck.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFirstCheck.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblFirstCheck.Appearance.Options.UseFont = true;
            this.lblFirstCheck.Appearance.Options.UseForeColor = true;
            this.lblFirstCheck.Location = new System.Drawing.Point(24, 322);
            this.lblFirstCheck.Name = "lblFirstCheck";
            this.lblFirstCheck.Size = new System.Drawing.Size(129, 20);
            this.lblFirstCheck.Text = "KQ kiểm tra lần đầu";
            // 
            // cboDepartment
            // 
            this.cboDepartment.Location = new System.Drawing.Point(210, 38);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(430, 20);
            this.cboDepartment.TabIndex = 0;
            // 
            // cboFactory
            // 
            this.cboFactory.Location = new System.Drawing.Point(870, 38);
            this.cboFactory.Name = "cboFactory";
            this.cboFactory.Size = new System.Drawing.Size(160, 20);
            this.cboFactory.TabIndex = 1;
            // 
            // txtManagementNo
            // 
            this.txtManagementNo.Location = new System.Drawing.Point(1170, 38);
            this.txtManagementNo.Name = "txtManagementNo";
            this.txtManagementNo.Size = new System.Drawing.Size(90, 20);
            this.txtManagementNo.TabIndex = 2;
            // 
            // btnEditManagementNo
            // 
            this.btnEditManagementNo.Location = new System.Drawing.Point(1050, 64);
            this.btnEditManagementNo.Name = "btnEditManagementNo";
            this.btnEditManagementNo.Size = new System.Drawing.Size(210, 23);
            this.btnEditManagementNo.TabIndex = 3;
            this.btnEditManagementNo.Text = "Sửa Số QL";
            this.btnEditManagementNo.Click += new System.EventHandler(this.btnEditManagementNo_Click);
            // 
            // txtNameJig
            // 
            this.txtNameJig.Location = new System.Drawing.Point(210, 94);
            this.txtNameJig.Name = "txtNameJig";
            this.txtNameJig.Size = new System.Drawing.Size(430, 20);
            this.txtNameJig.TabIndex = 4;
            // 
            // cboFrequency
            // 
            this.cboFrequency.Location = new System.Drawing.Point(870, 94);
            this.cboFrequency.Name = "cboFrequency";
            this.cboFrequency.Size = new System.Drawing.Size(350, 20);
            this.cboFrequency.TabIndex = 5;
            // 
            // cboJigType
            // 
            this.cboJigType.Location = new System.Drawing.Point(210, 150);
            this.cboJigType.Name = "cboJigType";
            this.cboJigType.Size = new System.Drawing.Size(430, 20);
            this.cboJigType.TabIndex = 6;
            this.cboJigType.EditValueChanged += new System.EventHandler(this.cboJigType_EditValueChanged);
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(870, 150);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(350, 20);
            this.txtSize.TabIndex = 7;
            this.txtSize.EditValueChanged += new System.EventHandler(this.txtSize_EditValueChanged);
            // 
            // txtUseProduct
            // 
            this.txtUseProduct.Location = new System.Drawing.Point(210, 206);
            this.txtUseProduct.Name = "txtUseProduct";
            this.txtUseProduct.Size = new System.Drawing.Size(430, 20);
            this.txtUseProduct.TabIndex = 8;
            // 
            // cboReportForm
            // 
            this.cboReportForm.Location = new System.Drawing.Point(870, 206);
            this.cboReportForm.Name = "cboReportForm";
            this.cboReportForm.Size = new System.Drawing.Size(350, 20);
            this.cboReportForm.TabIndex = 9;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(210, 262);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(430, 20);
            this.txtLocation.TabIndex = 10;
            // 
            // cboDrawing
            // 
            this.cboDrawing.Location = new System.Drawing.Point(870, 262);
            this.cboDrawing.Name = "cboDrawing";
            this.cboDrawing.Size = new System.Drawing.Size(350, 20);
            this.cboDrawing.TabIndex = 11;
            // 
            // deLastCheckDate
            // 
            this.deLastCheckDate.EditValue = null;
            this.deLastCheckDate.Location = new System.Drawing.Point(870, 318);
            this.deLastCheckDate.Name = "deLastCheckDate";
            this.deLastCheckDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deLastCheckDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deLastCheckDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.deLastCheckDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deLastCheckDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.deLastCheckDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deLastCheckDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.deLastCheckDate.Size = new System.Drawing.Size(350, 20);
            this.deLastCheckDate.TabIndex = 12;
            // 
            // txtFirstCheckFile
            // 
            this.txtFirstCheckFile.Location = new System.Drawing.Point(210, 318);
            this.txtFirstCheckFile.Name = "txtFirstCheckFile";
            this.txtFirstCheckFile.Size = new System.Drawing.Size(330, 20);
            this.txtFirstCheckFile.TabIndex = 13;
            // 
            // btnBrowseResult
            // 
            this.btnBrowseResult.Location = new System.Drawing.Point(550, 318);
            this.btnBrowseResult.Name = "btnBrowseResult";
            this.btnBrowseResult.Size = new System.Drawing.Size(90, 23);
            this.btnBrowseResult.TabIndex = 14;
            this.btnBrowseResult.Text = "Duyệt";
            this.btnBrowseResult.Click += new System.EventHandler(this.btnBrowseResult_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(30, 136, 229);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Location = new System.Drawing.Point(1048, 520);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1172, 520);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FRM_JIG_REGISTER
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(243, 246, 252);
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(1308, 575);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefreshData);
            this.Controls.Add(this.groupInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(1180, 600);
            this.Name = "FRM_JIG_REGISTER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký Jig mới";
            this.Load += new System.EventHandler(this.FRM_JIG_REGISTER_Load);
            // btnRefreshData
            this.btnRefreshData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshData.Location = new System.Drawing.Point(1172, 20);
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(110, 30);
            this.btnRefreshData.TabIndex = 3;
            this.btnRefreshData.Text = "Refresh";
            this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).EndInit();
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFactory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManagementNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameJig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFrequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboJigType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUseProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReportForm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDrawing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLastCheckDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLastCheckDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstCheckFile.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.GroupControl groupInfo;
        private DevExpress.XtraEditors.LabelControl lblDepartment;
        private DevExpress.XtraEditors.LabelControl lblFactory;
        private DevExpress.XtraEditors.LabelControl lblManagementNo;
        private DevExpress.XtraEditors.LabelControl lblNameJig;
        private DevExpress.XtraEditors.LabelControl lblFrequency;
        private DevExpress.XtraEditors.LabelControl lblJigType;
        private DevExpress.XtraEditors.LabelControl lblSize;
        private DevExpress.XtraEditors.LabelControl lblUseProduct;
        private DevExpress.XtraEditors.LabelControl lblReportForm;
        private DevExpress.XtraEditors.LabelControl lblLocation;
        private DevExpress.XtraEditors.LabelControl lblDrawing;
        private DevExpress.XtraEditors.LabelControl lblLastCheckDate;
        private DevExpress.XtraEditors.LabelControl lblFirstCheck;
        private DevExpress.XtraEditors.ComboBoxEdit cboDepartment;
        private DevExpress.XtraEditors.ComboBoxEdit cboFactory;
        private DevExpress.XtraEditors.TextEdit txtManagementNo;
        private DevExpress.XtraEditors.SimpleButton btnEditManagementNo;
        private DevExpress.XtraEditors.TextEdit txtNameJig;
        private DevExpress.XtraEditors.ComboBoxEdit cboFrequency;
        private DevExpress.XtraEditors.LookUpEdit cboJigType;
        private DevExpress.XtraEditors.TextEdit txtSize;
        private DevExpress.XtraEditors.TextEdit txtUseProduct;
        private DevExpress.XtraEditors.LookUpEdit cboReportForm;
        private DevExpress.XtraEditors.TextEdit txtLocation;
        private DevExpress.XtraEditors.LookUpEdit cboDrawing;
        private DevExpress.XtraEditors.DateEdit deLastCheckDate;
        private DevExpress.XtraEditors.TextEdit txtFirstCheckFile;
        private DevExpress.XtraEditors.SimpleButton btnBrowseResult;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnRefreshData;
    }
}
