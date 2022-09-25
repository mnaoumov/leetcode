using LeetCode._013_Roman_to_Integer;
using NUnit.Framework;

namespace LeetCode.Tests._013_Roman_to_Integer;

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
        Assert.That(_solution.RomanToInt("III"), Is.EqualTo(3));
    }

    [Test]
    public void Example2()
    {
        Assert.That(_solution.RomanToInt("LVIII"), Is.EqualTo(58));
    }

    [Test]
    public void Example3()
    {
        Assert.That(_solution.RomanToInt("MCMXCIV"), Is.EqualTo(1994));
    }

    private static IEnumerable<ISolution> Solutions
    {
        get
        {
            yield return new Solution();
        }
    }
}