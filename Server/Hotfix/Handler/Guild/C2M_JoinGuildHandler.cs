using System;

namespace ET
{
    [MessageHandler]
    public class C2M_JoinGuildHandler : AMRpcHandler<C2M_JoinGuild,M2C_JoinGuild>
    {
        protected override async ETTask Run(Session session, C2M_JoinGuild request, M2C_JoinGuild response, Action reply)
        {
            var player = session.GetComponent<SessionPlayerComponent>().Player;
            var guild = await DBComponent.Instance.Query<Data_Guild>(request.Id);
            if (guild == null)
            {
                response.Error = ErrorCode.ERR_MissingGuild;
                response.Message = "找不到公会";
            }
            else if (player.GuildId != 0)
            {
                response.Error = ErrorCode.ERR_JoinedGuild;
                response.Message = "已加入公会";
            }
            else
            {
                if (!(guild.IsPublic ?? true))
                {
                    var time = DateTime.UtcNow.Ticks;
                    guild.ApplicationList.Add(new ApplicationInfo
                    {
                        Id = player.Id,
                        Time = time,
                    });
                    GuildComponent.Instance.MarkDirty(guild);
                    //我们看看会长在不在.如果会长在的话就把申请信息推送给他,不在的话等下次登录的话会跟随Update推送
                    if (guild.OwnerId.HasValue)
                    {
                        var owner = PlayerComponent.Instance.Get(guild.OwnerId.Value);
                        if (owner != null)
                        {
                            var update = new M2C_GuildUpdate();
                            update.ApplicationList.Add(new ApplicationInfo{Id = player.Id,Time = time});
                            MessageHelper.SendToLocationActor(owner.UnitId, update);
                        }
                    }
                }
                else
                {
                    var newMember = new MemberInfo
                    {
                        Hornor = 0,
                        DressUp = player.DressUp,
                        Icon = player.Head,
                        Id = player.Id,
                        JoinTime = DateTime.UtcNow.Ticks,
                        Language = player.Language,
                        LastLogin = -1,
                        Level = player.CurLevel,
                        Name = player.Name
                    };
                    guild.Members.Add(newMember);
                    var update = new M2C_GuildUpdate();
                    update.Members.Add(newMember);
                    foreach (var node in guild.Members)
                    {
                        var member = PlayerComponent.Instance.Get(node.Id);
                        MessageHelper.SendToLocationActor(member.UnitId, update);
                    }
                    GuildComponent.Instance.MarkDirty(guild);
                }
            }
            reply();
        }
    }
}