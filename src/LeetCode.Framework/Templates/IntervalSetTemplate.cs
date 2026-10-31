// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class IntervalSetTemplate
{
    // Sorted, disjoint half-open intervals [Start, End): Add merges overlapping and touching intervals, Remove splits them.
    // Every call is O((k + 1) log n), where k is how many stored intervals it touches.
    public sealed class IntervalSet
    {
        private readonly SortedSet<(long Start, long End)> _intervals = new();

        /// <summary>The number of points covered.</summary>
        public long TotalLength { get; private set; }

        public int Count => _intervals.Count;

        public IEnumerable<(long Start, long End)> Intervals => _intervals;

        public void Add(long start, long end)
        {
            if (start >= end)
            {
                return;
            }

            if (Floor(start) is { } floor && floor.End >= start)
            {
                start = floor.Start;
            }

            foreach (var interval in StartingBetween(start, end))
            {
                end = Math.Max(end, interval.End);
                RemoveInterval(interval);
            }

            AddInterval((start, end));
        }

        public void Remove(long start, long end)
        {
            if (start >= end)
            {
                return;
            }

            var from = Floor(start) is { } floor && floor.End > start ? floor.Start : start;

            foreach (var interval in StartingBetween(from, end - 1))
            {
                RemoveInterval(interval);

                if (interval.Start < start)
                {
                    AddInterval((interval.Start, start));
                }

                if (interval.End > end)
                {
                    AddInterval((end, interval.End));
                }
            }
        }

        /// <summary>Whether every point of [start, end) is covered.</summary>
        public bool Covers(long start, long end) => start >= end || Floor(start) is { } floor && floor.End >= end;

        public bool Contains(long point) => Covers(point, point + 1);

        // The interval with the largest Start <= point, if any.
        private (long Start, long End)? Floor(long point)
        {
            foreach (var interval in _intervals.GetViewBetween((long.MinValue, long.MinValue), (point, long.MaxValue)).Reverse())
            {
                return interval;
            }

            return null;
        }

        // The intervals with from <= Start <= to, copied so the set can change while the caller walks them.
        private List<(long Start, long End)> StartingBetween(long from, long to) =>
            from > to ? [] : _intervals.GetViewBetween((from, long.MinValue), (to, long.MaxValue)).ToList();

        private void AddInterval((long Start, long End) interval)
        {
            _intervals.Add(interval);
            TotalLength += interval.End - interval.Start;
        }

        private void RemoveInterval((long Start, long End) interval)
        {
            _intervals.Remove(interval);
            TotalLength -= interval.End - interval.Start;
        }
    }

    // O(n log n). Merges intervals that overlap or touch (next.Start <= current End), which suits both closed intervals
    // ([1, 2] and [2, 3] give [1, 3]) and half-open ones ([1, 2) and [2, 3) give [1, 3)).
    public static List<(long Start, long End)> Merge(IEnumerable<(long Start, long End)> intervals)
    {
        var merged = new List<(long Start, long End)>();

        foreach (var (start, end) in intervals.OrderBy(interval => interval.Start))
        {
            if (merged.Count > 0 && start <= merged[^1].End)
            {
                merged[^1] = (merged[^1].Start, Math.Max(merged[^1].End, end));
            }
            else
            {
                merged.Add((start, end));
            }
        }

        return merged;
    }
}
