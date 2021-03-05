using ProtoBuf;

[ProtoContract]
public class DBDefine
{
    [ProtoMember(0)]
    public string id;
    [ProtoMember(1)]
    public long create_time = 0;
    [ProtoMember(2)]
    public long update_time;
}