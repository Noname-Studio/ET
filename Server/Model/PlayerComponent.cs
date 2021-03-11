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
		
		private readonly Dictionary<long, Data_PlayerInfo> idPlayers = new Dictionary<long, Data_PlayerInfo>();

		public void Awake()
		{
			Instance = this;
		}
		
		public void Add(Data_PlayerInfo Data_PlayerInfo)
		{
			this.idPlayers.Add(Data_PlayerInfo.Id, Data_PlayerInfo);
		}

		public Data_PlayerInfo Get(long id)
		{
			this.idPlayers.TryGetValue(id, out Data_PlayerInfo gamer);
			return gamer;
		}

		public void Remove(long id)
		{
			this.idPlayers.Remove(id);
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