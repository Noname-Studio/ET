﻿using System;

namespace Kitchen.Robot
{
    public class ModifyRobotStep: IGameAction
    {
        private System.Action mModify;

        public ModifyRobotStep(System.Action modify)
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