using DevExpress.XtraBars;
using JigFlow.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            xtraTabbedMdiManager1.MdiParent = this;
            AppSession.Clear();
            SetLoginState(false);
            OpenOrActivate(typeof(FrmJigTypeList));
        }

        private void SetLoginState(bool loggedIn)
        {
            btnLogin.Enabled = !loggedIn;
            btnLogout.Enabled = loggedIn;
            btnChangePassword.Enabled = loggedIn;
            btnUserManagement.Enabled = loggedIn && AppSession.RoleCode == "ADMIN";
            bsiUser.Caption = loggedIn ? $"Xin chào: {AppSession.FullName}" : "Chưa đăng nhập";
        }

        private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new FrmLogin())
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

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new FrmChangePassword())
            {
                frm.ShowDialog();
            }
        }

        private void btnUserManagement_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrActivate(typeof(FrmUserManagement));
        }

        private void btnJigTypeList_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrActivate(typeof(FrmJigTypeList));
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
