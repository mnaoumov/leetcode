using JetBrains.Annotations;

namespace LeetCode._2945_Find_Maximum_Non_decreasing_Array_Length;

/// <summary>
/// https://leetcode.com/submissions/detail/1106425285/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int FindMaximumLength(int[] nums)
    {
        var n = nums.Length;
        var prefixSums = new long[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + nums[i];
        }

        var dp = new DynamicProgramming<(int index, int previousIndex), int>((key, recursiveFunc) =>
        {
            var (index, previousIndex) = key;

            if (index == n)
            {
                return 0;
            }

            var previousSum = previousIndex >= 0 ? prefixSums[previousIndex] : 0;
            var previousNum = prefixSums[index] - previousSum;
            var minSum = previousSum + 2 * previousNum + 1;

            var sumIndex = Array.BinarySearch(prefixSums, minSum);

            if (sumIndex < 0)
            {
                sumIndex = ~sumIndex;
            }

            if (sumIndex == n + 1)
            {
                return 0;
            }

            var minIndex = index;
            var maxIndex = sumIndex;

            while (minIndex <= maxIndex)
            {
                var midIndex = minIndex + (maxIndex - minIndex >> 1);

                var previousNumCandidate = prefixSums[midIndex] - previousSum;
                var minSumCandidate = previousSum + 2 * previousNumCandidate + 1;

                if (prefixSums[sumIndex] >= minSumCandidate)
                {
                    minIndex = midIndex + 1;
                }
                else
                {
                    maxIndex = midIndex - 1;
                }
            }

            return 1 + recursiveFunc((sumIndex, maxIndex));
        });

        return dp.GetOrCalculate((0, -1));
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
