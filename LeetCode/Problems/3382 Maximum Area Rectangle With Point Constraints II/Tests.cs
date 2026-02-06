namespace LeetCode.Problems._3382_Maximum_Area_Rectangle_With_Point_Constraints_II;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxRectangleArea(testCase.XCoord, testCase.YCoord), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] XCoord { get; [UsedImplicitly] init; } = null!;
        public int[] YCoord { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
