using ProtoBuf;

[ProtoContract]
public class DBDefine
{
    [ProtoMember(0)]
    public long id;
    [ProtoMember(1)]
    public long create_time = 0;
    [ProtoMember(2)]
    public long update_time;
}