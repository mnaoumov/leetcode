namespace LeetCode.Problems._0836_Rectangle_Overlap;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsRectangleOverlap(testCase.Rec1, testCase.Rec2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Rec1 { get; [UsedImplicitly] init; } = null!;
        public int[] Rec2 { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
