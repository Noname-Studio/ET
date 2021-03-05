using UnityEngine;

namespace Kitchen
{
    /// <summary>
    /// 正常关卡的锚点位置.标记顾客到达目标点之后点餐
    /// </summary>
    public partial class KitchenNormalSpot : AKitchenSpot
    {
        public Vector3 OrderPosition { get; private set;}
        public KitchenNormalSpot(UnityObject display) : base(display)
        {
            OrderPosition = display.Find("Order").Position;
            #if UNITY_EDITOR
            Editor_Initialize();
            #endif
        }
    }
    
#if UNITY_EDITOR
    partial class KitchenNormalSpot
    {
        public void Editor_Initialize()
        {
            UnityLifeCycleKit.Inst.AddUpdate(Editor_Update);
        }
        private float Editor_Update()
        {
            OrderPosition = Display.Find("Order").Position;
            return 0;
        }
    }
#endif
}

