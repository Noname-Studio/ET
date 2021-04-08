using System;
using Model.Module.DB.ActualTable;

namespace ET
{
    [MessageHandler]
    public class C2G_HandleApplicationHandler : AMRpcHandler<C2G_HandleApplication,G2C_HandleApplication>
    {
        protected override async ETTask Run(Session session, C2G_HandleApplication request, G2C_HandleApplication response, Action reply)
        {
            var myPlayer = session.GetComponent<SessionPlayerComponent>().Player;
            var guild = GuildComponent.Instance.Get(myPlayer.GuildId);
            if (request.Approve)
            {
                Data_PlayerInfo targetPlayer = await CacheHelper.Get<Data_PlayerInfo>(request.PlayerId);
                var newMember = new MemberInfo
                {
                    Icon = targetPlayer.Head,
                    Id = targetPlayer.Id,
                    Level = targetPlayer.CurLevel,
                    Language = targetPlayer.Language,
                    Name = targetPlayer.Name,
                    DressUp = targetPlayer.DressUp,
                    LastLogin = targetPlayer.IsActive ? 0 : targetPlayer.LastLogin,
                    Hornor = 0,
                    JoinTime = TimeHelper.ServerTimeStamp()
                };
                
                var update = new M2C_GuildUpdate();
                update.RemoveApplicationList.Add(request.PlayerId);
                update.Members.Add(newMember);

                foreach (var node in guild.Members)
                {
                    ActorLocationSenderComponent.Instance.Send(node.Id, update);
                }
                
                guild.Members.Add(newMember);
                ActorLocationSenderComponent.Instance.Send(targetPlayer.UnitId, guild.CreateGuildUpdateProto());
                await targetPlayer.JoinGuild(guild);
            }
            guild.ApplicationList.RemoveAll(t1 => t1.Id == request.PlayerId);
            GuildComponent.Instance.MarkDirty(guild);

            reply();
            //request.PlayerId
        }
    }
}