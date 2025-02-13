namespace LeetCode.Problems._3449_Maximize_the_Minimum_Game_Score;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxScore(testCase.Points, testCase.M), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Points { get; [UsedImplicitly] init; } = null!;
        public int M { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
