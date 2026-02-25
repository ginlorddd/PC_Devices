namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    partial class FRM_ADD_USER_SKILL
    {
        private System.ComponentModel.IContainer components = null;

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.LabelControl lblEmp;
        private DevExpress.XtraEditors.GridLookUpEdit gluEmp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEmpPopup;
        private DevExpress.XtraEditors.LabelControl lblLegend;

        // ✅ NEW
        private DevExpress.XtraEditors.LabelControl lblCertificate;
        private DevExpress.XtraEditors.TextEdit txtCertificate;
        private DevExpress.XtraEditors.LabelControl lblSafetyCard;
        private DevExpress.XtraEditors.ComboBoxEdit cboSafetyCardStatus;

        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraEditors.GroupControl groupSkills;
        private DevExpress.XtraGrid.GridControl gcSkills;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSkills;

        private DevExpress.XtraEditors.PanelControl panelBottom;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ADD_USER_SKILL));
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.lblLegend = new DevExpress.XtraEditors.LabelControl();
            this.lblEmp = new DevExpress.XtraEditors.LabelControl();
            this.gluEmp = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gvEmpPopup = new DevExpress.XtraGrid.Views.Grid.GridView();

            // ✅ NEW
            this.lblCertificate = new DevExpress.XtraEditors.LabelControl();
            this.txtCertificate = new DevExpress.XtraEditors.TextEdit();
            this.lblSafetyCard = new DevExpress.XtraEditors.LabelControl();
            this.cboSafetyCardStatus = new DevExpress.XtraEditors.ComboBoxEdit();

            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            this.groupSkills = new DevExpress.XtraEditors.GroupControl();
            this.gcSkills = new DevExpress.XtraGrid.GridControl();
            this.gvSkills = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gluEmp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmpPopup)).BeginInit();

            // ✅ NEW
            ((System.ComponentModel.ISupportInitialize)(this.txtCertificate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSafetyCardStatus.Properties)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupSkills)).BeginInit();
            this.groupSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSkills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblLegend);
            this.panelTop.Controls.Add(this.lblEmp);
            this.panelTop.Controls.Add(this.gluEmp);

            // ✅ NEW
            this.panelTop.Controls.Add(this.lblCertificate);
            this.panelTop.Controls.Add(this.txtCertificate);
            this.panelTop.Controls.Add(this.lblSafetyCard);
            this.panelTop.Controls.Add(this.cboSafetyCardStatus);

            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(980, 96); // ✅ tăng chiều cao
            this.panelTop.TabIndex = 2;
            // 
            // lblLegend
            // 
            this.lblLegend.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblLegend.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblLegend.Appearance.Options.UseFont = true;
            this.lblLegend.Appearance.Options.UseForeColor = true;
            this.lblLegend.Location = new System.Drawing.Point(385, 70);
            this.lblLegend.Name = "lblLegend";
            this.lblLegend.Size = new System.Drawing.Size(580, 14);
            this.lblLegend.TabIndex = 0;
            this.lblLegend.Text = "Chú thích:  LEVEL = (màu xanh nhạt)    |    Được phép/ Không được phép = (màu vàng nhạt).";
            // 
            // lblEmp
            // 
            this.lblEmp.Location = new System.Drawing.Point(14, 16);
            this.lblEmp.Name = "lblEmp";
            this.lblEmp.Size = new System.Drawing.Size(52, 13);
            this.lblEmp.TabIndex = 1;
            this.lblEmp.Text = "Nhân viên:";
            // 
            // gluEmp
            // 
            this.gluEmp.Location = new System.Drawing.Point(85, 12);
            this.gluEmp.Name = "gluEmp";
            this.gluEmp.Properties.PopupView = this.gvEmpPopup;
            this.gluEmp.Size = new System.Drawing.Size(880, 22);
            this.gluEmp.TabIndex = 2;
            this.gluEmp.EditValueChanged += new System.EventHandler(this.gluEmp_EditValueChanged);
            // 
            // gvEmpPopup
            // 
            this.gvEmpPopup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvEmpPopup.Name = "gvEmpPopup";
            this.gvEmpPopup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvEmpPopup.OptionsView.ShowAutoFilterRow = true;
            this.gvEmpPopup.OptionsView.ShowGroupPanel = false;

            // ===========================
            // ✅ NEW: Certificate + Safety
            // ===========================
            // 
            // lblCertificate
            // 
            this.lblCertificate.Location = new System.Drawing.Point(14, 48);
            this.lblCertificate.Name = "lblCertificate";
            this.lblCertificate.Size = new System.Drawing.Size(46, 13);
            this.lblCertificate.TabIndex = 3;
            this.lblCertificate.Text = "Chứng chỉ:";
            // 
            // txtCertificate
            // 
            this.txtCertificate.Location = new System.Drawing.Point(85, 44);
            this.txtCertificate.Name = "txtCertificate";
            this.txtCertificate.Size = new System.Drawing.Size(420, 22);
            this.txtCertificate.TabIndex = 4;
            // 
            // lblSafetyCard
            // 
            this.lblSafetyCard.Location = new System.Drawing.Point(520, 48);
            this.lblSafetyCard.Name = "lblSafetyCard";
            this.lblSafetyCard.Size = new System.Drawing.Size(57, 13);
            this.lblSafetyCard.TabIndex = 5;
            this.lblSafetyCard.Text = "Thẻ an toàn:";
            // 
            // cboSafetyCardStatus
            // 
            this.cboSafetyCardStatus.Location = new System.Drawing.Point(600, 44);
            this.cboSafetyCardStatus.Name = "cboSafetyCardStatus";
            this.cboSafetyCardStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSafetyCardStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboSafetyCardStatus.Size = new System.Drawing.Size(365, 22);
            this.cboSafetyCardStatus.TabIndex = 6;

            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupSkills);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 96); // ✅ đổi theo panelTop mới
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(980, 462);
            this.panelMain.TabIndex = 0;
            // 
            // groupSkills
            // 
            this.groupSkills.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupSkills.AppearanceCaption.Options.UseFont = true;
            this.groupSkills.Controls.Add(this.gcSkills);
            this.groupSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSkills.Location = new System.Drawing.Point(2, 2);
            this.groupSkills.Name = "groupSkills";
            this.groupSkills.Size = new System.Drawing.Size(976, 458);
            this.groupSkills.TabIndex = 0;
            this.groupSkills.Text = "Danh sách kỹ năng";
            // 
            // gcSkills
            // 
            this.gcSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSkills.Location = new System.Drawing.Point(2, 22);
            this.gcSkills.MainView = this.gvSkills;
            this.gcSkills.Name = "gcSkills";
            this.gcSkills.Size = new System.Drawing.Size(972, 434);
            this.gcSkills.TabIndex = 0;
            this.gcSkills.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSkills});
            // 
            // gvSkills
            // 
            this.gvSkills.GridControl = this.gcSkills;
            this.gvSkills.Name = "gvSkills";
            this.gvSkills.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gvSkills.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gvSkills.OptionsView.ShowAutoFilterRow = true;
            this.gvSkills.OptionsView.ShowGroupPanel = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 558);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(980, 62);
            this.panelBottom.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(12, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 38);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(150, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 38);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FRM_ADD_USER_SKILL
            // 
            this.ClientSize = new System.Drawing.Size(980, 620);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_ADD_USER_SKILL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật kỹ năng nhân viên";
            this.Load += new System.EventHandler(this.FRM_ADD_USER_SKILL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gluEmp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmpPopup)).EndInit();

            // ✅ NEW
            ((System.ComponentModel.ISupportInitialize)(this.txtCertificate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSafetyCardStatus.Properties)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupSkills)).EndInit();
            this.groupSkills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSkills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
