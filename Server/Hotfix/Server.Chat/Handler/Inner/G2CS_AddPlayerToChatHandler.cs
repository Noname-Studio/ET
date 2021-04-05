using System;
using System.Collections.Generic;
using ET.Server.Chat;
using ET.Server.Chat.Component;

namespace ET
{
    [ActorMessageHandler]
    public class G2CS_AddPlayerToChatHandler : AMActorLocationRpcHandler<ChatUnit,G2CS_AddPlayerToChat,CS2G_AddPlayerToChat>
    {
        protected override async ETTask Run(ChatUnit unit, G2CS_AddPlayerToChat request, CS2G_AddPlayerToChat response, Action reply)
        {
            if (request.Type == (int)ChatHelper.Type.Guild)
            {
                var guild = unit.Scene.GetComponent<ChatChannelComponent>().AddPlayerToGuildChannel(request.GuildId, unit);
                unit.GuildId = request.GuildId;
                //推送聊天信息
                var changed = new CS2C_GuildMessageChanged();
                var list = changed.Value = new List<ChatMessageInfo>();
                foreach (var msg in guild.Data.Msg)
                {
                    list.Add(
                        new ChatMessageInfo
                        {
                            Time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                            SenderHead = msg.Head,
                            SenderName = msg.Name,
                            SenderId = msg.Id,
                            SenderMsg = msg.Message,
                        }
                    );
                }
                MessageHelper.SendActor(unit.GateSessionId, changed);
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}