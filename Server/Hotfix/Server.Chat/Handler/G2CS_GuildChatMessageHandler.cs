using System;
using System.Collections.Generic;
using ET.Server.Chat.Component;
namespace ET
{
    [ActorMessageHandler]
    public class G2CS_GuildChatMessageHandler : AMActorLocationHandler<ChatUnit,G2CS_SendGuildMessage>
    {
        protected override async ETTask Run(ChatUnit unit, G2CS_SendGuildMessage message)
        {
            var channel = unit.Scene.GetComponent<ChatChannelComponent>();
            if (channel.GuildDict.TryGetValue(message.GuildId, out var value))
            {
                var response = new CS2C_GuildMessageChanged
                {
                    Value = new List<ChatMessageInfo>()
                    {
                        new ChatMessageInfo
                        {
                            Time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                            SenderHead = unit.Head,
                            SenderName = unit.Name,
                            SenderId = unit.PlayerId,
                            SenderMsg = message.SenderMsg
                        }
                    }
                };
                foreach (var node in value.User)
                {
                    MessageHelper.SendActor(node.GateSessionId, response);
                }
                value.Data.Msg.Add(new Data_Guild_Chat.ChatInfo
                {
                    Head = unit.Head,
                    Name = unit.Name,
                    Id = unit.PlayerId,
                    Message = message.SenderMsg
                });
            }
            await ETTask.CompletedTask;
        }
    }
}