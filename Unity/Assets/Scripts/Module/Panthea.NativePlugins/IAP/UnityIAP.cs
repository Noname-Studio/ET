using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.Purchasing;

namespace Panthea.NativePlugins.IAP
{
    public class UnityIAP : IStoreListener
    {
        public bool InitializationComplete { get; private set; } = false;
        private IStoreController controller { get; set; }
        private IExtensionProvider extensions { get; set; }
        private UniTaskCompletionSource<PurchaseEventArgs> Utcs { get; set; }
        public void ReloadConfig(Dictionary<string,ProductType> productId)
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            foreach (var node in productId)
            {
                if(node.Value == ProductType.Consumable)
                    builder.AddProduct(node.Key, UnityEngine.Purchasing.ProductType.Consumable);
                else if(node.Value == ProductType.Subscription)
                    builder.AddProduct(node.Key, UnityEngine.Purchasing.ProductType.Subscription);
                else if(node.Value == ProductType.NonConsumable)
                    builder.AddProduct(node.Key, UnityEngine.Purchasing.ProductType.NonConsumable);
            }
            UnityPurchasing.Initialize(this, builder);
        }
    
        /// <summary>
        /// Called when Unity IAP is ready to make purchases.
        /// </summary>
        public void OnInitialized (IStoreController controller, IExtensionProvider extensions)
        {
            InitializationComplete = true;
            this.controller = controller;
            this.extensions = extensions;
        }
    
        /// <summary>
        /// Called when Unity IAP encounters an unrecoverable initialization error.
        ///
        /// Note that this will not be called if Internet is unavailable; Unity IAP
        /// will attempt initialization until it becomes available.
        /// </summary>
        public void OnInitializeFailed (InitializationFailureReason error)
        {
            Log.Error("无法初始化IAP系统,错误代码:" + error);
        }
    
        /// <summary>
        /// Called when a purchase completes.
        ///
        /// May be called at any time after OnInitialized().
        /// </summary>
        public PurchaseProcessingResult ProcessPurchase (PurchaseEventArgs e)
        {
            MessageKit.Inst.Send(EventKey.IAPPurchaseSuccess, e);
            return PurchaseProcessingResult.Complete;
        }

        public void Purchase(string productId)
        {
            if (controller == null)
            {
                Log.Error("购买失败,因为IAP尚未初始化");
                MessageKit.Inst.Send(EventKey.IAPPurchaseFailed);
                return;
            }
            controller.InitiatePurchase(productId);
        }

        public string GetLocalizedPriceString(string productId)
        {
            if (controller == null)
            {
                Log.Error("无法获得价格,可能是IAP尚未初始化,如果是在编辑器内可能是没有把ID添加到catlog当中");
                return "$0.00";
            }
            return controller.products.WithID(productId).metadata.localizedPriceString;
        }

        public bool HasPurchased(string productId)
        {
            if (controller == null)
            {
                return false;
            }
            return controller.products.WithID(productId).hasReceipt;
        }
        
        /// <summary>
        /// Called when a purchase fails.
        /// </summary>
        public void OnPurchaseFailed (Product i, PurchaseFailureReason p)
        {
        }
    }
}
