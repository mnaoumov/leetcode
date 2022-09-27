using NUnit.Framework;

namespace LeetCode._006_Zigzag_Conversion;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.Convert("PAYPALISHIRING", 3), Is.EqualTo("PAHNAPLSIIGYIR"));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.Convert("PAYPALISHIRING", 4), Is.EqualTo("PINALSIGYAHRPI"));
    }

    [Test]
    public void Test1()
    {
        Assert.That(Solution.Convert("A", 1), Is.EqualTo("A"));
    }
}