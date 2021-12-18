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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1119, 640);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "送信";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(1080, 532);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(150, 31);
            this.userNameTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(1080, 588);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(150, 31);
            this.passwordTextBox.TabIndex = 2;
            // 
            // copySourceEventTitleTextBox
            // 
            this.copySourceEventTitleTextBox.Location = new System.Drawing.Point(11, 33);
            this.copySourceEventTitleTextBox.Multiline = true;
            this.copySourceEventTitleTextBox.Name = "copySourceEventTitleTextBox";
            this.copySourceEventTitleTextBox.Size = new System.Drawing.Size(405, 66);
            this.copySourceEventTitleTextBox.TabIndex = 3;
            this.copySourceEventTitleTextBox.Text = "C#によるマルチコアのための非同期/並列処理プログラミング Zoomオンライン読書会 vol.6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(443, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "タイトル";
            // 
            // subTitleTextBox
            // 
            this.subTitleTextBox.Location = new System.Drawing.Point(441, 136);
            this.subTitleTextBox.Name = "subTitleTextBox";
            this.subTitleTextBox.Size = new System.Drawing.Size(284, 31);
            this.subTitleTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "サブタイトル";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "開始時間";
            // 
            // descTextBox
            // 
            this.descTextBox.Location = new System.Drawing.Point(439, 477);
            this.descTextBox.Multiline = true;
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.Size = new System.Drawing.Size(405, 257);
            this.descTextBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "イベントの説明";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(283, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "コピー元イベントタイトル（前方一致）";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(456, 38);
            this.titleTextBox.Multiline = true;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(405, 62);
            this.titleTextBox.TabIndex = 13;
            this.titleTextBox.Text = "C#によるマルチコアのための非同期/並列処理プログラミン";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "終了時間";
            // 
            // UserNamelabel
            // 
            this.UserNamelabel.AutoSize = true;
            this.UserNamelabel.Location = new System.Drawing.Point(996, 537);
            this.UserNamelabel.Name = "UserNamelabel";
            this.UserNamelabel.Size = new System.Drawing.Size(84, 25);
            this.UserNamelabel.TabIndex = 8;
            this.UserNamelabel.Text = "ユーザー名";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(1001, 593);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(79, 25);
            this.passwordLabel.TabIndex = 8;
            this.passwordLabel.Text = "パスワード";
            // 
            // startDateMaskedTextBox
            // 
            this.startDateMaskedTextBox.Location = new System.Drawing.Point(443, 278);
            this.startDateMaskedTextBox.Mask = "0000/00/00";
            this.startDateMaskedTextBox.Name = "startDateMaskedTextBox";
            this.startDateMaskedTextBox.Size = new System.Drawing.Size(150, 31);
            this.startDateMaskedTextBox.TabIndex = 21;
            this.startDateMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // startTimeMaskedTextBox
            // 
            this.startTimeMaskedTextBox.Location = new System.Drawing.Point(599, 278);
            this.startTimeMaskedTextBox.Mask = "00:00";
            this.startTimeMaskedTextBox.Name = "startTimeMaskedTextBox";
            this.startTimeMaskedTextBox.Size = new System.Drawing.Size(150, 31);
            this.startTimeMaskedTextBox.TabIndex = 22;
            this.startTimeMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // endTimeMaskedTextBox
            // 
            this.endTimeMaskedTextBox.Location = new System.Drawing.Point(599, 355);
            this.endTimeMaskedTextBox.Mask = "00:00";
            this.endTimeMaskedTextBox.Name = "endTimeMaskedTextBox";
            this.endTimeMaskedTextBox.Size = new System.Drawing.Size(150, 31);
            this.endTimeMaskedTextBox.TabIndex = 24;
            this.endTimeMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // endDateMaskedTextBox
            // 
            this.endDateMaskedTextBox.Location = new System.Drawing.Point(443, 355);
            this.endDateMaskedTextBox.Mask = "0000/00/00";
            this.endDateMaskedTextBox.Name = "endDateMaskedTextBox";
            this.endDateMaskedTextBox.Size = new System.Drawing.Size(150, 31);
            this.endDateMaskedTextBox.TabIndex = 23;
            this.endDateMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // plus7Button
            // 
            this.plus7Button.Location = new System.Drawing.Point(443, 213);
            this.plus7Button.Name = "plus7Button";
            this.plus7Button.Size = new System.Drawing.Size(112, 34);
            this.plus7Button.TabIndex = 25;
            this.plus7Button.Text = "+7Day";
            this.plus7Button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 815);
            this.Controls.Add(this.plus7Button);
            this.Controls.Add(this.endTimeMaskedTextBox);
            this.Controls.Add(this.endDateMaskedTextBox);
            this.Controls.Add(this.startTimeMaskedTextBox);
            this.Controls.Add(this.startDateMaskedTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.descTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.UserNamelabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subTitleTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.copySourceEventTitleTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}