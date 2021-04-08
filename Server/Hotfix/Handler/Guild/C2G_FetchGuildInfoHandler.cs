using System;

namespace ET
{
    [MessageHandler]
    public class C2G_FetchGuildInfoHandler : AMRpcHandler<C2G_FecthGuildInfo,G2C_FetchGuildInfo>
    {
        protected override async ETTask Run(Session session, C2G_FecthGuildInfo request, G2C_FetchGuildInfo response, Action reply)
        {
            var guild = GuildComponent.Instance.Get(request.GuildId);
            if (guild == null)
            {
                response.Message = "找不到公会";
                Log.Debug("找不到公会");
                reply();
                return;
            }

            response.Desc = guild.Desc;
            response.Name = guild.Name;
            response.Frame = guild.Frame.GetValueOrDefault(0);
            response.Inside = guild.Inside.GetValueOrDefault(0);
            response.IsPublic = guild.IsPublic.GetValueOrDefault(false);
            response.Members.AddRange(guild.Members);
            response.MaxMemberNum = guild.MaxMemberNum;
            response.OwnerId = guild.OwnerId.GetValueOrDefault(0);
            reply();
            await ETTask.CompletedTask;
        }
    }
}