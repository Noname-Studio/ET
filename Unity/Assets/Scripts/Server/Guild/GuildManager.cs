using System.Collections.Generic;
using Client.Event;
using ET;
using Manager;

public class GuildManager: Singleton<GuildManager>
{
    /// <summary>
    /// 公会的大部分信息的封装
    /// </summary>
    public M2C_GuildUpdate Data { get; set; }

    public List<CS2C_GuildMessageChanged> GuildMessage { get; } = new List<CS2C_GuildMessageChanged>();
    
    private GuildManager()
    {
    }
    public override void OnRelease()
    {
        base.OnRelease();
    }

    public void AddGuildMessage(CS2C_GuildMessageChanged message)
    {
        GuildMessage.Add(message);
        MessageKit.Inst.Send(new GuildMessageChanged(message));
    }

    public bool IsJoined()
    {
        if (Data == null || Data.Id == 0)
        {
            return false;
        }

        return true;
    }
}