namespace SqlFormat.Helper;

public static class FileHelper
{
    public static async Task FileWriteAsync(string filePath, string text)
    {
        await File.WriteAllTextAsync(filePath, text);
        await Console.Out.WriteLineAsync("檔案寫入完畢\n");
    }

    public static async Task FileReadAsync(string filePath)
    {
        string text = await File.ReadAllTextAsync(filePath);
        await Console.Out.WriteLineAsync(text);
        await Console.Out.WriteLineAsync("檔案讀取完畢");
    }
}
