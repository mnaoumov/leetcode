namespace LeetCode.Problems._2660_Determine_the_Winner_of_a_Bowling_Game;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsWinner(testCase.Player1, testCase.Player2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Player1 { get; [UsedImplicitly] init; } = null!;
        public int[] Player2 { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
