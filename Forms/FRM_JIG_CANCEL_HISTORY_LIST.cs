using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_CANCEL_HISTORY_LIST : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigRegisterService _service = new JigRegisterService();

        public FRM_JIG_CANCEL_HISTORY_LIST()
        {
            InitializeComponent();
            FormClosed += (s, e) => DataChangeNotifier.Changed -= DataChangeNotifier_Changed;
        }

        private void FRM_JIG_CANCEL_HISTORY_LIST_Load(object sender, EventArgs e)
        {
            gvHistory.OptionsView.ShowAutoFilterRow = true;
            gvHistory.OptionsView.ShowGroupPanel = false;
            gvHistory.OptionsView.ColumnAutoWidth = false;
            gvHistory.Appearance.HeaderPanel.Font = new Font(gvHistory.Appearance.HeaderPanel.Font, FontStyle.Bold);
            gvHistory.Appearance.HeaderPanel.Options.UseFont = true;
            ApplyPermissionState();
            DataChangeNotifier.Changed += DataChangeNotifier_Changed;
            LoadData();
        }

        private void LoadData()
        {
            gcHistory.DataSource = _service.GetCancelHistory();
            BuildColumns();
            gvHistory.BestFitColumns();
            if (gvHistory.Columns["REQUEST_AT"] != null)
            {
                gvHistory.Columns["REQUEST_AT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gvHistory.Columns["REQUEST_AT"].DisplayFormat.FormatString = "dd-MM-yy";
            }
            if (gvHistory.Columns["APPROVE_AT"] != null)
            {
                gvHistory.Columns["APPROVE_AT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gvHistory.Columns["APPROVE_AT"].DisplayFormat.FormatString = "dd-MM-yy";
            }
            lblRecord.Text = $"Record: {gvHistory.RowCount}";
        }

        private void BuildColumns()
        {
            gvHistory.Columns.Clear();
            gvHistory.Columns.AddVisible("STT", "STT");
            gvHistory.Columns.AddVisible("CONTROL_NO", "Control No.");
            gvHistory.Columns.AddVisible("JIG_NAME", "Tên Jig");
            gvHistory.Columns.AddVisible("JIG_TYPE", "Loại Jig");
            gvHistory.Columns.AddVisible("JIG_SIZE", "Size");
            gvHistory.Columns.AddVisible("USE_PRODUCT", "Sản phẩm sử dụng");
            gvHistory.Columns.AddVisible("PURPOSE_USE", "Mục đích sử dụng");
            gvHistory.Columns.AddVisible("LOCATION_CODE", "Vị trí");
            gvHistory.Columns.AddVisible("USE_SECTION", "Bộ phận sử dụng");
            gvHistory.Columns.AddVisible("REQUEST_AT", "Ngày đăng ký");
            gvHistory.Columns.AddVisible("REQUEST_BY", "Người đăng ký");
            gvHistory.Columns.AddVisible("CANCEL_REASON", "Lý do hủy");
            gvHistory.Columns.AddVisible("APPROVE_AT", "Ngày xác nhận");
        }

        private void ApplyPermissionState() => btnDelete.Enabled = RoleHelper.IsLoggedIn() && RoleHelper.IsSystemAdmin();

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();
        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dialog.FileName = $"Jig_Cancel_History_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                gcHistory.ExportToXlsx(dialog.FileName);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!RoleHelper.IsSystemAdmin())
            {
                MessageBox.Show("Chỉ SYSTEM_ADMIN mới có quyền xóa.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Dữ liệu lịch sử hủy đã duyệt không được phép xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void DataChangeNotifier_Changed(string entity)
        {
            if (string.Equals(entity, "JIG_CANCEL_REQUEST", StringComparison.OrdinalIgnoreCase))
            {
                if (IsHandleCreated) BeginInvoke(new Action(LoadData));
                ApplyPermissionState();
            }
        }
    }
}
