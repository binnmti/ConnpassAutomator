namespace ConnpassAutomator
{
    public class Setting
    {
        public Setting() { }
        public Credential Credential { get; init; } = new();
        public IList<Project> Projects { get; init; } = new List<Project>();

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
        public CopySource CopySource { get; init; } = new CopySource();
        public Changeset Changeset { get; init; } = new Changeset();

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
