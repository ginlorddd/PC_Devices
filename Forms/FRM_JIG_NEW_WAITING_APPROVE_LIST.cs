using DevExpress.XtraGrid.Views.Grid;
using JigFlow.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_NEW_WAITING_APPROVE_LIST : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigRegisterService _service = new JigRegisterService();

        public FRM_JIG_NEW_WAITING_APPROVE_LIST()
        {
            InitializeComponent();
        }

        private void FRM_JIG_NEW_WAITING_APPROVE_LIST_Load(object sender, EventArgs e)
        {
            SetupGridFormat(gvWaiting);
            ApplyPermissionState();
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            gcWaiting.DataSource = _service.GetWaitingApproveRequests();
            BuildColumns();
            gvWaiting.BestFitColumns();
            lblRecord.Text = $"Record: {gvWaiting.RowCount}";
            gvWaiting.Columns["REQUEST_AT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvWaiting.Columns["REQUEST_AT"].DisplayFormat.FormatString = "dd-MM-yy";
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dialog.FileName = $"Jig_New_Waiting_Approve_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                gcWaiting.ExportToXlsx(dialog.FileName);
                MessageBox.Show("Đã xuất file thành công.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!EnsureCanOperate()) return;
            var REQUEST_ID = GetSelectedRequestId();
            if (!REQUEST_ID.HasValue) return;

            using (var FORM = new FRM_JIG_REGISTER(REQUEST_ID.Value))
            {
                FORM.ShowDialog(this);
            }
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!EnsureCanOperate()) return;
            var REQUEST_ID = GetSelectedRequestId();
            if (!REQUEST_ID.HasValue) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa đăng ký đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var AFFECTED = _service.DeleteRegisterRequest(REQUEST_ID.Value);
            if (AFFECTED > 0)
            {
                MessageBox.Show("Đã xóa đăng ký chờ duyệt.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu hoặc dữ liệu đã được xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (!EnsureCanOperate()) return;
            var REQUEST_ID = GetSelectedRequestId();
            if (!REQUEST_ID.HasValue) return;
            if (MessageBox.Show("Xác nhận duyệt đăng ký Jig này?", "Approve", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var APPROVE_BY = string.IsNullOrWhiteSpace(AppSession.UserId) ? "SYSTEM" : AppSession.UserId;
            var AFFECTED = _service.ApproveRegisterRequest(REQUEST_ID.Value, APPROVE_BY);
            if (AFFECTED > 0)
            {
                MessageBox.Show("Duyệt thành công. Jig đã chuyển sang danh sách sử dụng với trạng thái 'Đang sử dụng'.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu chờ duyệt hoặc dữ liệu đã được xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupGridFormat(GridView VIEW)
        {
            VIEW.OptionsView.ShowAutoFilterRow = true;
            VIEW.OptionsView.ShowGroupPanel = false;
            VIEW.Appearance.HeaderPanel.Font = new Font(VIEW.Appearance.HeaderPanel.Font, FontStyle.Bold);
            VIEW.Appearance.HeaderPanel.Options.UseFont = true;
            VIEW.OptionsView.ColumnAutoWidth = false;
        }

        private void BuildColumns()
        {
            gvWaiting.Columns.Clear();
            gvWaiting.Columns.AddVisible("STT", "STT");
            var COL_REQUEST_ID = gvWaiting.Columns.AddVisible("REQUEST_ID", "REQUEST_ID");
            COL_REQUEST_ID.Visible = false;
            gvWaiting.Columns.AddVisible("MANAGEMENT_NO", "Control No.");
            gvWaiting.Columns.AddVisible("JIG_NAME", "Tên Jig");
            gvWaiting.Columns.AddVisible("JIG_TYPE_CODE", "Loại Jig");
            gvWaiting.Columns.AddVisible("JIG_SIZE", "Size");
            gvWaiting.Columns.AddVisible("USE_PRODUCT", "Sản phẩm sử dụng");
            gvWaiting.Columns.AddVisible("LOCATION_CODE", "Vị trí");
            gvWaiting.Columns.AddVisible("DEPARTMENT", "Bộ phận đăng ký");
            gvWaiting.Columns.AddVisible("REQUEST_AT", "Ngày đăng ký");
            gvWaiting.Columns.AddVisible("REQUEST_BY", "Người đăng ký");
            gvWaiting.Columns.AddVisible("STATUS_USE", "Kết quả kiểm tra");
            gvWaiting.Columns.AddVisible("FIRST_CHECK_RESULT_FILE", "File kết quả");
        }

        private int? GetSelectedRequestId()
        {
            if (gvWaiting.FocusedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng dữ liệu.", "Thiếu lựa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var VALUE = gvWaiting.GetRowCellValue(gvWaiting.FocusedRowHandle, "REQUEST_ID");
            int REQUEST_ID;
            if (VALUE == null || VALUE == DBNull.Value || !int.TryParse(Convert.ToString(VALUE), out REQUEST_ID))
            {
                MessageBox.Show("Không lấy được REQUEST_ID của dòng đã chọn.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return REQUEST_ID;
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

        private void ApplyPermissionState()
        {
            var CAN_OPERATE = !string.IsNullOrWhiteSpace(AppSession.UserId)
                              && string.Equals(AppSession.RoleCode, "ADMIN", StringComparison.OrdinalIgnoreCase);
            btnUpdate.Enabled = CAN_OPERATE;
            btnApprove.Enabled = CAN_OPERATE;
            btnDelete.Enabled = CAN_OPERATE;
        }
    }
}
