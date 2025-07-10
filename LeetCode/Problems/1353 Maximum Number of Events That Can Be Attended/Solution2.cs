namespace LeetCode.Problems._1353_Maximum_Number_of_Events_That_Can_Be_Attended;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-events-that-can-be-attended/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MaxEvents(int[][] events)
    {
        var eventObjs = events.Select(arr => new Event(arr[0], arr[1])).ToArray();

        var pq = new PriorityQueue<Event, Event>();

        foreach (var @event in eventObjs)
        {
            pq.Enqueue(@event, @event);
        }

        var minDay = 1;
        var ans = 0;

        while (pq.Count > 0)
        {
            var @event = pq.Dequeue();

            if (minDay > @event.EndDay)
            {
                continue;
            }

            if (minDay <= @event.StartDay)
            {
                ans++;
                minDay = @event.StartDay + 1;
            }
            else
            {
                var newEvent = @event with { StartDay = minDay };
                pq.Enqueue(newEvent, newEvent);
            }
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
