namespace LeetCode.Problems._2070_Most_Beautiful_Item_for_Each_Query;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MaximumBeauty(testCase.Items, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Items { get; [UsedImplicitly] init; } = null!;
        public int[] Queries { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
