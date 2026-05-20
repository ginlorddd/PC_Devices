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
            this.lblFrom.Location = new System.Drawing.Point(12, 18);
            this.lblFrom.Text = "Từ";
            this.deFrom.Location = new System.Drawing.Point(30, 15);
            this.deFrom.Size = new System.Drawing.Size(120, 22);
            this.lblTo.Location = new System.Drawing.Point(165, 18);
            this.lblTo.Text = "Đến";
            this.deTo.Location = new System.Drawing.Point(190, 15);
            this.deTo.Size = new System.Drawing.Size(120, 22);
            this.btnRefresh.Location = new System.Drawing.Point(330, 13);
            this.btnRefresh.Size = new System.Drawing.Size(85, 26);
            this.btnRefresh.Text = "Refresh";
            this.btnUpdate.Location = new System.Drawing.Point(420, 13);
            this.btnUpdate.Size = new System.Drawing.Size(140, 26);
            this.btnUpdate.Text = "Cập nhật khuôn";
            this.btnRule.Location = new System.Drawing.Point(565, 13);
            this.btnRule.Size = new System.Drawing.Size(140, 26);
            this.btnRule.Text = "Điều chỉnh quy tắc";
            this.btnConfigMail.Location = new System.Drawing.Point(710, 13);
            this.btnConfigMail.Size = new System.Drawing.Size(100, 26);
            this.btnConfigMail.Text = "Config mail";
            this.btnApprove.Location = new System.Drawing.Point(815, 13);
            this.btnApprove.Size = new System.Drawing.Size(95, 26);
            this.btnApprove.Text = "Duyệt";
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
