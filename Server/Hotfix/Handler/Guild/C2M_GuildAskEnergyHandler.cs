﻿using System;

namespace ET
{
    [MessageHandler]
    public class C2M_GuildAskEnergyHandler : AMRpcHandler<C2G_GuildAskEnergyRequest,G2C_GuildAskEnergyResponse>
    {
        protected override async ETTask Run(Session session, C2G_GuildAskEnergyRequest request, G2C_GuildAskEnergyResponse response, Action reply)
        {
            try
            {
                var player = session.GetComponent<SessionPlayerComponent>().Player;
                var guild = GuildComponent.Instance.Get(player.GuildId);
                for (int i = 0; i < guild.AskEnergyList.Count; i++)
                {
                    if (guild.AskEnergyList[i].Id == player.Id)
                    {
                        reply();
                        return;
                    }
                }

                var askEnergy = new AskEnergyInfo
                {
                    Count = 0,
                    Id = player.Id,
                    Time = TimeHelper.ServerNow(),
                    Head = player.Head,
                    Name = player.Name
                };
                
                guild.AskEnergyList.Add(askEnergy);
                
                var update = new M2C_GuildUpdate();
                update.AskEnergyList.Add(askEnergy);
                foreach (var node in guild.ActivePlayers)
                {
                    MessageHelper.SendToLocationActor(node.Key, update);
                }
                
            }
            catch(Exception e)
            {
                response.Error = ErrorCode.ERR_Exception;
                response.Message = e.Message;
            }
            
            reply();
            await ETTask.CompletedTask;
        }
    }
}