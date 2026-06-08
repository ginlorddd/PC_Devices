using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DM_OHD.DB;
using DM_OHD.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DM_OHD.FRM
{
    public partial class FRM_OHD_RULE : XtraForm
    {
        private readonly OhdAlertDTO _dto = new OhdAlertDTO();

        public FRM_OHD_RULE()
        {
            InitializeComponent();
            colorBgEdit.ParseEditValue += ColorEdit_ParseEditValue;
            colorFgEdit.ParseEditValue += ColorEdit_ParseEditValue;
            colorBgEdit.CustomDisplayText += ColorEdit_CustomDisplayText;
            colorFgEdit.CustomDisplayText += ColorEdit_CustomDisplayText;
            btnSave.Click += BtnSave_Click;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            Load += (s, e) => LoadData();
        }

        private void LoadData()
        {
            grid.DataSource = _dto.GetRules();
            ConfigureOwnerEditor(_dto.GetUsers());
            if (view.Columns["ID"] != null) view.Columns["ID"].Caption = "Stt";
            if (view.Columns["OWNER_USER_ID"] != null)
            {
                view.Columns["OWNER_USER_ID"].Caption = "Người phụ trách";
                view.Columns["OWNER_USER_ID"].ColumnEdit = cboOwner;
            }
            if (view.Columns["ALERT_CONTENT"] != null) view.Columns["ALERT_CONTENT"].Caption = "Nội dung cảnh báo";
            SetCaption("ALERT_BG_COLOR", "Màu nền cảnh báo");
            SetCaption("ALERT_FG_COLOR", "Màu chữ cảnh báo");
            if (view.Columns["ALERT_BG_COLOR"] != null) view.Columns["ALERT_BG_COLOR"].ColumnEdit = colorBgEdit;
            if (view.Columns["ALERT_FG_COLOR"] != null) view.Columns["ALERT_FG_COLOR"].ColumnEdit = colorFgEdit;
            SetCaption("DUE_DAYS_30", "30");
            SetCaption("DUE_DAYS_60", "60");
            SetCaption("DUE_DAYS_90", "90");
            SetCaption("DUE_DAYS_120", "120");
            SetCaption("DUE_DAYS_150", "150");
            SetCaption("DUE_DAYS_180", "180");
            SetCaption("DUE_DAYS_210", "210");
            SetCaption("DUE_DAYS_240", "240");
            SetCaption("USE_MONTH_FIRST_DAY", "Đạt mốc -> ngày 1");
            SetCaption("EXACT_DAY_IN_MONTH", "Chọn ngày chính xác");
            SetCaption("SEND_MAIL_AFTER_FINAL_DONE", "Gửi mail sau mục 5 OK");
            SetCaption("MAIL_DELAY_DAYS", "Số ngày sau mục 5");
            SetCaption("RULE_NOTE", "Ghi chú quy tắc");
            view.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowGroupPanel = false;
            view.BestFitColumns();
        }

        private void ConfigureOwnerEditor(DataTable users)
        {
            cboOwner.Items.Clear();
            foreach (DataRow user in users.Rows)
            {
                string userId = Convert.ToString(user["USER_ID"]);
                string fullName = Convert.ToString(user["FULL_NAME"]);
                string display = string.IsNullOrWhiteSpace(fullName) ? userId : $"{userId} - {fullName}";
                cboOwner.Items.Add(userId, display, CheckState.Unchecked, true);
            }
            cboOwner.SeparatorChar = ',';
            cboOwner.SelectAllItemCaption = "Chọn tất cả";
        }

        private void ColorEdit_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (e.Value is Color color)
            {
                e.Value = ColorTranslator.ToHtml(color);
                e.Handled = true;
                return;
            }

            string text = Convert.ToString(e.Value);
            if (string.IsNullOrWhiteSpace(text))
            {
                e.Value = "#FFF3CD";
                e.Handled = true;
            }
        }

        private void ColorEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            string text = Convert.ToString(e.Value);
            if (string.IsNullOrWhiteSpace(text))
            {
                e.DisplayText = string.Empty;
                return;
            }

            try
            {
                Color color = ColorTranslator.FromHtml(text);
                e.DisplayText = $"{color.R}, {color.G}, {color.B}";
            }
            catch
            {
                e.DisplayText = text;
            }
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = grid.DataSource as DataTable;
            if (dt == null) return;
            DataRow row = dt.NewRow();
            row["OWNER_USER_ID"] = string.Empty;
            row["ALERT_CONTENT"] = "Nội dung cảnh báo mới";
            row["ALERT_BG_COLOR"] = "#FFF3CD";
            row["ALERT_FG_COLOR"] = "#7A4E00";
            row["DUE_DAYS_30"] = 30;
            row["DUE_DAYS_60"] = 60;
            row["DUE_DAYS_90"] = 90;
            row["DUE_DAYS_120"] = 120;
            row["DUE_DAYS_150"] = 150;
            row["DUE_DAYS_180"] = 180;
            row["DUE_DAYS_210"] = 210;
            row["DUE_DAYS_240"] = 240;
            row["USE_MONTH_FIRST_DAY"] = true;
            row["SEND_MAIL_AFTER_FINAL_DONE"] = false;
            row["MAIL_DELAY_DAYS"] = 1;
            row["RULE_NOTE"] = string.Empty;
            dt.Rows.Add(row);
            view.FocusedRowHandle = view.GetRowHandle(dt.Rows.Count - 1);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int[] selectedRows = view.GetSelectedRows();
            if (selectedRows == null || selectedRows.Length == 0)
            {
                XtraMessageBox.Show("Vui lòng chọn quy tắc cần xóa.");
                return;
            }
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa các quy tắc đang chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            for (int i = selectedRows.Length - 1; i >= 0; i--)
            {
                if (selectedRows[i] >= 0) view.DeleteRow(selectedRows[i]);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            view.CloseEditor();
            view.UpdateCurrentRow();
            _dto.SaveRules(grid.DataSource as DataTable);
            int inserted = _dto.RefreshProgressFromPlan();
            int affected = _dto.ApplyRulesToAllProgress();
            int mailAffected = _dto.ApplyPostFinalCompletionMailRules();
            XtraMessageBox.Show($"Đã lưu điều chỉnh quy tắc.{Environment.NewLine}Đã bổ sung cảnh báo theo quy tắc mới: {Math.Max(0, inserted)} dòng.{Environment.NewLine}Đã áp dụng lại quy tắc cho bảng PROGRESS: {Math.Max(0, affected)} dòng.{Environment.NewLine}Đã áp dụng quy tắc gửi mail sau Hoàn thiện part: {Math.Max(0, mailAffected)} dòng.");
            LoadData();
        }

        private void SetCaption(string field, string caption)
        {
            if (view.Columns[field] != null) view.Columns[field].Caption = caption;
        }
    }
}
