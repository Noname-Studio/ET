namespace Kitchen.Action
{
    public class FailedRecord : IGameAction
    {
        public void Execute()
        {
            var analytics = DBManager.Inst.Query<Data_Analytics>();
            analytics.ConsecutiveLevels.Level = 0;
            DBManager.Inst.Update(analytics);
        }

        public bool Update()
        {
            return true;
        }
    }
}