using UnityEngine;

namespace Kitchen.Action
{
    public struct Delay :IGameAction
    {
        private float Ticks { get; set; }
        private float Second { get; }
        public Delay(float second)
        {
            Second = second;
            Ticks = 0;
        }
        
        public void Execute()
        {
        }

        public bool Update()
        {
            Ticks += Time.deltaTime;
            if (Ticks >= Second)
            {
                return true;
            }

            return false;
        }
    }
}