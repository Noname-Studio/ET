using System.Collections;
using System.Collections.Generic;
using Client.Event;
using UnityEngine;

namespace ET
{
    [MessageHandler]
    public class G2C_PlayerUpdateHandler : AMHandler<G2C_PlayerUpdate>
    {
        protected override async ETVoid Run(Session session, G2C_PlayerUpdate message)
        {
            if(message.PlayerId.HasValue)
                PlayerManager.Id = message.PlayerId.Value;
            if (message.GuildInviteList != null && message.GuildInviteList.Count > 0)
            {
                PlayerManager.Inst.GuildInvite.AddRange(message.GuildInviteList);
                MessageKit.Inst.Send(new GuildInviteListChanged(message.GuildInviteList));
            }
            await ETTask.CompletedTask;
        }
    }
}
