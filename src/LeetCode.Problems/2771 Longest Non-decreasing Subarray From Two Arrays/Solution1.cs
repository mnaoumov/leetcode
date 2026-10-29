namespace LeetCode.Problems._2771_Longest_Non_decreasing_Subarray_From_Two_Arrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-353/submissions/detail/989782624/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxNonDecreasingLength(int[] nums1, int[] nums2)
    {
        var n = nums1.Length;

        var dp = new DynamicProgramming<(int index, int previousValue), int>((key, recursiveFunc) =>
        {
            var (index, previousValue) = key;

            if (index == n)
            {
                return 0;
            }

            var min = Math.Min(nums1[index], nums2[index]);
            var max = Math.Max(nums1[index], nums2[index]);

            if (min >= previousValue)
            {
                return 1 + recursiveFunc((index + 1, min));
            }

            if (max < previousValue)
            {
                return recursiveFunc((index + 1, min));
            }

            return Math.Max(
                1 + recursiveFunc((index + 1, max)),
                recursiveFunc((index + 1, min))
            );
        });

        return Enumerable.Range(0, n).Select(index => dp.GetOrCalculate((index, 0))).Max();
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
