using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_FUNCTION_LIST : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigFunctionService _service = new JigFunctionService();

        public FRM_JIG_FUNCTION_LIST()
        {
            InitializeComponent();
            this.FormClosed += FRM_JIG_FUNCTION_LIST_FormClosed;
        }

        private void FRM_JIG_FUNCTION_LIST_Load(object sender, EventArgs e)
        {
            SetupGridFormat(gvJig);
            DataChangeNotifier.Changed += DataChangeNotifier_Changed;
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

        private void BuildColumns()
        {
            gvJig.Columns.Clear();
            gvJig.Columns.AddVisible("STT", "STT");
            gvJig.Columns.AddVisible("CONTROL_NO", "Control No.");
            gvJig.Columns.AddVisible("JIG_NAME", "Tên Jig");
            gvJig.Columns.AddVisible("JIG_TYPE_NAME", "Loại Jig");
            gvJig.Columns.AddVisible("JIG_SIZE", "Size");
            gvJig.Columns.AddVisible("USE_PRODUCT", "Sản phẩm sử dụng");
            gvJig.Columns.AddVisible("LOCATION_CODE", "Vị trí");
            gvJig.Columns.AddVisible("FACTORY", "Nhà máy");
            gvJig.Columns.AddVisible("STATUS_USE", "Trạng thái sử dụng");
            gvJig.Columns.AddVisible("USE_SECTION", "Bộ phận sử dụng");
            gvJig.Columns.AddVisible("LAST_CHECK_DATE", "Ngày kiểm tra định kỳ gần nhất");
            gvJig.Columns.AddVisible("NEXT_CHECK_PLAN_DATE", "Kế hoạch kiểm tra định kỳ tiếp theo");
            gvJig.Columns.AddVisible("CHECK_RESULT", "Kết quả kiểm tra định kỳ");
            gvJig.Columns.AddVisible("CHECK_FREQUENCY", "Tần suất kiểm tra định kỳ");
            foreach (DevExpress.XtraGrid.Columns.GridColumn C in gvJig.Columns)
            {
                C.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                C.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            gvJig.BestFitColumns();
        }

        private void LoadData()
        {
            var DATA = _service.GetJigFunctionList();
            gcJig.DataSource = DATA;
            BuildColumns();
            if (gvJig.Columns["NEXT_CHECK_PLAN_DATE"] != null)
            {
                gvJig.Columns["NEXT_CHECK_PLAN_DATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gvJig.Columns["NEXT_CHECK_PLAN_DATE"].DisplayFormat.FormatString = "dd-MM-yyyy";
            }
            lblRecord.Text = $"Record: {gvJig.RowCount}";
        }

        private void GvJig_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName != "NEXT_CHECK_PLAN_DATE") return;

            var VALUE = gvJig.GetRowCellValue(e.RowHandle, "NEXT_CHECK_PLAN_DATE");
            if (VALUE == null || VALUE == DBNull.Value) return;

            DateTime PLAN_DATE;
            if (!TryGetPlanDate(VALUE, out PLAN_DATE)) return;

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

        private DataTable ReadExcel(string FILE_PATH)
        {
            var EXT = Path.GetExtension(FILE_PATH).ToLowerInvariant();
            var CONN = EXT == ".xls"
                ? $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={FILE_PATH};Extended Properties='Excel 8.0;HDR=YES;IMEX=1'"
                : $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={FILE_PATH};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'";

            using (var CN = new OleDbConnection(CONN))
            {
                CN.Open();
                var SCHEMA = CN.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var SHEET = Convert.ToString(SCHEMA.Rows[0]["TABLE_NAME"]);
                var DT = new DataTable();
                using (var AD = new OleDbDataAdapter($"SELECT * FROM [{SHEET}]", CN))
                {
                    AD.Fill(DT);
                }
                return DT;
            }
        }

        private DateTime? ParseDate(object VALUE)
        {
            if (VALUE == null || VALUE == DBNull.Value) return null;
            DateTime D;
            return DateTime.TryParse(Convert.ToString(VALUE), out D) ? D : (DateTime?)null;
        }

        private bool TryGetPlanDate(object VALUE, out DateTime PLAN_DATE)
        {
            PLAN_DATE = DateTime.MinValue;
            if (VALUE == null || VALUE == DBNull.Value) return false;

            if (VALUE is DateTime)
            {
                PLAN_DATE = ((DateTime)VALUE).Date;
                return true;
            }

            return DateTime.TryParse(Convert.ToString(VALUE), out PLAN_DATE);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (var DIALOG = new OpenFileDialog())
            {
                DIALOG.Filter = "Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
                if (DIALOG.ShowDialog() != DialogResult.OK) return;

                var DT = ReadExcel(DIALOG.FileName);
                foreach (DataRow R in DT.Rows)
                {
                    _service.UpsertJig(
                        Convert.ToString(R["CONTROL_NO"]),
                        Convert.ToString(R["JIG_NAME"]),
                        Convert.ToString(R["JIG_TYPE_CODE"]),
                        Convert.ToString(R["JIG_SIZE"]),
                        Convert.ToString(R["USE_PRODUCT"]),
                        Convert.ToString(R["LOCATION_CODE"]),
                        DT.Columns.Contains("FACTORY") ? Convert.ToString(R["FACTORY"]) : null,
                        Convert.ToString(R["STATUS_USE"]),
                        Convert.ToString(R["USE_SECTION"]),
                        ParseDate(R["LAST_CHECK_DATE"]),
                        ParseDate(R["NEXT_CHECK_PLAN_DATE"]),
                        Convert.ToString(R["CHECK_RESULT"]),
                        Convert.ToString(R["CHECK_FREQUENCY"]));
                }

                MessageBox.Show("Import thành công.");
                DataChangeNotifier.Notify("JIG_MASTER");
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!EnsureCanOperate()) return;
            var CONTROL_NO = GetSelectedControlNo();
            if (string.IsNullOrWhiteSpace(CONTROL_NO)) return;

            using (var FORM = new FRM_JIG_REGISTER(CONTROL_NO))
            {
                FORM.ShowDialog(this);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DataChangeNotifier_Changed(string ENTITY)
        {
            if (string.Equals(ENTITY, "JIG_MASTER", StringComparison.OrdinalIgnoreCase))
            {
                if (IsHandleCreated) BeginInvoke(new Action(LoadData));
            }
        }

        private void FRM_JIG_FUNCTION_LIST_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataChangeNotifier.Changed -= DataChangeNotifier_Changed;
        }

        private string GetSelectedControlNo()
        {
            var SELECTED_ROWS = gvJig.GetSelectedRows();
            var ROW_HANDLE = (SELECTED_ROWS != null && SELECTED_ROWS.Length > 0)
                ? SELECTED_ROWS[0]
                : gvJig.FocusedRowHandle;

            if (ROW_HANDLE < 0)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng dữ liệu.", "Thiếu lựa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var VALUE = gvJig.GetRowCellValue(ROW_HANDLE, "CONTROL_NO");
            var CONTROL_NO = Convert.ToString(VALUE)?.Trim();
            if (string.IsNullOrWhiteSpace(CONTROL_NO))
            {
                MessageBox.Show("Không lấy được Control No.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return CONTROL_NO;
        }

        private bool EnsureCanOperate()
        {
            if (string.IsNullOrWhiteSpace(AppSession.UserId))
            {
                MessageBox.Show("Vui lòng đăng nhập để thao tác.", "Chưa đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.Equals(AppSession.RoleCode, "ADMIN", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không có quyền thao tác chức năng này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
