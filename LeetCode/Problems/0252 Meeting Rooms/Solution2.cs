using JetBrains.Annotations;

namespace LeetCode.Problems._0252_Meeting_Rooms;

/// <summary>
/// https://leetcode.com/submissions/detail/921929065/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool CanAttendMeetings(int[][] intervals)
    {
        if (intervals.Length == 0)
        {
            return true;
        }

        intervals = intervals.OrderBy(i => i[0]).ToArray();
        return Enumerable.Range(0, intervals.Length - 1).All(i => intervals[i][1] <= intervals[i + 1][0]);
    }
}
