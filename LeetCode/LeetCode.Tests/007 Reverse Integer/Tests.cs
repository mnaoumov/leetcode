using LeetCode._007_Reverse_Integer;
using NUnit.Framework;

namespace LeetCode.Tests._007_Reverse_Integer;

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
        Assert.That(_solution.Reverse(123), Is.EqualTo(321));
    }

    [Test]
    public void Example2()
    {
        Assert.That(_solution.Reverse(-123), Is.EqualTo(-321));
    }

    [Test]
    public void Example3()
    {
        Assert.That(_solution.Reverse(120), Is.EqualTo(21));
    }

    private static IEnumerable<ISolution> Solutions
    {
        get
        {
            yield return new StringReverseSolution();
            yield return new DigitSolution();
        }
    }
}