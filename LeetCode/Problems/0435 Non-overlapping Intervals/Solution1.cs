using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0435_Non_overlapping_Intervals;

/// <summary>
/// https://leetcode.com/submissions/detail/933430441/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        var sortedIntervals = intervals.OrderBy(i => i[0]).ThenBy(i => i[1]).ToArray();

        var result = 0;

        var i = 0;
        var j = 1;

        while (j < sortedIntervals.Length)
        {
            if (sortedIntervals[j][0] < sortedIntervals[i][1])
            {
                result++;
            }
            else
            {
                i = j;
            }

            j++;
        }

        return result;
    }
}
