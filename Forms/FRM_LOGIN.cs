using JigFlow.Data;
using System;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_LOGIN : DevExpress.XtraEditors.XtraForm
    {
        private readonly AuthService _authService = new AuthService();

        public FRM_LOGIN()
        {
            InitializeComponent();
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

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
