using System;
using Client.Event;
using Common;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Client.Logic.Helpler;

namespace Client.UI.ViewModel
{
    [UIWindow(Enter = WindowAnimType.Custom,Exit = WindowAnimType.Custom,GetControl = true,IngoreBack = true,Depth = UIDeepEnum.ResourcesBar)]
    public class UI_ResourcesBar : UIBase<View_ResourcesBar>
    {
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.AddHealth.onClick.Add(AddEnergy_OnClick);
            View.AddDiamond.onClick.Add(AddDiamond_OnClick);
        }
        
        protected override void OnEnable(IUIParams p, bool refresh)
        {
            if (refresh)
            {
                Message.Add<CoinChanged>(Event_CoinChanged);
                Message.Add<GemChanged>(Event_GemChanged);
                Message.Add(EventKey.CurEnergyChange, Event_CurEnergyChanged);
                View.Coin.text = ResourcesHelper.GetCoin().ToString();
                View.Gem.text = ResourcesHelper.GetGem().ToString();
                View.Energy.text = EnergyManager.Inst.CurEnergy.ToString();
            }
        }

        protected override void OnDisable(bool refresh)
        {
            if (refresh)
            {
                Message.Remove<CoinChanged>(Event_CoinChanged);
                Message.Remove<GemChanged>(Event_GemChanged);
                Message.Remove(EventKey.CurEnergyChange, Event_CurEnergyChanged);
            }
        }
        
        private void Event_CurEnergyChanged()
        {
            //View.Energy.text = EnergyManager.Inst.CurEnergy.ToString();
        }

        private void Event_GemChanged(GemChanged gemChanged)
        {
            //View.Gem.text = gemChanged.NewValue.ToString();
        }

        private void Event_CoinChanged(CoinChanged coinChanged)
        {
            //View.Coin.text = coinChanged.NewValue.ToString();
        }

        private void AddDiamond_OnClick()
        {
            var bank = UIKit.Inst.Create<UI_Bank>();
            bank.SetPage("Diamond");
        }

        private void AddEnergy_OnClick()
        {
            
        }

        public override void Update()
        {
            base.Update();
            if (EnergyManager.Inst.IsInfine)
            {
                View.EnergyTime.text = EnergyManager.Inst.InfineTimeSpan.ToString(@"hh\:mm\:ss");
                View.EnergyTime.visible = View.EnergyFrame.visible = true;
            }
            else if (!EnergyManager.Inst.IsLimit)
            {
                var timer = EnergyManager.Inst.NormalTimer;
                View.EnergyTime.text = TimeSpan.FromSeconds(timer.Interval - timer.CountingTime).ToString(@"hh\:mm\:ss");
                View.Energy.text = EnergyManager.Inst.CurEnergy.ToString();
                View.EnergyTime.visible = View.EnergyFrame.visible = true;
            }
            else
            {
                View.EnergyTime.visible = View.EnergyFrame.visible = false;
            }
        }

        public override void DoHideAnimation()
        {
            View.Out.Play(1, 0, () => base.DoHideAnimation());
        }

        public override void DoShowAnimation()
        {
            View.Out.PlayReverse(1, 0, () => base.DoShowAnimation());
        }
    }
}