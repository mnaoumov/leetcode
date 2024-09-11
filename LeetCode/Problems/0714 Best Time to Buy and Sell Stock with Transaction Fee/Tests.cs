using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0714_Best_Time_to_Buy_and_Sell_Stock_with_Transaction_Fee;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxProfit(testCase.Prices, testCase.Fee), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Prices { get; [UsedImplicitly] init; } = null!;
        public int Fee { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
