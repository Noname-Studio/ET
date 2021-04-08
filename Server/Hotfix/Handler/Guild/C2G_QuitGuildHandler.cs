using System;

namespace ET
{
    [MessageHandler]
    public class C2G_QuitGuildHandler : AMRpcHandler<C2G_QuitGuild,G2C_QuitGuild>
    {
        protected override async ETTask Run(Session session, C2G_QuitGuild request, G2C_QuitGuild response, Action reply)
        {
            var player = session.GetComponent<SessionPlayerComponent>().Player;
            var guild = GuildComponent.Instance.Get(player.GuildId);
            player.GuildId = 0;
            if (guild != null)
            {
                guild.Members.RemoveAll(info => info.Id == player.Id);
                guild.ActivePlayers.Remove(player.UnitId);
                if (guild.Members.Count > 0)
                {
                    guild.OwnerId = guild.Members[0].Id;
                    var update = new M2C_GuildUpdate();
                    update.OwnerId = guild.OwnerId;
                    update.RemoveMembers.Add(player.Id);
                    foreach (var node in guild.ActivePlayers)
                    {
                        MessageHelper.SendToLocationActor(node.Key, update);
                    }
                }
                else
                {
                    GuildComponent.Instance.Remove(guild.Id);
                    await DBComponent.Instance.Remove<Data_Guild>(guild.Id);
                }
            }

            session.Send(new G2C_PlayerUpdate { GuildId = 0, GuildInviteList = null });
            reply();
        }
    }
}