namespace JigFlow.Forms
{
    partial class FRM_JIG_FUNCTION_LIST
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gcJig = new DevExpress.XtraGrid.GridControl();
            this.gvJig = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcJig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJig)).BeginInit();
            this.SuspendLayout();
            this.gcJig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcJig.MainView = this.gvJig;
            this.gcJig.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvJig });
            this.gvJig.OptionsView.ShowGroupPanel = false;
            this.gvJig.Columns.AddVisible("ControlNo", "Control No.");
            this.gvJig.Columns.AddVisible("JigName", "Tên Jig");
            this.gvJig.Columns.AddVisible("JigType", "Loại Jig");
            this.gvJig.Columns.AddVisible("Size", "Size");
            this.gvJig.Columns.AddVisible("UseProduct", "Sản phẩm sử dụng");
            this.Controls.Add(this.gcJig);
            this.Text = "Danh sách Jig chức năng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gcJig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvJig)).EndInit();
            this.ResumeLayout(false);
        }

        private DevExpress.XtraGrid.GridControl gcJig;
        private DevExpress.XtraGrid.Views.Grid.GridView gvJig;
    }
}
