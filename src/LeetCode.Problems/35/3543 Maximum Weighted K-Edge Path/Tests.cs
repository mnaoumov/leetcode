namespace LeetCode.Problems._3543_Maximum_Weighted_K_Edge_Path;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxWeight(testCase.N, testCase.Edges, testCase.K, testCase.T), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int T { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
