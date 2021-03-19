using System;
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
			long mapInstanceId = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Map").SceneId;
			M2G_CreateUnit createUnit = (M2G_CreateUnit)await ActorMessageSenderComponent.Instance.Call(
				mapInstanceId, new G2M_CreateUnit() { PlayerId = player.Id, GateSessionId = session.InstanceId });
			CS2G_AddPlayerToChatServer createChat = (CS2G_AddPlayerToChatServer)await ActorMessageSenderComponent.Instance.Call(
				mapInstanceId, new G2CS_AddPlayerToChatServer() { GateSessionId = session.InstanceId });
			player.UnitId = createUnit.UnitId;
			player.ChatId = createChat.UnitId;
			response.UnitId = player.Id;
			var guild = await DBComponent.Instance.Query<Data_Guild>(player.GuildId);
			if (guild != null)
			{
				var proto = guild.CreateGuildUpdateProto();
				session.Send(proto);
			}
			reply();
		}
	}
}