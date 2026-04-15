using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DM_OHD.DB;
using DM_OHD.DTO;
using System;
using System.Data;
using System.Drawing;

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
            Load += (s, e) => LoadData();
        }

        private void LoadData()
        {
            grid.DataSource = _dto.GetRules();
            cboOwner.DataSource = _dto.GetUsers();
            cboOwner.DisplayMember = "USER_ID";
            cboOwner.ValueMember = "USER_ID";
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
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowGroupPanel = false;
            view.BestFitColumns();
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _dto.SaveRules(grid.DataSource as DataTable);
            int affected = _dto.ApplyRulesToAllProgress();
            XtraMessageBox.Show($"Đã lưu điều chỉnh quy tắc.{Environment.NewLine}Đã áp dụng lại quy tắc cho bảng PROGRESS: {Math.Max(0, affected)} dòng.");
            LoadData();
        }

        private void SetCaption(string field, string caption)
        {
            if (view.Columns[field] != null) view.Columns[field].Caption = caption;
        }
    }
}
