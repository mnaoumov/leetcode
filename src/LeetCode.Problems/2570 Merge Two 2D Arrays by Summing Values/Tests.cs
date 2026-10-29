namespace LeetCode.Problems._2570_Merge_Two_2D_Arrays_by_Summing_Values;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MergeArrays(testCase.Nums1, testCase.Nums2), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Nums1 { get; [UsedImplicitly] init; } = null!;
        public int[][] Nums2 { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
