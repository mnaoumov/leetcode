namespace LeetCode.Problems._0826_Most_Profit_Assigning_Work;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxProfitAssignment(testCase.Difficulty, testCase.Profit, testCase.Worker), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Difficulty { get; [UsedImplicitly] init; } = null!;
        public int[] Profit { get; [UsedImplicitly] init; } = null!;
        public int[] Worker { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
