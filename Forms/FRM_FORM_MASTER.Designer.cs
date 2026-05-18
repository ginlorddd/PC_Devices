namespace JigFlow.Forms
{
    partial class FRM_FORM_MASTER
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing){ if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing);} 
        private void InitializeComponent()
        {
            this.gcForm = new DevExpress.XtraGrid.GridControl();
            this.gvForm = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtFormCode = new DevExpress.XtraEditors.TextEdit();
            this.txtFormName = new DevExpress.XtraEditors.TextEdit();
            this.txtVersion = new DevExpress.XtraEditors.TextEdit();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.txtTemplatePath = new DevExpress.XtraEditors.TextEdit();
            this.txtPartNameCell = new DevExpress.XtraEditors.TextEdit();
            this.txtControlNoCell = new DevExpress.XtraEditors.TextEdit();
            this.txtDateCell = new DevExpress.XtraEditors.TextEdit();
            this.chkDefault = new DevExpress.XtraEditors.CheckEdit();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnGenerateSample = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVersion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplatePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPartNameCell.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtControlNoCell.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateCell.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            this.SuspendLayout();
            this.gcForm.Location = new System.Drawing.Point(12,12); this.gcForm.MainView=this.gvForm; this.gcForm.Size = new System.Drawing.Size(760,350); this.gcForm.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[]{this.gvForm});
            this.gvForm.GridControl=this.gcForm; this.gvForm.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvForm_FocusedRowChanged);
            this.txtFormCode.Location = new System.Drawing.Point(790,30); this.txtFormCode.Size = new System.Drawing.Size(250,20);
            this.txtFormName.Location = new System.Drawing.Point(790,60); this.txtFormName.Size = new System.Drawing.Size(250,20);
            this.txtVersion.Location = new System.Drawing.Point(790,90); this.txtVersion.Size = new System.Drawing.Size(250,20);
            this.txtDescription.Location = new System.Drawing.Point(790,120); this.txtDescription.Size = new System.Drawing.Size(250,20);
            this.txtTemplatePath.Location = new System.Drawing.Point(790,150); this.txtTemplatePath.Size = new System.Drawing.Size(210,20);
            this.btnBrowse.Location = new System.Drawing.Point(1005,148); this.btnBrowse.Size = new System.Drawing.Size(35,23); this.btnBrowse.Text="..."; this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            this.txtPartNameCell.Location = new System.Drawing.Point(790,180); this.txtPartNameCell.Size = new System.Drawing.Size(80,20);
            this.txtControlNoCell.Location = new System.Drawing.Point(880,180); this.txtControlNoCell.Size = new System.Drawing.Size(80,20);
            this.txtDateCell.Location = new System.Drawing.Point(970,180); this.txtDateCell.Size = new System.Drawing.Size(70,20);
            this.chkDefault.Location = new System.Drawing.Point(790,210); this.chkDefault.Properties.Caption = "Default";
            this.chkActive.Location = new System.Drawing.Point(880,210); this.chkActive.Properties.Caption = "Active"; this.chkActive.EditValue = true;
            this.btnSave.Location = new System.Drawing.Point(790,245); this.btnSave.Size = new System.Drawing.Size(120,30); this.btnSave.Text = "Lưu"; this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnGenerateSample.Location = new System.Drawing.Point(920,245); this.btnGenerateSample.Size = new System.Drawing.Size(120,30); this.btnGenerateSample.Text = "Tạo file mẫu"; this.btnGenerateSample.Click += new System.EventHandler(this.btnGenerateSample_Click);
            this.ClientSize = new System.Drawing.Size(1060,380);
            this.Controls.Add(this.gcForm);this.Controls.Add(this.txtFormCode);this.Controls.Add(this.txtFormName);this.Controls.Add(this.txtVersion);this.Controls.Add(this.txtDescription);this.Controls.Add(this.txtTemplatePath);this.Controls.Add(this.btnBrowse);this.Controls.Add(this.txtPartNameCell);this.Controls.Add(this.txtControlNoCell);this.Controls.Add(this.txtDateCell);this.Controls.Add(this.chkDefault);this.Controls.Add(this.chkActive);this.Controls.Add(this.btnSave);this.Controls.Add(this.btnGenerateSample);
            this.Name="FRM_FORM_MASTER"; this.Text="Form Master"; this.Load += new System.EventHandler(this.FRM_FORM_MASTER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcForm)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.gvForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormCode.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtFormName.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtVersion.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtTemplatePath.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtPartNameCell.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtControlNoCell.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.txtDateCell.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.chkDefault.Properties)).EndInit(); ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            this.ResumeLayout(false);
        }
        private DevExpress.XtraGrid.GridControl gcForm; private DevExpress.XtraGrid.Views.Grid.GridView gvForm;
        private DevExpress.XtraEditors.TextEdit txtFormCode, txtFormName, txtVersion, txtDescription, txtTemplatePath, txtPartNameCell, txtControlNoCell, txtDateCell;
        private DevExpress.XtraEditors.CheckEdit chkDefault, chkActive; private DevExpress.XtraEditors.SimpleButton btnBrowse, btnSave, btnGenerateSample;
    }
}
