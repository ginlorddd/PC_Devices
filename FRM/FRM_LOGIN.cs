using DevExpress.XtraEditors;
using PC_Devices.DTO;
using System;
using System.Windows.Forms;

namespace PC_Devices.FRM
{
    public class FRM_LOGIN : XtraForm
    {
        private readonly TextEdit txtUser = new TextEdit();
        private readonly TextEdit txtPassword = new TextEdit();
        private readonly SimpleButton btnLogin = new SimpleButton();
        private readonly UserDTO _userDto = new UserDTO();

        public FRM_LOGIN()
        {
            Text = "Đăng nhập - DM_OHD";
            Width = 420;
            Height = 230;
            StartPosition = FormStartPosition.CenterScreen;

            LabelControl lblUser = new LabelControl { Text = "User ID", Left = 35, Top = 35, Width = 100 };
            LabelControl lblPassword = new LabelControl { Text = "Mật khẩu", Left = 35, Top = 75, Width = 100 };

            txtUser.Left = 130;
            txtUser.Top = 30;
            txtUser.Width = 220;

            txtPassword.Left = 130;
            txtPassword.Top = 70;
            txtPassword.Width = 220;
            txtPassword.Properties.PasswordChar = '*';

            btnLogin.Text = "Đăng nhập";
            btnLogin.Left = 130;
            btnLogin.Top = 120;
            btnLogin.Width = 120;
            btnLogin.Click += BtnLogin_Click;

            Controls.Add(lblUser);
            Controls.Add(lblPassword);
            Controls.Add(txtUser);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);

            AcceptButton = btnLogin;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (_userDto.Login(txtUser.Text.Trim(), txtPassword.Text))
            {
                Hide();
                using (FRM_MAIN frm = new FRM_MAIN())
                {
                    frm.ShowDialog();
                }
                Close();
            }
            else
            {
                XtraMessageBox.Show("Sai tài khoản hoặc mật khẩu.", "DM_OHD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
