namespace LeetCode.Problems._0048_Rotate_Image;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var matrix = ArrayHelper.DeepCopy(testCase.Matrix);
        solution.Rotate(matrix);
        AssertCollectionEqualWithDetails(matrix, testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Matrix { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
