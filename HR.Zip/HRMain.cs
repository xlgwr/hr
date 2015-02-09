using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

using HR.Zip.API;
using HR.Zip.EF;
using System.IO;

namespace HR.Zip
{
    public partial class HRMain : Form
    {
        apioutlook apiol;
        apiZip apizip;
        IList<user_mstr> _guserMstrList;
        IList<savezipfile> _gzipfilepath;
        HR_Zip _hrzip;
        public HRMain()
        {
            InitializeComponent();

            txt3Addtchedfilepath.ReadOnly = true;
            //
            apiol = new apioutlook();
            apizip = new apiZip();
            _hrzip = new HR_Zip();
            _guserMstrList = new List<user_mstr>();
            _gzipfilepath = new List<savezipfile>();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (_hrzip != null)
            {
                _hrzip.Dispose();
            }
            base.OnClosing(e);
        }
        private void btn1Files_Click(object sender, EventArgs e)
        {
            txt3Addtchedfilepath.Text = apiol.getfilepath();
        }

        private void btn0Send_Click(object sender, EventArgs e)
        {
            _guserMstrList = new List<user_mstr>();
            _gzipfilepath = new List<savezipfile>();
            var tmpmsg = "";
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

            var tmpOemail = txt0To.Text.Trim().Split(';');

            if (tmpOemail.Count() < 0)
            {
                txt0To.Focus();
                return;
            }
            tmpmsg = "开始发送.";
            tool0Msg.Text = tmpmsg;
            btn0Send.Enabled = false;
            foreach (var item in tmpOemail)
            {
                var tmpuser = _hrzip.user_mstr.Where(p => p.email.Equals(item.Trim())).SingleOrDefault();
                if (tmpuser != null)
                {
                    _guserMstrList.Add(tmpuser);
                }
            }
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
            //init 

            foreach (FileInfo item in filelist)
            {
                if (item.Extension.Equals(".zip"))
                {
                    continue;
                }
                foreach (var userid in _guserMstrList)
                {
                    var fileuserid = item.Name.Split('.')[0].Split('-')[0];
                    if (fileuserid.Equals(userid.userID))
                    {
                        var tmpitemzip = tmpfilesZip + userid.userID + ".zip";

                        var sf = apizip.CompressFilesWithZip(item.FullName, tmpitemzip, userid.password, userid.userID);
                        if (sf)
                        {
                            _gzipfilepath.Add(new savezipfile(userid.userID, tmpitemzip));
                            //send mail
                            var tmpfilepath = new string[] { tmpitemzip };
                            tmpmsg = "正在发送: " + userid.userID + "," + userid.name + "," + userid.email + " 的邮件.";
                            tool0Msg.Text = tmpmsg;
                            apiol.sendmail(userid.email, txt1ToCC.Text, txt2Subject.Text, txt5Body.Text, tmpfilepath, "Ok");
                        }
                    }
                }
                //filelist_al.Add(item.FullName.ToString());

            }
            tmpmsg = "发送完成.";
            tool0Msg.Text = tmpmsg;
            MessageBox.Show(tmpmsg);
            btn0Send.Enabled = true;
            #endregion
        }
        void initwith()
        {
            groupBox1.Width = this.Width - 35;

            txt5Body.Width = groupBox1.Width;
            txt5Body.Height = this.Height - txt5Body.Top - 60;

            txt0To.Width = this.Width - txt0To.Left - 38;
            txt1ToCC.Width = txt0To.Width;
            txt2Subject.Width = txt0To.Width;
            txt3Addtchedfilepath.Width = txt0To.Width - btn1Files.Width - 10;
            btn1Files.Left = txt3Addtchedfilepath.Width + txt3Addtchedfilepath.Left + 5;

        }
        private void HRMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            initwith();
        }

        private void HRMain_Resize(object sender, EventArgs e)
        {
            initwith();
        }

        private void userUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userfrm = new UserFrm();
            //userfrm.Show();
            userfrm.ShowDialog();
            tool0Msg.Text = "打开用户管理Success";
        }

        private void lk0To_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetEmailfrm<HRMain> gef = new GetEmailfrm<HRMain>(this, txt0To, 1, true);
            gef.ShowDialog();
        }

        private void lk2ccTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetEmailfrm<HRMain> gef = new GetEmailfrm<HRMain>(this, txt1ToCC, 1, true);
            gef.ShowDialog();
        }
    }
    class savezipfile
    {
        public savezipfile(string userid, string filepathzip)
        {
            _userid = userid;
            _filepathzip = filepathzip;
        }

        public string _filepathzip { get; set; }

        public string _userid { get; set; }
    }
}
