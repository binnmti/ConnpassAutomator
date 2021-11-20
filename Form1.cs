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
            Driver = new ChromeDriver(baseDir, new ChromeOptions(), TimeSpan.FromSeconds(120));
            Driver.Url = "https://connpass.com/editmanage/";
        }
    }
}