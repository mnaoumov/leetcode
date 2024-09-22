namespace LeetCode.Problems._3295_Report_Spam_Message;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ReportSpam(testCase.Message, testCase.BannedWords), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Message { get; [UsedImplicitly] init; } = null!;
        public string[] BannedWords { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
