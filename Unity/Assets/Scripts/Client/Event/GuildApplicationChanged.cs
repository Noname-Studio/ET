using System.Collections.Generic;
using ET;

namespace Client.Event
{
    public struct GuildApplicationChanged : IEventHandle
    {
        public IReadOnlyList<ApplicationInfo> ApplicationInfos;
        public GuildApplicationChanged(List<ApplicationInfo> list)
        {
            ApplicationInfos = list.AsReadOnly();
        }
    }
}