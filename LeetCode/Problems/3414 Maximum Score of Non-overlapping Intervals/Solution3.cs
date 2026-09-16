namespace LeetCode.Problems._3414_Maximum_Score_of_Non_overlapping_Intervals;

/// <summary>
/// https://leetcode.com/problems/maximum-score-of-non-overlapping-intervals/submissions/2141086061/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int[] MaximumWeight(IList<IList<int>> intervals)
    {
        var n = intervals.Count;

        var sortedIntervals = intervals
            .Select((arr, originalIndex) => new Interval(arr[0], arr[1], arr[2], originalIndex))
            .OrderBy(x => x.Right)
            .ThenBy(x => x.Left)
            .ToArray();

        var nextIndices = new int[n];
        Array.Fill(nextIndices, n);

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (sortedIntervals[j].Left <= sortedIntervals[i].Right)
                {
                    continue;
                }

                nextIndices[i] = j;
                break;
            }
        }


        var dp = new DynamicProgramming<(int minIndex, int maxCount), (int[] indices, long maxWeight)>((key, getOrCalculate) =>
        {
            var (minIndex, maxCount) = key;

            if (minIndex == n || maxCount == 0)
            {
                return (indices: Array.Empty<int>(), maxWeight: 0);
            }

            var interval = sortedIntervals[minIndex];

            var ans = getOrCalculate((minIndex + 1, maxCount));

            var ans2 = getOrCalculate((nextIndices[minIndex], maxCount - 1));
            ans2.maxWeight += interval.Weight;
            ans2.indices = ans2.indices.Append(interval.OriginalIndex).OrderBy(x => x).ToArray();

            return ans2.maxWeight > ans.maxWeight || ans2.maxWeight == ans.maxWeight &&
                IsLexicographicallySmaller(ans2.indices, ans.indices)
                    ? ans2
                    : ans;
        });

        return dp.GetOrCalculate((0, 4)).indices;
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

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }

    private record Interval(int Left, int Right, int Weight, int OriginalIndex);
}
