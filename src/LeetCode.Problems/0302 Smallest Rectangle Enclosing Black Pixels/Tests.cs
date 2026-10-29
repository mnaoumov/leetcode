namespace LeetCode.Problems._0302_Smallest_Rectangle_Enclosing_Black_Pixels;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinArea(testCase.Image, testCase.X, testCase.Y), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public char[][] Image { get; [UsedImplicitly] init; } = null!;
        public int X { get; [UsedImplicitly] init; }
        public int Y { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
