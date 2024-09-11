namespace LeetCode.Problems._2771_Longest_Non_decreasing_Subarray_From_Two_Arrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-353/submissions/detail/989810817/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MaxNonDecreasingLength(int[] nums1, int[] nums2)
    {
        var n = nums1.Length;

        var dp = new DynamicProgramming<(int index, bool isNums1), int>((key, recursiveFunc) =>
        {
            var (index, isNums1) = key;

            if (index == n - 1)
            {
                return 1;
            }

            var array = isNums1 ? nums1 : nums2;
            var num = array[index];

            var nextNum1 = nums1[index + 1];
            var nextNum2 = nums2[index + 1];

            var ans = 1;

            if (nextNum1 > num)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((index + 1, true)));
            }

            if (nextNum2 > num)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((index + 1, false)));
            }

            return ans;
        });

        return Enumerable.Range(0, n)
            .SelectMany(_ => new[] { true, false }, (index, isNums1) => dp.GetOrCalculate((index, isNums1)))
            .Max();
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
