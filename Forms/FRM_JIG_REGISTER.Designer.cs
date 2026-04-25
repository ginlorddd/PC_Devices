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
            this.cboDepartment = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboFactory = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtNameJig = new DevExpress.XtraEditors.TextEdit();
            this.cboFrequency = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboJigType = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSize = new DevExpress.XtraEditors.TextEdit();
            this.txtUseProduct = new DevExpress.XtraEditors.TextEdit();
            this.cboReportForm = new DevExpress.XtraEditors.LookUpEdit();
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.txtManagementNo = new DevExpress.XtraEditors.TextEdit();
            this.btnEditManagementNo = new DevExpress.XtraEditors.SimpleButton();
            this.txtFirstCheckFile = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowseResult = new DevExpress.XtraEditors.SimpleButton();
            this.cboDrawing = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).BeginInit();
            this.groupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFactory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameJig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFrequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboJigType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUseProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReportForm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManagementNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstCheckFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDrawing.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(15, 35, 95);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(28, 16);
            this.lblTitle.Text = "Đăng ký Jig mới";
            // 
            // groupInfo
            // 
            this.groupInfo.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupInfo.AppearanceCaption.Options.UseFont = true;
            this.groupInfo.Text = "Thông tin Jig";
            this.groupInfo.Location = new System.Drawing.Point(24, 64);
            this.groupInfo.Size = new System.Drawing.Size(1260, 410);
            this.groupInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            int LEFT_LABEL_X = 24;
            int LEFT_CTRL_X = 210;
            int RIGHT_LABEL_X = 690;
            int RIGHT_CTRL_X = 870;
            int CTRL_W = 350;
            int LEFT_W = 430;
            int ROW_H = 56;
            int Y = 42;

            AddLabel("Bộ phận", LEFT_LABEL_X, Y); SetCtrl(this.cboDepartment, LEFT_CTRL_X, Y - 4, LEFT_W);
            AddLabel("Nhà máy", RIGHT_LABEL_X, Y); SetCtrl(this.cboFactory, RIGHT_CTRL_X, Y - 4, 160);
            AddLabel("Số quản lý", 1050, Y); SetCtrl(this.txtManagementNo, 1170, Y - 4, 90);
            this.groupInfo.Controls.Add(this.btnEditManagementNo);
            this.btnEditManagementNo.Location = new System.Drawing.Point(1050, Y + 26);
            this.btnEditManagementNo.Size = new System.Drawing.Size(210, 26);
            this.btnEditManagementNo.Text = "Sửa Số QL";
            this.btnEditManagementNo.Click += new System.EventHandler(this.btnEditManagementNo_Click);

            Y += ROW_H;
            AddLabel("Tên Jig", LEFT_LABEL_X, Y); SetCtrl(this.txtNameJig, LEFT_CTRL_X, Y - 4, LEFT_W);
            AddLabel("Tần suất kiểm tra", RIGHT_LABEL_X, Y); SetCtrl(this.cboFrequency, RIGHT_CTRL_X, Y - 4, CTRL_W);

            Y += ROW_H;
            AddLabel("Loại Jig", LEFT_LABEL_X, Y); SetCtrl(this.cboJigType, LEFT_CTRL_X, Y - 4, LEFT_W);
            AddLabel("Size", RIGHT_LABEL_X, Y); SetCtrl(this.txtSize, RIGHT_CTRL_X, Y - 4, CTRL_W);

            Y += ROW_H;
            AddLabel("Sản phẩm sử dụng", LEFT_LABEL_X, Y); SetCtrl(this.txtUseProduct, LEFT_CTRL_X, Y - 4, LEFT_W);
            AddLabel("Báo cáo kiểm tra", RIGHT_LABEL_X, Y); SetCtrl(this.cboReportForm, RIGHT_CTRL_X, Y - 4, CTRL_W);

            Y += ROW_H;
            AddLabel("Vị trí", LEFT_LABEL_X, Y); SetCtrl(this.txtLocation, LEFT_CTRL_X, Y - 4, LEFT_W);
            AddLabel("Bản vẽ", RIGHT_LABEL_X, Y); SetCtrl(this.cboDrawing, RIGHT_CTRL_X, Y - 4, CTRL_W);

            Y += ROW_H;
            AddLabel("KQ kiểm tra lần đầu", LEFT_LABEL_X, Y); SetCtrl(this.txtFirstCheckFile, LEFT_CTRL_X, Y - 4, 330);
            this.groupInfo.Controls.Add(this.btnBrowseResult);
            this.btnBrowseResult.Location = new System.Drawing.Point(550, Y - 4);
            this.btnBrowseResult.Size = new System.Drawing.Size(90, 30);
            this.btnBrowseResult.Text = "Duyệt";
            this.btnBrowseResult.Click += new System.EventHandler(this.btnBrowseResult_Click);

            this.cboJigType.EditValueChanged += new System.EventHandler(this.cboJigType_EditValueChanged);
            this.txtSize.EditValueChanged += new System.EventHandler(this.txtSize_EditValueChanged);

            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(30, 136, 229);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Location = new System.Drawing.Point(1048, 520);
            this.btnSave.Size = new System.Drawing.Size(110, 36);
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnClose.Location = new System.Drawing.Point(1172, 520);
            this.btnClose.Size = new System.Drawing.Size(110, 36);
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.Appearance.BackColor = System.Drawing.Color.FromArgb(243, 246, 252);
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupInfo);
            this.Controls.Add(this.lblTitle);
            this.ClientSize = new System.Drawing.Size(1308, 575);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(1180, 600);
            this.Name = "FRM_JIG_REGISTER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký Jig mới";
            this.Load += new System.EventHandler(this.FRM_JIG_REGISTER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).EndInit();
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFactory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameJig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFrequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboJigType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUseProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReportForm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManagementNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstCheckFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDrawing.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void AddLabel(string text, int x, int y)
        {
            var lb = new DevExpress.XtraEditors.LabelControl();
            lb.Text = text;
            lb.Location = new System.Drawing.Point(x, y);
            lb.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lb.Appearance.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            lb.Appearance.Options.UseFont = true;
            lb.Appearance.Options.UseForeColor = true;
            this.groupInfo.Controls.Add(lb);
        }

        private void SetCtrl(System.Windows.Forms.Control c, int x, int y, int w)
        {
            c.Location = new System.Drawing.Point(x, y);
            c.Width = w;
            c.Height = 30;
            this.groupInfo.Controls.Add(c);
        }

        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.GroupControl groupInfo;
        private DevExpress.XtraEditors.ComboBoxEdit cboDepartment;
        private DevExpress.XtraEditors.ComboBoxEdit cboFactory;
        private DevExpress.XtraEditors.TextEdit txtNameJig;
        private DevExpress.XtraEditors.ComboBoxEdit cboFrequency;
        private DevExpress.XtraEditors.LookUpEdit cboJigType;
        private DevExpress.XtraEditors.TextEdit txtSize;
        private DevExpress.XtraEditors.TextEdit txtUseProduct;
        private DevExpress.XtraEditors.LookUpEdit cboReportForm;
        private DevExpress.XtraEditors.TextEdit txtLocation;
        private DevExpress.XtraEditors.TextEdit txtManagementNo;
        private DevExpress.XtraEditors.SimpleButton btnEditManagementNo;
        private DevExpress.XtraEditors.TextEdit txtFirstCheckFile;
        private DevExpress.XtraEditors.SimpleButton btnBrowseResult;
        private DevExpress.XtraEditors.LookUpEdit cboDrawing;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
