namespace LeetCode.Problems._3594_Minimum_Time_to_Transport_All_Individuals;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinTime(testCase.N, testCase.K, testCase.M, testCase.Time, testCase.Mul), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int M { get; [UsedImplicitly] init; }
        public int[] Time { get; [UsedImplicitly] init; } = null!;
        public double[] Mul { get; [UsedImplicitly] init; } = null!;
        public double Output { get; [UsedImplicitly] init; }
    }
}
