using JetBrains.Annotations;

namespace LeetCode.Problems._2569_Handling_Sum_Queries_After_Update;

/// <summary>
/// https://leetcode.com/submissions/detail/900554542/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public long[] HandleQuery(int[] nums1, int[] nums2, int[][] queries)
    {
        var n = nums1.Length;
        var oneCountsOnTheLeft = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            oneCountsOnTheLeft[i + 1] = oneCountsOnTheLeft[i] + (nums1[i] == 1 ? 1 : 0);
        }

        var sum2 = nums2.Select(num => (long) num).Sum();
        var result = new List<long>();

        var flipIntervals = new List<(int from, int to)>();

        var minFakeInterval = (from: int.MinValue, to: int.MinValue);
        var maxFakeInterval = (from: int.MaxValue, to: int.MaxValue);

        var fromComparer = Comparer<(int from, int to)>.Create((interval1, interval2) => interval1.from.CompareTo(interval2.from));

        foreach (var query in queries)
        {
            var queryType = query[0];

            switch (queryType)
            {
                case 1:
                    var l = query[1];
                    var r = query[2];
                    var currentInterval = (from: l, to: r + 1);
                    var index = flipIntervals.BinarySearch(currentInterval, fromComparer);

                    var previousInterval = minFakeInterval;
                    var nextInterval = maxFakeInterval;

                    if (index < 0)
                    {
                        index = ~index - 1;
                    }

                    if (index < flipIntervals.Count - 1)
                    {
                        nextInterval = flipIntervals[index + 1];
                        flipIntervals.RemoveAt(index + 1);
                    }

                    if (index >= 0)
                    {
                        previousInterval = flipIntervals[index];
                        flipIntervals.RemoveAt(index);
                    }
                    else
                    {
                        index = 0;
                    }

                    var mergedIntervals = MergeIntervals(previousInterval, currentInterval, nextInterval)
                        .Except(new[] { minFakeInterval, maxFakeInterval });
                    flipIntervals.InsertRange(index, mergedIntervals);

                    break;
                case 2:
                    var p = query[1];
                    var sum1 = 0L + oneCountsOnTheLeft[n] + flipIntervals.Sum(CalculateSum1Change);
                    sum2 += sum1 * p;
                    break;
                case 3:
                    result.Add(sum2);
                    break;
            }
        }

        return result.ToArray();

        int CalculateSum1Change((int from, int to) flipInterval)
        {
            var onesCount = oneCountsOnTheLeft[flipInterval.to] - oneCountsOnTheLeft[flipInterval.from];
            return flipInterval.to - flipInterval.from - 2 * onesCount;
        }
    }

    private static IEnumerable<(int from, int to)> MergeIntervals((int from, int to) interval1, (int from, int to) interval2, (int from, int to) interval3)
    {
        var result = MergeIntervals(interval1, interval2).ToList();

        if (result.Count == 0)
        {
            result.Add(interval3);
        }
        else
        {
            var lastInterval = result[^1];
            result.RemoveAt(result.Count - 1);
            result.AddRange(MergeIntervals(lastInterval, interval3));
        }

        return result;
    }

    private static IEnumerable<(int from, int to)> MergeIntervals((int from, int to) interval1, (int from, int to) interval2)
    {
        if (interval1.to < interval2.from)
        {
            yield return interval1;
            yield return interval2;
            yield break;
        }

        if (interval1.to == interval2.from)
        {
            yield return (interval1.from, interval2.to);
            yield break;
        }

        if (interval1.from < interval2.from)
        {
            yield return (interval1.from, interval2.from);
        }

        if (interval2.to < interval1.to)
        {
            yield return (interval2.to, interval1.to);
        }

        if (interval1.to < interval2.to)
        {
            yield return (interval1.to, interval2.to);
        }
    }
}
