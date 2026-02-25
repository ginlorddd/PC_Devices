using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_USER_SKILL_LIST : XtraForm
    {
        private RepositoryItemCheckEdit _repoCheck;

        public FRM_USER_SKILL_LIST()
        {
            InitializeComponent();

            EnsureRepository();
            SetupGridOptions();
            BuildBandsAndColumns();

            // Load sau khi UI sẵn sàng
            Shown += (s, e) => BeginInvoke(new Action(LoadData));
        }

        private void FRM_USER_SKILL_LIST_Load(object sender, EventArgs e)
        {
            // đã load ở Shown
        }

        // =========================
        // Repo checkbox (an toàn)
        // =========================
        private void EnsureRepository()
        {
            _repoCheck = new RepositoryItemCheckEdit
            {
                AutoHeight = false,
                ValueChecked = true,
                ValueUnchecked = false,
                NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked,
                GlyphAlignment = HorzAlignment.Center
            };

            if (gcData != null)
                gcData.RepositoryItems.Add(_repoCheck);
        }

        private void SetupGridOptions()
        {
            gvData.BeginUpdate();
            try
            {
                gvData.OptionsView.ShowGroupPanel = false;
                gvData.OptionsView.ShowAutoFilterRow = true;
                gvData.OptionsView.ColumnHeaderAutoHeight = DefaultBoolean.True;

                gvData.OptionsBehavior.Editable = false;
                gvData.OptionsBehavior.ReadOnly = true;

                gvData.OptionsCustomization.AllowBandMoving = false;
                gvData.OptionsCustomization.AllowColumnMoving = false;

                gvData.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
                gvData.Appearance.BandPanel.TextOptions.VAlignment = VertAlignment.Center;
                gvData.Appearance.BandPanel.TextOptions.WordWrap = WordWrap.Wrap;

                gvData.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
                gvData.Appearance.HeaderPanel.TextOptions.VAlignment = VertAlignment.Center;
                gvData.Appearance.HeaderPanel.TextOptions.WordWrap = WordWrap.Wrap;

                gvData.CustomUnboundColumnData -= GvData_CustomUnboundColumnData;
                gvData.CustomUnboundColumnData += GvData_CustomUnboundColumnData;
            }
            finally
            {
                gvData.EndUpdate();
            }
        }

        // =========================
        // Build bands/columns (GIỮ NGUYÊN)
        // =========================
        private void BuildBandsAndColumns()
        {
            gvData.BeginUpdate();
            try
            {
                gvData.Bands.Clear();
                gvData.Columns.Clear();

                // ===== Band: Thông tin =====
                var bandInfo = NewBand("");
                bandInfo.Fixed = FixedStyle.Left;

                AddTextCol(bandInfo, "STT", "STT", 45, unbound: true);
                AddTextCol(bandInfo, "FullName", "Họ tên", 180);
                AddTextCol(bandInfo, "EmpCode", "Mã nhân viên", 110);
                AddTextCol(bandInfo, "Position", "Chức vụ", 120);
                AddTextCol(bandInfo, "FactoryName", "Nhà máy", 90);
                AddTextCol(bandInfo, "Certificate", "Chứng chỉ", 260);

                // ===== Band: Handlift =====
                var bandHandlift = NewBand("Kỹ năng sử dụng xe handlift");
                AddSkillCol(bandHandlift, "HandliftL1", "Level 1");
                AddSkillCol(bandHandlift, "HandliftL2", "Level 2");
                AddSkillCol(bandHandlift, "HandliftL3", "Level 3");
                AddSkillCol(bandHandlift, "HandliftL4", "Level 4");

                // ===== Band: EL Handlift =====
                var bandEL = NewBand("Kỹ năng sử dụng xe EL handlift");
                AddSkillCol(bandEL, "ELHandliftL1", "Level 1");
                AddSkillCol(bandEL, "ELHandliftL2", "Level 2");
                AddSkillCol(bandEL, "ELHandliftL3", "Level 3");
                AddSkillCol(bandEL, "ELHandliftL4", "Level 4");

                // ===== Band: Thiết bị được phép sử dụng =====
                var bandDevice = NewBand("Thiết bị được phép sử dụng");
                AddSkillCol(bandDevice, "AllowCut", "Máy cắt", 85);
                AddSkillCol(bandDevice, "AllowDrill", "Máy khoan", 85);
                AddSkillCol(bandDevice, "AllowGrind", "Kính", 70);

                // ===== Band: Cấp thẻ an toàn =====
                var bandCard = NewBand("");
                AddTextCol(bandCard, "SafetyCardStatus", "Cấp thẻ an toàn", 150);

                gvData.Bands.AddRange(new GridBand[]
                {
                    bandInfo, bandHandlift, bandEL, bandDevice, bandCard
                });
            }
            finally
            {
                gvData.EndUpdate();
            }
        }

        private GridBand NewBand(string caption)
            => new GridBand { Caption = caption, VisibleIndex = -1 };

        private BandedGridColumn AddTextCol(GridBand band, string fieldName, string caption, int width, bool unbound = false)
        {
            var col = new BandedGridColumn
            {
                FieldName = fieldName,
                Caption = caption,
                Visible = true,
                Width = width,
                MinWidth = width
            };

            if (unbound)
            {
                col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                col.OptionsColumn.AllowEdit = false;
                col.OptionsColumn.ReadOnly = true;
            }

            gvData.Columns.Add(col);
            band.Columns.Add(col);
            return col;
        }

        private BandedGridColumn AddSkillCol(GridBand band, string fieldName, string caption, int width = 70)
        {
            var col = new BandedGridColumn
            {
                FieldName = fieldName,
                Caption = caption,
                Visible = true,
                Width = width,
                MinWidth = width,
                ColumnEdit = _repoCheck
            };

            col.OptionsColumn.AllowEdit = false;
            col.OptionsColumn.ReadOnly = true;

            gvData.Columns.Add(col);
            band.Columns.Add(col);
            return col;
        }

        // =========================
        // LoadData theo schema mới
        // =========================
        private void LoadData()
        {
            try
            {
                // NOTE:
                // - LEVEL lấy theo SkillCode: HANDLIFT, EL_HANDLIFT
                // - BOOLEAN lấy theo SkillCode: CUT, DRILL, GRIND
                // - Nếu bạn đổi SkillCode thì sửa đúng ở đây

                string sql = @"
SELECT
    H.ID,
    H.FullName,
    H.EmpCode,
    A.Position,
    A.FactoryName,
    H.Certificate,

    -- Handlift L1..L4
    CAST(ISNULL(Lv.HandliftL1, 0) AS bit) AS HandliftL1,
    CAST(ISNULL(Lv.HandliftL2, 0) AS bit) AS HandliftL2,
    CAST(ISNULL(Lv.HandliftL3, 0) AS bit) AS HandliftL3,
    CAST(ISNULL(Lv.HandliftL4, 0) AS bit) AS HandliftL4,

    -- EL Handlift L1..L4
    CAST(ISNULL(Lv.ELHandliftL1, 0) AS bit) AS ELHandliftL1,
    CAST(ISNULL(Lv.ELHandliftL2, 0) AS bit) AS ELHandliftL2,
    CAST(ISNULL(Lv.ELHandliftL3, 0) AS bit) AS ELHandliftL3,
    CAST(ISNULL(Lv.ELHandliftL4, 0) AS bit) AS ELHandliftL4,

    -- Allow
    CAST(ISNULL(Al.AllowCut,   0) AS bit) AS AllowCut,
    CAST(ISNULL(Al.AllowDrill, 0) AS bit) AS AllowDrill,
    CAST(ISNULL(Al.AllowGrind, 0) AS bit) AS AllowGrind,

    H.SafetyCardStatus
FROM dbo.TBL_USER_SKILL_HDR H
LEFT JOIN dbo.TBL_ACCOUNT A
    ON A.USER_ID = H.EmpCode

-- Pivot LEVEL
LEFT JOIN
(
    SELECT
        UL.EmpCode,
        MAX(CASE WHEN SM.SkillCode = N'HANDLIFT'    AND UL.LevelNo = 1 AND ISNULL(UL.Huy,0)=0 AND UL.IsPassed=1 THEN 1 ELSE 0 END) AS HandliftL1,
        MAX(CASE WHEN SM.SkillCode = N'HANDLIFT'    AND UL.LevelNo = 2 AND ISNULL(UL.Huy,0)=0 AND UL.IsPassed=1 THEN 1 ELSE 0 END) AS HandliftL2,
        MAX(CASE WHEN SM.SkillCode = N'HANDLIFT'    AND UL.LevelNo = 3 AND ISNULL(UL.Huy,0)=0 AND UL.IsPassed=1 THEN 1 ELSE 0 END) AS HandliftL3,
        MAX(CASE WHEN SM.SkillCode = N'HANDLIFT'    AND UL.LevelNo = 4 AND ISNULL(UL.Huy,0)=0 AND UL.IsPassed=1 THEN 1 ELSE 0 END) AS HandliftL4,

        MAX(CASE WHEN SM.SkillCode = N'EL_HANDLIFT' AND UL.LevelNo = 1 AND ISNULL(UL.Huy,0)=0 AND UL.IsPassed=1 THEN 1 ELSE 0 END) AS ELHandliftL1,
        MAX(CASE WHEN SM.SkillCode = N'EL_HANDLIFT' AND UL.LevelNo = 2 AND ISNULL(UL.Huy,0)=0 AND UL.IsPassed=1 THEN 1 ELSE 0 END) AS ELHandliftL2,
        MAX(CASE WHEN SM.SkillCode = N'EL_HANDLIFT' AND UL.LevelNo = 3 AND ISNULL(UL.Huy,0)=0 AND UL.IsPassed=1 THEN 1 ELSE 0 END) AS ELHandliftL3,
        MAX(CASE WHEN SM.SkillCode = N'EL_HANDLIFT' AND UL.LevelNo = 4 AND ISNULL(UL.Huy,0)=0 AND UL.IsPassed=1 THEN 1 ELSE 0 END) AS ELHandliftL4
    FROM dbo.TBL_USER_SKILL_LEVEL UL
    INNER JOIN dbo.TBL_SKILL_MST SM
        ON SM.SkillID = UL.SkillID
    GROUP BY UL.EmpCode
) Lv
    ON Lv.EmpCode = H.EmpCode

-- Pivot ALLOW
LEFT JOIN
(
    SELECT
        UA.EmpCode,
        MAX(CASE WHEN SM.SkillCode = N'CUT'   AND ISNULL(UA.Huy,0)=0 AND UA.IsAllowed=1 THEN 1 ELSE 0 END) AS AllowCut,
        MAX(CASE WHEN SM.SkillCode = N'DRILL' AND ISNULL(UA.Huy,0)=0 AND UA.IsAllowed=1 THEN 1 ELSE 0 END) AS AllowDrill,
        MAX(CASE WHEN SM.SkillCode = N'GRIND' AND ISNULL(UA.Huy,0)=0 AND UA.IsAllowed=1 THEN 1 ELSE 0 END) AS AllowGrind
    FROM dbo.TBL_USER_SKILL_ALLOW UA
    INNER JOIN dbo.TBL_SKILL_MST SM
        ON SM.SkillID = UA.SkillID
    GROUP BY UA.EmpCode
) Al
    ON Al.EmpCode = H.EmpCode

WHERE ISNULL(H.Huy,0) = 0
ORDER BY H.FullName;
";

                DataTable dt = DBUtils._getData(sql) ?? new DataTable();

                gvData.BeginDataUpdate();
                try
                {
                    gcData.DataSource = dt;
                }
                finally
                {
                    gvData.EndDataUpdate();
                }

                gvData.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi LoadData:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // STT unbound
        private void GvData_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "STT" && e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }

        // =========================
        // Buttons
        // =========================
        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Constaint._exportGridViewXlsx(gvData, gcData);
            }
            catch
            {
                XtraMessageBox.Show("Chưa cấu hình hàm ExportExcel trong Constaint.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e) => Close();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvData.FocusedRowHandle < 0) return;

                string empCode = Convert.ToString(gvData.GetRowCellValue(gvData.FocusedRowHandle, "EmpCode"));
                if (string.IsNullOrWhiteSpace(empCode)) return;

                if (XtraMessageBox.Show($"Xóa kỹ năng của nhân viên [{empCode}]?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();

                    // set Huy ở header
                    using (SqlCommand cmd = new SqlCommand(@"UPDATE dbo.TBL_USER_SKILL_HDR SET Huy=1, UpdateAt=GETDATE(), UpdateBy=@u WHERE EmpCode=@e", conn))
                    {
                        cmd.Parameters.AddWithValue("@e", empCode);
                        cmd.Parameters.AddWithValue("@u", (object)Constaint._userID ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }

                    // set Huy ở detail (khuyến nghị để sạch)
                    using (SqlCommand cmd = new SqlCommand(@"UPDATE dbo.TBL_USER_SKILL_LEVEL SET Huy=1, UpdateAt=GETDATE(), UpdateBy=@u WHERE EmpCode=@e", conn))
                    {
                        cmd.Parameters.AddWithValue("@e", empCode);
                        cmd.Parameters.AddWithValue("@u", (object)Constaint._userID ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(@"UPDATE dbo.TBL_USER_SKILL_ALLOW SET Huy=1, UpdateAt=GETDATE(), UpdateBy=@u WHERE EmpCode=@e", conn))
                    {
                        cmd.Parameters.AddWithValue("@e", empCode);
                        cmd.Parameters.AddWithValue("@u", (object)Constaint._userID ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi xóa:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Constaint._access != "1" && Constaint._access != "3")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var f = new FRM_ADD_USER_SKILL())
            {
                if (f.ShowDialog() == DialogResult.OK) LoadData();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
