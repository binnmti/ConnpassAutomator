namespace ConnpassAutomator;

/// <summary>
/// セーブ、ロードの責務を持つ
/// </summary>
public class SettingManager
{
    public static ConnpassWillbeRenamed Load()
    {
        return new ConnpassWillbeRenamed();
    }

    public static void Save(ConnpassWillbeRenamed connpassWillbeRenamed)
    {
    }
}
