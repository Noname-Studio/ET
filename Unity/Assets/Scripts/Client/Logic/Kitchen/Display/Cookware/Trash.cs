using System;
using System.Collections.Generic;

namespace Kitchen
{
    public class Trash : ICookware
    {
        public Type Type => this.GetType();
        public IAnimation Animation { get; }
        public UnityObject Display { get; }
        public CookwareState State => CookwareState.Idle;

        public string FoodId { get; }
        
        public Trash(UnityObject display,IAnimation animation)
        {
            Display = display;
            Animation = animation;
        }
        
        public void DoWork()
        {
            Animation.AnimationName = "3work";
        }

        public string TakeFood()
        {
            return null;
        }

        public List<string> PutIn(List<string> list)
        {
            var result = new List<string>();
            if (list.Count == 0)
                return result;
            result.Add(list[0]);
            return result;
        }
        
        public void Dispose()
        {
        }
    }
}