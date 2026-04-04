namespace DM_OHD.FRM
{
    partial class FRM_ACCOUNT_MANAGEMENT
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.LabelControl lblUser;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.CheckedListBoxControl chkRoles;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView view;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.lblUser = new DevExpress.XtraEditors.LabelControl();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.chkRoles = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.SuspendLayout();
            // panel
            this.panel.Controls.Add(this.lblUser);
            this.panel.Controls.Add(this.lblName);
            this.panel.Controls.Add(this.lblPassword);
            this.panel.Controls.Add(this.txtUser);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.txtPassword);
            this.panel.Controls.Add(this.chkActive);
            this.panel.Controls.Add(this.chkRoles);
            this.panel.Controls.Add(this.btnSave);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1080, 190);
            this.panel.TabIndex = 0;
            // labels/inputs
            this.lblUser.Location = new System.Drawing.Point(15, 20);
            this.lblUser.Text = "User ID";
            this.lblName.Location = new System.Drawing.Point(15, 55);
            this.lblName.Text = "Họ tên";
            this.lblPassword.Location = new System.Drawing.Point(15, 90);
            this.lblPassword.Text = "Mật khẩu";
            this.txtUser.Location = new System.Drawing.Point(90, 15);
            this.txtUser.Size = new System.Drawing.Size(180, 22);
            this.txtName.Location = new System.Drawing.Point(90, 50);
            this.txtName.Size = new System.Drawing.Size(250, 22);
            this.txtPassword.Location = new System.Drawing.Point(90, 85);
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(180, 22);
            this.chkActive.Location = new System.Drawing.Point(90, 120);
            this.chkActive.Properties.Caption = "Active";
            this.chkRoles.Location = new System.Drawing.Point(370, 15);
            this.chkRoles.Size = new System.Drawing.Size(280, 130);
            this.btnSave.Location = new System.Drawing.Point(700, 20);
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.Text = "Lưu";
            // grid
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 190);
            this.grid.MainView = this.view;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1080, 430);
            this.grid.TabIndex = 1;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.view });
            this.view.GridControl = this.grid;
            this.view.Name = "view";
            // form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 620);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel);
            this.Name = "FRM_ACCOUNT_MANAGEMENT";
            this.Text = "Quản lý tài khoản & phân quyền";
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
