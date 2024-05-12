using JetBrains.Annotations;

namespace LeetCode._0956_Tallest_Billboard;

/// <summary>
/// https://leetcode.com/submissions/detail/978231664/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int TallestBillboard(int[] rods)
    {
        rods = rods.OrderByDescending(rod => rod).ToArray();
        var n = rods.Length;
        var suffixes = new int[n + 1];

        for (var i = n - 1; i >= 0; i--)
        {
            suffixes[i] = suffixes[i + 1] + rods[i];
        }

        var max = 0;

        var sum = rods.Sum();

        var dp = new DynamicProgramming<(int index, int totalLength1, int totalLength2), int>((key, recursiveFunc) =>
        {
            var (index, totalLength1, totalLength2) = key;

            if (totalLength1 > totalLength2)
            {
                return recursiveFunc((index, totalLength2, totalLength1));
            }

            if (2 * totalLength2 > sum)
            {
                return 0;
            }

            if (totalLength2 - totalLength1 > suffixes[index])
            {
                return 0;
            }

            if (totalLength1 + suffixes[index] <= max)
            {
                return 0;
            }

            var ans = 0;

            if (totalLength1 == totalLength2)
            {
                ans = totalLength1;
            }

            if (index < rods.Length)
            {
                ans = Math.Max(ans, recursiveFunc((index + 1, totalLength1, totalLength2)));
                var rod = rods[index];
                ans = Math.Max(ans, recursiveFunc((index + 1, totalLength1 + rod, totalLength2)));
                ans = Math.Max(ans, recursiveFunc((index + 1, totalLength1, totalLength2 + rod)));
            }

            max = Math.Max(max, ans);
            return ans;
        });

        return dp.GetOrCalculate((0, 0, 0));
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
