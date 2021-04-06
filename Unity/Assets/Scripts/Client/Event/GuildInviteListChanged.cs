using System.Collections.Generic;
using ET;

namespace Client.Event
{
    public struct GuildInviteListChanged : IEventHandle
    {
        public List<GuildInviteInfo> InviteInfos;

        public GuildInviteListChanged(List<GuildInviteInfo> list)
        {
            InviteInfos = list;
        }
    }
}