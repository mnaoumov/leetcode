using LeetCode.DataStructure;

namespace LeetCode.Tests.DataStructure;

public class IntervalTests
{
    [Test]
    public void FromArray_CreatesInterval()
    {
        var interval = Interval.FromArray([1, 5]);
        Assert.That(interval.start, Is.EqualTo(1));
        Assert.That(interval.end, Is.EqualTo(5));
    }

    [Test]
    public void FromArrays_CreatesMultipleIntervals()
    {
        var intervals = Interval.FromArrays([[1, 2], [3, 4]]);
        Assert.That(intervals.Length, Is.EqualTo(2));
        Assert.That(intervals[0].start, Is.EqualTo(1));
        Assert.That(intervals[1].end, Is.EqualTo(4));
    }

    [Test]
    public void ToArrays_ConvertsBack()
    {
        var intervals = new[] { new Interval(1, 2), new Interval(3, 4) };
        var arrays = Interval.ToArrays(intervals);
        Assert.That(arrays, Is.EqualTo(new[] { new[] { 1, 2 }, new[] { 3, 4 } }));
    }

    [Test]
    public void Equals_SameValues_ReturnsTrue()
    {
        var a = new Interval(1, 5);
        var b = new Interval(1, 5);
        Assert.That(a, Is.EqualTo(b));
    }

    [Test]
    public void Equals_DifferentValues_ReturnsFalse()
    {
        var a = new Interval(1, 5);
        var b = new Interval(1, 6);
        Assert.That(a, Is.Not.EqualTo(b));
    }

    [Test]
    public void Equals_Null_ReturnsFalse()
    {
        var a = new Interval(1, 5);
        Assert.That(a.Equals(null), Is.False);
    }

    [Test]
    public void Equals_Self_ReturnsTrue()
    {
        var a = new Interval(1, 5);
        Assert.That(a.Equals(a), Is.True);
    }

    [Test]
    public void GetHashCode_SameValues_SameHash()
    {
        var a = new Interval(1, 5);
        var b = new Interval(1, 5);
        Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
    }
}
