using System;
using ET.Server.Chat;
using ET.Server.Chat.Component;

namespace ET
{
    [ActorMessageHandler]
    public class G2CS_UnRegisterPlayerFromChatHandler : AMActorLocationRpcHandler<ChatUnit,G2CS_UnRegisterPlayerToChat,CS2G_UnRegisterPlayerToChat>
    {
        protected override async ETTask Run(ChatUnit unit, G2CS_UnRegisterPlayerToChat request, CS2G_UnRegisterPlayerToChat response, Action reply)
        {
            var channelComponent = unit.Scene.GetComponent<ChatChannelComponent>();
            if (channelComponent.GuildDict.TryGetValue(unit.GuildId, out var value))
            {
                value.User.Remove(unit);
            }

            channelComponent.WorldDict.Remove(unit);
            unit.Scene.GetComponent<ChatUnitComponent>().Remove(unit.Id);
            await unit.RemoveLocation();
            reply();
            await ETTask.CompletedTask;
        }
    }
}