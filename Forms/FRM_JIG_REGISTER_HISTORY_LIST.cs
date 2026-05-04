using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_REGISTER_HISTORY_LIST : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigRegisterService _service = new JigRegisterService();

        public FRM_JIG_REGISTER_HISTORY_LIST()
        {
            InitializeComponent();
        }

        private void FRM_JIG_REGISTER_HISTORY_LIST_Load(object sender, EventArgs e)
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
        }

        private void LoadData()
        {
            gcHistory.DataSource = _service.GetRegisterHistory();
            BuildColumns();
            lblRecordValue.Text = gvHistory.RowCount.ToString();
            lblModeValue.Text = "View";
        }

        private void BuildColumns()
        {
            gvHistory.Columns.Clear();
            gvHistory.Columns.AddVisible("MANAGEMENT_NO", "Control No.");
            gvHistory.Columns.AddVisible("REQUEST_STATUS_TEXT", "Trạng thái");
            gvHistory.Columns.AddVisible("JIG_NAME", "Tên Jig");
            gvHistory.Columns.AddVisible("JIG_TYPE_NAME", "Loại Jig");
            gvHistory.Columns.AddVisible("JIG_SIZE", "Size");
            gvHistory.Columns.AddVisible("USE_PRODUCT", "Sản phẩm sử dụng");
            gvHistory.Columns.AddVisible("LOCATION_CODE", "Vị trí");
            gvHistory.Columns.AddVisible("DEPARTMENT", "Bộ phận đăng ký");
            gvHistory.Columns.AddVisible("REQUEST_AT", "Ngày đăng ký");
            gvHistory.Columns.AddVisible("REQUEST_BY", "Người đăng ký");
            gvHistory.Columns.AddVisible("FIRST_CHECK_RESULT_FILE", "Kết quả kiểm tra lần đầu");

            if (gvHistory.Columns["REQUEST_AT"] != null)
            {
                gvHistory.Columns["REQUEST_AT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gvHistory.Columns["REQUEST_AT"].DisplayFormat.FormatString = "dd-MM-yy";
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
            if (e.Column.FieldName != "REQUEST_STATUS_TEXT") return;
            var VALUE = Convert.ToString(gvHistory.GetRowCellValue(e.RowHandle, "REQUEST_STATUS_TEXT"));
            if (string.Equals(VALUE, "Đã phê duyệt", StringComparison.OrdinalIgnoreCase))
            {
                e.Appearance.BackColor = Color.YellowGreen;
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
            else if (string.Equals(VALUE, "Chưa được phê duyệt", StringComparison.OrdinalIgnoreCase))
            {
                e.Appearance.BackColor = Color.Gold;
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
                DIALOG.FileName = $"Jig_Register_History_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                if (DIALOG.ShowDialog() != DialogResult.OK) return;
                gcHistory.ExportToXlsx(DIALOG.FileName);
                MessageBox.Show("Đã xuất file thành công.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
