using System;
using System.Collections.Generic;
using MongoDB.Libmongocrypt;

namespace ET
{
    [MessageHandler]
    public class C2M_CreateGuildHandler : AMRpcHandler<C2M_CreateGuild,M2C_CreateGuild>
    {
        protected override async ETTask Run(Session session, C2M_CreateGuild request, M2C_CreateGuild response, Action reply)
        {
            var db = DBComponent.Instance;
            List<Data_Guild> result = await db.Query<Data_Guild>(t => t.Name == request.Name);
            if (result.Count > 0)
            {
                response.Error = ErrorCode.ERR_DuplicateNames;
                response.Message = "名称重复";
            }
            else
            {
                try
                {
                    var player = session.GetComponent<SessionPlayerComponent>().Player;
                    if (player.GuildId != 0)
                    {
                        response.Error = ErrorCode.ERR_JoinedGuild;
                        response.Message = "已经加入公会";
                    }
                    else
                    {
                        var time = DateTime.UtcNow.Ticks;
                        var guild = new Data_Guild
                        {
                            Id = IdGenerater.Instance.GenerateId(),
                            Desc = request.Desc,
                            Frame = request.Frame,
                            Language = request.Language,
                            Name = request.Name,
                            Inside = request.Inside,
                            IsPublic = request.IsPublic,
                            MinLevel = request.MinLevel,
                            OwnerId = player.Id,
                            CreateTime = time,
                        };
                        guild.Members.Add(new MemberInfo
                        {
                            JoinTime = time,
                            LastLogin = -1,
                            Hornor = 0,
                            Icon = player.Head,
                            Level = player.CurLevel,
                            Language = player.Language,
                            Id = player.Id,
                            Name = player.Name,
                            DressUp = player.DressUp,
                        });
                        GuildComponent.Instance.Add(guild);
                        await GuildComponent.Instance.RegisterGuildToChat(guild);
                        player.GuildId = guild.Id;
                        var proto = guild.CreateGuildUpdateProto();
                        session.Send(proto);
                    }
                }
                catch(Exception e)
                {
                    response.Error = ErrorCode.ERR_LogicError;
                    response.Message = e.Message;
                    Log.Error(e.Message);
                }

                reply();
            }
        }
    }
}