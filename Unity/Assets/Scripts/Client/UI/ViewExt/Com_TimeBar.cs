using System;
using FairyGUI;
using TMPro;
using UnityEngine;

namespace GamingUI
{
    public class Com_TimeBar
    {
        private float time;
        private GProgressBar Bar { get; }

        public double Value
        {
            get => Bar.value;
            set => Bar.value = value;
        }

        public double Min
        {
            get => Bar.min;
            set => Bar.min = value;
        }

        public double Max
        {
            get => Bar.max;
            set => Bar.max = value;
        }

        public event Action<double, GProgressBar> ValueChangedCallback;

        public Com_TimeBar(GProgressBar progressBar)
        {
            Bar = progressBar;
        }

        public void Update()
        {
            if (Bar.value <= 0)
            {
                Bar.value = 0;
                Bar.GetChild("txt").asTextField.text = "0:00";
                return;
            }

            time += Time.unscaledDeltaTime;
            if (time > 1)
            {
                Bar.value -= time;
                ValueChangedCallback(Bar.value, Bar);
                time = 0;
                Bar.GetChild("txt").asTextField.text = TimeUtils.ConvertNumberToTimeString(Bar.value, @"m\:ss");
            }
        }
    }
}