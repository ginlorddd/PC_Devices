namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    partial class FRM_EDIT_MAINT
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_EDIT_MAINT));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgInfo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciMaQL = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMaQL = new DevExpress.XtraEditors.TextEdit();
            this.lciTenTB = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTenTB = new DevExpress.XtraEditors.TextEdit();
            this.sep1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.lcgBaoDuong = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciNgayBD = new DevExpress.XtraLayout.LayoutControlItem();
            this.dtNgayBD = new DevExpress.XtraEditors.DateEdit();
            this.lciTanSuat = new DevExpress.XtraLayout.LayoutControlItem();
            this.cboTanSuat = new DevExpress.XtraEditors.LookUpEdit();
            this.lciNgayKH = new DevExpress.XtraLayout.LayoutControlItem();
            this.dtNgayKH = new DevExpress.XtraEditors.DateEdit();
            this.lciStatus = new DevExpress.XtraLayout.LayoutControlItem();
            this.cboStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.lcgFiles = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciLSSC = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtLSSC = new DevExpress.XtraEditors.TextEdit();
            this.lciChooseLSSC = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnChooseLSSC = new DevExpress.XtraEditors.SimpleButton();
            this.lciOpenLSSC = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnOpenLSSC = new DevExpress.XtraEditors.SimpleButton();
            this.lcgButtons = new DevExpress.XtraLayout.LayoutControlGroup();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMaQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTenTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sep1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBaoDuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNgayBD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTanSuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTanSuat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNgayKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayKH.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLSSC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLSSC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChooseLSSC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOpenLSSC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButtons)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtMaQL);
            this.layoutControl1.Controls.Add(this.txtTenTB);
            this.layoutControl1.Controls.Add(this.dtNgayBD);
            this.layoutControl1.Controls.Add(this.cboTanSuat);
            this.layoutControl1.Controls.Add(this.dtNgayKH);
            this.layoutControl1.Controls.Add(this.cboStatus);
            this.layoutControl1.Controls.Add(this.txtLSSC);
            this.layoutControl1.Controls.Add(this.btnChooseLSSC);
            this.layoutControl1.Controls.Add(this.btnOpenLSSC);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgButtons});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(558, 181, 650, 400);
            this.layoutControl1.Root = this.root;
            this.layoutControl1.Size = new System.Drawing.Size(429, 455);
            this.layoutControl1.TabIndex = 0;
            // 
            // root
            // 
            this.root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.root.GroupBordersVisible = false;
            this.root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.sep1,
            this.lcgBaoDuong,
            this.lcgInfo,
            this.lcgFiles});
            this.root.Name = "Root";
            this.root.Padding = new DevExpress.XtraLayout.Utils.Padding(12, 12, 12, 12);
            this.root.Size = new System.Drawing.Size(429, 455);
            // 
            // lcgInfo
            // 
            this.lcgInfo.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lcgInfo.AppearanceGroup.Options.UseFont = true;
            this.lcgInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciMaQL,
            this.lciTenTB});
            this.lcgInfo.Location = new System.Drawing.Point(0, 1);
            this.lcgInfo.Name = "lcgInfo";
            this.lcgInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 8, 8);
            this.lcgInfo.Size = new System.Drawing.Size(405, 85);
            this.lcgInfo.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 6);
            this.lcgInfo.Text = "Thông tin";
            // 
            // lciMaQL
            // 
            this.lciMaQL.Control = this.txtMaQL;
            this.lciMaQL.Location = new System.Drawing.Point(0, 0);
            this.lciMaQL.Name = "lciMaQL";
            this.lciMaQL.Size = new System.Drawing.Size(383, 22);
            this.lciMaQL.Text = "Mã quản lý";
            this.lciMaQL.TextSize = new System.Drawing.Size(114, 13);
            // 
            // txtMaQL
            // 
            this.txtMaQL.Location = new System.Drawing.Point(150, 40);
            this.txtMaQL.Name = "txtMaQL";
            this.txtMaQL.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMaQL.Properties.Appearance.Options.UseBackColor = true;
            this.txtMaQL.Properties.ReadOnly = true;
            this.txtMaQL.Size = new System.Drawing.Size(255, 20);
            this.txtMaQL.StyleController = this.layoutControl1;
            this.txtMaQL.TabIndex = 4;
            // 
            // lciTenTB
            // 
            this.lciTenTB.Control = this.txtTenTB;
            this.lciTenTB.Location = new System.Drawing.Point(0, 22);
            this.lciTenTB.Name = "lciTenTB";
            this.lciTenTB.Size = new System.Drawing.Size(383, 22);
            this.lciTenTB.Text = "Tên thiết bị";
            this.lciTenTB.TextSize = new System.Drawing.Size(114, 13);
            // 
            // txtTenTB
            // 
            this.txtTenTB.Location = new System.Drawing.Point(150, 62);
            this.txtTenTB.Name = "txtTenTB";
            this.txtTenTB.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTenTB.Properties.Appearance.Options.UseBackColor = true;
            this.txtTenTB.Properties.ReadOnly = true;
            this.txtTenTB.Size = new System.Drawing.Size(255, 20);
            this.txtTenTB.StyleController = this.layoutControl1;
            this.txtTenTB.TabIndex = 5;
            // 
            // sep1
            // 
            this.sep1.Location = new System.Drawing.Point(0, 0);
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(405, 1);
            // 
            // lcgBaoDuong
            // 
            this.lcgBaoDuong.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lcgBaoDuong.AppearanceGroup.Options.UseFont = true;
            this.lcgBaoDuong.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciNgayBD,
            this.lciTanSuat,
            this.lciNgayKH,
            this.lciStatus});
            this.lcgBaoDuong.Location = new System.Drawing.Point(0, 86);
            this.lcgBaoDuong.Name = "lcgBaoDuong";
            this.lcgBaoDuong.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 8, 8);
            this.lcgBaoDuong.Size = new System.Drawing.Size(405, 135);
            this.lcgBaoDuong.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 6, 6);
            this.lcgBaoDuong.Text = "Bảo dưỡng";
            // 
            // lciNgayBD
            // 
            this.lciNgayBD.Control = this.dtNgayBD;
            this.lciNgayBD.Location = new System.Drawing.Point(0, 0);
            this.lciNgayBD.Name = "lciNgayBD";
            this.lciNgayBD.Size = new System.Drawing.Size(383, 22);
            this.lciNgayBD.Text = "Ngày bảo dưỡng";
            this.lciNgayBD.TextSize = new System.Drawing.Size(114, 13);
            // 
            // dtNgayBD
            // 
            this.dtNgayBD.EditValue = new System.DateTime(2025, 12, 19, 0, 0, 0, 0);
            this.dtNgayBD.Location = new System.Drawing.Point(150, 131);
            this.dtNgayBD.Name = "dtNgayBD";
            this.dtNgayBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayBD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayBD.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtNgayBD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayBD.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtNgayBD.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayBD.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtNgayBD.Size = new System.Drawing.Size(255, 20);
            this.dtNgayBD.StyleController = this.layoutControl1;
            this.dtNgayBD.TabIndex = 6;
            // 
            // lciTanSuat
            // 
            this.lciTanSuat.Control = this.cboTanSuat;
            this.lciTanSuat.Location = new System.Drawing.Point(0, 66);
            this.lciTanSuat.Name = "lciTanSuat";
            this.lciTanSuat.Size = new System.Drawing.Size(383, 22);
            this.lciTanSuat.Text = "Tần suất";
            this.lciTanSuat.TextSize = new System.Drawing.Size(114, 13);
            // 
            // cboTanSuat
            // 
            this.cboTanSuat.Location = new System.Drawing.Point(150, 197);
            this.cboTanSuat.Name = "cboTanSuat";
            this.cboTanSuat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTanSuat.Properties.NullText = "";
            this.cboTanSuat.Properties.ShowHeader = false;
            this.cboTanSuat.Size = new System.Drawing.Size(255, 20);
            this.cboTanSuat.StyleController = this.layoutControl1;
            this.cboTanSuat.TabIndex = 7;
            // 
            // lciNgayKH
            // 
            this.lciNgayKH.Control = this.dtNgayKH;
            this.lciNgayKH.Location = new System.Drawing.Point(0, 44);
            this.lciNgayKH.Name = "lciNgayKH";
            this.lciNgayKH.Size = new System.Drawing.Size(383, 22);
            this.lciNgayKH.Text = "KH bảo dưỡng tiếp theo";
            this.lciNgayKH.TextSize = new System.Drawing.Size(114, 13);
            // 
            // dtNgayKH
            // 
            this.dtNgayKH.EditValue = new System.DateTime(2025, 12, 19, 0, 0, 0, 0);
            this.dtNgayKH.Location = new System.Drawing.Point(150, 175);
            this.dtNgayKH.Name = "dtNgayKH";
            this.dtNgayKH.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dtNgayKH.Properties.Appearance.Options.UseBackColor = true;
            this.dtNgayKH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayKH.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayKH.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtNgayKH.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayKH.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtNgayKH.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayKH.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtNgayKH.Properties.ReadOnly = true;
            this.dtNgayKH.Size = new System.Drawing.Size(255, 20);
            this.dtNgayKH.StyleController = this.layoutControl1;
            this.dtNgayKH.TabIndex = 8;
            // 
            // lciStatus
            // 
            this.lciStatus.Control = this.cboStatus;
            this.lciStatus.Location = new System.Drawing.Point(0, 22);
            this.lciStatus.Name = "lciStatus";
            this.lciStatus.Size = new System.Drawing.Size(383, 22);
            this.lciStatus.Text = "Trạng thái";
            this.lciStatus.TextSize = new System.Drawing.Size(114, 13);
            // 
            // cboStatus
            // 
            this.cboStatus.Location = new System.Drawing.Point(150, 153);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStatus.Properties.NullText = "";
            this.cboStatus.Properties.ShowHeader = false;
            this.cboStatus.Size = new System.Drawing.Size(255, 20);
            this.cboStatus.StyleController = this.layoutControl1;
            this.cboStatus.TabIndex = 9;
            // 
            // lcgFiles
            // 
            this.lcgFiles.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lcgFiles.AppearanceGroup.Options.UseFont = true;
            this.lcgFiles.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciLSSC,
            this.lciOpenLSSC,
            this.lciChooseLSSC});
            this.lcgFiles.Location = new System.Drawing.Point(0, 221);
            this.lcgFiles.Name = "lcgFiles";
            this.lcgFiles.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 8, 8);
            this.lcgFiles.Size = new System.Drawing.Size(405, 210);
            this.lcgFiles.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 6);
            this.lcgFiles.Text = "Chọn File";
            // 
            // lciLSSC
            // 
            this.lciLSSC.Control = this.txtLSSC;
            this.lciLSSC.Location = new System.Drawing.Point(0, 0);
            this.lciLSSC.MaxSize = new System.Drawing.Size(0, 36);
            this.lciLSSC.MinSize = new System.Drawing.Size(1, 36);
            this.lciLSSC.Name = "lciLSSC";
            this.lciLSSC.Size = new System.Drawing.Size(383, 36);
            this.lciLSSC.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciLSSC.Text = "Lịch sử bảo dưỡng";
            this.lciLSSC.TextSize = new System.Drawing.Size(114, 13);
            // 
            // txtLSSC
            // 
            this.txtLSSC.Location = new System.Drawing.Point(150, 260);
            this.txtLSSC.Name = "txtLSSC";
            this.txtLSSC.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLSSC.Properties.Appearance.Options.UseBackColor = true;
            this.txtLSSC.Properties.ReadOnly = true;
            this.txtLSSC.Size = new System.Drawing.Size(255, 20);
            this.txtLSSC.StyleController = this.layoutControl1;
            this.txtLSSC.TabIndex = 10;
            // 
            // lciChooseLSSC
            // 
            this.lciChooseLSSC.Control = this.btnChooseLSSC;
            this.lciChooseLSSC.Location = new System.Drawing.Point(0, 36);
            this.lciChooseLSSC.Name = "lciChooseLSSC";
            this.lciChooseLSSC.Size = new System.Drawing.Size(191, 133);
            this.lciChooseLSSC.TextVisible = false;
            // 
            // btnChooseLSSC
            // 
            this.btnChooseLSSC.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnChooseLSSC.Appearance.Options.UseFont = true;
            this.btnChooseLSSC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnChooseLSSC.ImageOptions.SvgImage")));
            this.btnChooseLSSC.Location = new System.Drawing.Point(24, 296);
            this.btnChooseLSSC.MinimumSize = new System.Drawing.Size(90, 32);
            this.btnChooseLSSC.Name = "btnChooseLSSC";
            this.btnChooseLSSC.Size = new System.Drawing.Size(189, 36);
            this.btnChooseLSSC.StyleController = this.layoutControl1;
            this.btnChooseLSSC.TabIndex = 11;
            this.btnChooseLSSC.Text = "Chọn file";
            this.btnChooseLSSC.Click += new System.EventHandler(this.btnChooseLSSC_Click);
            // 
            // lciOpenLSSC
            // 
            this.lciOpenLSSC.Control = this.btnOpenLSSC;
            this.lciOpenLSSC.Location = new System.Drawing.Point(191, 36);
            this.lciOpenLSSC.Name = "lciOpenLSSC";
            this.lciOpenLSSC.Size = new System.Drawing.Size(192, 133);
            this.lciOpenLSSC.TextVisible = false;
            // 
            // btnOpenLSSC
            // 
            this.btnOpenLSSC.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenLSSC.Appearance.Options.UseFont = true;
            this.btnOpenLSSC.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpenLSSC.ImageOptions.SvgImage")));
            this.btnOpenLSSC.Location = new System.Drawing.Point(215, 296);
            this.btnOpenLSSC.MinimumSize = new System.Drawing.Size(70, 32);
            this.btnOpenLSSC.Name = "btnOpenLSSC";
            this.btnOpenLSSC.Size = new System.Drawing.Size(190, 36);
            this.btnOpenLSSC.StyleController = this.layoutControl1;
            this.btnOpenLSSC.TabIndex = 12;
            this.btnOpenLSSC.Text = "Mở";
            this.btnOpenLSSC.Click += new System.EventHandler(this.btnOpenLSSC_Click);
            // 
            // lcgButtons
            // 
            this.lcgButtons.GroupBordersVisible = false;
            this.lcgButtons.Location = new System.Drawing.Point(0, 1);
            this.lcgButtons.Name = "lcgButtons";
            this.lcgButtons.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 0);
            this.lcgButtons.Size = new System.Drawing.Size(1084, 129);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(241, 383);
            this.btnClose.MinimumSize = new System.Drawing.Size(120, 36);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 36);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(42, 383);
            this.btnSave.MinimumSize = new System.Drawing.Size(120, 36);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 36);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FRM_EDIT_MAINT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 455);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Office 2019 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_EDIT_MAINT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sửa bảo dưỡng thiết bị";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMaQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTenTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sep1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgBaoDuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNgayBD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTanSuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTanSuat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNgayKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayKH.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLSSC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLSSC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciChooseLSSC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOpenLSSC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButtons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;

        private DevExpress.XtraEditors.TextEdit txtMaQL;
        private DevExpress.XtraEditors.TextEdit txtTenTB;

        private DevExpress.XtraEditors.DateEdit dtNgayBD;
        private DevExpress.XtraEditors.DateEdit dtNgayKH;

        private DevExpress.XtraEditors.LookUpEdit cboTanSuat;
        private DevExpress.XtraEditors.LookUpEdit cboStatus;

        // NEW LSSC
        private DevExpress.XtraEditors.TextEdit txtLSSC;
        private DevExpress.XtraEditors.SimpleButton btnChooseLSSC;
        private DevExpress.XtraEditors.SimpleButton btnOpenLSSC;

        private DevExpress.XtraLayout.LayoutControlGroup root;
        private DevExpress.XtraLayout.LayoutControlGroup lcgInfo;
        private DevExpress.XtraLayout.LayoutControlGroup lcgBaoDuong;
        private DevExpress.XtraLayout.LayoutControlGroup lcgFiles;
        private DevExpress.XtraLayout.LayoutControlGroup lcgButtons;

        private DevExpress.XtraLayout.LayoutControlItem lciMaQL;
        private DevExpress.XtraLayout.LayoutControlItem lciTenTB;

        private DevExpress.XtraLayout.LayoutControlItem lciNgayBD;
        private DevExpress.XtraLayout.LayoutControlItem lciTanSuat;
        private DevExpress.XtraLayout.LayoutControlItem lciNgayKH;
        private DevExpress.XtraLayout.LayoutControlItem lciStatus;

        private DevExpress.XtraLayout.LayoutControlItem lciLSSC;
        private DevExpress.XtraLayout.LayoutControlItem lciChooseLSSC;
        private DevExpress.XtraLayout.LayoutControlItem lciOpenLSSC;

        private DevExpress.XtraLayout.SimpleSeparator sep1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
