namespace LeetCode.Problems._3169_Count_Days_Without_Meetings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountDays(testCase.Days, testCase.Meetings), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Days { get; [UsedImplicitly] init; }
        public int[][] Meetings { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
