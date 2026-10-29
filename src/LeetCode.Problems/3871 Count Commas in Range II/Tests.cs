namespace LeetCode.Problems._3871_Count_Commas_in_Range_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountCommas(testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long N { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
