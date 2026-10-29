namespace LeetCode.Problems._2920_Maximum_Points_After_Collecting_Coins_From_All_Nodes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximumPoints(testCase.Edges, testCase.Coins, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int[] Coins { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
