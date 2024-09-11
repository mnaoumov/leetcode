namespace LeetCode.Problems._1255_Maximum_Score_Words_Formed_by_Letters;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxScoreWords(testCase.Words, testCase.Letters, testCase.Score), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public char[] Letters { get; [UsedImplicitly] init; } = null!;
        public int[] Score { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
