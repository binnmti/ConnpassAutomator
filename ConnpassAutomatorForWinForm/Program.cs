using System.Globalization;

namespace ConnpassAutomatorForWinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //“ú–{Œê‚µ‚©‹–‚³‚È‚¢
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("ja-JP");
            CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("ja-JP");
            Application.Run(new MainForm());
        }
    }
}