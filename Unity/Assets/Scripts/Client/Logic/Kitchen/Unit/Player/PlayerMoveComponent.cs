using System;
using Pathfinding;
using Unity.Mathematics;
using UnityEngine;

namespace Kitchen
{
    public class PlayerMoveComponent : AIPath
    {
        public bool IsReached { get; private set; } = true;
        private Transform mCacheTransform;
        protected override void Start()
        {
            base.Start();
            mCacheTransform = transform;
            endReachedDistance = 0.1f;
            this.gameObject.AddComponent<FunnelModifier>();
        }

        public void SetDestination(Vector3 vec)
        {
            IsReached = false;
            destination = vec;
            SearchPath();
        }

        public override void FinalizeMovement(Vector3 nextPosition, Quaternion nextRotation)
        {
            if (!IsReached)
            {
                //var dir = position - nextPosition;
                
                
                base.FinalizeMovement(nextPosition, nextRotation);
            }
        }

        public override void OnTargetReached()
        {
            base.OnTargetReached();
            canSearch = false;
            IsReached = true;
        }
    }
}
