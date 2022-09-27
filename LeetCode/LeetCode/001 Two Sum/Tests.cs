using NUnit.Framework;

namespace LeetCode._001_Two_Sum;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        var result = Solution.TwoSum(new[] { 2, 7, 11, 15 }, 9);
        Assert.That(result, Is.EqualTo(new[] { 0, 1 }));
    }

    [Test]
    public void Example2()
    {
        var result = Solution.TwoSum(new[] { 3, 2, 4 }, 6);
        Assert.That(result, Is.EqualTo(new[] { 1, 2 }));
    }

    [Test]
    public void Example3()
    {
        var result = Solution.TwoSum(new[] { 3, 3 }, 6);
        Assert.That(result, Is.EqualTo(new[] { 0, 1 }));
    }
}