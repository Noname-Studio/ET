

using ET.Server.Chat;

namespace ET
{
	public class SessionPlayerComponentDestroySystem : DestroySystem<SessionPlayerComponent>
	{
		public override async void Destroy(SessionPlayerComponent self)
		{
			// 发送断线消息
			ActorLocationSenderComponent.Instance.Send(self.Player.UnitId, new G2M_SessionDisconnect());
			Game.Scene.GetComponent<PlayerComponent>()?.Remove(self.Player.Id);
			await ChatHelper.UnRegister(self.Player);
			await DBComponent.Instance.Save(self.Player);
		}
	}
}