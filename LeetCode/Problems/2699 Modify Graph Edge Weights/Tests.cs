namespace LeetCode.Problems._2699_Modify_Graph_Edge_Weights;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ModifiedGraphEdges(testCase.N, testCase.Edges, testCase.Source, testCase.Destination, testCase.Target), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int Source { get; [UsedImplicitly] init; }
        public int Destination { get; [UsedImplicitly] init; }
        public int Target { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
