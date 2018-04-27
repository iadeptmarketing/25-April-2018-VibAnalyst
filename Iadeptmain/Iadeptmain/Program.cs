using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using Iadeptmain;
using Iadeptmain.Mainforms;
using System.Threading;
using System.Globalization;

namespace Iadeptmain
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                //Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.UserSkins.BonusSkins.Register();
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
                Application.Run(new frmIAdeptMain());                
            }
            catch { }
        }
    }
}