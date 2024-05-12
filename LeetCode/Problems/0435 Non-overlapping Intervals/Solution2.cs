using JetBrains.Annotations;

namespace LeetCode.Problems._0435_Non_overlapping_Intervals;

/// <summary>
/// https://leetcode.com/submissions/detail/933433756/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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

                if (sortedIntervals[j][1] < sortedIntervals[i][1])
                {
                    i = j;
                }
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
