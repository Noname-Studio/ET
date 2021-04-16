using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Effect
{
    public class EffectFactory
    {
        public static TEffect Create<TEffect>(TEffect effect) where TEffect : IEffect
        {
            effect.Do();
            return effect;
        }
    }
}
