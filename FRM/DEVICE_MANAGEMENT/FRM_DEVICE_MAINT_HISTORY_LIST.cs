using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_DEVICE_MAINT_HISTORY_LIST : XtraForm
    {
        public FRM_DEVICE_MAINT_HISTORY_LIST()
        {
            InitializeComponent();
        }

        private void FRM_DEVICE_MAINT_HISTORY_LIST_Load(object sender, EventArgs e)
        {
            // Default: 30 ngày gần nhất
            dtTo.EditValue = DateTime.Today;
            dtFrom.EditValue = DateTime.Today.AddDays(-30);

            // Grid events
            gvData.CustomUnboundColumnData += gvData_CustomUnboundColumnData;

            SetupGridView();
            LoadData();
        }

        // ============================
        // GRID SETUP
        // ============================
        private void SetupGridView()
        {
            gvData.OptionsBehavior.Editable = false;
            gvData.OptionsView.ShowGroupPanel = false;
            gvData.OptionsView.ShowAutoFilterRow = true;
            gvData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;

            gvData.Appearance.HeaderPanel.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            gvData.Appearance.HeaderPanel.Options.UseFont = true;

            gvData.Appearance.Row.Font = new Font("Tahoma", 9F);
            gvData.Appearance.Row.Options.UseFont = true;
        }

        private void EnsureSTTColumn()
        {
            if (gvData.Columns["STT"] == null)
            {
                var col = gvData.Columns.AddField("STT");
                col.Caption = "STT";
                col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                col.VisibleIndex = 0;
                col.Width = 45;
                col.OptionsColumn.AllowEdit = false;
                col.OptionsColumn.ReadOnly = true;
                //col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        private void gvData_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "STT" && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }

        // ============================
        // LOAD DATA (WITH FILTER)
        // ============================
        private void LoadData()
        {
            try
            {
                string maQL = "";
                DateTime? from = dtFrom.EditValue as DateTime?;
                DateTime? to = dtTo.EditValue as DateTime?;

                // To: lấy hết ngày (23:59:59)
                DateTime? toEnd = null;
                if (to.HasValue)
                {
                    toEnd = to.Value.Date.AddDays(1).AddSeconds(-1);
                }

                string sql = @"
SELECT
    HistoryID,
    MaQuanLy,
    TenThietBi,
    OldNgayBaoDuong,
    NewNgayBaoDuong,
    OldKeHoach,
    NewKeHoach,
    UpdateAt,
    UpdateBy
FROM TBL_DEVICE_MAINT_HISTORY
WHERE 1=1
  AND (@MaQL = '' OR MaQuanLy = @MaQL)
  AND (@From IS NULL OR UpdateAt >= @From)
  AND (@To IS NULL OR UpdateAt <= @To)
ORDER BY UpdateAt DESC, HistoryID DESC;";

                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaQL", maQL ?? "");
                    cmd.Parameters.AddWithValue("@From", (object)(from.HasValue ? from.Value.Date : (DateTime?)null) ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@To", (object)(toEnd.HasValue ? toEnd.Value : (DateTime?)null) ?? DBNull.Value);

                    conn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(dt);
                    }
                }

                gcData.DataSource = dt;

                EnsureSTTColumn();
                ApplyCaptionsAndFormats();
                HideTechColumns();

                gvData.BestFitColumns();
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu lịch sử!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyCaptionsAndFormats()
        {
            if (gvData.Columns["MaQuanLy"] != null) gvData.Columns["MaQuanLy"].Caption = "Mã quản lý";
            if (gvData.Columns["TenThietBi"] != null) gvData.Columns["TenThietBi"].Caption = "Tên thiết bị";

            if (gvData.Columns["OldNgayBaoDuong"] != null) gvData.Columns["OldNgayBaoDuong"].Caption = "BD cũ";
            if (gvData.Columns["NewNgayBaoDuong"] != null) gvData.Columns["NewNgayBaoDuong"].Caption = "BD mới";
            if (gvData.Columns["OldKeHoach"] != null) gvData.Columns["OldKeHoach"].Caption = "KH cũ";
            if (gvData.Columns["NewKeHoach"] != null) gvData.Columns["NewKeHoach"].Caption = "KH mới";

            if (gvData.Columns["UpdateAt"] != null) gvData.Columns["UpdateAt"].Caption = "Thời gian cập nhật";
            if (gvData.Columns["UpdateBy"] != null) gvData.Columns["UpdateBy"].Caption = "Người cập nhật";

            // Format datetime
            SetDateFormat("OldNgayBaoDuong");
            SetDateFormat("NewNgayBaoDuong");
            SetDateFormat("OldKeHoach");
            SetDateFormat("NewKeHoach");
            SetDateTimeFormat("UpdateAt");
        }

        private void SetDateFormat(string fieldName)
        {
            var col = gvData.Columns[fieldName];
            if (col == null) return;

            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.DisplayFormat.FormatString = "dd/MM/yyyy";
        }

        private void SetDateTimeFormat(string fieldName)
        {
            var col = gvData.Columns[fieldName];
            if (col == null) return;

            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
        }

        private void HideTechColumns()
        {
            if (gvData.Columns["HistoryID"] != null)
                gvData.Columns["HistoryID"].Visible = false;
        }

        // ============================
        // BUTTONS
        // ============================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Constaint._exportGridViewXlsx(gvData, gcData);
            }
            catch
            {
                MessageBox.Show("Không export được file!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetupGridView();
            LoadData();
        }
    }
}
