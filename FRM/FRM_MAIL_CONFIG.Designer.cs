namespace DM_OHD.FRM
{
    partial class FRM_MAIL_CONFIG
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraEditors.LabelControl lblCc;
        private DevExpress.XtraEditors.LabelControl lblSubject;
        private DevExpress.XtraEditors.LabelControl lblBody;
        private DevExpress.XtraEditors.TextEdit txtTo;
        private DevExpress.XtraEditors.TextEdit txtCc;
        private DevExpress.XtraEditors.TextEdit txtSubject;
        private DevExpress.XtraEditors.MemoEdit txtBody;
        private DevExpress.XtraEditors.SpinEdit spFreq;
        private DevExpress.XtraEditors.LabelControl lblFreq;
        private DevExpress.XtraEditors.CheckEdit chkEnabled;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnSendTest;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.lblCc = new DevExpress.XtraEditors.LabelControl();
            this.lblSubject = new DevExpress.XtraEditors.LabelControl();
            this.lblBody = new DevExpress.XtraEditors.LabelControl();
            this.txtTo = new DevExpress.XtraEditors.TextEdit();
            this.txtCc = new DevExpress.XtraEditors.TextEdit();
            this.txtSubject = new DevExpress.XtraEditors.TextEdit();
            this.txtBody = new DevExpress.XtraEditors.MemoEdit();
            this.spFreq = new DevExpress.XtraEditors.SpinEdit();
            this.lblFreq = new DevExpress.XtraEditors.LabelControl();
            this.chkEnabled = new DevExpress.XtraEditors.CheckEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnSendTest = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBody.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFreq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnabled.Properties)).BeginInit();
            this.SuspendLayout();
            this.lblTo.Location = new System.Drawing.Point(16, 20); this.lblTo.Text = "To:";
            this.txtTo.Location = new System.Drawing.Point(90, 16); this.txtTo.Size = new System.Drawing.Size(640, 22);
            this.lblCc.Location = new System.Drawing.Point(16, 52); this.lblCc.Text = "CC:";
            this.txtCc.Location = new System.Drawing.Point(90, 48); this.txtCc.Size = new System.Drawing.Size(640, 22);
            this.lblSubject.Location = new System.Drawing.Point(16, 84); this.lblSubject.Text = "Subject:";
            this.txtSubject.Location = new System.Drawing.Point(90, 80); this.txtSubject.Size = new System.Drawing.Size(640, 22);
            this.lblBody.Location = new System.Drawing.Point(16, 116); this.lblBody.Text = "Body:";
            this.txtBody.Location = new System.Drawing.Point(90, 114); this.txtBody.Size = new System.Drawing.Size(640, 300);
            this.lblFreq.Location = new System.Drawing.Point(16, 430); this.lblFreq.Text = "Tần suất (ngày):";
            this.spFreq.Location = new System.Drawing.Point(120, 426); this.spFreq.Properties.IsFloatValue = false; this.spFreq.Properties.MinValue = 1; this.spFreq.Properties.MaxValue = 30; this.spFreq.Size = new System.Drawing.Size(80, 22);
            this.chkEnabled.Location = new System.Drawing.Point(230, 426); this.chkEnabled.Properties.Caption = "Bật gửi mail";
            this.btnSave.Location = new System.Drawing.Point(520, 460); this.btnSave.Size = new System.Drawing.Size(100, 30); this.btnSave.Text = "Lưu";
            this.btnSendTest.Location = new System.Drawing.Point(630, 460); this.btnSendTest.Size = new System.Drawing.Size(100, 30); this.btnSendTest.Text = "Gửi thử";
            this.ClientSize = new System.Drawing.Size(760, 510);
            this.Controls.Add(this.lblTo); this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblCc); this.Controls.Add(this.txtCc);
            this.Controls.Add(this.lblSubject); this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblBody); this.Controls.Add(this.txtBody);
            this.Controls.Add(this.lblFreq); this.Controls.Add(this.spFreq);
            this.Controls.Add(this.chkEnabled); this.Controls.Add(this.btnSave); this.Controls.Add(this.btnSendTest);
            this.Name = "FRM_MAIL_CONFIG";
            this.Text = "Config mail";
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBody.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFreq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnabled.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
