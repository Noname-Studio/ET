using System;

namespace ET
{
    [MessageHandler]
    public class C2M_ModifyGuildHandler : AMRpcHandler<C2M_ModifyGuild,M2C_ModifyGuild>
    {
        protected override async ETTask Run(Session session, C2M_ModifyGuild request, M2C_ModifyGuild response, Action reply)
        {
            var player = session.GetComponent<SessionPlayerComponent>().Player;
            var guild = GuildComponent.Instance.Get(player.GuildId);
            var update = new M2C_GuildUpdate();
            if (request.Desc != null)
            {
                update.Desc = guild.Desc = request.Desc;
            }

            if (request.Frame != null)
            {
                update.Frame = guild.Frame = request.Frame;
            }

            if (request.Inside != null)
            {
                update.Inside = guild.Inside = request.Inside;
            }

            if (request.Language != null)
            {
                update.Language = guild.Language = request.Language;
            }

            if (request.Name != null)
            {
                update.Name = guild.Name = request.Name;
            }

            if (request.IsPublic != null)
            {
                update.IsPublic = guild.IsPublic = request.IsPublic;
            }

            if (request.MinLevel != null)
            {
                update.MinLevel = guild.MinLevel = request.MinLevel;
            }

            try
            {
                foreach (var node in guild.Members)
                {
                    var member = PlayerComponent.Instance.Get(node.Id);
                    if(member != null)
                        MessageHelper.SendToLocationActor(member.UnitId, update);
                }
            }
            catch(Exception e)
            {
                response.Error = ErrorCode.ERR_LogicError;
                response.Message = e.Message;
            }

            GuildComponent.Instance.MarkDirty(guild);
            await ETTask.CompletedTask;
            reply();
        }
    }
}