using System;
using Model.Module.DB.ActualTable;

namespace ET
{
    [MessageHandler]
    public class C2G_ChatMessageHandler : AMRpcHandler<C2G_ChatMessage, G2C_ChatMessage>
    {
        protected override async ETTask Run(Session session, C2G_ChatMessage request, G2C_ChatMessage response, Action reply)
        {
            Data_PlayerInfo player = session.GetComponent<SessionPlayerComponent>().Player;
            //0世界频道,1公会频道,2私聊频道
            if (request.Type == 1)
            {
                MessageHelper.SendToLocationActor(player.ChatId,new G2CS_SendGuildMessage
                {
                    GuildId = player.GuildId,
                    Time = TimeHelper.ServerNow(),
                    SenderId = player.Id,
                    SenderMsg = request.SendMessage,
                    SenderName = player.Name
                });
            }
            await ETTask.CompletedTask;
        }
    }
}