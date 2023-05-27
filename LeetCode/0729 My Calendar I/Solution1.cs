using JetBrains.Annotations;

namespace LeetCode._0729_My_Calendar_I;

/// <summary>
/// https://leetcode.com/submissions/detail/957985018/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IMyCalendar Create() => new MyCalendar();

    private class MyCalendar : IMyCalendar
    {
        private readonly List<(int start, int end)> _intervals = new();

        public bool Book(int start, int end)
        {
            var low = 0;
            var high = _intervals.Count - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (_intervals[mid].start == start)
                {
                    return false;
                }

                if (_intervals[mid].start < start)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            if (high >= 0 && _intervals[high].end > start)
            {
                return false;
            }

            _intervals.Insert(low, (start, end));

            return true;
        }
    }
}
