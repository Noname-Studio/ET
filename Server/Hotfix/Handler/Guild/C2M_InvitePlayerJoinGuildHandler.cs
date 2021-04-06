using System;
using System.Collections.Generic;

namespace ET
{
    public class C2M_InvitePlayerJoinGuildHandler : AMRpcHandler<C2G_InvitePlayerJoinGuild,G2C_InvitePlayerJoinGuild>
    {
        protected override async ETTask Run(Session session, C2G_InvitePlayerJoinGuild request, G2C_InvitePlayerJoinGuild response, Action reply)
        {
            var target = PlayerComponent.Instance.Get(request.PlayerId);
            if (target == null)
            {
                reply();
                return;
            }

            var myPlayer = session.GetComponent<SessionPlayerComponent>().Player;
            var guild = GuildComponent.Instance.Get(myPlayer.GuildId);
            ActorLocationSenderComponent.Instance.Send(target.UnitId,new G2C_PlayerUpdate
            {
                GuildInviteList = new List<GuildInviteInfo>
                {
                    new GuildInviteInfo
                    {
                        GuildId = guild.Id,
                        Name = guild.Name,
                        MemberNum = guild.Members.Count
                    }
                }
            });
            await ETTask.CompletedTask;
        }
    }
}