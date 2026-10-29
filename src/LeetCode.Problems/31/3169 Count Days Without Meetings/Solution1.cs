namespace LeetCode.Problems._3169_Count_Days_Without_Meetings;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-400/submissions/detail/1274828677/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountDays(int days, int[][] meetings)
    {
        var intervals = new List<Interval> { new(0, 0), new(1, days), new(days + 1, days + 1) };

        var startComparer = Comparer<Interval>.Create((a, b) => a.Start.CompareTo(b.Start));
        var endComparer = Comparer<Interval>.Create((a, b) => a.End.CompareTo(b.End));

        foreach (var meeting in meetings)
        {
            var meetingInterval = new Interval(meeting[0], meeting[1]);

            var startIndex = intervals.BinarySearch(meetingInterval, startComparer);

            if (startIndex < 0)
            {
                startIndex = ~startIndex - 1;
            }

            var endIndex = intervals.BinarySearch(meetingInterval, endComparer);

            if (endIndex < 0)
            {
                endIndex = ~endIndex;
            }

            var startInterval = intervals[startIndex];
            var endInterval = intervals[endIndex];

            if (startInterval.End >= meetingInterval.Start)
            {
                intervals.RemoveAt(startIndex);
                var newStartInterval = startInterval with { End = meetingInterval.Start - 1 };

                if (newStartInterval.IsValid)
                {
                    intervals.Insert(startIndex, newStartInterval);
                }
                else
                {
                    startIndex--;
                    endIndex--;
                }

                if (startIndex == endIndex)
                {
                    endIndex++;
                    intervals.Insert(endIndex, endInterval);
                }
            }

            if (endInterval.Start <= meetingInterval.End)
            {
                intervals.RemoveAt(endIndex);
                var newEndInterval = endInterval with { Start = meetingInterval.End + 1 };

                if (newEndInterval.IsValid)
                {
                    intervals.Insert(endIndex, newEndInterval);
                }
            }

            var count = endIndex - startIndex - 1;

            if (count > 0)
            {
                intervals.RemoveRange(startIndex + 1, count);
            }
        }

        return intervals.Select(i => i.Length).Sum() - 2;
    }

    private record Interval(int Start, int End)
    {
        public bool IsValid => Start <= End;
        public int Length => End - Start + 1;
    }
}
