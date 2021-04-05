using System;

namespace ET
{
    [MessageHandler]
    public class C2M_GuildGiveEnergyHandler : AMRpcHandler<C2M_GuildGiveEnergyRequest,M2C_GuildGiveEnergyResponse>
    {
        protected override async ETTask Run(Session session, C2M_GuildGiveEnergyRequest request, M2C_GuildGiveEnergyResponse response, Action reply)
        {
            try
            {
                var player = session.GetComponent<SessionPlayerComponent>().Player;
                var guild = GuildComponent.Instance.Get(player.GuildId);
                for (int i = 0; i < guild.AskEnergyList.Count; i++)
                {
                    if (guild.AskEnergyList[i].Id == request.PlayerId)
                    {
                        guild.AskEnergyList[i].Count += 1;
                        
                        var update = new M2C_GuildUpdate();
                        update.AskEnergyList.Add(guild.AskEnergyList[i]);
                        foreach (var node in guild.Members)
                        {
                            var member = PlayerComponent.Instance.Get(node.Id);
                            if(member != null)
                                MessageHelper.SendToLocationActor(member.UnitId, update);
                        }

                        break;
                    }
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