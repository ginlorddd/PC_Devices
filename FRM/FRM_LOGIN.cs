using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PC_Devices.DB;
using PC_Devices.DTO;

namespace PC_Devices.FRM
{
    public partial class FRM_LOGIN : DevExpress.XtraEditors.XtraForm
    {
        public FRM_LOGIN()
        {
            InitializeComponent();
        }
        public string DataFromForm1 { get; set; }
        UserDTO _userDTO = new UserDTO();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string _userID = txtUser.Text.Trim();
                string _pass = txtPassword.Text.Trim();
                if (string.IsNullOrEmpty(_userID))
                {
                    MessageBox.Show("Tài khoản không được để trống!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.Focus();
                    return;
                }
                if (!string.IsNullOrEmpty(_userID))
                {
                    DataTable _data;
                    double _exsitsUser = 0;
                    string _query = "SELECT COUNT(*) as exsitsUser FROM TBL_ACCOUNT WHERE USER_ID='" + _userID + "'";
                    _data = DBUtils._getData(_query);
                    if (_data.Rows.Count > 0 && _data != null)
                    {
                        _exsitsUser = Convert.ToDouble(_data.Rows[0]["exsitsUser"]);
                        if (_exsitsUser <= 0)
                        {
                            MessageBox.Show("Tài khoản không tồn tại!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUser.Focus();
                            txtUser.SelectAll();
                            return;
                        }
                        else
                        {
                            txtPassword.Focus();
                        }
                    }
                }
                if (string.IsNullOrEmpty(_pass))
                {
                    MessageBox.Show("Mật khẩu không được để trống!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
                if (!string.IsNullOrEmpty(_userID) && !string.IsNullOrEmpty(_pass))
                {
                    try
                    {
                        bool _checkLogin = _userDTO._loginUser(_userID, _pass);
                        if (_checkLogin == true)
                        {
                            Constaint.isLoginOK = 1;
                            //FRM_MAIN _main = new FRM_MAIN();
                            //_main.Show();
                            //DialogResult = DialogResult.OK;
                            //btnLogin.Visible = false;
                            //mnUser.Visible = true;
                            DataFromForm1 = "1";
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không đúng!", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Focus();
                            txtPassword.SelectAll();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), _userID);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Đã sảy ra lỗi khi đăng nhập!\nLiên hệ bộ phận IT để được hỗ trợ!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void FRM_LOGIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            //Application.Exit();
        }
    }
}