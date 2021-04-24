using Client.Effect;
using Common;
using RemoteSaves;
using RestaurantPreview.Config;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Client.Logic.Helpler;

namespace Client.UI.ViewModel
{
    [UIWindow(Enter = WindowAnimType.Fall, Exit = WindowAnimType.Rise,Background = true)]
    //[UIBackgroundArgs(typeof())]
    public class UI_FoodUpgradeTip: UIBase<View_PopdUpgradeFood>
    {
        public class ParamsData: IUIParams
        {
            public FoodProperty Food;

            public ParamsData(FoodProperty food)
            {
                Food = food;
            }
        }

        private ParamsData mArgs;

        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            mArgs = p as ParamsData;
            if (mArgs == null)
            {
                Debug.LogError($"找不到Type为{nameof (ParamsData)}的参数,或者参数为Null");
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
            View.IsMax.selectedPage = nextLevel == null? "TRUE" : "FALSE";
            View.FoodIcon.url = food.CurrentLevel.Texture;
            View.FoodName.text = food.DisplayName;
            View.From.text = currentLevel.Tips.ToString();
            View.To.text = nextLevel == null? "" : nextLevel.Tips.ToString();
            if (nextLevel != null)
            {
                View.Price.text = currentLevel.Price.IsFree()? LocalizationProperty.Read("Free") : currentLevel.Price.ConvertToString(50, 50);
            }

            View.Star.RemoveChildrenToPool();
            for (int i = 0; i < food.LevelCap; i++)
            {
                var star = (View_Star) View.Star.AddItemFromPool();
                if (i < currentLevel.Level)
                {
                    star.Active.selectedPage = "TRUE";
                }
                else
                {
                    star.Active.selectedPage = "FALSE";
                }
            }
        }

        private void InitButton()
        {
            View.UpgradeButton.onClick.Set(UpgradeButton_OnClick);
        }

        private void UpgradeButton_OnClick()
        {
            var food = mArgs.Food;
            var price = food.CurrentLevel.Price;
            if (ResourcesHelper.SpenPrice(price,false))
            {
                var dt = Data_FoodFactory.Get(food.RestaurantId);
                var info = dt.Get(food.Key.Remove(0, 2));
                info.Level += 1;
                dt.Set(food.Key, info);
                Message.Send(new FoodUpgradeSuccess(food.Key));
            }
            if(price.Coin > 0)
                EffectFactory.Create(new ResourcesBarValueChanged(-price.Coin, ResourcesBarValueChanged.ResourceType.Coin));
            if (price.Gem > 0)
                EffectFactory.Create(new ResourcesBarValueChanged(-price.Gem, ResourcesBarValueChanged.ResourceType.Gem));
            CloseMySelf();
        }

        private void InitUI()
        {
            InitState();
            InitButton();
        }
    }
}