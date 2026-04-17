using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Drawing;
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
            SetupGridFormat(gvUsers);
            ReloadData();
        }

        private void SetupGridFormat(GridView VIEW)
        {
            VIEW.OptionsView.ShowAutoFilterRow = true;
            VIEW.OptionsView.ShowGroupPanel = false;
            VIEW.Appearance.HeaderPanel.Font = new Font(VIEW.Appearance.HeaderPanel.Font, FontStyle.Bold);
            VIEW.Appearance.HeaderPanel.Options.UseFont = true;
            VIEW.OptionsView.ColumnAutoWidth = false;
            if (VIEW.Columns.ColumnByFieldName("STT") == null)
            {
                var col = VIEW.Columns.AddVisible("STT", "STT");
                col.VisibleIndex = 0;
                col.Width = 60;
                col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            }
            VIEW.CustomUnboundColumnData += (s, e) =>
            {
                if (e.Column.FieldName == "STT" && e.IsGetData) e.Value = e.ListSourceRowIndex + 1;
            };
        }

        private void ReloadData()
        {
            gcUsers.DataSource = _service.GetUsers();
            gvUsers.PopulateColumns();
            if (gvUsers.Columns["STT"] != null) gvUsers.Columns["STT"].VisibleIndex = 0;
            gvUsers.BestFitColumns();
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
