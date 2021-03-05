using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace Kitchen
{
    public class SpineAnimation : IAnimation
    {
        private readonly SkeletonAnimation mInst;
        private Skeleton mSkeleton;
        private Transform mCacheTransform;

        public bool Loop
        {
            get => mInst.loop;
            set => mInst.loop = value;
        }

        public string AnimationName
        {
            get => mInst.AnimationName;
            set => mInst.AnimationName = value;
        }

        private Vector3 mClockPos;
        public Vector3 ClockPos
        {
            get => mClockPos;
            private set => mClockPos = value;
        }

        private Vector3 mFoodPos;
        public Vector3 FoodPos
        {
            get => mFoodPos;
            private set => mFoodPos = value;
        }

        
        public SpineAnimation(SkeletonAnimation inst)
        {
            if (inst == null)
            {
                throw new Exception("动画文件不能为空");
            }
            mInst = inst;
            mCacheTransform = mInst.transform;
            mSkeleton = mInst.Skeleton;
            mSkeleton.UpdateWorldTransform();
            var bone = mSkeleton.FindBone("food");
            if(bone != null)
                FoodPos = bone.GetWorldPosition(mCacheTransform);
            bone = mSkeleton.FindBone("clock");
            if(bone != null)
                ClockPos = bone.GetWorldPosition(mCacheTransform);
        }
    }
}
