using System;
using System.Collections.Generic;

namespace Kitchen
{
    public class Trash: ICookware
    {
        public Type Type => GetType();
        public IAnimation Animation { get; }
        public UnityObject Display { get; }
        public CookwareState State => CookwareState.Idle;

        public string FoodId { get; } = string.Empty;
        public int FoodCount { get; } = 0;

        public Trash(UnityObject display, IAnimation animation)
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
            {
                return result;
            }

            result.Add(list[0]);
            return result;
        }

        public void Update()
        {
            
        }

        public void Dispose()
        {
        }
    }
}