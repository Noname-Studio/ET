namespace Kitchen
{
    public class DoCookwareJob : IGameAction
    {
        private ICookware mTarget { get; }
        public DoCookwareJob(ICookware target)
        {
            mTarget = target;
        }
    
        public void Execute()
        {
            mTarget.DoWork();
        }

        public bool Update()
        {
            return true;
        }
    }
}
