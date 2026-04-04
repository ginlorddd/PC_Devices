using DevExpress.XtraBars;
using PC_Devices.DB;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PC_Devices.FRM
{
    public partial class FRM_MAIN : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly Dictionary<Type, Form> _openedForms = new Dictionary<Type, Form>();

        public FRM_MAIN()
        {
            InitializeComponent();
            btnAccount.Enabled = Constaint.IsAdmin() || Constaint.HasRole("ACCOUNT_MGMT");
            btnDieMaster.Enabled = Constaint.IsAdmin() || Constaint.HasRole("DIE_MST_MGMT");
        }

        private void OpenChild<T>() where T : Form, new()
        {
            Type key = typeof(T);
            if (_openedForms.ContainsKey(key) && !_openedForms[key].IsDisposed)
            {
                _openedForms[key].Activate();
                return;
            }

            T frm = new T();
            frm.MdiParent = this;
            frm.FormClosed += (s, e) => _openedForms.Remove(key);
            _openedForms[key] = frm;
            frm.Show();
        }

        private void btnDieMaster_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenChild<FRM_DIE_MASTER>();
        }

        private void btnAccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenChild<FRM_ACCOUNT_MANAGEMENT>();
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenChild<FRM_CHANGE_PASSWORD>();
        }
    }
}
