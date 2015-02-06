using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HR.Zip.EF;
using HR.Zip.API;

namespace HR.Zip
{
    public partial class UserFrm : Form
    {
        HR_Zip _hrzip;
        public UserFrm()
        {
            InitializeComponent();

            _dgvCurrRow = -1;
            _hrzip = new HR_Zip();

            this.AcceptButton = btn0Save;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += UserFrm_Resize;
            dataGridView1.CellClick += dataGridView1_CellClick;
            initwith();
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            initDGV(true, 50);
        }
        private void UserFrm_Load(object sender, EventArgs e)
        {

        }

        void UserFrm_Resize(object sender, EventArgs e)
        {
            initwith();
        }
        void initwith()
        {
            groupBox1.Width = this.Width - 35;

            dataGridView1.Width = groupBox1.Width;
            dataGridView1.Height = this.Height - dataGridView1.Top - 60;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (_hrzip != null)
            {
                _hrzip.Dispose();
            }
            base.OnClosing(e);
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _dgvCurrRow = e.RowIndex;
                txt0UserID.Enabled = false;
                txt0UserID.ReadOnly = false;

                var tmpuser = _tmplist[e.RowIndex];
                initToTxt(tmpuser);
                this.AcceptButton = btn0Passwd;
            }
            //throw new NotImplementedException();
        }
        void initToTxt(user_mstr model)
        {
            txt0UserID.Text = model.userID;
            txt1UserName.Text = model.name;
            txt2Email.Text = model.email;
            txt3PassWd.Text = model.password;

        }
        bool checktxt(TextBox tb, string msg)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Focus();
                this.Invoke(new Action(delegate()
                {
                    tool0Msg.Text = "Notice: " + msg + " is Nothing";
                }));
                return false;
            }
            return true;
        }
        bool initChectTXT()
        {
            if (!checktxt(txt0UserID, "用户ID"))
            {
                return false;
            }
            if (!checktxt(txt1UserName, "用户名"))
            {
                return false;
            }
            if (!checktxt(txt2Email, "Email"))
            {
                return false;
            }
            if (!apisharp.IsEmail(txt2Email.Text))
            {
                txt2Email.Focus();
                tool0Msg.Text = "请输入正确的邮件格式(XX@XX.com|net|cn|org|edu|mil|tv|biz|info)";
                return false;
            }
            if (!checktxt(txt3PassWd, "解压密码"))
            {
                return false;
            }
            return true;
        }
        private void btn0Save_Click(object sender, EventArgs e)
        {
            try
            {
                #region  checkthat
                if (!initChectTXT())
                {
                    return;
                }

                //check exist
                var tmpUserIDexit = _hrzip.user_mstr.Where(p => p.userID.Equals(txt0UserID.Text.Trim())).SingleOrDefault();

                if (tmpUserIDexit != null)
                {
                    txt0UserID.Focus();
                    tool0Msg.Text = txt0UserID.Text + " 已使用...(Error 1)";
                    return;
                }
                var tmpEmailexit = _hrzip.user_mstr.Where(p => p.email.Equals(txt2Email.Text.Trim())).SingleOrDefault();

                if (tmpEmailexit != null)
                {
                    txt2Email.Focus();
                    tool0Msg.Text = txt2Email.Text + " 已使用...(Error 2)";
                    return;
                }

                #endregion
                this.Invoke(new Action(delegate()
               {
                   tool0Msg.Text = "保存中...";
               }));

                btn0Save.Enabled = false;
                user_mstr tmpusermstr = new user_mstr();
                var tmpcount = _hrzip.user_mstr.Count();
                if (tmpcount <= 0)
                {
                    tmpusermstr.Tid = 1;
                }
                else
                {
                    tmpusermstr.Tid = _hrzip.user_mstr.Max(p => p.Tid) + 1;
                }
                tmpusermstr.comp = "WEC";
                tmpusermstr.userID = txt0UserID.Text.Trim();
                tmpusermstr.name = txt1UserName.Text.Trim();
                tmpusermstr.email = txt2Email.Text.Trim();
                tmpusermstr.password = txt3PassWd.Text.Trim();

                tmpusermstr.clientIP = apisharp.getClientIP();
                tmpusermstr.updateDate = DateTime.Now;
                _hrzip.user_mstr.Add(tmpusermstr);
                var saveflag = _hrzip.SaveChanges();

                this.Invoke(new Action(delegate()
           {
               if (saveflag > 0)
               {
                   txt6SearchByUserID.Text = txt0UserID.Text.Trim();
                   btn0Search_Click(sender, e);
                   tool0Msg.Text = "Save Success: " + txt0UserID.Text;
               }
               else
               {
                   tool0Msg.Text = "Save fail: " + txt0UserID.Text; ;
               }
           }));
                btn0Save.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tool0Msg.Text = ex.Message;
                btn0Save.Enabled = true;
            }
        }

        #region acceptbutton

        private void txt6SearchByUserID_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btn0Search;
        }

        private void txt0UserID_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btn0Save;
        }

        private void txt1UserName_TextChanged(object sender, EventArgs e)
        {
            //this.AcceptButton = btn0Save;
        }

        private void txt2Email_TextChanged(object sender, EventArgs e)
        {
            //this.AcceptButton = btn0Save;
        }

        private void txt3PassWd_TextChanged(object sender, EventArgs e)
        {
            //this.AcceptButton = btn0Save;
        }
        #endregion

        private void btn0Search_Click(object sender, EventArgs e)
        {
            _dgvCurrRow = -1;
            if (!checktxt(txt6SearchByUserID, "UserID"))
            {
                return;
            }

            btn0Search.Enabled = false;
            this.Invoke(new Action(delegate()
            {
                tool0Msg.Text = "开始查找 " + txt6SearchByUserID.Text.Trim();
            }));

            initDGV(false, 10);
            btn0Search.Enabled = true;
        }
        void initDGV(bool isall, int topint)
        {
            if (isall)
            {
                if (topint > 0)
                {
                    _tmplist = _hrzip.user_mstr.Take(topint).ToList();
                }
                else
                {
                    _tmplist = _hrzip.user_mstr.ToList();
                }
            }
            else
            {
                _tmplist = _hrzip.user_mstr.Take(topint).Where(p => p.userID.StartsWith(txt6SearchByUserID.Text.Trim())).ToList();
            }
            var tmpfrom = from u in _tmplist
                          select new user_mstrView
                          {
                              name = u.name,
                              userID = u.userID,
                              email = u.email,
                              updateDate = u.updateDate,
                              clientIP = u.clientIP
                          };

            dataGridView1.DataSource = tmpfrom.ToList();
            dataGridView1.Refresh();
            tool0Msg.Text = "查找完成...总计:" + _tmplist.Count;

            if (_dgvCurrRow > 0)
            {
                dataGridView1.Rows[_dgvCurrRow].Cells[0].Selected = true;
            }
        }

        private void btn1New_Click(object sender, EventArgs e)
        {
            txt0UserID.Text = "";
            txt1UserName.Text = "";
            txt2Email.Text = "";
            txt3PassWd.Text = "";

            txt0UserID.Enabled = true;
            txt1UserName.Enabled = true;
            txt2Email.Enabled = true;
            txt3PassWd.Enabled = true;

            txt0UserID.Focus();
            tool0Msg.Text = "开始新增.";
        }

        private void btn0Passwd_Click(object sender, EventArgs e)
        {
            if (!initChectTXT())
            {
                return;
            }
            if (!string.IsNullOrEmpty(txt0UserID.Text))
            {
                tool0Msg.Text = "";
                if (MessageBox.Show("确定要修改:" + txt0UserID.Text, "Notice", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                if (!string.IsNullOrEmpty(txt0UserID.Text))
                {
                    var tmpuseid = _hrzip.user_mstr.Where(p => p.userID.Equals(txt0UserID.Text.Trim())).SingleOrDefault();
                    if (tmpuseid != null)
                    {
                        tmpuseid.name = txt1UserName.Text.Trim();
                        tmpuseid.email = txt2Email.Text.Trim();
                        tmpuseid.password = txt3PassWd.Text.Trim();

                        var saveflag = _hrzip.SaveChanges();
                        if (saveflag > 0)
                        {
                            if (checkBox1.Enabled)
                            {
                                initDGV(true, 0);
                            }
                            else
                            {
                                txt6SearchByUserID.Text = txt0UserID.Text.Trim();
                                btn0Search_Click(sender, e);
                            }
                            tool0Msg.Text = txt0UserID.Text + " 修改成功(Success).";
                        }
                    }
                    else
                    {
                        tool0Msg.Text = txt0UserID.Text + " is not exists(Error).";
                    }
                }
            }
        }

        public List<user_mstr> _tmplist { get; set; }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _dgvCurrRow = -1;
            try
            {
                if (checkBox1.Checked)
                {
                    checkBox1.Enabled = false;
                    initDGV(true, 0);
                    checkBox1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                checkBox1.Enabled = true;
            }

        }

        public int _dgvCurrRow { get; set; }

        private void btn0Del_Click(object sender, EventArgs e)
        {
            _dgvCurrRow = -1;
            if (!string.IsNullOrEmpty(txt0UserID.Text))
            {
                tool0Msg.Text = "";
                if (MessageBox.Show("确定要删除: " + txt0UserID.Text + ",Email:" + txt2Email.Text, "Notice", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                if (!string.IsNullOrEmpty(txt0UserID.Text))
                {
                    var tmpuseid = _hrzip.user_mstr.Where(p => p.userID.Equals(txt0UserID.Text.Trim())).SingleOrDefault();
                    if (tmpuseid != null)
                    {
                        var dd = _hrzip.user_mstr.Remove(tmpuseid);

                        var saveflag = _hrzip.SaveChanges();
                        if (saveflag > 0)
                        {
                            if (checkBox1.Enabled)
                            {
                                initDGV(true, 0);
                            }
                            else
                            {
                                txt6SearchByUserID.Text = txt0UserID.Text.Trim();
                                btn0Search_Click(sender, e);
                            }
                            tool0Msg.Text = tmpuseid.userID + " 删除成功(Success).";
                        }
                    }
                    else
                    {
                        tool0Msg.Text = txt0UserID.Text + " 早已删除(Error).";
                    }
                }
            }

        }

        private void btn0GetEmail_Click(object sender, EventArgs e)
        {
            GetEmailfrm<UserFrm> gef = new GetEmailfrm<UserFrm>(this, txt2Email, 1, false);
            gef.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetEmailfrm<UserFrm> gef = new GetEmailfrm<UserFrm>(this, txt1UserName, 0, false);
            gef.ShowDialog();
        }
    }
}
