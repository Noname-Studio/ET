using ET;

namespace Client.Logic.Guild
{
    public class G2C_GuildUpdateHandler : AMHandler<M2C_GuildUpdate>
    {
        protected override async ETVoid Run(Session session, M2C_GuildUpdate message)
        {
            GuildManager.Inst.Data = message;
        }
    }
}