using System.Collections.Generic;

namespace ET.Server.Chat.Component
{
    public class ChatChannelComponent : Entity
    {
        /// <summary>
        /// 公会频道.
        /// 网关服务器可以通过公会ID发送内容给公会内的其他成员
        /// </summary>
        public Dictionary<long, GuildChatInfo> GuildDict = new Dictionary<long, GuildChatInfo>();
        /// <summary>
        /// 世界频道
        /// </summary>
        public HashSet<ChatUnit> WorldDict = new HashSet<ChatUnit>();
        /// <summary>
        /// 队伍频道
        /// </summary>
        public Dictionary<long, List<ChatUnit>> TeamDict = new Dictionary<long, List<ChatUnit>>();
    }
}