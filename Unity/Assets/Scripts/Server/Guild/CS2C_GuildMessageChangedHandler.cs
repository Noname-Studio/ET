using Client.Event;

namespace ET
{
    [MessageHandler]
    public class CS2C_GuildMessageChangedHandler : AMHandler<CS2C_GuildMessageChanged>
    {
        protected override async ETVoid Run(Session session, CS2C_GuildMessageChanged message)
        {
            GuildManager.Inst.AddGuildMessage(message);
            await ETTask.CompletedTask;
        }
    }
}