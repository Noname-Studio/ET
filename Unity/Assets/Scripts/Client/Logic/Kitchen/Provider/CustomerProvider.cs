using System.Collections.Generic;
using RestaurantPreview.Config;
using UnityEngine;

namespace Kitchen
{
    /// <summary>
    /// 顾客相关的接口。负责顾客的生成和管理
    /// </summary>
    public class CustomerProvider
    {
        /// <summary>
        /// 生成订单的衰减值,这是加快订单速度的唯一参数
        /// 受OrderDecayProvider 映像
        /// </summary>
        public float GenerateDecay { get; set; } = 0;
        public List<ACustomer> ActiveCustomer { get; } = new List<ACustomer>();
        private LevelProperty mLevelProperty;
        private Stack<ACustomer> mPool = new Stack<ACustomer>();
        private List<ACustomerGenerator> mCustomerGenerators = new List<ACustomerGenerator>();
        private KitchenSpotProvider mSpotProvider;
        public int RemainingCustomer { get; private set; }

        public CustomerProvider(KitchenSpotProvider spotProvider, LevelProperty levelProperty,int remaining)
        {
            mSpotProvider = spotProvider;
            mLevelProperty = levelProperty;
            RemainingCustomer = remaining;
        }

        public void AddGenerator(ACustomerGenerator generator)
        {
            mCustomerGenerators.Add(generator);
        }

        public void RemoveGenerator(ACustomerGenerator generator)
        {
            mCustomerGenerators.Remove(generator);
        }

        public void ClearGenerator()
        {
            mCustomerGenerators.Clear();
        }

        public void Push(ACustomer customer)
        {
            mPool.Push(customer);
            ActiveCustomer.Remove(customer);
        }

        public ACustomer Pop()
        {
            if (mPool.Count > 0)
            {
                return mPool.Pop();
            }
            else
            {
                return null;
            }
        }

        public bool HasActiveCustomer()
        {
            return ActiveCustomer.Count > 0;
        }

        /// <summary>
        /// 每帧执行一次.如果有空闲的餐位.则增加计时器中的秒数.
        /// </summary>
        public void Update()
        {
            if (RemainingCustomer == 0)
                return;
            foreach (var generator in mCustomerGenerators)
            {
                if (!mSpotProvider.AnyFree())
                {
                    break;
                }

                if (mLevelProperty.MaxCustomerNumber != 0)
                {
                    int count = 0;
                    for (int i = 0; i < ActiveCustomer.Count; i++)
                    {
                        var state = ActiveCustomer[i].State;
                        if (state == CustomerState.Wait || state == CustomerState.Enter)
                        {
                            count++;
                        }
                    }

                    if (count >= mLevelProperty.MaxCustomerNumber)
                    {
                        break;
                    }
                }

                generator.ActiveTime += Time.unscaledDeltaTime;
                LevelProperty.CustomerOrder order = generator.Run(GenerateDecay);
                if (order != null)
                {
                    var spot = mSpotProvider.GetFreeSpot();
                    ACustomer customerDisplay = Pop();
                    if (customerDisplay == null)
                    {
                        customerDisplay = CustomerFactory.CreateNormalCustomer(order, spot);
                    }
                    else
                    {
                        customerDisplay = CustomerFactory.CreateNormalCustomer(customerDisplay, order, spot);
                    }

                    ActiveCustomer.Add(customerDisplay);
                    mSpotProvider.LockSpot(spot, customerDisplay);
                    if (RemainingCustomer > 0)
                        RemainingCustomer--;
                }
            }
        }
    }
}