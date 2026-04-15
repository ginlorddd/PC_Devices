namespace DM_OHD.FRM
{
    partial class FRM_OHD_ALERT
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.DateEdit deFrom;
        private DevExpress.XtraEditors.DateEdit deTo;
        private DevExpress.XtraEditors.LabelControl lblFrom;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnConfigMail;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnRule;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView view;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.deFrom = new DevExpress.XtraEditors.DateEdit();
            this.deTo = new DevExpress.XtraEditors.DateEdit();
            this.lblFrom = new DevExpress.XtraEditors.LabelControl();
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfigMail = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnRule = new DevExpress.XtraEditors.SimpleButton();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.SuspendLayout();
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1280, 52);
            this.panelTop.Controls.Add(this.lblFrom);
            this.panelTop.Controls.Add(this.deFrom);
            this.panelTop.Controls.Add(this.lblTo);
            this.panelTop.Controls.Add(this.deTo);
            this.panelTop.Controls.Add(this.btnUpdate);
            this.panelTop.Controls.Add(this.btnConfigMail);
            this.panelTop.Controls.Add(this.btnRule);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnApprove);
            this.panelTop.Controls.Add(this.btnSave);
            this.lblFrom.Location = new System.Drawing.Point(12, 18);
            this.lblFrom.Text = "Từ tháng";
            this.deFrom.Location = new System.Drawing.Point(65, 15);
            this.deFrom.Size = new System.Drawing.Size(120, 22);
            this.lblTo.Location = new System.Drawing.Point(200, 18);
            this.lblTo.Text = "Đến tháng";
            this.deTo.Location = new System.Drawing.Point(262, 15);
            this.deTo.Size = new System.Drawing.Size(120, 22);
            this.btnRefresh.Location = new System.Drawing.Point(400, 13);
            this.btnRefresh.Size = new System.Drawing.Size(85, 26);
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Text = "Refresh";
            this.btnUpdate.Location = new System.Drawing.Point(490, 13);
            this.btnUpdate.Size = new System.Drawing.Size(140, 26);
            this.btnUpdate.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(245)))), ((int)(((byte)(232)))));
            this.btnUpdate.Appearance.Options.UseBackColor = true;
            this.btnUpdate.Text = "Cập nhật khuôn";
            this.btnRule.Location = new System.Drawing.Point(635, 13);
            this.btnRule.Size = new System.Drawing.Size(140, 26);
            this.btnRule.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(205)))));
            this.btnRule.Appearance.Options.UseBackColor = true;
            this.btnRule.Text = "Điều chỉnh quy tắc";
            this.btnConfigMail.Location = new System.Drawing.Point(780, 13);
            this.btnConfigMail.Size = new System.Drawing.Size(100, 26);
            this.btnConfigMail.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.btnConfigMail.Appearance.Options.UseBackColor = true;
            this.btnConfigMail.Text = "Config mail";
            this.btnApprove.Location = new System.Drawing.Point(885, 13);
            this.btnApprove.Size = new System.Drawing.Size(95, 26);
            this.btnApprove.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(214)))));
            this.btnApprove.Appearance.Options.UseBackColor = true;
            this.btnApprove.Text = "Duyệt";
            this.btnSave.Location = new System.Drawing.Point(985, 13);
            this.btnSave.Size = new System.Drawing.Size(95, 26);
            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Text = "Lưu";
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 52);
            this.grid.MainView = this.view;
            this.grid.Size = new System.Drawing.Size(1280, 618);
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.view });
            this.view.GridControl = this.grid;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 670);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panelTop);
            this.Name = "FRM_OHD_ALERT";
            this.Text = "Cảnh báo tiến độ OHD";
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
