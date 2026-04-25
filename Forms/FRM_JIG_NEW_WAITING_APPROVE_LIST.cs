using JigFlow.Data;
using System;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_JIG_NEW_WAITING_APPROVE_LIST : DevExpress.XtraEditors.XtraForm
    {
        private readonly JigRegisterService _service = new JigRegisterService();

        public FRM_JIG_NEW_WAITING_APPROVE_LIST()
        {
            InitializeComponent();
        }

        private void FRM_JIG_NEW_WAITING_APPROVE_LIST_Load(object sender, EventArgs e)
        {
            txtMode.Text = "View";
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            gcWaiting.DataSource = _service.GetWaitingApproveRequests();
            gvWaiting.BestFitColumns();
            txtRecord.Text = gvWaiting.RowCount.ToString();
            gvWaiting.Columns["REQUEST_AT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gvWaiting.Columns["REQUEST_AT"].DisplayFormat.FormatString = "dd-MM-yy";
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                dialog.FileName = $"Jig_New_Waiting_Approve_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                if (dialog.ShowDialog() != DialogResult.OK) return;
                gcWaiting.ExportToXlsx(dialog.FileName);
                MessageBox.Show("Đã xuất file thành công.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Update sẽ được triển khai theo workflow duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Delete sẽ được triển khai theo workflow duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Approve sẽ được triển khai theo workflow duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
