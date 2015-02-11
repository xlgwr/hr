using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HR.Zip.API
{
    class apisharp
    {
        private static Regex RegEmail = new Regex("^[\\w-]+[.]?[\\w-]+@[\\w-]+\\.[\\w-]+[.]?[\\w-]+$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 

        public static string getClientIP()
        {
            IPAddress[] arrIPAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in arrIPAddresses)
            {
                if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                {
                    return ip.ToString();
                }
            }
            return "Nothing";
        }
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }
        public static void OpenFolderAndSelectFile(String fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + fileFullName;
            //psi.UseShellExecute = true;
            //psi.Verb = "open";
            System.Diagnostics.Process.Start(psi);
        }
        /// <summary>
        /// set toolstriptitem state bar
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="strMsg"></param>
        /// <param name="enable"></param>
        /// <param name="visible"></param>
        public static void setControlText<T>(T tform, System.Windows.Forms.ToolStripItem ctl, string strMsg, bool enable, bool visible)
        where T : Form
        {
            tform.Invoke(new Action(delegate
            {
                ctl.Text = strMsg;
                ctl.Enabled = enable;
                ctl.Visible = visible;
            }));

        }

        /// <summary>
        /// set control text
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="strMsg"></param>
        /// <param name="enable"></param>
        /// <param name="visible"></param>
        public static void setControlText<T>(T tform, System.Windows.Forms.Control ctl, bool enable, bool visible)
            where T : Form
        {
            tform.Invoke(new Action(delegate
            {
                ctl.Enabled = enable;
                ctl.Visible = visible;
            }));

        }
        /// <summary>
        /// set control text
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="strMsg"></param>
        /// <param name="enable"></param>
        /// <param name="visible"></param>
        public static void setControlText<T>(T tform, System.Windows.Forms.Control ctl, string strMsg, bool enable, bool visible)
            where T : Form
        {
            tform.Invoke(new Action(delegate
            {
                ctl.Text = strMsg;
                ctl.Enabled = enable;
                ctl.Visible = visible;
            }));

        }

    }
}
