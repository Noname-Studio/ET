using System.Collections.Generic;
using ET;
using MongoDB.Bson.Serialization.Attributes;

public class Data_Guild : Entity, IDBCollection
{
    public string Name = null;
    public int? Frame = null;
    public int? Inside = null;
    public bool? IsPublic = null;
    public short? Language = null;
    public string Desc = null;
    public int? MinLevel = null;
    public long? OwnerId = null;
    public int? Activity = null;
    public List<MemberInfo> Members = new List<MemberInfo>();
    public List<ApplicationInfo> ApplicationList = new List<ApplicationInfo>();
    public List<AskEnergyInfo> AskEnergyList = new List<AskEnergyInfo>();
    public long? CreateTime = null;
    [BsonIgnore]
    public Dictionary<long, MemberInfo> ActivePlayers = new Dictionary<long, MemberInfo>();
    [BsonIgnore]
    public int MaxMemberNum { get; set; } = 20;

    public M2C_GuildUpdate CreateGuildUpdateProto()
    {
        var guildUpdate = new M2C_GuildUpdate
        {
            Desc = Desc,
            Id = Id,
            Inside = Inside,
            Name = Name,
            CreateTime = CreateTime,
            IsPublic = IsPublic,
            Language = Language,
            MinLevel = MinLevel,
            OwnerId = OwnerId,
            MaxMemberNum = MaxMemberNum,
            Frame = Frame
        };
        guildUpdate.Members.AddRange(Members);
        guildUpdate.ApplicationList.AddRange(ApplicationList);
        guildUpdate.AskEnergyList.AddRange(AskEnergyList);

        return guildUpdate;
    }

    public MemberInfo GetMemberFromId(long playerId)
    {
        foreach (var node in Members)
        {
            if (node.Id == playerId)
                return node;
        }

        return null;
    }
}
