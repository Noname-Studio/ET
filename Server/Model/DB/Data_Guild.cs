using System.Collections.Generic;
using ET;

public class Data_Guild : Entity
{
    public class MemberInfo
    {
        public string Id;
        public string Name;
        public int Level;
        public uint LastLogin;
        public uint JoinTime;
        public string Language;
        public int Timezone;
        public string Icon;
        public List<int> DressUp = new List<int>();
        public int Hornor = 0;
    }
    public class ApplicationInfo
    {
        public uint Time;
        public string Id;
    }
    public string Name = null;
    public string Frame = null;
    public string Outer = null;
    public int MaxLevel = -1;
    public short IsPublic = -1;
    public short Language = -1;
    public string Desc = null;
    public short MinLevel = -1;
    public string OwnerId = null;
    public int Activity = -1;
    public List<MemberInfo> Members = new List<MemberInfo>();
    public List<ApplicationInfo> ApplicationList = new List<ApplicationInfo>();
    public uint CreateTime;
}
