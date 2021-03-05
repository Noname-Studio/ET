using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
    /// <summary>
    /// 顾客相关的接口。负责顾客的生成和管理
    /// </summary>
    public class CustomerProvider
    {
        private List<ACustomer> mActiveCustomer = new List<ACustomer>();
        private LevelProperty mLevelProperty;
        private Stack<ACustomer> mPool = new Stack<ACustomer>();
        private List<ACustomerGenerator> mCustomerGenerators = new List<ACustomerGenerator>();
        private KitchenSpotProvider mSpotProvider;
        public CustomerProvider(KitchenSpotProvider spotProvider,LevelProperty levelProperty)
        {
            mSpotProvider = spotProvider;
            mLevelProperty = levelProperty;
            UnityLifeCycleKit.Inst.AddUpdate(Run);
        }
        
        public void AddGenerator(ACustomerGenerator generator)
        {
            mCustomerGenerators.Add(generator);
        }
        
        public void RemoveGenerator(ACustomerGenerator generator)
        {
            mCustomerGenerators.Remove(generator);
        }

        public void Push(ACustomer customer)
        {
            mPool.Push(customer);
            mActiveCustomer.Remove(customer);
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
        
        /// <summary>
        /// 每帧执行一次.如果有空闲的餐位.则增加计时器中的秒数.
        /// </summary>
        private float Run()
        {
            foreach (var node in mCustomerGenerators)
            {
                if (!mSpotProvider.AnyFree())
                {
                    break;
                }

                if (mLevelProperty.MaxCustomerNumber != 0)
                {
                    int count = 0;
                    for(int i = 0;i<mActiveCustomer.Count;i++)
                    {
                        var state = mActiveCustomer[i].State;
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
                
                node.ActiveTime += Time.unscaledDeltaTime;
                CustomerOrder order = node.Run();
                if (order != null)
                {
                    var spot = mSpotProvider.GetFreeSpot();
                    ACustomer customerDisplay = Pop();
                    if (customerDisplay == null)
                        customerDisplay = CustomerFactory.CreateNormalCustomer(order, spot);
                    else
                    {
                        customerDisplay = CustomerFactory.CreateNormalCustomer(customerDisplay, order, spot);
                        customerDisplay.Display.Active = true;
                    }
                    mActiveCustomer.Add(customerDisplay);
                    mSpotProvider.LockSpot(spot, customerDisplay);
                }
            }
            return 0;
        }
    }
}
