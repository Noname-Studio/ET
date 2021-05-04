using System;
using System.Collections.Generic;
using Kitchen;

public class BuffContainer
{
    private Dictionary<Type, ABuff> Components = new Dictionary<Type, ABuff>();

    public T Get<T>() where T :ABuff
    {
        var t = typeof (T);
        ABuff result;
        if (Components.TryGetValue(t, out result))
        {
            return (T) result;
        }

        return default;
    }

    public void Add<T>(T com) where T : ABuff
    {
        var t = typeof (T);
        Components[t] = com;
        com.OnAdd();
    }

    public void Remove<T>() where T : ABuff
    {
        var t = typeof (T);
        if (Components.TryGetValue(t, out ABuff value))
        {
            Components.Remove(t);
            value.OnRemove();
        }
    }

    public void Update()
    {
        foreach (var node in Components)
        {
            node.Value.OnUpdate();
        }
    }
}