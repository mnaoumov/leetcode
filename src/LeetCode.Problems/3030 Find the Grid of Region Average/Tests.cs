namespace LeetCode.Problems._3030_Find_the_Grid_of_Region_Average;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ResultGrid(testCase.Image, testCase.Threshold), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Image { get; [UsedImplicitly] init; } = null!;
        public int Threshold { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
