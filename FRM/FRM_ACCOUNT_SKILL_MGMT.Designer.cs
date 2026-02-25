namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    partial class FRM_ACCOUNT_SKILL_MGMT
    {
        private System.ComponentModel.IContainer components = null;

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnResetPass;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.LabelControl lblTitle;

        private DevExpress.XtraEditors.SplitContainerControl splitMain;

        // LEFT: Account list
        private DevExpress.XtraEditors.PanelControl panelLeft;
        private DevExpress.XtraEditors.GroupControl groupAccountList;
        private DevExpress.XtraGrid.GridControl gcAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAccount;

        // RIGHT: Tabs
        private DevExpress.XtraEditors.PanelControl panelRight;
        private DevExpress.XtraTab.XtraTabControl tabRight;
        private DevExpress.XtraTab.XtraTabPage tabAccountInfo;
        private DevExpress.XtraTab.XtraTabPage tabSkills;

        // Account info layout
        private DevExpress.XtraEditors.GroupControl groupInfo;
        private DevExpress.XtraEditors.PanelControl panelInfo;
        private DevExpress.XtraEditors.LabelControl lblID;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.LabelControl lblUserID;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.LabelControl lblAccess;
        private DevExpress.XtraEditors.LabelControl lblPosition;
        private DevExpress.XtraEditors.LabelControl lblFactory;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.TextEdit txtUserID;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.ComboBoxEdit cboAccess;

        private DevExpress.XtraEditors.CheckEdit chkLockUser; // optional (if later need)
        private DevExpress.XtraEditors.LabelControl lblHint;

        // Skills tab
        private DevExpress.XtraEditors.GroupControl groupSkills;
        private DevExpress.XtraEditors.PanelControl panelSkillsTop;
        private DevExpress.XtraEditors.LabelControl lblEmpSelected;
        private DevExpress.XtraEditors.LabelControl lblLegend;
        private DevExpress.XtraEditors.SimpleButton btnSaveSkills;

        private DevExpress.XtraGrid.GridControl gcSkills;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSkills;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ACCOUNT_SKILL_MGMT));
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnResetPass = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelLeft = new DevExpress.XtraEditors.PanelControl();
            this.groupAccountList = new DevExpress.XtraEditors.GroupControl();
            this.gcAccount = new DevExpress.XtraGrid.GridControl();
            this.gvAccount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelRight = new DevExpress.XtraEditors.PanelControl();
            this.tabRight = new DevExpress.XtraTab.XtraTabControl();
            this.tabAccountInfo = new DevExpress.XtraTab.XtraTabPage();
            this.groupInfo = new DevExpress.XtraEditors.GroupControl();
            this.panelInfo = new DevExpress.XtraEditors.PanelControl();
            this.lblID = new DevExpress.XtraEditors.LabelControl();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.lblUserID = new DevExpress.XtraEditors.LabelControl();
            this.txtUserID = new DevExpress.XtraEditors.TextEdit();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.lblAccess = new DevExpress.XtraEditors.LabelControl();
            this.cboAccess = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblPosition = new DevExpress.XtraEditors.LabelControl();
            this.lblFactory = new DevExpress.XtraEditors.LabelControl();
            this.chkLockUser = new DevExpress.XtraEditors.CheckEdit();
            this.lblHint = new DevExpress.XtraEditors.LabelControl();
            this.cboPosition = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboFactory = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tabSkills = new DevExpress.XtraTab.XtraTabPage();
            this.groupSkills = new DevExpress.XtraEditors.GroupControl();
            this.gcSkills = new DevExpress.XtraGrid.GridControl();
            this.gvSkills = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelSkillsTop = new DevExpress.XtraEditors.PanelControl();
            this.lblEmpSelected = new DevExpress.XtraEditors.LabelControl();
            this.lblLegend = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveSkills = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).BeginInit();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupAccountList)).BeginInit();
            this.groupAccountList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabRight)).BeginInit();
            this.tabRight.SuspendLayout();
            this.tabAccountInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).BeginInit();
            this.groupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelInfo)).BeginInit();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLockUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFactory.Properties)).BeginInit();
            this.tabSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupSkills)).BeginInit();
            this.groupSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSkillsTop)).BeginInit();
            this.panelSkillsTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.btnEdit);
            this.panelTop.Controls.Add(this.btnSave);
            this.panelTop.Controls.Add(this.btnCancel);
            this.panelTop.Controls.Add(this.btnDelete);
            this.panelTop.Controls.Add(this.btnResetPass);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1280, 70);
            this.panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(14, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(333, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ACCOUNT MANAGEMENT + USER SKILLS";
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(14, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.Location = new System.Drawing.Point(114, 34);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 28);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(214, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(314, 34);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(414, 34);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 28);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnResetPass
            // 
            this.btnResetPass.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnResetPass.Appearance.Options.UseFont = true;
            this.btnResetPass.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnResetPass.ImageOptions.Image")));
            this.btnResetPass.Location = new System.Drawing.Point(514, 34);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(115, 28);
            this.btnResetPass.TabIndex = 6;
            this.btnResetPass.Text = "Reset Pass";
            this.btnResetPass.Click += new System.EventHandler(this.btnResetPass_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(634, 34);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 28);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 70);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.panelLeft);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.panelRight);
            this.splitMain.Size = new System.Drawing.Size(1280, 690);
            this.splitMain.SplitterPosition = 660;
            this.splitMain.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelLeft.Controls.Add(this.groupAccountList);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(660, 690);
            this.panelLeft.TabIndex = 0;
            // 
            // groupAccountList
            // 
            this.groupAccountList.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupAccountList.AppearanceCaption.Options.UseFont = true;
            this.groupAccountList.Controls.Add(this.gcAccount);
            this.groupAccountList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupAccountList.Location = new System.Drawing.Point(0, 0);
            this.groupAccountList.Name = "groupAccountList";
            this.groupAccountList.Size = new System.Drawing.Size(660, 690);
            this.groupAccountList.TabIndex = 0;
            this.groupAccountList.Text = "Danh sách tài khoản";
            // 
            // gcAccount
            // 
            this.gcAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAccount.Location = new System.Drawing.Point(2, 22);
            this.gcAccount.MainView = this.gvAccount;
            this.gcAccount.Name = "gcAccount";
            this.gcAccount.Size = new System.Drawing.Size(656, 666);
            this.gcAccount.TabIndex = 0;
            this.gcAccount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAccount});
            // 
            // gvAccount
            // 
            this.gvAccount.GridControl = this.gcAccount;
            this.gvAccount.Name = "gvAccount";
            this.gvAccount.OptionsBehavior.Editable = false;
            this.gvAccount.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvAccount.OptionsView.ShowAutoFilterRow = true;
            this.gvAccount.OptionsView.ShowGroupPanel = false;
            this.gvAccount.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvAccount_FocusedRowChanged);
            // 
            // panelRight
            // 
            this.panelRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelRight.Controls.Add(this.tabRight);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(608, 690);
            this.panelRight.TabIndex = 0;
            // 
            // tabRight
            // 
            this.tabRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRight.Location = new System.Drawing.Point(0, 0);
            this.tabRight.Name = "tabRight";
            this.tabRight.SelectedTabPage = this.tabAccountInfo;
            this.tabRight.Size = new System.Drawing.Size(608, 690);
            this.tabRight.TabIndex = 0;
            this.tabRight.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabAccountInfo,
            this.tabSkills});
            // 
            // tabAccountInfo
            // 
            this.tabAccountInfo.Controls.Add(this.groupInfo);
            this.tabAccountInfo.Name = "tabAccountInfo";
            this.tabAccountInfo.Size = new System.Drawing.Size(606, 666);
            this.tabAccountInfo.Text = "Thông tin tài khoản";
            // 
            // groupInfo
            // 
            this.groupInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupInfo.AppearanceCaption.Options.UseFont = true;
            this.groupInfo.Controls.Add(this.panelInfo);
            this.groupInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupInfo.Location = new System.Drawing.Point(0, 0);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(606, 666);
            this.groupInfo.TabIndex = 0;
            this.groupInfo.Text = "Thông tin chi tiết";
            // 
            // panelInfo
            // 
            this.panelInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelInfo.Controls.Add(this.lblID);
            this.panelInfo.Controls.Add(this.lblFullName);
            this.panelInfo.Controls.Add(this.txtFullName);
            this.panelInfo.Controls.Add(this.lblUserID);
            this.panelInfo.Controls.Add(this.txtUserID);
            this.panelInfo.Controls.Add(this.lblEmail);
            this.panelInfo.Controls.Add(this.txtEmail);
            this.panelInfo.Controls.Add(this.lblAccess);
            this.panelInfo.Controls.Add(this.cboAccess);
            this.panelInfo.Controls.Add(this.lblPosition);
            this.panelInfo.Controls.Add(this.lblFactory);
            this.panelInfo.Controls.Add(this.chkLockUser);
            this.panelInfo.Controls.Add(this.lblHint);
            this.panelInfo.Controls.Add(this.cboPosition);
            this.panelInfo.Controls.Add(this.cboFactory);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo.Location = new System.Drawing.Point(2, 22);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(602, 642);
            this.panelInfo.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(0, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 13);
            this.lblID.TabIndex = 0;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(18, 52);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(36, 13);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Họ tên:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(140, 50);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(420, 22);
            this.txtFullName.TabIndex = 3;
            // 
            // lblUserID
            // 
            this.lblUserID.Location = new System.Drawing.Point(18, 86);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(103, 13);
            this.lblUserID.TabIndex = 4;
            this.lblUserID.Text = "USER_ID (EmpCode):";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(140, 84);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(240, 22);
            this.txtUserID.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(18, 120);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(28, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(140, 118);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(420, 22);
            this.txtEmail.TabIndex = 7;
            // 
            // lblAccess
            // 
            this.lblAccess.Location = new System.Drawing.Point(18, 154);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(103, 13);
            this.lblAccess.TabIndex = 8;
            this.lblAccess.Text = "Quyền (ID_ACCESS):";
            // 
            // cboAccess
            // 
            this.cboAccess.Location = new System.Drawing.Point(140, 152);
            this.cboAccess.Name = "cboAccess";
            this.cboAccess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAccess.Properties.Items.AddRange(new object[] {
            "2 - User",
            "3 - Approver"});
            this.cboAccess.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAccess.Size = new System.Drawing.Size(240, 22);
            this.cboAccess.TabIndex = 9;
            // 
            // lblPosition
            // 
            this.lblPosition.Location = new System.Drawing.Point(18, 188);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(41, 13);
            this.lblPosition.TabIndex = 10;
            this.lblPosition.Text = "Position:";
            // 
            // lblFactory
            // 
            this.lblFactory.Location = new System.Drawing.Point(18, 222);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(68, 13);
            this.lblFactory.TabIndex = 12;
            this.lblFactory.Text = "FactoryName:";
            // 
            // chkLockUser
            // 
            this.chkLockUser.Location = new System.Drawing.Point(140, 266);
            this.chkLockUser.Name = "chkLockUser";
            this.chkLockUser.Properties.Caption = "Khóa tài khoản (tùy chọn)";
            this.chkLockUser.Size = new System.Drawing.Size(240, 20);
            this.chkLockUser.TabIndex = 18;
            // 
            // lblHint
            // 
            this.lblHint.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblHint.Appearance.Options.UseForeColor = true;
            this.lblHint.Location = new System.Drawing.Point(18, 310);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(207, 13);
            this.lblHint.TabIndex = 19;
            this.lblHint.Text = "Gợi ý: Chọn tài khoản bên trái để xem/sửa.";
            // 
            // cboPosition
            // 
            this.cboPosition.Location = new System.Drawing.Point(140, 186);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPosition.Properties.Items.AddRange(new object[] {
            "Operator",
            "Sub-Leader",
            "Leader",
            "Coordinator",
            "Staff",
            "Senior Staff",
            "Assistant Manager",
            "Manager",
            "Supervisor"});
            this.cboPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPosition.Size = new System.Drawing.Size(240, 22);
            this.cboPosition.TabIndex = 11;
            // 
            // cboFactory
            // 
            this.cboFactory.Location = new System.Drawing.Point(140, 220);
            this.cboFactory.Name = "cboFactory";
            this.cboFactory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFactory.Properties.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3"});
            this.cboFactory.Size = new System.Drawing.Size(240, 22);
            this.cboFactory.TabIndex = 13;
            // 
            // tabSkills
            // 
            this.tabSkills.Controls.Add(this.groupSkills);
            this.tabSkills.Name = "tabSkills";
            this.tabSkills.Size = new System.Drawing.Size(746, 666);
            this.tabSkills.Text = "Kỹ năng";
            // 
            // groupSkills
            // 
            this.groupSkills.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupSkills.AppearanceCaption.Options.UseFont = true;
            this.groupSkills.Controls.Add(this.gcSkills);
            this.groupSkills.Controls.Add(this.panelSkillsTop);
            this.groupSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSkills.Location = new System.Drawing.Point(0, 0);
            this.groupSkills.Name = "groupSkills";
            this.groupSkills.Size = new System.Drawing.Size(746, 666);
            this.groupSkills.TabIndex = 0;
            this.groupSkills.Text = "Quản lý kỹ năng";
            // 
            // gcSkills
            // 
            this.gcSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSkills.Location = new System.Drawing.Point(2, 86);
            this.gcSkills.MainView = this.gvSkills;
            this.gcSkills.Name = "gcSkills";
            this.gcSkills.Size = new System.Drawing.Size(742, 578);
            this.gcSkills.TabIndex = 0;
            this.gcSkills.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSkills});
            // 
            // gvSkills
            // 
            this.gvSkills.GridControl = this.gcSkills;
            this.gvSkills.Name = "gvSkills";
            this.gvSkills.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.gvSkills.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvSkills.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gvSkills.OptionsView.ShowAutoFilterRow = true;
            this.gvSkills.OptionsView.ShowGroupPanel = false;
            // 
            // panelSkillsTop
            // 
            this.panelSkillsTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelSkillsTop.Controls.Add(this.lblEmpSelected);
            this.panelSkillsTop.Controls.Add(this.lblLegend);
            this.panelSkillsTop.Controls.Add(this.btnSaveSkills);
            this.panelSkillsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSkillsTop.Location = new System.Drawing.Point(2, 22);
            this.panelSkillsTop.Name = "panelSkillsTop";
            this.panelSkillsTop.Size = new System.Drawing.Size(742, 64);
            this.panelSkillsTop.TabIndex = 1;
            // 
            // lblEmpSelected
            // 
            this.lblEmpSelected.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmpSelected.Appearance.Options.UseFont = true;
            this.lblEmpSelected.Location = new System.Drawing.Point(14, 10);
            this.lblEmpSelected.Name = "lblEmpSelected";
            this.lblEmpSelected.Size = new System.Drawing.Size(239, 17);
            this.lblEmpSelected.TabIndex = 0;
            this.lblEmpSelected.Text = "Nhân viên đang chọn: (chưa chọn)";
            // 
            // lblLegend
            // 
            this.lblLegend.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblLegend.Appearance.Options.UseForeColor = true;
            this.lblLegend.Location = new System.Drawing.Point(14, 34);
            this.lblLegend.Name = "lblLegend";
            this.lblLegend.Size = new System.Drawing.Size(321, 13);
            this.lblLegend.TabIndex = 1;
            this.lblLegend.Text = "Chú thích: LEVEL = nhập LevelMax, BOOLEAN = tick = Được phép.";
            // 
            // btnSaveSkills
            // 
            this.btnSaveSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSkills.Location = new System.Drawing.Point(1262, 18);
            this.btnSaveSkills.Name = "btnSaveSkills";
            this.btnSaveSkills.Size = new System.Drawing.Size(140, 30);
            this.btnSaveSkills.TabIndex = 2;
            this.btnSaveSkills.Text = "Lưu kỹ năng";
            this.btnSaveSkills.Click += new System.EventHandler(this.btnSaveSkills_Click);
            // 
            // FRM_ACCOUNT_SKILL_MGMT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_ACCOUNT_SKILL_MGMT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản & kỹ năng";
            this.Load += new System.EventHandler(this.FRM_ACCOUNT_SKILL_MGMT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel1)).EndInit();
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain.Panel2)).EndInit();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupAccountList)).EndInit();
            this.groupAccountList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabRight)).EndInit();
            this.tabRight.ResumeLayout(false);
            this.tabAccountInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).EndInit();
            this.groupInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelInfo)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLockUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFactory.Properties)).EndInit();
            this.tabSkills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupSkills)).EndInit();
            this.groupSkills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSkillsTop)).EndInit();
            this.panelSkillsTop.ResumeLayout(false);
            this.panelSkillsTop.PerformLayout();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraEditors.ComboBoxEdit cboPosition;
        private DevExpress.XtraEditors.ComboBoxEdit cboFactory;
    }
}