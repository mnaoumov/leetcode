using LeetCode._003_Longest_Substring_Without_Repeating_Characters;
using NUnit.Framework;

namespace LeetCode.Tests._003_Longest_Substring_Without_Repeating_Characters;

public class Tests
{
    [Test]
    public void Example1()
    {
        Assert.That(new Solution().LengthOfLongestSubstring("abcabcbb"), Is.EqualTo(3));
    }

    [Test]
    public void Example2()
    {
        Assert.That(new Solution().LengthOfLongestSubstring("bbbbb"), Is.EqualTo(1));
    }

    [Test]
    public void Example3()
    {
        Assert.That(new Solution().LengthOfLongestSubstring("pwwkew"), Is.EqualTo(3));
    }
}