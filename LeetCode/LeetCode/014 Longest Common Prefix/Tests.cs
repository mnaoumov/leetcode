using NUnit.Framework;

namespace LeetCode._014_Longest_Common_Prefix;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.LongestCommonPrefix(new[] {"flower", "flow", "flight"}), Is.EqualTo("fl"));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.LongestCommonPrefix(new[] {"dog", "racecar", "car"}), Is.EqualTo(""));
    }
}