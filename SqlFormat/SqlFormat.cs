
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
                    string[] f = File.ReadAllLines(this.TargetFilePath);
                    List<string> li = f.ToList();
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
                    File.WriteAllText(this.TargetFilePath, string.Empty);
                    File.WriteAllLines(this.TargetFilePath, li.ToArray());
                }
            }
            catch (FileNotFoundException fe)
            {
                Console.WriteLine(fe);
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