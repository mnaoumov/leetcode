namespace LeetCode._0352_Data_Stream_as_Disjoint_Intervals;

/// <summary>
/// https://leetcode.com/submissions/detail/887098880/
/// </summary>
public class SummaryRanges1 : ISummaryRanges
{
    private readonly List<(int start, int end)> _intervals = new();

    public void AddNum(int value)
    {
        var index = _intervals.BinarySearch((value, 0),
            Comparer<(int start, int end)>.Create((value1, value2) => value1.start.CompareTo(value2.start)));

        if (index >= 0)
        {
            return;
        }

        index = ~index;

        if (index > 0 && _intervals[index - 1].end >= value)
        {
            return;
        }

        var mergedWithPrevious = false;
        var mergedWithNext = false;

        var previous = index > 0 ? _intervals[index - 1] : (start: 0, end: 0);
        var next = index < _intervals.Count ? _intervals[index] : (start: 0, end: 0);

        if (index > 0 && previous.end == value - 1)
        {
            _intervals[index - 1] = (previous.start, value);
            mergedWithPrevious = true;
        }

        if (index < _intervals.Count && next.start == value + 1)
        {
            if (mergedWithPrevious)
            {
                _intervals[index - 1] = (previous.start, next.end);
                _intervals.RemoveAt(index);
            }
            else
            {
                _intervals[index] = (value, next.end);
                mergedWithNext = true;
            }
        }

        if (!mergedWithPrevious && !mergedWithNext)
        {
            _intervals.Insert(index, (value, value));
        }
    }

    public int[][] GetIntervals() => _intervals.Select(x => new[] { x.start, x.end }).ToArray();
}