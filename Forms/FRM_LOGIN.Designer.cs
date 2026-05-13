namespace JigFlow.Forms
{
    partial class FRM_LOGIN
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblUsername = new DevExpress.XtraEditors.LabelControl();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.chkRememberPassword = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowPassword = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRememberPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowPassword.Properties)).BeginInit();
            this.SuspendLayout();
            this.lblUsername.Location = new System.Drawing.Point(28, 26);
            this.lblUsername.Text = "Tài khoản";
            this.txtUsername.Location = new System.Drawing.Point(108, 23);
            this.txtUsername.Size = new System.Drawing.Size(230, 22);
            this.lblPassword.Location = new System.Drawing.Point(28, 62);
            this.lblPassword.Text = "Mật khẩu";
            this.txtPassword.Location = new System.Drawing.Point(108, 59);
            this.txtPassword.Size = new System.Drawing.Size(230, 22);
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.chkRememberPassword.Location = new System.Drawing.Point(108, 90);
            this.chkRememberPassword.Properties.Caption = "Lưu mật khẩu";
            this.chkRememberPassword.Size = new System.Drawing.Size(110, 20);
            this.chkShowPassword.Location = new System.Drawing.Point(228, 90);
            this.chkShowPassword.Properties.Caption = "Hiển thị mật khẩu";
            this.chkShowPassword.Size = new System.Drawing.Size(120, 20);
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            this.btnLogin.Location = new System.Drawing.Point(108, 120);
            this.btnLogin.Size = new System.Drawing.Size(100, 30);
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnClose.Location = new System.Drawing.Point(238, 120);
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.ClientSize = new System.Drawing.Size(376, 170);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.chkRememberPassword);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FRM_LOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng nhập";
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRememberPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblUsername;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.CheckEdit chkRememberPassword;
        private DevExpress.XtraEditors.CheckEdit chkShowPassword;
    }
}
