using NUnit.Framework;

namespace LeetCode._020_Valid_Parentheses;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.IsValid("()"), Is.True);
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.IsValid("()[]{}"), Is.True);
    }

    [Test]
    public void Example3()
    {
        Assert.That(Solution.IsValid("(]"), Is.False);
    }
}