using System;
using UnityEngine;

namespace Kitchen
{
    /// <summary>
    /// 这是常用的移动系统.即从出生点朝目标点行进.没有任何障碍物.只需要Translate移动即可
    /// </summary>
    public class CustomerMoveComponent : IComponent
    {
        public Vector3? To { get; set; } = null;
        public Action ReachedCallback { get; set; }
        public float Speed { get; set; }
        public UnityObject Display { get; set; }
        public CustomerMoveComponent(float speed,UnityObject display)
        {
            Speed = speed;
            Display = display;
        }

        public void OnUpdate()
        {
            var transform = Display;
            if (To.HasValue)
            {
                if (transform.Position != To)
                {
                    float step =  Speed * Time.deltaTime;
                    transform.Position = Vector3.MoveTowards(transform.Position, To.Value, step);
                }
                else
                {
                    if (ReachedCallback != null)
                        ReachedCallback();
                    To = null;
                }
            }
        }
    }
}