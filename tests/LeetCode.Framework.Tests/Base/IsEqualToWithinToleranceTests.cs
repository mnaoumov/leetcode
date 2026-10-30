using LeetCode.Base;

namespace LeetCode.Framework.Tests.Base;

public class IsEqualToWithinToleranceTests : TestsBase
{
    // A SQL result: rows of strings, decimals and nulls, which NUnit's own Within refuses outright.
    [Test]
    public void MatchesRowsMixingNumbersWithOtherValues()
    {
        object[][] actual = [["Alice", 1.000001m, DBNull.Value], ["Bob", 2, 3L]];
        object[][] expected = [["Alice", 1.0, DBNull.Value], ["Bob", 2L, 3]];

        Assert.That(actual, IsEqualToWithinTolerance(expected));
    }

    [Test]
    public void MatchesNestedDoublesWithinTolerance()
    {
        double[][] actual = [[1.000001, 2], [3]];
        double[][] expected = [[1, 2.000001], [3]];

        Assert.That(actual, IsEqualToWithinTolerance(expected));
    }

    [Test]
    public void RejectsADoubleOutsideTolerance()
    {
        Assert.That(IsEqualToWithinTolerance(new object[] { "a", 1.0 }).ApplyTo(new object[] { "a", 1.0001 }).IsSuccess, Is.False);
    }

    [Test]
    public void RejectsADifferentString()
    {
        Assert.That(IsEqualToWithinTolerance(new object[] { "b", 1.0 }).ApplyTo(new object[] { "a", 1.0 }).IsSuccess, Is.False);
    }

    [Test]
    public void RejectsADifferentLength()
    {
        Assert.That(IsEqualToWithinTolerance(new[] { 1.0 }).ApplyTo(new[] { 1.0, 2.0 }).IsSuccess, Is.False);
    }
}
