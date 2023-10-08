using JetBrains.Annotations;

namespace LeetCode._1458_Max_Dot_Product_of_Two_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/1069871898/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        var dp = new DynamicProgramming<(int index1, int index2), int>((key, recursiveFunc) =>
        {
            var (index1, index2) = key;

            if (index1 >= nums1.Length || index2 >= nums2.Length)
            {
                return 0;
            }

            var ans = nums1[index1] * nums2[index2] + recursiveFunc((index1 + 1, index2 + 1));
            var ans2 = recursiveFunc((index1 + 1, index2));

            if (index1 > 0 || index2 > 0 || ans2 > 0)
            {
                ans = Math.Max(ans, ans2);
            }

            ans2 = recursiveFunc((index1, index2 + 1));

            if (index1 > 0 || index2 > 0 || ans2 > 0)
            {
                ans = Math.Max(ans, ans2);
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
