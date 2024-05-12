using JetBrains.Annotations;

namespace LeetCode._1130_Minimum_Cost_Tree_From_Leaf_Values;

/// <summary>
/// https://leetcode.com/submissions/detail/945299676/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MctFromLeafValues(int[] arr)
    {
        var dp = new DynamicProgramming<(int i, int j), int>((key, recursiveFunc) =>
        {
            var (i, j) = key;

            if (i == j)
            {
                return 0;
            }

            var ans = int.MaxValue;

            for (var k = i; k < j; k++)
            {
                var max1 = arr.Skip(i).Take(k - i + 1).Max();
                var max2 = arr.Skip(k + 1).Take(j - k).Max();
                var value = max1 * max2 + recursiveFunc((i, k)) + recursiveFunc((k + 1, j));
                ans = Math.Min(ans, value);
            }

            return ans;
        });

        return dp.GetOrCalculate((0, arr.Length - 1));
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
