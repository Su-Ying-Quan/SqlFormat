namespace SqlFormat;

public class SqlFormat
{
    /// <summary>
    /// Ini黨的控制物件
    /// </summary>
    private IniManager IniManager { get; set; }
    /// <summary>
    /// User需要的目標格式持有物件
    /// </summary>
    private Setting Setting { get; set; }
    private string TargetFilePath { get; set; }
    private List<string> KeyWords { get; set; }
    private List<string> Data { get; set; }

    public SqlFormat(string[] args)
    {
        this.KeyWords = new List<string>(){
            "select",
            "from"
        };
        try
        {
            this.IniManager = new IniManager(out Setting s);
            this.Setting = s;
            this.TargetFilePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), args[0]);
            if (File.Exists(this.TargetFilePath))
            {
                // 讀取檔案後轉換為內定的資料格式 
                this.ConvertRawContent(File.ReadAllLines(this.TargetFilePath));

                // 將內定資料格式轉換為User想要的目標格式
                this.TargetFormat();

                // 將目標格式陣列寫進檔案內
                File.WriteAllLines(this.TargetFilePath, this.Data.ToArray());
            }
        }
        catch (FileNotFoundException fe)
        {
            Console.WriteLine(fe);
        }
        catch (ArgumentOutOfRangeException ae)
        {
            Console.WriteLine(ae);
        }
    }
    /// <summary>
    /// 轉換原始檔案的內容為內定的資料格式
    /// </summary>
    /// <param name="source">從檔案讀取出來的字串陣列</param>
    public void ConvertRawContent(string[] source)
    {
        // 對原先的字串陣列當中每個元素做調整添加空格的部分並處理分號為獨立元素
        for (int i = 0; i < source.Length; i++)
        {
            if (i == source.Length - 1)
            {
                if (source[i].Contains(';'))
                {
                    source[i] = string.Concat(source[i].AsSpan(0, source[i].Length - 2), " ; ");
                }
                else
                {
                    source[i] += " ; ";
                }
            }
            else
            {
                source[i] += " ";
            }
        }

        // 合併字串陣列當中每個添加空白間格的元素為一個字串，並分割為陣列後轉為List
        this.Data = string.Join(" ", source.Select(v => v)).Split(" ").ToList();

        // 移除所有空的元素
        this.Data.RemoveAll(e => e == "");
    }

    private void TargetFormat()
    {
        //確認分號
        for (int i = 0; i < this.Data.Count; i++)
        {
            this.Data[i] = this.Data[i].Trim();
            if (this.KeyWords.Contains(this.Data[i].ToLower()))
            {
                this.Data[i] = this.Data[i].ToUpper();
            }
            else
            {
                this.Data[i] = this.Space() + this.Data[i];
            }
        }
    }

    private string Space()
    {
        string s = "";
        for (var _ = 0; _ < this.Setting.Indent; _++)
        {
            s += " ";
        }
        return s;
    }
}