using JetBrains.Annotations;

namespace LeetCode.Problems._2767_Partition_String_Into_Minimum_Beautiful_Substrings;

/// <summary>
/// https://leetcode.com/submissions/detail/989500208/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumBeautifulSubstrings(string s)
    {
        var powersOfFive = new HashSet<int>();
        const int maxValue = (1 << 15) - 1;
        var powerOfFive = 1;

        while (powerOfFive <= maxValue)
        {
            powersOfFive.Add(powerOfFive);
            powerOfFive *= 5;
        }

        const int impossible = -1;
        var n = s.Length;

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == n)
            {
                return 0;
            }

            if (s[index] == '0')
            {
                return impossible;
            }

            var ans = int.MaxValue;
            var value = 0;

            for (var i = index; i < n; i++)
            {
                value = 2 * value + (s[i] - '0');

                if (!powersOfFive.Contains(value))
                {
                    continue;
                }

                var next = recursiveFunc(i + 1);

                if (next != impossible)
                {
                    ans = Math.Min(ans, 1 + next);
                }
            }

            return ans == int.MaxValue ? impossible : ans;
        });

        return dp.GetOrCalculate(0);
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
