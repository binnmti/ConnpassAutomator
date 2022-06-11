namespace ConnpassAutomator
{
    public class Setting
    {
        public Setting() { }
        public Credential Credential { get; set; } = new();
        public IList<Project> Projects { get; set; } = new List<Project>();

        //TODO:デフォルトのSettingをどうするか
        static public Setting CreateDefault() => new();
    }

    public class Credential
    {
        public Credential() { }
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class Project
    {
        public Project() { }
        public CopySource CopySource { get; set; } = new CopySource();
        public Changeset Changeset { get; set; } = new Changeset();

        public static Project CreateDefault() => new();
    }

    public class CopySource
    {
        public CopySource() { }
        public string EventTitle { get; set; } = "";
    }

    public class Changeset
    {
        public Changeset() { }
        public string EventTitle { get; set; } = "";
        public string SubEventTitle { get; set; } = "";
        public string StartDate { get; set; } = "";
        public string StartTime { get; set; } = "";
        public string EndDate { get; set; } = "";
        public string EndTime { get; set; } = "";
        public string Explanation { get; set; } = "";
    }
}
