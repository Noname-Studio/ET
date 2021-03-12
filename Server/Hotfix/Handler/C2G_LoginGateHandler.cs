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
			
			string account = scene.GetComponent<GateSessionKeyComponent>().Get(request.Key);
			if (account == null)
			{
				response.Error = ErrorCode.ERR_ConnectGateKeyError;
				response.Message = "Gate key验证失败!";
				reply();
				return;
			}

			var Id = GetChecksum(account);
			var db = Game.Scene.GetComponent<DBComponent>();
			var playerInfo = await db.Query<Data_PlayerInfo>(Id);
			if (playerInfo == null)
			{
				playerInfo = EntityFactory.Create<Data_PlayerInfo, string>(Game.Scene, account);
				playerInfo.Id = Id;
			}

			scene.GetComponent<PlayerComponent>().Add(playerInfo);
			session.AddComponent<SessionPlayerComponent>().Player = playerInfo;
			session.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);

			response.PlayerId = Id;
			reply();
			await ETTask.CompletedTask;
		}
		
		private long GetChecksum(string text)
		{
			long sum = 0;
			byte overflow;
			for (int i = 0; i < text.Length; i++)
			{
				sum = (long)((16 * sum) ^ Convert.ToUInt32(text[i]));
				overflow = (byte)(sum / 4294967296);
				sum = sum - overflow * 4294967296;
				sum = sum ^ overflow;
			}

			if (sum > 2147483647)
				sum = sum - 4294967296;
			else if (sum >= 32768 && sum <= 65535)
				sum = sum - 65536;
			else if (sum >= 128 && sum <= 255)
				sum = sum - 256;

			sum = Math.Abs(sum);

			return sum;
		}
	}
}