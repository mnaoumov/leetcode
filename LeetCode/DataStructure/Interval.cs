using JetBrains.Annotations;

namespace LeetCode;

[PublicAPI]
public class Interval
{
    // ReSharper disable once InconsistentNaming
    public int start;
    // ReSharper disable once InconsistentNaming
    public int end;

    public Interval(int start, int end)
    {
        this.start = start;
        this.end = end;
    }

    public static Interval[] FromArrays(IEnumerable<int[]> arrays) => arrays.Select(FromArray).ToArray();

    public static Interval FromArray(int[] array) => new(array[0], array[1]);

    public static int[][] ToArrays(IEnumerable<Interval> intervals) => intervals.Select(interval => new[] { interval.start, interval.end }).ToArray();
}