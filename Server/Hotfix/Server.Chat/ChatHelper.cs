using Model.Module.DB.ActualTable;

namespace ET.Server.Chat
{
    public static class ChatHelper
    {
        public enum Type
        {
            World = 0,
            Guild = 1,
            Team = 2
        }
        public static async ETTask<CS2G_RegisterPlayerToChat> Register(Session session,Data_PlayerInfo player)
        {
            return (CS2G_RegisterPlayerToChat)await ActorMessageSenderComponent.Instance.Call(
                StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Chat").SceneId,
                new G2CS_RegisterPlayerToChat { GateSessionId = session.InstanceId,Head = player.Icon,Name = player.Name,PlayerId = player.Id,ChatId = player.ChatId});
        }
        
        public static async ETTask UnRegister(Data_PlayerInfo player)
        {
            await ActorLocationSenderComponent.Instance.Call(player.ChatId, new G2CS_UnRegisterPlayerToChat());
        }
        
        public static async ETTask AddToWorld(Data_PlayerInfo player)
        {
            await ActorLocationSenderComponent.Instance.Call(player.ChatId, new G2CS_AddPlayerToChat { Type = 0});
        }
        
        public static async ETTask AddToGuild(long guildId,Data_PlayerInfo player)
        {
            await ActorLocationSenderComponent.Instance.Call(player.ChatId, new G2CS_AddPlayerToChat { GuildId = guildId, Type = 1 });
        }

        public static async ETTask RemoveFromWorld(Data_PlayerInfo player)
        {
            await ActorLocationSenderComponent.Instance.Call(player.ChatId,
                new G2CS_RemovePlayerFromChat { Type = 0});
        }
    }
}