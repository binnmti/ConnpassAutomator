using ConnpassAutomator;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;

namespace ConnpassAutomatorForWinForm
{
    public partial class MainForm : Form
    {
        private ChromeDriver Driver { get; set; }
        private WebDriverWait DriverWait { get; set; }

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
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            Driver = new ChromeDriver(baseDir, new ChromeOptions(), TimeSpan.FromSeconds(120))
            {
                Url = "https://connpass.com/editmanage/"
            };
            DriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60))
            {
                PollingInterval = TimeSpan.FromSeconds(1),
            };
            DriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            Driver.FindElement(By.Name("username")).SendKeys(userNameTextBox.Text);
            Driver.FindElement(By.Name("password")).SendKeys(passwordTextBox.Text);
            Driver.FindElement(By.Id("login_form")).Submit();

            //TODO:����
            Thread.Sleep(1000);

            var elements = Driver.FindElements(By.ClassName("event_list"));
            foreach (var element in elements)
            {
                //label_status_event mb_5 close �I��
                var status = element.FindElement(By.ClassName("label_status_event")).Text;

                //C#�ɂ��}���`�R�A�̂��߂̔񓯊�/���񏈗��v���O���~���O Zoom�I�����C���Ǐ��� vol.5;
                var title = element.FindElement(By.CssSelector(".title > a")).Text;
                if (title.Contains(copySourceEventTitleTextBox.Text) && status == "�I��")
                {
                    element.FindElement(By.ClassName("icon_gray_copy")).Click();
                    break;
                }
            }
            //�R�s�[�쐬�B
            var alert = Driver.SwitchTo().Alert();
            alert.Accept();

            //TODO:����
            Thread.Sleep(1000);

            //�u�C�x���g���R�s�[���܂����v���X���C�h�C������
            var messageArea = Driver.FindElement(By.Id("flash_message_area"));
            messageArea.Click();
            Thread.Sleep(400);

            //�^�C�g���ҏW
            {
                var fieldTitle = Driver.FindElement(By.Id("FieldTitle"));
                //�ҏW���[�h�ɓ���
                fieldTitle.Click();
                //���g�̕���
                var title = fieldTitle.FindElement(By.Name("title"));
                //�^�C�g��������������
                var titleValue = title.GetAttribute("value");
                title.Clear();
                title.SendKeys(titleTextBox.Text);

                var submit = fieldTitle.FindElement(By.CssSelector("button[type=submit]"));
                submit.Click();
            }
            //�T�u�^�C�g���ҏW
            {
                var fieldTitle = Driver.FindElement(By.Id("FieldSubTitle"));
                //�ҏW���[�h�ɓ���
                fieldTitle.Click();
                //���g�̕���
                var title = fieldTitle.FindElement(By.Name("sub_title"));
                //�^�C�g��������������
                var titleValue = title.GetAttribute("value");
                title.Clear();
                title.SendKeys(subTitleTextBox.Text);

                var submit = fieldTitle.FindElement(By.CssSelector("button[type=submit]"));
                submit.Click();
            }
            //�J�Ó����ҏW
            {
                var fieldTitle = Driver.FindElement(By.Id("EventDates"));
                //�ҏW���[�h�ɓ���
                fieldTitle.Click();

                //�s�b�J�[���o��̂��������߂�\t�𓊂���
                //���g�̕���
                var startDate = fieldTitle.FindElement(By.Name("start_date"));
                startDate.Clear();
                startDate.SendKeys(startDateMaskedTextBox.Text);
                startDate.SendKeys("\t");

                //���g�̕���
                var startTime = fieldTitle.FindElement(By.Name("start_time"));
                startTime.Clear();
                startTime.SendKeys(startTimeMaskedTextBox.Text);
                startTime.SendKeys("\t");

                var endDate = fieldTitle.FindElement(By.Name("end_date"));
                endDate.Clear();
                endDate.SendKeys(endDateMaskedTextBox.Text);
                endDate.SendKeys("\t");

                //���g�̕���
                var endTime = fieldTitle.FindElement(By.Name("end_time"));
                endTime.Clear();
                endTime.SendKeys(endTimeMaskedTextBox.Text);
                endTime.SendKeys("\t");

                //�s�b�J�[���ۑ��{�^���ɔ��ƁA�{�^���������Ȃ��Ȃ�
                //�s�b�J�[���������߂ɁA�J�n�������N���b�N����
                startDate.Click();

                var submit = fieldTitle.FindElement(By.CssSelector("button[type=submit]"));
                submit.Click();
            }
            //�C�x���g�ҏW
            {
                var fieldTitle = Driver.FindElement(By.Id("FieldDescription"));
                //�ҏW���[�h�ɓ���
                fieldTitle.Click();
                //���g�̕���
                var title = fieldTitle.FindElement(By.Name("description_input"));
                //�^�C�g��������������
                var titleValue = title.GetAttribute("value");
                title.Clear();
                title.SendKeys(explanationTextBox.Text);
                var submit = fieldTitle.FindElement(By.CssSelector("button[type=submit]"));
                submit.Click();
            }


            //�������J����
            {
                var publishEvent = Driver.FindElement(By.ClassName("PublishEvent"));
                publishEvent.Click();

                var popupSubmit = Driver.FindElement(By.ClassName("PopupSubmit"));
                popupSubmit.Click();
            }

            //���J���ꂽ���Ƃ��m�F���ďI��
            System.Diagnostics.Debug.WriteLine(Driver.Url);
            DriverWait.Until((_) => Driver.Url.Contains("published"));
            var mainTitle = Driver.FindElement(By.ClassName("main_title_2"));
            if (mainTitle.Text != "�C�x���g�����J���܂���")
            {
                throw new Exception("NG!!");
            }

            Driver.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userNameTextBox.Text = Setting.Credential.UserName;
            passwordTextBox.Text = Setting.Credential.Password;
            var project = Setting.Projects.First();
            copySourceEventTitleTextBox.Text = project.CopySource.EventTitle;
            titleTextBox.Text = project.Changeset.EventTitle;
            subTitleTextBox.Text = project.Changeset.SubEventTitle;
            startDateMaskedTextBox.Text = project.Changeset.StartDate;
            startTimeMaskedTextBox.Text = project.Changeset.StartTime;
            endDateMaskedTextBox.Text = project.Changeset.EndDate;
            endTimeMaskedTextBox.Text = project.Changeset.EndTime;
            explanationTextBox.Text = project.Changeset.Explanation;
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
            return Setting.Projects[0];
        }
        private void SetCurrentProject(int index)
        {
            // TODO:�\���̐؂�ւ�
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
            int changedIndex = comboBox1.SelectedIndex;
            SetCurrentProject(changedIndex);
        }

        private void explanationTextBox_TextChanged(object sender, EventArgs e)
        {
            string changedText = explanationTextBox.Text;
            Project project = GetCurrentProject();
            project.Changeset.Explanation = changedText;
        }
    }
}