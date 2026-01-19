namespace LeetCode.Problems._3809_Best_Reachable_Tower;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.BestTower(testCase.Towers, testCase.Center, testCase.Radius), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Towers { get; [UsedImplicitly] init; } = null!;
        public int[] Center { get; [UsedImplicitly] init; } = null!;
        public int Radius { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
