namespace LeetCode.Problems._1168_Optimize_Water_Distribution_in_a_Village;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinCostToSupplyWater(testCase.N, testCase.Wells, testCase.Pipes), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[] Wells { get; [UsedImplicitly] init; } = null!;
        public int[][] Pipes { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
