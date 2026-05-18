using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_FORM_MASTER : DevExpress.XtraEditors.XtraForm
    {
        private readonly FormMasterService _service = new FormMasterService();
        private string _templatePath = string.Empty;

        public FRM_FORM_MASTER() { InitializeComponent(); }

        private void FRM_FORM_MASTER_Load(object sender, EventArgs e)
        {
            gvForm.OptionsView.ShowAutoFilterRow = true;
            gvForm.OptionsView.ColumnAutoWidth = false;
            LoadData();
        }

        private void LoadData()
        {
            gcForm.DataSource = _service.GetFormMasters();
            gvForm.BestFitColumns();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var d = new OpenFileDialog { Filter = "Excel (*.xlsx)|*.xlsx" })
            {
                if (d.ShowDialog() != DialogResult.OK) return;
                _templatePath = d.FileName;
                txtTemplatePath.Text = _templatePath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var code = txtFormCode.Text.Trim();
            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(txtFormName.Text)) { MessageBox.Show("Thiếu mã/tên form"); return; }
            var stored = _templatePath;
            if (!string.IsNullOrWhiteSpace(_templatePath) && File.Exists(_templatePath))
            {
                var folder = Path.Combine(StorageConfig.FolderFileUpload, "FormMasters", code);
                Directory.CreateDirectory(folder);
                var target = Path.Combine(folder, Path.GetFileName(_templatePath));
                if (!string.Equals(Path.GetFullPath(_templatePath), Path.GetFullPath(target), StringComparison.OrdinalIgnoreCase))
                    File.Copy(_templatePath, target, true);
                stored = target;
            }

            _service.UpsertFormMaster(code, txtFormName.Text.Trim(), txtVersion.Text.Trim(), txtDescription.Text.Trim(), stored,
                txtPartNameCell.Text.Trim(), txtControlNoCell.Text.Trim(), txtDateCell.Text.Trim(), chkDefault.Checked, chkActive.Checked);
            MessageBox.Show("Đã lưu form master");
            LoadData();
        }

        private void gvForm_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var r = gvForm.GetDataRow(e.FocusedRowHandle); if (r == null) return;
            txtFormCode.Text = Convert.ToString(r["FORM_CODE"]);
            txtFormName.Text = Convert.ToString(r["FORM_NAME"]);
            txtVersion.Text = Convert.ToString(r["FORM_VERSION"]);
            txtDescription.Text = Convert.ToString(r["DESCRIPTION"]);
            txtTemplatePath.Text = Convert.ToString(r["TEMPLATE_FILE_PATH"]);
            _templatePath = txtTemplatePath.Text;
            txtPartNameCell.Text = Convert.ToString(r["PART_NAME_CELL"]);
            txtControlNoCell.Text = Convert.ToString(r["CONTROL_NO_CELL"]);
            txtDateCell.Text = Convert.ToString(r["CHECK_DATE_CELL"]);
            chkDefault.Checked = r["IS_DEFAULT"] != DBNull.Value && Convert.ToBoolean(r["IS_DEFAULT"]);
            chkActive.Checked = r["IS_ACTIVE"] != DBNull.Value && Convert.ToBoolean(r["IS_ACTIVE"]);
        }

        private void btnGenerateSample_Click(object sender, EventArgs e)
        {
            if (gvForm.FocusedRowHandle < 0) return;
            var r = gvForm.GetDataRow(gvForm.FocusedRowHandle); if (r == null) return;
            var template = Convert.ToString(r["TEMPLATE_FILE_PATH"]);
            if (string.IsNullOrWhiteSpace(template) || !File.Exists(template)) { MessageBox.Show("Không tìm thấy template"); return; }
            using (var s = new SaveFileDialog { Filter = "Excel (*.xlsx)|*.xlsx", FileName = "Filled_Form.xlsx" })
            {
                if (s.ShowDialog() != DialogResult.OK) return;
                File.Copy(template, s.FileName, true);
                FillExcelByCell(s.FileName, Convert.ToString(r["PART_NAME_CELL"]), "JIG SAMPLE",
                    Convert.ToString(r["CONTROL_NO_CELL"]), "CTRL-001",
                    Convert.ToString(r["CHECK_DATE_CELL"]), DateTime.Now.ToString("dd-MM-yyyy"));
                MessageBox.Show("Đã tạo file mẫu điền sẵn.");
            }
        }

        private void FillExcelByCell(string filePath, string partCell, string partValue, string noCell, string noValue, string dateCell, string dateValue)
        {
            Type excelType = Type.GetTypeFromProgID("Excel.Application");
            if (excelType == null) { MessageBox.Show("Máy chưa cài Microsoft Excel."); return; }
            dynamic excel = Activator.CreateInstance(excelType);
            dynamic wb = null; dynamic ws = null;
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
