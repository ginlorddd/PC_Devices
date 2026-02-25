namespace PC_Devices
{
    partial class BarcodeReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Designer generated code

        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 =
                new DevExpress.XtraPrinting.BarCode.Code128Generator();

            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrBarcode = new DevExpress.XtraReports.UI.XRBarCode();

            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();

            // Top / Bottom
            this.TopMargin.HeightF = 10F;
            this.BottomMargin.HeightF = 5F;

            // Detail
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                this.xrBarcode
            });
            this.Detail.HeightF = 80F;
            this.Detail.MultiColumn.ColumnCount = 3;
            this.Detail.MultiColumn.Mode =
                DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;

            // xrBarcode
            this.xrBarcode.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
                new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Barcode]")
            });

            // ✅ QUAN TRỌNG: làm barcode RỘNG
            this.xrBarcode.Module = 1.6F;

            // ✅ Barcode THẤP bằng Height
            this.xrBarcode.SizeF = new System.Drawing.SizeF(260F, 55F);

            this.xrBarcode.ShowText = true;
            this.xrBarcode.Font =
                new DevExpress.Drawing.DXFont("Arial", 9F);

            this.xrBarcode.Padding =
                new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);

            this.xrBarcode.LocationFloat =
                new DevExpress.Utils.PointFloat(0F, 5F);

            this.xrBarcode.Symbology = code128Generator1;
            this.xrBarcode.TextAlignment =
                DevExpress.XtraPrinting.TextAlignment.BottomCenter;

            // Report
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                this.TopMargin,
                this.BottomMargin,
                this.Detail
            });

            this.PageWidth = 827;
            this.PageHeight = 1169;
            this.PaperKind =
                DevExpress.Drawing.Printing.DXPaperKind.A4;

            this.Margins =
                new DevExpress.Drawing.DXMargins(20F, 20F, 10F, 5F);

            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRBarCode xrBarcode;
    }
}
