namespace LeetCode.Problems._2045_Second_Minimum_Time_to_Reach_Destination;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SecondMinimum(testCase.N, testCase.Edges, testCase.Time, testCase.Change), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int Time { get; [UsedImplicitly] init; }
        public int Change { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
