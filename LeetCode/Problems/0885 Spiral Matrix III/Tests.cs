namespace LeetCode.Problems._0885_Spiral_Matrix_III;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SpiralMatrixIII(testCase.Rows, testCase.Cols, testCase.RStart, testCase.CStart), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int Rows { get; [UsedImplicitly] init; }
        public int Cols { get; [UsedImplicitly] init; }
        public int RStart { get; [UsedImplicitly] init; }
        public int CStart { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
