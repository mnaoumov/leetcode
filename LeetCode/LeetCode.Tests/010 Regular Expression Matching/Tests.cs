using LeetCode._010_Regular_Expression_Matching;
using NUnit.Framework;

namespace LeetCode.Tests._010_Regular_Expression_Matching;

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
        Assert.That(_solution.IsMatch("aa", "a"), Is.False);
    }

    [Test]
    public void Example2()
    {
        Assert.That(_solution.IsMatch("aa", "a*"), Is.True);
    }

    [Test]
    public void Example3()
    {
        Assert.That(_solution.IsMatch("ab", ".*"), Is.True);
    }

    private static IEnumerable<ISolution> Solutions
    {
        get
        {
            yield return new Solution();
        }
    }
}