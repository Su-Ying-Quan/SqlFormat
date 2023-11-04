namespace SqlFormat;

public class Setting
{
    /// <summary>
    /// 縮排控制
    /// </summary>
    public int Indent { get; set; }
    /// <summary>
    /// FROM後面的Table是否要換行
    /// </summary>
    public bool TableChangeLine { get; set; }
}
