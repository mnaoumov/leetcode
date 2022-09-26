using LeetCode._016_3Sum_Closest;
using NUnit.Framework;

namespace LeetCode.Tests._016_3Sum_Closest;

[TestFixtureSource(nameof(Solutions))]
public class Tests
{
    private readonly ISolution _solution;

    public Tests(ISolution solution)
    {
        _solution = solution;
    }

    [Test]
    public void Example1()
    {
        Assert.That(_solution.ThreeSumClosest(new [] { -1, 2, 1, -4 }, 1), Is.EqualTo(2));
    }

    [Test]
    public void Example2()
    {
        Assert.That(_solution.ThreeSumClosest(new [] { 0, 0, 0 }, 1), Is.EqualTo(0));
    }

    private static IEnumerable<ISolution> Solutions
    {
        get
        {
            yield return new Solution();
        }
    }
}