using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace LeetCode._0377_Combination_Sum_IV;

/// <summary>
/// https://leetcode.com/submissions/detail/882137797/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CombinationSum4(int[] nums, int target)
    {
        Array.Sort(nums);

        var dp = new DynamicProgramming<int, int>((target2, recursiveFunc) =>
        {
            return target2 switch
            {
                0 => 1,
                < 0 => 0,
                _ => nums.TakeWhile(num => num <= target2).Sum(num => recursiveFunc(target2 - num))
            };
        });

        return dp.GetOrCalculate(target);
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
