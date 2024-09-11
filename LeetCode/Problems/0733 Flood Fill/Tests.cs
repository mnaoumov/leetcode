namespace LeetCode.Problems._0733_Flood_Fill;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FloodFill(testCase.Image, testCase.Sr, testCase.Sc, testCase.Color), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Image { get; [UsedImplicitly] init; } = null!;
        public int Sr { get; [UsedImplicitly] init; }
        public int Sc { get; [UsedImplicitly] init; }
        public int Color { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
