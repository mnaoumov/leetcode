using JetBrains.Annotations;

namespace LeetCode.Problems._1458_Max_Dot_Product_of_Two_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/1069858859/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        var dp = new DynamicProgramming<(int minIndex1, int minIndex2), int>((key, recursiveFunc) =>
        {
            var (minIndex1, minIndex2) = key;

            if (minIndex1 >= nums1.Length || minIndex2 >= nums2.Length)
            {
                return 0;
            }

            var ans = minIndex1 == 0 && minIndex2 == 0 ? int.MinValue : 0;

            for (var index1 = minIndex1; index1 < nums1.Length; index1++)
            {
                for (var index2 = minIndex2; index2 < nums2.Length; index2++)
                {
                    var ans2 = nums1[index1] * nums2[index2] + recursiveFunc((index1 + 1, index2 + 1));
                    ans = Math.Max(ans, ans2);
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0));
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
