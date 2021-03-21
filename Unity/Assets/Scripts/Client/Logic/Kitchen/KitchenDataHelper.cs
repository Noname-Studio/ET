using Cysharp.Threading.Tasks;
using Panthea.Asset;

namespace Kitchen
{
    public static class KitchenDataHelper
    {
        public static LevelProperty LoadLevel(int id)
        {
            return AssetsKit.Inst.Load<LevelProperty>(GameConfig.LevelConfigPath + id).AsTask().Result;
        } 
        
        public static FoodProperty LoadFood(string key)
        {
            if (key.StartsWith("F_"))
                key = key.Remove(0, 2);
            return AssetsKit.Inst.Load<FoodProperty>(GameConfig.FoodConfigPath + key).AsTask().Result;
        }

        public static IngredientProperty LoadIngredient(string key)
        {
            if (key.StartsWith("I_"))
                key = key.Remove(0, 2);
            return AssetsKit.Inst.Load<IngredientProperty>(GameConfig.IngredientConfigPath + key).AsTask().Result;
        }

        public static CookwareProperty LoadCookware(string id)
        {
            return AssetsKit.Inst.Load<CookwareProperty>(GameConfig.CookwareConfigPath + id).AsTask().Result;
        }
        
        public static CustomerProperty LoadCustomer(string id)
        {
            return AssetsKit.Inst.Load<CustomerProperty>(GameConfig.CustomerConfigPath + id).AsTask().Result;
        }
    }
}
