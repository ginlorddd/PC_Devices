using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DM_OHD.DB;
using DM_OHD.DTO;
using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DM_OHD.FRM
{
    public partial class FRM_OHD_ALERT : XtraForm
    {
        private readonly OhdAlertDTO _dto = new OhdAlertDTO();

        public FRM_OHD_ALERT()
        {
            InitializeComponent();
            btnRefresh.Click += (s, e) => LoadData();
            btnUpdate.Click += BtnUpdate_Click;
            btnApprove.Click += BtnApprove_Click;
            btnSave.Click += BtnSave_Click;
            btnConfigMail.Click += BtnConfigMail_Click;
            btnRule.Click += BtnRule_Click;
            ConfigureMonthEditor(deFrom);
            ConfigureMonthEditor(deTo);
            deFrom.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            deTo.EditValue = new DateTime(DateTime.Today.Year + 1, 12, 1);
            Load += FRM_OHD_ALERT_Load;
        }

        private void ConfigureMonthEditor(DateEdit editor)
        {
            editor.Properties.Mask.EditMask = "MM/yyyy";
            editor.Properties.Mask.UseMaskAsDisplayFormat = true;
            editor.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            editor.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            editor.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            editor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        private void FRM_OHD_ALERT_Load(object sender, EventArgs e)
        {
            bool isAdmin = Constaint.IsAdmin();
            btnConfigMail.Visible = isAdmin;
            btnConfigMail.Enabled = isAdmin;
            if (!isAdmin)
            {
                btnConfigMail.ToolTip = "Chỉ tài khoản ADMIN mới được cấu hình mail.";
            }
            LoadData();
        }

        private void BtnConfigMail_Click(object sender, EventArgs e)
        {
            using (var frm = new FRM_MAIL_CONFIG())
            {
                frm.ShowDialog(this);
            }
        }

        private void BtnRule_Click(object sender, EventArgs e)
        {
            using (var frm = new FRM_OHD_RULE())
            {
                frm.ShowDialog(this);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int inserted = _dto.RefreshProgressFromPlan();
            DataTable fixedResult = _dto.ValidateAndFixProgressByRules();
            int fixedOwner = 0;
            int fixedColor = 0;
            int fixedContent = 0;
            if (fixedResult != null && fixedResult.Rows.Count > 0)
            {
                DataRow row = fixedResult.Rows[0];
                fixedOwner = ToInt(row["FIXED_OWNER"]);
                fixedColor = ToInt(row["FIXED_COLOR"]);
                fixedContent = ToInt(row["FIXED_CONTENT"]);
            }

            XtraMessageBox.Show(
                $"Đã cập nhật khuôn vào bảng cảnh báo: {Math.Max(0, inserted)} dòng."
                + Environment.NewLine
                + $"Đã chuẩn hóa theo quy tắc: Người phụ trách {fixedOwner} dòng, Nội dung cảnh báo {fixedContent} dòng, Màu cảnh báo {fixedColor} dòng.");
            LoadData();
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            int[] selected = view.GetSelectedRows();
            if (selected == null || selected.Length == 0)
            {
                XtraMessageBox.Show("Vui lòng chọn dòng để duyệt.");
                return;
            }

            foreach (int rowHandle in selected.Where(x => x >= 0))
            {
                view.SetRowCellValue(rowHandle, "APPROVED", true);
                view.SetRowCellValue(rowHandle, "COMPLETED_AT", DateTime.Now);
                view.SetRowCellValue(rowHandle, "REVIEW_NOTE", "Đã hoàn thành");
            }

            XtraMessageBox.Show("Đã đánh dấu duyệt hoàn thành. Vui lòng bấm Lưu để cập nhật.");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _dto.SaveProgress(grid.DataSource as DataTable);
            XtraMessageBox.Show("Đã lưu cảnh báo tiến độ.");
            LoadData();
        }

        private void LoadData()
        {
            DateTime from = deFrom.DateTime == DateTime.MinValue ? DateTime.Today : deFrom.DateTime;
            DateTime to = deTo.DateTime == DateTime.MinValue ? DateTime.Today.AddMonths(3) : deTo.DateTime;
            if (from > to)
            {
                DateTime tmp = from; from = to; to = tmp;
            }

            DataTable dt = _dto.GetProgress(from.Date, to.Date);
            foreach (DataRow row in dt.Rows)
            {
                bool approved = row["APPROVED"] != DBNull.Value && Convert.ToBoolean(row["APPROVED"]);
                DateTime? completed = row["COMPLETED_AT"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["COMPLETED_AT"]);
                DateTime trackDate = row["TRACK_START_DATE"] == DBNull.Value ? DateTime.Today : Convert.ToDateTime(row["TRACK_START_DATE"]);
                if (approved || completed.HasValue)
                {
                    row["REVIEW_NOTE"] = "Đã hoàn thành";
                    continue;
                }

                int lateDays = (DateTime.Today.Date - trackDate.Date).Days;
                row["REVIEW_NOTE"] = lateDays > 0 ? $"{lateDays} ngày chậm kế hoạch" : "Chưa hoàn thành";
            }
            grid.DataSource = dt;
            if (view.Columns["ID"] != null) view.Columns["ID"].Visible = false;
            SetCaption("DIE_NO", "Số khuôn");
            SetCaption("DIE_NAME", "Tên khuôn");
            SetCaption("TOTAL_CAVITY", "Số cavity");
            SetCaption("NEXT_OHD_MOC", "Mốc OHD sắp tới");
            SetCaption("TRACK_START_DATE", "Ngày bắt đầu theo dõi");
            SetCaption("ALERT_CONTENT", "Nội dung cảnh báo");
            if (view.Columns["ALERT_BG_COLOR"] != null) view.Columns["ALERT_BG_COLOR"].Visible = false;
            if (view.Columns["ALERT_FG_COLOR"] != null) view.Columns["ALERT_FG_COLOR"].Visible = false;
            SetCaption("REVIEW_NOTE", "Đánh giá");
            SetCaption("OWNER_USER_ID", "Người phụ trách");
            SetCaption("COMPLETED_AT", "Ngày hoàn thành");
            SetCaption("APPROVED", "Duyệt hoàn thành");
            view.OptionsSelection.MultiSelect = true;
            view.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowGroupPanel = false;
            view.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            view.Appearance.HeaderPanel.Options.UseFont = true;
            view.RowCellStyle -= View_RowCellStyle;
            view.RowCellStyle += View_RowCellStyle;
            view.BestFitColumns();
        }

        private void View_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            string field = e.Column?.FieldName ?? string.Empty;
            if (field == "REVIEW_NOTE")
            {
                string review = Convert.ToString(view.GetRowCellValue(e.RowHandle, "REVIEW_NOTE"));
                DateTime? completed = view.GetRowCellValue(e.RowHandle, "COMPLETED_AT") == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, "COMPLETED_AT"));
                if (completed.HasValue || review == "Đã hoàn thành")
                {
                    e.Appearance.BackColor = Color.FromArgb(198, 239, 206);
                    return;
                }
                if (review != null && review.Contains("chậm"))
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 199, 206);
                    return;
                }
                e.Appearance.BackColor = Color.FromArgb(255, 235, 156);
            }

            if (field == "ALERT_CONTENT")
            {
                string bg = Convert.ToString(view.GetRowCellValue(e.RowHandle, "ALERT_BG_COLOR"));
                string fg = Convert.ToString(view.GetRowCellValue(e.RowHandle, "ALERT_FG_COLOR"));
                try
                {
                    if (!string.IsNullOrWhiteSpace(bg)) e.Appearance.BackColor = ColorTranslator.FromHtml(bg);
                    if (!string.IsNullOrWhiteSpace(fg)) e.Appearance.ForeColor = ColorTranslator.FromHtml(fg);
                }
                catch { }
            }
        }

        private void SetCaption(string field, string caption)
        {
            if (view.Columns[field] != null) view.Columns[field].Caption = caption;
        }

        private int ToInt(object value) => int.TryParse(Convert.ToString(value), out int x) ? x : 0;
    }
}
