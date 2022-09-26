using LeetCode._990_Satisfiability_of_Equality_Equations;
using NUnit.Framework;

namespace LeetCode.Tests._990_Satisfiability_of_Equality_Equations;

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
        Assert.That(_solution.EquationsPossible(new []{ "a==b", "b!=a" }), Is.False);
    }

    [Test]
    public void Example2()
    {
        Assert.That(_solution.EquationsPossible(new[] { "b==a", "a==b" }), Is.True);
    }

    [Test]
    public void Test1()
    {
        Assert.That(_solution.EquationsPossible(new[] { "e==d", "e==a", "f!=d", "b!=c", "a==b" }), Is.True);
    }

    private static IEnumerable<ISolution> Solutions
    {
        get
        {
            yield return new Solution();
        }
    }
}