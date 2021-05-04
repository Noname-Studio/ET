using System.Collections.Generic;
using Client.Effect;
using Common;
using RestaurantPreview.Config;
using UnityEngine.Experimental.Rendering.Client.Logic.Helpler;

namespace Client.UI.ViewModel
{
    [UIWindow(Enter = WindowAnimType.Fall, Exit = WindowAnimType.Rise,Background = true)]
    public class UI_CookwareUpgradeTip: UIBase<View_KitchenPop>
    {
        public class ParamsData: IUIParams
        {
            public CookwareProperty Property;

            public ParamsData(CookwareProperty property)
            {
                Property = property;
            }
        }

        private ParamsData Arg { get; set; }
        private CookwareProperty.CookwareDetailProperty Detail { get; set; }

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

            Detail = Arg.Property.CurrentLevel;
            InitUI();
        }

        public void InitUI()
        {
            var property = Arg.Property;
            View.Name.text = property.DisplayName;
            View.iconframe.label.icon = Detail.Texture;
            if (!Detail.Price.IsFree())
            {
                View.price.text = Detail.Price.ConvertToString(50, 50);
                View.UpgradeBtn.onClick.Set(Upgrade_OnClick);
            }
            else
            {
                View.price.text = LocalizationProperty.Read("Free");
                View.UpgradeBtn.onClick.Set(Upgrade_OnClick);
            }

            for (int i = 0; i < property.LevelCap; i++)
            {
                var star = (View_Star) View.Star.AddItemFromPool();
                if (i >= Detail.Level)
                {
                    star.Active.selectedPage = "FALSE";
                }
                else
                {
                    star.Active.selectedPage = "TRUE";
                }
            }

            if (Detail.Level >= property.LevelCap)
            {
                View.MaxLevel.selectedPage = "TRUE";
                View.Language.selectedPage = Language.CurrentLanguage.Value;
            }

            Dictionary<string, RangeInt> changedAttribute = new Dictionary<string, RangeInt>();
            var levels = property.Levels;
            for (int index = 0; index < levels.Count; index++)
            {
                if (levels.Count <= index + 1) //没有找到下一级
                {
                    break;
                }

                var cur = levels[index];
                var next = levels[index + 1];
                if (cur.WorkTime != next.WorkTime)
                {
                    changedAttribute["workTime"] = new RangeInt(cur.WorkTime, next.WorkTime);
                }

                if (cur.BurnTime != next.BurnTime)
                {
                    changedAttribute["burnTime"] = new RangeInt(cur.BurnTime, next.BurnTime);
                }

                if (cur.MakeCount != next.MakeCount)
                {
                    changedAttribute["makeCount"] = new RangeInt(cur.MakeCount, next.MakeCount);
                }

                if (cur == Detail)
                {
                    break;
                }
            }

            if (changedAttribute.TryGetValue("workTime", out var workTime))
            {
                var attribute = (View_cw_updata_item) View.AttributeList.AddItemFromPool();
                attribute.icon.url = attribute.icon0.url = attribute.icon1.url = "ui://Common/icon_cw_work_time";
                attribute.val.text = workTime.Min.ToString();
                attribute.newval.text = workTime.Max.ToString();
                attribute.name.text = string.Format(LocalizationProperty.Read("workTime"), workTime);
            }

            if (changedAttribute.TryGetValue("burnTime", out var burnTime))
            {
                var attribute = (View_cw_updata_item) View.AttributeList.AddItemFromPool();
                attribute.icon.url = attribute.icon0.url = attribute.icon1.url = "ui://Common/icon_cw_burn_speed";
                attribute.val.text = burnTime.Min.ToString();
                attribute.newval.text = burnTime.Max.ToString();
                attribute.name.text = string.Format(LocalizationProperty.Read("burnTime"), burnTime);
            }

            if (changedAttribute.TryGetValue("makeCount", out var makeCount))
            {
                var attribute = (View_cw_updata_item) View.AttributeList.AddItemFromPool();
                attribute.icon.url = attribute.icon0.url = attribute.icon1.url = "ui://Common/icon_cw_add_count";
                attribute.val.text = makeCount.Min.ToString();
                attribute.newval.text = makeCount.Max.ToString();
                attribute.name.text = string.Format(LocalizationProperty.Read("makeCount"), makeCount);
            }

            View.Star.RemoveChildrenToPool();
            for (int i = 0; i < property.LevelCap; i++)
            {
                var star = (View_Star) View.Star.AddItemFromPool();
                if (i < Detail.Level)
                    
                {
                    star.Active.selectedPage = "TRUE";
                }
                else
                {
                    star.Active.selectedPage = "FALSE";
                }
            }
        }

        private void Upgrade_OnClick()
        {
            var prop = Arg.Property;
            if (ResourcesHelper.SpenPrice(Detail.Price,false))
            {
                Data_Cookware dt = DBManager.Inst.Query<Data_Cookware>();
                var info = dt.Get(prop);
                info.Level += 1;
                Message.Send(new CookwareUpgradeSuccess(prop.Id));
                if(Detail.Price.Coin > 0)
                    EffectFactory.Create(new ResourcesBarValueChanged(-Detail.Price.Coin, ResourcesBarValueChanged.ResourceType.Coin));
                if (Detail.Price.Gem > 0)
                    EffectFactory.Create(new ResourcesBarValueChanged(-Detail.Price.Gem, ResourcesBarValueChanged.ResourceType.Gem));
            }

            CloseMySelf();
        }
    }
}