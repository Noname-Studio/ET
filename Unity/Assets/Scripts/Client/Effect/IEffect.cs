using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Effect
{
    public interface IEffect: IDisposable
    {
        void Do();
        bool IsPlaying { get; }
    }
}
