using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace ET
{
    [MessageHandler]
    public class C2G_SearchGuildHandler : AMRpcHandler<C2M_SearchGuild, M2C_SearchGuild>
    {
        public const int GuildMaxMemberCount = 20;

        protected override async ETTask Run(Session session, C2M_SearchGuild request, M2C_SearchGuild response, Action reply)
        {
            var maxNum = request.MaxNum;
            if (maxNum >= 20)
                maxNum = 20;
            var list = new List<SearchGuildResult>();
            var db = DBComponent.Instance;
            
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                var result = await db.QueryPage(new ExpressionFilterDefinition<Data_Guild>(guild => request.Name == guild.Name
                        && request.Language == guild.Language
                        && request.MinLevel > guild.MinLevel),new SortDefinitionBuilder<Data_Guild>().Ascending(t1=>t1.Name),request.Cursor,maxNum);
                response.TotalPage = result.totalPages;
                foreach (var node in result.data)
                {
                    list.Add(new SearchGuildResult
                    {
                        Desc = node.Desc,
                        Frame = node.Frame,
                        Id = node.Id,
                        Name = node.Name,
                        Outer = node.Outer,
                    });
                }
            }
            else if (request.Id > 10000)
            {
                var data = await db.Query<Data_Guild>(request.Id);
                var result = new SearchGuildResult
                {
                    Desc = data.Desc,
                    Frame = data.Frame,
                    Id = data.Id,
                    Name = data.Name,
                    Outer = data.Outer
                };
                list.Add(result);
            }
            else
            {
                var userInfo = session.GetComponent<SessionPlayerComponent>().Player;
                //我们根据玩家的自身条件筛选一些符合玩家条件的公会推送给玩家
                //如果超出我们筛选的列表.则随机发送公会列表
                var result = await db.QueryPage(new ExpressionFilterDefinition<Data_Guild>(guild => userInfo.CurLevel > guild.MinLevel),new SortDefinitionBuilder<Data_Guild>().Ascending(t1=>t1.Name),request.Cursor,maxNum);
                response.TotalPage = result.totalPages;
                foreach (var node in result.data)
                {
                    list.Add(new SearchGuildResult
                    {
                        Desc = node.Desc,
                        Frame = node.Frame,
                        Id = node.Id,
                        Name = node.Name,
                        Outer = node.Outer,
                    });
                }
            }
        }
    }
}