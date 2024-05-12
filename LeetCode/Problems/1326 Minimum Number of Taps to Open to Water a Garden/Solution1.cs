using JetBrains.Annotations;

namespace LeetCode._1326_Minimum_Number_of_Taps_to_Open_to_Water_a_Garden;

/// <summary>
/// https://leetcode.com/submissions/detail/914676452/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinTaps(int n, int[] ranges)
    {
        var intervals = ranges
            .Select((range, index) => (start: Math.Max(0, index - range), end: Math.Min(n, index + range)))
            .OrderBy(x => x.start).ToArray();

        var result = 0;
        var start = 0;
        var end = 0;
        var i = 0;

        while (start < n)
        {
            while (i < intervals.Length && intervals[i].start <= start)
            {
                end = Math.Max(end, intervals[i].end);
                i++;
            }

            if (start == end)
            {
                return -1;
            }

            start = end;
            result++;
        }

        return result;
    }
}
