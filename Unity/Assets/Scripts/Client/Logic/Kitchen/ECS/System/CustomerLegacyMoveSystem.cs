using Leopotam.Ecs;
using UnityEngine;

namespace Kitchen
{
    public class CustomerLegacyMoveSystem : IEcsRunSystem
    {
        //EcsFilter<CustomerMoveComponent> mFilter = null;
        public void Run()
        {
        //    foreach (var index in mFilter)
        //    {
        //        var node = mFilter.Get1(index);
        //        var transform = node.Display;
        //        float step =  node.Speed * Time.deltaTime;
        //        transform.Position = Vector3.MoveTowards(transform.Position, node.To, step);
        //    }    
        }
    }
}