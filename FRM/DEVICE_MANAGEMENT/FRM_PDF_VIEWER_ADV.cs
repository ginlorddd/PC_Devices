using DevExpress.Pdf;
using DevExpress.XtraEditors;
using DevExpress.XtraPdfViewer;
using System;
using System.Diagnostics;
using System.IO;
using PC_Devices.DB;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_PDF_VIEWER_ADV : XtraForm
    {
        private string _fullPath;

        public FRM_PDF_VIEWER_ADV(string fullPath)
        {
            InitializeComponent();
            _fullPath = fullPath;
        }

        private void FRM_PDF_VIEWER_ADV_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(_fullPath))
                {
                    XtraMessageBox.Show("Không tìm thấy file PDF!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }
                pdfViewer1.LoadDocument(_fullPath);
                lblPage.Text = pdfViewer1.CurrentPageNumber.ToString() + "/" + pdfViewer1.PageCount;
                lblFileName.Text = Path.GetFileName(_fullPath);
            }
            catch
            {
                XtraMessageBox.Show("Không thể mở file PDF!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pdfViewer1_ScrollPositionChanged(object sender, PdfScrollPositionChangedEventArgs e)
        {
            lblPage.Text = pdfViewer1.CurrentPageNumber + "/" + pdfViewer1.PageCount;
        }

        //private void pdfViewer1_PopupMenuShowing(object sender, PdfPopupMenuShowingEventArgs e)
        //{
        //    e.Menu.ItemLinks.Clear(); // Disable right-click menu
        //}

        //private void pdfViewer1_PrintPage(object sender, DevExpress.Pdf.PdfPrintPageEventArgs e)
        //{
        //    XtraMessageBox.Show("Tài liệu không được phép in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    e.Cancel = true;
        //}

        //private void pdfViewer1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Control && e.KeyCode == Keys.P)
        //    {
        //        e.SuppressKeyPress = true;
        //        XtraMessageBox.Show("Không được phép in!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            pdfViewer1.ZoomMode = PdfZoomMode.Custom;
            pdfViewer1.ZoomFactor += 10;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            pdfViewer1.ZoomMode = PdfZoomMode.Custom;
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
            pdfViewer1.CursorMode = PdfCursorMode.MarqueeZoom;
        }

        private void btnSelectTool_Click(object sender, EventArgs e)
        {
            pdfViewer1.CursorMode = PdfCursorMode.SelectTool;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select," + _fullPath);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "PDF File|*.pdf";
                dlg.FileName = Path.GetFileName(_fullPath); // giữ nguyên tên file gốc

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(_fullPath, dlg.FileName, true);

                    XtraMessageBox.Show("Đã lưu file thành công!",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi lưu file: " + ex.Message,
                                     "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
