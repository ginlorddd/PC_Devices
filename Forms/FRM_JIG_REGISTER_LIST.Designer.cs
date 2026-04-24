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
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.txtManagementNo = new DevExpress.XtraEditors.TextEdit();
            this.btnEditManagementNo = new DevExpress.XtraEditors.SimpleButton();
            this.txtFirstCheckFile = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowseResult = new DevExpress.XtraEditors.SimpleButton();
            this.cboDrawing = new DevExpress.XtraEditors.LookUpEdit();
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
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Text = "Đăng ký Jig mới";

            this.groupInfo.Text = "Thông tin Jig";
            this.groupInfo.Location = new System.Drawing.Point(20, 60);
            this.groupInfo.Size = new System.Drawing.Size(1260, 430);

            int y=40;
            AddLabel("Bộ phận",20,y); SetCtrl(this.cboDepartment,180,y-4,270); AddLabel("Nhà máy",500,y); SetCtrl(this.cboFactory,620,y-4,150); AddLabel("Số quản lý",800,y); SetCtrl(this.txtManagementNo,930,y-4,220); this.groupInfo.Controls.Add(this.btnEditManagementNo); this.btnEditManagementNo.Location=new System.Drawing.Point(1155,y-4); this.btnEditManagementNo.Size=new System.Drawing.Size(90,28); this.btnEditManagementNo.Text="Sửa Số QL"; this.btnEditManagementNo.Click+=new System.EventHandler(this.btnEditManagementNo_Click);
            y+=55;
            AddLabel("Tên Jig",20,y); SetCtrl(this.txtNameJig,180,y-4,270); AddLabel("Tần suất kiểm tra",500,y); SetCtrl(this.cboFrequency,620,y-4,530);
            y+=55;
            AddLabel("Loại Jig",20,y); SetCtrl(this.cboJigType,180,y-4,270); AddLabel("Size",500,y); SetCtrl(this.txtSize,620,y-4,530);
            y+=55;
            AddLabel("Sản phẩm sử dụng",20,y); SetCtrl(this.txtUseProduct,180,y-4,270); AddLabel("Báo cáo kiểm tra",500,y); SetCtrl(this.cboReportForm,620,y-4,530);
            y+=55;
            AddLabel("Vị trí",20,y); SetCtrl(this.txtLocation,180,y-4,270); AddLabel("KQ kiểm tra lần đầu",500,y); SetCtrl(this.txtFirstCheckFile,620,y-4,430); this.groupInfo.Controls.Add(this.btnBrowseResult); this.btnBrowseResult.Location=new System.Drawing.Point(1060,y-4); this.btnBrowseResult.Size=new System.Drawing.Size(90,28); this.btnBrowseResult.Text="Browse"; this.btnBrowseResult.Click+=new System.EventHandler(this.btnBrowseResult_Click);
            y+=55;
            AddLabel("Bản vẽ",20,y); SetCtrl(this.cboDrawing,180,y-4,970);

            this.cboJigType.EditValueChanged += new System.EventHandler(this.cboJigType_EditValueChanged);
            this.txtSize.EditValueChanged += new System.EventHandler(this.txtSize_EditValueChanged);

            this.btnClose.Location = new System.Drawing.Point(1170, 510);
            this.btnClose.Size = new System.Drawing.Size(110, 34);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupInfo);
            this.Controls.Add(this.lblTitle);
            this.ClientSize = new System.Drawing.Size(1300, 560);
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

        private void AddLabel(string text,int x,int y)
        {
            var lb = new DevExpress.XtraEditors.LabelControl();
            lb.Text=text; lb.Location=new System.Drawing.Point(x,y); lb.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold); lb.Appearance.Options.UseFont=true;
            this.groupInfo.Controls.Add(lb);
        }

        private void SetCtrl(System.Windows.Forms.Control c,int x,int y,int w)
        {
            c.Location = new System.Drawing.Point(x,y); c.Width = w; c.Height = 28;
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
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
