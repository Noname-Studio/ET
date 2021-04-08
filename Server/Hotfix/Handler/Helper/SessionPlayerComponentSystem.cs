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
			TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + DelayRemoveTime, () =>
			{
				if (self.Player.LastLogin > 0)//超过30分钟未登录游戏直接从内存中移除
				{
					Game.Scene.GetComponent<PlayerComponent>()?.Remove(self.Player.Id);
					Log.Error($"清理离线用户Id:{self.Player.Id}");
				}
			});
			self.Player.LastLogin = TimeHelper.ServerTimeStamp();
			if (self.Player.GuildId != 0)
			{
				Data_Guild guild = GuildComponent.Instance.Get(self.Player.GuildId);
				var member = guild.GetMemberFromId(self.Player.Id);
				if (member != null)
					member.LastLogin = self.Player.LastLogin;
				var update = new M2C_GuildUpdate();
				update.Members.Add(member);
				guild.ActivePlayers.Remove(self.Player.UnitId);
				foreach (var node in guild.ActivePlayers)
				{
					MessageHelper.SendToLocationActor(node.Key, update);
				}
			}
			await CacheHelper.Set(self.Player.Id, self.Player);
			await ChatHelper.UnRegister(self.Player);
		}
	}
}