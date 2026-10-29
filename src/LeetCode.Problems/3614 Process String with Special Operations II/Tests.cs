namespace LeetCode.Problems._3614_Process_String_with_Special_Operations_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ProcessStr(testCase.S, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public long K { get; [UsedImplicitly] init; }
        public char Output { get; [UsedImplicitly] init; }
    }
}
