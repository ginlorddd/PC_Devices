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
using System.Data.SqlClient;

namespace PC_Devices.FRM
{
    public partial class FRM_USER_CHANGE_PASSWORD : DevExpress.XtraEditors.XtraForm
    {
        public FRM_USER_CHANGE_PASSWORD()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (Constaint._password != Constaint._md5(txtMKCu.Text))
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng!", "CHANGE PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMKCu.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtMKMoi1.Text.Trim()))
                {
                    MessageBox.Show("Mật khẩu không được để trống!", "CHANGE PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMKMoi1.Focus();
                    txtMKMoi1.SelectAll();
                    return;
                }
                if (txtMKMoi1.Text != txtMKMoi2.Text)
                {
                    MessageBox.Show("Mật khẩu nhập lại không đúng!", "CHANGE PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMKMoi2.Focus();
                    return;
                }
                else
                {
                    string queryUpdate = "UPDATE TBL_ACCOUNT SET PASSWORD = @PASSWORD WHERE USER_ID = @USER_ID";
                    using (SqlConnection connection = new SqlConnection(DBUtils._stringConnection))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(queryUpdate, connection))
                        {
                            cmd.Parameters.AddWithValue("@USER_ID", Constaint._userID);
                            cmd.Parameters.AddWithValue("@PASSWORD", Constaint._md5(txtMKMoi2.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Cập nhật mật khẩu thành công", "CHANGE PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRM_USER_CHANGE_PASSWORD_Load(object sender, EventArgs e)
        {

        }
    }
}