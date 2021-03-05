using Cysharp.Threading.Tasks;
using Panthea.Asset;

namespace Kitchen
{
    public static class KitchenDataHelper
    {
        public static LevelProperty LoadLevel(int id)
        {
            return AssetsKit.Inst.Load<LevelProperty>("DB/Kitchen/Levels/" + id).AsTask().Result;
        } 
        
        public static FoodProperty LoadFood(string key)
        {
            if (key.StartsWith("F_"))
                key = key.Remove(0, 2);
            return AssetsKit.Inst.Load<FoodProperty>("DB/Kitchen/Foods/" + key).AsTask().Result;
        }

        public static IngredientProperty LoadIngredient(string key)
        {
            if (key.StartsWith("I_"))
                key = key.Remove(0, 2);
            return AssetsKit.Inst.Load<IngredientProperty>("DB/Kitchen/Ingredient/" + key).AsTask().Result;
        }

        public static CookwareProperty LoadCookware(string id)
        {
            return AssetsKit.Inst.Load<CookwareProperty>("DB/Kitchen/Cookwares/" + id).AsTask().Result;
        }
        
        public static CustomerProperty LoadCustomer(string id)
        {
            return AssetsKit.Inst.Load<CustomerProperty>("DB/Kitchen/Customer/" + id).AsTask().Result;
        }
    }
}
