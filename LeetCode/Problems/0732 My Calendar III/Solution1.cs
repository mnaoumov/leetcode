using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0732_My_Calendar_III;

/// <summary>
/// https://leetcode.com/submissions/detail/816924979/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyCalendarThree Create() => new MyCalendarThree();

    private class MyCalendarThree : IMyCalendarThree
    {
        private readonly Dictionary<(int start, int end), int> _eventBookingDict = new();
        private int _maxBooking;

        public int Book(int start, int end)
        {
            var newEvent = (start, end);
            InitBooking(newEvent);

            foreach (var @event in _eventBookingDict.Keys.ToArray())
            {
                var intersection = Intersect(@event, newEvent);

                if (intersection.start >= intersection.end)
                {
                    continue;
                }

                InitBooking(intersection);
                var booking = Math.Max(_eventBookingDict[intersection], _eventBookingDict[@event] + 1);
                _eventBookingDict[intersection] = booking;
                _maxBooking = Math.Max(_maxBooking, booking);
            }

            return _maxBooking;
        }

        private void InitBooking((int start, int end) @event) => _eventBookingDict.TryAdd(@event, 0);

        private static (int start, int end) Intersect((int start, int end) event1, (int start, int end) event2) => (start: Math.Max(event1.start, event2.start), end: Math.Min(event1.end, event2.end));
    }
}
