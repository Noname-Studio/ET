using System;

namespace ET
{
    public class C2M_GuildGetRecommendedPlayersHandler : AMRpcHandler<C2G_GuildGetRecommendedPlayers,G2C_GuildGetRecommendedPlayers>
    {
        protected override async ETTask Run(Session session, C2G_GuildGetRecommendedPlayers request, G2C_GuildGetRecommendedPlayers response, Action reply)
        {
            var players = PlayerComponent.Instance.GetNotJoinedGuildPlayer(session, 10);
            var player = session.GetComponent<SessionPlayerComponent>().Player;
            foreach (var node in players)
            {
                if (node.Id == player.Id)
                    continue;
                response.Players.Add(new RecommendedPlayersInfo
                {
                    Id = node.Id,
                    Head = node.Head,
                    Name = node.Name,
                });
            }
            reply();
            await ETTask.CompletedTask;
        }
    }
}