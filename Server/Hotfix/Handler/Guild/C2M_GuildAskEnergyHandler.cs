using System;

namespace ET
{
    [MessageHandler]
    public class C2M_GuildAskEnergyHandler : AMRpcHandler<C2M_GuildAskEnergyRequest,M2C_GuildAskEnergyResponse>
    {
        protected override async ETTask Run(Session session, C2M_GuildAskEnergyRequest request, M2C_GuildAskEnergyResponse response, Action reply)
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
                    Head = player.Icon,
                    Name = player.Name
                };
                
                guild.AskEnergyList.Add(askEnergy);
                
                var update = new M2C_GuildUpdate();
                update.AskEnergyList.Add(askEnergy);
                foreach (var node in guild.Members)
                {
                    var member = PlayerComponent.Instance.Get(node.Id);
                    if(member != null)
                        MessageHelper.SendToLocationActor(member.UnitId, update);
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