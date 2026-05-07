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

        public FRM_JIG_TYPE_MASTER()
        {
            InitializeComponent();
        }

        private void FRM_JIG_TYPE_MASTER_Load(object sender, EventArgs e)
        {
            cboJigTypeMain.Properties.Items.Clear();
            cboJigTypeMain.Properties.Items.AddRange(new object[] { "FUNCTION", "VISUAL" });
            cboJigTypeMain.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            SetupGridFormat(gvJigType);
            LoadData();
        }

        private void SetupGridFormat(GridView VIEW)
        {
            VIEW.OptionsView.ShowAutoFilterRow = true;
            VIEW.OptionsView.ShowGroupPanel = false;
            VIEW.Appearance.HeaderPanel.Font = new Font(VIEW.Appearance.HeaderPanel.Font, FontStyle.Bold);
            VIEW.Appearance.HeaderPanel.Options.UseFont = true;
            VIEW.OptionsView.ColumnAutoWidth = false;
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
            txtDrawingCode.Text = Convert.ToString(ROW["DEFAULT_DRAWING_CODE"]);
            txtDrawingName.Text = Convert.ToString(ROW["DRAWING_NAME"]);
            txtDrawingFilePath.Text = Convert.ToString(ROW["DRAWING_FILE_PATH"]);
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

            var drawingCode = txtDrawingCode.Text.Trim();
            var drawingName = txtDrawingName.Text.Trim();
            var sourcePath = txtDrawingFilePath.Text.Trim();
            var storedPath = sourcePath;
            if (!string.IsNullOrWhiteSpace(sourcePath) && File.Exists(sourcePath))
            {
                var targetFolder = Path.Combine(StorageConfig.FolderFileUpload, "JigDrawings", CODE);
                Directory.CreateDirectory(targetFolder);
                var targetFile = Path.Combine(targetFolder, Path.GetFileName(sourcePath));
                File.Copy(sourcePath, targetFile, true);
                storedPath = targetFile;
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
            txtDrawingCode.Text = string.Empty;
            txtDrawingName.Text = string.Empty;
            txtDrawingFilePath.Text = string.Empty;
            chkIsActive.Checked = true;
            txtJigTypeCode.Focus();
        }

        private void btnBrowseDrawing_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Drawing files|*.pdf;*.dwg;*.dxf;*.png;*.jpg;*.jpeg|All files|*.*";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                txtDrawingFilePath.Text = dialog.FileName;
                if (string.IsNullOrWhiteSpace(txtDrawingName.Text)) txtDrawingName.Text = Path.GetFileNameWithoutExtension(dialog.FileName);
            }
        }
    }
}
