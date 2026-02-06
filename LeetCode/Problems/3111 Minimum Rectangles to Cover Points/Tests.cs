namespace LeetCode.Problems._3111_Minimum_Rectangles_to_Cover_Points;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinRectanglesToCoverPoints(testCase.Points, testCase.W), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Points { get; [UsedImplicitly] init; } = null!;
        public int W { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
