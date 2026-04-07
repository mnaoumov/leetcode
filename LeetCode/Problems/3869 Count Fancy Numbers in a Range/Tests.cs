namespace LeetCode.Problems._3869_Count_Fancy_Numbers_in_a_Range;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountFancy(testCase.L, testCase.R), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long L { get; [UsedImplicitly] init; }
        public long R { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
