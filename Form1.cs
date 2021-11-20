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

            //TODO:さて
            Thread.Sleep(1000);

            var elements = Driver.FindElements(By.ClassName("event_list"));
            foreach(var element in elements)
            {
                //label_status_event mb_5 close 終了
                var status = element.FindElement(By.ClassName("label_status_event")).Text;

                //C#によるマルチコアのための非同期/並列処理プログラミング Zoomオンライン読書会 vol.5;
                var title = element.FindElement(By.CssSelector(".title > a")).Text;
                if (title.Contains(titleTextBox.Text) && status == "終了")
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

            //下書き画面
            {
                var fieldTitle = Driver.FindElement(By.Id("FieldTitle"));
                fieldTitle.Click();
                var title = fieldTitle.FindElement(By.Name("title"));
                //タイトルを書き換える
                var titleValue = title.GetAttribute("value");
                title.Clear();
                title.SendKeys("aaa");
                var submit = fieldTitle.FindElement(By.CssSelector("button[type=submit]"));
                submit.Click();


            }

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