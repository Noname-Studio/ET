using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    [MessageHandler]
    public class G2C_LoginGateHandler : AMHandler<G2C_LoginGate>
    {
        protected override async ETVoid Run(Session session, G2C_LoginGate message)
        {
            PlayerManager.Id = message.PlayerId;
            await ETTask.CompletedTask;
        }
    }
}
