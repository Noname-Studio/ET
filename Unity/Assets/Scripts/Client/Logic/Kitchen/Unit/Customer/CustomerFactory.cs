using Cysharp.Threading.Tasks;
using Panthea.Asset;
using RestaurantPreview.Config;
using UnityEngine;

namespace Kitchen
{
    public static class CustomerFactory
    {
        public static ACustomer CreateNormalCustomer(LevelProperty.CustomerOrder order, AKitchenSpot spot)
        {
            var customerProperty = order.Customer;
            var obj = AssetsKit.Inst.Instantiate(CustomerProperty.Random().ModelPath, spot.Position + new Vector3(8, 0, 0)).AsTask();
            var customer = new NormalCustomer(obj.Result, (KitchenNormalSpot) spot, order);
            return customer;
        }

        public static ACustomer CreateNormalCustomer(ACustomer customer, LevelProperty.CustomerOrder order, AKitchenSpot spot)
        {
            var obj = customer.Display;
            customer = new NormalCustomer(obj, (KitchenNormalSpot) spot, order);
            return customer;
        }
    }
}