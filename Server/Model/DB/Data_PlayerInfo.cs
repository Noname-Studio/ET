using System.Collections.Generic;
using ET;

namespace Model.Module.DB.ActualTable
{
    public class Data_PlayerInfoSystem : AwakeSystem<Data_PlayerInfo>
    {
        public override void Awake(Data_PlayerInfo self)
        {
        }
    }
    public class Data_PlayerInfo : Entity, IDBCollection
    {
        public string Name = "Player";
        public short Language = -1;
        public string Icon;
        public long GuildId;

        public List<int> DressUp = new List<int>();
        public long UnitId { get; set; }

        public int CurLevel = 1000000;
    }
}