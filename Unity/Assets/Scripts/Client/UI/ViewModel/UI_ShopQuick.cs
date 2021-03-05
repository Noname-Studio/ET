using System;
using System.Collections.Generic;
using FairyGUI;
using Kitchen;
using Shop;

namespace Client.UI.ViewModel
{
    /// <summary>
    /// 商店界面的快捷升级模式.
    /// 该界面主要用于同时升级食物和厨具
    /// </summary>
    public class UI_ShopQuick : UIBase<View_Shop>
    {
        private PlayerManager Player { get; }
        private HashSet<object> ItemList => new HashSet<object>();
        private const int ListColumn = 4;

        public UI_ShopQuick()
        {
            Player = PlayerManager.Inst;
        }
        
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            QuickMode();
            InitData();
            InitList();
        }

        /// <summary>
        /// 初始化需要显示的列表数据
        /// </summary>
        private void InitData()
        {
            HashSet<object> foodSet = new HashSet<object>();
            HashSet<object> cookwareSet = new HashSet<object>();
            foreach (var node in Player.CurrentLevels.Orders)
            {
                foreach (var food in node.Foods)
                {
                    if(food != null)
                        foodSet.Add(food);
                    var cookware = food.Cookware;
                    if(cookware != null)
                        cookwareSet.Add(cookware);
                }
            }
            //排序
            foreach (var node in foodSet)
                ItemList.Add(node);
            foreach (var node in cookwareSet)
                ItemList.Add(node);
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
                if(node is FoodProperty food)
                    AddFood(currentChildList, food);
                else if (node is CookwareProperty cookware)
                    AddCookware(currentChildList, cookware);
                index++;
            }

        }

        private void AddFood(View_KitchenList currentChildList, FoodProperty node)
        {
            if (currentChildList != null)
            {
                var item = currentChildList.List.AddItemFromPool() as View_KitchenItem;
                if (item == null)
                {
                    throw new Exception("View_KitchenList 无法创建 View_KitchenItem");
                }

                FoodDetailProperty currentProperty = node.CurrentLevel;

                FoodDetailProperty nextLevel = null;
                if (node.Levels.Count > currentProperty.Level) //Level 是从 1 开始的
                    nextLevel = node.Levels[currentProperty.Level];
                if (node.LevelCap == currentProperty.Level || nextLevel == null)
                    item.State.selectedPage = "MaxLevel";
                else if (nextLevel.UnlockLv > Player.CurrentLevels.Id)
                {
                    item.State.selectedPage = "Lock";
                    item.View.url = currentProperty.Level == 1 ? View_TheBox.URL : node.Texture;
                }
                else
                {
                    item.State.selectedPage = "CanUpgrade";
                    item.title = nextLevel.Price.ConvertToString(50, 50);
                    item.View.url = node.Texture;
                    item.Star.RemoveChildrenToPool();
                    for (int i = 0; i < currentProperty.Level; i++)
                        item.Star.AddItemFromPool();
                }

                if (currentProperty.Level == node.LevelCap)
                    item.Plate.url = ResPath.Plate3;
                else if (currentProperty.Level >= node.LevelCap / 2 && currentProperty.Level != 1)
                    item.Plate.url = ResPath.Plate2;
                else
                    item.Plate.url = ResPath.Plate1;
                item.data = node;
                item.onClick.Set(UpgradeFood);
            }
        }

        private void AddCookware(View_KitchenList currentChildList, CookwareProperty node)
        {
            if (currentChildList != null)
            {
                var item = currentChildList.List.AddItemFromPool() as View_KitchenItem;
                if (item == null)
                {
                    throw new Exception("View_KitchenList 无法创建 View_KitchenItem");
                }

                CookwareDetailProperty currentProperty = node.Current;

                CookwareDetailProperty nextLevel = null;
                if (node.Levels.Count > currentProperty.Level) //Level 是从 1 开始的
                    nextLevel = node.Levels[currentProperty.Level];
                if (node.LevelCap == currentProperty.Level || nextLevel == null)
                    item.State.selectedPage = "MaxLevel";
                else if (nextLevel.UnlockLv > Player.CurrentLevels.Id)
                {
                    item.State.selectedPage = "Lock";
                    item.View.url = currentProperty.Level == 1 ? View_TheBox.URL : currentProperty.Texture;
                }
                else
                {
                    item.State.selectedPage = "CanUpgrade";
                    item.title = nextLevel.Price.ConvertToString(50, 50);
                    item.View.url = currentProperty.Texture;
                    item.Star.RemoveChildrenToPool();
                    for (int i = 0; i < currentProperty.Level; i++)
                        item.Star.AddItemFromPool();
                }
                item.Plate.url = null;
                item.data = node;
                item.onClick.Set(UpgradeCookware);
            }
        }
    
        private void UpgradeFood(EventContext evt)
        {
            var sender = (GButton) evt.sender;
            var property = (FoodProperty) sender.data;
            Manager.Create<UI_FoodUpgradeTip>(new UI_FoodUpgradeTip.ParamsData(property));
        }
    
        private void UpgradeCookware(EventContext evt)
        {
            var sender = (GButton) evt.sender;
            //var property = (FoodProperty) sender.data;
        }
    }
}
