using LeetCode._007_Reverse_Integer;
using NUnit.Framework;

namespace LeetCode.Tests._007_Reverse_Integer;

public class Tests
{
    [Test]
    public void Example1()
    {
        Assert.That(new Solution().Reverse(123), Is.EqualTo(321));
    }

    [Test]
    public void Example2()
    {
        Assert.That(new Solution().Reverse(-123), Is.EqualTo(-321));
    }

    [Test]
    public void Example3()
    {
        Assert.That(new Solution().Reverse(120), Is.EqualTo(21));
    }
}