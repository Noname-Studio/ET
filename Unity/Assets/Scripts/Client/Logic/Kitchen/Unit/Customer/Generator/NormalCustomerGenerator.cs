using System.Collections.Generic;
using RestaurantPreview.Config;
using UnityEngine;

namespace Kitchen
{
    /// <summary>
    /// 常规顾客生成器
    /// </summary>
    public class NormalCustomerGenerator: ACustomerGenerator
    {
        //固定时间抵达顾客.只有这些都抵达了才会计算时间到达顾客
        private List<KeyValuePair<float, LevelProperty.CustomerOrder>> mFixedTimes = new List<KeyValuePair<float, LevelProperty.CustomerOrder>>();

        //下次顾客抵达时间
        private float mNextTime = 0;

        //顾客循环索引
        private int mOrderIndex = 0;

        public NormalCustomerGenerator(LevelProperty levelProperty): base(levelProperty)
        {
            foreach (var node in levelProperty.FirstArrivals)
            {
                var customer = GetRecyleCustomer();
                mFixedTimes.Add(new KeyValuePair<float, LevelProperty.CustomerOrder>(node, customer));
                mNextTime = node;
            }

            mNextTime += Random.Range(levelProperty.OrderInterval.Min, levelProperty.OrderInterval.Max);
        }

        public override LevelProperty.CustomerOrder Run(float decay)
        {
            if (mFixedTimes.Count > 0)
            {
                for (var index = 0; index < mFixedTimes.Count; index++)
                {
                    var node = mFixedTimes[index];
                    if (ActiveTime >= node.Key)
                    {
                        mFixedTimes.RemoveAt(index);
                        return node.Value;
                    }
                }
            }
            else if (ActiveTime >= mNextTime)
            {
                mNextTime = ActiveTime + Random.Range(LevelProperty.OrderInterval.Min - decay, LevelProperty.OrderInterval.Max - decay);
                return GetRecyleCustomer();
            }

            return null;
        }

        private LevelProperty.CustomerOrder GetRecyleCustomer()
        {
            if (mOrderIndex >= LevelProperty.Orders.Count)
            {
                mOrderIndex = 0;
            }

            var order = LevelProperty.Orders[mOrderIndex];
            mOrderIndex++;
            return order;
        }
    }
}