using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace LeetCode._015_3Sum;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.ThreeSum(new[] { -1, 0, 1, 2, -1, -4 }),
            IsEquivalentToIgnoringItemOrder(new[] { new[] { -1, -1, 2 }, new[] { -1, 0, 1 } }));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.ThreeSum(new[] { 0, 1, 1 }), IsEquivalentToIgnoringItemOrder(Array.Empty<int[]>()));
    }

    [Test]
    public void Example3()
    {
        Assert.That(Solution.ThreeSum(new[] { 0, 0, 0 }), IsEquivalentToIgnoringItemOrder(new[] { new[] { 0, 0, 0 } }));
    }
}