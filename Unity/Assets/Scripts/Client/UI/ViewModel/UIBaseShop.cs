using System;
using System.Collections.Generic;
using Common;
using FairyGUI;
using RestaurantPreview.Config;
using Shop;

namespace Client.UI.ViewModel
{
    public class UIBaseShop: UIBase<View_Shop>
    {
        protected PlayerManager Player { get; }
        protected int ListColumn { get; set; }
        protected RestaurantKey Restaurant { get; set; }

        public UIBaseShop()
        {
            Player = PlayerManager.Inst;
        }

        protected override void OnDisable(bool refresh)
        {
            DBManager.Inst.Update();
        }

        protected void AddFood(GComponent currentChildList, FoodProperty node)
        {
            if (currentChildList != null)
            {
                var item = currentChildList.GetChild("List").asList.AddItemFromPool() as GButton;
                if (item == null)
                {
                    throw new Exception("View_KitchenList 无法创建 View_KitchenItem");
                }

                RefreshFoodItem(node, item);
            }
        }

        private void RefreshFoodItem(FoodProperty node, GButton item)
        {
            item.name = node.Key;
            FoodDetailProperty currentProperty = node.CurrentLevel;

            FoodDetailProperty nextLevel = null;
            if (node.Levels.Count > currentProperty.Level) //Level 是从 1 开始的
            {
                nextLevel = node.Levels[currentProperty.Level];
            }

            if (node.LevelCap == currentProperty.Level || nextLevel == null)
            {
                if (currentProperty.UnlockLv > Player.CurrentLevel.LevelId)
                {
                    item.GetController("State").selectedPage = "Lock";
                    item.icon = currentProperty.Level == 1? "ui://Shop/box" : node.CurrentLevel.Texture;
                    item.title = string.Format(LocalizationProperty.Read("UnLockAtLevel"), nextLevel.UnlockLv);
                }
                else
                {
                    item.GetController("State").selectedPage = "MaxLevel";
                }
            }
            else if (nextLevel.UnlockLv > Player.CurrentLevel.LevelId)
            {
                item.GetController("State").selectedPage = "Lock";
                item.icon = currentProperty.Level == 1? "ui://Shop/box" : node.CurrentLevel.Texture;
                item.title = string.Format(LocalizationProperty.Read("UnLockAtLevel"), nextLevel.UnlockLv);
            }
            else
            {
                item.GetController("State").selectedPage = "CanUpgrade";
                item.title = !currentProperty.Price.IsFree()? currentProperty.Price.ConvertToString(50, 50) : LocalizationProperty.Read("Free");
            }

            item.icon = node.CurrentLevel.Texture;
            var starList = item.GetChild("Star").asList;
            starList.RemoveChildrenToPool();
            for (int i = 0; i < node.LevelCap; i++)
            {
                var star = (View_Star) starList.AddItemFromPool();
                if (i < currentProperty.Level)
                {
                    star.Active.selectedPage = "TRUE";
                }
                else
                {
                    star.Active.selectedPage = "FALSE";
                }
            }

            var plate = item.GetChild("Plate").asLoader;
            if (currentProperty.Level == node.LevelCap)
            {
                plate.icon = ResPath.Plate3;
            }
            else if (currentProperty.Level >= node.LevelCap / 2 && currentProperty.Level != 1)
            {
                plate.icon = ResPath.Plate2;
            }
            else
            {
                plate.icon = ResPath.Plate1;
            }

            item.data = node;
            item.onClick.Set(UpgradeFood);
        }

        protected void AddCookware(View_KitchenList currentChildList, CookwareProperty node)
        {
            if (currentChildList != null)
            {
                var item = currentChildList.List.AddItemFromPool() as View_KitchenItem;
                if (item == null)
                {
                    throw new Exception("View_KitchenList 无法创建 View_KitchenItem");
                }

                RefreshCookwareItem(node, item);
            }
        }

        private void RefreshCookwareItem(CookwareProperty node, View_KitchenItem item)
        {
            item.name = node.Key;
            CookwareDetailProperty currentProperty = node.CurrentLevel;
            CookwareDetailProperty nextLevel = null;
            if (node.Levels.Count > currentProperty.Level) //Level 是从 1 开始的
            {
                nextLevel = node.Levels[currentProperty.Level];
            }

            if (node.LevelCap == currentProperty.Level || nextLevel == null)
            {
                item.State.selectedPage = "MaxLevel";
            }
            else if (nextLevel.UnlockLv > Player.CurrentLevel.Id)
            {
                item.State.selectedPage = "Lock";
                item.icon = currentProperty.Level == 1? "ui://Shop/box" : currentProperty.Texture;
            }
            else
            {
                item.State.selectedPage = "CanUpgrade";
                item.title = !currentProperty.Price.IsFree()? currentProperty.Price.ConvertToString(50, 50) : LocalizationProperty.Read("Free");
            }

            item.icon = currentProperty.Texture;
            item.Star.RemoveChildrenToPool();
            for (int i = 0; i < node.LevelCap; i++)
            {
                var star = (View_Star) item.Star.AddItemFromPool();
                if (i < currentProperty.Level)
                {
                    star.Active.selectedPage = "TRUE";
                }
                else
                {
                    star.Active.selectedPage = "FALSE";
                }
            }

            item.Plate.url = null;
            item.data = node;
            item.onClick.Set(UpgradeCookware);
        }

        protected void UpgradeFood(EventContext evt)
        {
            var sender = (GButton) evt.sender;
            var property = (FoodProperty) sender.data;
            UIKit.Inst.Create<UI_FoodUpgradeTip>(new UI_FoodUpgradeTip.ParamsData(property));
        }

        protected void UpgradeCookware(EventContext evt)
        {
            var sender = (GButton) evt.sender;
            var property = (CookwareProperty) sender.data;
            UIKit.Inst.Create<UI_CookwareUpgradeTip>(new UI_CookwareUpgradeTip.ParamsData(property));
        }

        protected HashSet<FoodProperty> GetSortFoodList(HashSet<FoodProperty> foods)
        {
            HashSet<FoodProperty> summary = new HashSet<FoodProperty>();
            List<FoodProperty> unlockList = new List<FoodProperty>();
            List<FoodProperty> lockList = new List<FoodProperty>();
            List<FoodProperty> maxLevelList = new List<FoodProperty>();
            foreach (FoodProperty food in foods)
            {
                if (food.RestaurantId != Restaurant)
                {
                    continue;
                }

                if (food.Levels.Count <= 1)
                {
                    continue;
                }

                var level = food.NextLevel;
                if (level != null && level.UnlockLv > Player.CurrentLevel.LevelId)
                {
                    lockList.Add(food);
                }
                else if (level == null)
                {
                    if (food.CurrentLevel.UnlockLv > Player.CurrentLevel.LevelId)
                    {
                        lockList.Add(food);
                    }
                    else
                    {
                        maxLevelList.Add(food);
                    }
                }
                else
                {
                    unlockList.Add(food);
                }
            }

            lockList.Sort((t1, t2) => string.CompareOrdinal(t1.Key, t2.Key));
            unlockList.Sort((t1, t2) => string.CompareOrdinal(t1.Key, t2.Key));
            maxLevelList.Sort((t1, t2) => string.CompareOrdinal(t1.Key, t2.Key));
            summary.AddRange(unlockList);
            summary.AddRange(lockList);
            summary.AddRange(maxLevelList);
            return summary;
        }

        protected HashSet<CookwareProperty> GetSortCookwareList(HashSet<CookwareProperty> cookwares)
        {
            HashSet<CookwareProperty> summary = new HashSet<CookwareProperty>();
            List<CookwareProperty> unlockList = new List<CookwareProperty>();
            List<CookwareProperty> lockList = new List<CookwareProperty>();
            List<CookwareProperty> maxLevelList = new List<CookwareProperty>();
            foreach (CookwareProperty cookware in cookwares)
            {
                if (cookware.RestaurantId != Restaurant)
                {
                    continue;
                }

                var level = cookware.NextLevel;
                if (level != null && level.UnlockLv > Player.CurrentLevel.LevelId)
                {
                    lockList.Add(cookware);
                }
                else if (level == null)
                {
                    if (cookware.CurrentLevel.UnlockLv > Player.CurrentLevel.LevelId)
                    {
                        lockList.Add(cookware);
                    }
                    else
                    {
                        maxLevelList.Add(cookware);
                    }
                }
                else
                {
                    unlockList.Add(cookware);
                }
            }

            lockList.Sort((t1, t2) => string.CompareOrdinal(t1.Key, t2.Key));
            unlockList.Sort((t1, t2) => string.CompareOrdinal(t1.Key, t2.Key));
            maxLevelList.Sort((t1, t2) => string.CompareOrdinal(t1.Key, t2.Key));
            summary.AddRange(unlockList);
            summary.AddRange(lockList);
            summary.AddRange(maxLevelList);
            return summary;
        }
    }
}