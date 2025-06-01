namespace LeetCode.Problems._3372_Maximize_the_Number_of_Target_Nodes_After_Connecting_Trees_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MaxTargetNodes(testCase.Edges1, testCase.Edges2, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Edges1 { get; [UsedImplicitly] init; } = null!;
        public int[][] Edges2 { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
