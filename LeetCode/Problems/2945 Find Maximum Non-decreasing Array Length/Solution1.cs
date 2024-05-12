using JetBrains.Annotations;

namespace LeetCode.Problems._2945_Find_Maximum_Non_decreasing_Array_Length;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-118/submissions/detail/1106179925/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int FindMaximumLength(int[] nums)
    {
        var n = nums.Length;
        var prefixSums = new long[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + nums[i];
        }

        var dp = new DynamicProgramming<(int index, long minSum), int>((key, recursiveFunc) =>
        {
            var (index, minSum) = key;

            if (index == n)
            {
                return 0;
            }

            var sumIndex = Array.BinarySearch(prefixSums, minSum);

            if (sumIndex < 0)
            {
                sumIndex = ~sumIndex;
            }

            if (sumIndex == n + 1)
            {
                return 0;
            }

            var sum = prefixSums[sumIndex] - prefixSums[index];

            return 1 + recursiveFunc((sumIndex, prefixSums[index] + 2 * sum + 1));
        });

        return dp.GetOrCalculate((0, 1));
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
