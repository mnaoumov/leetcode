namespace LeetCode.Problems._2446_Determine_if_Two_Events_Have_Conflict;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-316/submissions/detail/828277017/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool HaveConflict(string[] event1, string[] event2)
    {
        var (start1, end1) = Parse(event1);
        var (start2, end2) = Parse(event2);

        var start = Max(start1, start2);
        var end = Min(end1, end2);

        return start <= end;
    }

    private static TimeSpan Max(TimeSpan t1, TimeSpan t2) => t1 >= t2 ? t1 : t2;
    private static TimeSpan Min(TimeSpan t1, TimeSpan t2) => t1 <= t2 ? t1 : t2;

    private static (TimeSpan start, TimeSpan end) Parse(IReadOnlyList<string> @event)
    {
        return (start: TimeSpan.Parse(@event[0]), end: TimeSpan.Parse(@event[1]));
    }
}
