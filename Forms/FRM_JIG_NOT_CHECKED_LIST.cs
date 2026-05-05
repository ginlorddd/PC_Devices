using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_NOT_CHECKED_LIST : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigFunctionService _service = new JigFunctionService();

        public FRM_JIG_NOT_CHECKED_LIST()
        {
            InitializeComponent();
        }

        private void FRM_JIG_NOT_CHECKED_LIST_Load(object sender, EventArgs e)
        {
            SetupGridFormat(gvJig);
            LoadData();
        }

        private void SetupGridFormat(GridView VIEW)
        {
            VIEW.OptionsView.ShowAutoFilterRow = true;
            VIEW.OptionsView.ShowGroupPanel = false;
            VIEW.Appearance.HeaderPanel.Font = new Font(VIEW.Appearance.HeaderPanel.Font, FontStyle.Bold);
            VIEW.Appearance.HeaderPanel.Options.UseFont = true;
            VIEW.OptionsView.ColumnAutoWidth = false;
            VIEW.RowCellStyle += GvJig_RowCellStyle;
        }

        private void LoadData()
        {
            gcJig.DataSource = _service.GetNotCheckedJigs(DateTime.Today);
            BuildColumns();
            lblRecordValue.Text = gvJig.RowCount.ToString();
            lblModeValue.Text = "View";
        }

        private void BuildColumns()
        {
            gvJig.Columns.Clear();
            gvJig.Columns.AddVisible("CONTROL_NO", "Control No.");
            gvJig.Columns.AddVisible("JIG_NAME", "Tên Jig");
            gvJig.Columns.AddVisible("JIG_TYPE_NAME", "Loại Jig");
            gvJig.Columns.AddVisible("JIG_SIZE", "Size");
            gvJig.Columns.AddVisible("NEXT_CHECK_PLAN_DATE", "Kế hoạch kiểm tra");
            gvJig.Columns.AddVisible("USE_SECTION", "Bộ phận sử dụng");
            gvJig.Columns.AddVisible("CHECK_RESULT", "Nhập dữ liệu kết quả kiểm tra");

            if (gvJig.Columns["NEXT_CHECK_PLAN_DATE"] != null)
            {
                gvJig.Columns["NEXT_CHECK_PLAN_DATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gvJig.Columns["NEXT_CHECK_PLAN_DATE"].DisplayFormat.FormatString = "MMM-yy";
            }

            foreach (DevExpress.XtraGrid.Columns.GridColumn C in gvJig.Columns)
            {
                C.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                C.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            gvJig.BestFitColumns();
        }

        private void GvJig_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName != "NEXT_CHECK_PLAN_DATE") return;

            var VALUE = gvJig.GetRowCellValue(e.RowHandle, "NEXT_CHECK_PLAN_DATE");
            if (VALUE == null || VALUE == DBNull.Value) return;

            DateTime PLAN_DATE;
            if (!DateTime.TryParse(Convert.ToString(VALUE), out PLAN_DATE)) return;

            var TODAY = DateTime.Today;
            if (PLAN_DATE.Date < TODAY)
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
            else if (PLAN_DATE.Year == TODAY.Year && PLAN_DATE.Month == TODAY.Month)
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
                DIALOG.FileName = $"Jig_Not_Checked_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                if (DIALOG.ShowDialog() != DialogResult.OK) return;
                gcJig.ExportToXlsx(DIALOG.FileName);
                MessageBox.Show("Đã xuất file thành công.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var ROW_HANDLE = gvJig.FocusedRowHandle;
            if (ROW_HANDLE < 0) return;
            var CONTROL_NO = Convert.ToString(gvJig.GetRowCellValue(ROW_HANDLE, "CONTROL_NO"));
            if (string.IsNullOrWhiteSpace(CONTROL_NO)) return;

            using (var FORM = new FRM_JIG_REGISTER(CONTROL_NO.Trim()))
            {
                FORM.ShowDialog(this);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
