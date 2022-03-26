using ConnpassAutomator.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ConnpassAutomator
{
    internal class ConnpassWillbeRenamed
    {
        internal ConnpassWillbeRenamed() { }
        internal Credential Credential { get; set; } = new ();
        internal IList<Project> Projects { get; set; } = new List<Project>();
    }

    internal class Credential
    {
        internal Credential() { }
        internal string UserName { get; set; } = "";
        internal string Password { get; set; } = "";
    }

    internal class Project
    {
        internal Project() { }
        internal CopySource CopySource { get; set; } = new CopySource();
        internal Changeset Changeset { get; set; } = new Changeset();
    }

    internal class CopySource
    {
        internal CopySource() { }
        internal string EventTitle { get; set; } = "";
    }

    internal class Changeset
    {
        internal Changeset() { }
        internal string EventTitle { get; set; } = "";
        internal string SubEventTitle { get; set; } = "";
        internal string StartDate { get; set; } = "";
        internal string StartTime { get; set; } = "";
        internal string EndDate { get; set; } = "";
        internal string EndTime { get; set; } = "";
        internal string Explanation { get; set; } = "";
    }

    public partial class Form1 : Form
    {
        private ChromeDriver Driver { get; set; }
        private WebDriverWait DriverWait { get; set; }

        private ConnpassWillbeRenamed ConnpassWillbeRenamed { get; set; }

        public Form1()
        {
            InitializeComponent();
            ConnpassWillbeRenamed = LoadConnpassWillbeRenamed();
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

            SaveConnpassWillbeRenamed(ConnpassWillbeRenamed);
        }

        private ConnpassWillbeRenamed LoadConnpassWillbeRenamed()
        {
            Settings.Default.Upgrade();
            
            if (string.IsNullOrEmpty(Settings.Default.ConnpassWillbeRenamed))
            {
                return new();
            }

            return JsonSerializer.Deserialize<ConnpassWillbeRenamed>(Settings.Default.ConnpassWillbeRenamed);
        }

        private void SaveConnpassWillbeRenamed(ConnpassWillbeRenamed connpassWillbeRenamed)
        {
            Settings.Default.ConnpassWillbeRenamed = JsonSerializer.Serialize(connpassWillbeRenamed);
            Settings.Default.Save();
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
            foreach (var element in elements)
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
                startDate.SendKeys(startDateMaskedTextBox.Text);
                startDate.SendKeys("\t");

                //中身の文字
                var startTime = fieldTitle.FindElement(By.Name("start_time"));
                startTime.Clear();
                startTime.SendKeys(startTimeMaskedTextBox.Text);
                startTime.SendKeys("\t");

                var endDate = fieldTitle.FindElement(By.Name("end_date"));
                endDate.Clear();
                endDate.SendKeys(endDateMaskedTextBox.Text);
                endDate.SendKeys("\t");

                //中身の文字
                var endTime = fieldTitle.FindElement(By.Name("end_time"));
                endTime.Clear();
                endTime.SendKeys(endTimeMaskedTextBox.Text);
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
            // FIXME: プロパティである ConnpassWillbeRenamed を使わないといけない
            var credential = new Credential()
            {
                UserName = userNameTextBox.Text,
                Password = passwordTextBox.Text
            };

            var projects = new List<Project>
            {
                new Project(){
                    CopySource = new CopySource()
                    {
                        EventTitle = copySourceEventTitleTextBox.Text,
                    },
                    Changeset = new Changeset()
                    {
                        EventTitle = titleTextBox.Text,
                        SubEventTitle = subTitleTextBox.Text,
                        StartDate = startDateMaskedTextBox.Text,
                        StartTime = startTimeMaskedTextBox.Text,
                        EndDate = endDateMaskedTextBox.Text,
                        EndTime = endTimeMaskedTextBox.Text,
                        Explanation = descTextBox.Text
                    }
                }
            };

            ConnpassWillbeRenamed = new ConnpassWillbeRenamed()
            { Credential = credential, Projects = projects };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var connpassWillbeRenamed = ConnpassWillbeRenamed;

            userNameTextBox.Text = connpassWillbeRenamed.Credential.UserName;
            passwordTextBox.Text = connpassWillbeRenamed.Credential.Password;
            var project = connpassWillbeRenamed.Projects.First();
            copySourceEventTitleTextBox.Text = project.CopySource.EventTitle;
            titleTextBox.Text = project.Changeset.EventTitle;
            subTitleTextBox.Text = project.Changeset.SubEventTitle;
            startDateMaskedTextBox.Text = project.Changeset.StartDate;
            startTimeMaskedTextBox.Text = project.Changeset.StartTime;
            endDateMaskedTextBox.Text = project.Changeset.EndDate;
            endTimeMaskedTextBox.Text = project.Changeset.EndTime;
            descTextBox.Text = project.Changeset.Explanation;
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

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void copySourceEventTitleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void subTitleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void startDateMaskedTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void startTimeMaskedTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void endDateMaskedTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void endTimeMaskedTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void descTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}