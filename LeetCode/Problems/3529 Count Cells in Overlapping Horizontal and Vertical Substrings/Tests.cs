namespace LeetCode.Problems._3529_Count_Cells_in_Overlapping_Horizontal_and_Vertical_Substrings;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountCells(testCase.Grid, testCase.Pattern), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public char[][] Grid { get; [UsedImplicitly] init; } = null!;
        public string Pattern { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
