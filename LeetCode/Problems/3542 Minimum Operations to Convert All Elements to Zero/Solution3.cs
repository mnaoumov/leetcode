namespace LeetCode.Problems._3542_Minimum_Operations_to_Convert_All_Elements_to_Zero;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-convert-all-elements-to-zero/submissions/1825557880/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int MinOperations(int[] nums)
    {
        var n = nums.Length;

        var intervals = new List<Interval>();
        var pq = new PriorityQueue<int, (int num, int index)>();

        const int noStart = -1;

        var start = noStart;
        for (var i = 0; i <= n; i++)
        {
            var num = i < n ? nums[i] : 0;

            if (num == 0)
            {
                if (start == noStart)
                {
                    continue;
                }

                intervals.Add(new Interval(start, i));
                start = noStart;
            }
            else
            {
                if (start == noStart)
                {
                    start = i;
                }

                pq.Enqueue(i, (num, i));
            }
        }

        var ans = 0;
        var lastNum = 0;
        var lastEndIndex = 0;

        while (intervals.Count > 0)
        {
            var i = pq.Dequeue();
            var num = nums[i];

            var intervalIndex = intervals.BinarySearch(new Interval(i, i), Interval.ComparerByStart);

            if (intervalIndex < 0)
            {
                intervalIndex = ~intervalIndex - 1;
            }

            var interval = intervals[intervalIndex];

            if (num != lastNum || i > lastEndIndex)
            {
                ans++;
                lastNum = num;
                lastEndIndex = interval.ExclusiveEnd;
            }

            intervals.RemoveAt(intervalIndex);

            if (interval.Start < i)
            {
                intervals.Insert(intervalIndex, interval with { ExclusiveEnd = i });
                intervalIndex++;
            }

            if (i + 1 < interval.ExclusiveEnd)
            {
                intervals.Insert(intervalIndex, interval with { Start = i + 1 });
            }
        }

        return ans;
    }

    private record Interval(int Start, int ExclusiveEnd)
    {
        public static readonly Comparer<Interval> ComparerByStart =
            Comparer<Interval>.Create((a, b) => a.Start.CompareTo(b.Start));
    }
}
