namespace LeetCode.Problems._3321_Find_X_Sum_of_All_K_Long_Subarrays_II;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindXSum(testCase.Nums, testCase.K, testCase.X), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int X { get; [UsedImplicitly] init; }
        public long[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
