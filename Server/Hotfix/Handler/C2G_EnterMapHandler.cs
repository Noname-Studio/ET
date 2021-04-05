using System;
using ET.Server.Chat;
using Model.Module.DB.ActualTable;

namespace ET
{
	[MessageHandler]
	public class C2G_EnterMapHandler : AMRpcHandler<C2G_EnterMap, G2C_EnterMap>
	{
#pragma warning disable 1998
		protected override async ETTask Run(Session session, C2G_EnterMap request, G2C_EnterMap response, Action reply)
#pragma warning restore 1998
		{
			Data_PlayerInfo player = session.GetComponent<SessionPlayerComponent>().Player;
			// 在map服务器上创建战斗Unit
			M2G_CreateUnit createUnit = (M2G_CreateUnit)await ActorMessageSenderComponent.Instance.Call(
				StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Map").SceneId, 
				new G2M_CreateUnit() { PlayerId = player.Id, GateSessionId = session.InstanceId });
			player.UnitId = createUnit.UnitId;
			response.UnitId = player.Id;
			var guild = GuildComponent.Instance.Get(player.GuildId);
			
			//注册聊天到世界频道
			CS2G_RegisterPlayerToChat registerChat = await ChatHelper.Register(session, player);
			player.ChatId = registerChat.UnitId;
			
			if (guild != null)
			{
				//注册聊天到公会频道
				await ChatHelper.AddToGuild(guild.Id, player);
				var proto = guild.CreateGuildUpdateProto();
				session.Send(proto);
			}
			reply();
		}
	}
}