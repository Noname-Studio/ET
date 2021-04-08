using System;
using System.Collections.Generic;
using System.Linq;
using Model.Module.DB.ActualTable;

namespace ET
{
	public class Data_PlayerInfoComponentSystem : AwakeSystem<PlayerComponent>
	{
		public override void Awake(PlayerComponent self)
		{
			self.Awake();
		}
	}
	
	public class PlayerComponent : Entity
	{
		public static PlayerComponent Instance { get; private set; }

		public Data_PlayerInfo MyData_PlayerInfo;
		
		private Dictionary<long, Data_PlayerInfo> idPlayers { get; } = new Dictionary<long, Data_PlayerInfo>();
		private List<Data_PlayerInfo> PlayerList { get; } = new List<Data_PlayerInfo>();
		public void Awake()
		{
			Instance = this;
		}
		
		public void Add(Data_PlayerInfo Data_PlayerInfo)
		{
			this.idPlayers[Data_PlayerInfo.Id] = Data_PlayerInfo;
			PlayerList.Add(Data_PlayerInfo);
		}

		public Data_PlayerInfo Get(long id)
		{
			this.idPlayers.TryGetValue(id, out Data_PlayerInfo gamer);
			return gamer;
		}

		public void Remove(long id)
		{
			if (this.idPlayers.TryGetValue(id, out var value))
			{
				idPlayers.Remove(id);
				PlayerList.Remove(value);
			}
		}

		public int Count
		{
			get
			{
				return this.idPlayers.Count;
			}
		}

		public Data_PlayerInfo[] GetAll()
		{
			return this.idPlayers.Values.ToArray();
		}

		public List<Data_PlayerInfo> RandomGet(int size)
		{
			//TODO 存在性能问题.需要优化
			if (size >= idPlayers.Count)
			{
				return PlayerList;
			}
			var array = new List<Data_PlayerInfo>(size);
			for (int i = 0; i < size; i++)
			{
				var result = PlayerList[RandomHelper.RandomNumber(0, idPlayers.Count)];
				if (!array.Contains(result))
					array[i] = result;
			}
			return array;
		}

		public List<Data_PlayerInfo> GetNotJoinedGuildPlayer(Session session,int size)
		{
			List<Data_PlayerInfo> list = new List<Data_PlayerInfo>(size);
			var variables = session.GetComponent<SessionInnerVariables>();
			int index = variables.FetchEmptyGuildPlayerIndex;
			if (index > PlayerList.Count)
				index = 0;
			for (; index < PlayerList.Count; index++)
			{
				var node = PlayerList[index];
				if (node.GuildId == 0)
					list.Add(node);
			}

			variables.FetchEmptyGuildPlayerIndex = index;
			return list;
		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}
			
			base.Dispose();

			foreach (Data_PlayerInfo Data_PlayerInfo in this.idPlayers.Values)
			{
				Data_PlayerInfo.Dispose();
			}

			Instance = null;
		}
	}
}