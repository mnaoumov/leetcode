namespace LeetCode.Problems._1344_Angle_Between_Hands_of_a_Clock;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AngleClock(testCase.Hour, testCase.Minutes), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Hour { get; [UsedImplicitly] init; }
        public int Minutes { get; [UsedImplicitly] init; }
        public double Output { get; [UsedImplicitly] init; }
    }
}
