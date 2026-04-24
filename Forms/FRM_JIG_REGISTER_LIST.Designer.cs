namespace JigFlow.Forms
{
    partial class FRM_JIG_REGISTER_LIST
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
            this.btnBrowseReport = new DevExpress.XtraEditors.SimpleButton();
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
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Text = "Đăng ký Jig mới";
            // 
            // groupInfo
            // 
            this.groupInfo.Text = "Thông tin Jig";
            this.groupInfo.Location = new System.Drawing.Point(20, 60);
            this.groupInfo.Size = new System.Drawing.Size(1260, 410);

            int LEFT_LABEL_X = 20;
            int LEFT_CTRL_X = 180;
            int RIGHT_LABEL_X = 640;
            int RIGHT_CTRL_X = 820;
            int CTRL_W = 360;
            int ROW_H = 48;
            int Y = 40;

            AddLabel("Bộ phận", LEFT_LABEL_X, Y); SetCtrl(this.cboDepartment, LEFT_CTRL_X, Y - 4, 270);
            AddLabel("Nhà máy", RIGHT_LABEL_X, Y); SetCtrl(this.cboFactory, RIGHT_CTRL_X, Y - 4, 220);

            Y += ROW_H;
            AddLabel("Tên Jig", LEFT_LABEL_X, Y); SetCtrl(this.txtNameJig, LEFT_CTRL_X, Y - 4, 270);
            AddLabel("Số quản lý", RIGHT_LABEL_X, Y); SetCtrl(this.txtManagementNo, RIGHT_CTRL_X, Y - 4, 250);
            this.groupInfo.Controls.Add(this.btnEditManagementNo);
            this.btnEditManagementNo.Location = new System.Drawing.Point(1080, Y - 4);
            this.btnEditManagementNo.Size = new System.Drawing.Size(100, 28);
            this.btnEditManagementNo.Text = "Sửa Số QL";
            this.btnEditManagementNo.Click += new System.EventHandler(this.btnEditManagementNo_Click);

            Y += ROW_H;
            AddLabel("Loại Jig", LEFT_LABEL_X, Y); SetCtrl(this.cboJigType, LEFT_CTRL_X, Y - 4, 270);
            AddLabel("Tần suất kiểm tra", RIGHT_LABEL_X, Y); SetCtrl(this.cboFrequency, RIGHT_CTRL_X, Y - 4, CTRL_W);

            Y += ROW_H;
            AddLabel("Size", LEFT_LABEL_X, Y); SetCtrl(this.txtSize, LEFT_CTRL_X, Y - 4, 270);
            AddLabel("Sản phẩm sử dụng", RIGHT_LABEL_X, Y); SetCtrl(this.txtUseProduct, RIGHT_CTRL_X, Y - 4, CTRL_W);

            Y += ROW_H;
            AddLabel("Báo cáo kiểm tra", LEFT_LABEL_X, Y); SetCtrl(this.cboReportForm, LEFT_CTRL_X, Y - 4, 270);
            this.groupInfo.Controls.Add(this.btnBrowseReport);
            this.btnBrowseReport.Location = new System.Drawing.Point(460, Y - 4);
            this.btnBrowseReport.Size = new System.Drawing.Size(90, 28);
            this.btnBrowseReport.Text = "Browse";
            this.btnBrowseReport.Click += new System.EventHandler(this.btnBrowseReport_Click);
            AddLabel("Vị trí", RIGHT_LABEL_X, Y); SetCtrl(this.txtLocation, RIGHT_CTRL_X, Y - 4, CTRL_W);

            Y += ROW_H;
            AddLabel("KQ kiểm tra lần đầu", LEFT_LABEL_X, Y); SetCtrl(this.txtFirstCheckFile, LEFT_CTRL_X, Y - 4, 360);
            this.groupInfo.Controls.Add(this.btnBrowseResult);
            this.btnBrowseResult.Location = new System.Drawing.Point(550, Y - 4);
            this.btnBrowseResult.Size = new System.Drawing.Size(90, 28);
            this.btnBrowseResult.Text = "Browse";
            this.btnBrowseResult.Click += new System.EventHandler(this.btnBrowseResult_Click);
            AddLabel("Bản vẽ", RIGHT_LABEL_X, Y); SetCtrl(this.cboDrawing, RIGHT_CTRL_X, Y - 4, CTRL_W);

            this.cboJigType.EditValueChanged += new System.EventHandler(this.cboJigType_EditValueChanged);
            this.txtSize.EditValueChanged += new System.EventHandler(this.txtSize_EditValueChanged);

            this.btnSave.Location = new System.Drawing.Point(1050, 490);
            this.btnSave.Size = new System.Drawing.Size(110, 34);
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnClose.Location = new System.Drawing.Point(1170, 490);
            this.btnClose.Size = new System.Drawing.Size(110, 34);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupInfo);
            this.Controls.Add(this.lblTitle);
            this.ClientSize = new System.Drawing.Size(1300, 540);
            this.Name = "FRM_JIG_REGISTER_LIST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký Jig mới";
            this.Load += new System.EventHandler(this.FRM_JIG_REGISTER_LIST_Load);
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
            lb.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            lb.Appearance.Options.UseFont = true;
            this.groupInfo.Controls.Add(lb);
        }

        private void SetCtrl(System.Windows.Forms.Control c, int x, int y, int w)
        {
            c.Location = new System.Drawing.Point(x, y);
            c.Width = w;
            c.Height = 28;
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
        private DevExpress.XtraEditors.SimpleButton btnBrowseReport;
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
