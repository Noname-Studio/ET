namespace Kitchen.Action
{
    public class StopPlayerMoving : IGameAction
    {
        private PlayerController Controller { get; }
        public StopPlayerMoving(PlayerController controller)
        {
            Controller = controller;
        }
        public void Execute()
        {
            Controller.StopMove();
        }

        public bool Update()
        {
            return true;
        }
    }
}