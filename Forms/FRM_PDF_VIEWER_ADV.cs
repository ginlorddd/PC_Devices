using DevExpress.Pdf;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace JigFlow.Forms
{
    public partial class FRM_PDF_VIEWER_ADV : XtraForm
    {
        private readonly string _fullPath;

        public FRM_PDF_VIEWER_ADV(string fullPath)
        {
            InitializeComponent();
            _fullPath = fullPath;
        }

        private void FRM_PDF_VIEWER_ADV_Load(object sender, EventArgs e)
        {
            if (!File.Exists(_fullPath))
            {
                XtraMessageBox.Show("Không tìm thấy file PDF!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            pdfViewer1.LoadDocument(_fullPath);
            lblPage.Text = pdfViewer1.CurrentPageNumber + "/" + pdfViewer1.PageCount;
            lblFileName.Text = Path.GetFileName(_fullPath);
        }

        private void pdfViewer1_ScrollPositionChanged(object sender, PdfScrollPositionChangedEventArgs e)
        {
            lblPage.Text = pdfViewer1.CurrentPageNumber + "/" + pdfViewer1.PageCount;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.Custom;
            pdfViewer1.ZoomFactor += 10;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.Custom;
            pdfViewer1.ZoomFactor -= 10;
        }

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            pdfViewer1.RotationAngle -= 90;
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            pdfViewer1.RotationAngle += 90;
        }

        private void btnZoomTool_Click(object sender, EventArgs e)
        {
            pdfViewer1.CursorMode = DevExpress.XtraPdfViewer.PdfCursorMode.MarqueeZoom;
        }

        private void btnSelectTool_Click(object sender, EventArgs e)
        {
            pdfViewer1.CursorMode = DevExpress.XtraPdfViewer.PdfCursorMode.SelectTool;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select," + _fullPath);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF File|*.pdf";
                dlg.FileName = Path.GetFileName(_fullPath);

                if (dlg.ShowDialog() != DialogResult.OK) return;

                File.Copy(_fullPath, dlg.FileName, true);
                XtraMessageBox.Show("Đã lưu file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
