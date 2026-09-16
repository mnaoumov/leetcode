namespace LeetCode.Problems._3414_Maximum_Score_of_Non_overlapping_Intervals;

/// <summary>
/// https://leetcode.com/problems/maximum-score-of-non-overlapping-intervals/submissions/2141074228/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int[] MaximumWeight(IList<IList<int>> intervals)
    {
        var dp = new DynamicProgramming<(int index, int minValue, int maxValue, int maxCount), (int[] indices, long maxWeight)>((key, getOrCalculate) =>
        {
            var (index, minValue, maxValue, maxCount) = key;

            if (maxCount == 0 || index == intervals.Count || minValue > maxValue)
            {
                return (indices: Array.Empty<int>(), maxWeight: 0);
            }

            var interval = intervals[index];
            var l = interval[0];
            var r = interval[1];
            var weight = interval[2];

            var ans = getOrCalculate((index + 1, minValue, maxValue, maxCount));

            if (minValue > l || r > maxValue)
            {
                return ans;
            }

            for (var leftMaxCount = 0; leftMaxCount <= maxCount - 1; leftMaxCount++)
            {
                var leftResult = getOrCalculate((index + 1, minValue, l - 1, leftMaxCount));
                var rightResult = getOrCalculate((index + 1, r + 1, maxValue, maxCount - 1 - leftMaxCount));
                var collectedWeight = 0L + leftResult.maxWeight + weight + rightResult.maxWeight;
                var collectedIndices = leftResult.indices.Append(index).Concat(rightResult.indices).ToArray();
                Array.Sort(collectedIndices);

                if (collectedWeight > ans.maxWeight || collectedWeight == ans.maxWeight && IsLexicographicallySmaller(collectedIndices, ans.indices))
                {
                    ans = (indices: collectedIndices, maxWeight: collectedWeight);
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((0, int.MinValue, int.MaxValue, 4)).indices;
    }

    private static bool IsLexicographicallySmaller(int[] arr1, int[] arr2)
    {
        var length = Math.Min(arr1.Length, arr2.Length);

        for (var i = 0; i < length; i++)
        {
            if (arr1[i] < arr2[i])
            {
                return true;
            }

            if (arr1[i] > arr2[i])
            {
                return false;
            }
        }

        return arr1.Length < arr2.Length;
    }

    public sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
