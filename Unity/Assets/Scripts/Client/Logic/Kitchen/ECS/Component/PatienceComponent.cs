using UnityEngine;

namespace Kitchen
{
    public class PatienceComponent: IComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">耐心上限</param>
        /// <param name="loseValue">流失速度</param>
        public PatienceComponent(float loseSpeed)
        {
            Value = 100;
            LoseSpeed = loseSpeed;
        }

        public float Value { get; set; }
        public float LoseSpeed { get; set; }
        private float mTime { get; set; }
        public void OnUpdate()
        {
            mTime += Time.deltaTime;
            if (mTime >= LoseSpeed)
            {
                Value -= 3;
                mTime = 0;
            }
        }
    }
}