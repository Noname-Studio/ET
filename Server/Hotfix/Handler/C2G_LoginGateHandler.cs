﻿using System;
using Model.Module.DB.ActualTable;

namespace ET
{
	[MessageHandler]
	public class C2G_LoginGateHandler : AMRpcHandler<C2G_LoginGate, G2C_LoginGate>
	{
		protected override async ETTask Run(Session session, C2G_LoginGate request, G2C_LoginGate response, Action reply)
		{
			Scene scene = Game.Scene.Get(request.GateId);
			if (scene == null)
			{
				return;
			}
			
			long Id = scene.GetComponent<GateSessionKeyComponent>().Get(request.Key);
			if (Id == 0)
			{
				response.Error = ErrorCode.ERR_ConnectGateKeyError;
				response.Message = "Gate key验证失败!";
				reply();
				return;
			}

			var db = Game.Scene.GetComponent<DBComponent>();
			var cachePlayer = scene.GetComponent<PlayerComponent>().Get(Id);
			Data_PlayerInfo playerInfo = cachePlayer ?? await db.Query<Data_PlayerInfo>(Id);
			if (playerInfo == null)
			{
				playerInfo = EntityFactory.Create<Data_PlayerInfo>(Game.Scene);
				playerInfo.Id = Id;
			}

			scene.GetComponent<PlayerComponent>().Add(playerInfo);
			session.AddComponent<SessionPlayerComponent>().Player = playerInfo;
			session.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);

			response.PlayerId = Id;
			reply();
			await ETTask.CompletedTask;
		}
		
		
	}
}