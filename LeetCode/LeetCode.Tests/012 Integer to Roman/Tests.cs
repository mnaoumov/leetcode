using LeetCode._012_Integer_to_Roman;
using NUnit.Framework;

namespace LeetCode.Tests._012_Integer_to_Roman;

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
        Assert.That(_solution.IntToRoman(3), Is.EqualTo("III"));
    }

    [Test]
    public void Example2()
    {
        Assert.That(_solution.IntToRoman(58), Is.EqualTo("LVIII"));
    }

    [Test]
    public void Example3()
    {
        Assert.That(_solution.IntToRoman(1994), Is.EqualTo("MCMXCIV"));
    }

    private static IEnumerable<ISolution> Solutions
    {
        get
        {
            yield return new Solution();
        }
    }
}