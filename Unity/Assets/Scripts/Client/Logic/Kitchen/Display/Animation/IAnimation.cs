using UnityEngine;

namespace Kitchen
{
    public interface IAnimation 
    {
        bool Loop { get; set; }
        string AnimationName { get; set; }
        
        Vector3 ClockPos { get; }
        Vector3 FoodPos { get; }

    }
}
