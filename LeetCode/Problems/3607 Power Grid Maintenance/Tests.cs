namespace LeetCode.Problems._3607_Power_Grid_Maintenance;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ProcessQueries(testCase.C, testCase.Connections, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int C { get; [UsedImplicitly] init; }
        public int[][] Connections { get; [UsedImplicitly] init; } = null!;
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
