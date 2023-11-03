using SqlFormat.Helper;

string text = "select * from Employee;";

await FileHelper.FileWriteAsync("test.sql", text);
await FileHelper.FileReadAsync("test.sql");