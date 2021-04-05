using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kitchen
{
    public interface IUnit
    {
        void Update();
        void Dispose();
    }

    public static class UnitExt
    {
        public static Task PlayAnimation(this IUnit unit,string animation)
        {
            if(unit is PlayerController player)
                return player.Animator.PlayAsync(animation);
            else if(unit is ACustomer customer)
                return customer.Animator.PlayAsync(animation);
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}