using LeetCode._001_Two_Sum;
using NUnit.Framework;

namespace LeetCode.Tests._001_Two_Sum;

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
        var result = _solution.TwoSum(new[] { 2, 7, 11, 15 }, 9);
        Assert.That(result, Is.EqualTo(new[] { 0, 1 }));
    }

    [Test]
    public void Example2()
    {
        var result = _solution.TwoSum(new[] { 3, 2, 4 }, 6);
        Assert.That(result, Is.EqualTo(new[] { 1, 2 }));
    }

    [Test]
    public void Example3()
    {
        var result = _solution.TwoSum(new[] { 3, 3 }, 6);
        Assert.That(result, Is.EqualTo(new[] { 0, 1 }));
    }

    private static IEnumerable<ISolution> Solutions
    {
        get
        {
            yield return new BruteForceSolution();
            yield return new LookupSolution();
            yield return new HashMapSolution();
            yield return new HashMapOnePassSolution();
        }
    }
}