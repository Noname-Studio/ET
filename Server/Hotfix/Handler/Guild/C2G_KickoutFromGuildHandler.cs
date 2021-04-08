using System;

namespace ET
{
    [MessageHandler]
    public class C2G_KickoutFromGuildHandler : AMRpcHandler<C2G_KickoutFromGuild,G2C_KickoutFromGuild>
    {
        protected override async ETTask Run(Session session, C2G_KickoutFromGuild request, G2C_KickoutFromGuild response, Action reply)
        {
            var player = session.GetComponent<SessionPlayerComponent>().Player;
            var guild = GuildComponent.Instance.Get(player.GuildId);
            if (guild == null)
            {
                reply();
                return;
            }

            if (player.Id == guild.OwnerId)
            {
                guild.Members.RemoveAll(t1 => t1.Id == request.PlayerId);
                var targetPlayer = PlayerComponent.Instance.Get(request.PlayerId);
                if (targetPlayer != null)
                    guild.ActivePlayers.Remove(targetPlayer.UnitId);
                MessageHelper.SendToLocationActor(targetPlayer.UnitId, new G2C_PlayerUpdate { GuildId = 0, GuildInviteList = null });
                var update = new M2C_GuildUpdate();
                update.RemoveMembers.Add(request.PlayerId);
                foreach (var node in guild.ActivePlayers)
                {
                    MessageHelper.SendToLocationActor(node.Key, update);
                }
            }
            reply();
            await ETTask.CompletedTask;
        }
    }
}