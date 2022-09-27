using NUnit.Framework;

namespace LeetCode._010_Regular_Expression_Matching;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.IsMatch("aa", "a"), Is.False);
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.IsMatch("aa", "a*"), Is.True);
    }

    [Test]
    public void Example3()
    {
        Assert.That(Solution.IsMatch("ab", ".*"), Is.True);
    }
}