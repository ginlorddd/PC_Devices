namespace DM_OHD.FRM
{
    partial class FRM_CHANGE_PASSWORD
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.LabelControl lblOld;
        private DevExpress.XtraEditors.LabelControl lblNew;
        private DevExpress.XtraEditors.LabelControl lblConfirm;
        private DevExpress.XtraEditors.TextEdit txtOld;
        private DevExpress.XtraEditors.TextEdit txtNew;
        private DevExpress.XtraEditors.TextEdit txtConfirm;
        private DevExpress.XtraEditors.SimpleButton btnSave;

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
            this.lblOld = new DevExpress.XtraEditors.LabelControl();
            this.lblNew = new DevExpress.XtraEditors.LabelControl();
            this.lblConfirm = new DevExpress.XtraEditors.LabelControl();
            this.txtOld = new DevExpress.XtraEditors.TextEdit();
            this.txtNew = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirm = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirm.Properties)).BeginInit();
            this.SuspendLayout();
            this.lblOld.Location = new System.Drawing.Point(30, 30);
            this.lblOld.Text = "Mật khẩu cũ";
            this.lblNew.Location = new System.Drawing.Point(30, 70);
            this.lblNew.Text = "Mật khẩu mới";
            this.lblConfirm.Location = new System.Drawing.Point(30, 110);
            this.lblConfirm.Text = "Xác nhận";
            this.txtOld.Location = new System.Drawing.Point(140, 25);
            this.txtOld.Properties.PasswordChar = '*';
            this.txtOld.Size = new System.Drawing.Size(220, 22);
            this.txtNew.Location = new System.Drawing.Point(140, 65);
            this.txtNew.Properties.PasswordChar = '*';
            this.txtNew.Size = new System.Drawing.Size(220, 22);
            this.txtConfirm.Location = new System.Drawing.Point(140, 105);
            this.txtConfirm.Properties.PasswordChar = '*';
            this.txtConfirm.Size = new System.Drawing.Size(220, 22);
            this.btnSave.Location = new System.Drawing.Point(140, 155);
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.Text = "Lưu";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 223);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.txtOld);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.lblOld);
            this.Name = "FRM_CHANGE_PASSWORD";
            this.Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.txtOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirm.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
