using LeetCode._009_Palindrome_Number;
using NUnit.Framework;

namespace LeetCode.Tests._009_Palindrome_Number;

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
        Assert.That(_solution.IsPalindrome(121), Is.True);
    }

    [Test]
    public void Example2()
    {
        Assert.That(_solution.IsPalindrome(-121), Is.False);
    }

    [Test]
    public void Example3()
    {
        Assert.That(_solution.IsPalindrome(10), Is.False);
    }

    private static IEnumerable<ISolution> Solutions
    {
        get
        {
            yield return new Solution();
        }
    }
}