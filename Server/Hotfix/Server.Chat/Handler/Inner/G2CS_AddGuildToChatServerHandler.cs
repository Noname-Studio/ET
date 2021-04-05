using System;
using ET.Server.Chat.Component;

namespace ET
{
    [ActorMessageHandler]
    public class G2CS_AddGuildToChatServerHandler : AMActorRpcHandler<Scene, G2CS_AddGuildToChatServer, CS2G_AddGuildToChatServer>
    {
        protected override async ETTask Run(Scene scene, G2CS_AddGuildToChatServer request, CS2G_AddGuildToChatServer response, Action reply)
        {
            await scene.GetComponent<ChatChannelComponent>().AddGuildChannel(request.GuildId);
            reply();
        }
    }
}