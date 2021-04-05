using System;
using ET.ThirdParty.Login;
using ET.Utils;

namespace ET
{
	[ActorMessageHandler]
	public class R2G_GetLoginKeyHandler : AMActorRpcHandler<Scene, R2G_GetLoginKey, G2R_GetLoginKey>
	{
		protected override async ETTask Run(Scene scene, R2G_GetLoginKey request, G2R_GetLoginKey response, Action reply)
		{
			long account = 0;
			//在这里我们校验一下第三方登录是否正确
			if (Game.Options.Develop == 0)
			{
				if (request.LoginType == (int)LoginType.Google)
				{
					account = await GoogleLogin.Auth(request.AccessToken);
					if (account == 0)
					{
						response.Error = ErrorCode.ERR_Exception;
						response.Message = "账户IDToken错误";
						Log.Error("账户IDToken错误");
						reply();
						return;
					}
				}
				else
				{
					response.Error = ErrorCode.ERR_Exception;
					response.Message = "登陆类型错误";
					Log.Error("登录类型错误");
					reply();
					return;
				}
			}
			else
			{
				account = UniqueIdUtils.GetChecksum(request.AccessToken);
			}
			long key = RandomHelper.RandInt64();
			scene.GetComponent<GateSessionKeyComponent>().Add(key, account);
			response.Key = key;
			response.GateId = scene.Id;
			reply();
			await ETTask.CompletedTask;
		}
	}
}