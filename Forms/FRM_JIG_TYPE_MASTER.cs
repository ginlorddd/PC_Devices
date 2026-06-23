using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using System.IO;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_TYPE_MASTER : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigTypeMasterService _service = new JigTypeMasterService();
        private string _selectedDrawingFilePath = string.Empty;

        public FRM_JIG_TYPE_MASTER()
        {
            InitializeComponent();
        }

        private void FRM_JIG_TYPE_MASTER_Load(object sender, EventArgs e)
        {
            lblDrawingCode.Visible = false;
            txtDrawingCode.Visible = false;
            lblDrawingPath.Visible = false;
            txtDrawingFilePath.Visible = false;
            cboJigTypeMain.Properties.Items.Clear();
            cboJigTypeMain.Properties.Items.AddRange(new object[] { "FUNCTION", "VISUAL" });
            cboJigTypeMain.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            SetupGridFormat(gvJigType);
            gvJigType.DoubleClick += gvJigType_DoubleClick;
            LoadData();
        }

        private void SetupGridFormat(GridView VIEW)
        {
            VIEW.OptionsView.ShowAutoFilterRow = true;
            VIEW.OptionsView.ShowGroupPanel = false;
            VIEW.Appearance.HeaderPanel.Font = new Font(VIEW.Appearance.HeaderPanel.Font, FontStyle.Bold);
            VIEW.Appearance.HeaderPanel.Options.UseFont = true;
            VIEW.OptionsView.ColumnAutoWidth = false;
            VIEW.OptionsBehavior.Editable = false;
            VIEW.OptionsBehavior.ReadOnly = true;
            VIEW.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        private void LoadData()
        {
            gcJigType.DataSource = _service.GetJigTypeMasters();
            gvJigType.PopulateColumns();

            if (gvJigType.Columns["STT"] != null)
            {
                gvJigType.Columns["STT"].Caption = "STT";
                gvJigType.Columns["STT"].VisibleIndex = 0;
                gvJigType.Columns["STT"].Width = 60;
            }

            if (gvJigType.Columns["JIG_TYPE_CODE"] != null)
            {
                gvJigType.Columns["JIG_TYPE_CODE"].Caption = "Mã loại Jig";
                gvJigType.Columns["JIG_TYPE_CODE"].VisibleIndex = 1;
            }

            if (gvJigType.Columns["JIG_TYPE_NAME"] != null)
            {
                gvJigType.Columns["JIG_TYPE_NAME"].Caption = "Tên loại Jig";
                gvJigType.Columns["JIG_TYPE_NAME"].VisibleIndex = 2;
            }
            if (gvJigType.Columns["JIG_TYPE_MAIN"] != null)
            {
                gvJigType.Columns["JIG_TYPE_MAIN"].Caption = "Nhóm chính";
                gvJigType.Columns["JIG_TYPE_MAIN"].VisibleIndex = 3;
            }

            if (gvJigType.Columns["IS_ACTIVE"] != null)
            {
                gvJigType.Columns["IS_ACTIVE"].Caption = "Kích hoạt";
                gvJigType.Columns["IS_ACTIVE"].VisibleIndex = 4;
            }
            if (gvJigType.Columns["DRAWING_NAME"] != null)
            {
                gvJigType.Columns["DRAWING_NAME"].Caption = "Tên bản vẽ";
                gvJigType.Columns["DRAWING_NAME"].VisibleIndex = 5;
            }
            if (gvJigType.Columns["DEFAULT_DRAWING_CODE"] != null) gvJigType.Columns["DEFAULT_DRAWING_CODE"].Visible = false;
            if (gvJigType.Columns["DRAWING_FILE_PATH"] != null) gvJigType.Columns["DRAWING_FILE_PATH"].Visible = false;

            gvJigType.BestFitColumns();
            lblRecord.Text = $"Record: {gvJigType.RowCount}";
        }

        private void gvJigType_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var ROW = gvJigType.GetDataRow(e.FocusedRowHandle);
            if (ROW == null) return;

            txtJigTypeCode.Text = Convert.ToString(ROW["JIG_TYPE_CODE"]);
            txtJigTypeName.Text = Convert.ToString(ROW["JIG_TYPE_NAME"]);
            cboJigTypeMain.EditValue = Convert.ToString(ROW["JIG_TYPE_MAIN"]);
            txtDrawingName.Text = Convert.ToString(ROW["DRAWING_NAME"]);
            _selectedDrawingFilePath = Convert.ToString(ROW["DRAWING_FILE_PATH"]);
            chkIsActive.Checked = Convert.ToInt32(ROW["IS_ACTIVE"]) == 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var CODE = txtJigTypeCode.Text.Trim();
            var NAME = txtJigTypeName.Text.Trim();
            var TYPE_MAIN = Convert.ToString(cboJigTypeMain.EditValue);
            if (string.IsNullOrWhiteSpace(CODE) || string.IsNullOrWhiteSpace(NAME) || string.IsNullOrWhiteSpace(TYPE_MAIN))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã loại Jig, Tên loại Jig và Nhóm chính.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var drawingCode = string.Empty;
            var drawingName = txtDrawingName.Text.Trim();
            var sourcePath = _selectedDrawingFilePath;
            var storedPath = _selectedDrawingFilePath;
            if (!string.IsNullOrWhiteSpace(sourcePath) && File.Exists(sourcePath))
            {
                var targetFolder = Path.Combine(StorageConfig.FolderFileUpload, "JigDrawings", CODE);
                Directory.CreateDirectory(targetFolder);
                var targetFile = Path.Combine(targetFolder, Path.GetFileName(sourcePath));
                var sourceFullPath = Path.GetFullPath(sourcePath);
                var targetFullPath = Path.GetFullPath(targetFile);

                if (!string.Equals(sourceFullPath, targetFullPath, StringComparison.OrdinalIgnoreCase))
                {
                    File.Copy(sourceFullPath, targetFullPath, true);
                }

                storedPath = targetFullPath;
            }

            _service.UpsertJigTypeMaster(CODE, NAME, TYPE_MAIN, drawingCode, drawingName, storedPath, chkIsActive.Checked);
            MessageBox.Show("Đã lưu loại Jig.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtJigTypeCode.Text = string.Empty;
            txtJigTypeName.Text = string.Empty;
            cboJigTypeMain.EditValue = "FUNCTION";
            txtDrawingName.Text = string.Empty;
            _selectedDrawingFilePath = string.Empty;
            chkIsActive.Checked = true;
            txtJigTypeCode.Focus();
        }

        private void btnBrowseDrawing_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "PDF files|*.pdf";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                _selectedDrawingFilePath = dialog.FileName;
                if (string.IsNullOrWhiteSpace(txtDrawingName.Text)) txtDrawingName.Text = Path.GetFileNameWithoutExtension(dialog.FileName);
            }
        }

        private void gvJigType_DoubleClick(object sender, EventArgs e)
        {
            var hit = gvJigType.CalcHitInfo(gvJigType.GridControl.PointToClient(Cursor.Position));
            if (!hit.InRowCell || hit.RowHandle < 0) return;
            if (hit.Column == null || !string.Equals(hit.Column.FieldName, "DRAWING_NAME", StringComparison.OrdinalIgnoreCase)) return;

            var path = Convert.ToString(gvJigType.GetRowCellValue(hit.RowHandle, "DRAWING_FILE_PATH"));
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                MessageBox.Show("Không tìm thấy file PDF bản vẽ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new FRM_PDF_VIEWER_ADV(path))
            {
                form.ShowDialog(this);
            }
        }
    }
}
