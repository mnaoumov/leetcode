namespace LeetCode.Problems._3502_Minimum_Cost_to_Reach_Every_Position;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MinCosts(testCase.Cost), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Cost { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
