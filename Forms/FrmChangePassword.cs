using JigFlow.Data;
using System;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FrmChangePassword : DevExpress.XtraEditors.XtraForm
    {
        private readonly AuthService _authService = new AuthService();

        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.");
                return;
            }

            var ok = _authService.ChangePassword(AppSession.UserId, txtCurrentPassword.Text, txtNewPassword.Text);
            MessageBox.Show(ok ? "Đổi mật khẩu thành công." : "Mật khẩu hiện tại không đúng.");
            if (ok) Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
