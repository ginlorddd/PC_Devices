namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    partial class FRM_EDIT_DEVICE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_EDIT_DEVICE));
            this.imgBarCode = new DevExpress.XtraEditors.PictureEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDeviceType = new DevExpress.XtraEditors.GridLookUpEdit();
            this.txtDocumentTopLvView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label18 = new System.Windows.Forms.Label();
            this.dtNgayBD = new DevExpress.XtraEditors.DateEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTanSuatBD = new DevExpress.XtraEditors.GridLookUpEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDel4 = new DevExpress.XtraEditors.SimpleButton();
            this.btnChooseLSSC = new DevExpress.XtraEditors.SimpleButton();
            this.txtAttachFileLSSC = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnDel3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnChooseBCDT = new DevExpress.XtraEditors.SimpleButton();
            this.txtAttachFileBCDT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFactory = new DevExpress.XtraEditors.GridLookUpEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMQL = new System.Windows.Forms.TextBox();
            this.btnDel2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnChooseHDSD = new DevExpress.XtraEditors.SimpleButton();
            this.btnChooseIMG = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAttachFileHDSD = new System.Windows.Forms.TextBox();
            this.txtAttachFileIMG = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.checkTSCD = new DevExpress.XtraEditors.CheckEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgBarCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentTopLvView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTanSuatBD.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTSCD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBarCode
            // 
            this.imgBarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBarCode.Location = new System.Drawing.Point(3, 17);
            this.imgBarCode.Name = "imgBarCode";
            this.imgBarCode.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.imgBarCode.Size = new System.Drawing.Size(261, 335);
            this.imgBarCode.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(968, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 29);
            this.btnSave.TabIndex = 131;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.Location = new System.Drawing.Point(1052, 390);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 29);
            this.btnExit.TabIndex = 130;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // txtDeviceType
            // 
            this.txtDeviceType.Location = new System.Drawing.Point(266, 30);
            this.txtDeviceType.Name = "txtDeviceType";
            this.txtDeviceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDeviceType.Properties.NullText = "";
            this.txtDeviceType.Properties.PopupView = this.txtDocumentTopLvView;
            this.txtDeviceType.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.txtDeviceType.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoSearch;
            this.txtDeviceType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtDeviceType.Size = new System.Drawing.Size(265, 22);
            this.txtDeviceType.TabIndex = 2;
            // 
            // txtDocumentTopLvView
            // 
            this.txtDocumentTopLvView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.txtDocumentTopLvView.Name = "txtDocumentTopLvView";
            this.txtDocumentTopLvView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.txtDocumentTopLvView.OptionsView.ShowGroupPanel = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.imgBarCode);
            this.groupBox3.Location = new System.Drawing.Point(866, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(267, 355);
            this.groupBox3.TabIndex = 129;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bar Code";
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 319);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 16);
            this.label18.TabIndex = 38;
            this.label18.Text = "Ngày bảo dưỡng:";
            // 
            // dtNgayBD
            // 
            this.dtNgayBD.EditValue = null;
            this.dtNgayBD.Location = new System.Drawing.Point(195, 317);
            this.dtNgayBD.Name = "dtNgayBD";
            this.dtNgayBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayBD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayBD.Size = new System.Drawing.Size(236, 22);
            this.dtNgayBD.TabIndex = 37;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(574, 319);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 16);
            this.label17.TabIndex = 35;
            this.label17.Text = "Tài sản cố định:";
            // 
            // txtTanSuatBD
            // 
            this.txtTanSuatBD.AllowDrop = true;
            this.txtTanSuatBD.Location = new System.Drawing.Point(682, 135);
            this.txtTanSuatBD.Name = "txtTanSuatBD";
            this.txtTanSuatBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTanSuatBD.Properties.NullText = "";
            this.txtTanSuatBD.Properties.PopupView = this.gridView2;
            this.txtTanSuatBD.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.txtTanSuatBD.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoSearch;
            this.txtTanSuatBD.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtTanSuatBD.Size = new System.Drawing.Size(156, 22);
            this.txtTanSuatBD.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.dtNgayBD);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtTanSuatBD);
            this.groupBox1.Controls.Add(this.txtDeviceType);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btnDel4);
            this.groupBox1.Controls.Add(this.btnChooseLSSC);
            this.groupBox1.Controls.Add(this.txtAttachFileLSSC);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.btnDel3);
            this.groupBox1.Controls.Add(this.btnChooseBCDT);
            this.groupBox1.Controls.Add(this.txtAttachFileBCDT);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtFactory);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtPurpose);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSupplier);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSize);
            this.groupBox1.Controls.Add(this.txtSerial);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMQL);
            this.groupBox1.Controls.Add(this.btnDel2);
            this.groupBox1.Controls.Add(this.btnDel1);
            this.groupBox1.Controls.Add(this.btnChooseHDSD);
            this.groupBox1.Controls.Add(this.btnChooseIMG);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAttachFileHDSD);
            this.groupBox1.Controls.Add(this.txtAttachFileIMG);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtDeviceName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtModel);
            this.groupBox1.Controls.Add(this.checkTSCD);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 355);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thiết bị";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(574, 137);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 16);
            this.label16.TabIndex = 32;
            this.label16.Text = "Tần suất BD:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(182, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Loại thiết bị:";
            // 
            // btnDel4
            // 
            this.btnDel4.Location = new System.Drawing.Point(790, 280);
            this.btnDel4.Name = "btnDel4";
            this.btnDel4.Size = new System.Drawing.Size(48, 21);
            this.btnDel4.TabIndex = 24;
            this.btnDel4.Text = "Xóa";
            // 
            // btnChooseLSSC
            // 
            this.btnChooseLSSC.Location = new System.Drawing.Point(736, 280);
            this.btnChooseLSSC.Name = "btnChooseLSSC";
            this.btnChooseLSSC.Size = new System.Drawing.Size(48, 21);
            this.btnChooseLSSC.TabIndex = 23;
            this.btnChooseLSSC.Text = "Chọn";
            this.btnChooseLSSC.Click += new System.EventHandler(this.btnChooseLSSC_Click);
            // 
            // txtAttachFileLSSC
            // 
            this.txtAttachFileLSSC.Location = new System.Drawing.Point(195, 281);
            this.txtAttachFileLSSC.Name = "txtAttachFileLSSC";
            this.txtAttachFileLSSC.ReadOnly = true;
            this.txtAttachFileLSSC.Size = new System.Drawing.Size(535, 21);
            this.txtAttachFileLSSC.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(5, 281);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(160, 16);
            this.label15.TabIndex = 28;
            this.label15.Text = "File Sửa chữa, Bảo dưỡng:";
            // 
            // btnDel3
            // 
            this.btnDel3.Location = new System.Drawing.Point(790, 246);
            this.btnDel3.Name = "btnDel3";
            this.btnDel3.Size = new System.Drawing.Size(48, 21);
            this.btnDel3.TabIndex = 21;
            this.btnDel3.Text = "Xóa";
            // 
            // btnChooseBCDT
            // 
            this.btnChooseBCDT.Location = new System.Drawing.Point(736, 246);
            this.btnChooseBCDT.Name = "btnChooseBCDT";
            this.btnChooseBCDT.Size = new System.Drawing.Size(48, 21);
            this.btnChooseBCDT.TabIndex = 20;
            this.btnChooseBCDT.Text = "Chọn";
            this.btnChooseBCDT.Click += new System.EventHandler(this.btnChooseBCDT_Click);
            // 
            // txtAttachFileBCDT
            // 
            this.txtAttachFileBCDT.Location = new System.Drawing.Point(195, 247);
            this.txtAttachFileBCDT.Name = "txtAttachFileBCDT";
            this.txtAttachFileBCDT.ReadOnly = true;
            this.txtAttachFileBCDT.Size = new System.Drawing.Size(535, 21);
            this.txtAttachFileBCDT.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "File Báo cáo đào tạo:";
            // 
            // txtFactory
            // 
            this.txtFactory.Location = new System.Drawing.Point(90, 30);
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFactory.Properties.NullText = "";
            this.txtFactory.Properties.PopupView = this.gridView1;
            this.txtFactory.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.txtFactory.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoSearch;
            this.txtFactory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtFactory.Size = new System.Drawing.Size(70, 22);
            this.txtFactory.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "Nhà máy: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Mục đích SD:";
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(91, 135);
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(440, 21);
            this.txtPurpose.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(574, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Nhà cung cấp: ";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(682, 100);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(156, 21);
            this.txtSupplier.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(278, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Kích thước: ";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(369, 100);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(162, 21);
            this.txtSize.TabIndex = 9;
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(682, 65);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(156, 21);
            this.txtSerial.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(574, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "SerialNo:";
            // 
            // txtMQL
            // 
            this.txtMQL.Location = new System.Drawing.Point(682, 30);
            this.txtMQL.Name = "txtMQL";
            this.txtMQL.ReadOnly = true;
            this.txtMQL.Size = new System.Drawing.Size(156, 21);
            this.txtMQL.TabIndex = 3;
            // 
            // btnDel2
            // 
            this.btnDel2.Location = new System.Drawing.Point(791, 211);
            this.btnDel2.Name = "btnDel2";
            this.btnDel2.Size = new System.Drawing.Size(48, 21);
            this.btnDel2.TabIndex = 18;
            this.btnDel2.Text = "Xóa";
            // 
            // btnDel1
            // 
            this.btnDel1.Location = new System.Drawing.Point(790, 175);
            this.btnDel1.Name = "btnDel1";
            this.btnDel1.Size = new System.Drawing.Size(48, 21);
            this.btnDel1.TabIndex = 15;
            this.btnDel1.Text = "Xóa";
            // 
            // btnChooseHDSD
            // 
            this.btnChooseHDSD.Location = new System.Drawing.Point(737, 211);
            this.btnChooseHDSD.Name = "btnChooseHDSD";
            this.btnChooseHDSD.Size = new System.Drawing.Size(48, 21);
            this.btnChooseHDSD.TabIndex = 17;
            this.btnChooseHDSD.Text = "Chọn";
            this.btnChooseHDSD.Click += new System.EventHandler(this.btnChooseHDSD_Click);
            // 
            // btnChooseIMG
            // 
            this.btnChooseIMG.Location = new System.Drawing.Point(736, 175);
            this.btnChooseIMG.Name = "btnChooseIMG";
            this.btnChooseIMG.Size = new System.Drawing.Size(48, 21);
            this.btnChooseIMG.TabIndex = 14;
            this.btnChooseIMG.Text = "Chọn";
            this.btnChooseIMG.Click += new System.EventHandler(this.btnChooseIMG_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên thiết bị:";
            // 
            // txtAttachFileHDSD
            // 
            this.txtAttachFileHDSD.Location = new System.Drawing.Point(195, 211);
            this.txtAttachFileHDSD.Name = "txtAttachFileHDSD";
            this.txtAttachFileHDSD.ReadOnly = true;
            this.txtAttachFileHDSD.Size = new System.Drawing.Size(535, 21);
            this.txtAttachFileHDSD.TabIndex = 16;
            // 
            // txtAttachFileIMG
            // 
            this.txtAttachFileIMG.Location = new System.Drawing.Point(194, 175);
            this.txtAttachFileIMG.Name = "txtAttachFileIMG";
            this.txtAttachFileIMG.ReadOnly = true;
            this.txtAttachFileIMG.Size = new System.Drawing.Size(536, 21);
            this.txtAttachFileIMG.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Model: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(5, 211);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(148, 16);
            this.label14.TabIndex = 1;
            this.label14.Text = "File Hướng dẫn sử dụng:";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(90, 65);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(441, 21);
            this.txtDeviceName.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "File Người được phép sử dụng:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(574, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Mã quản lý:";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(90, 100);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(159, 21);
            this.txtModel.TabIndex = 8;
            // 
            // checkTSCD
            // 
            this.checkTSCD.Location = new System.Drawing.Point(683, 317);
            this.checkTSCD.Name = "checkTSCD";
            this.checkTSCD.Properties.AutoHeight = false;
            this.checkTSCD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkTSCD.Properties.Caption = "Có";
            this.checkTSCD.Size = new System.Drawing.Size(70, 22);
            this.checkTSCD.TabIndex = 36;
            // 
            // FRM_EDIT_DEVICE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 431);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FRM_EDIT_DEVICE";
            this.Text = "FRM_EDIT_DEVICE";
            ((System.ComponentModel.ISupportInitialize)(this.imgBarCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentTopLvView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTanSuatBD.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTSCD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit imgBarCode;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GridLookUpEdit txtDeviceType;
        private DevExpress.XtraGrid.Views.Grid.GridView txtDocumentTopLvView;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.Label label18;
        private DevExpress.XtraEditors.DateEdit dtNgayBD;
        private System.Windows.Forms.Label label17;
        private DevExpress.XtraEditors.GridLookUpEdit txtTanSuatBD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.SimpleButton btnDel4;
        private DevExpress.XtraEditors.SimpleButton btnChooseLSSC;
        private System.Windows.Forms.TextBox txtAttachFileLSSC;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.SimpleButton btnDel3;
        private DevExpress.XtraEditors.SimpleButton btnChooseBCDT;
        private System.Windows.Forms.TextBox txtAttachFileBCDT;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.GridLookUpEdit txtFactory;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMQL;
        private DevExpress.XtraEditors.SimpleButton btnDel2;
        private DevExpress.XtraEditors.SimpleButton btnDel1;
        private DevExpress.XtraEditors.SimpleButton btnChooseHDSD;
        private DevExpress.XtraEditors.SimpleButton btnChooseIMG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAttachFileHDSD;
        private System.Windows.Forms.TextBox txtAttachFileIMG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtModel;
        private DevExpress.XtraEditors.CheckEdit checkTSCD;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}