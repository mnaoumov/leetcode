using NUnit.Framework;

namespace LeetCode._009_Palindrome_Number;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.IsPalindrome(121), Is.True);
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.IsPalindrome(-121), Is.False);
    }

    [Test]
    public void Example3()
    {
        Assert.That(Solution.IsPalindrome(10), Is.False);
    }
}