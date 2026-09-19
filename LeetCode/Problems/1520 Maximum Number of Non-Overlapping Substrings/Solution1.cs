namespace LeetCode.Problems._1520_Maximum_Number_of_Non_Overlapping_Substrings;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-non-overlapping-substrings/submissions/2145888005/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> MaxNumOfSubstrings(string s)
    {
        var n = s.Length;

        var firstLetterIndices = new Dictionary<char, int>();

        for (var i = 0; i < n; i++)
        {
            var letter = s[i];
            firstLetterIndices.TryAdd(letter, i);
        }

        var lastLetterIndices = new Dictionary<char, int>();

        for (var i = n - 1; i >= 0; i--)
        {
            var letter = s[i];
            lastLetterIndices.TryAdd(letter, i);
        }

        var minIntervals = firstLetterIndices.Keys.Select(letter => new Interval(firstLetterIndices[letter], lastLetterIndices[letter])).ToList();

        for (var i = 0; i < minIntervals.Count; i++)
        {
            var hasChanges = true;
            var minInterval = minIntervals[i];

            while (hasChanges)
            {
                hasChanges = false;

                for (var j = minInterval.Start; j <= minInterval.End; j++)
                {
                    var letter = s[j];
                    var newMinInterval = new Interval(Math.Min(minInterval.Start, firstLetterIndices[letter]), Math.Max(minInterval.End, lastLetterIndices[letter]));

                    if (newMinInterval == minInterval)
                    {
                        continue;
                    }

                    minInterval = newMinInterval;
                    minIntervals[i] = minInterval;
                    hasChanges = true;
                    break;
                }
            }
        }

        var starts = new SortedSet<int>();
        var resultIntervals = new List<Interval>();

        foreach (var interval in minIntervals.OrderBy(x=>x.Length))
        {
            if (starts.GetViewBetween(interval.Start, interval.End).Count != 0)
            {
                continue;
            }

            resultIntervals.Add(interval);
            starts.Add(interval.Start);
        }

        return resultIntervals.Select(x => s[x.Start..(x.End + 1)]).ToArray();
    }

    private sealed record Interval(int Start, int End)
    {
        public int Length => End - Start + 1;
    }
}
