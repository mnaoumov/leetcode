using LeetCode._008_String_to_Integer__atoi_;
using NUnit.Framework;

namespace LeetCode.Tests._008_String_to_Integer__atoi_;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.MyAtoi("42"), Is.EqualTo(42));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.MyAtoi("   -42"), Is.EqualTo(-42));
    }

    [Test]
    public void Example3()
    {
        Assert.That(Solution.MyAtoi("4193 with words"), Is.EqualTo(4193));
    }
}