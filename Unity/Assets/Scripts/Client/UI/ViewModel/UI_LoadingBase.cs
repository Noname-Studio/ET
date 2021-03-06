﻿using FairyGUI;
using InternalResources;

namespace Client.UI.ViewModel
{
    public class UI_LoadingBase: UIBase<View_Loading>
    {
        public double MaxProgress
        {
            get => View.Progress.max;
            set => View.Progress.max = value;
        }

        public double Value
        {
            get => View.Progress.value;
            set
            {
                GTween.Kill(this, false);
                GTween.ToDouble(Value, value, 0.3f).SetTarget(this).SetEase(EaseType.Linear);
                View.Progress.value = value;
                //ProgressTweener = View.Progress.TweenValue(value, 0.3f);
            }
        }

        public string Title
        {
            get => View.Title.text;
            set => View.Title.text = value;
        }
    }
}