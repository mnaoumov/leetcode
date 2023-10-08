using JetBrains.Annotations;

namespace LeetCode._1458_Max_Dot_Product_of_Two_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/1069874732/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        var dp = new DynamicProgramming<(int index1, int index2, bool isValidProduct), int>((key, recursiveFunc) =>
        {
            var (index1, index2, isValidProduct) = key;

            if (index1 >= nums1.Length || index2 >= nums2.Length)
            {
                return isValidProduct ? 0 : int.MinValue;
            }

            var ans = nums1[index1] * nums2[index2] + recursiveFunc((index1 + 1, index2 + 1, true));
            ans = Math.Max(ans, recursiveFunc((index1 + 1, index2, isValidProduct)));
            ans = Math.Max(ans, recursiveFunc((index1, index2 + 1, isValidProduct)));

            return ans;
        });

        return dp.GetOrCalculate((0, 0, false));
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
