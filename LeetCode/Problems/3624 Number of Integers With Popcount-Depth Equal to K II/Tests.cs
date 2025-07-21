namespace LeetCode.Problems._3624_Number_of_Integers_With_Popcount_Depth_Equal_to_K_II;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.PopcountDepth(testCase.Nums, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public long[] Nums { get; [UsedImplicitly] init; } = null!;
        public long[][] Queries { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
