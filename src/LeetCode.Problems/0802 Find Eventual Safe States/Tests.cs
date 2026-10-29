namespace LeetCode.Problems._0802_Find_Eventual_Safe_States;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.EventualSafeNodes(testCase.Graph), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Graph { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
