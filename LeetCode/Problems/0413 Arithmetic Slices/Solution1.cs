using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0413_Arithmetic_Slices;

/// <summary>
/// https://leetcode.com/submissions/detail/928781448/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int NumberOfArithmeticSlices(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, int previousNum, int diff), int>((key, recursiveFunc) =>
        {
            var (index, previousNum, diff) = key;

            if (index == n)
            {
                return 0;
            }

            var result2 = recursiveFunc((index + 1, previousNum, diff));

            if (nums[index] == previousNum + diff)
            {
                result2 += 1 + recursiveFunc((index + 1, nums[index], diff));
            }

            return result2;
        });

        var result = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                result += dp.GetOrCalculate((j + 1, nums[j], nums[j] - nums[i]));
            }
        }

        return result;
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
