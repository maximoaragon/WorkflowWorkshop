namespace ExchangePointServiceTester
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wbXML = new System.Windows.Forms.WebBrowser();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPubSubLog = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.wbResponse = new System.Windows.Forms.WebBrowser();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFDBN = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLoadXML = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataPath = new System.Windows.Forms.TextBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.chkAuthenticate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlSubLog = new System.Windows.Forms.Panel();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.pnlSubTop = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMessages = new System.Windows.Forms.ComboBox();
            this.txtPubSubURI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUnsubscribe = new System.Windows.Forms.Button();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnlSubLog.SuspendLayout();
            this.pnlSubTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(892, 643);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(884, 617);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "EPS Test";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(878, 487);
            this.panel2.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wbXML);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 228);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Post Data";
            // 
            // wbXML
            // 
            this.wbXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbXML.Location = new System.Drawing.Point(3, 16);
            this.wbXML.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbXML.Name = "wbXML";
            this.wbXML.Size = new System.Drawing.Size(592, 209);
            this.wbXML.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPubSubLog);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(601, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(277, 228);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PubSub Activity";
            // 
            // txtPubSubLog
            // 
            this.txtPubSubLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPubSubLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPubSubLog.Location = new System.Drawing.Point(3, 16);
            this.txtPubSubLog.Multiline = true;
            this.txtPubSubLog.Name = "txtPubSubLog";
            this.txtPubSubLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPubSubLog.Size = new System.Drawing.Size(271, 209);
            this.txtPubSubLog.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.wbResponse);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 259);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Response";
            // 
            // wbResponse
            // 
            this.wbResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbResponse.Location = new System.Drawing.Point(3, 16);
            this.wbResponse.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbResponse.Name = "wbResponse";
            this.wbResponse.Size = new System.Drawing.Size(869, 240);
            this.wbResponse.TabIndex = 3;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 487);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtFDBN);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnLoadXML);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDataPath);
            this.panel1.Controls.Add(this.btnPost);
            this.panel1.Controls.Add(this.txtURL);
            this.panel1.Controls.Add(this.chkAuthenticate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 124);
            this.panel1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(598, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "FriendlyDBName:";
            // 
            // txtFDBN
            // 
            this.txtFDBN.Enabled = false;
            this.txtFDBN.Location = new System.Drawing.Point(601, 87);
            this.txtFDBN.Name = "txtFDBN";
            this.txtFDBN.Size = new System.Drawing.Size(138, 20);
            this.txtFDBN.TabIndex = 12;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(476, 88);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(119, 20);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(351, 89);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(119, 20);
            this.txtUser.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(474, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "User:";
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.Location = new System.Drawing.Point(754, 50);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(51, 23);
            this.btnLoadXML.TabIndex = 7;
            this.btnLoadXML.Text = "...";
            this.btnLoadXML.UseVisualStyleBackColor = true;
            this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXML_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data Path:";
            // 
            // txtDataPath
            // 
            this.txtDataPath.Location = new System.Drawing.Point(87, 51);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.Size = new System.Drawing.Size(657, 20);
            this.txtDataPath.TabIndex = 5;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(811, 19);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(51, 23);
            this.btnPost.TabIndex = 4;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(87, 22);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(657, 20);
            this.txtURL.TabIndex = 0;
            // 
            // chkAuthenticate
            // 
            this.chkAuthenticate.AutoSize = true;
            this.chkAuthenticate.Location = new System.Drawing.Point(87, 91);
            this.chkAuthenticate.Name = "chkAuthenticate";
            this.chkAuthenticate.Size = new System.Drawing.Size(255, 17);
            this.chkAuthenticate.TabIndex = 3;
            this.chkAuthenticate.Text = "Authenticate and Pass the Authentication Ticket";
            this.chkAuthenticate.UseVisualStyleBackColor = true;
            this.chkAuthenticate.CheckedChanged += new System.EventHandler(this.chkAuthenticate_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Request URL:";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(754, 19);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(51, 23);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pnlSubLog);
            this.tabPage2.Controls.Add(this.pnlSubTop);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage2.Size = new System.Drawing.Size(884, 617);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Subscriber Test";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlSubLog
            // 
            this.pnlSubLog.Controls.Add(this.lbLog);
            this.pnlSubLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubLog.Location = new System.Drawing.Point(5, 136);
            this.pnlSubLog.Name = "pnlSubLog";
            this.pnlSubLog.Size = new System.Drawing.Size(874, 476);
            this.pnlSubLog.TabIndex = 3;
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.HorizontalScrollbar = true;
            this.lbLog.Location = new System.Drawing.Point(0, 0);
            this.lbLog.Name = "lbLog";
            this.lbLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbLog.Size = new System.Drawing.Size(874, 476);
            this.lbLog.TabIndex = 2;
            // 
            // pnlSubTop
            // 
            this.pnlSubTop.Controls.Add(this.btnClear);
            this.pnlSubTop.Controls.Add(this.label3);
            this.pnlSubTop.Controls.Add(this.cbMessages);
            this.pnlSubTop.Controls.Add(this.txtPubSubURI);
            this.pnlSubTop.Controls.Add(this.label2);
            this.pnlSubTop.Controls.Add(this.btnUnsubscribe);
            this.pnlSubTop.Controls.Add(this.btnSubscribe);
            this.pnlSubTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubTop.Location = new System.Drawing.Point(5, 5);
            this.pnlSubTop.Name = "pnlSubTop";
            this.pnlSubTop.Size = new System.Drawing.Size(874, 131);
            this.pnlSubTop.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(295, 78);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(137, 47);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear Log";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Message Type:";
            // 
            // cbMessages
            // 
            this.cbMessages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMessages.FormattingEnabled = true;
            this.cbMessages.Location = new System.Drawing.Point(89, 48);
            this.cbMessages.Name = "cbMessages";
            this.cbMessages.Size = new System.Drawing.Size(276, 21);
            this.cbMessages.TabIndex = 5;
            // 
            // txtPubSubURI
            // 
            this.txtPubSubURI.Location = new System.Drawing.Point(89, 14);
            this.txtPubSubURI.Name = "txtPubSubURI";
            this.txtPubSubURI.Size = new System.Drawing.Size(584, 20);
            this.txtPubSubURI.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pub Sub URI:";
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Location = new System.Drawing.Point(149, 78);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(140, 47);
            this.btnUnsubscribe.TabIndex = 7;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.btnUnsubscribe_Click);
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(6, 78);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(137, 47);
            this.btnSubscribe.TabIndex = 6;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 663);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "DES Tester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.pnlSubLog.ResumeLayout(false);
            this.pnlSubTop.ResumeLayout(false);
            this.pnlSubTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.CheckBox chkAuthenticate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.Panel pnlSubTop;
        private System.Windows.Forms.Panel pnlSubLog;
        private System.Windows.Forms.Button btnUnsubscribe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPubSubURI;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMessages;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnLoadXML;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDataPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFDBN;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser wbXML;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPubSubLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser wbResponse;
        private System.Windows.Forms.Splitter splitter2;

    }
}

