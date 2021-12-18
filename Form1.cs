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

            //TODO:さて
            Thread.Sleep(1000);

            var elements = Driver.FindElements(By.ClassName("event_list"));
            foreach(var element in elements)
            {
                //label_status_event mb_5 close 終了
                var status = element.FindElement(By.ClassName("label_status_event")).Text;

                //C#によるマルチコアのための非同期/並列処理プログラミング Zoomオンライン読書会 vol.5;
                var title = element.FindElement(By.CssSelector(".title > a")).Text;
                if (title.Contains(copySourceEventTitleTextBox.Text) && status == "終了")
                {
                    element.FindElement(By.ClassName("icon_gray_copy")).Click();
                    break;
                }
            }
            //コピー作成。
            var alert = Driver.SwitchTo().Alert();
            alert.Accept();

            //TODO:さて
            Thread.Sleep(1000);

            //「イベントをコピーしました」がスライドインする
            var messageArea = Driver.FindElement(By.Id("flash_message_area"));
            messageArea.Click();
            Thread.Sleep(400);

            //タイトル編集
            {
                var fieldTitle = Driver.FindElement(By.Id("FieldTitle"));
                //編集モードに入る
                fieldTitle.Click();
                //中身の文字
                var title = fieldTitle.FindElement(By.Name("title"));
                //タイトルを書き換える
                var titleValue = title.GetAttribute("value");
                title.Clear();
                title.SendKeys(titleTextBox.Text);

                var submit = fieldTitle.FindElement(By.CssSelector("button[type=submit]"));
                submit.Click();
            }
            //サブタイトル編集
            {
                var fieldTitle = Driver.FindElement(By.Id("FieldSubTitle"));
                //編集モードに入る
                fieldTitle.Click();
                //中身の文字
                var title = fieldTitle.FindElement(By.Name("sub_title"));
                //タイトルを書き換える
                var titleValue = title.GetAttribute("value");
                title.Clear();
                title.SendKeys(subTitleTextBox.Text);

                var submit = fieldTitle.FindElement(By.CssSelector("button[type=submit]"));
                submit.Click();
            }
            //開催日時編集
            {
                var fieldTitle = Driver.FindElement(By.Id("EventDates"));
                //編集モードに入る
                fieldTitle.Click();

                //ピッカーが出るのを消すために\tを投げる
                //中身の文字
                var startDate = fieldTitle.FindElement(By.Name("start_date"));
                startDate.Clear();
                startDate.SendKeys(startDateTextBox.Text);
                startDate.SendKeys("\t");

                //中身の文字
                var startTime = fieldTitle.FindElement(By.Name("start_time"));
                startTime.Clear();
                startTime.SendKeys(startTimeTextBox.Text);
                startTime.SendKeys("\t");

                var endDate = fieldTitle.FindElement(By.Name("end_date"));
                endDate.Clear();
                endDate.SendKeys(endDateTextBox.Text);
                endDate.SendKeys("\t");

                //中身の文字
                var endTime = fieldTitle.FindElement(By.Name("end_time"));
                endTime.Clear();
                endTime.SendKeys(endTimeTextBox.Text);
                endTime.SendKeys("\t");

                //ピッカーが保存ボタンに被ると、ボタンが押せなくなる
                //ピッカーを消すために、開始日時をクリックする
                startDate.Click();

                var submit = fieldTitle.FindElement(By.CssSelector("button[type=submit]"));
                submit.Click();
            }
            //イベント編集
            {
                var fieldTitle = Driver.FindElement(By.Id("FieldDescription"));
                //編集モードに入る
                fieldTitle.Click();
                //中身の文字
                var title = fieldTitle.FindElement(By.Name("description_input"));
                //タイトルを書き換える
                var titleValue = title.GetAttribute("value");
                title.Clear();
                title.SendKeys(descTextBox.Text);
                var submit = fieldTitle.FindElement(By.CssSelector("button[type=submit]"));
                submit.Click();
            }


            //即時公開する
            {
                var publishEvent = Driver.FindElement(By.ClassName("PublishEvent"));
                publishEvent.Click();

                var popupSubmit = Driver.FindElement(By.ClassName("PopupSubmit"));
                popupSubmit.Click();
            }

            //公開されたことを確認して終了
            System.Diagnostics.Debug.WriteLine(Driver.Url);
            DriverWait.Until((_) => Driver.Url.Contains("published"));
            var mainTitle = Driver.FindElement(By.ClassName("main_title_2"));
            if (mainTitle.Text != "イベントを公開しました")
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
            Settings.Default.StartDate = startDateTextBox.Text;
            Settings.Default.StartTime= startTimeTextBox.Text;
            Settings.Default.EndDate = endDateTextBox.Text;
            Settings.Default.EndTime = endTimeTextBox.Text;
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
            startDateTextBox.Text = Settings.Default.StartDate;
            startTimeTextBox.Text = Settings.Default.StartTime;
            endDateTextBox.Text = Settings.Default.EndDate;
            endTimeTextBox.Text = Settings.Default.EndTime;
            descTextBox.Text = Settings.Default.DescText;
        }
    }
}