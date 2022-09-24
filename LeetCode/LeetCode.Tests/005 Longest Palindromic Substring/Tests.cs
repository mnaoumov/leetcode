using LeetCode._005_Longest_Palindromic_Substring;
using NUnit.Framework;

namespace LeetCode.Tests._005_Longest_Palindromic_Substring;

public class Tests
{
    [Test]
    public void Example1()
    {
        Assert.That(new Solution().LongestPalindrome("babad"), Is.EqualTo("bab"));
    }

    [Test]
    public void Example2()
    {
        Assert.That(new Solution().LongestPalindrome("cbbd"), Is.EqualTo("bb"));
    }

    [Test]
    public void Test1()
    {
        Assert.That(new Solution().LongestPalindrome("a"), Is.EqualTo("a"));
    }
}