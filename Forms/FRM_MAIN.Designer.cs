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
            this.btnLogin = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePass = new DevExpress.XtraBars.BarButtonItem();
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
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgMaster = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgRegister = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgCheck = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgCancel = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnLogin,
            this.btnLogout,
            this.btnChangePass,
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
            this.bsiUser});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 18;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Size = new System.Drawing.Size(1280, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // SYSTEM BUTTONS
            // 
            this.btnLogin.Caption = "Đăng nhập";
            this.btnLogin.Id = 1;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogin_ItemClick);
            this.btnLogout.Caption = "Đăng xuất";
            this.btnLogout.Id = 2;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            this.btnChangePass.Caption = "Đổi mật khẩu";
            this.btnChangePass.Id = 3;
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangePass_ItemClick);
            this.btnAccountManagement.Caption = "Quản lý tài khoản";
            this.btnAccountManagement.Id = 4;
            this.btnAccountManagement.Name = "btnAccountManagement";
            this.btnAccountManagement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAccountManagement_ItemClick);
            // 
            // MASTER GROUP
            // 
            this.btnJigFunctionList.Caption = "Jig chức năng";
            this.btnJigFunctionList.Id = 5;
            this.btnJigFunctionList.Name = "btnJigFunctionList";
            this.btnJigFunctionList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigFunctionList_ItemClick);
            this.btnJigVisualList.Caption = "Jig ngoại quan";
            this.btnJigVisualList.Id = 6;
            this.btnJigVisualList.Name = "btnJigVisualList";
            this.btnJigVisualList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigVisualList_ItemClick);
            this.btnJigDrawing.Caption = "Bản vẽ Jig";
            this.btnJigDrawing.Id = 15;
            this.btnJigDrawing.Name = "btnJigDrawing";
            this.btnJigDrawing.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigDrawing_ItemClick);
            this.btnFormMaster.Caption = "Form Master";
            this.btnFormMaster.Id = 16;
            this.btnFormMaster.Name = "btnFormMaster";
            this.btnFormMaster.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFormMaster_ItemClick);
            // 
            // REGISTER GROUP
            // 
            this.btnJigRegisterList.Caption = "Đăng ký Jig";
            this.btnJigRegisterList.Id = 7;
            this.btnJigRegisterList.Name = "btnJigRegisterList";
            this.btnJigRegisterList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigRegisterList_ItemClick);
            this.btnJigNewWaitingApprove.Caption = "Jig mới chờ duyệt";
            this.btnJigNewWaitingApprove.Id = 8;
            this.btnJigNewWaitingApprove.Name = "btnJigNewWaitingApprove";
            this.btnJigNewWaitingApprove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigNewWaitingApprove_ItemClick);
            this.btnJigRegisterHistory.Caption = "Lịch sử đăng ký Jig";
            this.btnJigRegisterHistory.Id = 9;
            this.btnJigRegisterHistory.Name = "btnJigRegisterHistory";
            this.btnJigRegisterHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigRegisterHistory_ItemClick);
            // 
            // CHECK GROUP
            // 
            this.btnJigNotChecked.Caption = "Jig chưa được kiểm tra";
            this.btnJigNotChecked.Id = 10;
            this.btnJigNotChecked.Name = "btnJigNotChecked";
            this.btnJigNotChecked.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigNotChecked_ItemClick);
            this.btnJigCheckHistory.Caption = "Lịch sử kiểm tra Jig";
            this.btnJigCheckHistory.Id = 11;
            this.btnJigCheckHistory.Name = "btnJigCheckHistory";
            this.btnJigCheckHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigCheckHistory_ItemClick);
            // 
            // CANCEL GROUP
            // 
            this.btnJigCancelRegister.Caption = "Đăng ký hủy Jig";
            this.btnJigCancelRegister.Id = 12;
            this.btnJigCancelRegister.Name = "btnJigCancelRegister";
            this.btnJigCancelRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigCancelRegister_ItemClick);
            this.btnJigCancelWaitingApprove.Caption = "Jig hủy chờ duyệt";
            this.btnJigCancelWaitingApprove.Id = 13;
            this.btnJigCancelWaitingApprove.Name = "btnJigCancelWaitingApprove";
            this.btnJigCancelWaitingApprove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigCancelWaitingApprove_ItemClick);
            this.btnJigCancelHistory.Caption = "Lịch sử hủy Jig";
            this.btnJigCancelHistory.Id = 14;
            this.btnJigCancelHistory.Name = "btnJigCancelHistory";
            this.btnJigCancelHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnJigCancelHistory_ItemClick);
            // 
            // bsiUser
            // 
            this.bsiUser.Caption = "Chưa đăng nhập";
            this.bsiUser.Id = 17;
            this.bsiUser.Name = "bsiUser";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSystem,
            this.rpgMaster,
            this.rpgRegister,
            this.rpgCheck,
            this.rpgCancel});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "JigFlow";
            // 
            // rpgSystem
            // 
            this.rpgSystem.ItemLinks.Add(this.btnLogin);
            this.rpgSystem.ItemLinks.Add(this.btnLogout);
            this.rpgSystem.ItemLinks.Add(this.btnChangePass);
            this.rpgSystem.ItemLinks.Add(this.btnAccountManagement);
            this.rpgSystem.Name = "rpgSystem";
            this.rpgSystem.Text = "Hệ thống";
            // 
            // rpgMaster
            // 
            this.rpgMaster.ItemLinks.Add(this.btnJigFunctionList);
            this.rpgMaster.ItemLinks.Add(this.btnJigVisualList);
            this.rpgMaster.ItemLinks.Add(this.btnJigDrawing);
            this.rpgMaster.ItemLinks.Add(this.btnFormMaster);
            this.rpgMaster.Name = "rpgMaster";
            this.rpgMaster.Text = "Master";
            // 
            // rpgRegister
            // 
            this.rpgRegister.ItemLinks.Add(this.btnJigRegisterList);
            this.rpgRegister.ItemLinks.Add(this.btnJigNewWaitingApprove);
            this.rpgRegister.ItemLinks.Add(this.btnJigRegisterHistory);
            this.rpgRegister.Name = "rpgRegister";
            this.rpgRegister.Text = "Đăng ký Jig mới";
            // 
            // rpgCheck
            // 
            this.rpgCheck.ItemLinks.Add(this.btnJigNotChecked);
            this.rpgCheck.ItemLinks.Add(this.btnJigCheckHistory);
            this.rpgCheck.Name = "rpgCheck";
            this.rpgCheck.Text = "Định kỳ kiểm tra Jig";
            // 
            // rpgCancel
            // 
            this.rpgCancel.ItemLinks.Add(this.btnJigCancelRegister);
            this.rpgCancel.ItemLinks.Add(this.btnJigCancelWaitingApprove);
            this.rpgCancel.ItemLinks.Add(this.btnJigCancelHistory);
            this.rpgCancel.Name = "rpgCancel";
            this.rpgCancel.Text = "Hủy Jig";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 689);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1280, 31);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // FRM_MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "FRM_MAIN";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "JigFlow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_MAIN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgMaster;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgRegister;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgCheck;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgCancel;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem btnLogin;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.BarButtonItem btnChangePass;
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
        private DevExpress.XtraBars.BarStaticItem bsiUser;
    }
}
