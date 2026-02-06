namespace LeetCode.Problems._3652_Best_Time_to_Buy_and_Sell_Stock_using_Strategy;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxProfit(testCase.Prices, testCase.Strategy, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Prices { get; [UsedImplicitly] init; } = null!;
        public int[] Strategy { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
