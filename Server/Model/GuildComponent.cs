using System.Collections.Generic;
using System.Linq;
using Model.Module.DB.ActualTable;

namespace ET
{
    public class GuildComponent : Entity
    {
        public static GuildComponent Instance { get; private set; }
		
        private readonly Dictionary<long, Data_Guild> guilds = new Dictionary<long, Data_Guild>();

        public readonly Dictionary<long, Data_Guild> dirty = new Dictionary<long, Data_Guild>();
        public void Awake()
        {
            Instance = this;
        }

        public void MarkDirty(Data_Guild guild)
        {
            dirty[guild.Id] = guild;
        }

        public void Add(Data_Guild guildInfo,bool markDirty = true)
        {
            this.guilds[guildInfo.Id] = guildInfo;
            MarkDirty(guildInfo);
        }

        public Data_Guild Get(long id)
        {
            this.guilds.TryGetValue(id, out Data_Guild gamer);
            return gamer;
        }

        public void Remove(long id)
        {
            this.guilds.Remove(id);
        }

        public int Count
        {
            get
            {
                return this.guilds.Count;
            }
        }

        public Data_Guild[] GetAll()
        {
            return this.guilds.Values.ToArray();
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