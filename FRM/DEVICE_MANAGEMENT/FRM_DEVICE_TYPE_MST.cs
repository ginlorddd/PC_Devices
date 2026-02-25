using DevExpress.XtraEditors;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_DEVICE_TYPE_MST : XtraForm
    {
        private DataTable _dt = new DataTable();
        private int? _typeId = null;
        private string _pickedHdsdFullPath = "";
        private string _pickedBcdtFullPath = "";

        public FRM_DEVICE_TYPE_MST()
        {
            InitializeComponent();
        }

        // ======================================================
        // LOAD
        // ======================================================
        private void FRM_DEVICE_TYPE_MST_Load(object sender, EventArgs e)
        {
            LoadData();
            SetupGridCaption();
            ClearForm();
            UpdateModeUI();
            this.gvData.CustomUnboundColumnData += gvData_CustomUnboundColumnData;

        }

        private void UpdateModeUI()
        {
            bool isInsert = (_typeId == null);

            lblMode.Text = isInsert ? "Chế độ: THÊM MỚI (INSERT)" : $"Chế độ: CẬP NHẬT (UPDATE)";
            btnSave.Text = isInsert ? "Thêm" : "Lưu";

            // (tuỳ bạn) đổi icon/enable delete
            btnDelete.Enabled = !isInsert;
        }


        // ======================================================
        // LOAD DATA
        // ======================================================
        private void LoadData()
        {
            try
            {
                bool hasHdsd = HasColumn("TBL_DEVICE_TYPE", "HuongDanSuDung");
                bool hasBcdt = HasColumn("TBL_DEVICE_TYPE", "BaoCaoDaoTao");
                bool hasHuy = HasColumn("TBL_DEVICE_TYPE", "Huy");

                string sql = "SELECT TypeID, [Type], TypeShort";

                if (hasHdsd) sql += ", HuongDanSuDung";
                if (hasBcdt) sql += ", BaoCaoDaoTao";
                if (hasHuy) sql += ", Huy";

                sql += " FROM dbo.TBL_DEVICE_TYPE";

                if (hasHuy)
                    sql += " WHERE ISNULL(Huy,0) = 0";

                sql += " ORDER BY TypeID DESC";

                _dt = DBUtils._getData(sql) ?? new DataTable();
                gcData.DataSource = _dt;

                gvData.OptionsBehavior.Editable = false;
                gvData.OptionsSelection.EnableAppearanceFocusedCell = false;
                gvData.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadData:\n" + ex.Message);
            }
        }

        private void gvData_CustomUnboundColumnData(
    object sender,
    DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "STT" && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }


        private void SetupGridCaption()
        {
            if (gvData.Columns["STT"] == null)
            {
                var colStt = gvData.Columns.AddField("STT");
                colStt.Caption = "STT";
                colStt.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                colStt.OptionsColumn.AllowEdit = false;
                colStt.OptionsColumn.AllowFocus = false;
                colStt.Visible = true;
                colStt.VisibleIndex = 0;   // cột đầu tiên
                colStt.Width = 50;
            }

            if (gvData.Columns["TypeID"] != null)
            {
                gvData.Columns["TypeID"].Caption = "ID";
                gvData.Columns["TypeID"].Width = 60;
                gvData.Columns["TypeID"].Visible = false;
            }

            if (gvData.Columns["Type"] != null)
                gvData.Columns["Type"].Caption = "Tên loại";

            if (gvData.Columns["TypeShort"] != null)
            {
                gvData.Columns["TypeShort"].Caption = "Mã ngắn";
                gvData.Columns["TypeShort"].Width = 90;
            }

            if (gvData.Columns["HuongDanSuDung"] != null)
                gvData.Columns["HuongDanSuDung"].Caption = "File HDSD";

            if (gvData.Columns["BaoCaoDaoTao"] != null)
                gvData.Columns["BaoCaoDaoTao"].Caption = "File BCDT";

            if (gvData.Columns["Huy"] != null)
                gvData.Columns["Huy"].Visible = false;
        }

        // ======================================================
        // GRID SELECT -> FILL FORM
        // ======================================================
        private void gvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            FillFromGrid();
        }

        private void FillFromGrid()
        {
            try
            {
                if (gvData.FocusedRowHandle < 0) return;

                object idObj = gvData.GetFocusedRowCellValue("TypeID");
                _typeId = (idObj == null || idObj == DBNull.Value) ? null : (int?)Convert.ToInt32(idObj);

                txtType.Text = gvData.GetFocusedRowCellValue("Type")?.ToString() ?? "";
                txtTypeShort.Text = gvData.GetFocusedRowCellValue("TypeShort")?.ToString() ?? "";

                if (gvData.Columns["HuongDanSuDung"] != null)
                    txtHDSD.Text = gvData.GetFocusedRowCellValue("HuongDanSuDung")?.ToString() ?? "";
                else
                    txtHDSD.Text = "";

                if (gvData.Columns["BaoCaoDaoTao"] != null)
                    txtBCDT.Text = gvData.GetFocusedRowCellValue("BaoCaoDaoTao")?.ToString() ?? "";
                else
                    txtBCDT.Text = "";

                // memoNote: không ghi DB (vì DB không chắc có cột Note), để trống cho khỏi gây lỗi
                memoNote.Text = "";

                UpdateModeUI();
            }
            catch
            {
                // không show lỗi chi tiết
            }
        }

        // ======================================================
        // SEARCH
        // ======================================================
        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_dt == null) return;
                string key = (txtSearch.Text ?? "").Trim().Replace("'", "''");

                DataView dv = _dt.DefaultView;
                if (string.IsNullOrWhiteSpace(key))
                {
                    dv.RowFilter = "";
                }
                else
                {
                    // Lọc theo Type / TypeShort / HuongDanSuDung / BaoCaoDaoTao
                    string filter = $"[Type] LIKE '%{key}%' OR TypeShort LIKE '%{key}%'";
                    if (_dt.Columns.Contains("HuongDanSuDung"))
                        filter += $" OR HuongDanSuDung LIKE '%{key}%'";
                    if (_dt.Columns.Contains("BaoCaoDaoTao"))
                        filter += $" OR BaoCaoDaoTao LIKE '%{key}%'";
                    dv.RowFilter = filter;
                }
            }
            catch
            {
                // ignore
            }
        }

        // ======================================================
        // BUTTON: NEW
        // ======================================================
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            UpdateModeUI();
            txtType.Focus();
        }

        private void ClearForm()
        {
            _typeId = null;
            txtType.Text = "";
            txtTypeShort.Text = "";
            txtHDSD.Text = "";
            txtBCDT.Text = "";
            memoNote.Text = "";
        }

        // ======================================================
        // CHOOSE FILES
        // ======================================================
        private void btnChooseHDSD_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "PDF Files|*.pdf";
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _pickedHdsdFullPath = dlg.FileName;
                txtHDSD.Text = Path.GetFileName(dlg.FileName); // để user nhìn
            }
        }

        private void btnChooseBCDT_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "PDF Files|*.pdf";
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _pickedBcdtFullPath = dlg.FileName;
                txtBCDT.Text = Path.GetFileName(dlg.FileName);
            }
        }


        // ======================================================
        // VALIDATE
        // ======================================================
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtType.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên loại (Type)!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtType.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTypeShort.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã ngắn (TypeShort)!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTypeShort.Focus();
                return false;
            }

            // (optional) ép TypeShort không có space
            txtTypeShort.Text = txtTypeShort.Text.Trim().Replace(" ", "");

            return true;
        }

        // ======================================================
        // BUTTON: SAVE (INSERT/UPDATE)
        // ======================================================
        private void btnSave_Click(object sender, EventArgs e)
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
            bool isInsert = (_typeId == null);
            lblMode.Text = isInsert ? "Đang lưu: INSERT..." : $"Đang lưu: UPDATE... (ID={_typeId})";

            if (!ValidateInput()) { UpdateModeUI(); return; }

            if (!ValidateInput()) return;

            string typeShort = txtTypeShort.Text.Trim().Replace(" ", "");
            string typeFolder = Path.Combine(Constaint._folderFileUpload, "DEVICE_TYPE", typeShort);

            if (!Directory.Exists(typeFolder))
                Directory.CreateDirectory(typeFolder);

            // Nếu user vừa chọn file mới thì copy vào folder chuẩn theo TypeShort
            // và đổi tên file theo chuẩn
            string finalHdsdFileName = txtHDSD.Text.Trim();
            string finalBcdtFileName = txtBCDT.Text.Trim();

            if (!string.IsNullOrWhiteSpace(_pickedHdsdFullPath) && File.Exists(_pickedHdsdFullPath))
            {
                finalHdsdFileName = $"{typeShort}_HDSD.pdf";
                string dest = Path.Combine(typeFolder, finalHdsdFileName);
                File.Copy(_pickedHdsdFullPath, dest, true);
            }

            if (!string.IsNullOrWhiteSpace(_pickedBcdtFullPath) && File.Exists(_pickedBcdtFullPath))
            {
                finalBcdtFileName = $"{typeShort}_BCDT.pdf";
                string dest = Path.Combine(typeFolder, finalBcdtFileName);
                File.Copy(_pickedBcdtFullPath, dest, true);
            }

            // cập nhật lại textbox theo tên file chuẩn (để lưu DB)
            txtHDSD.Text = finalHdsdFileName;
            txtBCDT.Text = finalBcdtFileName;


            try
            {
                bool hasHdsd = HasColumn("TBL_DEVICE_TYPE", "HuongDanSuDung");
                bool hasBcdt = HasColumn("TBL_DEVICE_TYPE", "BaoCaoDaoTao");

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();

                    if (_typeId == null)
                    {
                        // INSERT
                        string sql = "INSERT INTO dbo.TBL_DEVICE_TYPE ([Type], TypeShort";
                        if (hasHdsd) sql += ", HuongDanSuDung";
                        if (hasBcdt) sql += ", BaoCaoDaoTao";
                        sql += ") VALUES (@Type, @TypeShort";
                        if (hasHdsd) sql += ", @HDSD";
                        if (hasBcdt) sql += ", @BCDT";
                        sql += ");";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Type", txtType.Text.Trim());
                            cmd.Parameters.AddWithValue("@TypeShort", txtTypeShort.Text.Trim());

                            if (hasHdsd)
                                cmd.Parameters.AddWithValue("@HDSD", DbNullIfEmpty(txtHDSD.Text));
                            if (hasBcdt)
                                cmd.Parameters.AddWithValue("@BCDT", DbNullIfEmpty(txtBCDT.Text));

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Đã thêm loại thiết bị!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // UPDATE
                        string sql = "UPDATE dbo.TBL_DEVICE_TYPE SET [Type] = @Type, TypeShort = @TypeShort";
                        if (hasHdsd) sql += ", HuongDanSuDung = @HDSD";
                        if (hasBcdt) sql += ", BaoCaoDaoTao = @BCDT";
                        sql += " WHERE TypeID = @TypeID;";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Type", txtType.Text.Trim());
                            cmd.Parameters.AddWithValue("@TypeShort", txtTypeShort.Text.Trim());
                            cmd.Parameters.AddWithValue("@TypeID", _typeId.Value);

                            if (hasHdsd)
                                cmd.Parameters.AddWithValue("@HDSD", DbNullIfEmpty(txtHDSD.Text));
                            if (hasBcdt)
                                cmd.Parameters.AddWithValue("@BCDT", DbNullIfEmpty(txtBCDT.Text));

                            int affected = cmd.ExecuteNonQuery();
                            if (affected <= 0)
                            {
                                MessageBox.Show("Không lưu được (không tìm thấy TypeID).",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        MessageBox.Show("Đã cập nhật loại thiết bị!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadData();
                SetupGridCaption();
                ClearForm();          // đưa về insert mode
                UpdateModeUI();
            }
            catch
            {
                UpdateModeUI();
                MessageBox.Show("Không lưu được dữ liệu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================
        // BUTTON: DELETE
        // - Nếu có cột Huy: soft delete (Huy=1)
        // - Nếu không có: hard delete
        // ======================================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_typeId == null)
            {
                MessageBox.Show("Vui lòng chọn loại thiết bị cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn chắc chắn muốn xóa loại thiết bị này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                bool hasHuy = HasColumn("TBL_DEVICE_TYPE", "Huy");

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();

                    string sql;
                    if (hasHuy)
                        sql = "UPDATE dbo.TBL_DEVICE_TYPE SET Huy = 1 WHERE TypeID = @TypeID";
                    else
                        sql = "DELETE FROM dbo.TBL_DEVICE_TYPE WHERE TypeID = @TypeID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TypeID", _typeId.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadData();
                SetupGridCaption();
            }
            catch
            {
                MessageBox.Show("Không xóa được (có thể đang được sử dụng bởi thiết bị).",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================
        // BUTTON: REFRESH
        // ======================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            SetupGridCaption();
        }

        // ======================================================
        // BUTTON: CLOSE
        // ======================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ======================================================
        // HELPERS
        // ======================================================
        private object DbNullIfEmpty(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return DBNull.Value;
            return s.Trim();
        }

        private bool HasColumn(string tableName, string colName)
        {
            try
            {
                string sql = $@"
SELECT COUNT(*) AS Cnt
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = '{tableName}'
  AND COLUMN_NAME = '{colName}'";

                DataTable dt = DBUtils._getData(sql);
                if (dt == null || dt.Rows.Count == 0) return false;
                return Convert.ToInt32(dt.Rows[0]["Cnt"]) > 0;
            }
            catch
            {
                return false;
            }
        }

        private void btnApplyFilesToDevices_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Constaint._access != "1" && Constaint._access != "3")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_typeId == null)
            {
                MessageBox.Show("Vui lòng chọn 1 loại thiết bị để cập nhật file!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string typeShort = (txtTypeShort.Text ?? "").Trim().Replace(" ", "");
            if (string.IsNullOrWhiteSpace(typeShort))
            {
                MessageBox.Show("TypeShort đang rỗng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Folder file chuẩn của loại
            string typeFolder = Path.Combine(Constaint._folderFileUpload, "DEVICE_TYPE", typeShort);

            string srcHdsd = Path.Combine(typeFolder, $"{typeShort}_HDSD.pdf");
            string srcBcdt = Path.Combine(typeFolder, $"{typeShort}_BCDT.pdf");

            if (!File.Exists(srcHdsd) && !File.Exists(srcBcdt))
            {
                MessageBox.Show("Chưa có file HDSD/BCDT cho loại này trong folder chuẩn!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                "Bạn muốn cập nhật file HDSD/BCDT xuống TẤT CẢ thiết bị cùng loại này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                var rs = ApplyTypeFilesToAllDevices(_typeId.Value, typeShort, srcHdsd, srcBcdt);

                MessageBox.Show(
                    $"Đã cập nhật:\n- Thiết bị xử lý: {rs.Total}\n- Copy HDSD: {rs.CopiedHdsd}\n- Copy BCDT: {rs.CopiedBcdt}\n- DB updated: {rs.DbUpdatedRows}",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không cập nhật được file xuống thiết bị!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class ApplyFilesResult
        {
            public int Total { get; set; }
            public int CopiedHdsd { get; set; }
            public int CopiedBcdt { get; set; }
            public int DbUpdatedRows { get; set; }
        }

        private ApplyFilesResult ApplyTypeFilesToAllDevices(int typeId, string typeShort, string srcHdsd, string srcBcdt)
        {
            var result = new ApplyFilesResult();

            // 1) Lấy danh sách thiết bị theo TypeID
            DataTable dtDevices = new DataTable();

            using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
            {
                conn.Open();

                string sqlList = @"
SELECT MaQuanLy
FROM dbo.TBL_DEVICE_MST
WHERE ISNULL(Huy,0) = 0
  AND TypeID = @TypeID
  AND MaQuanLy IS NOT NULL
  AND LTRIM(RTRIM(MaQuanLy)) <> ''";

                using (SqlCommand cmd = new SqlCommand(sqlList, conn))
                {
                    cmd.Parameters.AddWithValue("@TypeID", typeId);
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(dtDevices);
                    }
                }

                result.Total = dtDevices.Rows.Count;

                // 2) Copy file xuống từng folder thiết bị
                foreach (DataRow r in dtDevices.Rows)
                {
                    string maQL = (r["MaQuanLy"] ?? "").ToString().Trim();
                    if (string.IsNullOrWhiteSpace(maQL)) continue;

                    string deviceFolder = Path.Combine(Constaint._folderFileUpload, maQL);
                    if (!Directory.Exists(deviceFolder))
                        Directory.CreateDirectory(deviceFolder);

                    // HDSD
                    if (File.Exists(srcHdsd))
                    {
                        string destHdsd = Path.Combine(deviceFolder, $"{maQL}_HDSD.pdf");
                        File.Copy(srcHdsd, destHdsd, true);
                        result.CopiedHdsd++;
                    }

                    // BCDT
                    if (File.Exists(srcBcdt))
                    {
                        string destBcdt = Path.Combine(deviceFolder, $"{maQL}_BCDT.pdf");
                        File.Copy(srcBcdt, destBcdt, true);
                        result.CopiedBcdt++;
                    }
                }

                // 3) Update DB hàng loạt: lưu theo chuẩn {MaQuanLy}_HDSD.pdf / {MaQuanLy}_BCDT.pdf
                // (chỉ set cột nào có file nguồn)
                string sqlUpdate = @"
UPDATE dbo.TBL_DEVICE_MST
SET
    HuongDanSuDung = CASE WHEN @HasHdsd = 1 THEN (MaQuanLy + '_HDSD.pdf') ELSE HuongDanSuDung END,
    BaoCaoDaoTao   = CASE WHEN @HasBcdt = 1 THEN (MaQuanLy + '_BCDT.pdf') ELSE BaoCaoDaoTao   END,
    UPDATE_DATE    = GETDATE(),
    UPDATE_BY      = @UpdateBy
WHERE ISNULL(Huy,0) = 0
  AND TypeID = @TypeID
  AND MaQuanLy IS NOT NULL
  AND LTRIM(RTRIM(MaQuanLy)) <> ''";

                using (SqlCommand cmdUp = new SqlCommand(sqlUpdate, conn))
                {
                    cmdUp.Parameters.AddWithValue("@TypeID", typeId);
                    cmdUp.Parameters.AddWithValue("@HasHdsd", File.Exists(srcHdsd) ? 1 : 0);
                    cmdUp.Parameters.AddWithValue("@HasBcdt", File.Exists(srcBcdt) ? 1 : 0);
                    cmdUp.Parameters.AddWithValue("@UpdateBy", (object)Constaint._userID ?? DBNull.Value);

                    result.DbUpdatedRows = cmdUp.ExecuteNonQuery();
                }
            }

            return result;
        }

    }
}
