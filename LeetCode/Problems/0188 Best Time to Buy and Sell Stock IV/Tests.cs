using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0188_Best_Time_to_Buy_and_Sell_Stock_IV;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxProfit(testCase.K, testCase.Prices), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int K { get; [UsedImplicitly] init; }
        public int[] Prices { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
