using JetBrains.Annotations;

namespace LeetCode._0494_Target_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/895666710/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        var dp = new DynamicProgramming<(int index, int subTarget), int>((key, recursiveFunc) =>
        {
            var (index, subTarget) = key;

            if (index == nums.Length)
            {
                return subTarget == 0 ? 1 : 0;
            }

            return recursiveFunc((index + 1, subTarget - nums[index])) + recursiveFunc((index + 1, subTarget + nums[index]));
        });
        return dp.GetOrCalculate((0, target));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
