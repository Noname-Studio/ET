using System;
using System.Reflection;
using UnityEngine;

namespace Kitchen.Robot
{
    public class RobotInput
    {
        private PlayerController mPlayerController;
        private Action<InputHandler, RaycastHit> doJobDelegate;
        private Camera mCamera;
        private InputHandler KitchenPlayerInputHandler;
        private RaycastHit[] mRaycastResult = new RaycastHit[10];

        public RobotInput(PlayerController playerController, Camera camera)
        {
            mPlayerController = playerController;
            mCamera = camera;
            KitchenPlayerInputHandler = (InputHandler) mPlayerController.GetType().GetField("mInput", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(mPlayerController);
            doJobDelegate = (Action<InputHandler, RaycastHit>) KitchenPlayerInputHandler.GetType()
                    .GetMethod("DoJob", BindingFlags.Instance | BindingFlags.NonPublic).CreateDelegate(typeof (Action<InputHandler, RaycastHit>));
        }

        public void DoJob(UnityObject uo)
        {
            Vector3 inputPosition = mCamera.WorldToScreenPoint(uo.Position);
            var ray = mCamera.ScreenPointToRay(inputPosition);
            //因为机器人无法做到精确得点击.比如说点击顾客得时候可能会点击到顾客身前的厨具(因为顾客的锚点在脚底下,如果在头顶可能可以避免这种情况)
            //所以这里我们使用Raycast获得数组.匹配是否是自己想要点击的目标
            if (Physics.RaycastNonAlloc(ray, mRaycastResult) > 0)
            {
                foreach (var node in mRaycastResult)
                {
                    if (uo.Equals(node.transform))
                    {
                        doJobDelegate(KitchenPlayerInputHandler, node);
                    }
                }
            }
        }
    }
}