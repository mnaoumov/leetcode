using JetBrains.Annotations;

namespace LeetCode.Problems._0759_Employee_Free_Time;

/// <summary>
/// https://leetcode.com/submissions/detail/957250074/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule)
    {
        var pq = new PriorityQueue<(int time, bool isMeetingEnd), (int time, bool isMeetingEnd)>();

        foreach (var intervals in schedule)
        {
            foreach (var interval in intervals)
            {
                pq.Enqueue((interval.start, false), (interval.start, false));
                pq.Enqueue((interval.end, true), (interval.end, true));
            }
        }

        var ongoingMeetingCount = 0;

        var ans = new List<Interval>();

        while (pq.Count > 0)
        {
            var (time, isMeetingEnd) = pq.Dequeue();

            if (isMeetingEnd)
            {
                ongoingMeetingCount--;

                if (ongoingMeetingCount == 0 && pq.Count > 0)
                {
                    ans.Add(new Interval(time, time));
                }
            }
            else
            {
                ongoingMeetingCount++;

                if (ongoingMeetingCount == 1 && ans.Count > 0)
                {
                    ans[^1].end = time;
                }
            }
        }

        return ans;
    }
}
