using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_NOT_CHECKED_LIST : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigFunctionService _service = new JigFunctionService();
        private readonly FormMasterService _formService = new FormMasterService();

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
            VIEW.DoubleClick += GvJig_DoubleClick;
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
            OpenAndFillCheckForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GvJig_DoubleClick(object sender, EventArgs e)
        {
            var hit = gvJig.CalcHitInfo(gvJig.GridControl.PointToClient(Cursor.Position));
            if (!hit.InRowCell || hit.Column == null) return;
            if (!string.Equals(hit.Column.FieldName, "CHECK_RESULT", StringComparison.OrdinalIgnoreCase)) return;
            OpenAndFillCheckForm();
        }

        private void OpenAndFillCheckForm()
        {
            var rowHandle = gvJig.FocusedRowHandle;
            if (rowHandle < 0) return;

            var jigTypeCode = Convert.ToString(gvJig.GetRowCellValue(rowHandle, "JIG_TYPE_CODE"));
            var reportFormCode = Convert.ToString(gvJig.GetRowCellValue(rowHandle, "REPORT_FORM_CODE"));
            var controlNo = Convert.ToString(gvJig.GetRowCellValue(rowHandle, "CONTROL_NO"));
            var jigName = Convert.ToString(gvJig.GetRowCellValue(rowHandle, "JIG_NAME"));
            var nextCheckDate = Convert.ToString(gvJig.GetRowCellValue(rowHandle, "NEXT_CHECK_PLAN_DATE"));
            if (string.IsNullOrWhiteSpace(jigTypeCode) || string.IsNullOrWhiteSpace(controlNo))
            {
                MessageBox.Show("Thiếu dữ liệu Jig Type hoặc Control No.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow formRow = null;
            if (!string.IsNullOrWhiteSpace(reportFormCode))
            {
                formRow = _formService.GetFormByCode(reportFormCode);
            }

            if (formRow == null)
            {
                MessageBox.Show("Jig này chưa có Form Master trong Jig Master. Vui lòng cấu hình từ FRM Register trước khi nhập kết quả kiểm tra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var templatePath = Convert.ToString(formRow["TEMPLATE_FILE_PATH"]);
            if (string.IsNullOrWhiteSpace(templatePath) || !File.Exists(templatePath))
            {
                MessageBox.Show("Không tìm thấy file form mẫu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var outputFolder = Path.Combine(StorageConfig.FolderFileUpload, "CheckResultForms", controlNo, DateTime.Now.ToString("yyyyMM"));
            Directory.CreateDirectory(outputFolder);
            var outputPath = Path.Combine(outputFolder, $"{controlNo}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            File.Copy(templatePath, outputPath, true);

            FillExcelByCell(outputPath,
                Convert.ToString(formRow["PART_NAME_CELL"]), jigName,
                Convert.ToString(formRow["CONTROL_NO_CELL"]), controlNo,
                Convert.ToString(formRow["CHECK_DATE_CELL"]), string.IsNullOrWhiteSpace(nextCheckDate) ? DateTime.Now.ToString("dd-MM-yyyy") : Convert.ToDateTime(nextCheckDate).ToString("dd-MM-yyyy"));

            Process.Start(outputPath);
        }

        private void FillExcelByCell(string filePath, string partCell, string partValue, string noCell, string noValue, string dateCell, string dateValue)
        {
            Type excelType = Type.GetTypeFromProgID("Excel.Application");
            if (excelType == null) throw new InvalidOperationException("Máy chưa cài Microsoft Excel.");
            dynamic excel = Activator.CreateInstance(excelType);
            dynamic wb = null;
            dynamic ws = null;
            try
            {
                excel.DisplayAlerts = false;
                wb = excel.Workbooks.Open(filePath);
                ws = wb.Worksheets[1];
                if (!string.IsNullOrWhiteSpace(partCell)) ws.Range[partCell].Value = partValue;
                if (!string.IsNullOrWhiteSpace(noCell)) ws.Range[noCell].Value = noValue;
                if (!string.IsNullOrWhiteSpace(dateCell)) ws.Range[dateCell].Value = dateValue;
                wb.Save();
            }
            finally
            {
                if (wb != null) wb.Close();
                excel.Quit();
                if (ws != null) Marshal.ReleaseComObject(ws);
                if (wb != null) Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(excel);
            }
        }
    }
}
