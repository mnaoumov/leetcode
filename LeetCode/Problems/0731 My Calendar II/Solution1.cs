namespace LeetCode.Problems._0731_My_Calendar_II;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyCalendarTwo Create() => new MyCalendarTwo();

    private class MyCalendarTwo : IMyCalendarTwo
    {
        private const int MaxEnd = 1_000_000_000;
        private readonly Dictionary<Interval, int> _counts = new()
        {
            [new Interval(0, MaxEnd)] = 0
        };
        private readonly List<Interval> _sortedIntervals = new() { new Interval(0, MaxEnd) };

        public bool Book(int start, int end)
        {
            var startIndex = _sortedIntervals.BinarySearch(new Interval(start, start), Interval.ComparerByStart);
            if (startIndex < 0)
            {
                startIndex = ~startIndex;
                SplitInterval(startIndex - 1, start);
            }

            var endIndex = _sortedIntervals.BinarySearch(new Interval(end, end), Interval.ComparerByEnd);

            if (endIndex < 0)
            {
                endIndex = ~endIndex;
                SplitInterval(endIndex, end);
            }

            for (var i = startIndex; i <= endIndex; i++)
            {
                if (_counts[_sortedIntervals[i]] >= 2)
                {
                    return false;
                }
            }

            for (var i = startIndex; i <= endIndex; i++)
            {
                _counts[_sortedIntervals[i]]++;
            }

            return true;

            void SplitInterval(int index, int splitValue)
            {
                var previous = _sortedIntervals[index];
                var count = _counts[previous];
                _counts.Remove(previous);
                var left = previous with { End = splitValue };
                var right = previous with { Start = splitValue };
                _counts.Add(left, count);
                _counts.Add(right, count);
                _sortedIntervals.RemoveAt(index);
                _sortedIntervals.Insert(index, left);
                _sortedIntervals.Insert(index + 1, right);
            }
        }
    }

    private record Interval(int Start, int End)
    {
        public static IComparer<Interval> ComparerByStart { get; } =
            Comparer<Interval>.Create((a, b) => a.Start.CompareTo(b.Start));
        public static IComparer<Interval> ComparerByEnd { get; } =
            Comparer<Interval>.Create((a, b) => a.End.CompareTo(b.End));
    }
}
