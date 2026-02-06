namespace LeetCode.Problems._1235_Maximum_Profit_in_Job_Scheduling;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.JobScheduling(testCase.StartTime, testCase.EndTime, testCase.Profit), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] StartTime { get; [UsedImplicitly] init; } = null!;
        public int[] EndTime { get; [UsedImplicitly] init; } = null!;
        public int[] Profit { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
