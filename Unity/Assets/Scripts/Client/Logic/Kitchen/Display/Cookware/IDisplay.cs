using System;
using UnityEngine;

namespace Kitchen
{
    public interface IDisplay
    {
        Type Type { get; }
        IAnimation Animation { get; }
        UnityObject Display { get; }
        void Dispose();
    }
}

