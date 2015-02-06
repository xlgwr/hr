using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HR.Zip.API;
using System.IO;

namespace HR.Zip
{
    public partial class HRMain : Form
    {
        apioutlook apiol;
        apiZip apizip;

        public HRMain()
        {
            InitializeComponent();

            txt3Addtchedfilepath.ReadOnly = true;
            //
            apiol = new apioutlook();
            apizip = new apiZip();
        }

        private void btn1Files_Click(object sender, EventArgs e)
        {
            txt3Addtchedfilepath.Text = apiol.getfilepath();
        }

        private void btn0Send_Click(object sender, EventArgs e)
        {
            #region check
            if (string.IsNullOrEmpty(txt0To.Text))
            {
                txt0To.Focus();
                tool0Msg.Text = "Notice: 请输入收件人.";
                return;
            }
            if (string.IsNullOrEmpty(txt1ToCC.Text))
            {
                txt1ToCC.Focus();
                tool0Msg.Text = "Notice: 请输入抄送人.";
                return;
            }
            if (string.IsNullOrEmpty(txt2Subject.Text))
            {
                txt2Subject.Focus();
                tool0Msg.Text = "Notice: 请输入主题.";
                return;
            }
            if (string.IsNullOrEmpty(txt3Addtchedfilepath.Text))
            {
                btn1Files.Focus();
                tool0Msg.Text = "Notice: 请设置附件文件夹.";
                return;
            }
            #endregion


            #region dotnetzip sample password

            var tmpfiles = txt3Addtchedfilepath.Text.Trim();
            List<string> filelist_al = new List<string>();
            var tmpfilesZip = tmpfiles + @"Zip\";

            DirectoryInfo thisdir = new DirectoryInfo(tmpfiles);
            FileInfo[] filelist = thisdir.GetFiles();

            if (!Directory.Exists(tmpfilesZip))
            {
                Directory.CreateDirectory(tmpfilesZip);
            }
            
            foreach (FileInfo item in filelist)
            {
                if (item.Extension.Equals(".zip"))
                {
                    continue;
                }
                //filelist_al.Add(item.FullName.ToString());

                var tmpitemzip = tmpfilesZip + item.Name + ".zip";
                apizip.CompressFilesWithZip(item.FullName, tmpitemzip, "110", "doc");
            }
            #endregion
        }
    }
}
