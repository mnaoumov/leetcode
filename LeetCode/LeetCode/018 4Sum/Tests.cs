// TODO Fix namespace

using NUnit.Framework;

namespace LeetCode._018_4Sum;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.FourSum(new[] { 1, 0, -1, 0, -2, 2 }, 0),
            IsEquivalentToIgnoringItemOrder(new[] { new[] { -2, -1, 1, 2 }, new[] { -2, 0, 0, 2 }, new[] { -1, 0, 0, 1 } }));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.FourSum(new[] { 2, 2, 2, 2, 2 }, 8),
            IsEquivalentToIgnoringItemOrder(new[] { new[] { -2, 2, 2, 2 } }));
    }
}