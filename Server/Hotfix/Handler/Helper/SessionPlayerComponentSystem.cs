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
			TimerComponent.Instance.NewOnceTimer(DelayRemoveTime, () =>
			{
				if (!self.Player.IsActive)//超过30分钟未登录游戏直接从内存中移除
				{
					Game.Scene.GetComponent<PlayerComponent>()?.Remove(self.Player.Id);
				}
			});
			self.Player.LastLogin = TimeHelper.ServerTimeStamp();
			self.Player.IsActive = false;
			await CacheHelper.Set(self.Player.Id, self.Player);
			await ChatHelper.UnRegister(self.Player);
		}
	}
}