using Cysharp.Threading.Tasks;
using Panthea.Asset;
using Pathfinding;
using UnityEngine;

namespace Kitchen
{
    public class PlayerDisplay
    {
        public PlayerMoveComponent MoveCom;
        public UnityObject Go;
        public AnimatorControl Animator;
        private RuntimeAnimatorController mRAC;
        public PlayerDisplay(UnityObject go)
        {
            Go = go;
            MoveCom = Go.AddComponent<PlayerMoveComponent>();
            MoveCom.whenCloseToDestination = CloseToDestinationMode.ContinueToExactDestination;
            MoveCom.radius = 0.25f;
            MoveCom.maxSpeed = 6;
            MoveCom.slowWhenNotFacingTarget = false;
            MoveCom.rotationSpeed = float.MaxValue;
            MoveCom.maxAcceleration = float.MaxValue;
            MoveCom.gravity = Vector3.zero;
            MoveCom.slowdownDistance = 0;
            Animator = Go.GetComponent<AnimatorControl>();
            var task = AssetsKit.Inst.Load<RuntimeAnimatorController>("Model/Roles/Lisa/Kitchen").AsTask();
            mRAC = task.Result;
            Animator.ReplaceController(mRAC);
        }

        public void Dispose()
        {
            AssetsKit.Inst.ReleaseInstance(mRAC);
        }
    }
}
