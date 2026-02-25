namespace PC_Devices.FRM.MAIL
{
    partial class FRM_SEND_EMAIL_MAINT
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

        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.SimpleButton btnClose;

        /// <summary>
        ///  Dispose
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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

            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBody.Properties)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(20, 20);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 16);
            this.lblTo.Text = "To:";

            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(90, 15);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(580, 22);

            // 
            // lblCc
            // 
            this.lblCc.Location = new System.Drawing.Point(20, 55);
            this.lblCc.Name = "lblCc";
            this.lblCc.Size = new System.Drawing.Size(20, 16);
            this.lblCc.Text = "CC:";

            // 
            // txtCc
            // 
            this.txtCc.Location = new System.Drawing.Point(90, 50);
            this.txtCc.Name = "txtCc";
            this.txtCc.Size = new System.Drawing.Size(580, 22);

            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(20, 90);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(50, 16);
            this.lblSubject.Text = "Subject:";

            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(90, 85);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(580, 22);

            // 
            // lblBody
            // 
            this.lblBody.Location = new System.Drawing.Point(20, 130);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(35, 16);
            this.lblBody.Text = "Body:";

            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(20, 155);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(650, 320);

            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(410, 490);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 35);
            this.btnSend.Text = "Gửi Email";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(550, 490);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // FRM_SEND_EMAIL_MAINT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(700, 550);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txtTo);

            this.Controls.Add(this.lblCc);
            this.Controls.Add(this.txtCc);

            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.txtSubject);

            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.txtBody);

            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClose);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FRM_SEND_EMAIL_MAINT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gửi Email Nhắc Bảo Dưỡng";
            this.Load += new System.EventHandler(this.FRM_SEND_EMAIL_MAINT_Load);

            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBody.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
