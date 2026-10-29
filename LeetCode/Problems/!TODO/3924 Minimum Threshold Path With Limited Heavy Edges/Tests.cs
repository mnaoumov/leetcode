namespace LeetCode.Problems._3924_Minimum_Threshold_Path_With_Limited_Heavy_Edges;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumThreshold(testCase.N, testCase.Edges, testCase.Source, testCase.Target, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int Source { get; [UsedImplicitly] init; }
        public int Target { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
