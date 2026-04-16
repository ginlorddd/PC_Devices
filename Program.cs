using DevExpress.Skins;
using DevExpress.UserSkins;
using JigFlow.Data;
using JigFlow.Forms;
using System;
using System.Windows.Forms;

namespace JigFlow
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DbUtils.SetDataInit();
            Application.Run(new FrmMain());
        }
    }
}
