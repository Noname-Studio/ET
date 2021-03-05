using UnityEngine;

namespace Kitchen
{
    public class ClickIngredient : IGameAction
    {
        private PlayerController mPlayer { get; }
        private IngredientDisplay Target { get; }
        private Vector3 mPosition;
        private QueueEventsKit ActionManager { get; } 
        public ClickIngredient(PlayerController player,IngredientDisplay target)
        {
            mPlayer = player;
            Target = target;
            ActionManager = QueueEventsKit.Inst;
            mPosition = Target.Display.Position;
        }

        public void Execute()
        {
            //先移动到目标点
            mPlayer.MoveToPoint(ref mPosition);
        }
    
        public bool Update()
        {
            var playerState = mPlayer.IsMoving(mPosition);
            if (playerState == PlayerController.MovingState.Moving)
            {
                return false;
            }

            if (playerState == PlayerController.MovingState.InDestination)
            {
                if(mPlayer.HandProvider.HasFreeSpace())
                    ActionManager.AddToTop(new TakeFood(mPlayer,Target));
                else
                {
                    mPlayer.HandProvider.RemoveAll(Target.FoodId);
                }
            }
            return true;
        }
    }

}