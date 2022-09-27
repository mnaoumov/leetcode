using NUnit.Framework;

namespace LeetCode._838_Push_Dominoes;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.PushDominoes("RR.L"), Is.EqualTo("RR.L"));
    }
    
    [Test]
    public void Example2()
    {
        Assert.That(Solution.PushDominoes(".L.R...LR..L.."), Is.EqualTo("LL.RR.LLRRLL.."));
    }
}