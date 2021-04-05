/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace Shop
{
    public class ShopBinder
    {
        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void BindAll()
        {
            UIObjectFactory.SetPackageItemExtension(View_DishesList.URL, typeof (View_DishesList));
            UIObjectFactory.SetPackageItemExtension(View_Shop.URL, typeof (View_Shop));
            UIObjectFactory.SetPackageItemExtension(View_KitchenItem.URL, typeof (View_KitchenItem));
            UIObjectFactory.SetPackageItemExtension(View_KitchenList.URL, typeof (View_KitchenList));
            UIObjectFactory.SetPackageItemExtension(View_DishesItem.URL, typeof (View_DishesItem));
        }
    }
}