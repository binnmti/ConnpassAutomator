namespace ConnpassAutomator
{
    public class ConnpassWillbeRenamed
    {
        public ConnpassWillbeRenamed() { }
        public Credential Credential { get; set; } = new();
        public IList<Project> Projects { get; set; } = new List<Project>();
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
