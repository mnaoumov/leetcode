namespace LeetCode.Problems._2943_Maximize_Area_of_Square_Hole_in_Grid;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximizeSquareHoleArea(testCase.N, testCase.M, testCase.HBars, testCase.VBars), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int M { get; [UsedImplicitly] init; }
        public int[] HBars { get; [UsedImplicitly] init; } = null!;
        public int[] VBars { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
