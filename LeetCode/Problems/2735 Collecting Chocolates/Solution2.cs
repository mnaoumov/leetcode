using JetBrains.Annotations;

namespace LeetCode._2735_Collecting_Chocolates;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-349/submissions/detail/968541497/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long MinCost(int[] nums, int x)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int operationsCount, string collectedTypesMask), long>((key, recursiveFunc) =>
        {
            var (operationsCount, collectedTypesMask) = key;

            var collectedTypes = new SortedSet<int>(collectedTypesMask.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            if (collectedTypes.Count == n)
            {
                return 0;
            }

            var ans = long.MaxValue;

            for (var i = 0; i < n; i++)
            {
                if (collectedTypes.Contains(i))
                {
                    continue;
                }

                var j = ((i - operationsCount) % n + n) % n;

                if (nums[j] >= ans)
                {
                    continue;
                }

                collectedTypes.Add(i);
                var nextMask = string.Join(",", collectedTypes);
                collectedTypes.Remove(i);

                ans = Math.Min(ans, nums[j] + recursiveFunc((operationsCount, nextMask)));
            }

            if (operationsCount < n - 1 && x < ans)
            {
                ans = Math.Min(ans, x + recursiveFunc((operationsCount + 1, collectedTypesMask)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, ""));
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
