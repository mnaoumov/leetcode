using JetBrains.Annotations;

namespace LeetCode.Problems._0252_Meeting_Rooms;

[PublicAPI]
public interface ISolution
{
    public bool CanAttendMeetings(int[][] intervals);
}
