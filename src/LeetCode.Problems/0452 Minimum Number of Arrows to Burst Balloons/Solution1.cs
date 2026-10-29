namespace LeetCode.Problems._0452_Minimum_Number_of_Arrows_to_Burst_Balloons;

/// <summary>
/// https://leetcode.com/submissions/detail/871627901/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindMinArrowShots(int[][] points) => FindMinArrowShotsImpl(points);

    private static int FindMinArrowShotsImpl(IEnumerable<int[]> rangeArr)
    {
        var ranges = rangeArr.Select(Range.FromArray).OrderBy(p => p.XEnd).ToArray();

        var result = ranges.Length;

        var currentRange = ranges[0];

        foreach (var range in ranges.Skip(1))
        {
            if (range.TryIntersectWith(currentRange) is { } subRange)
            {
                result--;
                currentRange = subRange;
            }
            else
            {
                currentRange = range;
            }
        }

        return result;
    }

    private record Range(int XStart, int XEnd)
    {
        public static Range FromArray(IReadOnlyList<int> arr) => new(arr[0], arr[1]);

        public Range? TryIntersectWith(Range otherRange)
        {
            var start = Math.Max(XStart, otherRange.XStart);
            var end = Math.Min(XEnd, otherRange.XEnd);
            return start <= end ? new Range(start, end) : null;
        }
    }
}
