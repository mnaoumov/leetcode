namespace LeetCode.Problems._1922_Count_Good_Numbers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountGoodNumbers(testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long N { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
