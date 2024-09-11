namespace LeetCode.Problems._1992_Find_All_Groups_of_Farmland;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindFarmland(testCase.Land), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Land { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
