namespace LeetCode.Problems._3562_Maximum_Profit_from_Trading_Stocks_with_Discounts;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxProfit(testCase.N, testCase.Present, testCase.Future, testCase.Hierarchy, testCase.Budget), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[] Present { get; [UsedImplicitly] init; } = null!;
        public int[] Future { get; [UsedImplicitly] init; } = null!;
        public int[][] Hierarchy { get; [UsedImplicitly] init; } = null!;
        public int Budget { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
