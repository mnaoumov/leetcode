namespace LeetCode.Problems._3282_Reach_End_of_Array_With_Max_Score;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-414/submissions/detail/1382724289/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long FindMaximumScore(IList<int> nums)
    {
        var n = nums.Count;
        var dp = new DynamicProgramming<(int i, int k), long>((key, recursiveFunc) =>
        {
            var (i, k) = key;
            return k == n ? 0 : Math.Max(recursiveFunc((i, k + 1)), 1L * nums[i] * (k - i) + recursiveFunc((k, k + 1)));
        });

        return dp.GetOrCalculate((0, 1));
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
