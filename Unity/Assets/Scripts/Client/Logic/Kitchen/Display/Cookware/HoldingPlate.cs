using System;
using System.Collections.Generic;
using Client.UI.ViewModel;
using Cysharp.Threading.Tasks;
using FairyGUI;
using UnityEngine;

namespace Kitchen
{
    public class HoldingPlate: ICookware
    {
        public Type Type => GetType();
        public IAnimation Animation { get; }
        public UnityObject Display { get; }
        public CookwareState State => CookwareState.Idle;
        private UI_CookFood mCookResult;

        public string FoodId { get; private set; }
        public int FoodCount { get; private set; } = 0;

        public HoldingPlate(UnityObject display, IAnimation animation)
        {
            Display = display;
            Animation = animation;
            CreateDisplay();
        }

        public void DoWork()
        {
            Animation.AnimationName = "3work";
        }

        public string TakeFood()
        {
            var food = FoodId;
            FoodId = null;
            mCookResult.View.visible = false;
            return food;
        }

        public List<string> PutIn(List<string> list)
        {
            var result = new List<string>();
            if (list.Count == 0 || !string.IsNullOrEmpty(FoodId) && list.Count < 2)
            {
                return result;
            }

            result.Add(list[0]);
            Internal_PutIn(list[0]).Forget();
            return result;
        }

        public void Update()
        {
            
        }

        private async UniTaskVoid Internal_PutIn(string food)
        {
            mCookResult.View.Plate.url = "Image/Food/plate1_1";
            if (IngredientHelper.IsFood(food))
            {
                mCookResult.View.Food.url = KitchenDataHelper.LoadFood(food).Texture;
            }
            else
            {
                mCookResult.View.Food.url = KitchenDataHelper.LoadIngredient(food).Texture;
            }

            mCookResult.View.visible = true;
            await UniTask.NextFrame();
            FoodId = food;
            FoodCount += 1;
        }

        /// <summary>
        /// 创建显示盘子
        /// </summary>
        private void CreateDisplay()
        {
            mCookResult = UIKit.Inst.Create<UI_CookFood>();
            mCookResult.View.visible = false;
            Vector3 screenPos = KitchenRoot.Inst.MainCamera.WorldToScreenPoint(Animation.FoodPos);
            screenPos.y = Screen.height - screenPos.y;
            var pt = GRoot.inst.GlobalToLocal(screenPos);
            mCookResult.View.position = pt;
        }

        public void Dispose()
        {
        }
    }
}