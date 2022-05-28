using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace ConnpassAutomator;

/// <summary>
/// セーブ、ロードの責務を持つ
/// </summary>
public class SettingManager
{
    /*
     * 永続化の場所
     *  ・決定?：実行ファイルと同じディレクトリ（デバッグ時のフォルダ違いに注意）
     *  ・別解：ホームディレクトリ
     *  
     *  ・別解：OSごとのお作法に従う
     *  
     *  読み取り権限がない場合にどうする？
     *  例外出したときどうする？
     *      FileNotFoundException以外は出たものそのまま出す
     *      
     *  デフォルトのConnpassWillbeRenamedをどうするか問題
     *      Projectの件数とか
     */
    public static ConnpassWillbeRenamed Load()
    {
        var filePath = GetFilePath();
        try
        {
            using var stream = File.Open(filePath, FileMode.Open);
            // Deserializeの戻り型がnullable
            //data = JsonSerializer.Deserialize<ConnpassWillbeRenamed>(stream) ?? ConnpassWillbeRenamed.CreateDefault();

            var data = JsonSerializer.Deserialize<ConnpassWillbeRenamed>(stream);
            Trace.Assert(data != null);
            return data!;
        }
        catch(FileNotFoundException /*ex*/)
        {
            return ConnpassWillbeRenamed.CreateDefault();
        }
    }

    public static void Save(ConnpassWillbeRenamed connpassWillbeRenamed)
    {
        var filePath = GetFilePath();
        // 例外はそのまま外に出す
        using var stream = File.Open(filePath, FileMode.Create);
        JsonSerializer.Serialize(stream, connpassWillbeRenamed);
    }

    private static string GetFilePath()
    {
        var dirPath = AppContext.BaseDirectory;
        var fileName = "ConnpassAutomator.json";
        var filePath = Path.Join(dirPath, fileName);
        return filePath;
    }
}
