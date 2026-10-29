#pragma warning disable CA1051
namespace LeetCode.DataStructure;

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

    protected bool Equals(Interval other) => start == other.start && end == other.end;

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((Interval) obj);
    }

    // ReSharper disable NonReadonlyMemberInGetHashCode
    public override int GetHashCode() => HashCode.Combine(start, end);
    // ReSharper restore NonReadonlyMemberInGetHashCode
}
