using JigFlow.Data;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_LOGIN : DevExpress.XtraEditors.XtraForm
    {
        private readonly AuthService _authService = new AuthService();
        private const string REG_PATH = @"Software\JigFlow\Login";

        public FRM_LOGIN()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadRememberedLogin();
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.");
                return;
            }

            var user = _authService.Login(username, password);
            if (user == null)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                return;
            }

            SaveRememberedLogin(username, password);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Properties.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void LoadRememberedLogin()
        {
            using (var key = Registry.CurrentUser.CreateSubKey(REG_PATH))
            {
                var savedUser = Convert.ToString(key.GetValue("Username", string.Empty));
                var savedPass = Convert.ToString(key.GetValue("Password", string.Empty));
                var remember = Convert.ToString(key.GetValue("RememberPassword", "0")) == "1";

                txtUsername.Text = savedUser;
                chkRememberPassword.Checked = remember;
                if (remember) txtPassword.Text = savedPass;
            }
        }

        private void SaveRememberedLogin(string username, string password)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(REG_PATH))
            {
                key.SetValue("Username", username ?? string.Empty);
                key.SetValue("RememberPassword", chkRememberPassword.Checked ? "1" : "0");
                key.SetValue("Password", chkRememberPassword.Checked ? (password ?? string.Empty) : string.Empty);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
