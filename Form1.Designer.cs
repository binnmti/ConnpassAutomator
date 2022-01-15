namespace ConnpassAutomator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.copySourceEventTitleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subTitleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.descTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UserNamelabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.startDateMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.startTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.endTimeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.endDateMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.plus7Button = new System.Windows.Forms.Button();
            this.titlePlusButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "送信";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(117, 51);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(150, 31);
            this.userNameTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(117, 107);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(150, 31);
            this.passwordTextBox.TabIndex = 2;
            // 
            // copySourceEventTitleTextBox
            // 
            this.copySourceEventTitleTextBox.Location = new System.Drawing.Point(91, 44);
            this.copySourceEventTitleTextBox.Multiline = true;
            this.copySourceEventTitleTextBox.Name = "copySourceEventTitleTextBox";
            this.copySourceEventTitleTextBox.Size = new System.Drawing.Size(405, 66);
            this.copySourceEventTitleTextBox.TabIndex = 3;
            this.copySourceEventTitleTextBox.Text = "C#によるマルチコアのための非同期/並列処理プログラミング Zoomオンライン読書会 vol.6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "タイトル";
            // 
            // subTitleTextBox
            // 
            this.subTitleTextBox.Location = new System.Drawing.Point(76, 301);
            this.subTitleTextBox.Name = "subTitleTextBox";
            this.subTitleTextBox.Size = new System.Drawing.Size(284, 31);
            this.subTitleTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "サブタイトル";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "開始時間";
            // 
            // descTextBox
            // 
            this.descTextBox.Location = new System.Drawing.Point(74, 611);
            this.descTextBox.Multiline = true;
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.Size = new System.Drawing.Size(405, 257);
            this.descTextBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 582);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "イベントの説明";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(283, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "コピー元イベントタイトル（前方一致）";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(91, 207);
            this.titleTextBox.Multiline = true;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(405, 62);
            this.titleTextBox.TabIndex = 13;
            this.titleTextBox.Text = "C#によるマルチコアのための非同期/並列処理プログラミン";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 461);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "終了時間";
            // 
            // UserNamelabel
            // 
            this.UserNamelabel.AutoSize = true;
            this.UserNamelabel.Location = new System.Drawing.Point(33, 56);
            this.UserNamelabel.Name = "UserNamelabel";
            this.UserNamelabel.Size = new System.Drawing.Size(84, 25);
            this.UserNamelabel.TabIndex = 8;
            this.UserNamelabel.Text = "ユーザー名";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(38, 112);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(79, 25);
            this.passwordLabel.TabIndex = 8;
            this.passwordLabel.Text = "パスワード";
            // 
            // startDateMaskedTextBox
            // 
            this.startDateMaskedTextBox.Location = new System.Drawing.Point(78, 412);
            this.startDateMaskedTextBox.Mask = "0000/00/00";
            this.startDateMaskedTextBox.Name = "startDateMaskedTextBox";
            this.startDateMaskedTextBox.Size = new System.Drawing.Size(150, 31);
            this.startDateMaskedTextBox.TabIndex = 21;
            this.startDateMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // startTimeMaskedTextBox
            // 
            this.startTimeMaskedTextBox.Location = new System.Drawing.Point(234, 412);
            this.startTimeMaskedTextBox.Mask = "00:00";
            this.startTimeMaskedTextBox.Name = "startTimeMaskedTextBox";
            this.startTimeMaskedTextBox.Size = new System.Drawing.Size(150, 31);
            this.startTimeMaskedTextBox.TabIndex = 22;
            this.startTimeMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // endTimeMaskedTextBox
            // 
            this.endTimeMaskedTextBox.Location = new System.Drawing.Point(234, 489);
            this.endTimeMaskedTextBox.Mask = "00:00";
            this.endTimeMaskedTextBox.Name = "endTimeMaskedTextBox";
            this.endTimeMaskedTextBox.Size = new System.Drawing.Size(150, 31);
            this.endTimeMaskedTextBox.TabIndex = 24;
            this.endTimeMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // endDateMaskedTextBox
            // 
            this.endDateMaskedTextBox.Location = new System.Drawing.Point(78, 489);
            this.endDateMaskedTextBox.Mask = "0000/00/00";
            this.endDateMaskedTextBox.Name = "endDateMaskedTextBox";
            this.endDateMaskedTextBox.Size = new System.Drawing.Size(150, 31);
            this.endDateMaskedTextBox.TabIndex = 23;
            this.endDateMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // plus7Button
            // 
            this.plus7Button.Location = new System.Drawing.Point(78, 347);
            this.plus7Button.Name = "plus7Button";
            this.plus7Button.Size = new System.Drawing.Size(112, 34);
            this.plus7Button.TabIndex = 25;
            this.plus7Button.Text = "+7Day";
            this.plus7Button.UseVisualStyleBackColor = true;
            this.plus7Button.Click += new System.EventHandler(this.plus7Button_Click);
            // 
            // titlePlusButton
            // 
            this.titlePlusButton.Location = new System.Drawing.Point(513, 217);
            this.titlePlusButton.Name = "titlePlusButton";
            this.titlePlusButton.Size = new System.Drawing.Size(112, 34);
            this.titlePlusButton.TabIndex = 26;
            this.titlePlusButton.Text = "+1";
            this.titlePlusButton.UseVisualStyleBackColor = true;
            this.titlePlusButton.Click += new System.EventHandler(this.titlePlusButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(375, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(717, 33);
            this.comboBox1.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.titlePlusButton);
            this.groupBox1.Controls.Add(this.plus7Button);
            this.groupBox1.Controls.Add(this.endTimeMaskedTextBox);
            this.groupBox1.Controls.Add(this.endDateMaskedTextBox);
            this.groupBox1.Controls.Add(this.startTimeMaskedTextBox);
            this.groupBox1.Controls.Add(this.startDateMaskedTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.titleTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.descTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.subTitleTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.copySourceEventTitleTextBox);
            this.groupBox1.Location = new System.Drawing.Point(375, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(717, 896);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 1007);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.UserNamelabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox userNameTextBox;
        private TextBox passwordTextBox;
        private TextBox copySourceEventTitleTextBox;
        private Label label1;
        private TextBox subTitleTextBox;
        private Label label2;
        private Label label3;
        private TextBox descTextBox;
        private Label label4;
        private Label label5;
        private TextBox titleTextBox;
        private Label label6;
        private Label UserNamelabel;
        private Label passwordLabel;
        private MaskedTextBox startDateMaskedTextBox;
        private MaskedTextBox startTimeMaskedTextBox;
        private MaskedTextBox endTimeMaskedTextBox;
        private MaskedTextBox endDateMaskedTextBox;
        private Button plus7Button;
        private Button titlePlusButton;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
    }
}