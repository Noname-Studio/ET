using System;
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

			Data_PlayerInfo playerInfo = await CacheHelper.Get<Data_PlayerInfo>(request.Key);
			if (playerInfo == null)
			{
				playerInfo = EntityFactory.Create<Data_PlayerInfo>(Game.Scene);
				playerInfo.Id = request.Key;
			}
			playerInfo.LastLogin = 0;
			scene.GetComponent<PlayerComponent>().Add(playerInfo);
			session.AddComponent<SessionPlayerComponent>().Player = playerInfo;
			session.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);
			session.AddComponent<SessionInnerVariables>();

			session.Send(new G2C_PlayerUpdate { PlayerId = playerInfo.Id,GuildId = playerInfo.GuildId,GuildInviteList = playerInfo.GuildInviteInfos });
			
			reply();
			await ETTask.CompletedTask;
		}
		
		
	}
}