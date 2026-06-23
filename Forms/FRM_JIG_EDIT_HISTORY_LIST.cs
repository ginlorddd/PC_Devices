using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_EDIT_HISTORY_LIST : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigRegisterService _service = new JigRegisterService();

        public FRM_JIG_EDIT_HISTORY_LIST()
        {
            InitializeComponent();
        }

        private void FRM_JIG_EDIT_HISTORY_LIST_Load(object sender, EventArgs e)
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
        }

        private void LoadData()
        {
            gcHistory.DataSource = _service.GetJigEditHistory();
            BuildColumns();
            lblRecordValue.Text = gvHistory.RowCount.ToString();
            lblModeValue.Text = "View";
        }

        private void BuildColumns()
        {
            gvHistory.Columns.Clear();
            gvHistory.Columns.AddVisible("JIG_NAME", "Tên Jig");
            gvHistory.Columns.AddVisible("OLD_CONTROL_NO", "Mã QL cũ");
            gvHistory.Columns.AddVisible("NEW_CONTROL_NO", "Mã QL mới");
            gvHistory.Columns.AddVisible("JIG_TYPE_CODE", "Loại Jig");
            gvHistory.Columns.AddVisible("JIG_SIZE", "Size");
            gvHistory.Columns.AddVisible("USE_PRODUCT", "Sản phẩm sử dụng");
            gvHistory.Columns.AddVisible("PURPOSE_USE", "Mục đích sử dụng");
            gvHistory.Columns.AddVisible("LOCATION_CODE", "Vị trí");
            gvHistory.Columns.AddVisible("DEPARTMENT", "Bộ phận");
            gvHistory.Columns.AddVisible("FACTORY", "Nhà máy");
            gvHistory.Columns.AddVisible("UPDATED_AT", "Ngày sửa");
            gvHistory.Columns.AddVisible("UPDATED_BY", "Người sửa");

            if (gvHistory.Columns["UPDATED_AT"] != null)
            {
                gvHistory.Columns["UPDATED_AT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gvHistory.Columns["UPDATED_AT"].DisplayFormat.FormatString = "dd-MM-yy";
            }

            foreach (DevExpress.XtraGrid.Columns.GridColumn C in gvHistory.Columns)
            {
                C.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                C.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            gvHistory.BestFitColumns();
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
                DIALOG.FileName = $"Jig_Edit_History_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
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
