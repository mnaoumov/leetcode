using System.Collections;
using System.Text;

namespace LeetCode.Problems._0758_Bold_Words_in_String;

/// <summary>
/// https://leetcode.com/problems/bold-words-in-string/submissions/2076497654/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public string BoldWords(string[] words, string s)
    {
        var intervals = new DisjointIntervals();
        const string startTag = "<b>";
        const string endTag = "</b>";

        const int notFoundIndex = -1;

        foreach (var word in words)
        {
            var startIndex = 0;

            while (true)
            {
                startIndex = s.IndexOf(word, startIndex, StringComparison.Ordinal);

                if (startIndex == notFoundIndex)
                {
                    break;
                }

                intervals.Add(new Interval(startIndex, startIndex + word.Length));
                startIndex++;
            }
        }

        var sb = new StringBuilder(s);
        var offset = 0;

        foreach (var interval in intervals)
        {
            sb.Insert(offset + interval.StartInclusive, startTag);
            offset += startTag.Length;
            sb.Insert(offset + interval.EndExclusive, endTag);
            offset += endTag.Length;
        }

        return sb.ToString();
    }

    private sealed record Interval(int StartInclusive, int EndExclusive)
    {
        public static readonly Comparer<Interval> StartComparer =
            Comparer<Interval>.Create((a, b) => a.StartInclusive.CompareTo(b.StartInclusive));
    }

    private sealed class DisjointIntervals : IEnumerable<Interval>
    {
        private readonly List<Interval> _intervals = new();

        public void Add(Interval interval)
        {
            var index = _intervals.BinarySearch(interval, Interval.StartComparer);

            if (index < 0)
            {
                index = ~index;
            }

            _intervals.Insert(index, interval);

            if (index - 1 >= 0)
            {
                var previousInterval = _intervals[index - 1];

                if (previousInterval.EndExclusive >= interval.StartInclusive)
                {
                    interval = previousInterval with
                    {
                        EndExclusive = Math.Max(previousInterval.EndExclusive, interval.EndExclusive)
                    };
                    index--;
                    _intervals[index] = interval;
                    _intervals.RemoveAt(index + 1);
                }
            }

            if (index + 1 >= _intervals.Count)
            {
                return;
            }

            var nextInterval = _intervals[index + 1];

            if (interval.EndExclusive < nextInterval.StartInclusive)
            {
                return;
            }

            interval = interval with
            {
                EndExclusive = Math.Max(interval.EndExclusive, nextInterval.EndExclusive)
            };
            _intervals[index] = interval;
            _intervals.RemoveAt(index + 1);
        }

        public IEnumerator<Interval> GetEnumerator() => _intervals.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) _intervals).GetEnumerator();
    }
}
