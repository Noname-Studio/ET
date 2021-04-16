using System;
using FairyGUI;
using Main;
using Panthea.NativePlugins.IAP;
using RestaurantPreview.Config;

namespace Client.UI.ViewModel
{
    [UIWindow(Enter = WindowAnimType.Fall,Exit = WindowAnimType.Rise)]
    public class UI_StarterPack : UIBase<View_NewPack>
    {
        public class ParamsData: IUIParams
        {
            public IAPProperty Property { get; }

            public ParamsData(IAPProperty property)
            {
                if (property == null)
                {
                    throw new Exception("参数不可以为NULL");
                }
                Property = property;
            }
        }
        
        private ParamsData Args { get; set; }
        
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            Args = p as ParamsData;
            if(Args == null)
            {
                Log.Error("参数错误");
                CloseMySelf();
                return;
            }
            InitUI();
        }

        private void InitUI()
        {
            if (Args.Property.Content.TryGetValue(GameConfig.GemPropKey,out int gem))
            {
                View.Gem.text = "x " + gem;
            }
            if (Args.Property.Content.TryGetValue(GameConfig.InfiniteEnergyPropKey,out var energy))
            {
                var timeSpan = TimeSpan.FromSeconds(energy);
                View.InfineTime.text = ((int) timeSpan.TotalMinutes + LocalizationProperty.Read("Minute"));
            }
            View.buy.onClick.Set(Buy_onClick);
            View.buy.title = IAPKit.Inst.GetLocalizedPriceString(Args.Property.Id);
        }

        private void Buy_onClick(EventContext context)
        {
            IAPKit.Inst.Purchase(Args.Property.Id);
        }
    }
}