namespace ET
{
    [MessageHandler]
    public class M2C_GuildUpdateHandler : AMHandler<M2C_GuildUpdate>
    {
        protected override async ETVoid Run(Session session, M2C_GuildUpdate message)
        {
            GuildManager.Inst.Data = message;
        }
    }
}