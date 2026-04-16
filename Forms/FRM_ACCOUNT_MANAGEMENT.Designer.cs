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
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top; this.panelTop.Height = 90;
            this.txtUsername.Location = new System.Drawing.Point(10, 12); this.txtUsername.Size = new System.Drawing.Size(120, 22);
            this.txtFullName.Location = new System.Drawing.Point(140, 12); this.txtFullName.Size = new System.Drawing.Size(180, 22);
            this.txtPassword.Location = new System.Drawing.Point(330, 12); this.txtPassword.Size = new System.Drawing.Size(120, 22); this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtEmail.Location = new System.Drawing.Point(460, 12); this.txtEmail.Size = new System.Drawing.Size(180, 22);
            this.cboRole.Location = new System.Drawing.Point(650, 12); this.cboRole.Size = new System.Drawing.Size(120, 22); this.cboRole.Properties.Items.AddRange(new object[] { "ADMIN", "USER" }); this.cboRole.EditValue = "USER";
            this.chkIsActive.Location = new System.Drawing.Point(780, 12); this.chkIsActive.Properties.Caption = "Active"; this.chkIsActive.Checked = true;
            this.btnSave.Location = new System.Drawing.Point(10, 46); this.btnSave.Size = new System.Drawing.Size(120, 30); this.btnSave.Text = "Lưu"; this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnRefresh.Location = new System.Drawing.Point(140, 46); this.btnRefresh.Size = new System.Drawing.Size(120, 30); this.btnRefresh.Text = "Refresh"; this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.panelTop.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtUsername, this.txtFullName, this.txtPassword, this.txtEmail, this.cboRole, this.chkIsActive, this.btnSave, this.btnRefresh });
            this.gcUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUsers.MainView = this.gvUsers;
            this.gcUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvUsers });
            this.Controls.Add(this.gcUsers);
            this.Controls.Add(this.panelTop);
            this.Text = "Quản lý tài khoản và phân quyền";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_ACCOUNT_MANAGEMENT_Load);
            this.panelTop.ResumeLayout(false);
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
