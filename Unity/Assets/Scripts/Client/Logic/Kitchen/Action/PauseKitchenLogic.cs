namespace Kitchen.Action
{
    public struct PauseKitchenLogic : IGameAction
    {
        public void Execute()
        {
            KitchenRoot.Inst.Pause();
        }

        public bool Update()
        {
            return true;
        }
    }
}