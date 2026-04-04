using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PC_Devices.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PC_Devices.FRM
{
    public partial class FRM_ACCOUNT_MANAGEMENT : XtraForm
    {
        private readonly UserDTO _userDto = new UserDTO();

        public FRM_ACCOUNT_MANAGEMENT()
        {
            InitializeComponent();
            btnSave.ImageOptions.Image = ImageResourceCache.Default.GetImage("images/save/save_16x16.png");
            Load += FRM_ACCOUNT_MANAGEMENT_Load;
            view.RowClick += View_RowClick;
            btnSave.Click += BtnSave_Click;
        }

        private void FRM_ACCOUNT_MANAGEMENT_Load(object sender, EventArgs e)
        {
            DataTable roles = _userDto.GetRoles();
            chkRoles.Items.Clear();
            foreach (DataRow row in roles.Rows)
            {
                chkRoles.Items.Add(row["ROLE_CODE"], false);
            }
            LoadUsers();
        }

        private void LoadUsers()
        {
            grid.DataSource = _userDto.GetUsers();
            view.BestFitColumns();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            List<string> roles = chkRoles.CheckedItems.Cast<CheckedListBoxItem>().Select(x => x.Value.ToString()).ToList();
            _userDto.SaveUser(txtUser.Text.Trim(), txtName.Text.Trim(), txtPassword.Text, chkActive.Checked, roles);
            XtraMessageBox.Show("Lưu tài khoản thành công.");
            LoadUsers();
        }

        private void View_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtUser.Text = view.GetRowCellDisplayText(e.RowHandle, "USER_ID");
            txtName.Text = view.GetRowCellDisplayText(e.RowHandle, "FULL_NAME");
            chkActive.Checked = view.GetRowCellValue(e.RowHandle, "IS_ACTIVE") != DBNull.Value && Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "IS_ACTIVE"));
            txtPassword.Text = string.Empty;

            string roleCsv = view.GetRowCellDisplayText(e.RowHandle, "ROLES") ?? string.Empty;
            for (int i = 0; i < chkRoles.Items.Count; i++)
            {
                string role = chkRoles.Items[i].Value.ToString();
                chkRoles.Items[i].CheckState = roleCsv.Split(',').Contains(role) ? CheckState.Checked : CheckState.Unchecked;
            }
        }
    }
}
