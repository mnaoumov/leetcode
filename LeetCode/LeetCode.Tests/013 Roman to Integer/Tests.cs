using LeetCode._013_Roman_to_Integer;
using NUnit.Framework;

namespace LeetCode.Tests._013_Roman_to_Integer;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.RomanToInt("III"), Is.EqualTo(3));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.RomanToInt("LVIII"), Is.EqualTo(58));
    }

    [Test]
    public void Example3()
    {
        Assert.That(Solution.RomanToInt("MCMXCIV"), Is.EqualTo(1994));
    }
}