using DevExpress.XtraEditors;
using DM_OHD.DTO;
using System;
using System.Windows.Forms;

namespace DM_OHD.FRM
{
    public partial class FRM_LOGIN : XtraForm
    {
        private readonly UserDTO _userDto = new UserDTO();

        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
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
