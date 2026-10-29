namespace LeetCode.Problems._1353_Maximum_Number_of_Events_That_Can_Be_Attended;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-events-that-can-be-attended/submissions/1688992028/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int MaxEvents(int[][] events)
    {
        var eventObjs = events.Select(arr => new Event(arr[0], arr[1]))
            .OrderBy(e => e.EndDay)
            .ThenBy(e => e.StartDay)
            .ToArray();

        var minDay = 1;
        var ans = 0;

        foreach (var @event in eventObjs)
        {
            if (minDay > @event.EndDay)
            {
                continue;
            }

            minDay = Math.Max(minDay, @event.StartDay) + 1;
            ans++;
        }

        return ans;
    }

    private record Event(int StartDay, int EndDay);
}
