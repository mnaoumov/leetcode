

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0057_Insert_Interval;

/// <seealso href="https://leetcode.com/submissions/detail/819441661/">Submission</seealso>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution4 : ISolution
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

        return result.ToArray();
    }
}
