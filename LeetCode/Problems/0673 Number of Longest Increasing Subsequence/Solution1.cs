using JetBrains.Annotations;

namespace LeetCode._0673_Number_of_Longest_Increasing_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/940343439/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindNumberOfLIS(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<int, (int length, int count)>((index, recursiveFunc) =>
        {
            var result = (length: 1, count: 1);

            for (var i = index + 1; i < n; i++)
            {
                if (nums[i] <= nums[index])
                {
                    continue;
                }

                var (length, count) = recursiveFunc(i);

                if (1 + length > result.length)
                {
                    result.length = 1 + length;
                    result.count = count;
                }
                else if (1 + length == result.length)
                {
                    result.count += count;
                }
            }

            return result;
        });

        return Enumerable.Range(0, n).Select(i => dp.GetOrCalculate(i))
            .GroupBy(x => x.length)
            .MaxBy(g => g.Key)!
            .Sum(x => x.count);
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
