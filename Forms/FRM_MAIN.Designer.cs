namespace JigFlow.Forms
{
    partial class FRM_MAIN
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.subUser = new DevExpress.XtraBars.BarSubItem();
            this.btnLoginMenu = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserInfoMenu = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogoutMenu = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePassMenu = new DevExpress.XtraBars.BarButtonItem();
            this.btnExitMenu = new DevExpress.XtraBars.BarButtonItem();
            this.btnAccountManagement = new DevExpress.XtraBars.BarButtonItem();
            this.btnJigFunctionList = new DevExpress.XtraBars.BarButtonItem();
            this.btnJigVisualList = new DevExpress.XtraBars.BarButtonItem();
            this.btnJigRegisterList = new DevExpress.XtraBars.BarButtonItem();
            this.btnJigNewWaitingApprove = new DevExpress.XtraBars.BarButtonItem();
            this.btnJigRegisterHistory = new DevExpress.XtraBars.BarButtonItem();
            this.btnJigNotChecked = new DevExpress.XtraBars.BarButtonItem();
            this.btnJigCheckHistory = new DevExpress.XtraBars.BarButtonItem();
            this.btnJigCancelRegister = new DevExpress.XtraBars.BarButtonItem();
            this.btnJigCancelWaitingApprove = new DevExpress.XtraBars.BarButtonItem();
            this.btnJigCancelHistory = new DevExpress.XtraBars.BarButtonItem();
            this.btnJigDrawing = new DevExpress.XtraBars.BarButtonItem();
            this.btnFormMaster = new DevExpress.XtraBars.BarButtonItem();
            this.btnJigTypeMaster = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgMaster = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgRegister = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgCheck = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgCancel = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.btnAccountFloat = new DevExpress.XtraEditors.SimpleButton();
            this.accountMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.accountMenu.SuspendLayout();
            this.SuspendLayout();
            // ribbonControl1
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.ribbonControl1.ExpandCollapseItem,
                this.subUser,
                this.btnLoginMenu,
                this.btnUserInfoMenu,
                this.btnLogoutMenu,
                this.btnChangePassMenu,
                this.btnExitMenu,
                this.btnAccountManagement,
                this.btnJigFunctionList,
                this.btnJigVisualList,
                this.btnJigRegisterList,
                this.btnJigNewWaitingApprove,
                this.btnJigRegisterHistory,
                this.btnJigNotChecked,
                this.btnJigCheckHistory,
                this.btnJigCancelRegister,
                this.btnJigCancelWaitingApprove,
                this.btnJigCancelHistory,
                this.btnJigDrawing,
                this.btnFormMaster,
                this.btnJigTypeMaster});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 21;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.subUser);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { this.ribbonPage1 });
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Size = new System.Drawing.Size(1280, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;

            // subUser
            this.subUser.Caption = "Đăng nhập";
            this.subUser.Id = 1;
            this.subUser.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.btnLoginMenu),
                new DevExpress.XtraBars.LinkPersistInfo(this.btnLogoutMenu),
                new DevExpress.XtraBars.LinkPersistInfo(this.btnChangePassMenu),
                new DevExpress.XtraBars.LinkPersistInfo(this.btnExitMenu)});
            this.subUser.Name = "subUser";
            this.subUser.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;

            // account menu items
            this.btnLoginMenu.Caption = "Đăng nhập"; this.btnLoginMenu.Id = 2; this.btnLoginMenu.Name = "btnLoginMenu"; this.btnLoginMenu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoginMenu_ItemClick);
            this.btnUserInfoMenu.Caption = "User"; this.btnUserInfoMenu.Enabled = false; this.btnUserInfoMenu.Id = 3; this.btnUserInfoMenu.Name = "btnUserInfoMenu";
            this.btnLogoutMenu.Caption = "Đăng xuất"; this.btnLogoutMenu.Id = 4; this.btnLogoutMenu.Name = "btnLogoutMenu"; this.btnLogoutMenu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogoutMenu_ItemClick);
            this.btnChangePassMenu.Caption = "Đổi mật khẩu"; this.btnChangePassMenu.Id = 5; this.btnChangePassMenu.Name = "btnChangePassMenu"; this.btnChangePassMenu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangePassMenu_ItemClick);
            this.btnExitMenu.Caption = "Thoát"; this.btnExitMenu.Id = 6; this.btnExitMenu.Name = "btnExitMenu"; this.btnExitMenu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExitMenu_ItemClick);

            // function items
            this.btnAccountManagement.Caption = "Quản lý tài khoản"; this.btnAccountManagement.Id = 7; this.btnAccountManagement.Name = "btnAccountManagement"; this.btnAccountManagement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAccountManagement_ItemClick);
            this.btnJigFunctionList.Caption = "Jig chức năng"; this.btnJigFunctionList.Id = 8; this.btnJigFunctionList.Name = "btnJigFunctionList"; this.btnJigFunctionList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigFunctionList_ItemClick);
            this.btnJigVisualList.Caption = "Jig ngoại quan"; this.btnJigVisualList.Id = 9; this.btnJigVisualList.Name = "btnJigVisualList"; this.btnJigVisualList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigVisualList_ItemClick);
            this.btnJigRegisterList.Caption = "Đăng ký Jig"; this.btnJigRegisterList.Id = 10; this.btnJigRegisterList.Name = "btnJigRegisterList"; this.btnJigRegisterList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigRegisterList_ItemClick);
            this.btnJigNewWaitingApprove.Caption = "Jig mới chờ duyệt"; this.btnJigNewWaitingApprove.Id = 11; this.btnJigNewWaitingApprove.Name = "btnJigNewWaitingApprove"; this.btnJigNewWaitingApprove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigNewWaitingApprove_ItemClick);
            this.btnJigRegisterHistory.Caption = "Lịch sử đăng ký Jig"; this.btnJigRegisterHistory.Id = 12; this.btnJigRegisterHistory.Name = "btnJigRegisterHistory"; this.btnJigRegisterHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigRegisterHistory_ItemClick);
            this.btnJigNotChecked.Caption = "Jig chưa được kiểm tra"; this.btnJigNotChecked.Id = 13; this.btnJigNotChecked.Name = "btnJigNotChecked"; this.btnJigNotChecked.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigNotChecked_ItemClick);
            this.btnJigCheckHistory.Caption = "Lịch sử kiểm tra Jig"; this.btnJigCheckHistory.Id = 14; this.btnJigCheckHistory.Name = "btnJigCheckHistory"; this.btnJigCheckHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigCheckHistory_ItemClick);
            this.btnJigCancelRegister.Caption = "Đăng ký hủy Jig"; this.btnJigCancelRegister.Id = 15; this.btnJigCancelRegister.Name = "btnJigCancelRegister"; this.btnJigCancelRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigCancelRegister_ItemClick);
            this.btnJigCancelWaitingApprove.Caption = "Jig hủy chờ duyệt"; this.btnJigCancelWaitingApprove.Id = 16; this.btnJigCancelWaitingApprove.Name = "btnJigCancelWaitingApprove"; this.btnJigCancelWaitingApprove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigCancelWaitingApprove_ItemClick);
            this.btnJigCancelHistory.Caption = "Lịch sử hủy Jig"; this.btnJigCancelHistory.Id = 17; this.btnJigCancelHistory.Name = "btnJigCancelHistory"; this.btnJigCancelHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigCancelHistory_ItemClick);
            this.btnJigDrawing.Caption = "Bản vẽ Jig"; this.btnJigDrawing.Id = 18; this.btnJigDrawing.Name = "btnJigDrawing"; this.btnJigDrawing.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigDrawing_ItemClick);
            this.btnFormMaster.Caption = "Form Master"; this.btnFormMaster.Id = 19; this.btnFormMaster.Name = "btnFormMaster"; this.btnFormMaster.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFormMaster_ItemClick);
            this.btnJigTypeMaster.Caption = "Loại Jig Master"; this.btnJigTypeMaster.Id = 20; this.btnJigTypeMaster.Name = "btnJigTypeMaster"; this.btnJigTypeMaster.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigTypeMaster_ItemClick);

            // ribbon page/groups
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                this.rpgMaster,
                this.rpgRegister,
                this.rpgCheck,
                this.rpgCancel,
                this.rpgSystem});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "JigFlow";

            this.rpgMaster.ItemLinks.Add(this.btnJigFunctionList);
            this.rpgMaster.ItemLinks.Add(this.btnJigVisualList);
            this.rpgMaster.ItemLinks.Add(this.btnJigDrawing);
            this.rpgMaster.ItemLinks.Add(this.btnFormMaster);
            this.rpgMaster.ItemLinks.Add(this.btnJigTypeMaster);
            this.rpgMaster.Text = "Master";

            this.rpgRegister.ItemLinks.Add(this.btnJigRegisterList);
            this.rpgRegister.ItemLinks.Add(this.btnJigNewWaitingApprove);
            this.rpgRegister.ItemLinks.Add(this.btnJigRegisterHistory);
            this.rpgRegister.Text = "Đăng ký Jig mới";

            this.rpgCheck.ItemLinks.Add(this.btnJigNotChecked);
            this.rpgCheck.ItemLinks.Add(this.btnJigCheckHistory);
            this.rpgCheck.Text = "Định kỳ kiểm tra Jig";

            this.rpgCancel.ItemLinks.Add(this.btnJigCancelRegister);
            this.rpgCancel.ItemLinks.Add(this.btnJigCancelWaitingApprove);
            this.rpgCancel.ItemLinks.Add(this.btnJigCancelHistory);
            this.rpgCancel.Text = "Hủy Jig";

            this.rpgSystem.ItemLinks.Add(this.btnAccountManagement);
            this.rpgSystem.Text = "Hệ thống";

            // status/mdi/form
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 689);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1280, 31);

            this.xtraTabbedMdiManager1.MdiParent = this;
            this.btnAccountFloat.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnAccountFloat.Location = new System.Drawing.Point(1120, 8);
            this.btnAccountFloat.Size = new System.Drawing.Size(150, 30);
            this.btnAccountFloat.Text = "Đăng nhập";
            this.btnAccountFloat.Click += new System.EventHandler(this.btnAccountFloat_Click);

            this.accountMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin,
            this.mnuLogout,
            this.mnuChangePassword,
            this.mnuExit});
            this.mnuLogin.Text = "Đăng nhập";
            this.mnuLogin.Click += new System.EventHandler(this.mnuLogin_Click);
            this.mnuLogout.Text = "Đăng xuất";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            this.mnuChangePassword.Text = "Đổi mật khẩu";
            this.mnuChangePassword.Click += new System.EventHandler(this.mnuChangePassword_Click);
            this.mnuExit.Text = "Thoát";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.btnAccountFloat);
            this.IsMdiContainer = true;
            this.Name = "FRM_MAIN";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "JigFlow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_MAIN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.accountMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgMaster;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgRegister;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgCheck;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgCancel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSystem;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarSubItem subUser;
        private DevExpress.XtraBars.BarButtonItem btnLoginMenu;
        private DevExpress.XtraBars.BarButtonItem btnUserInfoMenu;
        private DevExpress.XtraBars.BarButtonItem btnLogoutMenu;
        private DevExpress.XtraBars.BarButtonItem btnChangePassMenu;
        private DevExpress.XtraBars.BarButtonItem btnExitMenu;
        private DevExpress.XtraBars.BarButtonItem btnAccountManagement;
        private DevExpress.XtraBars.BarButtonItem btnJigFunctionList;
        private DevExpress.XtraBars.BarButtonItem btnJigVisualList;
        private DevExpress.XtraBars.BarButtonItem btnJigRegisterList;
        private DevExpress.XtraBars.BarButtonItem btnJigNewWaitingApprove;
        private DevExpress.XtraBars.BarButtonItem btnJigRegisterHistory;
        private DevExpress.XtraBars.BarButtonItem btnJigNotChecked;
        private DevExpress.XtraBars.BarButtonItem btnJigCheckHistory;
        private DevExpress.XtraBars.BarButtonItem btnJigCancelRegister;
        private DevExpress.XtraBars.BarButtonItem btnJigCancelWaitingApprove;
        private DevExpress.XtraBars.BarButtonItem btnJigCancelHistory;
        private DevExpress.XtraBars.BarButtonItem btnJigDrawing;
        private DevExpress.XtraBars.BarButtonItem btnFormMaster;
        private DevExpress.XtraBars.BarButtonItem btnJigTypeMaster;
        private DevExpress.XtraEditors.SimpleButton btnAccountFloat;
        private System.Windows.Forms.ContextMenuStrip accountMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePassword;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
    }
}
