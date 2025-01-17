using System.Text;

namespace LeetCode.Problems._2381_Shifting_Letters_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1500102849/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public string ShiftingLetters(string s, int[][] shifts)
    {
        var intervals = new List<Interval> { new Interval(0, s.Length, 0) };
        var comparerByStart = Comparer<Interval>.Create((a, b) => a.Start.CompareTo(b.Start));
        var comparerByEnd = Comparer<Interval>.Create((a, b) => a.EndExclusive.CompareTo(b.EndExclusive));

        foreach (var shift in shifts)
        {
            var start = shift[0];
            var end = shift[1];
            var direction = shift[2];
            var diff = direction == 1 ? 1 : -1;

            var startIndex = intervals.BinarySearch(new Interval(start, end, 1), comparerByStart);

            if (startIndex < 0)
            {
                startIndex = ~startIndex;

                var previousInterval = intervals[startIndex - 1];
                intervals.RemoveAt(startIndex - 1);
                intervals.Insert(startIndex - 1, previousInterval with { EndExclusive = start });
                intervals.Insert(startIndex, previousInterval with { Start = start });
            }

            var endIndex = intervals.BinarySearch(new Interval(end, end + 1, 1), comparerByEnd);

            if (endIndex < 0)
            {
                endIndex = ~endIndex;

                var previousInterval = intervals[endIndex];
                intervals.RemoveAt(endIndex);
                intervals.Insert(endIndex, previousInterval with { EndExclusive = end + 1 });
                intervals.Insert(endIndex + 1, previousInterval with { Start = end + 1 });
            }

            for (var i = startIndex; i <= endIndex; i++)
            {
                var interval = intervals[i];
                intervals[i] = interval with { Shift = interval.Shift + diff };
            }
        }

        var sb = new StringBuilder(s);

        foreach (var interval in intervals)
        {
            for(var i = interval.Start; i < interval.EndExclusive; i++)
            {
                var letterIndex = sb[i] - 'a';
                var shiftedLetterIndex = ((letterIndex + interval.Shift) % 26 + 26) % 26;
                sb[i] = (char)(shiftedLetterIndex + 'a');
            }
        }

        return sb.ToString();
    }

    private record Interval(int Start, int EndExclusive, int Shift);
}
