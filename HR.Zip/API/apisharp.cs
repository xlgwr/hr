using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

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
    }
}
