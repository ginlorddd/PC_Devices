using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PC_Devices.DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PC_Devices.FRM
{
    public partial class FRM_MAIL_CONFIG : XtraForm
    {
        public FRM_MAIL_CONFIG()
        {
            InitializeComponent();
        }

        private void FRM_MAIL_CONFIG_Load(object sender, EventArgs e)
        {
            // Kiểm tra quyền admin
            if (Constaint._access != "1")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Cảnh báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            LoadConfig();
            LoadAccountMail();
        }

        // ====================================================
        // 1) Load cấu hình từ bảng TBL_MAIL_CONFIG
        // ====================================================
        private void LoadConfig()
        {
            try
            {
                string query = "SELECT TOP 1 * FROM TBL_MAIL_CONFIG ORDER BY ID DESC";

                DataTable dt = DBUtils._getData(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    numWarningDays.Value = Convert.ToInt32(dt.Rows[0]["WarningDays"]);
                    checkAutoSend.Checked = Convert.ToBoolean(dt.Rows[0]["IsAutoSend"]);
                    txtMailNote.Text = dt.Rows[0]["UpdateBy"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadConfig:\n" + ex.Message);
            }
        }

        // ====================================================
        // 2) Load danh sách email nhân sự
        // ====================================================
        private void LoadAccountMail()
        {
            try
            {
                string query = "SELECT USER_ID, FULLNAME, EMAIL FROM TBL_ACCOUNT";

                DataTable dt = DBUtils._getData(query);

                gcMail.DataSource = dt;

                // Quan trọng: Gán đúng view
                gcMail.MainView = gvMail;

                // Quan trọng: Tự tạo cột
                gvMail.PopulateColumns();

                // Sửa tên cột
                gvMail.Columns["USER_ID"].Caption = "User";
                gvMail.Columns["FULLNAME"].Caption = "Họ tên";
                gvMail.Columns["EMAIL"].Caption = "Email";

                // Cho phép edit email
                gvMail.Columns["EMAIL"].OptionsColumn.AllowEdit = true;

                gvMail.OptionsBehavior.Editable = true;
                gvMail.OptionsView.ShowGroupPanel = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadAccountMail:\n" + ex.Message);
            }
        }


        // ====================================================
        // 3) Lưu cấu hình
        // ====================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show("Bạn muốn lưu cấu hình gửi mail?",
                                                "Xác nhận",
                                                MessageBoxButtons.OKCancel,
                                                MessageBoxIcon.Question);

            if (ask != DialogResult.OK)
                return;

            try
            {
                string query = @"
                UPDATE TBL_MAIL_CONFIG 
                SET WarningDays = @WarningDays,
                    IsAutoSend = @IsAutoSend,
                    UpdateAt = GETDATE(),
                    UpdateBy = @UpdateBy";

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@WarningDays", numWarningDays.Value);
                    cmd.Parameters.AddWithValue("@IsAutoSend", checkAutoSend.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@UpdateBy", Constaint._userID);

                    cmd.ExecuteNonQuery();
                }

                // Lưu email đã chỉnh sửa trực tiếp trên grid
                SaveEmailChanges();

                MessageBox.Show("Đã lưu cấu hình và danh sách email!",
                                 "Thông báo",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu cấu hình:\n" + ex.Message);
            }
        }

        // ====================================================
        // 4) Lưu các email đã update ngay trên gridControl
        // ====================================================
        private void SaveEmailChanges()
        {
            try
            {
                gvMail.PostEditor();
                gvMail.UpdateCurrentRow();

                DataTable dt = gcMail.DataSource as DataTable;
                if (dt == null) return;

                using (SqlConnection conn = new SqlConnection(DBUtils._stringConnection))
                {
                    conn.Open();

                    foreach (DataRow row in dt.Rows)
                    {
                        string update = @"UPDATE TBL_ACCOUNT 
                                          SET Email = @Email 
                                          WHERE USER_ID = @User";

                        SqlCommand cmd = new SqlCommand(update, conn);
                        cmd.Parameters.AddWithValue("@Email", row["Email"] ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@User", row["USER_ID"].ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SaveEmailChanges:\n" + ex.Message);
            }
        }
    }
}
