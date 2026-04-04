using DevExpress.XtraEditors;
using PC_Devices.DB;
using PC_Devices.DTO;
using System;
using System.Windows.Forms;

namespace PC_Devices.FRM
{
    public class FRM_CHANGE_PASSWORD : XtraForm
    {
        private readonly TextEdit txtOld = new TextEdit();
        private readonly TextEdit txtNew = new TextEdit();
        private readonly TextEdit txtConfirm = new TextEdit();
        private readonly UserDTO _userDto = new UserDTO();

        public FRM_CHANGE_PASSWORD()
        {
            Text = "Đổi mật khẩu";
            Width = 420;
            Height = 260;

            Controls.Add(new LabelControl { Text = "Mật khẩu cũ", Left = 30, Top = 30 });
            Controls.Add(new LabelControl { Text = "Mật khẩu mới", Left = 30, Top = 70 });
            Controls.Add(new LabelControl { Text = "Xác nhận", Left = 30, Top = 110 });

            ConfigurePassword(txtOld, 140, 25);
            ConfigurePassword(txtNew, 140, 65);
            ConfigurePassword(txtConfirm, 140, 105);

            SimpleButton btnSave = new SimpleButton { Text = "Lưu", Left = 140, Top = 155, Width = 120 };
            btnSave.Click += BtnSave_Click;
            Controls.Add(btnSave);
        }

        private void ConfigurePassword(TextEdit textEdit, int left, int top)
        {
            textEdit.Left = left;
            textEdit.Top = top;
            textEdit.Width = 220;
            textEdit.Properties.PasswordChar = '*';
            Controls.Add(textEdit);
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
