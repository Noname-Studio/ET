using UnityEngine;

namespace Kitchen
{
    public class ClickCookware : IGameAction
    {
        private PlayerController Player { get; }
        private ICookware Cookware { get; }
        private Vector3 mPosition;
        private QueueEventsKit ActionManager { get; } 
        public ClickCookware(PlayerController player,ICookware cookware)
        {
            Player = player;
            Cookware = cookware;
            ActionManager = QueueEventsKit.Inst;
            mPosition = Cookware.Display.Position;
        }

        public void Execute()
        {
            //先移动到目标点
            Player.MoveToPoint(ref mPosition);
        }
    
        public bool Update()
        {
            var playerState = Player.IsMoving(mPosition);
            if (playerState == PlayerController.MovingState.Moving)
            {
                return false;
            }

            if (playerState == PlayerController.MovingState.InDestination)
            {
                //转向目标点
                Player.LookAt(Cookware.Display.Position);
                var cookwareState = Cookware.State;
                if (cookwareState == CookwareState.Idle)
                {
                    ActionManager.AddToTop(new DoCookwareJob(Cookware));
                    ActionManager.AddToTop(new PutIngredientAndGetFood(Player,Cookware));
                }
                else if (Cookware.FoodId != null)
                {
                    //厨具上有食物,主角手上得食材刚好可以放进去,就交换手上和厨具上得物品
                    ActionManager.AddToTop(new PutIngredientAndGetFood(Player,Cookware));
                }
            }
            return true;
        }
    }

}
