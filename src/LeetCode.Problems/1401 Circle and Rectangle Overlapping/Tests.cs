namespace LeetCode.Problems._1401_Circle_and_Rectangle_Overlapping;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CheckOverlap(testCase.Radius, testCase.XCenter, testCase.YCenter, testCase.X1, testCase.Y1, testCase.X2, testCase.Y2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Radius { get; [UsedImplicitly] init; }
        public int XCenter { get; [UsedImplicitly] init; }
        public int YCenter { get; [UsedImplicitly] init; }
        public int X1 { get; [UsedImplicitly] init; }
        public int Y1 { get; [UsedImplicitly] init; }
        public int X2 { get; [UsedImplicitly] init; }
        public int Y2 { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
