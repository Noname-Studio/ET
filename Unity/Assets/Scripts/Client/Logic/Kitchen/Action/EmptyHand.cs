namespace Kitchen.Action
{
    public class EmptyHand : IGameAction
    {
        private PlayerController Controller { get; }
        public EmptyHand(PlayerController controller)
        {
            Controller = controller;
        }
        
        public void Execute()
        {
            Controller.HandProvider.Clear();
        }

        public bool Update()
        {
            return true;
        }
    }
}