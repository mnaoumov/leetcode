namespace LeetCode.Problems._2651_Calculate_Delayed_Arrival_Time;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindDelayedArrivalTime(testCase.ArrivalTime, testCase.DelayedTime), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int ArrivalTime { get; [UsedImplicitly] init; }
        public int DelayedTime { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
