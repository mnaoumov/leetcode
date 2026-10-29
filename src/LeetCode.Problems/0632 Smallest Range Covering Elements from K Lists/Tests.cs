namespace LeetCode.Problems._0632_Smallest_Range_Covering_Elements_from_K_Lists;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SmallestRange(testCase.Nums), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<IList<int>> Nums { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
