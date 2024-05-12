using JetBrains.Annotations;

namespace LeetCode._1043_Partition_Array_for_Maximum_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/1164438586/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSumAfterPartitioning(int[] arr, int k)
    {
        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            var ans = 0;
            var max = 0;

            for (var i = index; i < Math.Min(index + k, arr.Length); i++)
            {
                max = Math.Max(max, arr[i]);
                ans = Math.Max(ans, max * (i - index + 1) + recursiveFunc(i + 1));
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
