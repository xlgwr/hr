namespace HR.Zip
{
    partial class HRMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn1Files = new System.Windows.Forms.Button();
            this.btn0Send = new System.Windows.Forms.Button();
            this.txt3Addtchedfilepath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt2Subject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt1ToCC = new System.Windows.Forms.TextBox();
            this.txt0To = new System.Windows.Forms.TextBox();
            this.txt5Body = new System.Windows.Forms.RichTextBox();
            this.lk0To = new System.Windows.Forms.LinkLabel();
            this.lk2ccTo = new System.Windows.Forms.LinkLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tool0Msg = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lk2ccTo);
            this.groupBox1.Controls.Add(this.lk0To);
            this.groupBox1.Controls.Add(this.btn1Files);
            this.groupBox1.Controls.Add(this.btn0Send);
            this.groupBox1.Controls.Add(this.txt3Addtchedfilepath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt2Subject);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt1ToCC);
            this.groupBox1.Controls.Add(this.txt0To);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn1Files
            // 
            this.btn1Files.Location = new System.Drawing.Point(565, 131);
            this.btn1Files.Name = "btn1Files";
            this.btn1Files.Size = new System.Drawing.Size(100, 23);
            this.btn1Files.TabIndex = 9;
            this.btn1Files.Text = "设置文件夹(&E)";
            this.btn1Files.UseVisualStyleBackColor = true;
            this.btn1Files.Click += new System.EventHandler(this.btn1Files_Click);
            // 
            // btn0Send
            // 
            this.btn0Send.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn0Send.Location = new System.Drawing.Point(6, 32);
            this.btn0Send.Name = "btn0Send";
            this.btn0Send.Size = new System.Drawing.Size(75, 119);
            this.btn0Send.TabIndex = 8;
            this.btn0Send.Text = "发送(&S)";
            this.btn0Send.UseVisualStyleBackColor = true;
            this.btn0Send.Click += new System.EventHandler(this.btn0Send_Click);
            // 
            // txt3Addtchedfilepath
            // 
            this.txt3Addtchedfilepath.Location = new System.Drawing.Point(168, 133);
            this.txt3Addtchedfilepath.Name = "txt3Addtchedfilepath";
            this.txt3Addtchedfilepath.Size = new System.Drawing.Size(394, 21);
            this.txt3Addtchedfilepath.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "附件文件夹(&F):";
            // 
            // txt2Subject
            // 
            this.txt2Subject.Location = new System.Drawing.Point(168, 96);
            this.txt2Subject.Multiline = true;
            this.txt2Subject.Name = "txt2Subject";
            this.txt2Subject.Size = new System.Drawing.Size(497, 21);
            this.txt2Subject.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "主题(&U):";
            // 
            // txt1ToCC
            // 
            this.txt1ToCC.Location = new System.Drawing.Point(168, 62);
            this.txt1ToCC.Multiline = true;
            this.txt1ToCC.Name = "txt1ToCC";
            this.txt1ToCC.Size = new System.Drawing.Size(497, 21);
            this.txt1ToCC.TabIndex = 3;
            // 
            // txt0To
            // 
            this.txt0To.Location = new System.Drawing.Point(168, 29);
            this.txt0To.Multiline = true;
            this.txt0To.Name = "txt0To";
            this.txt0To.Size = new System.Drawing.Size(497, 21);
            this.txt0To.TabIndex = 1;
            // 
            // txt5Body
            // 
            this.txt5Body.Location = new System.Drawing.Point(12, 182);
            this.txt5Body.Name = "txt5Body";
            this.txt5Body.Size = new System.Drawing.Size(671, 144);
            this.txt5Body.TabIndex = 1;
            this.txt5Body.Text = "";
            // 
            // lk0To
            // 
            this.lk0To.AutoSize = true;
            this.lk0To.Location = new System.Drawing.Point(90, 32);
            this.lk0To.Name = "lk0To";
            this.lk0To.Size = new System.Drawing.Size(77, 12);
            this.lk0To.TabIndex = 10;
            this.lk0To.TabStop = true;
            this.lk0To.Text = "收件人(&O)...";
            // 
            // lk2ccTo
            // 
            this.lk2ccTo.AutoSize = true;
            this.lk2ccTo.Location = new System.Drawing.Point(102, 65);
            this.lk2ccTo.Name = "lk2ccTo";
            this.lk2ccTo.Size = new System.Drawing.Size(65, 12);
            this.lk2ccTo.TabIndex = 11;
            this.lk2ccTo.TabStop = true;
            this.lk2ccTo.Text = "抄送(&C)...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool0Msg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 329);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(695, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tool0Msg
            // 
            this.tool0Msg.ForeColor = System.Drawing.Color.Red;
            this.tool0Msg.Name = "tool0Msg";
            this.tool0Msg.Size = new System.Drawing.Size(0, 17);
            // 
            // HRMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 351);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txt5Body);
            this.Controls.Add(this.groupBox1);
            this.Name = "HRMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HRMain";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt3Addtchedfilepath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt2Subject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt1ToCC;
        private System.Windows.Forms.TextBox txt0To;
        private System.Windows.Forms.Button btn0Send;
        private System.Windows.Forms.RichTextBox txt5Body;
        private System.Windows.Forms.Button btn1Files;
        private System.Windows.Forms.LinkLabel lk2ccTo;
        private System.Windows.Forms.LinkLabel lk0To;
        private System.Windows.Forms.StatusStrip statusStrip1;
        protected internal System.Windows.Forms.ToolStripStatusLabel tool0Msg;
    }
}