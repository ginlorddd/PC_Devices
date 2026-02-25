using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_ADD_USER_SKILL : XtraForm
    {
        private RepositoryItemSpinEdit _repoSpinLevel;
        private RepositoryItemCheckEdit _repoCheckAllowed;

        private DataTable _dtSkills; // datasource grid
        private string _empCode = "";

        public FRM_ADD_USER_SKILL()
        {
            InitializeComponent();
        }

        private void FRM_ADD_USER_SKILL_Load(object sender, EventArgs e)
        {
            BuildRepositories();
            SetupGrid();
            LoadEmployees();
            InitSafetyCardCombo();

            LoadAllSkillsToGrid();   // load master list, chưa có emp -> show mặc định
        }

        // =========================================================
        // UI: Repo editors
        // =========================================================
        private void BuildRepositories()
        {
            _repoSpinLevel = new RepositoryItemSpinEdit
            {
                IsFloatValue = false,
                MinValue = 0,
                MaxValue = 20, // sẽ clamp theo MaxLevel của từng skill khi save
                Increment = 1
            };

            _repoCheckAllowed = new RepositoryItemCheckEdit
            {
                AllowGrayed = false, // ✅ không 3-state
                NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked,
                ValueChecked = true,
                ValueUnchecked = false
            };

            gcSkills.RepositoryItems.Add(_repoSpinLevel);
            gcSkills.RepositoryItems.Add(_repoCheckAllowed);
        }

        private void SetupGrid()
        {
            gvSkills.OptionsView.ShowGroupPanel = false;
            gvSkills.OptionsView.ShowAutoFilterRow = true;

            // ✅ Fix “click 3 lần”
            gvSkills.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            gvSkills.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvSkills.OptionsBehavior.Editable = true;

            gvSkills.ShowingEditor -= gvSkills_ShowingEditor;
            gvSkills.ShowingEditor += gvSkills_ShowingEditor;

            gvSkills.CellValueChanging -= gvSkills_CellValueChanging;
            gvSkills.CellValueChanging += gvSkills_CellValueChanging;

            // ✅ Highlight row theo SkillType
            gvSkills.RowStyle -= gvSkills_RowStyle;
            gvSkills.RowStyle += gvSkills_RowStyle;

            // ✅ Toggle checkbox ngay khi click vào cell (1 click)
            gvSkills.RowCellClick -= gvSkills_RowCellClick;
            gvSkills.RowCellClick += gvSkills_RowCellClick;
        }

        private void InitSafetyCardCombo()
        {
            // YÊU CẦU: bạn phải có control cboSafetyCardStatus (ComboBoxEdit) trong Designer
            try
            {
                cboSafetyCardStatus.Properties.Items.Clear();
                cboSafetyCardStatus.Properties.Items.Add("Được cấp phép");
                cboSafetyCardStatus.Properties.Items.Add("Chưa cấp phép");
                cboSafetyCardStatus.Properties.Items.Add("Đang chờ");
                cboSafetyCardStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

                // default
                cboSafetyCardStatus.EditValue = "Chưa cấp phép";
            }
            catch { }
        }

        private void gvSkills_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            string type = Convert.ToString(gvSkills.GetRowCellValue(e.RowHandle, "SkillType"));

            if (type == "LEVEL")
            {
                e.Appearance.BackColor = System.Drawing.Color.AliceBlue;   // xanh nhạt
                e.Appearance.ForeColor = System.Drawing.Color.Black;
                e.HighPriority = true;
            }
            else if (type == "BOOLEAN")
            {
                e.Appearance.BackColor = System.Drawing.Color.LemonChiffon; // vàng nhạt
                e.Appearance.ForeColor = System.Drawing.Color.Black;
                e.HighPriority = true;
            }
        }

        private void gvSkills_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            // Chỉ xử lý cột Allowed (BOOLEAN)
            if (e.Column.FieldName != "Allowed") return;

            string type = Convert.ToString(gvSkills.GetRowCellValue(e.RowHandle, "SkillType"));
            if (type != "BOOLEAN") return;

            bool cur = false;
            object v = gvSkills.GetRowCellValue(e.RowHandle, "Allowed");
            if (v != null && v != DBNull.Value) cur = Convert.ToBoolean(v);

            gvSkills.SetRowCellValue(e.RowHandle, "Allowed", !cur);
        }

        // Chặn edit theo SkillType
        private void gvSkills_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (gvSkills.FocusedRowHandle < 0) return;

                string type = Convert.ToString(gvSkills.GetFocusedRowCellValue("SkillType"));
                string field = gvSkills.FocusedColumn.FieldName;

                if (type == "LEVEL" && field == "Allowed")
                {
                    e.Cancel = true; // LEVEL không sửa Allowed
                    return;
                }
                if (type == "BOOLEAN" && field == "LevelMax")
                {
                    e.Cancel = true; // BOOLEAN không sửa LevelMax
                    return;
                }
            }
            catch { }
        }

        // Auto: nếu user nhập LevelMax âm/null => clamp
        private void gvSkills_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName != "LevelMax") return;

            try
            {
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
            catch { }
        }

        // =========================================================
        // Load employees (tbl_account)
        // =========================================================
        private void LoadEmployees()
        {
            string sql = @"SELECT USER_ID, FULLNAME FROM dbo.TBL_ACCOUNT ORDER BY FULLNAME";
            DataTable dt = DBUtils._getData(sql);

            gluEmp.Properties.DataSource = dt;
            gluEmp.Properties.DisplayMember = "FULLNAME";
            gluEmp.Properties.ValueMember = "USER_ID";
            gluEmp.Properties.NullText = "";

            gvEmpPopup.Columns.Clear();
            gvEmpPopup.Columns.AddVisible("USER_ID", "EmpCode");
            gvEmpPopup.Columns.AddVisible("FULLNAME", "Họ tên");
            gvEmpPopup.BestFitColumns();
        }

        private void gluEmp_EditValueChanged(object sender, EventArgs e)
        {
            _empCode = (gluEmp.EditValue == null) ? "" : gluEmp.EditValue.ToString().Trim();

            LoadAllSkillsToGrid();       // reload master
            ClearHdrFields();

            if (!string.IsNullOrWhiteSpace(_empCode))
            {
                LoadUserValuesToGrid(_empCode); // merge current values
                LoadHdrFields(_empCode);        // ✅ load Certificate + SafetyCardStatus
            }
        }

        private void ClearHdrFields()
        {
            try
            {
                txtCertificate.Text = "";
                cboSafetyCardStatus.EditValue = "Chưa cấp phép";
            }
            catch { }
        }

        // =========================================================
        // Load HDR fields (Certificate + SafetyCardStatus)
        // =========================================================
        private void LoadHdrFields(string empCode)
        {
            try
            {
                string sql = @"
SELECT TOP 1 
    Certificate,
    SafetyCardStatus
FROM dbo.TBL_USER_SKILL_HDR
WHERE EmpCode = @EmpCode AND ISNULL(Huy,0)=0
ORDER BY ISNULL(UpdateAt, CreateAt) DESC;
";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@EmpCode", empCode);

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            try
                            {
                                txtCertificate.Text = rd["Certificate"] == DBNull.Value ? "" : rd["Certificate"].ToString();
                            }
                            catch { }

                            try
                            {
                                string st = rd["SafetyCardStatus"] == DBNull.Value ? "" : rd["SafetyCardStatus"].ToString();
                                if (!string.IsNullOrWhiteSpace(st))
                                    cboSafetyCardStatus.EditValue = st;
                            }
                            catch { }
                        }
                    }
                }
            }
            catch
            {
                // Không show lỗi chi tiết theo yêu cầu bạn
            }
        }

        // =========================================================
        // Load skill master -> grid table
        // =========================================================
        private void LoadAllSkillsToGrid()
        {
            // Lấy MaxLevel cho skill LEVEL để clamp
            string sql = @"
SELECT 
    SM.SkillID,
    SM.SkillCode,
    SM.SkillName,
    SM.SkillType,
    ISNULL((
        SELECT MAX(LevelNo) FROM dbo.TBL_SKILL_LEVEL_MST L
        WHERE L.SkillID = SM.SkillID AND ISNULL(L.IsActive,1)=1
    ), 0) AS MaxLevel
FROM dbo.TBL_SKILL_MST SM
WHERE ISNULL(SM.IsActive,1)=1
ORDER BY ISNULL(SM.SortOrder,999), SM.SkillName;
";

            _dtSkills = DBUtils._getData(sql) ?? new DataTable();

            // Add editable columns
            if (!_dtSkills.Columns.Contains("LevelMax"))
                _dtSkills.Columns.Add("LevelMax", typeof(int));
            if (!_dtSkills.Columns.Contains("Allowed"))
                _dtSkills.Columns.Add("Allowed", typeof(bool));

            // default values
            foreach (DataRow r in _dtSkills.Rows)
            {
                string type = Convert.ToString(r["SkillType"]);
                int maxLevel = Convert.ToInt32(r["MaxLevel"] == DBNull.Value ? 0 : r["MaxLevel"]);

                if (type == "LEVEL")
                {
                    r["LevelMax"] = 0;
                    r["Allowed"] = false;
                    if (maxLevel <= 0) r["LevelMax"] = 0;
                }
                else // BOOLEAN
                {
                    r["LevelMax"] = 0;
                    r["Allowed"] = false;
                }
            }

            gcSkills.DataSource = _dtSkills;
            BuildGridColumns();
        }

        private void BuildGridColumns()
        {
            gvSkills.Columns.Clear();
            gvSkills.PopulateColumns();

            // Ẩn kỹ thuật
            if (gvSkills.Columns["SkillID"] != null) gvSkills.Columns["SkillID"].Visible = false;
            if (gvSkills.Columns["SkillCode"] != null) gvSkills.Columns["SkillCode"].Visible = false;
            if (gvSkills.Columns["MaxLevel"] != null) gvSkills.Columns["MaxLevel"].Visible = false;
            if (gvSkills.Columns["SkillType"] != null) gvSkills.Columns["SkillType"].Visible = false;

            // Caption
            gvSkills.Columns["SkillName"].Caption = "Kỹ năng";
            gvSkills.Columns["LevelMax"].Caption = "Level đạt (0..n)";
            gvSkills.Columns["Allowed"].Caption = "Được phép";

            // Editors
            gvSkills.Columns["LevelMax"].ColumnEdit = _repoSpinLevel;
            gvSkills.Columns["Allowed"].ColumnEdit = _repoCheckAllowed;

            // Readonly cột master
            gvSkills.Columns["SkillName"].OptionsColumn.AllowEdit = false;

            gvSkills.BestFitColumns();
        }

        // =========================================================
        // Load user current values -> merge into _dtSkills
        // =========================================================
        private void LoadUserValuesToGrid(string empCode)
        {
            try
            {
                // 1) LEVEL: lấy max level đã passed
                string sqlLevel = @"
SELECT 
    UL.SkillID,
    MAX(UL.LevelNo) AS LevelMax
FROM dbo.TBL_USER_SKILL_LEVEL UL
WHERE UL.EmpCode = @EmpCode
  AND ISNULL(UL.Huy,0)=0
  AND ISNULL(UL.IsPassed,0)=1
GROUP BY UL.SkillID;
";

                // 2) ALLOW:
                string sqlAllow = @"
SELECT 
    UA.SkillID,
    MAX(CASE WHEN ISNULL(UA.Huy,0)=0 AND ISNULL(UA.IsAllowed,0)=1 THEN 1 ELSE 0 END) AS Allowed
FROM dbo.TBL_USER_SKILL_ALLOW UA
WHERE UA.EmpCode = @EmpCode
GROUP BY UA.SkillID;
";

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

                // merge
                foreach (DataRow r in _dtSkills.Rows)
                {
                    int skillId = Convert.ToInt32(r["SkillID"]);
                    string type = Convert.ToString(r["SkillType"]);

                    if (type == "LEVEL")
                    {
                        DataRow[] found = dtLv.Select("SkillID=" + skillId);
                        int levelMax = (found.Length > 0) ? Convert.ToInt32(found[0]["LevelMax"]) : 0;

                        int maxLevel = Convert.ToInt32(r["MaxLevel"] == DBNull.Value ? 0 : r["MaxLevel"]);
                        if (maxLevel > 0 && levelMax > maxLevel) levelMax = maxLevel;

                        r["LevelMax"] = levelMax;
                        r["Allowed"] = false;
                    }
                    else // BOOLEAN
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
                MessageBox.Show("Không load được kỹ năng hiện tại của nhân viên!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // Ensure HDR exists (EmpCode = account.USER_ID)
        // + thêm Certificate + SafetyCardStatus
        // =========================================================
        private void EnsureUserHdr(SqlConnection conn, SqlTransaction tran, string empCode)
        {
            string sqlFullname = @"SELECT TOP 1 FULLNAME FROM dbo.TBL_ACCOUNT WHERE USER_ID=@EmpCode";
            string fullname = empCode;

            using (SqlCommand cmd = new SqlCommand(sqlFullname, conn, tran))
            {
                cmd.Parameters.AddWithValue("@EmpCode", empCode);
                object v = cmd.ExecuteScalar();
                if (v != null && v != DBNull.Value) fullname = v.ToString();
            }

            string certificate = "";
            string safetyStatus = "Chưa cấp phép";

            try { certificate = (txtCertificate == null) ? "" : (txtCertificate.Text ?? "").Trim(); } catch { }
            try
            {
                safetyStatus = (cboSafetyCardStatus == null || cboSafetyCardStatus.EditValue == null)
                    ? "Chưa cấp phép"
                    : cboSafetyCardStatus.EditValue.ToString().Trim();
            }
            catch { }

            string sqlUpsertHdr = @"
IF NOT EXISTS (SELECT 1 FROM dbo.TBL_USER_SKILL_HDR WHERE EmpCode=@EmpCode)
BEGIN
    INSERT INTO dbo.TBL_USER_SKILL_HDR 
        (EmpCode, FullName, Certificate, SafetyCardStatus, Huy, CreateAt, CreateBy)
    VALUES 
        (@EmpCode, @FullName, @Certificate, @SafetyCardStatus, 0, GETDATE(), @User)
END
ELSE
BEGIN
    UPDATE dbo.TBL_USER_SKILL_HDR
    SET FullName=@FullName,
        Certificate=@Certificate,
        SafetyCardStatus=@SafetyCardStatus,
        Huy=0,
        UpdateAt=GETDATE(),
        UpdateBy=@User
    WHERE EmpCode=@EmpCode
END
";

            using (SqlCommand cmd = new SqlCommand(sqlUpsertHdr, conn, tran))
            {
                cmd.Parameters.AddWithValue("@EmpCode", empCode);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.Parameters.AddWithValue("@Certificate",
    string.IsNullOrWhiteSpace(certificate) ? (object)DBNull.Value : (object)certificate);

                cmd.Parameters.AddWithValue("@SafetyCardStatus",
                    string.IsNullOrWhiteSpace(safetyStatus) ? (object)DBNull.Value : (object)safetyStatus);


                cmd.Parameters.AddWithValue("@User", (object)Constaint._userID ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        // =========================================================
        // SAVE
        // =========================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (gluEmp.EditValue == null || string.IsNullOrWhiteSpace(gluEmp.EditValue.ToString()))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string empCode = gluEmp.EditValue.ToString().Trim();
                if (string.IsNullOrWhiteSpace(empCode))
                {
                    MessageBox.Show("EmpCode không hợp lệ!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // ✅ lưu cả Certificate + SafetyCardStatus vào HDR
                            EnsureUserHdr(conn, tran, empCode);

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

                                    SaveLevelMax(conn, tran, empCode, skillId, levelMax);
                                }
                                else // BOOLEAN
                                {
                                    bool allowed = false;
                                    if (r["Allowed"] != DBNull.Value)
                                        allowed = Convert.ToBoolean(r["Allowed"]);

                                    SaveAllow(conn, tran, empCode, skillId, allowed);
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

                MessageBox.Show("Lưu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Không lưu được dữ liệu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // LEVEL: LevelMax => passed levels 1..LevelMax, levels > LevelMax => Huy=1
        private void SaveLevelMax(SqlConnection conn, SqlTransaction tran, string empCode, int skillId, int levelMax)
        {
            // 1) Hủy hết level > levelMax (hoặc hủy tất cả nếu levelMax=0)
            string sqlHuy = @"
UPDATE dbo.TBL_USER_SKILL_LEVEL
SET Huy=1,
    UpdateAt=GETDATE(),
    UpdateBy=@User
WHERE EmpCode=@EmpCode
  AND SkillID=@SkillID
  AND (
        @LevelMax = 0
        OR LevelNo > @LevelMax
      );
";
            using (SqlCommand cmd = new SqlCommand(sqlHuy, conn, tran))
            {
                cmd.Parameters.AddWithValue("@EmpCode", empCode);
                cmd.Parameters.AddWithValue("@SkillID", skillId);
                cmd.Parameters.AddWithValue("@LevelMax", levelMax);
                cmd.Parameters.AddWithValue("@User", (object)Constaint._userID ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }

            if (levelMax <= 0) return;

            // 2) Upsert L1..LevelMax
            string sqlUpsert = @"
IF EXISTS (SELECT 1 FROM dbo.TBL_USER_SKILL_LEVEL WHERE EmpCode=@EmpCode AND SkillID=@SkillID AND LevelNo=@LevelNo)
BEGIN
    UPDATE dbo.TBL_USER_SKILL_LEVEL
    SET IsPassed=1,
        Huy=0,
        UpdateAt=GETDATE(),
        UpdateBy=@User
    WHERE EmpCode=@EmpCode AND SkillID=@SkillID AND LevelNo=@LevelNo
END
ELSE
BEGIN
    INSERT INTO dbo.TBL_USER_SKILL_LEVEL
        (EmpCode, SkillID, LevelNo, IsPassed, Huy, CreateAt, CreateBy)
    VALUES
        (@EmpCode, @SkillID, @LevelNo, 1, 0, GETDATE(), @User)
END
";

            for (int lv = 1; lv <= levelMax; lv++)
            {
                using (SqlCommand cmd = new SqlCommand(sqlUpsert, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@EmpCode", empCode);
                    cmd.Parameters.AddWithValue("@SkillID", skillId);
                    cmd.Parameters.AddWithValue("@LevelNo", lv);
                    cmd.Parameters.AddWithValue("@User", (object)Constaint._userID ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // BOOLEAN: upsert allowed
        private void SaveAllow(SqlConnection conn, SqlTransaction tran, string empCode, int skillId, bool allowed)
        {
            string sqlUpsert = @"
IF EXISTS (SELECT 1 FROM dbo.TBL_USER_SKILL_ALLOW WHERE EmpCode=@EmpCode AND SkillID=@SkillID)
BEGIN
    UPDATE dbo.TBL_USER_SKILL_ALLOW
    SET IsAllowed=@IsAllowed,
        Huy=0,
        UpdateAt=GETDATE(),
        UpdateBy=@User
    WHERE EmpCode=@EmpCode AND SkillID=@SkillID
END
ELSE
BEGIN
    INSERT INTO dbo.TBL_USER_SKILL_ALLOW
        (EmpCode, SkillID, IsAllowed, Huy, CreateAt, CreateBy)
    VALUES
        (@EmpCode, @SkillID, @IsAllowed, 0, GETDATE(), @User)
END
";

            using (SqlCommand cmd = new SqlCommand(sqlUpsert, conn, tran))
            {
                cmd.Parameters.AddWithValue("@EmpCode", empCode);
                cmd.Parameters.AddWithValue("@SkillID", skillId);
                cmd.Parameters.AddWithValue("@IsAllowed", allowed ? 1 : 0);
                cmd.Parameters.AddWithValue("@User", (object)Constaint._userID ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
