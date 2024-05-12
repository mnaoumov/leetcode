using System.Text;
using JetBrains.Annotations;

namespace LeetCode._0664_Strange_Printer;

/// <summary>
/// https://leetcode.com/submissions/detail/1072266234/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int StrangePrinter(string s)
    {
        var dp = new DynamicProgramming<(int left, int right), int>((key, recursiveFunc) =>
        {
            var (left, right) = key;

            if (left == right)
            {
                return 0;
            }

            var i = left;

            while (i < right && s[i] == s[right])
            {
                i++;
            }

            if (i == right)
            {
                return 0;
            }

            var ans = int.MaxValue;

            for (var j = i; j < right; j++)
            {
                if (s[j] == s[right])
                {
                    continue;
                }

                ans = Math.Min(ans, 1 + recursiveFunc((i, j)) + recursiveFunc((j + 1, right)));
            }

            return ans;
        });

        var sb = new StringBuilder();

        foreach (var letter in s.Where(letter => sb.Length <= 0 || sb[^1] != letter))
        {
            sb.Append(letter);
        }

        return 1 + dp.GetOrCalculate((0, s.Length - 1));
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
