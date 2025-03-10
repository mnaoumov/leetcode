namespace LeetCode.Problems._3478_Choose_K_Elements_With_Maximum_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindMaxSum(testCase.Nums1, testCase.Nums2, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums1 { get; [UsedImplicitly] init; } = null!;
        public int[] Nums2 { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public long[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
