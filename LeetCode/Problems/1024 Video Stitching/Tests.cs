namespace LeetCode.Problems._1024_Video_Stitching;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.VideoStitching(testCase.Clips, testCase.Time), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Clips { get; [UsedImplicitly] init; } = null!;
        public int Time { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
