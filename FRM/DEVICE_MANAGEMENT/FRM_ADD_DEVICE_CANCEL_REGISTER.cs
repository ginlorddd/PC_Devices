using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_ADD_DEVICE_CANCEL_REGISTER : XtraForm
    {
        private DataTable _dtDevice = new DataTable();

        // MaQuanLy đang chọn
        private string _maQLSelected = "";
        private int _statusIdSelected = 0;

        public FRM_ADD_DEVICE_CANCEL_REGISTER()
        {
            InitializeComponent();
        }

        private void FRM_ADD_DEVICE_CANCEL_REGISTER_Load(object sender, EventArgs e)
        {
            try
            {
                cboAnhHuong.SelectedIndex = -1;
                dtNgayHuyDuKien.EditValue = DateTime.Today;

                LoadDeviceList();
                SetupGridColumnsCaption();
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOAD LIST THIẾT BỊ CÓ THỂ ĐĂNG KÝ HỦY
        // (Không lấy StatusID=4 (đã hủy) & 5 (chờ duyệt hủy))
        // =========================================================
        private void LoadDeviceList()
        {
            string sql = @"
SELECT
    D.MaQuanLy,
    D.TenThietBi,
    D.SerialNo,
    D.Model,
    D.NhaCungCap,
    D.MucDichSuDung,
    D.NhaMay,
    T.[Type] AS LoaiThietBi,
    S.StatusName AS TrangThaiSuDung,
    D.StatusID
FROM dbo.TBL_DEVICE_MST D
LEFT JOIN dbo.TBL_DEVICE_TYPE T
    ON D.TypeID = T.TypeID
LEFT JOIN dbo.TBL_DEVICE_STATUS S
    ON D.StatusID = S.StatusID
WHERE ISNULL(D.Huy,0) = 0
  AND ISNULL(D.StatusID,0) NOT IN (4,5)
ORDER BY D.UPDATE_DATE DESC, D.CREATE_DATE DESC;";

            _dtDevice = DBUtils._getData(sql) ?? new DataTable();
            gcDevice.DataSource = _dtDevice;

            if (gvDevice.Columns["StatusID"] != null)
                gvDevice.Columns["StatusID"].Visible = false;

            gvDevice.BestFitColumns();
        }

        private void SetupGridColumnsCaption()
        {
            if (gvDevice.Columns["MaQuanLy"] != null) gvDevice.Columns["MaQuanLy"].Caption = "Mã quản lý";
            if (gvDevice.Columns["TenThietBi"] != null) gvDevice.Columns["TenThietBi"].Caption = "Tên thiết bị";
            if (gvDevice.Columns["SerialNo"] != null) gvDevice.Columns["SerialNo"].Caption = "Số serial";
            if (gvDevice.Columns["Model"] != null) gvDevice.Columns["Model"].Caption = "Model";
            if (gvDevice.Columns["NhaCungCap"] != null) gvDevice.Columns["NhaCungCap"].Caption = "Nhà cung cấp";
            if (gvDevice.Columns["MucDichSuDung"] != null) gvDevice.Columns["MucDichSuDung"].Caption = "Mục đích sử dụng";
            if (gvDevice.Columns["NhaMay"] != null) gvDevice.Columns["NhaMay"].Caption = "Nhà máy";
            if (gvDevice.Columns["LoaiThietBi"] != null) gvDevice.Columns["LoaiThietBi"].Caption = "Loại thiết bị";
            if (gvDevice.Columns["TrangThaiSuDung"] != null) gvDevice.Columns["TrangThaiSuDung"].Caption = "Trạng thái";
        }

        // dummy helper to avoid any compiler complaining about unused; can remove safely
        private string IDB(string x) { return x; }

        // =========================================================
        // SEARCH FILTER
        // =========================================================
        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_dtDevice == null || _dtDevice.Rows.Count == 0) return;

                string key = (txtSearch.Text ?? "").Trim().Replace("'", "''");

                DataView dv = _dtDevice.DefaultView;

                if (string.IsNullOrWhiteSpace(key))
                {
                    dv.RowFilter = "";
                }
                else
                {
                    // tìm theo: MaQuanLy, TenThietBi, SerialNo, Model, NhaMay, LoaiThietBi
                    dv.RowFilter =
                        $"MaQuanLy LIKE '%{key}%'" +
                        $" OR TenThietBi LIKE '%{key}%'" +
                        $" OR SerialNo LIKE '%{key}%'" +
                        $" OR Model LIKE '%{key}%'" +
                        $" OR NhaMay LIKE '%{key}%'" +
                        $" OR LoaiThietBi LIKE '%{key}%'";
                }
            }
            catch
            {
                // Không show lỗi chi tiết theo yêu cầu
            }
        }

        // =========================================================
        // CHỌN DÒNG -> FILL THIẾT BỊ ĐÃ CHỌN
        // =========================================================
        private void gvDevice_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            FillSelectedDevice();
        }

        private void gvDevice_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            // double click cũng fill (cho dễ thao tác)
            if (e.Clicks >= 1)
                FillSelectedDevice();
        }

        private void FillSelectedDevice()
        {
            try
            {
                if (gvDevice.FocusedRowHandle < 0) return;

                _maQLSelected = gvDevice.GetFocusedRowCellValue("MaQuanLy")?.ToString() ?? "";
                string ten = gvDevice.GetFocusedRowCellValue("TenThietBi")?.ToString() ?? "";
                string nm = gvDevice.GetFocusedRowCellValue("NhaMay")?.ToString() ?? "";
                string st = gvDevice.GetFocusedRowCellValue("TrangThaiSuDung")?.ToString() ?? "";

                object sid = gvDevice.GetFocusedRowCellValue("StatusID");
                _statusIdSelected = (sid == null || sid == DBNull.Value) ? 0 : Convert.ToInt32(sid);

                txtMaQL.Text = _maQLSelected;
                txtTenTB.Text = ten;
                txtFactory.Text = nm;
                txtStatus.Text = st;
            }
            catch
            {
                // ignore
            }
        }

        // =========================================================
        // VALIDATE
        // =========================================================
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(_maQLSelected))
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần hủy!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Không cho đăng ký hủy nếu đã hủy / đang chờ duyệt hủy
            if (_statusIdSelected == 4 || _statusIdSelected == 5)
            {
                MessageBox.Show("Thiết bị đã hủy hoặc đang chờ duyệt hủy!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                MessageBox.Show("Vui lòng nhập Lý do hủy!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLyDo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboAnhHuong.Text))
            {
                MessageBox.Show("Vui lòng chọn Ảnh hưởng sản xuất!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAnhHuong.Focus();
                return false;
            }

            if (dtNgayHuyDuKien.EditValue == null || dtNgayHuyDuKien.EditValue == DBNull.Value)
            {
                MessageBox.Show("Vui lòng chọn Ngày hủy dự kiến!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgayHuyDuKien.Focus();
                return false;
            }

            if (DateTime.TryParse(dtNgayHuyDuKien.EditValue.ToString(), out DateTime d))
            {
                if (d.Date < DateTime.Today)
                {
                    MessageBox.Show("Ngày hủy dự kiến không được nhỏ hơn hôm nay!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtNgayHuyDuKien.Focus();
                    return false;
                }
            }

            return true;
        }

        // =========================================================
        // BUTTON: ADD (Đăng ký hủy)
        // =========================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                DateTime planDate = Convert.ToDateTime(dtNgayHuyDuKien.EditValue).Date;

                string sql = @"
UPDATE dbo.TBL_DEVICE_MST
SET
    CancelReason      = @Reason,
    CancelImpact      = @Impact,
    CancelPlanDate    = @PlanDate,
    CancelNote        = @Note,

    CancelRequestBy   = @ReqBy,
    CancelRequestAt   = GETDATE(),

    -- reset duyệt/từ chối cũ (nếu có)
    CancelApproveBy   = NULL,
    CancelApproveAt   = NULL,
    CancelRejectReason= NULL,

    StatusID          = 5,
    UPDATE_DATE       = GETDATE(),
    UPDATE_BY         = @ReqBy
WHERE MaQuanLy = @MaQL
  AND ISNULL(Huy,0) = 0
  AND ISNULL(StatusID,0) NOT IN (4,5);";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Reason", txtLyDo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Impact", cboAnhHuong.Text.Trim());
                        cmd.Parameters.AddWithValue("@PlanDate", planDate);
                        cmd.Parameters.AddWithValue("@Note", (object)(txtGhiChu.Text?.Trim()) ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@ReqBy", (object)Constaint._userID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaQL", _maQLSelected);

                        int affected = cmd.ExecuteNonQuery();
                        if (affected <= 0)
                        {
                            MessageBox.Show("Không đăng ký được (thiết bị đã hủy/đang chờ duyệt hủy hoặc không tồn tại).",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                MessageBox.Show("Đã đăng ký hủy thiết bị!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // FRM LIST sẽ LoadData lại
                this.Close();
            }
            catch
            {
                MessageBox.Show("Không đăng ký được!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // BUTTON: CLOSE
        // =========================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
