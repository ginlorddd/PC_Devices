using JigFlow.Data;
using System;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_ACCOUNT_MANAGEMENT : DevExpress.XtraEditors.XtraForm
    {
        private readonly UserManagementService _service = new UserManagementService();

        public FRM_ACCOUNT_MANAGEMENT()
        {
            InitializeComponent();
        }

        private void FRM_ACCOUNT_MANAGEMENT_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            gcUsers.DataSource = _service.GetUsers();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập Username và Họ tên.");
                return;
            }

            var password = string.IsNullOrWhiteSpace(txtPassword.Text) ? "123456" : txtPassword.Text;
            _service.SaveUser(txtUsername.Text.Trim(), txtFullName.Text.Trim(), cboRole.Text.Trim(), txtEmail.Text.Trim(), chkIsActive.Checked, password);
            ReloadData();
            MessageBox.Show("Đã lưu tài khoản.");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
    }
}
