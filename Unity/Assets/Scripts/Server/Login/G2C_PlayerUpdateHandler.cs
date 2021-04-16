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
            if (message.PlayerId.HasValue)
            {
                PlayerManager.Inst.Id = message.PlayerId.Value;
                DBManager.Inst.UserId = message.PlayerId.Value;
            }
            if (message.GuildId.HasValue)
            {
                PlayerManager.Inst.GuildId = message.GuildId.Value;
                if (PlayerManager.Inst.GuildId == 0)
                    GuildManager.Inst.Data = null;
            }
            if (message.GuildInviteList.Count > 0)
            {
                PlayerManager.Inst.GuildInvite.AddRange(message.GuildInviteList);
                MessageKit.Inst.Send(new GuildInviteListChanged(message.GuildInviteList));
            }
            else if(message.GuildInviteList == null)
            {
                PlayerManager.Inst.GuildInvite.Clear();
            }
            await ETTask.CompletedTask;
        }
    }
}
