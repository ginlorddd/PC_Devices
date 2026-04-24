namespace JigFlow.Forms
{
    partial class FRM_FORM_MASTER
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblPlaceholder = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            this.lblPlaceholder.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblPlaceholder.Appearance.Options.UseFont = true;
            this.lblPlaceholder.Location = new System.Drawing.Point(40, 40);
            this.lblPlaceholder.Name = "lblPlaceholder";
            this.lblPlaceholder.Size = new System.Drawing.Size(250, 26);
            this.lblPlaceholder.Text = "Form Master - Đang cập nhật";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.lblPlaceholder);
            this.Name = "FRM_FORM_MASTER";
            this.Text = "Form Master";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DevExpress.XtraEditors.LabelControl lblPlaceholder;
    }
}
