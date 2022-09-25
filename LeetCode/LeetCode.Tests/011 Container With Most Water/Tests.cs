using LeetCode._011_Container_With_Most_Water;
using NUnit.Framework;

namespace LeetCode.Tests._011_Container_With_Most_Water;

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
        Assert.That(_solution.MaxArea(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }), Is.EqualTo(49));
    }

    [Test]
    public void Example2()
    {
        Assert.That(_solution.MaxArea(new[] { 1, 1 }), Is.EqualTo(1));
    }

    private static IEnumerable<ISolution> Solutions
    {
        get
        {
            yield return new Solution();
        }
    }
}