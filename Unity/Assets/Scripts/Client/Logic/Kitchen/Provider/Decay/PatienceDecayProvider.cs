using System;
using RestaurantPreview.Config;
using UnityEngine;

namespace Kitchen.Decay
{
    public class PatienceDecayProvider
    {
        private DecayData Data { get; }
        private float mTime { get; set; }
        public PatienceDecayProvider(DecayData data)
        {
            Data = data ?? throw new Exception("参数不正确,DecayData is Null");
        }

        public void Update()
        {
            mTime += Time.deltaTime;
            if (mTime >= Data.Interval)
            {
                mTime = 0;
                foreach (var node in KitchenRoot.Inst.CustomerProvider.ActiveCustomer)
                {
                    var patience = node.Components.Get<PatienceComponent>();
                    if (patience != null)
                    {
                        if (Data.Rate > 0)
                        {
                            if(patience.LoseSpeed < Data.Limit)
                                patience.LoseSpeed += Data.Rate;
                            else
                                patience.LoseSpeed = Data.Limit;
                        }
                        else
                        {
                            if (patience.LoseSpeed > Data.Limit)
                                patience.LoseSpeed += Data.Rate;
                            else
                                patience.LoseSpeed = Data.Limit;
                        }
                    }
                }
            }
        }
    }
}