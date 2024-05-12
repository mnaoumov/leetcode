using JetBrains.Annotations;

namespace LeetCode.Problems._0718_Maximum_Length_of_Repeated_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/898743782/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int FindLength(int[] nums1, int[] nums2)
    {
        var dp = new DynamicProgramming<(int index1, int index2), int>((key, recursiveFunc) =>
        {
            var (index1, index2) = key;

            if (index1 >= nums1.Length || index2 >= nums2.Length)
            {
                return 0;
            }

            if (nums1[index1] != nums2[index2])
            {
                return 0;
            }

            return 1 + recursiveFunc((index1 + 1, index2 + 1));
        });

        var result = 0;

        for (var index1 = 0; index1 < nums1.Length; index1++)
        {
            for (var index2 = 0; index2 < nums2.Length; index2++)
            {
                result = Math.Max(result, dp.GetOrCalculate((index1, index2)));
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
