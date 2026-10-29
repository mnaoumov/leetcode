namespace LeetCode.Problems._3332_Maximum_Points_Tourist_Can_Earn;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxScore(testCase.N, testCase.K, testCase.StayScore, testCase.TravelScore), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int[][] StayScore { get; [UsedImplicitly] init; } = null!;
        public int[][] TravelScore { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
