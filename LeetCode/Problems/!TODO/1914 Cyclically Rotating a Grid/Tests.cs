namespace LeetCode.Problems._1914_Cyclically_Rotating_a_Grid;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.RotateGrid(testCase.Grid, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Grid { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
