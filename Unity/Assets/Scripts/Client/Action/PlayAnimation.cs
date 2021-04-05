using System.Threading.Tasks;

namespace Kitchen.Action
{
    public class PlayAnimation : IGameAction
    {
        private IUnit Unit { get; }
        private string AnimationName { get; }
        private bool WaitFinish { get; }
        private Task AnimationTask { get; set; } 
        public PlayAnimation(IUnit unit,string animationName,bool waitFinish)
        {
            Unit = unit;
            AnimationName = animationName;
            WaitFinish = waitFinish;
        }
        public void Execute()
        {
            AnimationTask = Unit.PlayAnimation(AnimationName);
        }

        public bool Update()
        {
            if (WaitFinish)
            {
                return AnimationTask.IsCanceled || AnimationTask.IsCompleted || AnimationTask.IsFaulted;
            }
            return true;
        }
    }
}