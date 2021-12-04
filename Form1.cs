using ConnpassAutomator.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConnpassAutomator
{
    public partial class Form1 : Form
    {
        private ChromeDriver Driver { get; set; }

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
                if (title.Contains(titleTextBox.Text) && status == "�I��")
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

            //          <div id="flash_message_area" style="">
            //  <p class="message info">�C�x���g���R�s�[���܂����B</p>
            //</div>
            //400ms�҂�


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
                title.SendKeys("aaa");

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
                title.SendKeys("bbb");

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
                startDate.SendKeys("2021/12/30");
                startDate.SendKeys("\t");

                //���g�̕���
                var startTime = fieldTitle.FindElement(By.Name("start_time"));
                startTime.Clear();
                startTime.SendKeys("19:30");
                startTime.SendKeys("\t");

                var endDate = fieldTitle.FindElement(By.Name("end_date"));
                endDate.Clear();
                endDate.SendKeys("2021/12/31");
                endDate.SendKeys("\t");

                //���g�̕���
                var endTime = fieldTitle.FindElement(By.Name("end_time"));
                endTime.Clear();
                endTime.SendKeys("21:30");
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
                title.SendKeys(@"C#�ɂ��}���`�R�A�̂��߂̔񓯊�/���񏈗��v���O���~���O Zoom�I�����C���Ǐ��� vol.5

�^�C�g����ҏW

�T�u�^�C�g����ҏW");

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
            //<span class="PublishEvent btn btn_high_priority">...</span> 

            Driver.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.UserName = userNameTextBox.Text;
            Settings.Default.Password = passwordTextBox.Text;
            Settings.Default.Title = titleTextBox.Text;

            Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userNameTextBox.Text = Settings.Default.UserName;
            passwordTextBox.Text = Settings.Default.Password;
            titleTextBox.Text = Settings.Default.Title;
        }
    }
}