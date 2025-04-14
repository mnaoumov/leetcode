namespace LeetCode.Problems._3500_Minimum_Cost_to_Divide_Array_Into_Subarrays;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-153/problems/minimum-cost-to-divide-array-into-subarrays/submissions/1590183202/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MinimumCost(int[] nums, int[] cost, int k)
    {
        var n = nums.Length;
        var numsPrefixSums = new int[n + 1];
        var costPrefixSums = new int[n + 1];
        for (var i = 0; i < n; i++)
        {
            numsPrefixSums[i + 1] = numsPrefixSums[i] + nums[i];
            costPrefixSums[i + 1] = costPrefixSums[i] + cost[i];
        }

        var dp = new DynamicProgramming<(int l, int divisionOrder), long>((key, recursiveFunc) =>
        {
            var (l, divisionOrder) = key;

            if (l == n)
            {
                return 0;
            }

            var ans = long.MaxValue;

            for (var r = l; r < n; r++)
            {
                var divisionCost =
                    1L *
                    (numsPrefixSums[r + 1] + k * divisionOrder) *
                    (costPrefixSums[r + 1] - costPrefixSums[l]);
                ans = Math.Min(ans, divisionCost + recursiveFunc((r + 1, divisionOrder + 1)));
            }

            return ans;
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
