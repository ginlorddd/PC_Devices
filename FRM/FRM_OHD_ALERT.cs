using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DM_OHD.DTO;
using System;
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
            btnConfigMail.Click += (s, e) => new FRM_MAIL_CONFIG { MdiParent = this.MdiParent }.Show();
            btnRule.Click += (s, e) => new FRM_OHD_RULE { MdiParent = this.MdiParent }.Show();
            deFrom.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            deTo.EditValue = DateTime.Today.AddMonths(3);
            Load += (s, e) => LoadData();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int inserted = _dto.RefreshProgressFromPlan();
            XtraMessageBox.Show($"Đã cập nhật khuôn vào bảng cảnh báo: {Math.Max(0, inserted)} dòng.");
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
                int id = ToInt(view.GetRowCellValue(rowHandle, "ID"));
                if (id <= 0) continue;
                string review = Convert.ToString(view.GetRowCellValue(rowHandle, "REVIEW_NOTE"));
                _dto.ApproveProgress(id, review);
            }

            XtraMessageBox.Show("Đã duyệt hoàn thành. Các nội dung đã duyệt sẽ dừng nhắc mail.");
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

            grid.DataSource = _dto.GetProgress(from.Date, to.Date);
            if (view.Columns["ID"] != null) view.Columns["ID"].Visible = false;
            SetCaption("DIE_NO", "Số khuôn");
            SetCaption("DIE_NAME", "Tên khuôn");
            SetCaption("TOTAL_CAVITY", "Số cavity");
            SetCaption("NEXT_OHD_MOC", "Mốc OHD sắp tới");
            SetCaption("TRACK_START_DATE", "Ngày bắt đầu theo dõi");
            SetCaption("ALERT_CONTENT", "Nội dung cảnh báo");
            SetCaption("REVIEW_NOTE", "Đánh giá");
            SetCaption("OWNER_USER_ID", "Người phụ trách");
            SetCaption("COMPLETED_AT", "Ngày hoàn thành");
            SetCaption("APPROVED", "Đã duyệt");
            view.OptionsSelection.MultiSelect = true;
            view.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowGroupPanel = false;
            view.BestFitColumns();
        }

        private void SetCaption(string field, string caption)
        {
            if (view.Columns[field] != null) view.Columns[field].Caption = caption;
        }

        private int ToInt(object value) => int.TryParse(Convert.ToString(value), out int x) ? x : 0;
    }
}
