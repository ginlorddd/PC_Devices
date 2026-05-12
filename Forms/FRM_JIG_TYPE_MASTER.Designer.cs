namespace JigFlow.Forms
{
    partial class FRM_JIG_TYPE_MASTER
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
            this.panelInput = new System.Windows.Forms.Panel();
            this.lblJigTypeCode = new DevExpress.XtraEditors.LabelControl();
            this.txtJigTypeCode = new DevExpress.XtraEditors.TextEdit();
            this.lblJigTypeName = new DevExpress.XtraEditors.LabelControl();
            this.txtJigTypeName = new DevExpress.XtraEditors.TextEdit();
            this.lblJigTypeMain = new DevExpress.XtraEditors.LabelControl();
            this.cboJigTypeMain = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.lblDrawingCode = new DevExpress.XtraEditors.LabelControl();
            this.txtDrawingCode = new DevExpress.XtraEditors.TextEdit();
            this.lblDrawingName = new DevExpress.XtraEditors.LabelControl();
            this.txtDrawingName = new DevExpress.XtraEditors.TextEdit();
            this.lblDrawingPath = new DevExpress.XtraEditors.LabelControl();
            this.txtDrawingFilePath = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowseDrawing = new DevExpress.XtraEditors.SimpleButton();
            this.gcJigType = new DevExpress.XtraGrid.GridControl();
            this.gvJigType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblRecord = new DevExpress.XtraEditors.LabelControl();
            this.panelTop.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJigTypeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJigTypeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboJigTypeMain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcJigType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJigType)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawingName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawingFilePath.Properties)).BeginInit();
            this.SuspendLayout();
            // panelTop
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 56;
            // lblTitle
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Text = "Jig Type Master";
            // panelInput
            this.panelInput.Controls.Add(this.lblJigTypeCode);
            this.panelInput.Controls.Add(this.txtJigTypeCode);
            this.panelInput.Controls.Add(this.lblJigTypeName);
            this.panelInput.Controls.Add(this.txtJigTypeName);
            this.panelInput.Controls.Add(this.lblJigTypeMain);
            this.panelInput.Controls.Add(this.cboJigTypeMain);
            this.panelInput.Controls.Add(this.chkIsActive);
            this.panelInput.Controls.Add(this.btnNew);
            this.panelInput.Controls.Add(this.btnSave);
            this.panelInput.Controls.Add(this.btnRefresh);
            this.panelInput.Controls.Add(this.lblDrawingCode);
            this.panelInput.Controls.Add(this.txtDrawingCode);
            this.panelInput.Controls.Add(this.lblDrawingName);
            this.panelInput.Controls.Add(this.txtDrawingName);
            this.panelInput.Controls.Add(this.lblDrawingPath);
            this.panelInput.Controls.Add(this.txtDrawingFilePath);
            this.panelInput.Controls.Add(this.btnBrowseDrawing);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInput.Height = 112;
            // lblJigTypeCode
            this.lblJigTypeCode.Location = new System.Drawing.Point(16, 16);
            this.lblJigTypeCode.Text = "Mã loại Jig";
            // txtJigTypeCode
            this.txtJigTypeCode.Location = new System.Drawing.Point(95, 13);
            this.txtJigTypeCode.Size = new System.Drawing.Size(200, 20);
            // lblJigTypeName
            this.lblJigTypeName.Location = new System.Drawing.Point(320, 16);
            this.lblJigTypeName.Text = "Tên loại Jig";
            // txtJigTypeName
            this.txtJigTypeName.Location = new System.Drawing.Point(392, 13);
            this.txtJigTypeName.Size = new System.Drawing.Size(330, 20);
            // lblJigTypeMain
            this.lblJigTypeMain.Location = new System.Drawing.Point(742, 16);
            this.lblJigTypeMain.Text = "Nhóm chính";
            // cboJigTypeMain
            this.cboJigTypeMain.Location = new System.Drawing.Point(820, 13);
            this.cboJigTypeMain.Size = new System.Drawing.Size(120, 20);
            // chkIsActive
            this.chkIsActive.Location = new System.Drawing.Point(950, 13);
            this.chkIsActive.Properties.Caption = "Kích hoạt";
            this.chkIsActive.Size = new System.Drawing.Size(80, 20);
            // btnNew
            this.btnNew.Location = new System.Drawing.Point(16, 42);
            this.btnNew.Size = new System.Drawing.Size(90, 26);
            this.btnNew.Text = "Thêm mới";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // btnSave
            this.btnSave.Location = new System.Drawing.Point(112, 42);
            this.btnSave.Size = new System.Drawing.Size(90, 26);
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(208, 42);
            this.btnRefresh.Size = new System.Drawing.Size(90, 26);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.lblDrawingCode.Location = new System.Drawing.Point(16, 80); this.lblDrawingCode.Text = "Mã bản vẽ";
            this.txtDrawingCode.Location = new System.Drawing.Point(95, 77); this.txtDrawingCode.Size = new System.Drawing.Size(150, 20);
            this.lblDrawingName.Location = new System.Drawing.Point(260, 80); this.lblDrawingName.Text = "Tên bản vẽ";
            this.txtDrawingName.Location = new System.Drawing.Point(330, 77); this.txtDrawingName.Size = new System.Drawing.Size(220, 20);
            this.lblDrawingPath.Location = new System.Drawing.Point(560, 80); this.lblDrawingPath.Text = "File";
            this.txtDrawingFilePath.Location = new System.Drawing.Point(590, 77); this.txtDrawingFilePath.Size = new System.Drawing.Size(350, 20);
            this.btnBrowseDrawing.Location = new System.Drawing.Point(950, 75); this.btnBrowseDrawing.Size = new System.Drawing.Size(90, 24); this.btnBrowseDrawing.Text = "Browse"; this.btnBrowseDrawing.Click += new System.EventHandler(this.btnBrowseDrawing_Click);
            // gcJigType
            this.gcJigType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcJigType.Location = new System.Drawing.Point(0, 168);
            this.gcJigType.MainView = this.gvJigType;
            this.gcJigType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvJigType });
            // gvJigType
            this.gvJigType.GridControl = this.gcJigType;
            this.gvJigType.OptionsBehavior.Editable = false;
            this.gvJigType.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvJigType_FocusedRowChanged);
            // panelBottom
            this.panelBottom.Controls.Add(this.lblRecord);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 40;
            this.lblRecord.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblRecord.Location = new System.Drawing.Point(1100, 12);
            this.lblRecord.Text = "Record: 0";

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 700);
            this.Controls.Add(this.gcJigType);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_JIG_TYPE_MASTER";
            this.Text = "Jig Type Master";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_JIG_TYPE_MASTER_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJigTypeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJigTypeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboJigTypeMain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcJigType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJigType)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawingName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawingFilePath.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.Panel panelInput;
        private DevExpress.XtraEditors.LabelControl lblJigTypeCode;
        private DevExpress.XtraEditors.TextEdit txtJigTypeCode;
        private DevExpress.XtraEditors.LabelControl lblJigTypeName;
        private DevExpress.XtraEditors.TextEdit txtJigTypeName;
        private DevExpress.XtraEditors.LabelControl lblJigTypeMain;
        private DevExpress.XtraEditors.ComboBoxEdit cboJigTypeMain;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.LabelControl lblDrawingCode;
        private DevExpress.XtraEditors.TextEdit txtDrawingCode;
        private DevExpress.XtraEditors.LabelControl lblDrawingName;
        private DevExpress.XtraEditors.TextEdit txtDrawingName;
        private DevExpress.XtraEditors.LabelControl lblDrawingPath;
        private DevExpress.XtraEditors.TextEdit txtDrawingFilePath;
        private DevExpress.XtraEditors.SimpleButton btnBrowseDrawing;
        private DevExpress.XtraGrid.GridControl gcJigType;
        private DevExpress.XtraGrid.Views.Grid.GridView gvJigType;
        private System.Windows.Forms.Panel panelBottom;
        private DevExpress.XtraEditors.LabelControl lblRecord;
    }
}
