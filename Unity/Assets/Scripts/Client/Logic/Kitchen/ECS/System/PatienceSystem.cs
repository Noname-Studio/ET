using Leopotam.Ecs;
using UnityEngine;

namespace Kitchen
{
    public class PatienceSystem: IEcsRunSystem
    {
        //private EcsFilter<PatienceComponent> mFilter;
        public void Run()
        {
            //    foreach (var node in mFilter)
            //    {
            //        ref var com = ref mFilter.Get1(node);
            //        com.Value -= Time.unscaledDeltaTime * com.LoseSpeed;
            //    }
        }
    }
}