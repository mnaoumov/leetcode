namespace LeetCode.Problems._3633_Earliest_Finish_Time_for_Land_and_Water_Rides_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.EarliestFinishTime(testCase.LandStartTime, testCase.LandDuration, testCase.WaterStartTime, testCase.WaterDuration), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] LandStartTime { get; [UsedImplicitly] init; } = null!;
        public int[] LandDuration { get; [UsedImplicitly] init; } = null!;
        public int[] WaterStartTime { get; [UsedImplicitly] init; } = null!;
        public int[] WaterDuration { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
