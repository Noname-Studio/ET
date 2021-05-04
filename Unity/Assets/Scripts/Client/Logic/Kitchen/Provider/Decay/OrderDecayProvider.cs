using System;
using UnityEngine;

namespace Kitchen.Decay
{
    public class OrderDecayProvider
    {
        private DecayData Data { get; }
        private float mTime { get; set; }
        private float CountingValue { get; set; }
        public OrderDecayProvider(DecayData data)
        {
            Data = data ?? throw new Exception("参数不正确,DecayData is Null");
        }

        public void Update()
        {
            mTime += Time.deltaTime;
            if (CountingValue >= Data.Limit)
                return;
            if (mTime >= Data.Interval)
            {
                mTime = 0;
                KitchenRoot.Inst.CustomerProvider.GenerateDecay += Data.Rate;
                CountingValue += Data.Rate;
            }
        }

        public void Reset()
        {
            CountingValue = 0;
            mTime = 0;
        }
    }
}