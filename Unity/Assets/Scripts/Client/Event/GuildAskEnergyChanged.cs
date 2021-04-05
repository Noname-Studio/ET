using System;
using System.Collections.Generic;
using ET;

namespace Client.Event
{
    public struct GuildAskEnergyChanged : IEventHandle
    {
        public List<AskEnergyInfo> List;
        
        public GuildAskEnergyChanged(List<AskEnergyInfo> list)
        {
            List = list ?? throw new Exception("List不能为空");
        }        
    }
}