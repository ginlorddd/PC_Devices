using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using PC_Devices.FRM.DEVICE_MANAGEMENT;
using System;
using System.Windows.Forms;

namespace PC_Devices.FRM
{
    public partial class FRM_SCAN_QR : XtraForm
    {
        public FRM_SCAN_QR()
        {
            InitializeComponent();
        }

        // FOCUS textbox khi mở form
        private void FRM_SCAN_QR_Load(object sender, EventArgs e)
        {
            txtQR.Select();
        }

        private void FRM_SCAN_QR_Activated(object sender, EventArgs e)
        {
            txtQR.Focus();
            txtQR.Select();
        }

        // QUÉT BẰNG MÁY BARCODE
        private void txtQR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string qr = txtQR.Text.Trim();
                if (qr == "") return;

                ProcessQR(qr);

                txtQR.SelectAll();      // chuẩn nhất cho quét liên tục
                txtQR.Focus();
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQR.Text = "";
            txtQR.Focus();
        }

        // ======================================================
        //  TỰ ĐỘNG MỞ FRM_DEVICE_LIST & TÌM MÃ QR/MAQUANLY
        // ======================================================
        private void ProcessQR(string qr)
        {
            FRM_DEVICE_LIST frm = null;

            foreach (Form f in this.MdiParent.MdiChildren)
                if (f is FRM_DEVICE_LIST)
                    frm = (FRM_DEVICE_LIST)f;

            if (frm == null)
            {
                frm = new FRM_DEVICE_LIST();
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }

            frm.Activate();
            frm.SearchDevice(qr);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Không cho đóng
            e.Cancel = true;
            this.Hide(); // hoặc bỏ dòng này nếu muốn luôn hiện
        }

    }
}
