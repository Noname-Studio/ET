using ET.Server.Chat;
using Model.Module.DB.ActualTable;

namespace ET
{
    public static class PlayerHelper
    {
        public static async ETTask JoinGuild(this Data_PlayerInfo player,Data_Guild guild)
        {
            player.GuildId = guild.Id;
            await ChatHelper.AddToGuild(guild.Id, player);
        }
    }
}