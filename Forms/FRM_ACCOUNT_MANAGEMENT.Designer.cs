namespace JigFlow.Forms
{
    partial class FRM_ACCOUNT_MANAGEMENT
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblUsername = new DevExpress.XtraEditors.LabelControl();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.lblRole = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.cboRole = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.gcUsers = new DevExpress.XtraGrid.GridControl();
            this.gvUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).BeginInit();
            this.SuspendLayout();

            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top; this.panelTop.Height = 112;

            this.lblUsername.Location = new System.Drawing.Point(10, 10); this.lblUsername.Text = "Username";
            this.txtUsername.Location = new System.Drawing.Point(10, 30); this.txtUsername.Size = new System.Drawing.Size(150, 22); this.txtUsername.Properties.NullValuePrompt = "Nhập username";

            this.lblFullName.Location = new System.Drawing.Point(170, 10); this.lblFullName.Text = "Họ tên";
            this.txtFullName.Location = new System.Drawing.Point(170, 30); this.txtFullName.Size = new System.Drawing.Size(190, 22); this.txtFullName.Properties.NullValuePrompt = "Nhập họ tên";

            this.lblPassword.Location = new System.Drawing.Point(370, 10); this.lblPassword.Text = "Mật khẩu";
            this.txtPassword.Location = new System.Drawing.Point(370, 30); this.txtPassword.Size = new System.Drawing.Size(150, 22); this.txtPassword.Properties.UseSystemPasswordChar = true; this.txtPassword.Properties.NullValuePrompt = "Để trống = 123456";

            this.lblEmail.Location = new System.Drawing.Point(530, 10); this.lblEmail.Text = "Email";
            this.txtEmail.Location = new System.Drawing.Point(530, 30); this.txtEmail.Size = new System.Drawing.Size(210, 22); this.txtEmail.Properties.NullValuePrompt = "Nhập email";

            this.lblRole.Location = new System.Drawing.Point(750, 10); this.lblRole.Text = "Role";
            this.cboRole.Location = new System.Drawing.Point(750, 30); this.cboRole.Size = new System.Drawing.Size(130, 22);
            this.cboRole.Properties.Items.AddRange(new object[] { "SYSTEM_ADMIN", "APPROVER", "MEMBER" });
            this.cboRole.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboRole.SelectedIndex = 2;

            this.chkIsActive.Location = new System.Drawing.Point(890, 30); this.chkIsActive.Properties.Caption = "Active"; this.chkIsActive.Checked = true;

            this.btnSave.Location = new System.Drawing.Point(10, 66); this.btnSave.Size = new System.Drawing.Size(100, 32); this.btnSave.Text = "Lưu"; this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnRefresh.Location = new System.Drawing.Point(116, 66); this.btnRefresh.Size = new System.Drawing.Size(100, 32); this.btnRefresh.Text = "Refresh"; this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.panelTop.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblUsername, this.txtUsername, this.lblFullName, this.txtFullName, this.lblPassword, this.txtPassword, this.lblEmail, this.txtEmail, this.lblRole, this.cboRole, this.chkIsActive, this.btnSave, this.btnRefresh });

            this.gcUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUsers.MainView = this.gvUsers;
            this.gcUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvUsers });

            this.Controls.Add(this.gcUsers);
            this.Controls.Add(this.panelTop);
            this.Text = "Quản lý tài khoản và phân quyền";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_ACCOUNT_MANAGEMENT_Load);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraEditors.LabelControl lblUsername;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.LabelControl lblRole;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.ComboBoxEdit cboRole;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl gcUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUsers;
    }
}
