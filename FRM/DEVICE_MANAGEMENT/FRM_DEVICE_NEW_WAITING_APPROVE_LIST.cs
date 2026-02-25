using DevExpress.XtraEditors;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_DEVICE_NEW_WAITING_APPROVE_LIST : XtraForm
    {
        public FRM_DEVICE_NEW_WAITING_APPROVE_LIST()
        {
            InitializeComponent();
        }

        // ======================================================
        // FORM LOAD
        // ======================================================
        private void FRM_DEVICE_NEW_WAITING_APPROVE_LIST_Load(object sender, EventArgs e)
        {
            dtFrom.EditValue = DateTime.Today.AddMonths(-3);
            dtTo.EditValue = DateTime.Today;

            LoadData();
            gvData.CustomUnboundColumnData += gvData_CustomUnboundColumnData;

        }
        private void gvData_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "STT" && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }

        // ======================================================
        // LOAD DATA
        // ======================================================
        private void LoadData()
        {
            try
            {
                string sql = @"
SELECT
    R.RegisterID,
    R.DeviceName,
    R.Serial,
    R.Model,
    R.Supplier,
    R.Purpose,
    F.FactoryName,
    T.Type AS DeviceType,
    R.NgayVe,
    R.TaiSanCoDinh,
    R.ThongSoThietBi,
    R.CongViecCanDung,
    R.ChucNang,
    R.TaiTrong,
    R.DungSai,
    R.DanhGia,
    S.StatusName
FROM TBL_DEVICE_REGISTER R
LEFT JOIN TBL_FACTORY_MST F ON R.FactoryID = F.ID
LEFT JOIN TBL_DEVICE_TYPE T ON R.TypeID = T.TypeID
LEFT JOIN TBL_DEVICE_REGISTER_STATUS S ON R.StatusID = S.StatusID
WHERE
    ISNULL(R.Huy, 0) = 0
    AND R.StatusID = 2
    AND R.NgayVe IS NOT NULL
    AND R.NgayVe <= GETDATE()
";

                // ===== FILTER NGÀY =====
                if (dtFrom.EditValue != null)
                    sql += " AND R.NgayVe >= @FromDate";

                if (dtTo.EditValue != null)
                    sql += " AND R.NgayVe <= @ToDate";

                // ===== SEARCH =====

                sql += " ORDER BY R.NgayVe DESC";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    if (dtFrom.EditValue != null)
                        cmd.Parameters.AddWithValue("@FromDate",
                            ((DateTime)dtFrom.EditValue).Date);

                    if (dtTo.EditValue != null)
                        cmd.Parameters.AddWithValue("@ToDate",
                            ((DateTime)dtTo.EditValue).Date.AddDays(1).AddSeconds(-1));

                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    gcData.DataSource = dt;
                }

                BuildGrid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi load dữ liệu:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================
        // GRID FORMAT
        // ======================================================
        private void BuildGrid()
        {
            gvData.BestFitColumns();
            gvData.OptionsBehavior.Editable = false;
            gvData.OptionsView.ShowGroupPanel = false;

            if (gvData.Columns["RegisterID"] != null)
                gvData.Columns["RegisterID"].Visible = false;

            if (gvData.Columns["STT"] == null)
            {
                DevExpress.XtraGrid.Columns.GridColumn colSTT = gvData.Columns.AddField("STT");
                colSTT.Caption = "STT";
                colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                colSTT.VisibleIndex = 0;   // luôn ở đầu
                colSTT.Width = 50;
                colSTT.OptionsColumn.AllowEdit = false;
                colSTT.OptionsColumn.ReadOnly = true;
            }

            gvData.Columns["DeviceName"].Caption = "Tên thiết bị";
            gvData.Columns["Serial"].Caption = "Serial";
            gvData.Columns["Model"].Caption = "Model";
            gvData.Columns["Supplier"].Caption = "Nhà cung cấp";
            gvData.Columns["Purpose"].Caption = "Mục đích sử dụng";
            gvData.Columns["FactoryName"].Caption = "Nhà máy";
            gvData.Columns["DeviceType"].Caption = "Loại thiết bị";
            gvData.Columns["NgayVe"].Caption = "Ngày về";
            gvData.Columns["TaiSanCoDinh"].Caption = "Tài sản cố định";
            gvData.Columns["ThongSoThietBi"].Caption = "Thông số thiết bị";
            gvData.Columns["CongViecCanDung"].Caption = "Công việc cần dùng";
            gvData.Columns["ChucNang"].Caption = "Chức năng";
            gvData.Columns["TaiTrong"].Caption = "Tải trọng";
            gvData.Columns["DungSai"].Caption = "Dung sai";
            gvData.Columns["DanhGia"].Caption = "Đánh giá";
            gvData.Columns["StatusName"].Caption = "Trạng thái";
        }

        // ======================================================
        // BUTTON: REFRESH
        // ======================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // ======================================================
        // BUTTON: ADD → FRM_ADD_DEVICE
        // ======================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ===== CHECK LOGIN =====
            if (string.IsNullOrWhiteSpace(Constaint._access))
            {
                XtraMessageBox.Show("Hãy đăng nhập!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ===== CHECK PERMISSION =====
            if (Constaint._access != "1" && Constaint._access != "3")
            {
                XtraMessageBox.Show("Bạn không có quyền thêm thiết bị!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gvData.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn thiết bị!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow row = gvData.GetFocusedDataRow();
            if (row == null) return;

            FRM_ADD_DEVICE frm = new FRM_ADD_DEVICE();

            // ===== FILL DATA SANG FORM ADD =====
            frm.PreFillFromRegister(row);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // reload sau khi add
            }
        }

        // ======================================================
        // BUTTON: CLOSE
        // ======================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Constaint._exportGridViewXlsx(gvData, gcData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
