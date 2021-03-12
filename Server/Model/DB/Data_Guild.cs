using System.Collections.Generic;
using ET;

public class Data_Guild : Entity, IDBCollection
{
    public class MemberInfo
    {
        public long Id;
        public string Name;
        public int Level;
        public long LastLogin;
        public long JoinTime;
        public short Language;
        public string Icon;
        public List<int> DressUp = new List<int>();
        public int Hornor = 0;
    }
    public class ApplicationInfo
    {
        public long Time;
        public long Id;
    }
    public string Name = null;
    public int Frame = 0;
    public int Inside = 0;
    public bool IsPublic = true;
    public short Language = -1;
    public string Desc = null;
    public int MinLevel = -1;
    public long OwnerId = 0;
    public int Activity = -1;
    public List<MemberInfo> Members = new List<MemberInfo>();
    public List<ApplicationInfo> ApplicationList = new List<ApplicationInfo>();
    public long CreateTime;


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
            MaxMemberNum = 20,
        };
        foreach (var node in Members)
        {
            guildUpdate.Members.Add(new ET.MemberInfo
            {
                JoinTime = node.JoinTime,
                LastLogin = node.LastLogin,
                Hornor = node.Hornor,
                Icon = node.Icon,
                Level = node.Level,
                Language = node.Language,
                Id = node.Id,
                Name = node.Name,
                DressUp = node.DressUp,
            });
        }

        return guildUpdate;
    }
}
