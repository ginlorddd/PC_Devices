using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_CANCEL_WAITING_APPROVE_LIST : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigRegisterService _service = new JigRegisterService();

        public FRM_JIG_CANCEL_WAITING_APPROVE_LIST()
        {
            InitializeComponent();
            FormClosed += FRM_JIG_CANCEL_WAITING_APPROVE_LIST_FormClosed;
        }

        private void FRM_JIG_CANCEL_WAITING_APPROVE_LIST_Load(object sender, EventArgs e)
        {
            SetupGridFormat(gvWaiting);
            ApplyPermissionState();
            DataChangeNotifier.Changed += DataChangeNotifier_Changed;
            LoadData();
        }

        private void LoadData()
        {
            gcWaiting.DataSource = _service.GetCancelWaitingApproveRequests();
            BuildColumns();
            gvWaiting.BestFitColumns();
            lblRecord.Text = $"Record: {gvWaiting.RowCount}";
            gvWaiting.Columns["REQUEST_AT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvWaiting.Columns["REQUEST_AT"].DisplayFormat.FormatString = "dd-MM-yy";
        }

        private static void SetupGridFormat(GridView view)
        {
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ColumnAutoWidth = false;
            view.Appearance.HeaderPanel.Font = new Font(view.Appearance.HeaderPanel.Font, FontStyle.Bold);
            view.Appearance.HeaderPanel.Options.UseFont = true;
        }

        private void BuildColumns()
        {
            gvWaiting.Columns.Clear();
            gvWaiting.Columns.AddVisible("STT", "STT");
            var colId = gvWaiting.Columns.AddVisible("CANCEL_ID", "CANCEL_ID");
            colId.Visible = false;
            gvWaiting.Columns.AddVisible("CONTROL_NO", "Control No.");
            gvWaiting.Columns.AddVisible("JIG_NAME", "Tên Jig");
            gvWaiting.Columns.AddVisible("JIG_TYPE", "Loại Jig");
            gvWaiting.Columns.AddVisible("JIG_SIZE", "Size");
            gvWaiting.Columns.AddVisible("USE_PRODUCT", "Sản phẩm sử dụng");
            gvWaiting.Columns.AddVisible("PURPOSE_USE", "Mục đích sử dụng");
            gvWaiting.Columns.AddVisible("LOCATION_CODE", "Vị trí");
            gvWaiting.Columns.AddVisible("USE_SECTION", "Bộ phận sử dụng");
            gvWaiting.Columns.AddVisible("REQUEST_AT", "Ngày đăng ký");
            gvWaiting.Columns.AddVisible("REQUEST_BY", "Người đăng ký");
            gvWaiting.Columns.AddVisible("CANCEL_REASON", "Lý do hủy");
        }

        private int? GetSelectedCancelId()
        {
            if (gvWaiting.FocusedRowHandle < 0) return null;
            var value = gvWaiting.GetRowCellValue(gvWaiting.FocusedRowHandle, "CANCEL_ID");
            int id;
            return value != null && int.TryParse(Convert.ToString(value), out id) ? (int?)id : null;
        }

        private bool EnsureCanOperate()
        {
            if (string.IsNullOrWhiteSpace(AppSession.UserId))
            {
                MessageBox.Show("Vui lòng đăng nhập để thao tác.", "Chưa đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!RoleHelper.CanApprove())
            {
                MessageBox.Show("Bạn không có quyền duyệt/xóa.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ApplyPermissionState()
        {
            var canApprove = RoleHelper.IsLoggedIn() && RoleHelper.CanApprove();
            btnApprove.Enabled = canApprove;
            btnDelete.Enabled = RoleHelper.IsLoggedIn() && RoleHelper.IsSystemAdmin();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!EnsureCanOperate()) return;
            if (!RoleHelper.IsSystemAdmin())
            {
                MessageBox.Show("Chỉ SYSTEM_ADMIN mới có quyền xóa.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var id = GetSelectedCancelId();
            if (!id.HasValue) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa đăng ký hủy đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            _service.DeleteCancelRequest(id.Value);
            DataChangeNotifier.Notify("JIG_CANCEL_REQUEST");
            LoadData();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (!EnsureCanOperate()) return;
            var id = GetSelectedCancelId();
            if (!id.HasValue) return;
            if (MessageBox.Show("Xác nhận duyệt hủy Jig này?", "Approve", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            var approveBy = string.IsNullOrWhiteSpace(AppSession.UserId) ? "SYSTEM" : AppSession.UserId;
            _service.ApproveCancelRequest(id.Value, approveBy);
            MessageBox.Show("Đã duyệt hủy. Jig sẽ không còn trong danh sách Jig chức năng / Jig ngoại quan.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataChangeNotifier.Notify("JIG_CANCEL_REQUEST");
            DataChangeNotifier.Notify("JIG_MASTER");
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dialog.FileName = $"Jig_Cancel_Waiting_Approve_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                gcWaiting.ExportToXlsx(dialog.FileName);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void DataChangeNotifier_Changed(string entity)
        {
            if (string.Equals(entity, "JIG_CANCEL_REQUEST", StringComparison.OrdinalIgnoreCase) || string.Equals(entity, "JIG_MASTER", StringComparison.OrdinalIgnoreCase))
            {
                if (IsHandleCreated) BeginInvoke(new Action(LoadData));
            }
            ApplyPermissionState();
        }

        private void FRM_JIG_CANCEL_WAITING_APPROVE_LIST_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataChangeNotifier.Changed -= DataChangeNotifier_Changed;
        }
    }
}
