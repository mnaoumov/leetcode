using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0956_Tallest_Billboard;

/// <summary>
/// https://leetcode.com/submissions/detail/978217877/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int TallestBillboard(int[] rods)
    {
        var dp = new DynamicProgramming<(int index, int totalLength1, int totalLength2), int>((key, recursiveFunc) =>
        {
            var (index, totalLength1, totalLength2) = key;

            var ans = 0;

            if (totalLength1 == totalLength2)
            {
                ans = totalLength1;
            }

            if (index == rods.Length)
            {
                return ans;
            }

            ans = Math.Max(ans, recursiveFunc((index + 1, totalLength1, totalLength2)));
            ans = Math.Max(ans, recursiveFunc((index + 1, totalLength1 + rods[index], totalLength2)));
            ans = Math.Max(ans, recursiveFunc((index + 1, totalLength1, totalLength2 + rods[index])));

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
