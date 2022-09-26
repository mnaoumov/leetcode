using LeetCode._005_Longest_Palindromic_Substring;
using NUnit.Framework;

namespace LeetCode.Tests._005_Longest_Palindromic_Substring;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.LongestPalindrome("babad"), Is.EqualTo("bab"));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.LongestPalindrome("cbbd"), Is.EqualTo("bb"));
    }

    [Test]
    public void Test1()
    {
        Assert.That(Solution.LongestPalindrome("a"), Is.EqualTo("a"));
    }
}