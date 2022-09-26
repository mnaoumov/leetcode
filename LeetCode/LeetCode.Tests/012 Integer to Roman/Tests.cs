using LeetCode._012_Integer_to_Roman;
using NUnit.Framework;

namespace LeetCode.Tests._012_Integer_to_Roman;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.IntToRoman(3), Is.EqualTo("III"));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.IntToRoman(58), Is.EqualTo("LVIII"));
    }

    [Test]
    public void Example3()
    {
        Assert.That(Solution.IntToRoman(1994), Is.EqualTo("MCMXCIV"));
    }
}