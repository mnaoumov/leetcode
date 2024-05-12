using JetBrains.Annotations;

namespace LeetCode._0252_Meeting_Rooms;

/// <summary>
/// https://leetcode.com/submissions/detail/921928297/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public bool CanAttendMeetings(int[][] intervals)
    {
        intervals = intervals.OrderBy(i => i[0]).ToArray();
        return Enumerable.Range(0, intervals.Length - 1).All(i => intervals[i][1] <= intervals[i + 1][0]);
    }
}
