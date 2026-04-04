using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using PC_Devices.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PC_Devices.FRM
{
    public class FRM_ACCOUNT_MANAGEMENT : XtraForm
    {
        private readonly UserDTO _userDto = new UserDTO();
        private readonly GridControl grid = new GridControl();
        private readonly GridView view = new GridView();
        private readonly TextEdit txtUser = new TextEdit();
        private readonly TextEdit txtName = new TextEdit();
        private readonly TextEdit txtPassword = new TextEdit();
        private readonly CheckedListBoxControl chkRoles = new CheckedListBoxControl();
        private readonly CheckEdit chkActive = new CheckEdit();

        public FRM_ACCOUNT_MANAGEMENT()
        {
            Text = "Quản lý tài khoản & phân quyền";
            Width = 1000;
            Height = 700;

            PanelControl panel = new PanelControl { Dock = DockStyle.Top, Height = 190 };
            Controls.Add(panel);

            panel.Controls.Add(new LabelControl { Text = "User ID", Left = 15, Top = 20 });
            panel.Controls.Add(new LabelControl { Text = "Họ tên", Left = 15, Top = 55 });
            panel.Controls.Add(new LabelControl { Text = "Mật khẩu", Left = 15, Top = 90 });

            txtUser.SetBounds(90, 15, 180, 25);
            txtName.SetBounds(90, 50, 250, 25);
            txtPassword.SetBounds(90, 85, 180, 25);
            txtPassword.Properties.PasswordChar = '*';
            chkActive.Text = "Active";
            chkActive.SetBounds(90, 120, 100, 25);
            chkActive.Checked = true;

            chkRoles.SetBounds(370, 15, 280, 130);

            SimpleButton btnSave = new SimpleButton { Text = "Lưu", Left = 700, Top = 20, Width = 120 };
            btnSave.Click += BtnSave_Click;
            panel.Controls.Add(btnSave);

            panel.Controls.Add(txtUser);
            panel.Controls.Add(txtName);
            panel.Controls.Add(txtPassword);
            panel.Controls.Add(chkActive);
            panel.Controls.Add(chkRoles);

            grid.Dock = DockStyle.Fill;
            grid.MainView = view;
            grid.ViewCollection.Add(view);
            Controls.Add(grid);

            view.RowClick += View_RowClick;
            Load += FRM_ACCOUNT_MANAGEMENT_Load;
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
