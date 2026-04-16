using DevExpress.XtraBars;
using JigFlow.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_MAIN : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FRM_MAIN()
        {
            InitializeComponent();
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            xtraTabbedMdiManager1.MdiParent = this;
            AppSession.Clear();
            SetLoginState(false);
            OpenOrActivate(typeof(FRM_JIG_FUNCTION_LIST));
        }

        private void SetLoginState(bool LOGGED_IN)
        {
            btnLogin.Enabled = !LOGGED_IN;
            btnLogout.Enabled = LOGGED_IN;
            btnChangePass.Enabled = LOGGED_IN;
            btnAccountManagement.Enabled = LOGGED_IN && AppSession.RoleCode == "ADMIN";
            bsiUser.Caption = LOGGED_IN ? $"Xin chào: {AppSession.FullName}" : "Chưa đăng nhập";
        }

        private void OpenOrActivate(Type FORM_TYPE)
        {
            var OPENED_FORM = MdiChildren.FirstOrDefault(x => x.GetType() == FORM_TYPE);
            if (OPENED_FORM != null)
            {
                OPENED_FORM.Activate();
                return;
            }

            Form FORM = (Form)Activator.CreateInstance(FORM_TYPE);
            FORM.MdiParent = this;
            FORM.Show();
        }

        private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var FORM_LOGIN = new FRM_LOGIN())
            {
                if (FORM_LOGIN.ShowDialog() == DialogResult.OK)
                {
                    SetLoginState(true);
                }
            }
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            AppSession.Clear();
            SetLoginState(false);
        }

        private void btnChangePass_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var FORM_CHANGE_PASS = new FRM_USER_CHANGE_PASSWORD())
            {
                FORM_CHANGE_PASS.ShowDialog();
            }
        }

        private void btnAccountManagement_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_ACCOUNT_MANAGEMENT));
        private void btnJigFunctionList_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_JIG_FUNCTION_LIST));
        private void btnJigVisualList_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_JIG_VISUAL_LIST));
        private void btnJigRegisterList_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_JIG_REGISTER_LIST));
        private void btnJigNewWaitingApprove_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_JIG_NEW_WAITING_APPROVE_LIST));
        private void btnJigRegisterHistory_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_JIG_REGISTER_HISTORY_LIST));
        private void btnJigNotChecked_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_JIG_NOT_CHECKED_LIST));
        private void btnJigCheckHistory_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_JIG_CHECK_HISTORY_LIST));
        private void btnJigCancelRegister_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_JIG_CANCEL_REGISTER));
        private void btnJigCancelWaitingApprove_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_JIG_CANCEL_WAITING_APPROVE_LIST));
        private void btnJigCancelHistory_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_JIG_CANCEL_HISTORY_LIST));
        private void btnJigDrawing_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_JIG_DRAWING_LIST));
        private void btnFormMaster_ItemClick(object sender, ItemClickEventArgs e) => OpenOrActivate(typeof(FRM_FORM_MASTER));
    }
}
