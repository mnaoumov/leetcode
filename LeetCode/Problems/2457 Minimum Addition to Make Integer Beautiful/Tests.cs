namespace LeetCode.Problems._2457_Minimum_Addition_to_Make_Integer_Beautiful;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MakeIntegerBeautiful(testCase.N, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long N { get; [UsedImplicitly] init; }
        public int Target { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
