using ET;
using ProtoBuf;
using System.Collections.Generic;
namespace ET
{
	[Message(OuterOpcode.G2C_TestHotfixMessage)]
	[ProtoContract]
	public partial class G2C_TestHotfixMessage: IMessage
	{
		[ProtoMember(1)]
		public string Info { get; set; }

	}

	[ResponseType(typeof(M2C_TestActorResponse))]
	[Message(OuterOpcode.C2M_TestActorRequest)]
	[ProtoContract]
	public partial class C2M_TestActorRequest: IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public long ActorId { get; set; }

		[ProtoMember(1)]
		public string Info { get; set; }

	}

	[Message(OuterOpcode.M2C_TestActorResponse)]
	[ProtoContract]
	public partial class M2C_TestActorResponse: IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Info { get; set; }

	}

	[ResponseType(typeof(M2C_TestResponse))]
	[Message(OuterOpcode.C2M_TestRequest)]
	[ProtoContract]
	public partial class C2M_TestRequest: IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(93)]
		public long ActorId { get; set; }

		[ProtoMember(1)]
		public string request { get; set; }

	}

	[Message(OuterOpcode.M2C_TestResponse)]
	[ProtoContract]
	public partial class M2C_TestResponse: IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string response { get; set; }

	}

	[ResponseType(typeof(Actor_TransferResponse))]
	[Message(OuterOpcode.Actor_TransferRequest)]
	[ProtoContract]
	public partial class Actor_TransferRequest: IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(93)]
		public long ActorId { get; set; }

		[ProtoMember(1)]
		public int MapIndex { get; set; }

	}

	[Message(OuterOpcode.Actor_TransferResponse)]
	[ProtoContract]
	public partial class Actor_TransferResponse: IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(G2C_EnterMap))]
	[Message(OuterOpcode.C2G_EnterMap)]
	[ProtoContract]
	public partial class C2G_EnterMap: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_EnterMap)]
	[ProtoContract]
	public partial class G2C_EnterMap: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

// 自己的unit id
// 自己的unit id
		[ProtoMember(1)]
		public long UnitId { get; set; }

// 所有的unit
// 所有的unit
		[ProtoMember(2)]
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[Message(OuterOpcode.UnitInfo)]
	[ProtoContract]
	public partial class UnitInfo
	{
		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public float X { get; set; }

		[ProtoMember(3)]
		public float Y { get; set; }

		[ProtoMember(4)]
		public float Z { get; set; }

	}

	[Message(OuterOpcode.M2C_CreateUnits)]
	[ProtoContract]
	public partial class M2C_CreateUnits: IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(93)]
		public long ActorId { get; set; }

		[ProtoMember(1)]
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[Message(OuterOpcode.Frame_ClickMap)]
	[ProtoContract]
	public partial class Frame_ClickMap: IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(93)]
		public long ActorId { get; set; }

		[ProtoMember(94)]
		public long Id { get; set; }

		[ProtoMember(1)]
		public float X { get; set; }

		[ProtoMember(2)]
		public float Y { get; set; }

		[ProtoMember(3)]
		public float Z { get; set; }

	}

	[Message(OuterOpcode.M2C_PathfindingResult)]
	[ProtoContract]
	public partial class M2C_PathfindingResult: IActorMessage
	{
		[ProtoMember(93)]
		public long ActorId { get; set; }

		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public float X { get; set; }

		[ProtoMember(3)]
		public float Y { get; set; }

		[ProtoMember(4)]
		public float Z { get; set; }

		[ProtoMember(5)]
		public List<float> Xs = new List<float>();

		[ProtoMember(6)]
		public List<float> Ys = new List<float>();

		[ProtoMember(7)]
		public List<float> Zs = new List<float>();

	}

	[ResponseType(typeof(G2C_Ping))]
	[Message(OuterOpcode.C2G_Ping)]
	[ProtoContract]
	public partial class C2G_Ping: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_Ping)]
	[ProtoContract]
	public partial class G2C_Ping: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long Time { get; set; }

	}

	[Message(OuterOpcode.G2C_Test)]
	[ProtoContract]
	public partial class G2C_Test: IMessage
	{
	}

	[Message(OuterOpcode.C2G_Reload)]
	[ProtoContract]
	public partial class C2G_Reload: IMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.C2G_SafeShutdown)]
	[ProtoContract]
	public partial class C2G_SafeShutdown: IMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[ResponseType(typeof(R2C_Login))]
	[Message(OuterOpcode.C2R_Login)]
	[ProtoContract]
	public partial class C2R_Login: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string AccessToken { get; set; }

		[ProtoMember(2)]
		public int LoginType { get; set; }

	}

	[Message(OuterOpcode.R2C_Login)]
	[ProtoContract]
	public partial class R2C_Login: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Address { get; set; }

		[ProtoMember(2)]
		public long Key { get; set; }

		[ProtoMember(3)]
		public long GateId { get; set; }

	}

	[ResponseType(typeof(M2C_JoinGuild))]
	[Message(OuterOpcode.C2M_JoinGuild)]
	[ProtoContract]
	public partial class C2M_JoinGuild: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Id { get; set; }

	}

	[Message(OuterOpcode.M2C_JoinGuild)]
	[ProtoContract]
	public partial class M2C_JoinGuild: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(M2C_SearchGuild))]
	[Message(OuterOpcode.C2M_SearchGuild)]
	[ProtoContract]
	public partial class C2M_SearchGuild: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Name { get; set; }

		[ProtoMember(2)]
		public long Id { get; set; }

		[ProtoMember(3)]
		public int MinLevel { get; set; }

		[ProtoMember(4)]
		public short Language { get; set; }

		[ProtoMember(5)]
		public int TimeZone { get; set; }

		[ProtoMember(6)]
		public int MaxNum { get; set; }

		[ProtoMember(7)]
		public bool IsNewSearch { get; set; }

		[ProtoMember(8)]
		public int Cursor { get; set; }

	}

	[Message(OuterOpcode.M2C_SearchGuild)]
	[ProtoContract]
	public partial class M2C_SearchGuild: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<SearchGuildResult> Results = new List<SearchGuildResult>();

		[ProtoMember(2)]
		public int TotalPage { get; set; }

	}

	[ResponseType(typeof(M2C_CreateGuild))]
	[Message(OuterOpcode.C2M_CreateGuild)]
	[ProtoContract]
	public partial class C2M_CreateGuild: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Name { get; set; }

		[ProtoMember(2)]
		public int Frame { get; set; }

		[ProtoMember(3)]
		public int Inside { get; set; }

		[ProtoMember(4)]
		public bool IsPublic { get; set; }

		[ProtoMember(5)]
		public short Language { get; set; }

		[ProtoMember(6)]
		public string Desc { get; set; }

		[ProtoMember(7)]
		public int MinLevel { get; set; }

	}

	[Message(OuterOpcode.M2C_CreateGuild)]
	[ProtoContract]
	public partial class M2C_CreateGuild: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(M2C_ModifyGuild))]
	[Message(OuterOpcode.C2M_ModifyGuild)]
	[ProtoContract]
	public partial class C2M_ModifyGuild: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public int? Frame { get; set; }

		[ProtoMember(4)]
		public int? Inside { get; set; }

		[ProtoMember(5)]
		public bool? IsPublic { get; set; }

		[ProtoMember(6)]
		public short? Language { get; set; }

		[ProtoMember(7)]
		public string Desc { get; set; }

		[ProtoMember(8)]
		public int? MinLevel { get; set; }

		[ProtoMember(9)]
		public long? OwnerId { get; set; }

	}

	[Message(OuterOpcode.M2C_ModifyGuild)]
	[ProtoContract]
	public partial class M2C_ModifyGuild: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.SearchGuildResult)]
	[ProtoContract]
	public partial class SearchGuildResult
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public string Desc { get; set; }

		[ProtoMember(4)]
		public int? Inside { get; set; }

		[ProtoMember(5)]
		public int? Frame { get; set; }

	}

	[ResponseType(typeof(G2C_LoginGate))]
	[Message(OuterOpcode.C2G_LoginGate)]
	[ProtoContract]
	public partial class C2G_LoginGate: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Key { get; set; }

		[ProtoMember(2)]
		public long GateId { get; set; }

	}

	[Message(OuterOpcode.G2C_LoginGate)]
	[ProtoContract]
	public partial class G2C_LoginGate: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.PlayerInfo)]
	[ProtoContract]
	public partial class PlayerInfo: IMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[ResponseType(typeof(G2C_PlayerInfo))]
	[Message(OuterOpcode.C2G_PlayerInfo)]
	[ProtoContract]
	public partial class C2G_PlayerInfo: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_PlayerInfo)]
	[ProtoContract]
	public partial class G2C_PlayerInfo: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public PlayerInfo PlayerInfo { get; set; }

		[ProtoMember(2)]
		public List<PlayerInfo> PlayerInfos = new List<PlayerInfo>();

		[ProtoMember(3)]
		public List<string> TestRepeatedString = new List<string>();

		[ProtoMember(4)]
		public List<int> TestRepeatedInt32 = new List<int>();

		[ProtoMember(5)]
		public List<long> TestRepeatedInt64 = new List<long>();

	}

	[Message(OuterOpcode.M2C_GuildUpdate)]
	[ProtoContract]
	public partial class M2C_GuildUpdate: IActorMessage,IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long? Id { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public int? Frame { get; set; }

		[ProtoMember(4)]
		public int? Inside { get; set; }

		[ProtoMember(5)]
		public long? CreateTime { get; set; }

		[ProtoMember(6)]
		public bool? IsPublic { get; set; }

		[ProtoMember(7)]
		public short? Language { get; set; }

		[ProtoMember(8)]
		public string Desc { get; set; }

		[ProtoMember(9)]
		public int? MinLevel { get; set; }

		[ProtoMember(10)]
		public long? OwnerId { get; set; }

		[ProtoMember(11)]
		public int? MaxMemberNum { get; set; }

		[ProtoMember(12)]
		public List<MemberInfo> Members = new List<MemberInfo>();

		[ProtoMember(13)]
		public List<long> RemoveMembers = new List<long>();

		[ProtoMember(14)]
		public List<ApplicationInfo> ApplicationList = new List<ApplicationInfo>();

		[ProtoMember(15)]
		public List<long> RemoveApplicationList = new List<long>();

		[ProtoMember(16)]
		public List<AskEnergyInfo> AskEnergyList = new List<AskEnergyInfo>();

		[ProtoMember(17)]
		public List<long> RemoveAskEnergyList = new List<long>();

	}

	[ResponseType(typeof(G2C_ChatMessage))]
	[Message(OuterOpcode.C2G_ChatMessage)]
	[ProtoContract]
	public partial class C2G_ChatMessage: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string SendMessage { get; set; }

		[ProtoMember(2)]
		public int Type { get; set; }

		[ProtoMember(3)]
		public int Id { get; set; }

	}

	[Message(OuterOpcode.G2C_ChatMessage)]
	[ProtoContract]
	public partial class G2C_ChatMessage: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.CS2C_GuildMessageChanged)]
	[ProtoContract]
	public partial class CS2C_GuildMessageChanged: IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<ChatMessageInfo> Value = new List<ChatMessageInfo>();

	}

	[ResponseType(typeof(G2C_GuildAskEnergyResponse))]
	[Message(OuterOpcode.C2G_GuildAskEnergyRequest)]
	[ProtoContract]
	public partial class C2G_GuildAskEnergyRequest: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_GuildAskEnergyResponse)]
	[ProtoContract]
	public partial class G2C_GuildAskEnergyResponse: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(G2C_GuildGiveEnergyResponse))]
	[Message(OuterOpcode.C2G_GuildGiveEnergyRequest)]
	[ProtoContract]
	public partial class C2G_GuildGiveEnergyRequest: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

	}

	[Message(OuterOpcode.G2C_GuildGiveEnergyResponse)]
	[ProtoContract]
	public partial class G2C_GuildGiveEnergyResponse: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(G2C_GuildGetRecommendedPlayers))]
	[Message(OuterOpcode.C2G_GuildGetRecommendedPlayers)]
	[ProtoContract]
	public partial class C2G_GuildGetRecommendedPlayers: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_GuildGetRecommendedPlayers)]
	[ProtoContract]
	public partial class G2C_GuildGetRecommendedPlayers: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<RecommendedPlayersInfo> Players = new List<RecommendedPlayersInfo>();

	}

	[ResponseType(typeof(G2C_InvitePlayerJoinGuild))]
	[Message(OuterOpcode.C2G_InvitePlayerJoinGuild)]
	[ProtoContract]
	public partial class C2G_InvitePlayerJoinGuild: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

	}

	[Message(OuterOpcode.G2C_InvitePlayerJoinGuild)]
	[ProtoContract]
	public partial class G2C_InvitePlayerJoinGuild: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(G2C_HandleApplication))]
	[Message(OuterOpcode.C2G_HandleApplication)]
	[ProtoContract]
	public partial class C2G_HandleApplication: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

		[ProtoMember(2)]
		public bool Approve { get; set; }

	}

	[Message(OuterOpcode.G2C_HandleApplication)]
	[ProtoContract]
	public partial class G2C_HandleApplication: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(G2C_HandleGuildInvite))]
	[Message(OuterOpcode.C2G_HandleGuildInvite)]
	[ProtoContract]
	public partial class C2G_HandleGuildInvite: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long GuildId { get; set; }

		[ProtoMember(2)]
		public bool Approve { get; set; }

	}

	[Message(OuterOpcode.G2C_HandleGuildInvite)]
	[ProtoContract]
	public partial class G2C_HandleGuildInvite: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.G2C_PlayerUpdate)]
	[ProtoContract]
	public partial class G2C_PlayerUpdate: IActorLocationMessage, IMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long? PlayerId { get; set; }

		[ProtoMember(2)]
		public List<GuildInviteInfo> GuildInviteList = new List<GuildInviteInfo>();

		[ProtoMember(3)]
		public long? GuildId { get; set; }

		[ProtoMember(4)]
		public List<string> AchievementList = new List<string>();

	}

	[ResponseType(typeof(G2C_QuitGuild))]
	[Message(OuterOpcode.C2G_QuitGuild)]
	[ProtoContract]
	public partial class C2G_QuitGuild: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_QuitGuild)]
	[ProtoContract]
	public partial class G2C_QuitGuild: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(G2C_FetchGuildInfo))]
	[Message(OuterOpcode.C2G_FecthGuildInfo)]
	[ProtoContract]
	public partial class C2G_FecthGuildInfo: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long GuildId { get; set; }

	}

	[Message(OuterOpcode.G2C_FetchGuildInfo)]
	[ProtoContract]
	public partial class G2C_FetchGuildInfo: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Name { get; set; }

		[ProtoMember(2)]
		public bool IsPublic { get; set; }

		[ProtoMember(3)]
		public string Desc { get; set; }

		[ProtoMember(4)]
		public int Frame { get; set; }

		[ProtoMember(5)]
		public int Inside { get; set; }

		[ProtoMember(6)]
		public long Id { get; set; }

		[ProtoMember(7)]
		public int MaxMemberNum { get; set; }

		[ProtoMember(8)]
		public long OwnerId { get; set; }

		[ProtoMember(9)]
		public List<MemberInfo> Members = new List<MemberInfo>();

	}

	[ResponseType(typeof(G2C_KickoutFromGuild))]
	[Message(OuterOpcode.C2G_KickoutFromGuild)]
	[ProtoContract]
	public partial class C2G_KickoutFromGuild: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

	}

	[Message(OuterOpcode.G2C_KickoutFromGuild)]
	[ProtoContract]
	public partial class G2C_KickoutFromGuild: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(typeof(G2C_TransferGuildPresident))]
	[Message(OuterOpcode.C2G_TransferGuildPresident)]
	[ProtoContract]
	public partial class C2G_TransferGuildPresident: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

	}

	[Message(OuterOpcode.G2C_TransferGuildPresident)]
	[ProtoContract]
	public partial class G2C_TransferGuildPresident: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.G2C_VersionChanged)]
	[ProtoContract]
	public partial class G2C_VersionChanged: IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.C2G_ChangeVersion)]
	[ProtoContract]
	public partial class C2G_ChangeVersion: IMessage
	{
	}

	[ResponseType(typeof(G2C_DrawReward))]
	[Message(OuterOpcode.C2G_DrawReward)]
	[ProtoContract]
	public partial class C2G_DrawReward: IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int Type { get; set; }

	}

	[Message(OuterOpcode.G2C_DrawReward)]
	[ProtoContract]
	public partial class G2C_DrawReward: IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Reward { get; set; }

		[ProtoMember(2)]
		public int Number { get; set; }

	}

	[Message(OuterOpcode.GuildInviteInfo)]
	[ProtoContract]
	public partial class GuildInviteInfo
	{
		[ProtoMember(1)]
		public string Name { get; set; }

		[ProtoMember(2)]
		public long GuildId { get; set; }

		[ProtoMember(3)]
		public int MemberNum { get; set; }

		[ProtoMember(4)]
		public int Frame { get; set; }

		[ProtoMember(5)]
		public int Inside { get; set; }

	}

	[Message(OuterOpcode.RecommendedPlayersInfo)]
	[ProtoContract]
	public partial class RecommendedPlayersInfo
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public string Head { get; set; }

	}

	[Message(OuterOpcode.ChatMessageInfo)]
	[ProtoContract]
	public partial class ChatMessageInfo
	{
		[ProtoMember(1)]
		public long SenderId { get; set; }

		[ProtoMember(2)]
		public string SenderName { get; set; }

		[ProtoMember(3)]
		public string SenderMsg { get; set; }

		[ProtoMember(4)]
		public long Time { get; set; }

		[ProtoMember(5)]
		public string SenderHead { get; set; }

	}

	[Message(OuterOpcode.ApplicationInfo)]
	[ProtoContract]
	public partial class ApplicationInfo
	{
		[ProtoMember(1)]
		public long Time { get; set; }

		[ProtoMember(2)]
		public long Id { get; set; }

		[ProtoMember(3)]
		public string Name { get; set; }

		[ProtoMember(4)]
		public string Head { get; set; }

	}

	[Message(OuterOpcode.AskEnergyInfo)]
	[ProtoContract]
	public partial class AskEnergyInfo
	{
		[ProtoMember(1)]
		public long Time { get; set; }

		[ProtoMember(2)]
		public long Id { get; set; }

		[ProtoMember(3)]
		public long Count { get; set; }

		[ProtoMember(4)]
		public string Head { get; set; }

		[ProtoMember(5)]
		public string Name { get; set; }

	}

	[Message(OuterOpcode.MemberInfo)]
	[ProtoContract]
	public partial class MemberInfo
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public int Level { get; set; }

		[ProtoMember(4)]
		public long LastLogin { get; set; }

		[ProtoMember(5)]
		public long JoinTime { get; set; }

		[ProtoMember(6)]
		public short Language { get; set; }

		[ProtoMember(7)]
		public string Icon { get; set; }

		[ProtoMember(8)]
		public List<int> DressUp = new List<int>();

		[ProtoMember(9)]
		public int Hornor { get; set; }

	}

}
