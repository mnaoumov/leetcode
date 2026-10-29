namespace LeetCode.Problems._1288_Remove_Covered_Intervals;

/// <summary>
/// https://leetcode.com/problems/remove-covered-intervals/submissions/2057420220/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        var intervalObjs = intervals.Select(arr => new Interval(arr[0], arr[1]))
            .OrderBy(x => x.Start)
            .ThenByDescending(x => x.End)
            .ToArray();

        var previousInterval = new Interval(int.MinValue, int.MinValue);
        var ans = 0;

        foreach (var interval in intervalObjs)
        {
            if (previousInterval.Start <= interval.Start && interval.End <= previousInterval.End)
            {
                continue;
            }

            ans++;
            previousInterval = interval;
        }

        return ans;
    }

    private sealed record Interval(int Start, int End);
}
