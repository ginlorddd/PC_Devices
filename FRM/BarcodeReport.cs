using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace PC_Devices
{
    public partial class BarcodeReport : DevExpress.XtraReports.UI.XtraReport
    {
        public BarcodeReport()
        {
            InitializeComponent();
        }

        private void DataReport()
        {
            xrBarcode.DataBindings.Clear(); // Xóa binding cũ tránh lỗi
            xrBarcode.DataBindings.Add("Text", DataSource, "Barcode");
        }

        private void BarcodeReport_BeforePrint(object sender, CancelEventArgs e)
        {
            DataReport();
        }
    }
}
