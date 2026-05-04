using DevExpress.XtraEditors.Controls;
using JigFlow.Data;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_REGISTER : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigRegisterService _service = new JigRegisterService();
        private bool _allowEditManagementNo = false;
        private readonly int? _requestId;
        private readonly string _masterControlNo;

        public FRM_JIG_REGISTER()
        {
            InitializeComponent();
        }

        public FRM_JIG_REGISTER(int REQUEST_ID)
        {
            _requestId = REQUEST_ID;
            InitializeComponent();
        }

        public FRM_JIG_REGISTER(string CONTROL_NO)
        {
            _masterControlNo = CONTROL_NO;
            InitializeComponent();
        }

        private void FRM_JIG_REGISTER_Load(object sender, EventArgs e)
        {
            ConfigureEditors();
            LoadCombos();
            txtManagementNo.Properties.ReadOnly = true;
            txtNameJig.Properties.ReadOnly = !_requestId.HasValue;
            txtSize.Properties.ReadOnly = true;
            txtFirstCheckFile.Properties.ReadOnly = true;

            if (_requestId.HasValue)
            {
                Text = "Cập nhật đăng ký Jig";
                lblTitle.Text = "Cập nhật đăng ký Jig";
                LoadRequestData(_requestId.Value);
            }
            else if (!string.IsNullOrWhiteSpace(_masterControlNo))
            {
                Text = "Cập nhật Jig";
                lblTitle.Text = "Cập nhật Jig";
                LoadMasterData(_masterControlNo);
            }
        }

        private void ConfigureEditors()
        {
            ConfigureComboBox(cboDepartment);
            ConfigureComboBox(cboFactory);
            ConfigureComboBox(cboFrequency);
            ConfigureLookUp(cboJigType);
            ConfigureLookUp(cboReportForm);
            ConfigureLookUp(cboDrawing);

            cboReportForm.Properties.NullText = "Chọn biểu mẫu";
            cboDrawing.Properties.NullText = "Chọn bản vẽ";
            cboFrequency.Properties.NullText = "Chọn tần suất";
            cboFactory.Properties.NullText = "Chọn nhà máy";
        }

        private static void ConfigureComboBox(DevExpress.XtraEditors.ComboBoxEdit edit)
        {
            edit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            edit.Properties.Buttons.Clear();
            edit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Combo));
        }

        private static void ConfigureLookUp(DevExpress.XtraEditors.LookUpEdit edit)
        {
            edit.Properties.TextEditStyle = TextEditStyles.Standard;
            edit.Properties.Buttons.Clear();
            edit.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Combo));
            edit.Properties.ShowHeader = false;
            edit.Properties.ShowFooter = false;
            edit.Properties.PopupSizeable = false;
        }

        private void LoadCombos()
        {
            cboJigType.Properties.DataSource = _service.GetJigTypes();
            cboJigType.Properties.DisplayMember = "JIG_TYPE_NAME";
            cboJigType.Properties.ValueMember = "JIG_TYPE_CODE";

            cboReportForm.Properties.DataSource = _service.GetFormMasters();
            cboReportForm.Properties.DisplayMember = "FORM_NAME";
            cboReportForm.Properties.ValueMember = "FORM_CODE";

            cboDrawing.Properties.DataSource = _service.GetDrawings();
            cboDrawing.Properties.DisplayMember = "DRAWING_NAME";
            cboDrawing.Properties.ValueMember = "DRAWING_CODE";

            cboDepartment.Properties.Items.Clear();
            cboDepartment.Properties.Items.AddRange(new object[] { "QA", "QC", "PE" });

            cboFactory.Properties.Items.Clear();
            cboFactory.Properties.Items.AddRange(new object[] { "F1", "F2", "F3" });

            cboFrequency.Properties.Items.Clear();
            cboFrequency.Properties.Items.AddRange(new object[] { "1 tháng", "3 tháng", "6 tháng", "1 năm", "2 năm" });
        }

        private void cboJigType_EditValueChanged(object sender, EventArgs e) => AutoFillNameAndManagementNo();

        private void txtSize_EditValueChanged(object sender, EventArgs e)
        {
            if (!txtSize.Properties.ReadOnly) AutoFillNameAndManagementNo();
        }

        private void AutoFillNameAndManagementNo()
        {
            if (_requestId.HasValue || !string.IsNullOrWhiteSpace(_masterControlNo))
            {
                return;
            }

            var TYPE_CODE = Convert.ToString(cboJigType.EditValue);
            if (string.IsNullOrWhiteSpace(TYPE_CODE)) return;

            var TYPE_NAME = cboJigType.Text ?? string.Empty;
            var IS_BRACKET = TYPE_NAME.ToUpper().Contains("BRACKET") || TYPE_CODE.ToUpper().Contains("BRACKET");
            var IS_HLC = TYPE_CODE.ToUpper().Contains("HLC");

            txtSize.Properties.ReadOnly = !IS_BRACKET;
            if (!IS_BRACKET) txtSize.Text = string.Empty;

            if (IS_HLC)
            {
                txtNameJig.Text = "J";
            }
            else if (IS_BRACKET)
            {
                var NUMBER_MATCH = Regex.Match(TYPE_NAME, "\\d+");
                var BRACKET_NO = NUMBER_MATCH.Success ? NUMBER_MATCH.Value : "1";
                txtNameJig.Text = $"BK{BRACKET_NO}";
            }
            else
            {
                txtNameJig.Text = "QA-JIG";
            }

            var YYMM = DateTime.Now.ToString("yyMM");
            string PREFIX;

            if (IS_HLC)
            {
                PREFIX = "J-";
                var SEQ_HLC = _service.GetNextSequenceByPrefix(PREFIX);
                txtManagementNo.Text = $"J-{SEQ_HLC:000}";
                return;
            }

            if (IS_BRACKET)
            {
                var SIZE_PART = string.IsNullOrWhiteSpace(txtSize.Text) ? "KT" : txtSize.Text.Trim();
                PREFIX = $"{txtNameJig.Text}-{SIZE_PART}-{YYMM}-";
            }
            else
            {
                PREFIX = $"{txtNameJig.Text}-{YYMM}-";
            }

            var SEQ = _service.GetNextSequenceByPrefix(PREFIX);
            txtManagementNo.Text = $"{PREFIX}{SEQ:000}";
        }

        private void btnEditManagementNo_Click(object sender, EventArgs e)
        {
            _allowEditManagementNo = !_allowEditManagementNo;
            txtManagementNo.Properties.ReadOnly = !_allowEditManagementNo;
            btnEditManagementNo.Text = _allowEditManagementNo ? "Khóa Số QL" : "Sửa Số QL";
        }

        private void btnBrowseResult_Click(object sender, EventArgs e)
        {
            using (var DIALOG = new OpenFileDialog())
            {
                if (DIALOG.ShowDialog() == DialogResult.OK)
                {
                    txtFirstCheckFile.Text = DIALOG.FileName;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtManagementNo.Text) || string.IsNullOrWhiteSpace(txtNameJig.Text))
            {
                MessageBox.Show("Vui lòng chọn loại Jig để tự sinh Tên Jig và Số quản lý.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var MANAGEMENT_NO = txtManagementNo.Text.Trim();
            if (string.IsNullOrWhiteSpace(_masterControlNo))
            {
                var IS_DUPLICATED = _service.IsManagementNoDuplicated(MANAGEMENT_NO, _requestId);
                if (IS_DUPLICATED)
                {
                    MessageBox.Show(
                        "Số quản lý đã tồn tại trong JIG MASTER hoặc danh sách đăng ký. Vui lòng kiểm tra lại.",
                        "Trùng số quản lý",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            var CREATED_BY = string.IsNullOrWhiteSpace(AppSession.UserId) ? "SYSTEM" : AppSession.UserId;
            if (!string.IsNullOrWhiteSpace(_masterControlNo))
            {
                _service.UpdateJigMasterFromRegister(
                    _masterControlNo,
                    MANAGEMENT_NO,
                    Convert.ToString(cboDepartment.EditValue),
                    Convert.ToString(cboFactory.EditValue),
                    txtNameJig.Text.Trim(),
                    Convert.ToString(cboJigType.EditValue),
                    txtSize.Text.Trim(),
                    txtUseProduct.Text.Trim(),
                    txtLocation.Text.Trim(),
                    deLastCheckDate.DateTime == DateTime.MinValue ? (DateTime?)null : deLastCheckDate.DateTime.Date,
                    cboFrequency.Text);

                MessageBox.Show("Đã cập nhật Jig.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataChangeNotifier.Notify("JIG_MASTER");
            }
            else if (_requestId.HasValue)
            {
                _service.UpdateRegisterRequest(
                    _requestId.Value,
                    Convert.ToString(cboDepartment.EditValue),
                    Convert.ToString(cboFactory.EditValue),
                    MANAGEMENT_NO,
                    txtNameJig.Text.Trim(),
                    Convert.ToString(cboJigType.EditValue),
                    txtSize.Text.Trim(),
                    txtUseProduct.Text.Trim(),
                    txtLocation.Text.Trim(),
                    deLastCheckDate.DateTime == DateTime.MinValue ? (DateTime?)null : deLastCheckDate.DateTime.Date,
                    cboFrequency.Text,
                    Convert.ToString(cboReportForm.EditValue),
                    txtFirstCheckFile.Text.Trim(),
                    Convert.ToString(cboDrawing.EditValue),
                    CREATED_BY);

                MessageBox.Show("Đã cập nhật đăng ký Jig chờ duyệt.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataChangeNotifier.Notify("JIG_REGISTER_REQUEST");
            }
            else
            {
                _service.CreateRegisterRequest(
                    Convert.ToString(cboDepartment.EditValue),
                    Convert.ToString(cboFactory.EditValue),
                    MANAGEMENT_NO,
                    txtNameJig.Text.Trim(),
                    Convert.ToString(cboJigType.EditValue),
                    txtSize.Text.Trim(),
                    txtUseProduct.Text.Trim(),
                    txtLocation.Text.Trim(),
                    deLastCheckDate.DateTime == DateTime.MinValue ? (DateTime?)null : deLastCheckDate.DateTime.Date,
                    cboFrequency.Text,
                    Convert.ToString(cboReportForm.EditValue),
                    txtFirstCheckFile.Text.Trim(),
                    Convert.ToString(cboDrawing.EditValue),
                    CREATED_BY);

                MessageBox.Show("Đã lưu đăng ký. Trạng thái sử dụng chuyển sang chờ duyệt.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataChangeNotifier.Notify("JIG_REGISTER_REQUEST");
            }

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void LoadRequestData(int REQUEST_ID)
        {
            DataRow ROW = _service.GetRegisterRequestById(REQUEST_ID);
            if (ROW == null) return;

            cboDepartment.EditValue = Convert.ToString(ROW["DEPARTMENT"]);
            cboFactory.EditValue = Convert.ToString(ROW["FACTORY"]);
            txtManagementNo.Text = Convert.ToString(ROW["MANAGEMENT_NO"]);
            txtNameJig.Text = Convert.ToString(ROW["JIG_NAME"]);
            cboJigType.EditValue = Convert.ToString(ROW["JIG_TYPE_CODE"]);
            txtSize.Text = Convert.ToString(ROW["JIG_SIZE"]);
            txtUseProduct.Text = Convert.ToString(ROW["USE_PRODUCT"]);
            txtLocation.Text = Convert.ToString(ROW["LOCATION_CODE"]);
            cboFrequency.EditValue = Convert.ToString(ROW["CHECK_FREQUENCY"]);
            cboReportForm.EditValue = Convert.ToString(ROW["REPORT_FORM_CODE"]);
            txtFirstCheckFile.Text = Convert.ToString(ROW["FIRST_CHECK_RESULT_FILE"]);
            cboDrawing.EditValue = Convert.ToString(ROW["DRAWING_CODE"]);
            if (ROW["LAST_CHECK_DATE"] != DBNull.Value)
            {
                deLastCheckDate.EditValue = Convert.ToDateTime(ROW["LAST_CHECK_DATE"]);
            }
            else
            {
                deLastCheckDate.EditValue = null;
            }
            txtSize.Properties.ReadOnly = !((Convert.ToString(ROW["JIG_TYPE_CODE"]) ?? string.Empty).ToUpper().Contains("BRACKET"));
        }

        private void LoadMasterData(string CONTROL_NO)
        {
            DataRow ROW = _service.GetJigMasterByControlNo(CONTROL_NO);
            if (ROW == null) return;

            cboDepartment.EditValue = Convert.ToString(ROW["USE_SECTION"]);
            cboFactory.EditValue = Convert.ToString(ROW["FACTORY"]);
            txtManagementNo.Text = Convert.ToString(ROW["CONTROL_NO"]);
            txtNameJig.Text = Convert.ToString(ROW["JIG_NAME"]);
            cboJigType.EditValue = Convert.ToString(ROW["JIG_TYPE_CODE"]);
            txtSize.Text = Convert.ToString(ROW["JIG_SIZE"]);
            txtUseProduct.Text = Convert.ToString(ROW["USE_PRODUCT"]);
            txtLocation.Text = Convert.ToString(ROW["LOCATION_CODE"]);
            cboFrequency.EditValue = Convert.ToString(ROW["CHECK_FREQUENCY"]);
            if (ROW.Table.Columns.Contains("LAST_CHECK_DATE") && ROW["LAST_CHECK_DATE"] != DBNull.Value)
            {
                deLastCheckDate.EditValue = Convert.ToDateTime(ROW["LAST_CHECK_DATE"]);
            }
            txtSize.Properties.ReadOnly = !((Convert.ToString(ROW["JIG_TYPE_CODE"]) ?? string.Empty).ToUpper().Contains("BRACKET"));
        }
    }
}
