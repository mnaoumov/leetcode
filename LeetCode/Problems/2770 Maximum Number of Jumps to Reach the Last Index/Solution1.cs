using JetBrains.Annotations;

namespace LeetCode.Problems._2770_Maximum_Number_of_Jumps_to_Reach_the_Last_Index;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-353/submissions/detail/989750117/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumJumps(int[] nums, int target)
    {
        var n = nums.Length;
        const int impossible = -1;

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == n - 1)
            {
                return 0;
            }

            var ans = impossible;

            for (var j = index + 1; j < n; j++)
            {
                if (Math.Abs(nums[j] - nums[index]) > target)
                {
                    continue;
                }

                var next = recursiveFunc(j);

                if (next != impossible)
                {
                    ans = Math.Max(ans, 1 + recursiveFunc(j));
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
