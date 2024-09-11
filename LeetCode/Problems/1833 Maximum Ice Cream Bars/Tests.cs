using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1833_Maximum_Ice_Cream_Bars;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxIceCream(testCase.Costs, testCase.Coins), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Costs { get; [UsedImplicitly] init; } = null!;
        public int Coins { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
