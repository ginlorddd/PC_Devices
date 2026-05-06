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
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.gcJigType = new DevExpress.XtraGrid.GridControl();
            this.gvJigType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblRecord = new DevExpress.XtraEditors.LabelControl();
            this.panelTop.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJigTypeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJigTypeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcJigType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJigType)).BeginInit();
            this.panelBottom.SuspendLayout();
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
            this.panelInput.Controls.Add(this.chkIsActive);
            this.panelInput.Controls.Add(this.btnNew);
            this.panelInput.Controls.Add(this.btnSave);
            this.panelInput.Controls.Add(this.btnRefresh);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInput.Height = 78;
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
            // chkIsActive
            this.chkIsActive.Location = new System.Drawing.Point(742, 13);
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
            // gcJigType
            this.gcJigType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcJigType.Location = new System.Drawing.Point(0, 134);
            this.gcJigType.MainView = this.gvJigType;
            this.gcJigType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvJigType });
            // gvJigType
            this.gvJigType.GridControl = this.gcJigType;
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
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcJigType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJigType)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.Panel panelInput;
        private DevExpress.XtraEditors.LabelControl lblJigTypeCode;
        private DevExpress.XtraEditors.TextEdit txtJigTypeCode;
        private DevExpress.XtraEditors.LabelControl lblJigTypeName;
        private DevExpress.XtraEditors.TextEdit txtJigTypeName;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl gcJigType;
        private DevExpress.XtraGrid.Views.Grid.GridView gvJigType;
        private System.Windows.Forms.Panel panelBottom;
        private DevExpress.XtraEditors.LabelControl lblRecord;
    }
}
