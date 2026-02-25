namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    partial class FRM_ADD_DEVICE_REGISTER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ADD_DEVICE_REGISTER));
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblPurpose = new System.Windows.Forms.Label();
            this.lblFactory = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblNgayVe = new System.Windows.Forms.Label();
            this.lblTSCD = new System.Windows.Forms.Label();
            this.txtDeviceName = new DevExpress.XtraEditors.TextEdit();
            this.txtSerial = new DevExpress.XtraEditors.TextEdit();
            this.txtModel = new DevExpress.XtraEditors.TextEdit();
            this.txtSupplier = new DevExpress.XtraEditors.TextEdit();
            this.txtPurpose = new DevExpress.XtraEditors.MemoEdit();
            this.gluFactory = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gluFactoryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gluType = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gluTypeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dtNgayVe = new DevExpress.XtraEditors.DateEdit();
            this.chkTSCD = new DevExpress.XtraEditors.CheckEdit();
            this.groupUse = new System.Windows.Forms.GroupBox();
            this.lblThongSo = new System.Windows.Forms.Label();
            this.lblCongViec = new System.Windows.Forms.Label();
            this.lblChucNang = new System.Windows.Forms.Label();
            this.lblTaiTrong = new System.Windows.Forms.Label();
            this.lblDungSai = new System.Windows.Forms.Label();
            this.lblDanhGia = new System.Windows.Forms.Label();
            this.mmThongSo = new DevExpress.XtraEditors.MemoEdit();
            this.mmCongViec = new DevExpress.XtraEditors.MemoEdit();
            this.mmChucNang = new DevExpress.XtraEditors.MemoEdit();
            this.txtTaiTrong = new DevExpress.XtraEditors.TextEdit();
            this.txtDungSai = new DevExpress.XtraEditors.TextEdit();
            this.mmDanhGia = new DevExpress.XtraEditors.MemoEdit();
            this.groupButton = new System.Windows.Forms.GroupBox();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurpose.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluFactory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluFactoryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluTypeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayVe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayVe.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTSCD.Properties)).BeginInit();
            this.groupUse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmThongSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmCongViec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmChucNang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiTrong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDungSai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmDanhGia.Properties)).BeginInit();
            this.groupButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.lblDeviceName);
            this.groupInfo.Controls.Add(this.lblSerial);
            this.groupInfo.Controls.Add(this.lblModel);
            this.groupInfo.Controls.Add(this.lblSupplier);
            this.groupInfo.Controls.Add(this.lblPurpose);
            this.groupInfo.Controls.Add(this.lblFactory);
            this.groupInfo.Controls.Add(this.lblType);
            this.groupInfo.Controls.Add(this.lblNgayVe);
            this.groupInfo.Controls.Add(this.lblTSCD);
            this.groupInfo.Controls.Add(this.txtDeviceName);
            this.groupInfo.Controls.Add(this.txtSerial);
            this.groupInfo.Controls.Add(this.txtModel);
            this.groupInfo.Controls.Add(this.txtSupplier);
            this.groupInfo.Controls.Add(this.txtPurpose);
            this.groupInfo.Controls.Add(this.gluFactory);
            this.groupInfo.Controls.Add(this.gluType);
            this.groupInfo.Controls.Add(this.dtNgayVe);
            this.groupInfo.Controls.Add(this.chkTSCD);
            this.groupInfo.Location = new System.Drawing.Point(12, 12);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(1056, 250);
            this.groupInfo.TabIndex = 0;
            this.groupInfo.TabStop = false;
            this.groupInfo.Text = "Thông tin thiết bị";
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDeviceName.Location = new System.Drawing.Point(20, 35);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(93, 14);
            this.lblDeviceName.TabIndex = 0;
            this.lblDeviceName.Text = "Tên thiết bị (*)";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSerial.Location = new System.Drawing.Point(20, 70);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(35, 14);
            this.lblSerial.TabIndex = 1;
            this.lblSerial.Text = "Serial";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblModel.Location = new System.Drawing.Point(20, 105);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(39, 14);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Model";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSupplier.Location = new System.Drawing.Point(20, 140);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(82, 14);
            this.lblSupplier.TabIndex = 3;
            this.lblSupplier.Text = "Nhà cung cấp";
            // 
            // lblPurpose
            // 
            this.lblPurpose.AutoSize = true;
            this.lblPurpose.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblPurpose.Location = new System.Drawing.Point(20, 175);
            this.lblPurpose.Name = "lblPurpose";
            this.lblPurpose.Size = new System.Drawing.Size(104, 14);
            this.lblPurpose.TabIndex = 4;
            this.lblPurpose.Text = "Mục đích sử dụng";
            // 
            // lblFactory
            // 
            this.lblFactory.AutoSize = true;
            this.lblFactory.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFactory.Location = new System.Drawing.Point(540, 35);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(75, 14);
            this.lblFactory.TabIndex = 5;
            this.lblFactory.Text = "Nhà máy (*)";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblType.Location = new System.Drawing.Point(540, 70);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(92, 14);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "Loại thiết bị (*)";
            // 
            // lblNgayVe
            // 
            this.lblNgayVe.AutoSize = true;
            this.lblNgayVe.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblNgayVe.Location = new System.Drawing.Point(540, 105);
            this.lblNgayVe.Name = "lblNgayVe";
            this.lblNgayVe.Size = new System.Drawing.Size(51, 14);
            this.lblNgayVe.TabIndex = 7;
            this.lblNgayVe.Text = "Ngày về";
            // 
            // lblTSCD
            // 
            this.lblTSCD.AutoSize = true;
            this.lblTSCD.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTSCD.Location = new System.Drawing.Point(540, 140);
            this.lblTSCD.Name = "lblTSCD";
            this.lblTSCD.Size = new System.Drawing.Size(89, 14);
            this.lblTSCD.TabIndex = 8;
            this.lblTSCD.Text = "Tài sản cố định";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(140, 32);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(360, 22);
            this.txtDeviceName.TabIndex = 9;
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(140, 67);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(360, 22);
            this.txtSerial.TabIndex = 10;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(140, 102);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(360, 22);
            this.txtModel.TabIndex = 11;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(140, 137);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(360, 22);
            this.txtSupplier.TabIndex = 12;
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(140, 172);
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(360, 60);
            this.txtPurpose.TabIndex = 13;
            // 
            // gluFactory
            // 
            this.gluFactory.Location = new System.Drawing.Point(660, 32);
            this.gluFactory.Name = "gluFactory";
            this.gluFactory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gluFactory.Properties.NullText = "";
            this.gluFactory.Properties.PopupView = this.gluFactoryView;
            this.gluFactory.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.gluFactory.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoSearch;
            this.gluFactory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.gluFactory.Size = new System.Drawing.Size(360, 22);
            this.gluFactory.TabIndex = 14;
            // 
            // gluFactoryView
            // 
            this.gluFactoryView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gluFactoryView.Name = "gluFactoryView";
            this.gluFactoryView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gluFactoryView.OptionsView.ShowGroupPanel = false;
            // 
            // gluType
            // 
            this.gluType.Location = new System.Drawing.Point(660, 67);
            this.gluType.Name = "gluType";
            this.gluType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gluType.Properties.NullText = "";
            this.gluType.Properties.PopupView = this.gluTypeView;
            this.gluType.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.gluType.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoSearch;
            this.gluType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.gluType.Size = new System.Drawing.Size(360, 22);
            this.gluType.TabIndex = 15;
            // 
            // gluTypeView
            // 
            this.gluTypeView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gluTypeView.Name = "gluTypeView";
            this.gluTypeView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gluTypeView.OptionsView.ShowGroupPanel = false;
            // 
            // dtNgayVe
            // 
            this.dtNgayVe.EditValue = new System.DateTime(2025, 12, 14, 0, 0, 0, 0);
            this.dtNgayVe.Location = new System.Drawing.Point(660, 102);
            this.dtNgayVe.Name = "dtNgayVe";
            this.dtNgayVe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayVe.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayVe.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtNgayVe.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayVe.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtNgayVe.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayVe.Size = new System.Drawing.Size(360, 22);
            this.dtNgayVe.TabIndex = 16;
            // 
            // chkTSCD
            // 
            this.chkTSCD.Location = new System.Drawing.Point(660, 137);
            this.chkTSCD.Name = "chkTSCD";
            this.chkTSCD.Properties.Caption = "Có";
            this.chkTSCD.Size = new System.Drawing.Size(80, 20);
            this.chkTSCD.TabIndex = 17;
            // 
            // groupUse
            // 
            this.groupUse.Controls.Add(this.lblThongSo);
            this.groupUse.Controls.Add(this.lblCongViec);
            this.groupUse.Controls.Add(this.lblChucNang);
            this.groupUse.Controls.Add(this.lblTaiTrong);
            this.groupUse.Controls.Add(this.lblDungSai);
            this.groupUse.Controls.Add(this.lblDanhGia);
            this.groupUse.Controls.Add(this.mmThongSo);
            this.groupUse.Controls.Add(this.mmCongViec);
            this.groupUse.Controls.Add(this.mmChucNang);
            this.groupUse.Controls.Add(this.txtTaiTrong);
            this.groupUse.Controls.Add(this.txtDungSai);
            this.groupUse.Controls.Add(this.mmDanhGia);
            this.groupUse.Location = new System.Drawing.Point(12, 270);
            this.groupUse.Name = "groupUse";
            this.groupUse.Size = new System.Drawing.Size(1056, 300);
            this.groupUse.TabIndex = 1;
            this.groupUse.TabStop = false;
            this.groupUse.Text = "Nhu cầu sử dụng";
            // 
            // lblThongSo
            // 
            this.lblThongSo.AutoSize = true;
            this.lblThongSo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblThongSo.Location = new System.Drawing.Point(20, 35);
            this.lblThongSo.Name = "lblThongSo";
            this.lblThongSo.Size = new System.Drawing.Size(102, 14);
            this.lblThongSo.TabIndex = 0;
            this.lblThongSo.Text = "Thông số thiết bị";
            // 
            // lblCongViec
            // 
            this.lblCongViec.AutoSize = true;
            this.lblCongViec.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblCongViec.Location = new System.Drawing.Point(20, 110);
            this.lblCongViec.Name = "lblCongViec";
            this.lblCongViec.Size = new System.Drawing.Size(115, 14);
            this.lblCongViec.TabIndex = 1;
            this.lblCongViec.Text = "Công việc cần dùng";
            // 
            // lblChucNang
            // 
            this.lblChucNang.AutoSize = true;
            this.lblChucNang.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblChucNang.Location = new System.Drawing.Point(20, 185);
            this.lblChucNang.Name = "lblChucNang";
            this.lblChucNang.Size = new System.Drawing.Size(66, 14);
            this.lblChucNang.TabIndex = 2;
            this.lblChucNang.Text = "Chức năng";
            // 
            // lblTaiTrong
            // 
            this.lblTaiTrong.AutoSize = true;
            this.lblTaiTrong.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTaiTrong.Location = new System.Drawing.Point(540, 35);
            this.lblTaiTrong.Name = "lblTaiTrong";
            this.lblTaiTrong.Size = new System.Drawing.Size(57, 14);
            this.lblTaiTrong.TabIndex = 3;
            this.lblTaiTrong.Text = "Tải trọng";
            // 
            // lblDungSai
            // 
            this.lblDungSai.AutoSize = true;
            this.lblDungSai.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDungSai.Location = new System.Drawing.Point(540, 70);
            this.lblDungSai.Name = "lblDungSai";
            this.lblDungSai.Size = new System.Drawing.Size(53, 14);
            this.lblDungSai.TabIndex = 4;
            this.lblDungSai.Text = "Dung sai";
            // 
            // lblDanhGia
            // 
            this.lblDanhGia.AutoSize = true;
            this.lblDanhGia.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDanhGia.Location = new System.Drawing.Point(540, 105);
            this.lblDanhGia.Name = "lblDanhGia";
            this.lblDanhGia.Size = new System.Drawing.Size(54, 14);
            this.lblDanhGia.TabIndex = 5;
            this.lblDanhGia.Text = "Đánh giá";
            // 
            // mmThongSo
            // 
            this.mmThongSo.Location = new System.Drawing.Point(140, 32);
            this.mmThongSo.Name = "mmThongSo";
            this.mmThongSo.Size = new System.Drawing.Size(360, 65);
            this.mmThongSo.TabIndex = 6;
            // 
            // mmCongViec
            // 
            this.mmCongViec.Location = new System.Drawing.Point(140, 107);
            this.mmCongViec.Name = "mmCongViec";
            this.mmCongViec.Size = new System.Drawing.Size(360, 65);
            this.mmCongViec.TabIndex = 7;
            // 
            // mmChucNang
            // 
            this.mmChucNang.Location = new System.Drawing.Point(140, 182);
            this.mmChucNang.Name = "mmChucNang";
            this.mmChucNang.Size = new System.Drawing.Size(360, 90);
            this.mmChucNang.TabIndex = 8;
            // 
            // txtTaiTrong
            // 
            this.txtTaiTrong.Location = new System.Drawing.Point(660, 32);
            this.txtTaiTrong.Name = "txtTaiTrong";
            this.txtTaiTrong.Size = new System.Drawing.Size(360, 22);
            this.txtTaiTrong.TabIndex = 9;
            // 
            // txtDungSai
            // 
            this.txtDungSai.Location = new System.Drawing.Point(660, 67);
            this.txtDungSai.Name = "txtDungSai";
            this.txtDungSai.Size = new System.Drawing.Size(360, 22);
            this.txtDungSai.TabIndex = 10;
            // 
            // mmDanhGia
            // 
            this.mmDanhGia.Location = new System.Drawing.Point(660, 102);
            this.mmDanhGia.Name = "mmDanhGia";
            this.mmDanhGia.Size = new System.Drawing.Size(360, 170);
            this.mmDanhGia.TabIndex = 11;
            // 
            // groupButton
            // 
            this.groupButton.Controls.Add(this.btnSave);
            this.groupButton.Controls.Add(this.btnClose);
            this.groupButton.Location = new System.Drawing.Point(12, 580);
            this.groupButton.Name = "groupButton";
            this.groupButton.Size = new System.Drawing.Size(1056, 60);
            this.groupButton.TabIndex = 2;
            this.groupButton.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(20, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(140, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FRM_ADD_DEVICE_REGISTER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 650);
            this.Controls.Add(this.groupInfo);
            this.Controls.Add(this.groupUse);
            this.Controls.Add(this.groupButton);
            this.Name = "FRM_ADD_DEVICE_REGISTER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký thiết bị";
            this.Load += new System.EventHandler(this.FRM_ADD_DEVICE_REGISTER_Load);
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurpose.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluFactory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluFactoryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluTypeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayVe.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayVe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTSCD.Properties)).EndInit();
            this.groupUse.ResumeLayout(false);
            this.groupUse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmThongSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmCongViec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmChucNang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiTrong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDungSai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmDanhGia.Properties)).EndInit();
            this.groupButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.GroupBox groupUse;
        private System.Windows.Forms.GroupBox groupButton;

        // Labels groupInfo
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblPurpose;
        private System.Windows.Forms.Label lblFactory;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblNgayVe;
        private System.Windows.Forms.Label lblTSCD;

        // Labels groupUse
        private System.Windows.Forms.Label lblThongSo;
        private System.Windows.Forms.Label lblCongViec;
        private System.Windows.Forms.Label lblChucNang;
        private System.Windows.Forms.Label lblTaiTrong;
        private System.Windows.Forms.Label lblDungSai;
        private System.Windows.Forms.Label lblDanhGia;

        // Controls (match .cs)
        private DevExpress.XtraEditors.TextEdit txtDeviceName;
        private DevExpress.XtraEditors.TextEdit txtSerial;
        private DevExpress.XtraEditors.TextEdit txtModel;
        private DevExpress.XtraEditors.TextEdit txtSupplier;
        private DevExpress.XtraEditors.MemoEdit txtPurpose;

        private DevExpress.XtraEditors.GridLookUpEdit gluFactory;
        private DevExpress.XtraGrid.Views.Grid.GridView gluFactoryView;

        private DevExpress.XtraEditors.GridLookUpEdit gluType;
        private DevExpress.XtraGrid.Views.Grid.GridView gluTypeView;

        private DevExpress.XtraEditors.DateEdit dtNgayVe;
        private DevExpress.XtraEditors.CheckEdit chkTSCD;

        private DevExpress.XtraEditors.MemoEdit mmThongSo;
        private DevExpress.XtraEditors.MemoEdit mmCongViec;
        private DevExpress.XtraEditors.MemoEdit mmChucNang;
        private DevExpress.XtraEditors.TextEdit txtTaiTrong;
        private DevExpress.XtraEditors.TextEdit txtDungSai;
        private DevExpress.XtraEditors.MemoEdit mmDanhGia;

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
