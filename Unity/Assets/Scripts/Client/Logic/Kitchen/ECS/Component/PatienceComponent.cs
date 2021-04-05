using UnityEngine;

namespace Kitchen
{
    public class PatienceComponent: IComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">耐心上限</param>
        /// <param name="loseSpeed">流失速度</param>
        public PatienceComponent(float value, float loseSpeed)
        {
            Value = value;
            LoseSpeed = loseSpeed;
        }

        public float Value { get; set; }
        public float LoseSpeed { get; set; }

        public void OnUpdate()
        {
            Value -= LoseSpeed * Time.deltaTime;
        }
    }
}