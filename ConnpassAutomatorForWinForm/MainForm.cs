using ConnpassAutomator;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;

namespace ConnpassAutomatorForWinForm
{
    public partial class MainForm : Form
    {
        private Setting Setting { get; init; }

        public MainForm()
        {
            InitializeComponent();
            Setting = LoadSetting();
        }

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

            SaveSetting(Setting);
        }

        private Setting LoadSetting()
        {
            var loaded = SettingManager.Load();
            return RequireAtLeastOneProject(loaded);
        }

        private Setting RequireAtLeastOneProject(Setting setting)
        {
            var projects = setting.Projects;
            if (projects.Count > 0) return setting;

            projects.Add(Project.CreateDefault());
            return setting;
        }

        private void SaveSetting(Setting setting)
        {
            SettingManager.Save(setting);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 引数になるもの
            var credential = Setting.Credential;
            var project = GetCurrentProject();
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // TODO: エラーハンドリングが必要
            var publisher = new EventPublisher(baseDir);
            publisher.Publish(project, credential);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userNameTextBox.Text = Setting.Credential.UserName;
            passwordTextBox.Text = Setting.Credential.Password;
            comboBox1.Items.AddRange(Setting.Projects.ToArray());
            comboBox1.DisplayMember = "DisplayName";

            //TODO:前回開いていたプロジェクトをひらいてくれるのが嬉しい。
            comboBox1.SelectedIndex = 0;
        }

        private void plus7Button_Click(object sender, EventArgs e)
        {
            if (!startDateMaskedTextBox.MaskFull) return;
            if (!endDateMaskedTextBox.MaskFull) return;
            if (!DateTime.TryParse(startDateMaskedTextBox.Text, out var startDate)) return;
            if (!DateTime.TryParse(endDateMaskedTextBox.Text, out var endDate)) return;
            startDateMaskedTextBox.Text = startDate.AddDays(7).ToString();
            endDateMaskedTextBox.Text = endDate.AddDays(7).ToString();
        }

        private void titlePlusButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = MagicIncrement(titleTextBox.Text);
        }

        private string MagicIncrement(string title)
        {
            return new LastBareIntegerMagicIncrementProvider().Increment(title);
        }

        private interface IMagicIncrementProvider
        {
            public string Increment(string naturalText);
        }

        private class DefaultMagicIncrementProvider : IMagicIncrementProvider
        {
            public string Increment(string title)
            {
                var numText = new string(title.Reverse()
                    .SkipWhile(x => x < '0' || x > '9')
                    .TakeWhile(x => x >= '0' && x <= '9')
                    .Reverse()
                    .ToArray());
                if (!int.TryParse(numText, out var num)) return title;
                return $"{title[..title.LastIndexOf(numText)]}{++num}{title[(title.LastIndexOf(numText) + numText.Length)..]}";
            }
        }

        private class LastBareIntegerMagicIncrementProvider : IMagicIncrementProvider
        {
            public string Increment(string naturalText)
            {
                var parse = (string text) => BigInteger.Parse(text, NumberStyles.AllowLeadingSign);
                var format = (BigInteger value) => value.ToString("D");
                var increment = (string text) => format(parse(text) + 1);

                return Regex.Replace(naturalText, @"-?\d+(?!.*\d)", match => increment(match.Value));
            }

        }

        private Project GetCurrentProject()
        {
            return Setting.Projects[comboBox1.SelectedIndex];
        }

        private void SetCurrentProject()
        {
            var project = GetCurrentProject();
            copySourceEventTitleTextBox.Text = project.CopySource.EventTitle;
            titleTextBox.Text = project.Changeset.EventTitle;
            subTitleTextBox.Text = project.Changeset.SubEventTitle;
            startDateMaskedTextBox.Text = project.Changeset.StartDate;
            startTimeMaskedTextBox.Text = project.Changeset.StartTime;
            endDateMaskedTextBox.Text = project.Changeset.EndDate;
            endTimeMaskedTextBox.Text = project.Changeset.EndTime;
            explanationTextBox.Text = project.Changeset.Explanation;
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {
            string changedText = userNameTextBox.Text;
            Setting.Credential.UserName = changedText;
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            string changedText = passwordTextBox.Text;
            Setting.Credential.Password = changedText;
        }

        private void copySourceEventTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            string changedText = copySourceEventTitleTextBox.Text;
            Project project = GetCurrentProject();
            project.CopySource.EventTitle = changedText;

            // コンボボックスも更新する
            comboBox1.Items[comboBox1.SelectedIndex] = project;
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            string changedText = titleTextBox.Text;
            Project project = GetCurrentProject();
            project.Changeset.EventTitle = changedText;
        }

        private void subTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            string changedText = subTitleTextBox.Text;
            Project project = GetCurrentProject();
            project.Changeset.SubEventTitle = changedText;
        }

        private void startDateMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            string changedText = startDateMaskedTextBox.Text;
            Project project = GetCurrentProject();
            project.Changeset.StartDate = changedText;
        }

        private void startTimeMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            string changedText = startTimeMaskedTextBox.Text;
            Project project = GetCurrentProject();
            project.Changeset.StartTime = changedText;
        }

        private void endDateMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            string changedText = endDateMaskedTextBox.Text;
            Project project = GetCurrentProject();
            project.Changeset.EndDate = changedText;
        }

        private void endTimeMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            string changedText = endTimeMaskedTextBox.Text;
            Project project = GetCurrentProject();
            project.Changeset.EndTime = changedText;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentProject();
        }

        private void explanationTextBox_TextChanged(object sender, EventArgs e)
        {
            string changedText = explanationTextBox.Text;
            Project project = GetCurrentProject();
            project.Changeset.Explanation = changedText;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newProject = Project.CreateDefault();
            Setting.Projects.Add(newProject);
            comboBox1.Items.Add(newProject); // コンボボックスに反映
            // カレントの設定どうするか
        }

        private void RemoveProjectButton_Click(object sender, EventArgs e)
        {
            var count = Setting.Projects.Count;
            if(count == 1)
            {
                MessageBox.Show("少なくとも1つのプロジェクトが必要なため、削除できません");
                return;
            }
            // 削除確認
            var result = MessageBox.Show("削除しますか？", "削除", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }
            var index = comboBox1.SelectedIndex;
            Setting.Projects.RemoveAt(index);
            comboBox1.Items.RemoveAt(index);
            // この状態だとindexは-1（未選択）
            if (index == Setting.Projects.Count)
            {
                index--;
            }
            comboBox1.SelectedIndex = index;
        }
    }
}