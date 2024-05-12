using JetBrains.Annotations;

namespace LeetCode.Problems._0213_House_Robber_II;

/// <summary>
/// https://leetcode.com/submissions/detail/919890591/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int Rob(int[] nums)
    {
        var dp = new DynamicProgramming<(int index, bool wasFirstHouseRobbed), int>((key, recursiveFunc) =>
        {
            var (index, wasFirstHouseRobbed) = key;

            if (index == nums.Length)
            {
                return 0;
            }

            if (index == nums.Length - 1)
            {
                return wasFirstHouseRobbed ? 0 : nums[index];
            }

            var result = Math.Max(
                recursiveFunc((index + 1, wasFirstHouseRobbed)),
                nums[index] + recursiveFunc((index + 2, wasFirstHouseRobbed || index == 0))
            );

            return result;
        });

        return dp.GetOrCalculate((0, false));
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
