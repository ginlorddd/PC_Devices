using DevExpress.XtraEditors;
using PC_Devices.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Devices.FRM.DEVICE_MANAGEMENT
{
    public partial class FRM_IMAGE_VIEWER_ADV : XtraForm
    {
        private string _imagePath;

        public FRM_IMAGE_VIEWER_ADV(string imagePath)
        {
            InitializeComponent();
            _imagePath = imagePath;

            lblFileName.Text = Path.GetFileName(imagePath);

            if (File.Exists(imagePath))
            {
                pictureEdit1.Image = Image.FromFile(imagePath);
                pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            }
            else
            {
                XtraMessageBox.Show("Không tìm thấy file ảnh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            pictureEdit1.Properties.ZoomPercent += 10;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            pictureEdit1.Properties.ZoomPercent -= 10;
        }

        private void btnFitScreen_Click(object sender, EventArgs e)
        {
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (pictureEdit1.Image != null)
            {
                pictureEdit1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureEdit1.Refresh();
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureEdit1.Image.Save(dlg.FileName);
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (Constaint._access != "1")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (File.Exists(_imagePath))
                {
                    Process.Start("explorer.exe", "/select," + _imagePath);
                }
            }
        }
    }
}
