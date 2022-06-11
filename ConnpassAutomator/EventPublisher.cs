using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConnpassAutomator
{
    public class EventPublisher
    {
        private readonly string chromeDriverDirectory;

        public EventPublisher(string chromeDriverDirectory)
        {
            this.chromeDriverDirectory = chromeDriverDirectory;
        }

        public void Publish(Project project, Credential credential)
        {
            CopyAndSetAndPublishEventToConnpassWebSite(credential, project, chromeDriverDirectory);
        }

        // TODO: 責務を private メソッドに分離
        private void CopyAndSetAndPublishEventToConnpassWebSite(Credential credential, Project project, string chromeDriverDirectory)
        {

            using var Driver = new ChromeDriver(chromeDriverDirectory, new ChromeOptions(), TimeSpan.FromSeconds(120))
            {
                Url = "https://connpass.com/editmanage/"
            };
            // classlib
            var DriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60))
            {
                PollingInterval = TimeSpan.FromSeconds(1),
            };
            DriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            Driver.FindElement(By.Name("username")).SendKeys(credential.UserName);
            Driver.FindElement(By.Name("password")).SendKeys(credential.Password);
            Driver.FindElement(By.Id("login_form")).Submit();

            //TODO:さて
            Thread.Sleep(1000);

            // connpass の Web サイト固有事情

            var elements = Driver.FindElements(By.ClassName("event_list"));
            foreach (var element in elements)
            {
                //label_status_event mb_5 close 終了
                var status = element.FindElement(By.ClassName("label_status_event")).Text;

                //C#によるマルチコアのための非同期/並列処理プログラミング Zoomオンライン読書会 vol.5;
                var title = element.FindElement(By.CssSelector(".title > a")).Text;
                if (title.Contains(project.CopySource.EventTitle) && status == "終了")
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

            // この時点で connpass のイベント編集画面のはず

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
                title.SendKeys(project.Changeset.EventTitle);

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
                title.SendKeys(project.Changeset.SubEventTitle);

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
                startDate.SendKeys(project.Changeset.StartDate);
                startDate.SendKeys("\t");

                //中身の文字
                var startTime = fieldTitle.FindElement(By.Name("start_time"));
                startTime.Clear();
                startTime.SendKeys(project.Changeset.StartTime);
                startTime.SendKeys("\t");

                var endDate = fieldTitle.FindElement(By.Name("end_date"));
                endDate.Clear();
                endDate.SendKeys(project.Changeset.EndDate);
                endDate.SendKeys("\t");

                //中身の文字
                var endTime = fieldTitle.FindElement(By.Name("end_time"));
                endTime.Clear();
                endTime.SendKeys(project.Changeset.EndTime);
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
                title.SendKeys(project.Changeset.Explanation);
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
        }

    }

}
