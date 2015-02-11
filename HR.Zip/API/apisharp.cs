using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;

namespace HR.Zip.API
{
    class apisharp
    {
        private static Regex RegEmail = new Regex("^[\\w-]+[.]?[\\w-]+@[\\w-]+\\.[\\w-]+[.]?[\\w-]+$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 

        //////////////////////////////////add new

        public static HSSFWorkbook hssfworkbook_xls { get; set; }
        public static XSSFWorkbook xssfworkbook_xlsx { get; set; }
        public static string currmsg { get; set; }

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
                ctl.Visible = visible;
                ctl.Enabled = enable;
                if (enable)
                {
                    ctl.Focus();
                }
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
                ctl.Enabled = enable;
                ctl.Visible = visible;
                ctl.Text = strMsg;
            }));

        }
        /// <summary>
        /// dgv true: rowcount,false: column count
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="isRowCount">true: rowcount,false: column count</param>
        /// <returns></returns>
        public static int getControlInt<T>(T tform, DataGridView dgv, bool isRowCount)
            where T : Form
        {
            int tmpText = 0;
            tform.Invoke(new Action(delegate
             {
                 if (isRowCount)
                 {
                     tmpText = dgv.Rows.Count;
                 }
                 else
                 {
                     tmpText = dgv.ColumnCount;
                 }
             }));
            return tmpText;
        }
        public static string getControlText<T>(T tform, Control ctl)
                 where T : Form
        {
            string tmpText = "";
            tform.Invoke(new Action(delegate
            {
                tmpText = ctl.Text;
            }));
            return tmpText;
        }
        public static object getControlText<T>(T tform, DataGridView dgv, int xindex, int yxindex)
                 where T : Form
        {
            object tmpText = null;
            tform.Invoke(new Action(delegate
            {
                tmpText = dgv.Rows[xindex].Cells[yxindex].Value;
            }));
            return tmpText;
        }
        public static string getControlText<T>(T tform, DataGridView dgv, int yindex)
            where T : Form
        {
            string tmpText = "";
            tform.Invoke(new Action(delegate
            {
                tmpText = dgv.Columns[yindex].HeaderText;
            }));
            return tmpText;
        }
        /// <summary>
        /// DataGridView dgv, string xlsType, string filenamePrefix, string filepath,bool autoOpen
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="xlsType"></param>
        /// <param name="filenamePrefix"></param>
        /// <param name="filepath"></param>
        public static void downLoadExcel<T>(object o)
            where T : Form
        {

            var dwo = (DgvObject<T>)o;
            try
            {
                currmsg = "Start init excel file name and path.";
                setControlText(dwo._tform, dwo._cl, currmsg, true, true);

                xssfworkbook_xlsx = new XSSFWorkbook();

                string filename = dwo._filenamePrefix + "_" + DateTime.Now.ToString("yyMMddHHmmssff") + ".xlsx";//yyyyMMddHHmmssff

                if (string.IsNullOrEmpty(dwo._filepath))
                {
                    dwo._filepath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"0DownLoadExcel";

                }
                if (!Directory.Exists(dwo._filepath))
                {
                    Directory.CreateDirectory(dwo._filepath);
                }
                string tmpAllFilepathAndName = System.IO.Path.Combine(dwo._filepath, filename);



                ISheet sheet1 = xssfworkbook_xlsx.CreateSheet(filename);

                int tmpColumnsCount = getControlInt(dwo._tform, dwo._dgv, false);//dwo._dgv.Columns.Count;
                int tmpRowsCount = getControlInt(dwo._tform, dwo._dgv, true);// dwo._dgv.Rows.Count;

                currmsg = "Start create excel file,it has Rows:" + tmpRowsCount + ",Columns:" + tmpColumnsCount;
                setControlText(dwo._tform, dwo._cl, currmsg, true, true);

                int x = 1;
                IRow rowHeader = sheet1.CreateRow(0);
                for (int i = 0; i < tmpColumnsCount; i++)
                {
                    var tmpHeadText = getControlText(dwo._tform, dwo._dgv, i);//dwo._dgv.Columns[i].HeaderText;
                    if (tmpHeadText == null)
                    {
                        tmpHeadText = x++.ToString();
                    }
                    currmsg = "Start write Header text at:" + (i + 1) + ", value:" + tmpHeadText.ToString();
                    setControlText(dwo._tform, dwo._cl, currmsg, true, true);

                    rowHeader.CreateCell(i).SetCellValue(tmpHeadText.ToString());
                }

                for (int i = 1; i <= tmpRowsCount; i++)
                {
                    IRow row = sheet1.CreateRow(i);
                    for (int j = 0; j < tmpColumnsCount; j++)
                    {
                        var tmpCellValue = getControlText(dwo._tform, dwo._dgv, i - 1, j);// dwo._dgv.Rows[i - 1].Cells[j].Value;

                        if (tmpCellValue == null)
                        {
                            tmpCellValue = "";
                        }

                        if (tmpCellValue.GetType() == System.TypeCode.String.GetType())
                        {
                            row.CreateCell(j).SetCellValue(tmpCellValue.ToString());
                        }
                        else if (tmpCellValue.GetType() == System.TypeCode.Decimal.GetType())
                        {
                            var tmpCellValue_convert = Convert.ToDouble(tmpCellValue);
                            row.CreateCell(j).SetCellValue(tmpCellValue_convert);
                        }
                        else if (tmpCellValue.GetType() == System.TypeCode.Double.GetType())
                        {
                            var tmpCellValue_convert = Convert.ToDouble(tmpCellValue);
                            row.CreateCell(j).SetCellValue(tmpCellValue_convert);
                        }
                        else if (tmpCellValue.GetType() == System.TypeCode.DateTime.GetType())
                        {
                            var tmpCellValue_convert = Convert.ToDateTime(tmpCellValue);
                            row.CreateCell(j).SetCellValue(tmpCellValue_convert);
                        }
                        else
                        {
                            row.CreateCell(j).SetCellValue(tmpCellValue.ToString());
                        }

                        currmsg = "That has Rows:" + tmpRowsCount + ",Columns:" + tmpColumnsCount + ",Start write at Rows:" + (i + 1) + ",Columns:" + (j + 1) + ",Value:" + tmpCellValue.ToString();
                        setControlText(dwo._tform, dwo._cl, currmsg, true, true);

                    }
                }
                using (var f = File.Create(@tmpAllFilepathAndName))
                {
                    currmsg = "Start save Excel file to " + tmpAllFilepathAndName;
                    setControlText(dwo._tform, dwo._cl, currmsg, true, true);
                    xssfworkbook_xlsx.Write(f);
                    currmsg = "Success: save Excel file to " + tmpAllFilepathAndName;
                    setControlText(dwo._tform, dwo._cl, currmsg, true, true);
                }
                if (dwo._autoOpen)
                {
                    OpenFolderAndSelectFile(tmpAllFilepathAndName);
                }
            }
            catch (Exception ex)
            {

                currmsg = "Error:" + ex.Message;
                setControlText(dwo._tform, dwo._cl, currmsg, true, true);
            }

        }
        public static void downLoadExcel_Thread<T>(object o)
            where T : Form
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(downLoadExcel<T>), o);
        }

    }
}
