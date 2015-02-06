using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HR.Zip.API;

namespace HR.Zip
{
    public partial class GetEmailfrm<T> : Form
    {

        apioutlook apiol;
        T _userform;
        TextBox _tb;
        int _getflag;
        bool _isappend;

        public GetEmailfrm()
        {
            InitializeComponent();

            initset();
        }

        private void GetEmailfrm_Load(object sender, EventArgs e)
        {

        }
        public GetEmailfrm(T userform, TextBox tb, int getflag, bool isappend)
        {
            InitializeComponent();

            _userform = userform;
            _tb = tb;
            _getflag = getflag;
            _isappend = isappend;
            //
            initset();


        }
        void initset()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point { X = Control.MousePosition.X - this.Width / 3, Y = Control.MousePosition.Y + 25 };
            this.Resize += GetEmailfrm_Resize;
            this.AcceptButton = button1;
            //
            apiol = new apioutlook();

            dataGridView1.Columns.Add("name", "Name");
            dataGridView1.Columns.Add("email", "Email");

            dataGridView1.Rows.Clear();
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.CellClick += dataGridView1_CellClick;

            if (Program._exuser.Count <= 0)
            {
                apiol.dgvaddEmailUsernameByExchange();
            }
            foreach (var item in Program._exuser)
            {
                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.CreateCells(dataGridView1);
                dgvr.Cells[0].Value = item.Name;
                dgvr.Cells[1].Value = item.PrimarySmtpAddress;
                dataGridView1.Rows.Add(dgvr);
            }
            dataGridView1.Refresh();
            this.Text = "Email,Count:" + dataGridView1.RowCount;

        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                initSetTxt(e.RowIndex);
            }
            //throw new NotImplementedException();
        }

        void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            //throw new NotImplementedException();
        }

        void GetEmailfrm_Resize(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width - 5;
            dataGridView1.Height = this.Height - dataGridView1.Top - 30;
            //throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString().StartsWith(textBox1.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        dataGridView1.Rows[i].Cells[0].Selected = true;
                        _dgvCurrRow = i;
                        break;
                    }
                }
            }
        }

        public int _dgvCurrRow { get; set; }

        void initSetTxt(int xindex)
        {
            _dgvCurrRow = xindex;
            if (_dgvCurrRow > -1 && _dgvCurrRow < dataGridView1.RowCount)
            {
                if (_isappend)
                {
                    if (string.IsNullOrWhiteSpace(_tb.Text))
                    {
                        _tb.Text = dataGridView1.Rows[_dgvCurrRow].Cells[_getflag].Value.ToString();
                    }
                    else
                    {

                        _tb.Text += ";" + dataGridView1.Rows[_dgvCurrRow].Cells[_getflag].Value.ToString();
                    }
                }
                else
                {
                    _tb.Text = dataGridView1.Rows[_dgvCurrRow].Cells[_getflag].Value.ToString();
                }
            }
        }
    }
}
