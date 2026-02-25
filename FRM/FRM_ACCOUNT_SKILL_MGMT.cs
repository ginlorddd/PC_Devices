using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_ACCOUNT_SKILL_MGMT : XtraForm
    {
        // ===== Account state =====
        private bool _isEdit = false;      // đang edit/add
        private bool _isAddNew = false;    // đang add
        private int _currentId = -1;
        private string _currentEmpCode = "";

        // ===== Skills =====
        private RepositoryItemSpinEdit _repoSpinLevel;
        private RepositoryItemCheckEdit _repoCheckAllowed;
        private DataTable _dtSkills;

        public FRM_ACCOUNT_SKILL_MGMT()
        {
            InitializeComponent();
        }

        private void FRM_ACCOUNT_SKILL_MGMT_Load(object sender, EventArgs e)
        {
            try
            {
                BuildSkillRepositories();
                SetupSkillGrid();

                LoadAccounts();
                SetEditMode(false);
                ClearAccountForm();

                // Nếu có dòng đầu thì focus load
                if (gvAccount.RowCount > 0)
                {
                    gvAccount.FocusedRowHandle = 0;
                    LoadAccountToFormFromFocusedRow();
                }
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // COMMON: Permission
        // =========================================================
        private bool RequireAdmin()
        {
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Constaint._access != "1")
            {
                MessageBox.Show("Bạn không có quyền (Admin)!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private object DbNullIfEmpty(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return DBNull.Value;
            return s.Trim();
        }

        private int ParseAccess()
        {
            // cboAccess items: "1 - Admin", "2 - User", "3 - Approver"
            string t = cboAccess.Text?.Trim() ?? "";
            if (t.Length == 0) return 2;

            // lấy phần trước dấu '-'
            string[] parts = t.Split('-');
            if (parts.Length > 0 && int.TryParse(parts[0].Trim(), out int v))
                return v;

            // fallback: nếu user nhập "1"
            if (int.TryParse(t, out int v2)) return v2;

            return 2;
        }

        // =========================================================
        // ACCOUNTS: Load list
        // =========================================================
        private void LoadAccounts()
        {
            string sql = @"
SELECT 
    ID,
    FULLNAME,
    USER_ID,
    EMAIL,
    ID_ACCESS,
    Position,
    FactoryName,
    CREATE_BY,
    CREATE_AT
FROM dbo.TBL_ACCOUNT
ORDER BY ID DESC;";

            DataTable dt = DBUtils._getData(sql);
            gcAccount.DataSource = dt;

            // captions (nếu có)
            if (gvAccount.Columns["ID"] != null) gvAccount.Columns["ID"].Caption = "ID";
            if (gvAccount.Columns["FULLNAME"] != null) gvAccount.Columns["FULLNAME"].Caption = "Họ tên";
            if (gvAccount.Columns["USER_ID"] != null) gvAccount.Columns["USER_ID"].Caption = "USER_ID";
            if (gvAccount.Columns["EMAIL"] != null) gvAccount.Columns["EMAIL"].Caption = "Email";
            if (gvAccount.Columns["ID_ACCESS"] != null) gvAccount.Columns["ID_ACCESS"].Caption = "Quyền";
            if (gvAccount.Columns["Position"] != null) gvAccount.Columns["Position"].Caption = "Position";
            if (gvAccount.Columns["FactoryName"] != null) gvAccount.Columns["FactoryName"].Caption = "Factory";
            if (gvAccount.Columns["CREATE_AT"] != null) gvAccount.Columns["CREATE_AT"].Caption = "CreateAt";

            gvAccount.BestFitColumns();
        }

        private void gvAccount_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (_isEdit) return; // đang edit thì không auto đổi
            LoadAccountToFormFromFocusedRow();
        }

        private void LoadAccountToFormFromFocusedRow()
        {
            if (gvAccount.FocusedRowHandle < 0) return;

            object idObj = gvAccount.GetFocusedRowCellValue("ID");
            if (idObj == null || idObj == DBNull.Value) return;

            _currentId = Convert.ToInt32(idObj);

            txtFullName.Text = Convert.ToString(gvAccount.GetFocusedRowCellValue("FULLNAME"));
            txtUserID.Text = Convert.ToString(gvAccount.GetFocusedRowCellValue("USER_ID"));
            txtEmail.Text = Convert.ToString(gvAccount.GetFocusedRowCellValue("EMAIL"));
            cboPosition.Text = Convert.ToString(gvAccount.GetFocusedRowCellValue("Position"));
            cboFactory.Text = Convert.ToString(gvAccount.GetFocusedRowCellValue("FactoryName"));

            int access = 2;
            object a = gvAccount.GetFocusedRowCellValue("ID_ACCESS");
            if (a != null && a != DBNull.Value) access = Convert.ToInt32(a);

            cboAccess.SelectedIndex = -1;
            if (access == 1) cboAccess.Text = "1 - Admin";
            else if (access == 3) cboAccess.Text = "3 - Approver";
            else cboAccess.Text = "2 - User";

            // Load skills by EmpCode = USER_ID
            _currentEmpCode = txtUserID.Text.Trim();
            lblEmpSelected.Text = string.IsNullOrWhiteSpace(_currentEmpCode)
                ? "Nhân viên đang chọn: (chưa chọn)"
                : $"Nhân viên đang chọn: {txtFullName.Text} - {_currentEmpCode}";

            LoadAllSkillsToGrid(); // master
            if (!string.IsNullOrWhiteSpace(_currentEmpCode))
                LoadUserValuesToSkillGrid(_currentEmpCode);
        }

        private void ClearAccountForm()
        {
            _currentId = -1;
            _currentEmpCode = "";

            txtFullName.Text = "";
            txtUserID.Text = "";
            txtEmail.Text = "";
            cboPosition.Text = "";
            cboFactory.Text = "";
            cboAccess.Text = "2 - User";
            chkLockUser.Checked = false;

            lblEmpSelected.Text = "Nhân viên đang chọn: (chưa chọn)";

            LoadAllSkillsToGrid();
        }

        private void SetEditMode(bool editing)
        {
            _isEdit = editing;

            // account fields
            txtFullName.Properties.ReadOnly = !editing;
            txtUserID.Properties.ReadOnly = !editing; // nếu bạn muốn không cho sửa USER_ID khi edit, set true khi !_isAddNew
            txtEmail.Properties.ReadOnly = !editing;
            cboPosition.Properties.ReadOnly = !editing;
            cboFactory.Properties.ReadOnly = !editing;
            cboAccess.Properties.ReadOnly = !editing;

            if (editing && !_isAddNew)
            {
                // khi sửa: thường không cho đổi USER_ID
                txtUserID.Properties.ReadOnly = true;
            }

            // buttons
            btnAdd.Enabled = !editing;
            btnEdit.Enabled = !editing;
            btnDelete.Enabled = !editing;
            btnResetPass.Enabled = !editing;
            btnRefresh.Enabled = !editing;

            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;
        }

        // =========================================================
        // BUTTONS: Account CRUD
        // =========================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!RequireAdmin()) return;

            _isAddNew = true;
            SetEditMode(true);
            ClearAccountForm();

            txtUserID.Properties.ReadOnly = false;
            txtFullName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!RequireAdmin()) return;

            if (gvAccount.FocusedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isAddNew = false;
            SetEditMode(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _isAddNew = false;
            SetEditMode(false);
            LoadAccountToFormFromFocusedRow();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!RequireAdmin()) return;

            if (gvAccount.FocusedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(gvAccount.GetFocusedRowCellValue("ID"));
            string userId = Convert.ToString(gvAccount.GetFocusedRowCellValue("USER_ID"));

            if (MessageBox.Show($"Xóa tài khoản [{userId}] ?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.TBL_ACCOUNT WHERE ID=@ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadAccounts();
                ClearAccountForm();
            }
            catch
            {
                MessageBox.Show("Không xóa được!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (!RequireAdmin()) return;

            if (gvAccount.FocusedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần reset mật khẩu!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(gvAccount.GetFocusedRowCellValue("ID"));
            string userId = Convert.ToString(gvAccount.GetFocusedRowCellValue("USER_ID"));

            if (MessageBox.Show($"Reset password tài khoản [{userId}] về mặc định (123456)?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                // ⚠️ Nếu hệ thống bạn hash password -> thay chỗ này
                string defaultPass = "e10adc3949ba59abbe56e057f20f883e";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand("UPDATE dbo.TBL_ACCOUNT SET [PASSWORD]=@P WHERE ID=@ID", conn))
                {
                    cmd.Parameters.AddWithValue("@P", defaultPass);
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã reset password!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không reset được!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!RequireAdmin()) return;

            // validate basic
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Họ tên không được rỗng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("USER_ID không được rỗng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();

                    if (_isAddNew)
                    {
                        // Check duplicate USER_ID
                        using (SqlCommand chk = new SqlCommand("SELECT COUNT(1) FROM dbo.TBL_ACCOUNT WHERE USER_ID=@U", conn))
                        {
                            chk.Parameters.AddWithValue("@U", txtUserID.Text.Trim());
                            int exists = Convert.ToInt32(chk.ExecuteScalar());
                            if (exists > 0)
                            {
                                MessageBox.Show("USER_ID đã tồn tại!", "Cảnh báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        string insert = @"
INSERT INTO dbo.TBL_ACCOUNT
(FULLNAME, USER_ID, [PASSWORD], ID_ACCESS, CREATE_BY, CREATE_AT, EMAIL, Position, FactoryName)
VALUES
(@FULLNAME, @USER_ID, @PASSWORD, @ID_ACCESS, @CREATE_BY, GETDATE(), @EMAIL, @Position, @FactoryName);
SELECT SCOPE_IDENTITY();
";

                        using (SqlCommand cmd = new SqlCommand(insert, conn))
                        {
                            // ⚠️ Password mặc định khi tạo mới (đổi theo bạn)
                            string defaultPass = "e10adc3949ba59abbe56e057f20f883e";

                            cmd.Parameters.AddWithValue("@FULLNAME", txtFullName.Text.Trim());
                            cmd.Parameters.AddWithValue("@USER_ID", txtUserID.Text.Trim());
                            cmd.Parameters.AddWithValue("@PASSWORD", defaultPass);
                            cmd.Parameters.AddWithValue("@ID_ACCESS", ParseAccess());
                            cmd.Parameters.AddWithValue("@CREATE_BY", (object)Constaint._userID ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@EMAIL", DbNullIfEmpty(txtEmail.Text));
                            cmd.Parameters.AddWithValue("@Position", DbNullIfEmpty(cboPosition.Text));
                            cmd.Parameters.AddWithValue("@FactoryName", DbNullIfEmpty(cboFactory.Text));

                            object newId = cmd.ExecuteScalar();
                            _currentId = Convert.ToInt32(Convert.ToDecimal(newId));
                        }
                    }
                    else
                    {
                        if (_currentId <= 0)
                        {
                            MessageBox.Show("Không xác định được ID để cập nhật!", "Cảnh báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string update = @"
UPDATE dbo.TBL_ACCOUNT
SET FULLNAME=@FULLNAME,
    EMAIL=@EMAIL,
    ID_ACCESS=@ID_ACCESS,
    Position=@Position,
    FactoryName=@FactoryName
WHERE ID=@ID;
";

                        using (SqlCommand cmd = new SqlCommand(update, conn))
                        {
                            cmd.Parameters.AddWithValue("@FULLNAME", txtFullName.Text.Trim());
                            cmd.Parameters.AddWithValue("@EMAIL", DbNullIfEmpty(txtEmail.Text));
                            cmd.Parameters.AddWithValue("@ID_ACCESS", ParseAccess());
                            cmd.Parameters.AddWithValue("@Position", DbNullIfEmpty(cboPosition.Text));
                            cmd.Parameters.AddWithValue("@FactoryName", DbNullIfEmpty(cboFactory.Text));
                            cmd.Parameters.AddWithValue("@ID", _currentId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Lưu tài khoản thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _isAddNew = false;
                SetEditMode(false);

                LoadAccounts();
                // focus lại row vừa lưu
                FocusRowById(_currentId);
            }
            catch
            {
                MessageBox.Show("Không lưu được tài khoản!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FocusRowById(int id)
        {
            try
            {
                for (int i = 0; i < gvAccount.RowCount; i++)
                {
                    object v = gvAccount.GetRowCellValue(i, "ID");
                    if (v != null && v != DBNull.Value && Convert.ToInt32(v) == id)
                    {
                        gvAccount.FocusedRowHandle = i;
                        return;
                    }
                }
            }
            catch { }
        }

        // =========================================================
        // SKILLS: Grid Setup + load/save (Option A)
        // =========================================================
        private void BuildSkillRepositories()
        {
            _repoSpinLevel = new RepositoryItemSpinEdit
            {
                IsFloatValue = false,
                MinValue = 0,
                MaxValue = 50,
                Increment = 1
            };

            _repoCheckAllowed = new RepositoryItemCheckEdit
            {
                AllowGrayed = false,
                NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked,
                ValueChecked = true,
                ValueUnchecked = false
            };

            gcSkills.RepositoryItems.Add(_repoSpinLevel);
            gcSkills.RepositoryItems.Add(_repoCheckAllowed);
        }

        private void SetupSkillGrid()
        {
            gvSkills.OptionsView.ShowGroupPanel = false;
            gvSkills.OptionsView.ShowAutoFilterRow = true;

            // ✅ checkbox 1-click
            gvSkills.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            gvSkills.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvSkills.OptionsBehavior.Editable = true;

            gvSkills.RowStyle -= gvSkills_RowStyle;
            gvSkills.RowStyle += gvSkills_RowStyle;

            gvSkills.ShowingEditor -= gvSkills_ShowingEditor;
            gvSkills.ShowingEditor += gvSkills_ShowingEditor;

            gvSkills.RowCellClick -= gvSkills_RowCellClick;
            gvSkills.RowCellClick += gvSkills_RowCellClick;

            gvSkills.CellValueChanging -= gvSkills_CellValueChanging;
            gvSkills.CellValueChanging += gvSkills_CellValueChanging;
        }

        private void gvSkills_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            string type = Convert.ToString(gvSkills.GetRowCellValue(e.RowHandle, "SkillType"));
            if (type == "LEVEL")
            {
                e.Appearance.BackColor = Color.AliceBlue;
                e.Appearance.ForeColor = Color.Black;
                e.HighPriority = true;
            }
            else if (type == "BOOLEAN")
            {
                e.Appearance.BackColor = Color.LemonChiffon;
                e.Appearance.ForeColor = Color.Black;
                e.HighPriority = true;
            }
        }

        private void gvSkills_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (gvSkills.FocusedRowHandle < 0) return;

            string type = Convert.ToString(gvSkills.GetFocusedRowCellValue("SkillType"));
            string field = gvSkills.FocusedColumn.FieldName;

            if (type == "LEVEL" && field == "Allowed") { e.Cancel = true; return; }
            if (type == "BOOLEAN" && field == "LevelMax") { e.Cancel = true; return; }
            if (field == "SkillName") { e.Cancel = true; return; }
        }

        private void gvSkills_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName != "Allowed") return;

            string type = Convert.ToString(gvSkills.GetRowCellValue(e.RowHandle, "SkillType"));
            if (type != "BOOLEAN") return;

            bool cur = false;
            object v = gvSkills.GetRowCellValue(e.RowHandle, "Allowed");
            if (v != null && v != DBNull.Value) cur = Convert.ToBoolean(v);

            gvSkills.SetRowCellValue(e.RowHandle, "Allowed", !cur);
        }

        private void gvSkills_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName != "LevelMax") return;

            string type = Convert.ToString(gvSkills.GetRowCellValue(e.RowHandle, "SkillType"));
            if (type != "LEVEL") return;

            int maxLevel = 0;
            object mx = gvSkills.GetRowCellValue(e.RowHandle, "MaxLevel");
            if (mx != null && mx != DBNull.Value) maxLevel = Convert.ToInt32(mx);

            int val = 0;
            if (e.Value != null && e.Value != DBNull.Value)
                int.TryParse(e.Value.ToString(), out val);

            if (val < 0) val = 0;
            if (maxLevel > 0 && val > maxLevel) val = maxLevel;

            gvSkills.SetRowCellValue(e.RowHandle, "LevelMax", val);
        }

        private void LoadAllSkillsToGrid()
        {
            // ⚠️ bạn phải có các bảng master này:
            // TBL_SKILL_MST (SkillID, SkillName, SkillType, IsActive, SortOrder...)
            // TBL_SKILL_LEVEL_MST (SkillID, LevelNo, IsActive...)
            string sql = @"
SELECT 
    SM.SkillID,
    SM.SkillName,
    SM.SkillType,
    ISNULL((
        SELECT MAX(LevelNo) FROM dbo.TBL_SKILL_LEVEL_MST L
        WHERE L.SkillID = SM.SkillID AND ISNULL(L.IsActive,1)=1
    ), 0) AS MaxLevel
FROM dbo.TBL_SKILL_MST SM
WHERE ISNULL(SM.IsActive,1)=1
ORDER BY ISNULL(SM.SortOrder,999), SM.SkillName;";

            _dtSkills = DBUtils._getData(sql) ?? new DataTable();

            if (!_dtSkills.Columns.Contains("LevelMax"))
                _dtSkills.Columns.Add("LevelMax", typeof(int));
            if (!_dtSkills.Columns.Contains("Allowed"))
                _dtSkills.Columns.Add("Allowed", typeof(bool));

            foreach (DataRow r in _dtSkills.Rows)
            {
                r["LevelMax"] = 0;
                r["Allowed"] = false;
            }

            gcSkills.DataSource = _dtSkills;
            BuildSkillColumns();
        }

        private void BuildSkillColumns()
        {
            gvSkills.Columns.Clear();
            gvSkills.PopulateColumns();

            // hide technical
            if (gvSkills.Columns["SkillID"] != null) gvSkills.Columns["SkillID"].Visible = false;
            if (gvSkills.Columns["MaxLevel"] != null) gvSkills.Columns["MaxLevel"].Visible = false;

            // ✅ hide Type column theo yêu cầu
            if (gvSkills.Columns["SkillType"] != null) gvSkills.Columns["SkillType"].Visible = false;

            gvSkills.Columns["SkillName"].Caption = "Kỹ năng";
            gvSkills.Columns["LevelMax"].Caption = "Level đạt (0..n)";
            gvSkills.Columns["Allowed"].Caption = "Được phép";

            gvSkills.Columns["SkillName"].OptionsColumn.AllowEdit = false;
            gvSkills.Columns["LevelMax"].ColumnEdit = _repoSpinLevel;
            gvSkills.Columns["Allowed"].ColumnEdit = _repoCheckAllowed;

            gvSkills.BestFitColumns();
        }

        private void LoadUserValuesToSkillGrid(string empCode)
        {
            try
            {
                // LEVEL: max level passed
                string sqlLevel = @"
SELECT 
    UL.SkillID,
    MAX(UL.LevelNo) AS LevelMax
FROM dbo.TBL_USER_SKILL_LEVEL UL
WHERE UL.EmpCode=@EmpCode
  AND ISNULL(UL.Huy,0)=0
  AND ISNULL(UL.IsPassed,0)=1
GROUP BY UL.SkillID;";

                // BOOLEAN: allowed
                string sqlAllow = @"
SELECT 
    UA.SkillID,
    MAX(CASE WHEN ISNULL(UA.Huy,0)=0 AND ISNULL(UA.IsAllowed,0)=1 THEN 1 ELSE 0 END) AS Allowed
FROM dbo.TBL_USER_SKILL_ALLOW UA
WHERE UA.EmpCode=@EmpCode
GROUP BY UA.SkillID;";

                DataTable dtLv = new DataTable();
                DataTable dtAl = new DataTable();

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlLevel, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpCode", empCode);
                        new SqlDataAdapter(cmd).Fill(dtLv);
                    }
                    using (SqlCommand cmd = new SqlCommand(sqlAllow, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpCode", empCode);
                        new SqlDataAdapter(cmd).Fill(dtAl);
                    }
                }

                foreach (DataRow r in _dtSkills.Rows)
                {
                    int skillId = Convert.ToInt32(r["SkillID"]);
                    string type = Convert.ToString(r["SkillType"]);

                    if (type == "LEVEL")
                    {
                        DataRow[] found = dtLv.Select("SkillID=" + skillId);
                        int levelMax = (found.Length > 0) ? Convert.ToInt32(found[0]["LevelMax"]) : 0;

                        int maxLevelMaster = Convert.ToInt32(r["MaxLevel"] == DBNull.Value ? 0 : r["MaxLevel"]);
                        if (maxLevelMaster > 0 && levelMax > maxLevelMaster) levelMax = maxLevelMaster;

                        r["LevelMax"] = levelMax;
                        r["Allowed"] = false;
                    }
                    else
                    {
                        DataRow[] found = dtAl.Select("SkillID=" + skillId);
                        bool allowed = (found.Length > 0) && Convert.ToInt32(found[0]["Allowed"]) == 1;

                        r["Allowed"] = allowed;
                        r["LevelMax"] = 0;
                    }
                }

                _dtSkills.AcceptChanges();
                gvSkills.RefreshData();
            }
            catch
            {
                MessageBox.Show("Không load được kỹ năng của nhân viên!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveSkills_Click(object sender, EventArgs e)
        {
            if (!RequireAdmin()) return;

            if (string.IsNullOrWhiteSpace(_currentEmpCode))
            {
                MessageBox.Show("Vui lòng chọn tài khoản trước!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            EnsureUserHdr(conn, tran, _currentEmpCode);

                            foreach (DataRow r in _dtSkills.Rows)
                            {
                                int skillId = Convert.ToInt32(r["SkillID"]);
                                string type = Convert.ToString(r["SkillType"]);

                                if (type == "LEVEL")
                                {
                                    int maxLevelMaster = Convert.ToInt32(r["MaxLevel"] == DBNull.Value ? 0 : r["MaxLevel"]);
                                    int levelMax = 0;
                                    if (r["LevelMax"] != DBNull.Value)
                                        int.TryParse(r["LevelMax"].ToString(), out levelMax);

                                    if (levelMax < 0) levelMax = 0;
                                    if (maxLevelMaster > 0 && levelMax > maxLevelMaster) levelMax = maxLevelMaster;

                                    SaveLevelMax(conn, tran, _currentEmpCode, skillId, levelMax);
                                }
                                else
                                {
                                    bool allowed = false;
                                    if (r["Allowed"] != DBNull.Value)
                                        allowed = Convert.ToBoolean(r["Allowed"]);

                                    SaveAllow(conn, tran, _currentEmpCode, skillId, allowed);
                                }
                            }

                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Đã lưu kỹ năng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // reload to confirm
                LoadAllSkillsToGrid();
                LoadUserValuesToSkillGrid(_currentEmpCode);
            }
            catch
            {
                MessageBox.Show("Không lưu được kỹ năng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnsureUserHdr(SqlConnection conn, SqlTransaction tran, string empCode)
        {
            // lấy fullname từ account
            string fullname = empCode;
            using (SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 FULLNAME FROM dbo.TBL_ACCOUNT WHERE USER_ID=@U", conn, tran))
            {
                cmd.Parameters.AddWithValue("@U", empCode);
                object v = cmd.ExecuteScalar();
                if (v != null && v != DBNull.Value) fullname = v.ToString();
            }

            string sql = @"
IF NOT EXISTS (SELECT 1 FROM dbo.TBL_USER_SKILL_HDR WHERE EmpCode=@EmpCode)
BEGIN
    INSERT INTO dbo.TBL_USER_SKILL_HDR (EmpCode, FullName, Huy, CreateAt, CreateBy)
    VALUES (@EmpCode, @FullName, 0, GETDATE(), @User)
END
ELSE
BEGIN
    UPDATE dbo.TBL_USER_SKILL_HDR
    SET Huy=0, UpdateAt=GETDATE(), UpdateBy=@User
    WHERE EmpCode=@EmpCode
END";

            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.AddWithValue("@EmpCode", empCode);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.Parameters.AddWithValue("@User", (object)Constaint._userID ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        // LEVEL: passed 1..LevelMax, levels > LevelMax => Huy=1
        private void SaveLevelMax(SqlConnection conn, SqlTransaction tran, string empCode, int skillId, int levelMax)
        {
            string sqlHuy = @"
UPDATE dbo.TBL_USER_SKILL_LEVEL
SET Huy=1, UpdateAt=GETDATE(), UpdateBy=@User
WHERE EmpCode=@EmpCode AND SkillID=@SkillID
  AND (@LevelMax=0 OR LevelNo>@LevelMax);";

            using (SqlCommand cmd = new SqlCommand(sqlHuy, conn, tran))
            {
                cmd.Parameters.AddWithValue("@EmpCode", empCode);
                cmd.Parameters.AddWithValue("@SkillID", skillId);
                cmd.Parameters.AddWithValue("@LevelMax", levelMax);
                cmd.Parameters.AddWithValue("@User", (object)Constaint._userID ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }

            if (levelMax <= 0) return;

            string upsert = @"
IF EXISTS (SELECT 1 FROM dbo.TBL_USER_SKILL_LEVEL WHERE EmpCode=@EmpCode AND SkillID=@SkillID AND LevelNo=@LevelNo)
BEGIN
    UPDATE dbo.TBL_USER_SKILL_LEVEL
    SET IsPassed=1, Huy=0, UpdateAt=GETDATE(), UpdateBy=@User
    WHERE EmpCode=@EmpCode AND SkillID=@SkillID AND LevelNo=@LevelNo
END
ELSE
BEGIN
    INSERT INTO dbo.TBL_USER_SKILL_LEVEL (EmpCode, SkillID, LevelNo, IsPassed, Huy, CreateAt, CreateBy)
    VALUES (@EmpCode, @SkillID, @LevelNo, 1, 0, GETDATE(), @User)
END";

            for (int lv = 1; lv <= levelMax; lv++)
            {
                using (SqlCommand cmd = new SqlCommand(upsert, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@EmpCode", empCode);
                    cmd.Parameters.AddWithValue("@SkillID", skillId);
                    cmd.Parameters.AddWithValue("@LevelNo", lv);
                    cmd.Parameters.AddWithValue("@User", (object)Constaint._userID ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SaveAllow(SqlConnection conn, SqlTransaction tran, string empCode, int skillId, bool allowed)
        {
            string upsert = @"
IF EXISTS (SELECT 1 FROM dbo.TBL_USER_SKILL_ALLOW WHERE EmpCode=@EmpCode AND SkillID=@SkillID)
BEGIN
    UPDATE dbo.TBL_USER_SKILL_ALLOW
    SET IsAllowed=@IsAllowed, Huy=0, UpdateAt=GETDATE(), UpdateBy=@User
    WHERE EmpCode=@EmpCode AND SkillID=@SkillID
END
ELSE
BEGIN
    INSERT INTO dbo.TBL_USER_SKILL_ALLOW (EmpCode, SkillID, IsAllowed, Huy, CreateAt, CreateBy)
    VALUES (@EmpCode, @SkillID, @IsAllowed, 0, GETDATE(), @User)
END";

            using (SqlCommand cmd = new SqlCommand(upsert, conn, tran))
            {
                cmd.Parameters.AddWithValue("@EmpCode", empCode);
                cmd.Parameters.AddWithValue("@SkillID", skillId);
                cmd.Parameters.AddWithValue("@IsAllowed", allowed ? 1 : 0);
                cmd.Parameters.AddWithValue("@User", (object)Constaint._userID ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
