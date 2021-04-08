using System;

namespace ET
{
    [MessageHandler]
    public class C2G_TransferGuildPresidentHandler : AMRpcHandler<C2G_TransferGuildPresident,G2C_TransferGuildPresident>
    {
        protected override async ETTask Run(Session session, C2G_TransferGuildPresident request, G2C_TransferGuildPresident response, Action reply)
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
                guild.OwnerId = request.PlayerId;
                var update = new M2C_GuildUpdate{OwnerId = request.PlayerId};
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