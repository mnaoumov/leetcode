namespace LeetCode.Problems._2569_Handling_Sum_Queries_After_Update;

/// <summary>
/// https://leetcode.com/submissions/detail/900570484/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
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

                    if (index < 0)
                    {
                        index = ~index;
                    }

                    flipIntervals.Insert(index, currentInterval);

                    var leftChecked = false;

                    if (index == 0)
                    {
                        index = 1;
                        leftChecked = true;
                    }

                    while (true)
                    {
                        if (index > 0 && index < flipIntervals.Count &&
                            flipIntervals[index - 1].to >= flipIntervals[index].from)
                        {
                            var previousInterval = flipIntervals[index - 1];
                            currentInterval = flipIntervals[index];
                            flipIntervals.RemoveAt(index);
                            flipIntervals.RemoveAt(index - 1);
                            var mergeIntervals = MergeIntervals(previousInterval, currentInterval).ToArray();
                            flipIntervals.InsertRange(index - 1, mergeIntervals);
                            index = index - 1 + mergeIntervals.Length;
                            leftChecked = true;
                        }
                        else if (!leftChecked)
                        {
                            index++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    while (index < flipIntervals.Count && index > 0 && flipIntervals[index - 1].to <= flipIntervals[index].from)
                    {

                        index++;
                    }

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
