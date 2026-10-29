namespace LeetCode.Problems._2409_Count_Days_Spent_Together;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountDaysTogether(testCase.ArriveAlice, testCase.LeaveAlice, testCase.ArriveBob, testCase.LeaveBob), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string ArriveAlice { get; [UsedImplicitly] init; } = null!;
        public string LeaveAlice { get; [UsedImplicitly] init; } = null!;
        public string ArriveBob { get; [UsedImplicitly] init; } = null!;
        public string LeaveBob { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
