using JetBrains.Annotations;

namespace LeetCode._0300_Longest_Increasing_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/919723955/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LengthOfLIS(int[] nums)
    {
        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == nums.Length)
            {
                return 0;
            }

            var result = 1;

            for (var j = index + 1; j < nums.Length; j++)
            {
                if (nums[j] > nums[index])
                {
                    result = Math.Max(result, 1 + recursiveFunc(j));
                }
            }

            return result;
        });

        return Enumerable.Range(0, nums.Length).Max(dp.GetOrCalculate);
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
