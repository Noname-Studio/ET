using System;

namespace ET
{
    [MessageHandler]
    public class C2M_ModifyGuildHandler : AMRpcHandler<C2M_ModifyGuild,M2C_ModifyGuild>
    {
        protected override async ETTask Run(Session session, C2M_ModifyGuild request, M2C_ModifyGuild response, Action reply)
        {
            var player = session.GetComponent<SessionPlayerComponent>().Player;
            var guild = GuildComponent.Instance.Get(player.GuildId);
            guild.Desc = request.Desc;
            guild.Frame = request.Frame;
            guild.Inside = request.Inside;
            guild.Language = request.Language;
            guild.Name = request.Name;
            guild.IsPublic = request.IsPublic;
            guild.MinLevel = request.MinLevel;
            reply();
            await ETTask.CompletedTask;
        }
    }
}