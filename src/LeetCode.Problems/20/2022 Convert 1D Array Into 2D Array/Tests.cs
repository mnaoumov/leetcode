namespace LeetCode.Problems._2022_Convert_1D_Array_Into_2D_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.Construct2DArray(testCase.Original, testCase.M, testCase.N), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Original { get; [UsedImplicitly] init; } = null!;
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
