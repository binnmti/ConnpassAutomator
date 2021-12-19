using ConnpassAutomator.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConnpassAutomator
{
    public partial class Form1 : Form
    {
        private ChromeDriver Driver { get; set; }
        private WebDriverWait DriverWait { get; set; }

        public Form1()
        {
            InitializeComponent();
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
            foreach(var element in elements)
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
                title.SendKeys(descTextBox.Text);
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.UserName = userNameTextBox.Text;
            Settings.Default.Password = passwordTextBox.Text;
            
            Settings.Default.CopySourceEventTitle = copySourceEventTitleTextBox.Text;
            Settings.Default.Title = titleTextBox.Text;
            Settings.Default.Subtitle = subTitleTextBox.Text;
            Settings.Default.StartDate = startDateMaskedTextBox.Text;
            Settings.Default.StartTime= startTimeMaskedTextBox.Text;
            Settings.Default.EndDate = endDateMaskedTextBox.Text;
            Settings.Default.EndTime = endTimeMaskedTextBox.Text;
            Settings.Default.DescText = descTextBox.Text;

            Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userNameTextBox.Text = Settings.Default.UserName;
            passwordTextBox.Text = Settings.Default.Password;

            copySourceEventTitleTextBox.Text = Settings.Default.CopySourceEventTitle;
            titleTextBox.Text= Settings.Default.Title;
            subTitleTextBox.Text = Settings.Default.Subtitle;
            startDateMaskedTextBox.Text = Settings.Default.StartDate;
            startTimeMaskedTextBox.Text = Settings.Default.StartTime;
            endDateMaskedTextBox.Text = Settings.Default.EndDate;
            endTimeMaskedTextBox.Text = Settings.Default.EndTime;
            descTextBox.Text = Settings.Default.DescText;
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
            var numText = new string(title.Reverse()
                .SkipWhile(x => x < '0' || x > '9')
                .TakeWhile(x => x >= '0' && x <= '9')
                .Reverse()
                .ToArray());
            var num = int.Parse(numText);
            return $"{title[..title.LastIndexOf(numText)]}{++num}{title[(title.LastIndexOf(numText) + numText.Length)..]}";
        }
    }
}