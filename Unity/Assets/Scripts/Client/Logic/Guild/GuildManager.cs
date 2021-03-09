using ET;
using Manager;

public class GuildManager : Singleton<GuildManager>
{
    /// <summary>
    /// 公会的大部分信息的封装
    /// </summary>
    public G2C_GuildUpdate Data;

    public bool IsJoined()
    {
        if (Data == null || this.Data.Id == 0)
            return false;
        return true;
    }
}
