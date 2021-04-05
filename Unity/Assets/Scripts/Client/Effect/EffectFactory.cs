using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFactory
{
    public static TEffect Create<TEffect>() where TEffect : IEffect
    {
        return Activator.CreateInstance<TEffect>();
    }
}