using JetBrains.Annotations;

namespace LeetCode.Problems._3144_Minimum_Substring_Partition_of_Equal_Character_Frequency;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-130/submissions/detail/1255261857/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumSubstringsInPartition(string s)
    {
        var n = s.Length;

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == n)
            {
                return 0;
            }

            var counts = new Dictionary<char, int>();

            var ans = int.MaxValue;

            for (var i = index; i < n; i++)
            {
                var letter = s[i];
                counts.TryAdd(letter, 0);
                counts[letter]++;

                if (counts.Values.All(count => count == counts[letter]))
                {
                    ans = Math.Min(ans, 1 + recursiveFunc(i + 1));
                }
            }

            return ans;
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
