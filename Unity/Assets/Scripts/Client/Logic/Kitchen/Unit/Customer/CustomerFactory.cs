using Cysharp.Threading.Tasks;
using Panthea.Asset;
using UnityEngine;

namespace Kitchen
{
    public static class CustomerFactory
    {
        public static ACustomer CreateNormalCustomer(CustomerOrder order,AKitchenSpot spot)
        {
            var customerProperty = order.Customer;
            var obj = AssetsKit.Inst.Instantiate(customerProperty.ModelPath, spot.Position + new Vector3(8,0,0)).AsTask();
            var customer = new NormalCustomer(obj.Result, (KitchenNormalSpot)spot,order);
            return customer;
        }
        
        public static ACustomer CreateNormalCustomer(ACustomer customer,CustomerOrder order,AKitchenSpot spot)
        {
            var obj = customer.Display;
            customer = new NormalCustomer(obj, (KitchenNormalSpot)spot, order);
            return customer;
        }
    }

}
