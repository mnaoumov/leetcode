namespace LeetCode.Problems._3621_Number_of_Integers_With_Popcount_Depth_Equal_to_K_I;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.PopcountDepth(testCase.N, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long N { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
