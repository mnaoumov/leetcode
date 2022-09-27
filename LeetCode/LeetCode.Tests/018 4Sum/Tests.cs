// TODO Fix namespace
using LeetCode._Template;
using NUnit.Framework;

namespace LeetCode.Tests._Template;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution, Is.Not.Null);
    }
}