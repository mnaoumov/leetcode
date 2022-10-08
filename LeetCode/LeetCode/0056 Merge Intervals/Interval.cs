// ReSharper disable All
namespace LeetCode._0056_Merge_Intervals;

public class Interval
{
    public readonly int start;
    public readonly int end;

    public Interval(int start, int end)
    {
        this.start = start;
        this.end = end;
    }

    public static Interval[] FromArrays(int[][] arrays) => arrays.Select(array => new Interval(array[0], array[1])).ToArray();

    public static int[][] ToArrays(IList<Interval> intervals) => intervals.Select(interval => new[] { interval.start, interval.end }).ToArray();
}