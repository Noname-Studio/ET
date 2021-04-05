namespace RemoteSaves
{
    public abstract class Data_Cookware_DBDefine: DBDefine
    {
        public abstract void Set(string key, Data_Cookware_Info info);
        public abstract Data_Cookware_Info Get(string key);
    }
}