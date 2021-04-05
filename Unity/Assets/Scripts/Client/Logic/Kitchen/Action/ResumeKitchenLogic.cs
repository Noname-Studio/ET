namespace Kitchen.Action
{
    public class ResumeKitchenLogic : IGameAction
    {
        public void Execute()
        {
            KitchenRoot.Inst.Resume();
        }

        public bool Update()
        {
            return true;
        }
    }
}