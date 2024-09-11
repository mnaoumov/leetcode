namespace LeetCode.Problems._3274_Check_if_Two_Chessboard_Squares_Have_the_Same_Color;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CheckTwoChessboards(testCase.Coordinate1, testCase.Coordinate2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Coordinate1 { get; [UsedImplicitly] init; } = null!;
        public string Coordinate2 { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
