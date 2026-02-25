using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_DEVICE_CANCEL_REGISTER_LIST : XtraForm
    {
        public FRM_DEVICE_CANCEL_REGISTER_LIST()
        {
            InitializeComponent();
        }

        private void FRM_DEVICE_CANCEL_REGISTER_LIST_Load(object sender, EventArgs e)
        {
            BuildBandedGrid();
            HookUnboundSTT();
            LoadData();
        }

        // ====== helper add column giống style FRM_DEVICE_REGISTER_LIST ======
        private BandedGridColumn AddCol(string field, string caption, int width = 100)
        {
            BandedGridColumn col = new BandedGridColumn()
            {
                FieldName = field,
                Caption = caption,
                Visible = true,
                Width = width,
                OptionsColumn = { AllowEdit = false, ReadOnly = true }
            };
            gvData.Columns.Add(col);
            return col;
        }

        private void BuildBandedGrid()
        {
            gvData.Bands.Clear();
            gvData.Columns.Clear();

            // ===== Bands =====
            GridBand bandInfo = gvData.Bands.AddBand("Thông tin thiết bị");
            GridBand bandCancel = gvData.Bands.AddBand("Xác định mục đích cần hủy");

            // ===== STT (Unbound) =====
            var colSTT = new BandedGridColumn()
            {
                Caption = "STT",
                FieldName = "STT",
                Visible = true,
                Width = 45,
                UnboundType = DevExpress.Data.UnboundColumnType.Integer,
                OptionsColumn = { AllowEdit = false, ReadOnly = true }
            };
            bandInfo.Columns.Add(colSTT);
            gvData.Columns.Add(colSTT);

            // ===== COLUMNS – Thông tin thiết bị (theo ảnh bạn gửi) =====
            bandInfo.Columns.Add(AddCol("TenThietBi", "Tên thiết bị", 150));
            bandInfo.Columns.Add(AddCol("MaQuanLy", "Mã quản lý", 150));
            bandInfo.Columns.Add(AddCol("TrangThaiSuDung", "Trạng thái sử dụng", 150));
            bandInfo.Columns.Add(AddCol("SerialNo", "Số serial", 120));
            bandInfo.Columns.Add(AddCol("Model", "Model", 100));
            bandInfo.Columns.Add(AddCol("NhaCungCap", "Nhà cung cấp", 140));
            bandInfo.Columns.Add(AddCol("MucDichSuDung", "Mục đích sử dụng", 160));
            bandInfo.Columns.Add(AddCol("NhaMay", "Nhà máy", 90));
            bandInfo.Columns.Add(AddCol("LoaiThietBi", "Loại thiết bị", 120));

            // Nếu bạn thật sự cần thêm 1 cột “Nhà máy” nữa như hình
            // bandInfo.Columns.Add(AddCol("NhaMay2", "Nhà máy", 90));

            // ===== COLUMNS – Xác định mục đích cần hủy =====
            bandCancel.Columns.Add(AddCol("LyDoHuy", "Lý do hủy", 220));
            bandCancel.Columns.Add(AddCol("AnhHuongSanXuat", "Có ảnh hưởng đến sản xuất không", 200));
            bandCancel.Columns.Add(AddCol("NgayHuyDuKien", "Ngày hủy dự kiến", 120));
            bandCancel.Columns.Add(AddCol("GhiChu", "Ghi chú", 180));

            // ===== Grid options giống FRM_DEVICE_REGISTER_LIST =====
            gvData.OptionsView.ShowBands = true;
            gvData.OptionsBehavior.Editable = false;
            gvData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            gvData.OptionsView.ShowAutoFilterRow = true;
            gvData.OptionsView.ShowGroupPanel = false;

            foreach (GridBand band in gvData.Bands)
            {
                band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                band.AppearanceHeader.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            }
        }

        private void HookUnboundSTT()
        {
            gvData.CustomUnboundColumnData -= gvData_CustomUnboundColumnData;
            gvData.CustomUnboundColumnData += gvData_CustomUnboundColumnData;
        }

        private void gvData_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "STT" && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void LoadData()
        {
            try
            {
                string query = @"
SELECT
    D.MaQuanLy,
    D.TenThietBi,
    S.StatusName AS TrangThaiSuDung,
    D.SerialNo,
    D.Model,
    D.NhaCungCap,
    D.MucDichSuDung,
    D.NhaMay,
    T.Type AS LoaiThietBi,

    D.CancelReason      AS LyDoHuy,
    D.CancelImpact      AS AnhHuongSanXuat,
    D.CancelPlanDate    AS NgayHuyDuKien,
    D.CancelNote        AS GhiChu

FROM dbo.TBL_DEVICE_MST D
LEFT JOIN dbo.TBL_DEVICE_TYPE T
    ON T.TypeID = D.TypeID
LEFT JOIN dbo.TBL_DEVICE_STATUS S
    ON S.StatusID = D.StatusID
WHERE ISNULL(D.Huy,0) = 0
  AND D.StatusID = 5
ORDER BY D.CancelRequestAt DESC, D.UPDATE_DATE DESC;
";

                DataTable dt = DBUtils._getData(query) ?? new DataTable();
                gcData.DataSource = dt;

                gvData.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadData:\n" + ex.Message);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Constaint._access != "1" && Constaint._access != "3")
            {
                MessageBox.Show("Bạn không có quyền!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gvData.FocusedRowHandle < 0)
            {
                MessageBox.Show("Chọn dòng để từ chối!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maQuanLy = gvData.GetFocusedRowCellValue("MaQuanLy")?.ToString();
            if (string.IsNullOrWhiteSpace(maQuanLy))
            {
                MessageBox.Show("Không lấy được Mã quản lý!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // (tuỳ bạn) hỏi lý do reject
            string reason = XtraInputBox.Show("Nhập lý do từ chối hủy (có thể để trống):",
                                              "Từ chối hủy", "");

            string sql = @"
UPDATE TBL_DEVICE_MST
SET
    StatusID = 1, -- hoặc 3 tuỳ logic bạn
    CancelRejectReason = @Reason,
    UPDATE_BY = @UpdateBy,
    UPDATE_DATE = GETDATE()
WHERE MaQuanLy = @MaQuanLy
  AND ISNULL(Huy,0) = 0
  AND StatusID = 5;";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaQuanLy", maQuanLy);
                        cmd.Parameters.AddWithValue("@Reason", string.IsNullOrWhiteSpace(reason) ? (object)DBNull.Value : reason.Trim());
                        cmd.Parameters.AddWithValue("@UpdateBy", (object)Constaint._userID ?? DBNull.Value);

                        int affected = cmd.ExecuteNonQuery();
                        if (affected <= 0)
                        {
                            MessageBox.Show("Không từ chối được (có thể thiết bị không còn ở trạng thái Chờ duyệt hủy).",
                                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                MessageBox.Show("Đã từ chối hủy!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch
            {
                MessageBox.Show("Thao tác thất bại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 0) Login + quyền
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                MessageBox.Show("Hãy đăng nhập!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Constaint._access != "1" && Constaint._access != "3")
            {
                MessageBox.Show("Bạn không có quyền!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1) chọn dòng
            if (gvData.FocusedRowHandle < 0)
            {
                MessageBox.Show("Chọn dòng để xác nhận!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2) lấy MaQuanLy (string)
            string maQuanLy = gvData.GetFocusedRowCellValue("MaQuanLy")?.ToString();
            if (string.IsNullOrWhiteSpace(maQuanLy))
            {
                MessageBox.Show("Không lấy được Mã quản lý!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3) confirm
            if (MessageBox.Show($"Xác nhận DUYỆT HỦY thiết bị: {maQuanLy} ?",
                                "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            // 4) update DB: StatusID = 4 (Đã hủy)
            string sql = @"
UPDATE TBL_DEVICE_MST
SET
    StatusID = 4,
    CancelApproveBy = @ApproveBy,
    CancelApproveAt = GETDATE(),
    UPDATE_BY = @UpdateBy,
    UPDATE_DATE = GETDATE()
WHERE MaQuanLy = @MaQuanLy
  AND ISNULL(Huy,0) = 0
  AND StatusID = 5;";

            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaQuanLy", maQuanLy);
                        cmd.Parameters.AddWithValue("@ApproveBy", (object)Constaint._userID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@UpdateBy", (object)Constaint._userID ?? DBNull.Value);

                        int affected = cmd.ExecuteNonQuery();
                        if (affected <= 0)
                        {
                            MessageBox.Show("Không duyệt được (có thể thiết bị không còn ở trạng thái Chờ duyệt hủy).",
                                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                MessageBox.Show("Đã duyệt hủy!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác thất bại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            Constaint._exportGridViewXlsx(gvData, gcData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
