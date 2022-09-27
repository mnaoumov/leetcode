using NUnit.Framework;

namespace LeetCode._003_Longest_Substring_Without_Repeating_Characters;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.LengthOfLongestSubstring("abcabcbb"), Is.EqualTo(3));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.LengthOfLongestSubstring("bbbbb"), Is.EqualTo(1));
    }

    [Test]
    public void Example3()
    {
        Assert.That(Solution.LengthOfLongestSubstring("pwwkew"), Is.EqualTo(3));
    }
}