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

        private void SetLoginState(bool loggedIn)
        {
            btnLogin.Enabled = !loggedIn;
            btnLogout.Enabled = loggedIn;
            btnChangePass.Enabled = loggedIn;
            btnAccountManagement.Enabled = loggedIn && AppSession.RoleCode == "ADMIN";
            bsiUser.Caption = loggedIn ? $"Xin chào: {AppSession.FullName}" : "Chưa đăng nhập";
        }

        private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new FRM_LOGIN())
            {
                if (frm.ShowDialog() == DialogResult.OK)
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
            using (var frm = new FRM_USER_CHANGE_PASSWORD())
            {
                frm.ShowDialog();
            }
        }

        private void btnAccountManagement_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrActivate(typeof(FRM_ACCOUNT_MANAGEMENT));
        }

        private void btnJigFunctionList_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrActivate(typeof(FRM_JIG_FUNCTION_LIST));
        }

        private void OpenOrActivate(Type type)
        {
            var opened = MdiChildren.FirstOrDefault(x => x.GetType() == type);
            if (opened != null)
            {
                opened.Activate();
                return;
            }

            Form frm = (Form)Activator.CreateInstance(type);
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
