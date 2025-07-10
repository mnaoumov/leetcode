namespace LeetCode.Problems._1353_Maximum_Number_of_Events_That_Can_Be_Attended;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-events-that-can-be-attended/submissions/1689046102/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int MaxEvents(int[][] events)
    {
        var eventObjs = events.Select(arr => new Event(arr[0], arr[1]))
            .OrderBy(e => e.StartDay)
            .ThenBy(e => e.EndDay)
            .ToArray();

        var minDay = 1;
        var ans = 0;

        var pq = new PriorityQueue<Event, int>();

        var i = 0;
        var n = eventObjs.Length;

        while (true)
        {
            while (i < n && eventObjs[i].EndDay < minDay)
            {
                i++;
            }

            while (i < n && eventObjs[i].StartDay <= minDay)
            {
                pq.Enqueue(eventObjs[i], eventObjs[i].EndDay);
                i++;
            }

            while (pq.Count > 0 && pq.Peek().EndDay < minDay)
            {
                pq.Dequeue();
            }

            if (pq.Count == 0 && i == n)
            {
                break;
            }

            Event @event;

            if (pq.Count > 0)
            {
                @event = pq.Dequeue();
            }
            else
            {
                @event = eventObjs[i];
                i++;
            }

            minDay = Math.Max(minDay, @event.StartDay) + 1;
            ans++;
        }

        return ans;
    }

    private record Event(int StartDay, int EndDay) : IComparable<Event>
    {
        public int CompareTo(Event? other) =>
            other is null
                ? 1
                : (StartDay, EndDay).CompareTo((other.StartDay, other.EndDay));
    }
}
