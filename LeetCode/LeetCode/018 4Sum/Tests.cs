// TODO Fix namespace

using NUnit.Framework;

namespace LeetCode._018_4Sum;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<_Template.ISolution>
{
    public Tests(_Template.ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution, Is.Not.Null);
    }
}