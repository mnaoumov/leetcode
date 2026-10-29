namespace LeetCode.Problems._1627_Graph_Connectivity_With_Threshold;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.AreConnected(testCase.N, testCase.Threshold, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int Threshold { get; [UsedImplicitly] init; }
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public IList<bool> Output { get; [UsedImplicitly] init; } = null!;
    }
}
