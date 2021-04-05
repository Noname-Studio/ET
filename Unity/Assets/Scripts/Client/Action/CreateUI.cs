namespace Kitchen.Action
{
    public struct CreateUI<T> : IGameAction where T : UIBase
    {
        private T ui;
        public void Execute()
        {
            ui = UIKit.Inst.Create<T>();
        }

        public bool Update()
        {
            return ui.Visible;
        }
    }
}