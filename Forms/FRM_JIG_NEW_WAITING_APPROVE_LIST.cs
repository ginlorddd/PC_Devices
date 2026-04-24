using JigFlow.Data;
using System;

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
        }
    }
}
