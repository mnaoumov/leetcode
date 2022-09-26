using LeetCode._007_Reverse_Integer;
using NUnit.Framework;

namespace LeetCode.Tests._007_Reverse_Integer;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.Reverse(123), Is.EqualTo(321));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.Reverse(-123), Is.EqualTo(-321));
    }

    [Test]
    public void Example3()
    {
        Assert.That(Solution.Reverse(120), Is.EqualTo(21));
    }
}