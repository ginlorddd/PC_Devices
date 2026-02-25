using DevExpress.XtraBars;
using PC_Devices.DB;
using PC_Devices.FRM.DEVICE_MANAGEMENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTabbedMdi;

namespace PC_Devices.FRM
{
    public partial class FRM_MAIN : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
            
        public FRM_MAIN()
        {
            InitializeComponent();
        }
        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            Constaint._userID = "";
            Constaint._access = "";
            this.IsMdiContainer = true;
            xtraTabbedMdiManager1.MdiParent = this;
            // 👉 Mở mặc định danh sách thiết bị
            OpenDeviceList();

            // 👉 Mở Scan QR (không cho đóng)
            OpenScanQR_Locked();
        }

        private void OpenDeviceList()
        {
            Form frm = CheckForm(typeof(FRM_DEVICE_LIST));
            if (frm == null)
            {
                FRM_DEVICE_LIST f = new FRM_DEVICE_LIST();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void OpenScanQR_Locked()
        {
            if (scanForm == null || scanForm.IsDisposed)
            {
                scanForm = new FRM_SCAN_QR();
                scanForm.MdiParent = this;

                // Không cho minimize / close
                scanForm.ControlBox = false;
                scanForm.MinimizeBox = false;
                scanForm.MaximizeBox = false;

                scanForm.Show();
            }
            else
            {
                scanForm.Show();
                scanForm.Activate();
            }
        }



        private Form CheckForm(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private Form Check_OnlyOpen(Form form)
        {
            if (Application.OpenForms.OfType<Form>().Count() == 1)
                Application.OpenForms.OfType<Form>().First().Close();
            form = new Form();
            return form;
        }

        private void btnDeviceList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_DEVICE_LIST));
            if (frm == null)
            {
                FRM_DEVICE_LIST f = new FRM_DEVICE_LIST();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnDeviceRegistrationList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_DEVICE_REGISTER_LIST));
            if (frm == null)
            {
                FRM_DEVICE_REGISTER_LIST f = new FRM_DEVICE_REGISTER_LIST();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FRM_LOGIN f = new FRM_LOGIN();
            f.ShowDialog();

            // Kết quả login
            string statusLog = f.DataFromForm1;

            if (statusLog == "1")   // login OK
            {
                menuStrip1.Visible = true;
                btnLogin.Visible = false;

                // quyền đã được set trong FRM_LOGIN
                // Constaint._access đã có giá trị
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Constaint._access = "";
            FRM_MAIN_Load(this, EventArgs.Empty);
            btnLogin.Visible = true;
            menuStrip1.Visible = false;
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_USER_CHANGE_PASSWORD f = new FRM_USER_CHANGE_PASSWORD();
            f.ShowDialog();
        }

        private void btnLogOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            Constaint._access = "";
            FRM_MAIN_Load(this, EventArgs.Empty);
            btnLogin.Visible = true;
            menuStrip1.Visible = false;
        }

        private FRM_SCAN_QR scanForm;

        private void btnScanQR_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (scanForm == null || scanForm.IsDisposed)
            {
                scanForm = new FRM_SCAN_QR();
                scanForm.MdiParent = this;
                scanForm.Show();
            }
            else
            {
                scanForm.Show();
                scanForm.Activate();
            }
        }

        private void btnDeviceMaintenanceList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_DEVICE_MAINT_LIST));
            if (frm == null)
            {
                FRM_DEVICE_MAINT_LIST f = new FRM_DEVICE_MAINT_LIST();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnMailConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Constaint._access != "1")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FRM_MAIL_CONFIG f = new FRM_MAIL_CONFIG();
            f.ShowDialog();
        }

        private void btnSkillList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_USER_SKILL_LIST));
            if (frm == null)
            {
                FRM_USER_SKILL_LIST f = new FRM_USER_SKILL_LIST();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnDeviceDestroyRegistration_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_ADD_DEVICE_CANCEL_REGISTER));
            if (frm == null)
            {
                FRM_ADD_DEVICE_CANCEL_REGISTER f = new FRM_ADD_DEVICE_CANCEL_REGISTER();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnDeviceMaintenanceHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_DEVICE_MAINT_HISTORY_LIST));
            if (frm == null)
            {
                FRM_DEVICE_MAINT_HISTORY_LIST f = new FRM_DEVICE_MAINT_HISTORY_LIST();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnDeviceApproval_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_DEVICE_NEW_WAITING_APPROVE_LIST));
            if (frm == null)
            {
                FRM_DEVICE_NEW_WAITING_APPROVE_LIST f = new FRM_DEVICE_NEW_WAITING_APPROVE_LIST();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnDeviceRegistationHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_DEVICE_REGISTER_HISTORY_LIST));
            if (frm == null)
            {
                FRM_DEVICE_REGISTER_HISTORY_LIST f = new FRM_DEVICE_REGISTER_HISTORY_LIST();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Constaint._access != "1")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FRM_ACCOUNT_SKILL_MGMT f = new FRM_ACCOUNT_SKILL_MGMT();
            f.ShowDialog();
        }

        private void btnDeviceDestroyApproval_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            Form frm = CheckForm(typeof(FRM_DEVICE_CANCEL_REGISTER_LIST));
            if (frm == null)
            {
                FRM_DEVICE_CANCEL_REGISTER_LIST f = new FRM_DEVICE_CANCEL_REGISTER_LIST();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnDeviceDestroyHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_DEVICE_CANCEL_HISTORY));
            if (frm == null)
            {
                FRM_DEVICE_CANCEL_HISTORY f = new FRM_DEVICE_CANCEL_HISTORY();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btnDeviceType_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(FRM_DEVICE_TYPE_MST));
            if (frm == null)
            {
                FRM_DEVICE_TYPE_MST f = new FRM_DEVICE_TYPE_MST();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }
    }
}