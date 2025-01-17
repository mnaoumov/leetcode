namespace LeetCode.Problems._3420_Count_Non_Decreasing_Subarrays_After_K_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/1505773293/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long CountNonDecreasingSubarrays(int[] nums, int k)
    {
        var nonDecreasingSubarrays = new List<List<int>>();

        foreach (var num in nums)
        {
            if (nonDecreasingSubarrays.Count == 0 || nonDecreasingSubarrays[^1][^1] > num)
            {
                nonDecreasingSubarrays.Add(new List<int> { num });
            }
            else
            {
                nonDecreasingSubarrays[^1].Add(num);
            }
        }

        var m = nonDecreasingSubarrays.Count;
        var prefixLengthSums = new int[m + 1];

        for (var i = 0; i < m; i++)
        {
            prefixLengthSums[i + 1] = prefixLengthSums[i] + nonDecreasingSubarrays[i].Count;
        }

        var prefixSums = nonDecreasingSubarrays.Select(PrefixSum).ToArray();

        var maxAllowedIndexDp = new DynamicProgramming<(int subarrayIndex, int operationsLeft, int previousValue), int>((key, recursiveFunc) =>
        {
            var (subarrayIndex, operationsLeft, previousValue) = key;

            if (subarrayIndex == m)
            {
                return nums.Length - 1;
            }

            var subarray = nonDecreasingSubarrays[subarrayIndex];
            var maxValueIndexInSubarray = BinarySearchFirst(subarray, previousValue);

            var low = 0;
            var high = maxValueIndexInSubarray;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);
                if (1L * mid * previousValue <= operationsLeft + prefixSums[subarrayIndex][mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            if (high < maxValueIndexInSubarray)
            {
                return prefixLengthSums[subarrayIndex] + high - 1;
            }

            var prefixSum = prefixSums[subarrayIndex][maxValueIndexInSubarray];
            var sumAfterOperations = 1L * previousValue * maxValueIndexInSubarray;
            var operationsNeeded = sumAfterOperations - prefixSum;
            return recursiveFunc((subarrayIndex + 1, (int) (operationsLeft - operationsNeeded), Math.Max(previousValue, subarray[^1])));
        });

        var ans = 0L;

        for (var i = 0; i < nonDecreasingSubarrays.Count; i++)
        {
            var nonDecreasingSubarray = nonDecreasingSubarrays[i];
            var maxAllowedIndex = maxAllowedIndexDp.GetOrCalculate((i + 1, k, nonDecreasingSubarray[^1]));
            ans += 1L * nonDecreasingSubarray.Count * (2 * maxAllowedIndex - 2 * prefixLengthSums[i] - nonDecreasingSubarray.Count + 3) / 2;
        }

        return ans;
    }

    private static long[] PrefixSum(IReadOnlyList<int> nums)
    {
        var n = nums.Count;
        var ans = new long[n + 1];

        for (var i = 0; i < n; i++)
        {
            ans[i + 1] = ans[i] + nums[i];
        }

        return ans;
    }

    private static int BinarySearchFirst<T>(IReadOnlyList<T> arr, T value, int? firstIndex = null, int? lastIndex = null) where T : IComparable<T>
    {
        var low = firstIndex ?? 0;
        var high = lastIndex ?? arr.Count - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (arr[mid].CompareTo(value) >= 0)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
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