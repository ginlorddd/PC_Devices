namespace PC_Devices.FRM
{
    partial class FRM_MAIL_CONFIG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.txtMailNote = new DevExpress.XtraEditors.MemoEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.checkAutoSend = new DevExpress.XtraEditors.CheckEdit();
            this.lblWarningDays = new DevExpress.XtraEditors.LabelControl();
            this.numWarningDays = new DevExpress.XtraEditors.SpinEdit();

            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.gcMail = new DevExpress.XtraGrid.GridControl();
            this.gvMail = new DevExpress.XtraGrid.Views.Grid.GridView();

            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.txtMailNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAutoSend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWarningDays.Properties)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMail)).BeginInit();

            this.SuspendLayout();

            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblNote);
            this.panelTop.Controls.Add(this.txtMailNote);
            this.panelTop.Controls.Add(this.btnSave);
            this.panelTop.Controls.Add(this.checkAutoSend);
            this.panelTop.Controls.Add(this.lblWarningDays);
            this.panelTop.Controls.Add(this.numWarningDays);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 180);

            // 
            // lblWarningDays
            // 
            this.lblWarningDays.Location = new System.Drawing.Point(20, 20);
            this.lblWarningDays.Name = "lblWarningDays";
            this.lblWarningDays.Size = new System.Drawing.Size(150, 20);
            this.lblWarningDays.Text = "Số ngày cảnh báo:";

            // 
            // numWarningDays
            // 
            this.numWarningDays.Location = new System.Drawing.Point(170, 18);
            this.numWarningDays.Name = "numWarningDays";
            this.numWarningDays.Properties.IsFloatValue = false;
            this.numWarningDays.Properties.MinValue = 1;
            this.numWarningDays.Properties.MaxValue = 60;
            this.numWarningDays.Size = new System.Drawing.Size(80, 26);

            // 
            // checkAutoSend
            // 
            this.checkAutoSend.Location = new System.Drawing.Point(20, 60);
            this.checkAutoSend.Name = "checkAutoSend";
            this.checkAutoSend.Properties.Caption = "Tự động gửi email cảnh báo";
            this.checkAutoSend.Size = new System.Drawing.Size(250, 25);

            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(20, 95);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(120, 20);
            this.lblNote.Text = "Ghi chú email:";

            // 
            // txtMailNote
            // 
            this.txtMailNote.Location = new System.Drawing.Point(20, 120);
            this.txtMailNote.Name = "txtMailNote";
            this.txtMailNote.Size = new System.Drawing.Size(550, 50);

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(600, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.Text = "Lưu cấu hình";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.gcMail);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 180);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(900, 420);

            // 
            // gcMail
            // 
            this.gcMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMail.MainView = this.gvMail;
            this.gcMail.Location = new System.Drawing.Point(2, 2);
            this.gcMail.Name = "gcMail";
            this.gcMail.Size = new System.Drawing.Size(896, 416);

            // 
            // gvMail
            // 
            this.gvMail.GridControl = this.gcMail;
            this.gvMail.Name = "gvMail";
            this.gvMail.OptionsBehavior.Editable = true;
            this.gvMail.OptionsView.ShowGroupPanel = false;

            // 
            // FRM_MAIL_CONFIG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_MAIL_CONFIG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình cảnh báo Email";
            this.Load += new System.EventHandler(this.FRM_MAIL_CONFIG_Load);

            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.numWarningDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAutoSend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailNote.Properties)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMail)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.PanelControl panelBottom;
        private DevExpress.XtraGrid.GridControl gcMail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMail;
        private DevExpress.XtraEditors.LabelControl lblWarningDays;
        private DevExpress.XtraEditors.SpinEdit numWarningDays;
        private DevExpress.XtraEditors.CheckEdit checkAutoSend;
        private DevExpress.XtraEditors.MemoEdit txtMailNote;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl lblNote;
    }
}
