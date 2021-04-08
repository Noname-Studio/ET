using System;


namespace ET
{
	[MessageHandler]
	public class C2M_ReloadHandler: AMRpcHandler<C2G_Reload, G2C_Reload>
	{
		protected override async ETTask Run(Session session, C2G_Reload request, G2C_Reload response, Action reply)
		{
			Game.EventSystem.Add(DllHelper.GetHotfixAssembly());
			reply();
			
			await ETTask.CompletedTask;
		}
	}
}