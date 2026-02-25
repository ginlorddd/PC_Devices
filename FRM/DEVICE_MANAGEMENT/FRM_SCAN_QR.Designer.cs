namespace PC_Devices.FRM
{
    partial class FRM_SCAN_QR
    {
        private System.ComponentModel.IContainer components = null;

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtQR;
        private DevExpress.XtraEditors.SimpleButton btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.txtQR = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQR.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.txtQR);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(320, 120);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "SCAN QR / BARCODE";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(90, 75);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(210, 30);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Xóa";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtQR
            // 
            this.txtQR.Location = new System.Drawing.Point(90, 35);
            this.txtQR.Name = "txtQR";
            this.txtQR.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtQR.Properties.Appearance.Options.UseFont = true;
            this.txtQR.Size = new System.Drawing.Size(210, 28);
            this.txtQR.TabIndex = 1;
            this.txtQR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQR_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã Quét:";
            // 
            // FRM_SCAN_QR
            // 
            this.ClientSize = new System.Drawing.Size(330, 130);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FRM_SCAN_QR";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scan QR";
            this.Activated += new System.EventHandler(this.FRM_SCAN_QR_Activated);
            this.Load += new System.EventHandler(this.FRM_SCAN_QR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQR.Properties)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
