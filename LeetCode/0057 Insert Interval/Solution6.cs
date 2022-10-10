namespace LeetCode._0057_Insert_Interval;

/// <summary>
/// https://leetcode.com/submissions/detail/819447391/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution6 : ISolution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();
        var inserted = false;

        foreach (var interval in intervals)
        {
            if (interval[1] < newInterval[0] || newInterval[1] < interval[0])
            {
                result.Add(interval);
            }
            else
            {
                newInterval = new[] { Math.Min(interval[0], newInterval[0]), Math.Max(interval[1], newInterval[1]) };
                if (!inserted)
                {
                    result.Add(newInterval);
                    inserted = true;
                }
                else
                {
                    result[^1] = newInterval;
                }
            }
        }

        if (!inserted)
        {
            if (intervals.Length > 0 && newInterval[1] < intervals[0][0])
            {
                result.Insert(0, newInterval);
            }
            else
            {
                result.Add(newInterval);
            }
        }

        return result.ToArray();
    }
}