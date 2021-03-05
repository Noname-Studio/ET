using Common;
using UnityEngine;

namespace Client.UI.ViewModel
{
    [UIWindow(Enter = WindowAnimType.Fall,Exit = WindowAnimType.Rise)]
//[UIBackgroundArgs(typeof())]
    public class UI_FoodUpgradeTip : UIBase<View_PopdUpgradeFood>
    {
        public class ParamsData : IUIParams
        {
            public FoodProperty Food;

            public ParamsData(FoodProperty food)
            {
                Food = food;
            }
        }

        private ParamsData mArgs;
    
        public override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            mArgs = p as ParamsData;
            if (mArgs == null)
            {
                Debug.LogError($"找不到Type为{nameof(ParamsData)}的参数,或者参数为Null");
                CloseMySelf();
                return;
            }

            InitUI();
        }

        private void InitState()
        {
            var food = mArgs.Food;
            FoodDetailProperty currentLevel = food.CurrentLevel;
            FoodDetailProperty nextLevel = food.NextLevel;
            View.IsMax.selectedPage = nextLevel == null ? "TRUE" : "FALSE";
            View.FoodIcon.url = food.Texture;
            View.FoodName.text = food.DisplayName;
            View.From.text = currentLevel.Tips.ToString();
            View.To.text = nextLevel == null ? "" : nextLevel.Tips.ToString();
        }
    
        private void InitUI()
        {
            InitState();
        }
    }
}
