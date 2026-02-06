namespace LeetCode.Problems._0373_Find_K_Pairs_with_Smallest_Sums;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.KSmallestPairs(testCase.Nums1, testCase.Nums2, testCase.K), testCase.Output);
        AssertCollectionEqualWithDetails(solution.KSmallestPairs(testCase.Nums1, testCase.Nums2, testCase.K).Select(x => x[0] + x[1]), testCase.Output.Select(x => x[0] + x[1]));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums1 { get; [UsedImplicitly] init; } = null!;
        public int[] Nums2 { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
