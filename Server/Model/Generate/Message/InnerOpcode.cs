namespace ET
{
	public static partial class InnerOpcode
	{
		 public const ushort M2M_TrasferUnitRequest = 10001;
		 public const ushort M2M_TrasferUnitResponse = 10002;
		 public const ushort M2A_Reload = 10003;
		 public const ushort A2M_Reload = 10004;
		 public const ushort G2G_LockRequest = 10005;
		 public const ushort G2G_LockResponse = 10006;
		 public const ushort G2G_LockReleaseRequest = 10007;
		 public const ushort G2G_LockReleaseResponse = 10008;
		 public const ushort ObjectAddRequest = 10009;
		 public const ushort ObjectAddResponse = 10010;
		 public const ushort ObjectLockRequest = 10011;
		 public const ushort ObjectLockResponse = 10012;
		 public const ushort ObjectUnLockRequest = 10013;
		 public const ushort ObjectUnLockResponse = 10014;
		 public const ushort ObjectRemoveRequest = 10015;
		 public const ushort ObjectRemoveResponse = 10016;
		 public const ushort ObjectGetRequest = 10017;
		 public const ushort ObjectGetResponse = 10018;
		 public const ushort R2G_GetLoginKey = 10019;
		 public const ushort G2R_GetLoginKey = 10020;
		 public const ushort G2M_CreateUnit = 10021;
		 public const ushort M2G_CreateUnit = 10022;
		 public const ushort G2CS_AddGuildToChatServer = 10023;
		 public const ushort CS2G_AddGuildToChatServer = 10024;
		 public const ushort G2CS_RemoveGuildToChatServer = 10025;
		 public const ushort CS2G_RemoveGuildToChatServer = 10026;
		 public const ushort G2CS_AddPlayerToChat = 10027;
		 public const ushort CS2G_AddPlayerToChat = 10028;
		 public const ushort G2CS_RemovePlayerFromChat = 10029;
		 public const ushort CS2G_RemovePlayerFromChat = 10030;
		 public const ushort G2CS_RegisterPlayerToChat = 10031;
		 public const ushort CS2G_RegisterPlayerToChat = 10032;
		 public const ushort G2CS_UnRegisterPlayerToChat = 10033;
		 public const ushort CS2G_UnRegisterPlayerToChat = 10034;
		 public const ushort G2CS_SendGuildMessage = 10035;
		 public const ushort G2M_SessionDisconnect = 10036;
	}
}
