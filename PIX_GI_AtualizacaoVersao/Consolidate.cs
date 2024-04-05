using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIX_GI_AtualizacaoVersao
{
    public static IEnumerable<TSource> Consolidate<TSource, TProperty>(
        this IEnumerable<TSource> source,
        Func<TSource, TProperty> property1Selector,
        Func<TSource, TProperty> property2Selector,
        Func<TSource, TSource, TSource> combine)
    {
        var dict1 = source.ToDictionary(property1Selector);
        var dict2 = source.ToDictionary(property2Selector);
        if (dict1.Keys.Count == 0) yield break;
        var first = dict2.Values.First(); // Start with a random element
        var last = first;
        var current = first;
        while (true) // Searching backward
        {
            dict1.Remove(property1Selector(first));
            dict2.Remove(property2Selector(first));
            if (dict2.TryGetValue(property1Selector(first), out current))
            {
                first = current; // Continue searching backward
            }
            else
            {
                while (true) // Searching forward
                {
                    if (dict1.TryGetValue(property2Selector(last), out current))
                    {
                        last = current; // Continue searching forward
                        dict1.Remove(property1Selector(last));
                        dict2.Remove(property2Selector(last));
                    }
                    else
                    {
                        yield return combine(first, last);
                        break;
                    }
                }
                if (dict1.Keys.Count == 0) break;
                first = dict1.Values.First(); // Continue with a random element
                last = first;
            }
        }
    }
}
