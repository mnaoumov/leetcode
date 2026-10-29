namespace LeetCode.Problems._3915_Maximum_Sum_of_Alternating_Subsequence_With_Distance_at_Least_K;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-499/problems/maximum-sum-of-alternating-subsequence-with-distance-at-least-k/submissions/1988315972/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public long MaxAlternatingSum(int[] nums, int k)
    {
        var n = nums.Length;
        const int noIndex = -1;

        var sortedList = new List<(int num, int index)>();

        for (var i = k; i < n; i++)
        {
            var num = nums[i];
            var pair = (num, i);
            var j = ~sortedList.BinarySearch(pair);
            sortedList.Insert(j, pair);
        }

        var sortedLists = new List<(int num, int index)>[n - k];

        for (var i = 0; i < n - k; i++)
        {
            sortedLists[i] = sortedList.ToList();
            var pair = (nums[i + k], i + k);
            var j = sortedList.BinarySearch(pair);
            sortedList.RemoveAt(j);
        }

        var dp = new DynamicProgramming<(int index, int diffSign), int>((key, getOrCalculate) =>
        {
            var (index, diffSign) = key;

            if (index >= n)
            {
                return 0;
            }

            var ans2 = 0;

            if (index == noIndex)
            {
                for (var i = 0; i < n; i++)
                {
                    ans2 = Math.Max(ans2, getOrCalculate((i, 1)));
                    ans2 = Math.Max(ans2, getOrCalculate((i, -1)));
                }

                return ans2;
            }

            var num = nums[index];
            ans2 = num;

            var sortedList2 = index < n - k ? sortedLists[index] : new List<(int num, int index)>();

            var j = diffSign == 1
                ? ~sortedList2.BinarySearch((num + 1, 0))
                : ~sortedList2.BinarySearch((num - 1, n)) - 1;

            for (var i = j; 0 <= i && i < sortedList2.Count; i += diffSign)
            {
                ans2 = Math.Max(ans2, num + getOrCalculate((sortedList2[i].index, -diffSign)));
            }

            return ans2;
        });

        return dp.GetOrCalculate((noIndex, 1));
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
