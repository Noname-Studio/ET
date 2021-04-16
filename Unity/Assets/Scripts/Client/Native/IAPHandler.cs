using Client.Effect;
using Manager;
using Panthea.NativePlugins.Analytics;
using RestaurantPreview.Config;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Client.Logic.Helpler;
using UnityEngine.Purchasing;

namespace Client.Native
{
    public class IAPHandler : Singleton<IAPHandler>
    {
        [RuntimeInitializeOnLoadMethod]
        static void Init()
        {
            var init = Inst;
        }
        
        private IAPHandler(){}
        public override void OnInit()
        {
            base.OnInit();
            MessageKit.Inst.Add(EventKey.IAPPurchaseSuccess, Event_IAPSuccess);
            MessageKit.Inst.Add(EventKey.IAPPurchaseFailed, Event_IAPFailed);
        }

        public override void OnRelease()
        {
            base.OnRelease();
            MessageKit.Inst.Remove(EventKey.IAPPurchaseSuccess, Event_IAPSuccess);
            MessageKit.Inst.Remove(EventKey.IAPPurchaseFailed, Event_IAPFailed);
        }
        
        private void Event_IAPSuccess(object obj)
        {
            var purchaseEvent = obj as PurchaseEventArgs;
            if (purchaseEvent == null)
            {
                Log.Error("购买发生错误");
                return;
            }
            var property = IAPProperty.Read(purchaseEvent.purchasedProduct.definition.id);
            if (property == null)
            {
                Log.Error($"IAP配置表中不存在{purchaseEvent.purchasedProduct.definition.id}该字段");
                return;
            }
            AnalyticsKit.Inst.IAPTransaction(IAPType.Store, -1, LocalizationProperty.Read(property.Name));
            foreach (var node in property.Content)
            {
                var prop = PropProperty.Read(node.Key);
                if (prop == null)
                {
                    Log.Error("IAP的购买内容中存在不存在的物品内容,IAP ID:" + property.Id + " 不存在的物品ID:" + node.Key);
                    continue;
                }

                if (prop.Type == PropProperty.TypeEnum.Level || prop.Type == PropProperty.TypeEnum.InTheLevel )
                {
                    DBManager.Inst.Query<Data_Prop>().IncrementNumByKey(prop.Id, node.Value);
                }

                if (prop.Id == GameConfig.InfiniteEnergyPropKey)
                {
                    EnergyManager.Inst.AddInfineTime(node.Value);
                }
                else if (prop.Id == GameConfig.GemPropKey)
                {
                    ResourcesHelper.GainGem(node.Value);
                    EffectFactory.Create(new ResourcesBarValueChanged(node.Value, ResourcesBarValueChanged.ResourceType.Gem));
                }
                else if (prop.Id == GameConfig.CoinPropKey)
                {
                    ResourcesHelper.GainGameCoin(node.Value);
                    EffectFactory.Create(new ResourcesBarValueChanged(node.Value, ResourcesBarValueChanged.ResourceType.Coin));
                }
            }

            UIKit.Inst.Create<UI_PropRewardTips>(new UI_PropRewardTips.UIParamsData(property.Content));

        }
        
        private void Event_IAPFailed()
        {
        }
    }
}