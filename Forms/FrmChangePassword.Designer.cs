namespace JigFlow.Forms
{
    partial class FrmChangePassword
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCurrentPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            this.SuspendLayout();
            this.labelControl1.Location = new System.Drawing.Point(20, 24); this.labelControl1.Text = "Mật khẩu cũ";
            this.labelControl2.Location = new System.Drawing.Point(20, 60); this.labelControl2.Text = "Mật khẩu mới";
            this.labelControl3.Location = new System.Drawing.Point(20, 96); this.labelControl3.Text = "Nhập lại";
            this.txtCurrentPassword.Location = new System.Drawing.Point(120, 21); this.txtCurrentPassword.Size = new System.Drawing.Size(228, 22); this.txtCurrentPassword.Properties.UseSystemPasswordChar = true;
            this.txtNewPassword.Location = new System.Drawing.Point(120, 57); this.txtNewPassword.Size = new System.Drawing.Size(228, 22); this.txtNewPassword.Properties.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Location = new System.Drawing.Point(120, 93); this.txtConfirmPassword.Size = new System.Drawing.Size(228, 22); this.txtConfirmPassword.Properties.UseSystemPasswordChar = true;
            this.btnSave.Location = new System.Drawing.Point(120, 131); this.btnSave.Size = new System.Drawing.Size(100, 30); this.btnSave.Text = "Cập nhật"; this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnClose.Location = new System.Drawing.Point(248, 131); this.btnClose.Size = new System.Drawing.Size(100, 30); this.btnClose.Text = "Đóng"; this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.ClientSize = new System.Drawing.Size(375, 178);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.labelControl1, this.labelControl2, this.labelControl3, this.txtCurrentPassword, this.txtNewPassword, this.txtConfirmPassword, this.btnSave, this.btnClose });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DevExpress.XtraEditors.TextEdit txtCurrentPassword;
        private DevExpress.XtraEditors.TextEdit txtNewPassword;
        private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
