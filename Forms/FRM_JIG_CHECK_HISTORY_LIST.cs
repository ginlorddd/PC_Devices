using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_CHECK_HISTORY_LIST : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigFunctionService _service = new JigFunctionService();

        public FRM_JIG_CHECK_HISTORY_LIST()
        {
            InitializeComponent();
        }

        private void FRM_JIG_CHECK_HISTORY_LIST_Load(object sender, EventArgs e)
        {
            SetupGridFormat(gvHistory);
            LoadData();
        }

        private void SetupGridFormat(GridView VIEW)
        {
            VIEW.OptionsView.ShowAutoFilterRow = true;
            VIEW.OptionsView.ShowGroupPanel = false;
            VIEW.Appearance.HeaderPanel.Font = new Font(VIEW.Appearance.HeaderPanel.Font, FontStyle.Bold);
            VIEW.Appearance.HeaderPanel.Options.UseFont = true;
            VIEW.OptionsView.ColumnAutoWidth = false;
            VIEW.RowCellStyle += gvHistory_RowCellStyle;
            VIEW.DoubleClick += gvHistory_DoubleClick;
        }

        private void LoadData()
        {
            gcHistory.DataSource = _service.GetJigCheckHistory();
            BuildColumns();
            lblRecordValue.Text = gvHistory.RowCount.ToString();
            lblModeValue.Text = "View";
        }

        private void BuildColumns()
        {
            gvHistory.Columns.Clear();
            gvHistory.Columns.AddVisible("CONTROL_NO", "Control No.");
            gvHistory.Columns.AddVisible("JIG_NAME", "Tên Jig");
            gvHistory.Columns.AddVisible("JIG_TYPE_NAME", "Loại Jig");
            gvHistory.Columns.AddVisible("JIG_SIZE", "Size");
            gvHistory.Columns.AddVisible("USE_PRODUCT", "Sản phẩm sử dụng");
            gvHistory.Columns.AddVisible("LOCATION_CODE", "Vị trí");
            gvHistory.Columns.AddVisible("STATUS_USE", "Trạng thái sử dụng");
            gvHistory.Columns.AddVisible("USE_SECTION", "Bộ phận sử dụng");
            gvHistory.Columns.AddVisible("LAST_CHECK_DATE", "Ngày kiểm tra định kỳ");
            gvHistory.Columns.AddVisible("CHECK_RESULT", "Kết quả kiểm tra định kỳ");
            gvHistory.Columns.AddVisible("REPORT_FILE", "Báo cáo kiểm tra");
            gvHistory.Columns.AddVisible("CHECK_BY", "Người kiểm tra");
            gvHistory.Columns.AddVisible("CHECKER_BY", "Người check");
            gvHistory.Columns.AddVisible("APPROVE_BY", "Người duyệt");
            gvHistory.Columns.AddVisible("NOTE", "Ghi chú");

            var colJigId = gvHistory.Columns.AddVisible("JIG_ID", "JIG_ID");
            colJigId.Visible = false;

            if (gvHistory.Columns["LAST_CHECK_DATE"] != null)
            {
                gvHistory.Columns["LAST_CHECK_DATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gvHistory.Columns["LAST_CHECK_DATE"].DisplayFormat.FormatString = "dd-MM-yy";
            }

            foreach (DevExpress.XtraGrid.Columns.GridColumn C in gvHistory.Columns)
            {
                C.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                C.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            gvHistory.BestFitColumns();
        }

        private void gvHistory_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName != "CHECK_RESULT") return;
            var VALUE = Convert.ToString(gvHistory.GetRowCellValue(e.RowHandle, "CHECK_RESULT"));
            if (string.Equals(VALUE, "OK", StringComparison.OrdinalIgnoreCase))
            {
                e.Appearance.BackColor = Color.YellowGreen;
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var DIALOG = new SaveFileDialog())
            {
                DIALOG.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                DIALOG.FileName = $"Jig_Check_History_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                if (DIALOG.ShowDialog() != DialogResult.OK) return;
                gcHistory.ExportToXlsx(DIALOG.FileName);
                MessageBox.Show("Đã xuất file thành công.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AppSession.UserId) || !string.Equals(AppSession.RoleCode, "ADMIN", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Chỉ người quản lý (ADMIN) mới có quyền duyệt báo cáo.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gvHistory.FocusedRowHandle < 0) return;
            var VALUE = gvHistory.GetRowCellValue(gvHistory.FocusedRowHandle, "JIG_ID");
            int JIG_ID;
            if (VALUE == null || VALUE == DBNull.Value || !int.TryParse(Convert.ToString(VALUE), out JIG_ID)) return;

            var AFFECTED = _service.ApproveJigCheck(JIG_ID, AppSession.UserId);
            if (AFFECTED > 0)
            {
                MessageBox.Show("Đã duyệt báo cáo kiểm tra Jig.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu kiểm tra để duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gvHistory_DoubleClick(object sender, EventArgs e)
        {
            var HIT = gvHistory.CalcHitInfo(gvHistory.GridControl.PointToClient(Cursor.Position));
            if (!HIT.InRowCell || HIT.Column == null) return;
            if (!string.Equals(HIT.Column.FieldName, "REPORT_FILE", StringComparison.OrdinalIgnoreCase)) return;

            var VALUE = gvHistory.GetRowCellValue(HIT.RowHandle, "REPORT_FILE");
            var FILE_PATH = Convert.ToString(VALUE);
            if (string.IsNullOrWhiteSpace(FILE_PATH)) return;

            using (var FORM = new FRM_PDF_VIEWER_ADV(FILE_PATH))
            {
                FORM.ShowDialog(this);
            }
        }
    }
}
