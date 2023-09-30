using System.Text;
using JetBrains.Annotations;

namespace LeetCode._0664_Strange_Printer;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int StrangePrinter(string s)
    {
        var dp = new DynamicProgramming<string, int>((str, recursiveFunc) =>
        {
            if (str == "")
            {
                return 0;
            }

            var ans = int.MaxValue;

            for (var i = 0; i < str.Length; i++)
            {
                var left = str[..i];
                var right = str[(i + 1)..];

                var next = left.Length == 0 || right.Length == 0 || left[^1] != right[0] ? left + right : left + right[1..];

                ans = Math.Min(ans, 1 + recursiveFunc(next));
            }

            return ans;
        });

        var sb = new StringBuilder();

        foreach (var letter in s.Where(letter => sb.Length <= 0 || sb[^1] != letter))
        {
            sb.Append(letter);
        }

        return dp.GetOrCalculate(sb.ToString());
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
