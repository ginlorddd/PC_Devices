using DevExpress.XtraEditors;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_EDIT_MAINT : XtraForm
    {
        private readonly string _maQL;
        private string _deviceFolder;

        // Old values
        private DateTime? oldNgayBD;
        private DateTime? oldNgayKH;
        private int? oldStatusId;
        private string tenThietBi;

        // LSSC file
        private string oldLSSCFileName;
        private string _newLsscFullPath = "";

        public FRM_EDIT_MAINT(string maQuanLy)
        {
            InitializeComponent();
            _maQL = maQuanLy;

            // Hook load
            this.Load += FRM_EDIT_MAINT_Load;
        }

        private void FRM_EDIT_MAINT_Load(object sender, EventArgs e)
        {
            _deviceFolder = Path.Combine(Constaint._folderFileUpload, _maQL);

            // khóa không cho sửa mã + tên (vì form bảo dưỡng)
            txtMaQL.Properties.ReadOnly = true;
            txtTenTB.Properties.ReadOnly = true;

            // kế hoạch BD: auto-calc -> không cho sửa tay
            dtNgayKH.Properties.ReadOnly = true;
            dtNgayKH.Properties.AllowFocused = false;

            // Load master trước (quan trọng)
            LoadFreqMaster();
            LoadStatusMaster();

            // Load data thiết bị sau
            LoadDeviceData();

            // Auto recalc
            dtNgayBD.EditValueChanged -= DtNgayBD_EditValueChanged;
            dtNgayBD.EditValueChanged += DtNgayBD_EditValueChanged;

            cboTanSuat.EditValueChanged -= CboTanSuat_EditValueChanged;
            cboTanSuat.EditValueChanged += CboTanSuat_EditValueChanged;
        }

        private void DtNgayBD_EditValueChanged(object sender, EventArgs e)
        {
            RecalcNextPlan();
        }

        private void CboTanSuat_EditValueChanged(object sender, EventArgs e)
        {
            RecalcNextPlan();
        }

        // ======================================================
        // LOAD MASTER: FREQ
        // ======================================================
        private void LoadFreqMaster()
        {
            try
            {
                string sql = "SELECT FreqID, FreqName FROM TBL_MAINT_FREQ ORDER BY FreqID";
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlDataAdapter ad = new SqlDataAdapter(sql, conn))
                {
                    ad.Fill(dt);
                }

                cboTanSuat.Properties.DataSource = dt;
                cboTanSuat.Properties.DisplayMember = "FreqName";
                cboTanSuat.Properties.ValueMember = "FreqID";
                cboTanSuat.Properties.NullText = "";

                // để user chỉ chọn, không gõ
                cboTanSuat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

                // hiện cột
                cboTanSuat.Properties.Columns.Clear();
                cboTanSuat.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FreqName", "Tần suất"));
            }
            catch
            {
                // không show lỗi chi tiết
            }
        }

        // ======================================================
        // LOAD MASTER: STATUS (1,3)
        // ======================================================
        private void LoadStatusMaster()
        {
            try
            {
                string sql = "SELECT StatusID, StatusName FROM TBL_DEVICE_STATUS WHERE StatusID IN (1,3) ORDER BY StatusID";
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlDataAdapter ad = new SqlDataAdapter(sql, conn))
                {
                    ad.Fill(dt);
                }

                cboStatus.Properties.DataSource = dt;
                cboStatus.Properties.DisplayMember = "StatusName";
                cboStatus.Properties.ValueMember = "StatusID";
                cboStatus.Properties.NullText = "";

                // chỉ chọn, không gõ
                cboStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

                // hiện cột
                cboStatus.Properties.Columns.Clear();
                cboStatus.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusName", "Trạng thái"));
            }
            catch
            {
            }
        }

        // ======================================================
        // LOAD DEVICE DATA
        // ======================================================
        private void LoadDeviceData()
        {
            try
            {
                string sql = @"
SELECT
    TenThietBi,
    NgayBaoDuong,
    KeHoachBaoDuongTiepTheo,
    TanSuat,
    StatusID,
    LichSuBaoDuong
FROM TBL_DEVICE_MST
WHERE MaQuanLy = @MaQL";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MaQL", _maQL);

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            XtraMessageBox.Show("Không tìm thấy thiết bị!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                            return;
                        }

                        tenThietBi = rd["TenThietBi"]?.ToString() ?? "";
                        oldNgayBD = rd["NgayBaoDuong"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(rd["NgayBaoDuong"]);
                        oldNgayKH = rd["KeHoachBaoDuongTiepTheo"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(rd["KeHoachBaoDuongTiepTheo"]);
                        oldStatusId = rd["StatusID"] == DBNull.Value ? (int?)null : Convert.ToInt32(rd["StatusID"]);
                        string tanSuatText = rd["TanSuat"]?.ToString() ?? "";
                        oldLSSCFileName = rd["LichSuBaoDuong"]?.ToString() ?? "";

                        // ====== Fill UI ======
                        txtMaQL.Text = _maQL;
                        txtTenTB.Text = tenThietBi;

                        dtNgayBD.EditValue = oldNgayBD;
                        dtNgayKH.EditValue = oldNgayKH;

                        // STATUS: set EditValue (sau khi load master)
                        if (oldStatusId == 1 || oldStatusId == 3)
                            cboStatus.EditValue = oldStatusId;
                        else
                            cboStatus.EditValue = 3; // default cho dễ (bạn muốn thì đổi)

                        // FREQ: vì DB lưu TEXT => map FreqName -> FreqID
                        SetFreqByFreqName(tanSuatText);

                        // LSSC
                        txtLSSC.Text = oldLSSCFileName;
                    }
                }

                // nếu KH null -> auto tính luôn
                if (dtNgayKH.EditValue == null || dtNgayKH.EditValue == DBNull.Value)
                    RecalcNextPlan();
            }
            catch
            {
                XtraMessageBox.Show("Không thể tải dữ liệu thiết bị.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetFreqByFreqName(string freqName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(freqName))
                {
                    cboTanSuat.EditValue = null;
                    return;
                }

                DataTable dt = cboTanSuat.Properties.DataSource as DataTable;
                if (dt == null)
                {
                    cboTanSuat.EditValue = null;
                    return;
                }

                foreach (DataRow r in dt.Rows)
                {
                    string name = (r["FreqName"]?.ToString() ?? "").Trim();
                    if (string.Equals(name, freqName.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        cboTanSuat.EditValue = r["FreqID"];
                        return;
                    }
                }

                // không match => để trống (hoặc set default)
                cboTanSuat.EditValue = null;
            }
            catch
            {
                cboTanSuat.EditValue = null;
            }
        }

        // ======================================================
        // CALC NEXT PLAN
        // ======================================================
        private void RecalcNextPlan()
        {
            try
            {
                DateTime? ngayBD = GetDateEditValue(dtNgayBD);
                string tanSuatText = (cboTanSuat.Text ?? "").Trim(); // FreqName

                DateTime? next = TinhNgayBaoDuongTiepTheo(ngayBD, tanSuatText);
                dtNgayKH.EditValue = next;
            }
            catch
            {
            }
        }

        private DateTime? GetDateEditValue(DateEdit de)
        {
            if (de.EditValue == null || de.EditValue == DBNull.Value) return null;
            if (DateTime.TryParse(de.EditValue.ToString(), out DateTime d)) return d.Date;
            return null;
        }

        private DateTime? TinhNgayBaoDuongTiepTheo(DateTime? ngayBaoDuong, string tanSuat)
        {
            if (!ngayBaoDuong.HasValue || string.IsNullOrWhiteSpace(tanSuat))
                return null;

            string s = tanSuat.Trim().ToLower();
            Match m = Regex.Match(s, @"\d+");
            if (!m.Success || !int.TryParse(m.Value, out int n) || n <= 0)
                return null;

            if (s.Contains("tháng")) return ngayBaoDuong.Value.AddMonths(n);
            if (s.Contains("năm")) return ngayBaoDuong.Value.AddYears(n);

            return null;
        }

        // ======================================================
        // LSSC FILE UI
        // ======================================================
        private void btnChooseLSSC_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "PDF Files|*.pdf";
                    dlg.Title = "Chọn file Lịch sử bảo dưỡng (PDF)";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        _newLsscFullPath = dlg.FileName;
                        txtLSSC.Text = Path.GetFileName(_newLsscFullPath);
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Không thể chọn file.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenLSSC_Click(object sender, EventArgs e)
        {
            try
            {
                string pathToOpen = "";

                if (!string.IsNullOrWhiteSpace(_newLsscFullPath) && File.Exists(_newLsscFullPath))
                {
                    pathToOpen = _newLsscFullPath;
                }
                else
                {
                    string fileName = (txtLSSC.Text ?? "").Trim();
                    if (!string.IsNullOrWhiteSpace(fileName))
                    {
                        string p = Path.Combine(_deviceFolder, fileName);
                        if (File.Exists(p)) pathToOpen = p;
                    }
                }

                if (string.IsNullOrWhiteSpace(pathToOpen))
                {
                    XtraMessageBox.Show("Chưa có file để mở.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Process.Start(new ProcessStartInfo(pathToOpen) { UseShellExecute = true });
            }
            catch
            {
                XtraMessageBox.Show("Không mở được file.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================
        // VALIDATE
        // ======================================================
        private bool ValidateInput(out DateTime? newNgayBD, out DateTime? newNgayKH, out string tanSuatText, out int statusId)
        {
            newNgayBD = GetDateEditValue(dtNgayBD);
            tanSuatText = (cboTanSuat.Text ?? "").Trim();
            newNgayKH = GetDateEditValue(dtNgayKH);

            statusId = 0;
            if (cboStatus.EditValue != null && int.TryParse(cboStatus.EditValue.ToString(), out int st))
                statusId = st;

            if (!newNgayBD.HasValue)
            {
                XtraMessageBox.Show("Vui lòng chọn Ngày bảo dưỡng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgayBD.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tanSuatText))
            {
                XtraMessageBox.Show("Vui lòng chọn Tần suất!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTanSuat.Focus();
                return false;
            }

            if (statusId != 1 && statusId != 3)
            {
                XtraMessageBox.Show("Vui lòng chọn Trạng thái (chỉ 1 hoặc 3).", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboStatus.Focus();
                return false;
            }

            // auto calc KH
            DateTime? calc = TinhNgayBaoDuongTiepTheo(newNgayBD, tanSuatText);
            dtNgayKH.EditValue = calc;
            newNgayKH = calc;

            return true;
        }

        // ======================================================
        // SAVE
        // ======================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput(out DateTime? newNgayBD, out DateTime? newNgayKH, out string tanSuatText, out int statusId))
                    return;

                if (!Directory.Exists(_deviceFolder))
                    Directory.CreateDirectory(_deviceFolder);

                // LSSC: copy nếu user chọn file mới
                string lsscFileName = oldLSSCFileName;
                if (!string.IsNullOrWhiteSpace(_newLsscFullPath) && File.Exists(_newLsscFullPath))
                {
                    lsscFileName = $"{_maQL}_LSSC.pdf";
                    File.Copy(_newLsscFullPath, Path.Combine(_deviceFolder, lsscFileName), true);
                }

                string updateSql = @"
UPDATE TBL_DEVICE_MST
SET
    NgayBaoDuong = @NgayBD,
    KeHoachBaoDuongTiepTheo = @NgayKH,
    TanSuat = @TanSuat,
    StatusID = @StatusID,
    LichSuBaoDuong = @LSSC,
    UPDATE_DATE = GETDATE(),
    UPDATE_BY = @UpdateBy
WHERE MaQuanLy = @MaQL;";

                int affected = 0;
                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand(updateSql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@NgayBD", newNgayBD.HasValue ? (object)newNgayBD.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayKH", newNgayKH.HasValue ? (object)newNgayKH.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@TanSuat", (object)tanSuatText ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StatusID", statusId);
                    cmd.Parameters.AddWithValue("@LSSC", string.IsNullOrWhiteSpace(lsscFileName) ? (object)DBNull.Value : lsscFileName);
                    cmd.Parameters.AddWithValue("@UpdateBy", (object)Constaint._userID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaQL", _maQL);

                    affected = cmd.ExecuteNonQuery();
                }

                if (affected <= 0)
                {
                    XtraMessageBox.Show("Không cập nhật được (không tìm thấy mã quản lý).", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                InsertHistory(newNgayBD, newNgayKH);

                XtraMessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                XtraMessageBox.Show("Không thể lưu dữ liệu.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertHistory(DateTime? newBD, DateTime? newKH)
        {
            try
            {
                string insert = @"
INSERT INTO TBL_DEVICE_MAINT_HISTORY
(
    MaQuanLy, TenThietBi,
    OldNgayBaoDuong, NewNgayBaoDuong,
    OldKeHoach, NewKeHoach,
    UpdateAt, UpdateBy
)
VALUES
(
    @MaQL, @TenTB,
    @OldBD, @NewBD,
    @OldKH, @NewKH,
    @Time, @User
);";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@MaQL", _maQL);
                    cmd.Parameters.AddWithValue("@TenTB", (object)tenThietBi ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@OldBD", oldNgayBD.HasValue ? (object)oldNgayBD.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@NewBD", newBD.HasValue ? (object)newBD.Value : DBNull.Value);

                    cmd.Parameters.AddWithValue("@OldKH", oldNgayKH.HasValue ? (object)oldNgayKH.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@NewKH", newKH.HasValue ? (object)newKH.Value : DBNull.Value);

                    cmd.Parameters.AddWithValue("@Time", DateTime.Now);
                    cmd.Parameters.AddWithValue("@User", (object)Constaint._userID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
