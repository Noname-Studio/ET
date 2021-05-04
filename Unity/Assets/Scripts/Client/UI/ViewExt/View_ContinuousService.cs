using System.ComponentModel;
using FairyGUI;
using Kitchen;
using RestaurantPreview.Config;
using UnityEngine;

namespace GamingUI
{
    public partial class View_ContinuousService
    {
        private GProgressBar IntervalProgress { get; set; }
        private GProgressBar ComboTimesProgress { get; set; }
        private KitchenRecord Record { get; set; }
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
            Record = KitchenRoot.Inst.Record;
            Record.PropertyChanged += RegisterDataUpdate;
        }

        public override void Dispose()
        {
            base.Dispose();
            Record.PropertyChanged -= RegisterDataUpdate;
        }

        private void RegisterDataUpdate(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof (KitchenRecord.ServicesOrderNumber))
            {
                var args = e as IntPropertyChanged;
                if (args != null)
                {
                    ComboTimesProgress.value += args.NewValue - args.OldValue;
                    if (ComboTimesProgress.value == 3)
                    {
                        Record.Combo3++;
                        Record.TipsNumber += Mathf.CeilToInt(KitchenRoot.Inst.LevelProperty.Combo.Gain * 3);
                    }
                    if (ComboTimesProgress.value == 4)
                    {
                        WhenMaxCombo();
                        Record.Combo4++;
                        Record.TipsNumber += Mathf.CeilToInt(KitchenRoot.Inst.LevelProperty.Combo.Gain * 4);
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
            IntervalProgress.value -= GlobalConfigProperty.Read("ComboLoseSpeed").Int * Time.deltaTime;
            if (IntervalProgress.value <= 0)
            {
                ComboTimesProgress.value = 0;
            }
        }
    }
}