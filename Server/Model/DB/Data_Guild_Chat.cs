using System.Collections.Generic;
using ET;

public class Data_Guild_Chat : Entity, IDBCollection
{
    public class ChatInfo
    {
        public string Name;
        public string Head;
        public long Id;
        public string Message;
    }
    public List<ChatInfo> Msg = new List<ChatInfo>();
}
