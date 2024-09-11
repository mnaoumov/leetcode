using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3282_Reach_End_of_Array_With_Max_Score;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-414/submissions/detail/1382701546/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long FindMaximumScore(IList<int> nums)
    {
        var n = nums.Count;
        var dp = new DynamicProgramming<int, long>((index, recursiveFunc) =>
        {
            if (index == n - 1)
            {
                return 0;
            }

            var ans = 0L;

            for (var j = index + 1; j < n; j++)
            {
                ans = Math.Max(ans, 1L * nums[index] * (j - index) + recursiveFunc(j));
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
