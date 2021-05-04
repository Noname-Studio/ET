using FairyGUI;
using UnityEngine;

namespace Kitchen
{
    /// <summary>
    /// 正常关卡的锚点位置.标记顾客到达目标点之后点餐
    /// </summary>
    public partial class KitchenNormalSpot: AKitchenSpot
    {
        private UnityObject OrderObject { get; }
        public Vector3 OrderPosition { get; private set; }
        public UIPanel OrderUI { get; }

        public KitchenNormalSpot(UnityObject display): base(display)
        {
            OrderObject = display.Find("Order");
            OrderPosition = OrderObject.Position;
            OrderUI = OrderObject.GetComponent<UIPanel>();
            //OrderUI.CreateUI();
            OrderUI.ui.scale = new Vector2(0.4f, 0.4f);
            OrderUI.transform.eulerAngles = new Vector3(30, 135, 0);
            OrderUI.ui.visible = false;
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
            if (Display.IsDisposed())
                return -1;
            OrderPosition = Display.Find("Order").Position;
            return 0;
        }
    }
#endif
}