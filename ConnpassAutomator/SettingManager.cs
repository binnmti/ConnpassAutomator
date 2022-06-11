using System.Diagnostics;
using System.Text.Json;

namespace ConnpassAutomator;

/// <summary>
/// セーブ、ロードの責務を持つ
/// </summary>
public class SettingManager
{
    public static Setting Load()
    {
        var filePath = GetFilePath();
        try
        {
            using var stream = File.Open(filePath, FileMode.Open);
            var data = JsonSerializer.Deserialize<Setting>(stream);
            Trace.Assert(data != null);
            return data!;
        }
        catch(FileNotFoundException /*ex*/)
        {
            return Setting.CreateDefault();
        }
    }

    public static void Save(Setting setting)
    {
        var filePath = GetFilePath();
        // 例外はそのまま外に出す
        using var stream = File.Open(filePath, FileMode.Create);
        JsonSerializer.Serialize(stream, setting);
    }

    private static string GetFilePath()
    {
        var dirPath = AppContext.BaseDirectory;
        var fileName = "ConnpassAutomator.json";
        var filePath = Path.Join(dirPath, fileName);
        return filePath;
    }
}
