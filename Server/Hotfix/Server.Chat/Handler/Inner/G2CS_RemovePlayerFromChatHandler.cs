using System;
using ET.Server.Chat;
using ET.Server.Chat.Component;

namespace ET
{
    [ActorMessageHandler]
    public class G2CS_RemovePlayerFromChatHandler : AMActorLocationRpcHandler<ChatUnit,G2CS_RemovePlayerFromChat,CS2G_RemovePlayerFromChat>
    {
        protected override async ETTask Run(ChatUnit unit, G2CS_RemovePlayerFromChat request, CS2G_RemovePlayerFromChat response, Action reply)
        {
            if (request.Type == (int)ChatHelper.Type.Guild)
            {
                unit.Scene.GetComponent<ChatChannelComponent>().RemovePlayerFromGuildChannel(request.GuildId, unit);
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}