using IniParser;
using IniParser.Model;

namespace SqlFormat;

public class IniManager
{
    /// <summary>
    /// Ini檔的控制物件 
    /// </summary>
    private FileIniDataParser FileIniDataParser { get; set; }
    /// <summary>
    /// 設定檔路徑
    /// </summary>
    private string ConfigFile { get; set; } = @".\config.ini";
    public IniManager(out Setting setting)
    {
        setting = new Setting();
        this.FileIniDataParser = new FileIniDataParser();
        if (File.Exists(this.ConfigFile))
        {
            IniData data = this.FileIniDataParser.ReadFile(this.ConfigFile);
            setting.Indent = int.Parse(data["Basic"]["Indent"]);
            setting.TableChangeLine = bool.Parse(data["Basic"]["TableChangeLine"]);
        }
        else
        {
            IniData data = new IniData();
            setting.Indent = 8;
            setting.TableChangeLine = false;
            data["Basic"]["Indent"] = setting.Indent.ToString();
            data["Basic"]["TableChangeLine"] = setting.TableChangeLine.ToString();
            this.FileIniDataParser.WriteFile(this.ConfigFile, data);
        }
    }
}