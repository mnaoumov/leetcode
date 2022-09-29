using NUnit.Framework;

namespace LeetCode._658_Find_K_Closest_Elements;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.FindClosestElements(new[] { 1, 2, 3, 4, 5 }, 4, 3), Is.EqualTo(new[] { 1, 2, 3, 4 }));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.FindClosestElements(new[] { 1, 2, 3, 4, 5 }, 4, -1), Is.EqualTo(new[] { 1, 2, 3, 4 }));
    }
}