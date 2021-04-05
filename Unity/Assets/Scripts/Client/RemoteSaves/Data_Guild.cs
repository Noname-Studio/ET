using System.Collections.Generic;
using ProtoBuf;

[ProtoContract]
public class Data_Guild: DBDefine
{
    [ProtoContract]
    public class MemberInfo
    {
        [ProtoMember(0)]
        public string Id;

        [ProtoMember(1)]
        public string Name;

        [ProtoMember(2)]
        public int Level;

        [ProtoMember(3)]
        public uint LastLogin;

        [ProtoMember(4)]
        public uint JoinTime;

        [ProtoMember(5)]
        public string Language;

        [ProtoMember(6)]
        public int Timezone;

        [ProtoMember(7)]
        public string Icon;

        [ProtoMember(8)]
        public List<int> DressUp = new List<int>();

        [ProtoMember(9)]
        public int Hornor = 0;
    }

    [ProtoContract]
    public class ApplicationInfo
    {
        [ProtoMember(0)]
        public uint Time;

        [ProtoMember(1)]
        public string Id;
    }

    [ProtoMember(0)]
    public int Id;

    [ProtoMember(1)]
    public string Name = null;

    [ProtoMember(2)]
    public string Frame = null;

    [ProtoMember(3)]
    public string Outer = null;

    [ProtoMember(4)]
    public int MaxLevel = -1;

    [ProtoMember(5)]
    public short IsPublic = -1;

    [ProtoMember(6)]
    public short Language = -1;

    [ProtoMember(7)]
    public string Desc = null;

    [ProtoMember(8)]
    public short MinLevel = -1;

    [ProtoMember(9)]
    public string OwnerId = null;

    [ProtoMember(10)]
    public int Activity = -1;

    [ProtoMember(11)]
    public List<MemberInfo> Members = new List<MemberInfo>();

    [ProtoMember(12)]
    public List<ApplicationInfo> ApplicationList = new List<ApplicationInfo>();

    [ProtoMember(13)]
    public uint CreateTime;
}