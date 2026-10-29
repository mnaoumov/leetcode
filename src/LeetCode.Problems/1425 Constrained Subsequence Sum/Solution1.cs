namespace LeetCode.Problems._1425_Constrained_Subsequence_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/1080723206/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int ConstrainedSubsetSum(int[] nums, int k)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == n)
            {
                return 0;
            }

            var ans = nums[index];

            for (var j = index + 1; j < Math.Min(index + k + 1, n); j++)
            {
                ans = Math.Max(ans, nums[index] + recursiveFunc(j));
            }

            return ans;
        });

        return Enumerable.Range(0, n).Max(i => dp.GetOrCalculate(i));
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
