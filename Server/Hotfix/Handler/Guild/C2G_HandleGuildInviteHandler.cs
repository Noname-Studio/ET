using System;

namespace ET
{
    [MessageHandler]
    public class C2G_HandleGuildInviteHandler : AMRpcHandler<C2G_HandleGuildInvite,G2C_HandleGuildInvite>
    {
        protected override async ETTask Run(Session session, C2G_HandleGuildInvite request, G2C_HandleGuildInvite response, Action reply)
        {
            var myPlayer = session.GetComponent<SessionPlayerComponent>().Player;
            if (request.Approve)
            {
                var newMember = new MemberInfo
                {
                    Icon = myPlayer.Head,
                    Id = myPlayer.Id,
                    Level = myPlayer.CurLevel,
                    Language = myPlayer.Language,
                    Name = myPlayer.Name,
                    DressUp = myPlayer.DressUp,
                    LastLogin = myPlayer.IsActive ? 0 : myPlayer.LastLogin,
                    Hornor = 0,
                    JoinTime = TimeHelper.ServerTimeStamp()
                };
                var guild = GuildComponent.Instance.Get(request.GuildId);
                
                var update = new M2C_GuildUpdate();
                update.RemoveApplicationList.Add(myPlayer.Id);
                update.Members.Add(newMember);

                foreach (var node in guild.Members)
                {
                    ActorLocationSenderComponent.Instance.Send(node.Id, update);
                }
                
                guild.ApplicationList.RemoveAll(t1 => t1.Id == myPlayer.Id);
                guild.Members.Add(newMember);
                GuildComponent.Instance.MarkDirty(guild);
                ActorLocationSenderComponent.Instance.Send(myPlayer.UnitId, guild.CreateGuildUpdateProto());
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}