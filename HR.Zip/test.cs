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

namespace HR.Zip
{
    public partial class test : Form
    {
        apioutlook apiol;
        public test()
        {
           

            InitializeComponent();

            apiol = new apioutlook();

            dataGridView1.Columns.Add("name", "Name");
            dataGridView1.Columns.Add("email", "Email");

            apiol.cbinitAddLists(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tmpfilepath = new string[]{
                        AppDomain.CurrentDomain.BaseDirectory + @"\attach\test.txt",
                        AppDomain.CurrentDomain.BaseDirectory + @"\attach\test.zip"
            };
            apiol.sendmail("Ling.Xie@wehc.com.cn", "Ling.Xie@wehc.com.cn", " a test from client", "This is a test, It should work.....", tmpfilepath, "OK");

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                dataGridView1.Rows.Clear();
                apiol.dgvAddEmailUsername(dataGridView1, comboBox1.SelectedItem.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            apiol.dgvGetSMTPAddressForRecipients(dataGridView1);
        }

        private void test_Load(object sender, EventArgs e)
        {

        }
    }
}
