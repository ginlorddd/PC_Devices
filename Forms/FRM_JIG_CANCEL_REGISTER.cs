using DevExpress.XtraEditors.Controls;
using JigFlow.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_CANCEL_REGISTER : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigRegisterService _service = new JigRegisterService();
        private DataRow _selectedJig;

        public FRM_JIG_CANCEL_REGISTER()
        {
            InitializeComponent();
        }

        private void FRM_JIG_CANCEL_REGISTER_Load(object sender, EventArgs e)
        {
            SetupLookup();
            LoadManagementNoLookup();
            cboCancelReason.Properties.Items.Clear();
            cboCancelReason.Properties.Items.AddRange(new object[]
            {
                "Hư hỏng",
                "Không còn sử dụng",
                "Thay đổi model",
                "Khác"
            });
            cboCancelReason.SelectedIndex = -1;
            dtCancelPlan.EditValue = DateTime.Today;
            SetJigInfo(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
        }

        private void SetupLookup()
        {
            lueManagementNo.Properties.TextEditStyle = TextEditStyles.Standard;
            lueManagementNo.Properties.NullText = "Nhập/chọn số quản lý";
            lueManagementNo.Properties.ShowHeader = true;
            lueManagementNo.Properties.ShowFooter = false;
            lueManagementNo.Properties.SearchMode = SearchMode.AutoFilter;
            lueManagementNo.Properties.AutoSearchColumnIndex = 0;
            lueManagementNo.Properties.Columns.Clear();
            lueManagementNo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CONTROL_NO", "Số quản lý", 150));
            lueManagementNo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("JIG_NAME", "Tên Jig", 220));
            lueManagementNo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("USE_SECTION", "Bộ phận", 100));
            lueManagementNo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FACTORY", "Nhà máy", 80));
        }

        private void LoadManagementNoLookup()
        {
            var dt = _service.GetActiveJigForCancelLookup();
            lueManagementNo.Properties.DataSource = dt;
            lueManagementNo.Properties.DisplayMember = "CONTROL_NO";
            lueManagementNo.Properties.ValueMember = "CONTROL_NO";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var controlNo = Convert.ToString(lueManagementNo.EditValue);
            if (string.IsNullOrWhiteSpace(controlNo))
            {
                MessageBox.Show("Vui lòng nhập/chọn Số quản lý.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedJig = _service.GetJigByControlNo(controlNo.Trim());
            if (_selectedJig == null)
            {
                MessageBox.Show("Không tìm thấy Jig đang hoạt động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SetJigInfo(
                Convert.ToString(_selectedJig["USE_SECTION"]),
                Convert.ToString(_selectedJig["FACTORY"]),
                Convert.ToString(_selectedJig["JIG_NAME"]),
                Convert.ToString(_selectedJig["CHECK_FREQUENCY"]),
                Convert.ToString(_selectedJig["JIG_TYPE_NAME"]),
                Convert.ToString(_selectedJig["JIG_SIZE"]),
                Convert.ToString(_selectedJig["USE_PRODUCT"]),
                Convert.ToString(_selectedJig["LOCATION_CODE"]));
        }

        private void SetJigInfo(string department, string factory, string jigName, string frequency, string jigType, string size, string product, string location)
        {
            txtDepartment.Text = department;
            txtFactory.Text = factory;
            txtJigName.Text = jigName;
            txtFrequency.Text = frequency;
            txtJigType.Text = jigType;
            txtSize.Text = size;
            txtUseProduct.Text = product;
            txtLocation.Text = location;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (_selectedJig == null)
            {
                MessageBox.Show("Vui lòng Search Jig trước khi đăng ký hủy.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(cboCancelReason.Text) || dtCancelPlan.EditValue == null || string.IsNullOrWhiteSpace(txtAbnormalNo.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Lý do hủy, Ngày hủy dự kiến và Số bất thường.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var requestBy = string.IsNullOrWhiteSpace(AppSession.UserId) ? "SYSTEM" : AppSession.UserId;
            var affected = _service.CreateCancelRequest(
                Convert.ToInt32(_selectedJig["JIG_ID"]),
                cboCancelReason.Text.Trim(),
                dtCancelPlan.DateTime.Date,
                txtAbnormalNo.Text.Trim(),
                txtNote.Text.Trim(),
                requestBy);

            if (affected > 0)
            {
                MessageBox.Show("Đăng ký hủy Jig thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataChangeNotifier.Notify("JIG_CANCEL_REQUEST");
                Close();
            }
            else
            {
                MessageBox.Show("Không thể đăng ký hủy (có thể Jig đã có yêu cầu chờ duyệt).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
