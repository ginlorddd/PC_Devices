using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PC_Devices.DB;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_DEVICE_CANCEL_HISTORY : XtraForm
    {
        public FRM_DEVICE_CANCEL_HISTORY()
        {
            InitializeComponent();
        }

        // ======================================================
        // LOAD
        // ======================================================
        private void FRM_DEVICE_CANCEL_HISTORY_Load(object sender, EventArgs e)
        {
            //cboStatus.SelectedIndex = 0; // Tất cả
            LoadData();
        }

        // ======================================================
        // LOAD DATA
        // ======================================================
        private void LoadData()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(@"
SELECT
    D.MaQuanLy,
    D.TenThietBi,
    D.NhaMay,
    T.[Type]            AS LoaiThietBi,

    D.CancelReason     AS LyDoHuy,
    D.CancelImpact     AS AnhHuongSanXuat,
    D.CancelPlanDate   AS NgayHuyDuKien,

    D.CancelRequestBy,
    D.CancelRequestAt,
    D.CancelApproveBy,
    D.CancelApproveAt,

    D.StatusID
FROM dbo.TBL_DEVICE_MST D
LEFT JOIN dbo.TBL_DEVICE_TYPE T
    ON D.TypeID = T.TypeID
WHERE D.CancelRequestAt IS NOT NULL
");

                // ===============================
                // FILTER: STATUS
                // ===============================
                //if (cboStatus.SelectedIndex == 1) // Chờ duyệt hủy
                //    sql.Append(" AND D.StatusID = 5 ");
                //else if (cboStatus.SelectedIndex == 2) // Đã hủy
                //    sql.Append(" AND D.StatusID = 4 ");

                // ===============================
                // FILTER: DATE
                // ===============================
                if (dtFrom.EditValue != null)
                {
                    sql.Append($" AND D.CancelRequestAt >= '{Convert.ToDateTime(dtFrom.EditValue):yyyy-MM-dd 00:00:00}' ");
                }

                if (dtTo.EditValue != null)
                {
                    sql.Append($" AND D.CancelRequestAt <= '{Convert.ToDateTime(dtTo.EditValue):yyyy-MM-dd 23:59:59}' ");
                }

                // ===============================
                // FILTER: SEARCH
                // ===============================
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    string key = txtSearch.Text.Trim().Replace("'", "''");
                    sql.Append($@"
 AND (
        D.MaQuanLy LIKE N'%{key}%'
     OR D.TenThietBi LIKE N'%{key}%'
     OR D.CancelReason LIKE N'%{key}%'
     OR D.CancelRequestBy LIKE N'%{key}%'
     OR D.CancelApproveBy LIKE N'%{key}%'
 )
");
                }

                sql.Append(" ORDER BY D.CancelRequestAt DESC ");

                DataTable dt = DBUtils._getData(sql.ToString()) ?? new DataTable();
                gcData.DataSource = dt;

                BuildGridCaption();
                gvData.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadData:\n" + ex.Message);
            }
        }

        // ======================================================
        // GRID CAPTION + FORMAT
        // ======================================================
        private void BuildGridCaption()
        {
            if (gvData.Columns["MaQuanLy"] != null)
                gvData.Columns["MaQuanLy"].Caption = "Mã quản lý";

            if (gvData.Columns["TenThietBi"] != null)
                gvData.Columns["TenThietBi"].Caption = "Tên thiết bị";

            if (gvData.Columns["NhaMay"] != null)
                gvData.Columns["NhaMay"].Caption = "Nhà máy";

            if (gvData.Columns["LoaiThietBi"] != null)
                gvData.Columns["LoaiThietBi"].Caption = "Loại thiết bị";

            if (gvData.Columns["LyDoHuy"] != null)
                gvData.Columns["LyDoHuy"].Caption = "Lý do hủy";

            if (gvData.Columns["AnhHuongSanXuat"] != null)
                gvData.Columns["AnhHuongSanXuat"].Caption = "Ảnh hưởng SX";

            if (gvData.Columns["NgayHuyDuKien"] != null)
            {
                gvData.Columns["NgayHuyDuKien"].Caption = "Ngày hủy dự kiến";
                gvData.Columns["NgayHuyDuKien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gvData.Columns["NgayHuyDuKien"].DisplayFormat.FormatString = "dd/MM/yyyy";
            }

            if (gvData.Columns["CancelRequestBy"] != null)
                gvData.Columns["CancelRequestBy"].Caption = "Người đăng ký hủy";

            if (gvData.Columns["CancelRequestAt"] != null)
            {
                gvData.Columns["CancelRequestAt"].Caption = "Ngày đăng ký";
                gvData.Columns["CancelRequestAt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gvData.Columns["CancelRequestAt"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }

            if (gvData.Columns["CancelApproveBy"] != null)
                gvData.Columns["CancelApproveBy"].Caption = "Người duyệt";

            if (gvData.Columns["CancelApproveAt"] != null)
            {
                gvData.Columns["CancelApproveAt"].Caption = "Ngày duyệt";
                gvData.Columns["CancelApproveAt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gvData.Columns["CancelApproveAt"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }

            if (gvData.Columns["StatusID"] != null)
                gvData.Columns["StatusID"].Visible = false;
        }

        // ======================================================
        // FILTER CHANGED
        // ======================================================
        private void FilterChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        // ======================================================
        // BUTTONS
        // ======================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Constaint._exportGridViewXlsx(gvData, gcData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ======================================================
        // ROW STYLE (STATUS)
        // ======================================================
        private void gvData_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName != "TenThietBi") return;

            object val = gvData.GetRowCellValue(e.RowHandle, "StatusID");
            if (val == null || val == DBNull.Value) return;

            int status = Convert.ToInt32(val);

            if (status == 5) // Chờ duyệt hủy
            {
                e.Appearance.BackColor = Color.Gold;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
            else if (status == 4) // Đã hủy
            {
                e.Appearance.BackColor = Color.LightCoral;
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        // ======================================================
        // DOUBLE CLICK (OPTIONAL)
        // ======================================================
        private void gvData_DoubleClick(object sender, EventArgs e)
        {
            if (gvData.FocusedRowHandle < 0) return;

            string lyDo = gvData.GetFocusedRowCellValue("LyDoHuy")?.ToString();
            string ghiChu = gvData.GetFocusedRowCellValue("AnhHuongSanXuat")?.ToString();

            XtraMessageBox.Show(
                $"Lý do hủy:\n{lyDo}\n\nẢnh hưởng sản xuất:\n{ghiChu}",
                "Chi tiết hủy thiết bị",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
