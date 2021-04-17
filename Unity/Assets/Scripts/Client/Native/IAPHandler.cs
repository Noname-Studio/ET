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
            UI_PropRewardTips.Pop(property.Content);

        }
        
        private void Event_IAPFailed()
        {
        }
    }
}