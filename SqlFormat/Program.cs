using SqlFormat.Helper;

string text = "select * from test;";

await FileHelper.FileWriteAsync("test.sql", text);
await FileHelper.FileReadAsync("test.sql");