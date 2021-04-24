using System;
using Spine.Unity;
using UnityEngine;

namespace Kitchen
{
    public class IngredientDisplay: IDisplay
    {
        private FoodProperty Property;
        public Type Type => GetType();
        public IAnimation Animation { get; set; }
        public UnityObject Display { get; }
        public string FoodId { get; }

        public IngredientDisplay(UnityObject display, FoodProperty property)
        {
            Display = display;
            Property = property;
            FoodId = property.Key;
        }

        public void Dispose()
        {
        }
    }
}