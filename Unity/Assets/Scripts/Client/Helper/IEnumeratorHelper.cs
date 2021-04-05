using System.Collections.Generic;

public static class ListHelper
{
    public static int Overlap<T>(this IList<T> from, IList<T> to)
    {
        int count = from.Count;
        int count2 = to.Count;
        int result = 0;
        for (int i = 0; i < count; i++)
        {
            var a = from[i];
            for (int j = 0; j < count2; j++)
            {
                var b = to[j];
                if (Equals(a, b))
                {
                    result++;
                }
            }
        }

        return result;
    }

    public static void AddRangeIfNotExists<T>(this IList<T> from, IList<T> to)
    {
        int count = to.Count;
        for (int i = 0; i < count; i++)
        {
            var a = to[i];
            if (!from.Contains(a))
            {
                from.Add(a);
            }
        }
    }

    public static void AddRange<T>(this ICollection<T> hash, IEnumerable<T> ie)
    {
        foreach (var node in ie)
        {
            hash.Add(node);
        }
    }
}