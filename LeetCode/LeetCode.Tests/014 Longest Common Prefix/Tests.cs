using LeetCode._014_Longest_Common_Prefix;
using NUnit.Framework;

namespace LeetCode.Tests._014_Longest_Common_Prefix;

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
        Assert.That(_solution.LongestCommonPrefix(new[] { "flower", "flow", "flight" }), Is.EqualTo("fl"));
    }

    [Test]
    public void Example2()
    {
        Assert.That(_solution.LongestCommonPrefix(new[] { "dog", "racecar", "car" }), Is.EqualTo(""));
    }

    private static IEnumerable<ISolution> Solutions
    {
        get
        {
            yield return new Solution();
        }
    }
}