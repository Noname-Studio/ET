using System.Collections.Generic;

namespace ET.Server.Chat.Component
{
    public static class ChatChannelComponentHelper
    {
        public static async ETTask AddGuildChannel(this ChatChannelComponent self,long guildId)
        {
            if (!self.GuildDict.ContainsKey(guildId))
            {
                self.GuildDict.Add(guildId,new GuildChatInfo
                {
                    Data = await DBComponent.Instance.Query<Data_Guild_Chat>(guildId) ?? new Data_Guild_Chat(),
                    User = new List<ChatUnit>()
                });
            }
        }

        public static void RemoveGuildChannel(this ChatChannelComponent self,long guildId)
        {
            if (self.GuildDict.ContainsKey(guildId))
            {
                self.GuildDict.Remove(guildId);
            }
        }

        public static GuildChatInfo AddPlayerToGuildChannel(this ChatChannelComponent self, long guildId, ChatUnit unit)
        {
            if (self.GuildDict.TryGetValue(guildId, out var info))
            {
                info.User.Add(unit);
            }

            return info;
        }

        public static void RemovePlayerFromGuildChannel(this ChatChannelComponent self, long guildId, ChatUnit unit)
        {
            if (self.GuildDict.TryGetValue(guildId, out var info))
            {
                info.User.Remove(unit);
            }
        }
    }
}