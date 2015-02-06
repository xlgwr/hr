namespace HR.Zip
{
    partial class UserFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserFrm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn0GetEmail = new System.Windows.Forms.Button();
            this.btn0Del = new System.Windows.Forms.Button();
            this.btn0Passwd = new System.Windows.Forms.Button();
            this.btn1New = new System.Windows.Forms.Button();
            this.btn0Save = new System.Windows.Forms.Button();
            this.txt3PassWd = new System.Windows.Forms.TextBox();
            this.txt2Email = new System.Windows.Forms.TextBox();
            this.txt1UserName = new System.Windows.Forms.TextBox();
            this.txt0UserID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt6SearchByUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn0Search = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tool0Msg = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btn0GetEmail);
            this.groupBox1.Controls.Add(this.btn0Del);
            this.groupBox1.Controls.Add(this.btn0Passwd);
            this.groupBox1.Controls.Add(this.btn1New);
            this.groupBox1.Controls.Add(this.btn0Save);
            this.groupBox1.Controls.Add(this.txt3PassWd);
            this.groupBox1.Controls.Add(this.txt2Email);
            this.groupBox1.Controls.Add(this.txt1UserName);
            this.groupBox1.Controls.Add(this.txt0UserID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 164);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(249, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn0GetEmail
            // 
            this.btn0GetEmail.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn0GetEmail.Location = new System.Drawing.Point(249, 91);
            this.btn0GetEmail.Name = "btn0GetEmail";
            this.btn0GetEmail.Size = new System.Drawing.Size(21, 23);
            this.btn0GetEmail.TabIndex = 2;
            this.btn0GetEmail.Text = ">";
            this.btn0GetEmail.UseVisualStyleBackColor = true;
            this.btn0GetEmail.Click += new System.EventHandler(this.btn0GetEmail_Click);
            // 
            // btn0Del
            // 
            this.btn0Del.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn0Del.ForeColor = System.Drawing.Color.Red;
            this.btn0Del.Location = new System.Drawing.Point(6, 22);
            this.btn0Del.Name = "btn0Del";
            this.btn0Del.Size = new System.Drawing.Size(40, 23);
            this.btn0Del.TabIndex = 8;
            this.btn0Del.Text = "删除";
            this.btn0Del.UseVisualStyleBackColor = true;
            this.btn0Del.Click += new System.EventHandler(this.btn0Del_Click);
            // 
            // btn0Passwd
            // 
            this.btn0Passwd.Location = new System.Drawing.Point(282, 124);
            this.btn0Passwd.Name = "btn0Passwd";
            this.btn0Passwd.Size = new System.Drawing.Size(127, 23);
            this.btn0Passwd.TabIndex = 7;
            this.btn0Passwd.Text = "修改(&E)";
            this.btn0Passwd.UseVisualStyleBackColor = true;
            this.btn0Passwd.Click += new System.EventHandler(this.btn0Passwd_Click);
            // 
            // btn1New
            // 
            this.btn1New.Location = new System.Drawing.Point(282, 22);
            this.btn1New.Name = "btn1New";
            this.btn1New.Size = new System.Drawing.Size(127, 23);
            this.btn1New.TabIndex = 7;
            this.btn1New.Text = "New(&N)";
            this.btn1New.UseVisualStyleBackColor = true;
            this.btn1New.Click += new System.EventHandler(this.btn1New_Click);
            // 
            // btn0Save
            // 
            this.btn0Save.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn0Save.Location = new System.Drawing.Point(282, 58);
            this.btn0Save.Name = "btn0Save";
            this.btn0Save.Size = new System.Drawing.Size(127, 55);
            this.btn0Save.TabIndex = 4;
            this.btn0Save.Text = "保存(&S)";
            this.btn0Save.UseVisualStyleBackColor = true;
            this.btn0Save.Click += new System.EventHandler(this.btn0Save_Click);
            // 
            // txt3PassWd
            // 
            this.txt3PassWd.Location = new System.Drawing.Point(96, 125);
            this.txt3PassWd.Name = "txt3PassWd";
            this.txt3PassWd.PasswordChar = '*';
            this.txt3PassWd.Size = new System.Drawing.Size(172, 21);
            this.txt3PassWd.TabIndex = 3;
            this.txt3PassWd.TextChanged += new System.EventHandler(this.txt3PassWd_TextChanged);
            // 
            // txt2Email
            // 
            this.txt2Email.Location = new System.Drawing.Point(96, 92);
            this.txt2Email.Multiline = true;
            this.txt2Email.Name = "txt2Email";
            this.txt2Email.Size = new System.Drawing.Size(153, 21);
            this.txt2Email.TabIndex = 2;
            this.txt2Email.TextChanged += new System.EventHandler(this.txt2Email_TextChanged);
            // 
            // txt1UserName
            // 
            this.txt1UserName.Location = new System.Drawing.Point(96, 58);
            this.txt1UserName.Multiline = true;
            this.txt1UserName.Name = "txt1UserName";
            this.txt1UserName.Size = new System.Drawing.Size(153, 21);
            this.txt1UserName.TabIndex = 1;
            this.txt1UserName.TextChanged += new System.EventHandler(this.txt1UserName_TextChanged);
            // 
            // txt0UserID
            // 
            this.txt0UserID.Location = new System.Drawing.Point(96, 23);
            this.txt0UserID.Multiline = true;
            this.txt0UserID.Name = "txt0UserID";
            this.txt0UserID.Size = new System.Drawing.Size(172, 21);
            this.txt0UserID.TabIndex = 0;
            this.txt0UserID.TextChanged += new System.EventHandler(this.txt0UserID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "附件解压Passwd:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "用户ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 208);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(430, 246);
            this.dataGridView1.TabIndex = 7;
            // 
            // txt6SearchByUserID
            // 
            this.txt6SearchByUserID.Location = new System.Drawing.Point(110, 179);
            this.txt6SearchByUserID.Name = "txt6SearchByUserID";
            this.txt6SearchByUserID.Size = new System.Drawing.Size(172, 21);
            this.txt6SearchByUserID.TabIndex = 5;
            this.txt6SearchByUserID.TextChanged += new System.EventHandler(this.txt6SearchByUserID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "UserID:";
            // 
            // btn0Search
            // 
            this.btn0Search.Location = new System.Drawing.Point(294, 177);
            this.btn0Search.Name = "btn0Search";
            this.btn0Search.Size = new System.Drawing.Size(79, 23);
            this.btn0Search.TabIndex = 6;
            this.btn0Search.Text = "Find(&F)";
            this.btn0Search.UseVisualStyleBackColor = true;
            this.btn0Search.Click += new System.EventHandler(this.btn0Search_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool0Msg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(453, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tool0Msg
            // 
            this.tool0Msg.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
            this.tool0Msg.ForeColor = System.Drawing.Color.Red;
            this.tool0Msg.Name = "tool0Msg";
            this.tool0Msg.Size = new System.Drawing.Size(0, 17);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(399, 180);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(42, 16);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // UserFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 479);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn0Search);
            this.Controls.Add(this.txt6SearchByUserID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserFrm";
            this.Text = "User Main";
            this.Load += new System.EventHandler(this.UserFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn0Save;
        private System.Windows.Forms.TextBox txt3PassWd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt0UserID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt6SearchByUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn0Search;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        protected internal System.Windows.Forms.ToolStripStatusLabel tool0Msg;
        private System.Windows.Forms.Button btn1New;
        private System.Windows.Forms.Button btn0Passwd;
        private System.Windows.Forms.Button btn0Del;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn0GetEmail;
        private System.Windows.Forms.Button button1;
        protected internal System.Windows.Forms.TextBox txt1UserName;
        protected internal System.Windows.Forms.TextBox txt2Email;
    }
}