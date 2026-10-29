namespace LeetCode.Problems._0073_Set_Matrix_Zeroes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var matrix = ArrayHelper.DeepCopy(testCase.Matrix);
        solution.SetZeroes(matrix);
        AssertCollectionEqualWithDetails(matrix, testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Matrix { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
