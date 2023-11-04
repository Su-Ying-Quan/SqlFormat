
using System.Runtime.CompilerServices;

namespace SqlFormat
{
    public class SqlFormat
    {
        private IniManager IniManager { get; set; }
        private Setting Setting { get; set; }
        private string TargetFilePath { get; set; }
        private List<string> KeyWords { get; set; }

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
                    // TODO 是否需要只讀一部份文字
                    string[] f = File.ReadAllLines(this.TargetFilePath);
                    List<string> data = f.ToList();
                    // this.FourLine(li);
                    this.OneLine(ref data);
                    data.Remove("");
                    this.TargetFormat(data);
                    // File.WriteAllText(this.TargetFilePath, string.Empty);
                    File.WriteAllLines(this.TargetFilePath, data.ToArray());
                }
            }
            catch (FileNotFoundException fe)
            {
                Console.WriteLine(fe);
            }
        }
        private void OneLine(ref List<string> li)
        {
            li = li[0].Split(' ').ToList();
        }

        private void TargetFormat(List<string> li)
        {
            //確認分號
            for (int i = 0; i < li.Count; i++)
            {
                li[i] = li[i].Trim();
                if (this.KeyWords.Contains(li[i].ToLower()))
                {
                    li[i] = li[i].ToUpper();
                }
                else
                {
                    li[i] = this.Space() + li[i];
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
}