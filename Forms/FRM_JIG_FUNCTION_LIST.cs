using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_FUNCTION_LIST : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigFunctionService _service = new JigFunctionService();

        public FRM_JIG_FUNCTION_LIST()
        {
            InitializeComponent();
        }

        private void FRM_JIG_FUNCTION_LIST_Load(object sender, EventArgs e)
        {
            SetupGridFormat(gvJig);
            LoadData();
        }

        private void SetupGridFormat(GridView VIEW)
        {
            VIEW.OptionsView.ShowAutoFilterRow = true;
            VIEW.Appearance.HeaderPanel.Font = new Font(VIEW.Appearance.HeaderPanel.Font, FontStyle.Bold);
            VIEW.Appearance.HeaderPanel.Options.UseFont = true;
            VIEW.OptionsView.ColumnAutoWidth = false;
            VIEW.RowCellStyle += GvJig_RowCellStyle;
        }

        private void LoadData()
        {
            gcJig.DataSource = _service.GetJigFunctionList();
            lblRecord.Text = $"Record: {gvJig.RowCount}";
        }

        private void GvJig_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName != "NEXT_CHECK_PLAN_DATE") return;

            var VALUE = gvJig.GetRowCellValue(e.RowHandle, "NEXT_CHECK_PLAN_DATE");
            if (VALUE == null || VALUE == DBNull.Value) return;

            DateTime PLAN_DATE;
            if (!DateTime.TryParse(Convert.ToString(VALUE, CultureInfo.InvariantCulture), out PLAN_DATE)) return;

            var TODAY = DateTime.Today;
            if (PLAN_DATE.Date < TODAY)
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
            else if (PLAN_DATE.Year == TODAY.Year && PLAN_DATE.Month == TODAY.Month)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var DIALOG = new SaveFileDialog())
            {
                DIALOG.Filter = "Excel (*.xlsx)|*.xlsx";
                DIALOG.FileName = "JIG_FUNCTION_LIST.xlsx";
                if (DIALOG.ShowDialog() == DialogResult.OK)
                {
                    gcJig.ExportToXlsx(DIALOG.FileName);
                    MessageBox.Show("Export thành công.");
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Import sẽ bổ sung nội dung sau.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Update sẽ bổ sung nội dung sau.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
