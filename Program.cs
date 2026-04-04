using System;
using System.Windows.Forms;

namespace DM_OHD
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DB.DBUtils.SetDataInit();
            Application.Run(new FRM.FRM_LOGIN());
        }
    }
}
