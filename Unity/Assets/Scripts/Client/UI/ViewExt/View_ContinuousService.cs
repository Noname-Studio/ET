using System.ComponentModel;
using FairyGUI;
using Kitchen;
using UnityEngine;

namespace GamingUI
{
    public partial class View_ContinuousService
    {
        private KitchenConfigProperty KitchenGlobalConfig { get; }
        private GProgressBar IntervalProgress { get; set; }
        private GProgressBar ComboTimesProgress { get; set; }

        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            IntervalProgress = Interval.component.asProgress;
            ComboTimesProgress = ComboTimes.component.asProgress;
            IntervalProgress.min = 0;
            IntervalProgress.max = 100;
            IntervalProgress.value = 0;
            ComboTimesProgress.min = 0;
            ComboTimesProgress.max = 4;
            ComboTimesProgress.value = 0;
        }

        public View_ContinuousService()
        {
            KitchenGlobalConfig = KitchenRoot.Inst.KitchenConfig;
            KitchenRoot.Inst.Record.PropertyChanged += RegisterDataUpdate;
        }

        public override void Dispose()
        {
            base.Dispose();
            KitchenRoot.Inst.Record.PropertyChanged -= RegisterDataUpdate;
        }

        private void RegisterDataUpdate(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof (KitchenRecord.ServicesOrderNumber))
            {
                var args = e as IntPropertyChanged;
                if (args != null)
                {
                    ComboTimesProgress.value += args.NewValue - args.OldValue;
                    if (ComboTimesProgress.value == ComboTimesProgress.max)
                    {
                        WhenMaxCombo();
                    }
                    else
                    {
                        SetFullComboTime();
                    }
                }
            }
        }

        private void WhenMaxCombo()
        {
            IntervalProgress.value = 0;
            ComboTimesProgress.value = 0;
        }

        private void SetFullComboTime()
        {
            IntervalProgress.value = 100;
        }

        public void Update()
        {
            IntervalProgress.value -= KitchenGlobalConfig.ComboLoseSpeed * Time.deltaTime;
            if (IntervalProgress.value <= 0)
            {
                ComboTimesProgress.value = 0;
                MessageKit.Inst.Send(EventKey.AdsFailed);
            }
        }
    }
}