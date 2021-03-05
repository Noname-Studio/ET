namespace RemoteSaves
{
    public abstract class Data_Food_DBDefine : DBDefine
    {
        public abstract void Set(string key, Data_Food_Info info);
        public abstract Data_Food_Info Get(string key);
    }
}