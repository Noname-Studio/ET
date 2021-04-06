

using System;
using ET.Server.Chat;

namespace ET
{
	public class SessionPlayerComponentDestroySystem : DestroySystem<SessionPlayerComponent>
	{
		public override async void Destroy(SessionPlayerComponent self)
		{
			const long DelayRemoveTime = 1000 * 60 * 30;//30分钟 
			// 发送断线消息
			ActorLocationSenderComponent.Instance.Send(self.Player.UnitId, new G2M_SessionDisconnect());
			TimerComponent.Instance.NewOnceTimer(DelayRemoveTime, async() =>
			{
				Game.Scene.GetComponent<PlayerComponent>()?.Remove(self.Player.Id);
				await CacheHelper.Set(self.Player.Id,self.Player);
			});
			self.Player.LastLogin = TimeHelper.ServerTimeStamp();
			await ChatHelper.UnRegister(self.Player);
		}
	}
}