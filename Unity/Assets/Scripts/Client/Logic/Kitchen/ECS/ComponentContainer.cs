using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这是个临时得Component容器.
/// TODO 未来需要修改为ECS架构
/// </summary>
public class ComponentContainer
{
    private Dictionary<Type,IComponent> Components = new Dictionary<Type, IComponent>();

    public T Get<T>()
    {
        var t = typeof(T);
        IComponent result;
        if (Components.TryGetValue(t, out result))
        {
            return (T) result;
        }
        return default(T);
    }

    public void Set<T>(T com) where T : IComponent
    {
        var t = typeof(T);
        Components[t] = com;
    }
}
