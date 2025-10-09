using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BSE.Platten.Tunes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string strCulture = "en-US";
            System.Globalization.CultureInfo selectedCulture = new System.Globalization.CultureInfo(strCulture);
            System.Threading.Thread.CurrentThread.CurrentCulture = selectedCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = selectedCulture;
            
            Application.Run(new Tunes());
            //Application.Run(new Desktop());
        }
    }
}