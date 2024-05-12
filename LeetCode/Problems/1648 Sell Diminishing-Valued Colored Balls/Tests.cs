using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._1648_Sell_Diminishing_Valued_Colored_Balls;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxProfit(testCase.Inventory, testCase.Orders), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Inventory { get; [UsedImplicitly] init; } = null!;
        public int Orders { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
