using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;


using HR.Zip.API;
using System.IO;

namespace HR.Zip
{
    static class Program
    {

        public static IList<Outlook.ExchangeUser> _exuser;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _exuser = new List<Outlook.ExchangeUser>();

            Application.Run(new HRMain());
        }
    }
}
