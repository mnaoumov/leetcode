namespace LeetCode.Problems._3812_Minimum_Edge_Toggles_on_a_Tree;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MinimumFlips(testCase.N, testCase.Edges, testCase.Start, testCase.Target), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public string Start { get; [UsedImplicitly] init; } = null!;
        public string Target { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
