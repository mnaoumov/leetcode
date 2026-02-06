namespace LeetCode.Problems._3439_Reschedule_Meetings_for_Maximum_Free_Time_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxFreeTime(testCase.EventTime, testCase.K, testCase.StartTime, testCase.EndTime), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int EventTime { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int[] StartTime { get; [UsedImplicitly] init; } = null!;
        public int[] EndTime { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
