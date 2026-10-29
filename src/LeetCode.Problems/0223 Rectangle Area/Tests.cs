namespace LeetCode.Problems._0223_Rectangle_Area;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ComputeArea(testCase.Ax1, testCase.Ay1, testCase.Ax2, testCase.Ay2, testCase.Bx1, testCase.By1, testCase.Bx2, testCase.By2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Ax1 { get; [UsedImplicitly] init; }
        public int Ay1 { get; [UsedImplicitly] init; }
        public int Ax2 { get; [UsedImplicitly] init; }
        public int Ay2 { get; [UsedImplicitly] init; }
        public int Bx1 { get; [UsedImplicitly] init; }
        public int By1 { get; [UsedImplicitly] init; }
        public int Bx2 { get; [UsedImplicitly] init; }
        public int By2 { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
