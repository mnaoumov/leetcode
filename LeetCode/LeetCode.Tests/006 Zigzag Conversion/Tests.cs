using LeetCode._006_Zigzag_Conversion;
using NUnit.Framework;

namespace LeetCode.Tests._006_Zigzag_Conversion;

public class Tests
{
    [Test]
    public void Example1()
    {
        Assert.That(new Solution().Convert("PAYPALISHIRING", 3), Is.EqualTo("PAHNAPLSIIGYIR"));
    }

    [Test]
    public void Example2()
    {
        Assert.That(new Solution().Convert("PAYPALISHIRING", 4), Is.EqualTo("PINALSIGYAHRPI"));
    }

    [Test]
    public void Test1()
    {
        Assert.That(new Solution().Convert("A", 1), Is.EqualTo("A"));
    }
}