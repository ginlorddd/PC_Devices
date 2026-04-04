using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using PC_Devices.DB;
using System;
using System.Windows.Forms;

namespace PC_Devices.FRM
{
    public class FRM_MAIN : RibbonForm
    {
        public FRM_MAIN()
        {
            Text = "DM_OHD";
            WindowState = FormWindowState.Maximized;

            RibbonControl ribbon = new RibbonControl();
            RibbonPage page = new RibbonPage("Hệ thống");
            RibbonPageGroup group = new RibbonPageGroup("Chức năng");

            BarButtonItem btnDieMaster = new BarButtonItem { Caption = "Die Master" };
            btnDieMaster.ItemClick += (s, e) => OpenChild(new FRM_DIE_MASTER());

            BarButtonItem btnAccount = new BarButtonItem { Caption = "Quản lý tài khoản" };
            btnAccount.ItemClick += (s, e) => OpenChild(new FRM_ACCOUNT_MANAGEMENT());

            BarButtonItem btnChangePassword = new BarButtonItem { Caption = "Đổi mật khẩu" };
            btnChangePassword.ItemClick += (s, e) => OpenChild(new FRM_CHANGE_PASSWORD());

            group.ItemLinks.Add(btnDieMaster);
            group.ItemLinks.Add(btnAccount);
            group.ItemLinks.Add(btnChangePassword);
            page.Groups.Add(group);
            ribbon.Pages.Add(page);
            Controls.Add(ribbon);
            Ribbon = ribbon;

            IsMdiContainer = true;

            btnAccount.Enabled = Constaint.IsAdmin() || Constaint.HasRole("ACCOUNT_MGMT");
            btnDieMaster.Enabled = Constaint.IsAdmin() || Constaint.HasRole("DIE_MST_MGMT");
        }

        private void OpenChild(Form frm)
        {
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
