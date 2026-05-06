using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

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

            if (gvJigType.Columns["IS_ACTIVE"] != null)
            {
                gvJigType.Columns["IS_ACTIVE"].Caption = "Kích hoạt";
                gvJigType.Columns["IS_ACTIVE"].VisibleIndex = 3;
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
            chkIsActive.Checked = Convert.ToInt32(ROW["IS_ACTIVE"]) == 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var CODE = txtJigTypeCode.Text.Trim();
            var NAME = txtJigTypeName.Text.Trim();
            if (string.IsNullOrWhiteSpace(CODE) || string.IsNullOrWhiteSpace(NAME))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã loại Jig và Tên loại Jig.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _service.UpsertJigTypeMaster(CODE, NAME, chkIsActive.Checked);
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
            chkIsActive.Checked = true;
            txtJigTypeCode.Focus();
        }
    }
}
