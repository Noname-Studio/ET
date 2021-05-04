using System;
using System.Collections.Generic;
using FairyGUI;
using Kitchen;
using RestaurantPreview.Config;
using Shop;

namespace Client.UI.ViewModel
{
    /// <summary>
    /// 商店界面的快捷升级模式.
    /// 该界面主要用于同时升级食物和厨具
    /// </summary>
    public class UI_QuickShop: UIBaseShop
    {
        public class ParamsData: IUIParams
        {
            public LevelProperty level;

            public ParamsData(LevelProperty level)
            {
                this.level = level;
            }
        }

        private PlayerManager Player { get; }
        private HashSet<object> ItemList { get; } = new HashSet<object>();
        private const int ListColumn = 4;
        public ParamsData Arg { get; set; }

        public UI_QuickShop()
        {
            Player = PlayerManager.Inst;
        }

        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            Arg = p as ParamsData;
            if (Arg == null)
            {
                Log.Error("缺少参数");
                CloseMySelf();
                return;
            }

            Restaurant = Arg.level.Restaurant;
            QuickMode();
            InitData();
            InitList();
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

        private void FoodUpgradeSuccess(FoodUpgradeSuccess evt)
        {
            InitList();
        }

        private void CookwareUpgradeSuccess(CookwareUpgradeSuccess evt)
        {
            InitList();
        }

        /// <summary>
        /// 初始化需要显示的列表数据
        /// </summary>
        private void InitData()
        {
            HashSet<FoodProperty> foodSet = new HashSet<FoodProperty>();
            HashSet<CookwareProperty> cookwareSet = new HashSet<CookwareProperty>();
            foreach (var food in FoodProperty.ReadDict())
            {
                if (food.Value.Restaurant == RestaurantKey.This)
                {
                    FoodProperty data = food.Value;
                    foodSet.Add(data);
                    var cookware = CookwareProperty.Read(data.Cookware);
                    if (cookware != null)
                    {
                        cookwareSet.Add(cookware);
                    }
                }
            }

            foodSet = GetSortFoodList(foodSet);
            cookwareSet = GetSortCookwareList(cookwareSet);
            //排序
            foreach (var node in foodSet)
            {
                ItemList.Add(node);
            }

            foreach (var node in cookwareSet)
            {
                ItemList.Add(node);
            }
        }

        /// <summary>
        /// 快捷模式的入口核心代码.这里我们处理和UIShop不同的逻辑
        /// 一些UI状态的调整
        /// </summary>
        private void QuickMode()
        {
            View.PanelType.visible = false;
            View.ShowPanelType.selectedPage = "厨具";
        }

        /// <summary>
        /// 初始化显示列表
        /// </summary>
        private void InitList()
        {
            var mainList = View.KitchenList;
            int index = 0;
            View_KitchenList currentChildList = null;
            mainList.RemoveChildrenToPool();
            foreach (var node in ItemList)
            {
                if (index % ListColumn == 0)
                {
                    currentChildList = mainList.AddItemFromPool() as View_KitchenList;
                    currentChildList?.List.RemoveChildrenToPool();
                }

                if (node is FoodProperty food)
                {
                    AddFood(currentChildList, food);
                }
                else if (node is CookwareProperty cookware)
                {
                    AddCookware(currentChildList, cookware);
                }

                index++;
            }
        }
    }
}