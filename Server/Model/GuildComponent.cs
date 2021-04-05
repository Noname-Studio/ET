using System.Collections.Generic;
using System.Linq;
using Model.Module.DB.ActualTable;

namespace ET
{
    public class GuildComponent : Entity
    {
        public static GuildComponent Instance { get; private set; }
		
        public readonly Dictionary<long, Data_Guild> guilds = new Dictionary<long, Data_Guild>();

        public readonly Dictionary<long, Data_Guild> dirty = new Dictionary<long, Data_Guild>();
        public void Awake()
        {
            Instance = this;
        }
        public int Count
        {
            get
            {
                return guilds.Count;
            }
        }
        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
			
            base.Dispose();

            foreach (Data_Guild Data_PlayerInfo in this.guilds.Values)
            {
                Data_PlayerInfo.Dispose();
            }

            Instance = null;
        }
    }
}