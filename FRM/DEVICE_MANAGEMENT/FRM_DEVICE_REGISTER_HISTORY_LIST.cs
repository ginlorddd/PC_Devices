using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_DEVICE_REGISTER_HISTORY_LIST : XtraForm
    {
        public FRM_DEVICE_REGISTER_HISTORY_LIST()
        {
            InitializeComponent();
        }

        private void FRM_DEVICE_REGISTER_HISTORY_LIST_Load(object sender, EventArgs e)
        {
            // Default filter: 3 tháng gần nhất
            dtFrom.EditValue = DateTime.Today.AddMonths(-3);
            dtTo.EditValue = DateTime.Today;

            // STT unbound
            gvRegister.CustomUnboundColumnData += gvRegister_CustomUnboundColumnData;
            gvDevice.CustomUnboundColumnData += gvDevice_CustomUnboundColumnData;

            LoadRegisterHistory();
            LoadDeviceHistory();
        }

        // ======================================================
        // STT - UNBOUND
        // ======================================================
        private void gvRegister_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "STT" && e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }

        private void gvDevice_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "STT" && e.IsGetData)
                e.Value = e.ListSourceRowIndex + 1;
        }

        // ======================================================
        // BUTTON EVENTS
        // ======================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRegisterHistory();
            LoadDeviceHistory();
        }

        private void btnExportRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Constaint._exportGridViewXlsx(gvRegister, gcRegister);
            }
            catch
            {
                MessageBox.Show("Không export được lịch sử đăng ký!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportDevice_Click(object sender, EventArgs e)
        {
            try
            {
                Constaint._exportGridViewXlsx(gvDevice, gcDevice);
            }
            catch
            {
                MessageBox.Show("Không export được lịch sử sử dụng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ======================================================
        // FILTER HELPERS
        // ======================================================
        private DateTime? GetFromDate()
        {
            if (dtFrom.EditValue == null || dtFrom.EditValue == DBNull.Value) return null;
            return ((DateTime)dtFrom.EditValue).Date;
        }

        private DateTime? GetToDate()
        {
            if (dtTo.EditValue == null || dtTo.EditValue == DBNull.Value) return null;
            // lấy hết ngày
            return ((DateTime)dtTo.EditValue).Date.AddDays(1).AddSeconds(-1);
        }

        // ======================================================
        // 1) LOAD REGISTER HISTORY (TBL_DEVICE_REGISTER)
        // ======================================================
        private void LoadRegisterHistory()
        {
            try
            {
                string sql = @"
SELECT
    -- STT: unbound
    R.RegisterID,
    R.DeviceName,
    R.Serial,
    R.Model,
    R.Supplier,
    R.Purpose,
    R.FactoryID,
    R.TypeID,
    R.NgayVe,
    R.TaiSanCoDinh,

    RS.StatusName AS TrangThaiDangKy,

    R.CreateAt,
    R.CreateBy,
    R.ApproveBy,
    R.ApproveAt,

    COALESCE(R.ApproveAt, R.CreateAt) AS NgayDuyetHienThi
FROM dbo.TBL_DEVICE_REGISTER R
LEFT JOIN dbo.TBL_DEVICE_REGISTER_STATUS RS
    ON R.StatusID = RS.StatusID
WHERE ISNULL(R.Huy, 0) = 0
";

                DateTime? from = GetFromDate();
                DateTime? to = GetToDate();

                if (from.HasValue) sql += " AND COALESCE(R.ApproveAt, R.CreateAt) >= @FromDate";
                if (to.HasValue) sql += " AND COALESCE(R.ApproveAt, R.CreateAt) <= @ToDate";


                sql += " ORDER BY COALESCE(R.ApproveAt, R.CreateAt) DESC";

                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    if (from.HasValue) cmd.Parameters.AddWithValue("@FromDate", from.Value);
                    if (to.HasValue) cmd.Parameters.AddWithValue("@ToDate", to.Value);

                    new SqlDataAdapter(cmd).Fill(dt);
                }

                gcRegister.DataSource = dt;
                BuildRegisterGrid();
            }
            catch
            {
                MessageBox.Show("Lỗi load lịch sử đăng ký!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuildRegisterGrid()
        {
            // STT
            if (gvRegister.Columns["STT"] == null)
            {
                var col = gvRegister.Columns.AddField("STT");
                col.Caption = "STT";
                col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                col.VisibleIndex = 0;
                col.Width = 50;
                col.OptionsColumn.AllowEdit = false;
                col.OptionsColumn.ReadOnly = true;
            }

            // Ẩn ID
            if (gvRegister.Columns["RegisterID"] != null)
                gvRegister.Columns["RegisterID"].Visible = false;

            // Caption
            SetCaption(gvRegister, "DeviceName", "Tên thiết bị");
            SetCaption(gvRegister, "Serial", "Serial");
            SetCaption(gvRegister, "Model", "Model");
            SetCaption(gvRegister, "Supplier", "Nhà cung cấp");
            SetCaption(gvRegister, "Purpose", "Mục đích sử dụng");
            SetCaption(gvRegister, "NgayVe", "Ngày về");
            SetCaption(gvRegister, "TaiSanCoDinh", "Tài sản cố định");
            SetCaption(gvRegister, "TrangThaiDangKy", "Trạng thái (đăng ký)");

            SetCaption(gvRegister, "CreateAt", "Ngày tạo đăng ký");
            SetCaption(gvRegister, "CreateBy", "Người đăng ký");
            SetCaption(gvRegister, "ApproveBy", "Người duyệt");
            SetCaption(gvRegister, "ApproveAt", "Ngày duyệt");
            SetCaption(gvRegister, "NgayDuyetHienThi", "Ngày duyệt (hiển thị)");

            // Ẩn cột kỹ thuật nếu bạn không cần show
            if (gvRegister.Columns["FactoryID"] != null) gvRegister.Columns["FactoryID"].Visible = false;
            if (gvRegister.Columns["TypeID"] != null) gvRegister.Columns["TypeID"].Visible = false;

            // Format Date
            FormatDate(gvRegister, "NgayVe", "dd/MM/yyyy");
            FormatDateTime(gvRegister, "CreateAt");
            FormatDateTime(gvRegister, "ApproveAt");
            FormatDateTime(gvRegister, "NgayDuyetHienThi");

            gvRegister.OptionsBehavior.Editable = false;
            gvRegister.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvRegister.OptionsView.ShowGroupPanel = false;

            gvRegister.BestFitColumns();
        }

        // ======================================================
        // 2) LOAD DEVICE HISTORY (TBL_DEVICE_MST)
        // ======================================================
        private void LoadDeviceHistory()
        {
            try
            {
                string sql = @"
SELECT
    -- STT: unbound
    D.MaQuanLy,
    D.TenThietBi,
    D.SerialNo,
    D.Model,
    D.NhaCungCap,
    D.MucDichSuDung,
    D.NhaMay,

    S.StatusName AS TrangThaiSuDung,

    D.CREATE_DATE,
    D.CREATE_BY
FROM dbo.TBL_DEVICE_MST D
LEFT JOIN dbo.TBL_DEVICE_STATUS S
    ON D.StatusID = S.StatusID
WHERE ISNULL(D.Huy, 0) = 0
";

                DateTime? from = GetFromDate();
                DateTime? to = GetToDate();

                // lọc theo ngày sử dụng = CREATE_DATE
                if (from.HasValue) sql += " AND D.CREATE_DATE >= @FromDate";
                if (to.HasValue) sql += " AND D.CREATE_DATE <= @ToDate";

                sql += " ORDER BY D.CREATE_DATE DESC";

                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    if (from.HasValue) cmd.Parameters.AddWithValue("@FromDate", from.Value);
                    if (to.HasValue) cmd.Parameters.AddWithValue("@ToDate", to.Value);


                    new SqlDataAdapter(cmd).Fill(dt);
                }

                gcDevice.DataSource = dt;
                BuildDeviceGrid();
            }
            catch
            {
                MessageBox.Show("Lỗi load lịch sử sử dụng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuildDeviceGrid()
        {
            // STT
            if (gvDevice.Columns["STT"] == null)
            {
                var col = gvDevice.Columns.AddField("STT");
                col.Caption = "STT";
                col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                col.VisibleIndex = 0;
                col.Width = 50;
                col.OptionsColumn.AllowEdit = false;
                col.OptionsColumn.ReadOnly = true;
            }

            // Caption
            SetCaption(gvDevice, "MaQuanLy", "Mã quản lý");
            SetCaption(gvDevice, "TenThietBi", "Tên thiết bị");
            SetCaption(gvDevice, "SerialNo", "Serial");
            SetCaption(gvDevice, "Model", "Model");
            SetCaption(gvDevice, "NhaCungCap", "Nhà cung cấp");
            SetCaption(gvDevice, "MucDichSuDung", "Mục đích sử dụng");
            SetCaption(gvDevice, "NhaMay", "Nhà máy");
            SetCaption(gvDevice, "TrangThaiSuDung", "Trạng thái sử dụng");

            SetCaption(gvDevice, "CREATE_DATE", "Ngày sử dụng");
            SetCaption(gvDevice, "CREATE_BY", "Người thêm vào sử dụng");

            // Format DateTime
            FormatDateTime(gvDevice, "CREATE_DATE");

            gvDevice.OptionsBehavior.Editable = false;
            gvDevice.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvDevice.OptionsView.ShowGroupPanel = false;

            gvDevice.BestFitColumns();
        }

        // ======================================================
        // UI HELPERS
        // ======================================================
        private void SetCaption(DevExpress.XtraGrid.Views.Grid.GridView gv, string field, string caption)
        {
            if (gv.Columns[field] != null)
                gv.Columns[field].Caption = caption;
        }

        private void FormatDate(DevExpress.XtraGrid.Views.Grid.GridView gv, string field, string fmt)
        {
            if (gv.Columns[field] == null) return;
            gv.Columns[field].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gv.Columns[field].DisplayFormat.FormatString = fmt;
        }

        private void FormatDateTime(DevExpress.XtraGrid.Views.Grid.GridView gv, string field)
        {
            if (gv.Columns[field] == null) return;
            gv.Columns[field].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gv.Columns[field].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
        }
    }
}
