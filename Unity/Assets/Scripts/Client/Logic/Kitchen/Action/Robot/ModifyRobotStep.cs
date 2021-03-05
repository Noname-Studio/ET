using System;

namespace Kitchen.Robot
{
    public class ModifyRobotStep : IGameAction
    {
        private Action mModify;
        public ModifyRobotStep(Action modify)
        {
            mModify = modify;
        }
        
        public void Execute()
        {
            mModify();
        }

        public bool Update()
        {
            return true;
        }
    }
}