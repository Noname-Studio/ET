using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Pathfinding;
using UnityEngine;

namespace Kitchen
{
    public class PlayerController : IUnit
    {
        public List<IBuff> Buff { get; } = new List<IBuff>();

        public enum MovingState
        {
            Moving, //正在移动中
            InDestination, //是否已经抵达终点
            Error, //目标点已经被修改
        }

        private InputHandler mInput;
        private PlayerDisplay mDisplay;
        public AnimatorControl Animator;
        public HandProvider HandProvider;

        private List<string> mHandItem;
        private UnityBehaviour mBehaviour;

        public Vector3 Position
        {
            get => mDisplay.Go.Position;
            set => mDisplay.Go.Position = value;
        }

        public Quaternion Rotation
        {
            get => mDisplay.Go.Rotation;
            set => mDisplay.Go.Rotation = value;
        }

        public PlayerController(PlayerDisplay playerDisplay)
        {
            mBehaviour = UnityLifeCycleKit.Inst;            
            mBehaviour.AddUpdate(Update);

            mDisplay = playerDisplay;
            Animator = playerDisplay.Animator;
            
            //创建操作控制器
            mInput = new InputHandler();
            mInput.Init(this);
            
            //创建操作手
            HandProvider = new HandProvider();
            //一定要先添加左手在添加右手,左手没食物.那么要将右手的食物传递给左手.因为动画拿取一个菜盘的只有左手.没有右手
            HandProvider.AddHand("Right",mDisplay.Go.Find("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 R Clavicle/Bip01 R UpperArm/Bip01 R Forearm/Bip01 R Hand/HoldItem"));
            HandProvider.AddHand("Left",mDisplay.Go.Find("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 L Clavicle/Bip01 L UpperArm/Bip01 L Forearm/Bip01 L Hand/HoldItem"));
            
            UnitManager.Inst.Register(this);
            //TODO 测试代码
            //mDisplay.Go.AddModule(new TrailVFX());
        }

        #region 公共方法
        /// <summary>
        /// 移动到目标点.如果目标点无法到达则移动至最近的目标点,ref 将把传入的坐标校对为最近的点以方便后续校验坐标是否修改
        /// </summary>
        /// <param name="position"></param>
        public void MoveToPoint(ref Vector3 position)
        {
            mDisplay.MoveCom.SetPath(null);
            mDisplay.MoveCom.canSearch = true;
            mDisplay.MoveCom.isStopped = false;
            var node = AstarPath.active.GetNearest ( position, NNConstraint.Default );
            if (node.node == null)
                return;
            position = node.position;
            mDisplay.MoveCom.SetDestination(position);
        }

        /// <summary>
        /// 检查目标点是否被篡改.如果被篡改了则返回Error,如果未到达目标点则返回Moving.到达了目标点返回InDestination
        /// </summary>
        /// <param name="position"></param>
        public MovingState IsMoving(Vector3 position)
        {
            //TODO 当前还未实现人物2D平面移动
            //return MovingState.InDestination;
            if (mDisplay.MoveCom.destination != position)
                return MovingState.Error;
            if (mDisplay.MoveCom.IsReached)
                return MovingState.InDestination;
            return MovingState.Moving;
        }

        
        #endregion
        
        private float Update()
        {
            UpdateAnimation();
            HandProvider.Update();
            return 0;
        }

        private void UpdateAnimation()
        {
            HandProvider.Get(ref mHandItem);
            if (mDisplay.MoveCom.IsReached == false && mDisplay.MoveCom.hasPath)
            {
                if (mHandItem.Count == 0)
                {
                    if(Animator.PlayingAnimation != "Walk")
                        Animator.Play("Walk");
                }
                else if (mHandItem.Count == 1)
                {
                    if(Animator.PlayingAnimation != "HoldingOneWalk")
                        Animator.Play("HoldingOneWalk");
                }
                else if (mHandItem.Count == 2)
                {
                    if(Animator.PlayingAnimation != "HoldingTwoWalk")
                        Animator.Play("HoldingTwoWalk");
                }
            }
            else
            {
                if (mHandItem.Count == 0)
                {
                    if(!Animator.PlayingAnimation.StartsWith("Idle"))
                        Animator.Play("Idle");
                }
                else if (mHandItem.Count == 1)
                {
                    if(!Animator.PlayingAnimation.StartsWith("HoldingOneIdle"))
                        Animator.Play("HoldingOneIdle");
                }
                else if (mHandItem.Count == 2)
                {
                    if(Animator.PlayingAnimation != "HoldingTwoIdle")
                        Animator.Play("HoldingTwoIdle");
                }
            }
        }
        
        public void Dispose()
        {
            HandProvider.Dispose();
        }
        
        /// <summary>
        /// 转向目标
        /// </summary>
        public void LookAt(Vector3 targetPosition)
        {
            Vector3 dir = targetPosition - mDisplay.Go.Position;
            var angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            mDisplay.Go.Rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
    }
}
