using System;
using System.Collections.Generic;
using FairyGUI;
using Kitchen;
using Shop;

namespace Client.UI.ViewModel
{
    public class UI_LegacyShop: UIBaseShop
    {
        public class ParamsData: IUIParams
        {
            public RestaurantKey Restaurant;

            public ParamsData(RestaurantKey restaurant)
            {
                Restaurant = restaurant;
            }
        }

        private ParamsData Arg { get; set; }
        private HashSet<CookwareProperty> CachedCookwareProp;
        private HashSet<FoodProperty> CachedFoodProp;

        protected override void OnInit(IUIParams p)
        {
            Arg = p as ParamsData;
            if (Arg == null)
            {
                Log.Error("缺少参数");
                CloseMySelf();
                return;
            }

            Restaurant = Arg.Restaurant;
            View.ShowPanelType.onChanged.Add(PanelTypeChanged);
            CachedCookwareProp = new HashSet<CookwareProperty>(CookwareProperty.ReadDict().Values);
            CachedFoodProp = new HashSet<FoodProperty>(FoodProperty.ReadDict().Values);
            PanelTypeChanged();
        }

        protected override void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
            Message.Add<CookwareUpgradeSuccess>(CookwareUpgradeSuccess);
            Message.Add<FoodUpgradeSuccess>(FoodUpgradeSuccess);
        }

        protected override void OnDisable(bool refresh)
        {
            base.OnDisable(refresh);
            Message.Remove<CookwareUpgradeSuccess>(CookwareUpgradeSuccess);
            Message.Remove<FoodUpgradeSuccess>(FoodUpgradeSuccess);
        }

        private void CookwareUpgradeSuccess(CookwareUpgradeSuccess evt)
        {
            InitCookwareList();
        }

        private void FoodUpgradeSuccess(FoodUpgradeSuccess evt)
        {
            InitFoodList();
        }

        private void PanelTypeChanged()
        {
            if (View.ShowPanelType.selectedPage == "菜品")
            {
                ListColumn = 5;
                InitFoodList();
            }
            else
            {
                ListColumn = 4;
                InitCookwareList();
            }
        }

        private void InitFoodList()
        {
            var mainList = View.DishesList;
            int index = 0;
            View_DishesList currentChildList = null;
            mainList.RemoveChildrenToPool();
            var summary = GetSortFoodList(CachedFoodProp);
            foreach (var food in summary)
            {
                if (index % ListColumn == 0)
                {
                    currentChildList = mainList.AddItemFromPool() as View_DishesList;
                    currentChildList?.List.RemoveChildrenToPool();
                }

                AddFood(currentChildList, food);
                index++;
            }
        }

        private void InitCookwareList()
        {
            var mainList = View.KitchenList;
            int index = 0;
            View_KitchenList currentChildList = null;
            mainList.RemoveChildrenToPool();
            mainList.RemoveChildrenToPool();
            var summary = GetSortCookwareList(CachedCookwareProp);
            foreach (var cookware in summary)
            {
                if (cookware.RestaurantId != Arg.Restaurant)
                {
                    continue;
                }

                if (cookware.FunType == CookwareFuncType.Misc)
                {
                    continue;
                }

                if (index % ListColumn == 0)
                {
                    currentChildList = mainList.AddItemFromPool() as View_KitchenList;
                    currentChildList?.List.RemoveChildrenToPool();
                }

                AddCookware(currentChildList, cookware);
                index++;
            }
        }
    }
}