﻿using System.Collections.Generic;
using ET;
using MongoDB.Bson.Serialization.Attributes;

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
        public string Name { get; set; } = "Player";
        public short Language { get; set; }= -1;
        public string Head { get; set; }
        public long GuildId { get; set; }
        public List<GuildInviteInfo> GuildInviteInfos { get; } = new List<GuildInviteInfo>();
        public List<int> DressUp { get; } = new List<int>();
        [BsonIgnore]
        public long UnitId { get; set; }
        [BsonIgnore]
        public long ChatId { get; set; }
        /// <summary>
        /// 标记这个玩家是否是活跃状态,即这个玩家与服务器是否存在连接状态
        /// </summary>
        public int CurLevel { get; set; } = 1000000;
        public long LastLogin { get; set; } = 0;
    }
}