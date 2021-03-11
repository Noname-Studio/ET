using ET;

namespace Model.Module.DB.ActualTable
{
    public class Data_PlayerInfoSystem : AwakeSystem<Data_PlayerInfo>
    {
        public override void Awake(Data_PlayerInfo self)
        {
        }
    }
    public class Data_PlayerInfo : Entity
    {
        public long GuildId;
        //暂时没有理解ET使用UnitID做为Actor ID的意图.所以这里我暂时返回Entity Id
        public long UnitId { get
        {
            return Id;
        } }

        public int CurLevel;
    }
}