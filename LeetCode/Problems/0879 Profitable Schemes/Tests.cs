namespace LeetCode.Problems._0879_Profitable_Schemes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ProfitableSchemes(testCase.N, testCase.MinProfit, testCase.Group, testCase.Profit), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int MinProfit { get; [UsedImplicitly] init; }
        public int[] Group { get; [UsedImplicitly] init; } = null!;
        public int[] Profit { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
