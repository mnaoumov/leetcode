namespace LeetCode.Problems._3685_Subsequence_Sum_After_Capping_Elements;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SubsequenceSumAfterCapping(testCase.Nums, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public bool[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
