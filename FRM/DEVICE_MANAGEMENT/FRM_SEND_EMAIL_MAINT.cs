using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using outlook = Microsoft.Office.Interop.Outlook;
using PC_Devices.DB;

namespace PC_Devices.FRM.MAIL
{
    public partial class FRM_SEND_EMAIL_MAINT : XtraForm
    {
        private string _maQuanLy;
        private string _tenThietBi;
        private DateTime? _ngayKeHoachBD;
        private int _daysRemain;

        /// <summary>
        /// Form gửi mail nhắc bảo dưỡng thiết bị
        /// </summary>
        /// <param name="maQuanLy">Mã quản lý thiết bị</param>
        /// <param name="tenThietBi">Tên thiết bị</param>
        /// <param name="ngayKeHoachBD">Ngày bảo dưỡng tiếp theo</param>
        /// <param name="daysRemain">Số ngày còn lại (có thể truyền từ form lịch bảo dưỡng)</param>
        public FRM_SEND_EMAIL_MAINT(string maQuanLy, string tenThietBi, DateTime? ngayKeHoachBD, int daysRemain)
        {
            InitializeComponent();
            _maQuanLy = maQuanLy;
            _tenThietBi = tenThietBi;
            _ngayKeHoachBD = ngayKeHoachBD;
            _daysRemain = daysRemain;
        }

        private void FRM_SEND_EMAIL_MAINT_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy danh sách mail từ TBL_ACCOUNT (ví dụ tất cả user có EMAIL)
                string queryMail = "SELECT EMAIL FROM TBL_ACCOUNT WHERE EMAIL IS NOT NULL AND EMAIL <> ''";
                DataTable dtMail = DBUtils._getData(queryMail);

                string listMail = string.Empty;
                if (dtMail != null && dtMail.Rows.Count > 0)
                {
                    foreach (DataRow row in dtMail.Rows)
                    {
                        string mail = row["EMAIL"].ToString();
                        if (!string.IsNullOrEmpty(mail))
                        {
                            if (!listMail.Contains(mail))
                            {
                                if (!string.IsNullOrEmpty(listMail))
                                    listMail += ";";
                                listMail += mail;
                            }
                        }
                    }
                }

                // 2. Gán To, CC, Subject, Body
                txtTo.Text = listMail;
                txtCc.Text = ""; // nếu có mail CC cố định thì set ở đây

                string ngayText = _ngayKeHoachBD.HasValue
                    ? _ngayKeHoachBD.Value.ToString("dd/MM/yyyy")
                    : "(chưa xác định)";

                txtSubject.Text = $"[PC-Devices] Nhắc bảo dưỡng thiết bị: {_maQuanLy} - {_tenThietBi}";

                string alertLine = string.Empty;
                if (_ngayKeHoachBD.HasValue)
                {
                    if (_daysRemain < 0)
                        alertLine = $"Thiết bị đã quá hạn bảo dưỡng {_daysRemain * -1} ngày.";
                    else
                        alertLine = $"Còn {_daysRemain} ngày đến hạn bảo dưỡng.";
                }

                txtBody.Text =
                    "Dear all," +
                    "\r\n\r\n" +
                    "Bộ phận PC gửi mail nhắc bảo dưỡng thiết bị như sau:" +
                    "\r\n\r\n" +
                    $" - Tên thiết bị : {_tenThietBi}" +
                    "\r\n" +
                    $" - Mã quản lý   : {_maQuanLy}" +
                    "\r\n" +
                    $" - Ngày bảo dưỡng kế tiếp : {ngayText}" +
                    "\r\n" +
                    (!string.IsNullOrEmpty(alertLine) ? " - Tình trạng : " + alertLine + "\r\n" : "") +
                    "\r\n" +
                    "Đề nghị các bên liên quan sắp xếp kế hoạch bảo dưỡng, thực hiện đúng thời hạn." +
                    "\r\n\r\n" +
                    "Trân trọng," +
                    "\r\n" +
                    "Phòng PC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load form gửi email:\n" + ex.ToString(),
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTo.Text))
                {
                    MessageBox.Show("Danh sách mail 'To' đang trống!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                outlook.Application app = new outlook.Application();
                outlook.MailItem mail = (outlook.MailItem)app.CreateItem(outlook.OlItemType.olMailItem);

                mail.To = txtTo.Text.Trim();
                mail.CC = txtCc.Text.Trim();
                mail.Subject = txtSubject.Text;
                mail.Body = txtBody.Text;
                mail.Importance = outlook.OlImportance.olImportanceHigh;

                mail.Send();

                MessageBox.Show("Đã gửi email nhắc bảo dưỡng thành công!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi mail:\n" + ex.ToString(),
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
