using DevExpress.XtraEditors;
using DM_OHD.DB;
using DM_OHD.DTO;
using System;
using System.Data;

namespace DM_OHD.FRM
{
    public partial class FRM_MAIL_CONFIG : XtraForm
    {
        private readonly OhdAlertDTO _dto = new OhdAlertDTO();

        public FRM_MAIL_CONFIG()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnSendTest.Click += (s, e) => XtraMessageBox.Show("Chức năng gửi mail task schedule sẽ phát triển sau.");
            Load += (s, e) => LoadData();
        }

        private void LoadData()
        {
            bool isAdmin = Constaint.IsAdmin() || Constaint.HasRole("ADMIN");
            btnSave.Enabled = isAdmin;
            btnSendTest.Enabled = isAdmin;
            if (!isAdmin)
            {
                XtraMessageBox.Show("Chỉ admin mới được cấu hình mail.");
            }

            DataTable dt = _dto.GetMailConfig();
            if (dt.Rows.Count == 0) return;
            DataRow r = dt.Rows[0];
            txtTo.Text = Convert.ToString(r["MAIL_TO"]);
            txtCc.Text = Convert.ToString(r["MAIL_CC"]);
            txtSubject.Text = Convert.ToString(r["SUBJECT_TEMPLATE"]);
            txtBody.Text = Convert.ToString(r["BODY_TEMPLATE"]);
            spFreq.Value = ToInt(r["SEND_FREQUENCY_DAYS"]);
            chkEnabled.Checked = r["ENABLED"] != DBNull.Value && Convert.ToBoolean(r["ENABLED"]);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _dto.SaveMailConfig(txtTo.Text.Trim(), txtCc.Text.Trim(), txtSubject.Text.Trim(), txtBody.Text, (int)spFreq.Value, chkEnabled.Checked);
            XtraMessageBox.Show("Đã lưu cấu hình mail.");
        }

        private int ToInt(object value) => int.TryParse(Convert.ToString(value), out int x) ? x : 1;
    }
}
