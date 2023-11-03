namespace SqlFormat
{
    public class SqlFormat
    {
        private string ConfigFile { get; set; } = @".\config.ini";
        public SqlFormat(string[] args)
        {
            try
            {
                // Load Config File 
                if (File.Exists(this.ConfigFile))
                {
                    var config = File.ReadAllLines(@".\config.ini");
                }
                else
                {
                    File.Create(this.ConfigFile);
                }
            }
            catch (FileNotFoundException)
            {

            }


        }
    }
}