using LeetCode._001_Two_Sums;
using NUnit.Framework;

namespace LeetCode.Tests._001_Two_Sums;

public class Tests
{
    [Test]
    public void Example1()
    {
        var result = new Solution().TwoSum(new[] { 2, 7, 11, 15 }, 9);
        Assert.That(result, Is.EqualTo(new[] { 0, 1 }));
    }

    [Test]
    public void Example2()
    {
        var result = new Solution().TwoSum(new[] { 3, 2, 4 }, 6);
        Assert.That(result, Is.EqualTo(new[] { 1, 2 }));
    }

    [Test]
    public void Example3()
    {
        var result = new Solution().TwoSum(new[] { 3, 3 }, 6);
        Assert.That(result, Is.EqualTo(new[] { 0, 1 }));
    }
}