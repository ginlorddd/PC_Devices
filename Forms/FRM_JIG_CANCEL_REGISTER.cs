using DevExpress.XtraEditors.Controls;
using JigFlow.Data;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_CANCEL_REGISTER : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigRegisterService _service = new JigRegisterService();

        public FRM_JIG_CANCEL_REGISTER()
        {
            InitializeComponent();
        }

        private void FRM_JIG_CANCEL_REGISTER_Load(object sender, EventArgs e)
        {
            ConfigureLookUp();
            ConfigureReadOnlyInfo();
            LoadManagementNoLookup();
            LoadReasonLookup();
            deExpectedCancelDate.DateTime = DateTime.Today;
        }

        private void ConfigureLookUp()
        {
            lueManagementNo.Properties.TextEditStyle = TextEditStyles.Standard;
            lueManagementNo.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSearch;
            lueManagementNo.Properties.PopupFilterMode = PopupFilterMode.Contains;
            lueManagementNo.Properties.ImmediatePopup = true;
            lueManagementNo.Properties.NullText = "Nhập/chọn số quản lý";

            lueReason.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            lueReason.Properties.ShowHeader = false;
            lueReason.Properties.ShowFooter = false;
            lueReason.Properties.NullText = "Chọn lý do hủy";
        }

        private void ConfigureReadOnlyInfo()
        {
            foreach (var EDIT in new[] { txtDepartment, txtFactory, txtJigName, txtFrequency, txtJigType, txtSize, txtUseProduct, txtLocation })
            {
                EDIT.Properties.ReadOnly = true;
            }
        }

        private void LoadManagementNoLookup()
        {
            var DT = _service.GetJigsAvailableForCancel();
            lueManagementNo.Properties.DataSource = DT;
            lueManagementNo.Properties.DisplayMember = "CONTROL_NO";
            lueManagementNo.Properties.ValueMember = "CONTROL_NO";
            lueManagementNo.Properties.Columns.Clear();
            lueManagementNo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CONTROL_NO", "Số quản lý"));
            lueManagementNo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("JIG_NAME", "Tên Jig"));
            lueManagementNo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("USE_SECTION", "Bộ phận"));
        }

        private void LoadReasonLookup()
        {
            var DT = new DataTable();
            DT.Columns.Add("VALUE");
            DT.Rows.Add("Hỏng không thể sửa");
            DT.Rows.Add("Không còn nhu cầu sử dụng");
            DT.Rows.Add("Thay thế bằng Jig mới");
            DT.Rows.Add("Khác");

            lueReason.Properties.DataSource = DT;
            lueReason.Properties.DisplayMember = "VALUE";
            lueReason.Properties.ValueMember = "VALUE";
            lueReason.Properties.Columns.Clear();
            lueReason.Properties.Columns.Add(new LookUpColumnInfo("VALUE", "Lý do hủy"));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var MANAGEMENT_NO = Convert.ToString(lueManagementNo.EditValue);
            if (string.IsNullOrWhiteSpace(MANAGEMENT_NO)) MANAGEMENT_NO = txtSearchManagementNo.Text.Trim();
            if (string.IsNullOrWhiteSpace(MANAGEMENT_NO))
            {
                MessageBox.Show("Vui lòng nhập Số quản lý.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ROW = _service.GetJigMasterByControlNo(MANAGEMENT_NO);
            if (ROW == null)
            {
                ClearJigInfo();
                MessageBox.Show("Không tìm thấy Jig đang sử dụng với số quản lý đã nhập.", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtSearchManagementNo.Text = Convert.ToString(ROW["CONTROL_NO"]);
            lueManagementNo.EditValue = Convert.ToString(ROW["CONTROL_NO"]);
            txtDepartment.Text = Convert.ToString(ROW["USE_SECTION"]);
            txtFactory.Text = Convert.ToString(ROW["FACTORY"]);
            txtJigName.Text = Convert.ToString(ROW["JIG_NAME"]);
            txtFrequency.Text = Convert.ToString(ROW["CHECK_FREQUENCY"]);
            txtJigType.Text = Convert.ToString(ROW["JIG_TYPE"]);
            txtSize.Text = Convert.ToString(ROW["JIG_SIZE"]);
            txtUseProduct.Text = Convert.ToString(ROW["USE_PRODUCT"]);
            txtLocation.Text = Convert.ToString(ROW["LOCATION_CODE"]);
        }

        private void ClearJigInfo()
        {
            txtDepartment.Text = string.Empty;
            txtFactory.Text = string.Empty;
            txtJigName.Text = string.Empty;
            txtFrequency.Text = string.Empty;
            txtJigType.Text = string.Empty;
            txtSize.Text = string.Empty;
            txtUseProduct.Text = string.Empty;
            txtLocation.Text = string.Empty;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var MANAGEMENT_NO = txtSearchManagementNo.Text.Trim();
            if (string.IsNullOrWhiteSpace(MANAGEMENT_NO) || string.IsNullOrWhiteSpace(txtJigName.Text))
            {
                MessageBox.Show("Vui lòng Search Jig trước khi đăng ký hủy.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var REASON = Convert.ToString(lueReason.EditValue);
            if (string.IsNullOrWhiteSpace(REASON))
            {
                MessageBox.Show("Vui lòng chọn Lý do hủy.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ROW = _service.GetJigMasterByControlNo(MANAGEMENT_NO);
            if (ROW == null)
            {
                MessageBox.Show("Jig không còn hợp lệ để đăng ký hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var jigId = Convert.ToInt32(ROW["JIG_ID"]);
            if (_service.HasWaitingCancelRequest(jigId))
            {
                MessageBox.Show("Jig này đã có yêu cầu hủy chờ duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var detail = new StringBuilder();
            detail.Append(REASON);
            if (!string.IsNullOrWhiteSpace(txtAbnormalNo.Text)) detail.Append($" | Số bất thường: {txtAbnormalNo.Text.Trim()}");
            detail.Append($" | Ngày hủy dự kiến: {deExpectedCancelDate.DateTime:yyyy-MM-dd}");
            if (!string.IsNullOrWhiteSpace(memoNote.Text)) detail.Append($" | Ghi chú: {memoNote.Text.Trim()}");

            var requestBy = string.IsNullOrWhiteSpace(AppSession.UserId) ? "SYSTEM" : AppSession.UserId;
            _service.CreateCancelRequest(jigId, detail.ToString(), requestBy);

            MessageBox.Show("Đã đăng ký hủy Jig, vui lòng chờ phê duyệt.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataChangeNotifier.Notify("JIG_CANCEL_REQUEST");
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
