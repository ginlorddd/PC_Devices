using DevExpress.XtraEditors;
using PC_Devices.DB;
using PC_Devices.DTO;
using System;

namespace PC_Devices.FRM
{
    public partial class FRM_CHANGE_PASSWORD : XtraForm
    {
        private readonly UserDTO _userDto = new UserDTO();

        public FRM_CHANGE_PASSWORD()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtNew.Text != txtConfirm.Text)
            {
                XtraMessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }

            try
            {
                _userDto.ChangePassword(Constaint.CurrentUserId, txtOld.Text, txtNew.Text);
                XtraMessageBox.Show("Đổi mật khẩu thành công.");
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}
